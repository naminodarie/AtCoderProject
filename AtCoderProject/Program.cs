﻿using System;
using System.Collections.Generic;
using System.Linq;
using IEnumerable = System.Collections.IEnumerable;
using IEnumerator = System.Collections.IEnumerator;
using BitArray = System.Collections.BitArray;
using BigInteger = System.Numerics.BigInteger;
using TextReader = System.IO.TextReader;
using static AtCoderProject.Global;

namespace AtCoderProject
{
    public class Program
    {
        public object Calc()
        {
            var N = consoleReader.Int;
            var M = consoleReader.Int;
            return (N - 1) * (M - 1);
        }


        #region いつもの
#pragma warning disable
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)] private ConsoleReader consoleReader;
        public Program(ConsoleReader consoleReader) { this.consoleReader = consoleReader; }
        static void Main() => Console.WriteLine(new Program(new ConsoleReader(Console.In)).Calc()); static string AllLines<T>(IEnumerable<T> source) => string.Join("\n", source);
    }
    static class Global
    {
        private class ComparerReverseImpl<T> : Comparer<T> where T : IComparable<T> { public override int Compare(T y, T x) => x.CompareTo(y); public override bool Equals(object obj) => obj != null && GetType() == obj.GetType(); public override int GetHashCode() => GetType().GetHashCode(); }
        public static IComparer<T> ComparerReverse<T>() where T : IComparable<T> => new ComparerReverseImpl<T>();
        public static BigInteger ParseBigInteger(string s)
        {
            // MonoのBigInteger.Parseが遅いので自前実装
            var res = BigInteger.Zero;
            var splited = new string[(s.Length + 7) / 8];
            for (int i = 0; i < splited.Length - 1; i++)
            {
                splited[i] = s.Substring(8 * i, 8);
            }
            splited[splited.Length - 1] = s.Substring(8 * (splited.Length - 1));
            foreach (var sp in splited)
            {
                res *= (int)Math.Pow(10, sp.Length);
                res += int.Parse(sp);
            }
            return res;
        }
    }
    static class Ext
    {
        public static IComparer<T> Reverse<T>(this IComparer<T> comparer) => Comparer<T>.Create((x, y) => comparer.Compare(y, x));
        public static Dictionary<TKey, int> GroupCount<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector) => source.GroupBy(keySelector).ToDictionary(g => g.Key, g => g.Count());
        public static Dictionary<TKey, int> GroupCount<TKey>(this IEnumerable<TKey> source) => source.GroupCount(i => i);
    }
    public class ConsoleReader { private string[] ReadLineSplit() => textReader.ReadLine().Split(Array.Empty<char>(), StringSplitOptions.RemoveEmptyEntries); private string[] line = Array.Empty<string>(); private int linePosition; private TextReader textReader; public ConsoleReader(TextReader tr) { textReader = tr; } public int Int => int.Parse(String); public int Int0 => Int - 1; public long Long => long.Parse(String); public double Double => double.Parse(String); public string String { get { if (linePosition >= line.Length) { linePosition = 0; line = ReadLineSplit(); } return line[linePosition++]; } } public class SplitLine { private string[] splited; public SplitLine(ConsoleReader cr) { splited = cr.ReadLineSplit(); cr.line = Array.Empty<string>(); } public int[] Int => String.Select(x => int.Parse(x)).ToArray(); public int[] Int0 => String.Select(x => int.Parse(x) - 1).ToArray(); public long[] Long => String.Select(x => long.Parse(x)).ToArray(); public double[] Double => String.Select(x => double.Parse(x)).ToArray(); public string[] String => splited; } public SplitLine Split => new SplitLine(this); public class RepeatReader : IEnumerable<ConsoleReader> { ConsoleReader cr; int count; public RepeatReader(ConsoleReader cr, int count) { this.cr = cr; this.count = count; } public IEnumerator<ConsoleReader> GetEnumerator() => Enumerable.Repeat(cr, count).GetEnumerator(); System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator(); public IEnumerable<string> String => this.Select(cr => cr.String); public IEnumerable<int> Int => this.Select(cr => cr.Int); public IEnumerable<int> Int0 => this.Select(cr => cr.Int - 1); public IEnumerable<long> Long => this.Select(cr => cr.Long); public IEnumerable<double> Double => this.Select(cr => cr.Double); } public RepeatReader Repeat(int count) => new RepeatReader(this, count); }
    #endregion
}
