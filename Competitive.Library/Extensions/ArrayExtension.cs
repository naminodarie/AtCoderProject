﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Kzrnm.Competitive
{
    using static MethodImplOptions;
    public static class __ArrayExtension
    {
        [MethodImpl(AggressiveInlining)]
        public static T[] Fill<T>(this T[] arr, T value)
        {
            arr.AsSpan().Fill(value);
            return arr;
        }
        [MethodImpl(AggressiveInlining)]
        public static T[] Sort<T>(this T[] arr) { Array.Sort(arr); return arr; }
        [MethodImpl(AggressiveInlining)]
        public static string[] Sort(this string[] arr) => Sort(arr, StringComparer.Ordinal);
        [MethodImpl(AggressiveInlining)]
        public static T[] Sort<T, U>(this T[] arr, Func<T, U> selector) where U : IComparable<U>
        {
            Array.Sort(arr.Select(selector).ToArray(), arr);
            return arr;
        }
        [MethodImpl(AggressiveInlining)]
        public static T[] Sort<T>(this T[] arr, Comparison<T> comparison) { Array.Sort(arr, comparison); return arr; }
        [MethodImpl(AggressiveInlining)]
        public static T[] Sort<T>(this T[] arr, IComparer<T> comparer) { Array.Sort(arr, comparer); return arr; }
        [MethodImpl(AggressiveInlining)]
        public static T[] Reverse<T>(this T[] arr) { Array.Reverse(arr); return arr; }
        [MethodImpl(AggressiveInlining)]
        public static ref T Get<T>(this T[] arr, int index)
        {
            if (index < 0) index += arr.Length;
            return ref arr[index];
        }
        [MethodImpl(AggressiveInlining)]
        public static ref readonly T GetOrDummy<T>(this ReadOnlySpan<T> arr, int index, T dummy = default)
        {
            if ((uint)index < (uint)arr.Length)
                return ref arr[index];
            Dummy<T>.dummy = dummy;
            return ref Dummy<T>.dummy;
        }
        [MethodImpl(AggressiveInlining)]
        public static ref T GetOrDummy<T>(this Span<T> arr, int index, T dummy = default)
        {
            if ((uint)index < (uint)arr.Length)
                return ref arr[index];
            Dummy<T>.dummy = dummy;
            return ref Dummy<T>.dummy;
        }
        [MethodImpl(AggressiveInlining)]
        public static ref T GetOrDummy<T>(this T[] arr, int index, T dummy = default)
        {
            if ((uint)index < (uint)arr.Length)
                return ref arr[index];
            Dummy<T>.dummy = dummy;
            return ref Dummy<T>.dummy;
        }
        [MethodImpl(AggressiveInlining)]
        public static ref T GetOrDummy<T>(this T[][] arr,
            int index1,
            int index2,
            T dummy = default)
        {
            if ((uint)index1 < (uint)arr.Length &&
                (uint)index2 < (uint)arr[index1].Length)
                return ref arr[index1][index2];
            Dummy<T>.dummy = dummy;
            return ref Dummy<T>.dummy;
        }
        [MethodImpl(AggressiveInlining)]
        public static ref T GetOrDummy<T>(this T[][][] arr,
            int index1,
            int index2,
            int index3,
            T dummy = default)
        {
            if ((uint)index1 < (uint)arr.Length &&
                (uint)index2 < (uint)arr[index1].Length &&
                (uint)index3 < (uint)arr[index1][index2].Length)
                return ref arr[index1][index2][index3];
            Dummy<T>.dummy = dummy;
            return ref Dummy<T>.dummy;
        }
        private static class Dummy<T> { public static T dummy; }
    }
}
