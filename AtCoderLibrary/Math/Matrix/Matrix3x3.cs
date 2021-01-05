﻿using System;
using System.Runtime.CompilerServices;

namespace AtCoder
{
    using static MethodImplOptions;
    public readonly struct Matrix3x3<T, TOp>
        where TOp : struct, IArithmeticOperator<T>
    {
        private static TOp op = default;
        public readonly (T Col0, T Col1, T Col2) Row0;
        public readonly (T Col0, T Col1, T Col2) Row1;
        public readonly (T Col0, T Col1, T Col2) Row2;
        public Matrix3x3((T Col0, T Col1, T Col2) row0, (T Col0, T Col1, T Col2) row1, (T Col0, T Col1, T Col2) row2)
        {
            this.Row0 = row0;
            this.Row1 = row1;
            this.Row2 = row2;
        }
        public static readonly Matrix3x3<T, TOp> Identity = new Matrix3x3<T, TOp>(
            (op.MultiplyIdentity, default(T), default(T)),
            (default(T), op.MultiplyIdentity, default(T)),
            (default(T), default(T), op.MultiplyIdentity));

        public static Matrix3x3<T, TOp> operator -(Matrix3x3<T, TOp> x)
            => new Matrix3x3<T, TOp>(
                (op.Minus(x.Row0.Col0), op.Minus(x.Row0.Col1), op.Minus(x.Row0.Col2)),
                (op.Minus(x.Row1.Col0), op.Minus(x.Row1.Col1), op.Minus(x.Row1.Col2)),
                (op.Minus(x.Row2.Col0), op.Minus(x.Row2.Col1), op.Minus(x.Row2.Col2)));
        public static Matrix3x3<T, TOp> operator +(Matrix3x3<T, TOp> x, Matrix3x3<T, TOp> y)
            => new Matrix3x3<T, TOp>(
                (op.Add(x.Row0.Col0, y.Row0.Col0), op.Add(x.Row0.Col1, y.Row0.Col1), op.Add(x.Row0.Col2, y.Row0.Col2)),
                (op.Add(x.Row1.Col0, y.Row1.Col0), op.Add(x.Row1.Col1, y.Row1.Col1), op.Add(x.Row1.Col2, y.Row1.Col2)),
                (op.Add(x.Row2.Col0, y.Row2.Col0), op.Add(x.Row2.Col1, y.Row2.Col1), op.Add(x.Row2.Col2, y.Row2.Col2)));
        public static Matrix3x3<T, TOp> operator -(Matrix3x3<T, TOp> x, Matrix3x3<T, TOp> y)
            => new Matrix3x3<T, TOp>(
                (op.Subtract(x.Row0.Col0, y.Row0.Col0), op.Subtract(x.Row0.Col1, y.Row0.Col1), op.Subtract(x.Row0.Col2, y.Row0.Col2)),
                (op.Subtract(x.Row1.Col0, y.Row1.Col0), op.Subtract(x.Row1.Col1, y.Row1.Col1), op.Subtract(x.Row1.Col2, y.Row1.Col2)),
                (op.Subtract(x.Row2.Col0, y.Row2.Col0), op.Subtract(x.Row2.Col1, y.Row2.Col1), op.Subtract(x.Row2.Col2, y.Row2.Col2)));
        public static Matrix3x3<T, TOp> operator *(Matrix3x3<T, TOp> x, Matrix3x3<T, TOp> y)
            => new Matrix3x3<T, TOp>(
                (
                    op.Add(op.Add(op.Multiply(x.Row0.Col0, y.Row0.Col0), op.Multiply(x.Row0.Col1, y.Row1.Col0)), op.Multiply(x.Row0.Col2, y.Row2.Col0)),
                    op.Add(op.Add(op.Multiply(x.Row0.Col0, y.Row0.Col1), op.Multiply(x.Row0.Col1, y.Row1.Col1)), op.Multiply(x.Row0.Col2, y.Row2.Col1)),
                    op.Add(op.Add(op.Multiply(x.Row0.Col0, y.Row0.Col2), op.Multiply(x.Row0.Col1, y.Row1.Col2)), op.Multiply(x.Row0.Col2, y.Row2.Col2))
                ),
                (
                    op.Add(op.Add(op.Multiply(x.Row1.Col0, y.Row0.Col0), op.Multiply(x.Row1.Col1, y.Row1.Col0)), op.Multiply(x.Row1.Col2, y.Row2.Col0)),
                    op.Add(op.Add(op.Multiply(x.Row1.Col0, y.Row0.Col1), op.Multiply(x.Row1.Col1, y.Row1.Col1)), op.Multiply(x.Row1.Col2, y.Row2.Col1)),
                    op.Add(op.Add(op.Multiply(x.Row1.Col0, y.Row0.Col2), op.Multiply(x.Row1.Col1, y.Row1.Col2)), op.Multiply(x.Row1.Col2, y.Row2.Col2))
                ),
                (
                    op.Add(op.Add(op.Multiply(x.Row2.Col0, y.Row0.Col0), op.Multiply(x.Row2.Col1, y.Row1.Col0)), op.Multiply(x.Row2.Col2, y.Row2.Col0)),
                    op.Add(op.Add(op.Multiply(x.Row2.Col0, y.Row0.Col1), op.Multiply(x.Row2.Col1, y.Row1.Col1)), op.Multiply(x.Row2.Col2, y.Row2.Col1)),
                    op.Add(op.Add(op.Multiply(x.Row2.Col0, y.Row0.Col2), op.Multiply(x.Row2.Col1, y.Row1.Col2)), op.Multiply(x.Row2.Col2, y.Row2.Col2))
                )
            );

        /// <summary>
        /// <paramref name="y"/> 乗した行列を返す。
        /// </summary>
        public Matrix3x3<T, TOp> Pow(long y) => MathLibGeneric.Pow<Matrix3x3<T, TOp>, Matrix3x3Operator<T, TOp>>(this, y);
    }

    public struct Matrix3x3Operator<T, TOp> : IArithmeticOperator<Matrix3x3<T, TOp>>
        where TOp : struct, IArithmeticOperator<T>
    {
        public Matrix3x3<T, TOp> MultiplyIdentity => Matrix3x3<T, TOp>.Identity;

        [MethodImpl(AggressiveInlining)]
        public Matrix3x3<T, TOp> Add(Matrix3x3<T, TOp> x, Matrix3x3<T, TOp> y) => x + y;
        [MethodImpl(AggressiveInlining)]
        public Matrix3x3<T, TOp> Subtract(Matrix3x3<T, TOp> x, Matrix3x3<T, TOp> y) => x - y;
        [MethodImpl(AggressiveInlining)]
        public Matrix3x3<T, TOp> Multiply(Matrix3x3<T, TOp> x, Matrix3x3<T, TOp> y) => x * y;
        [MethodImpl(AggressiveInlining)]
        public Matrix3x3<T, TOp> Minus(Matrix3x3<T, TOp> x) => -x;

        [MethodImpl(AggressiveInlining)]
        public Matrix3x3<T, TOp> Increment(Matrix3x3<T, TOp> x) => throw new NotSupportedException();
        [MethodImpl(AggressiveInlining)]
        public Matrix3x3<T, TOp> Decrement(Matrix3x3<T, TOp> x) => throw new NotSupportedException();
        [MethodImpl(AggressiveInlining)]
        public Matrix3x3<T, TOp> Divide(Matrix3x3<T, TOp> x, Matrix3x3<T, TOp> y) => throw new NotSupportedException();
        [MethodImpl(AggressiveInlining)]
        public Matrix3x3<T, TOp> Modulo(Matrix3x3<T, TOp> x, Matrix3x3<T, TOp> y) => throw new NotSupportedException();
    }
}
