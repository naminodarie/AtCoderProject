﻿using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace Kzrnm.Competitive
{
    /// <summary>
    /// mod Nで循環しているなどのときに 前計算 O(N) で K 個先の遷移を O(1) で求められるデータ構造
    /// </summary>
    public class PathLoop
    {
        /// <summary>
        /// <para><paramref name="to"/>: 頂点 i からの遷移先。負数は遷移先なしとする。</para>
        /// <para><paramref name="start"/>: どの頂点からのパスを見るか</para>
        /// <para>制約: <paramref name="to"/>[i] &lt; |<paramref name="to"/>|, 0 ≦ <paramref name="start"/> &lt; |<paramref name="to"/>|</para>
        /// <para>計算量: O(N)</para>
        /// </summary>
        /// <param name="to">数値 i からの遷移先</param>
        /// <param name="start">どの頂点からのパスを見るか</param>
        public PathLoop(int[] to, int start)
        {
            var used = new int[to.Length];
            var list = new SList<int>(to.Length);
            int cur = start;
            while (used[cur] == 0)
            {
                list.Add(cur);
                used[cur] = list.Count;
                cur = to[cur];
                if ((uint)cur >= (uint)to.Length)
                {
                    Straight = list.ToArray();
                    Loop = Array.Empty<int>();
                    return;
                }
            }
            var ix = used[cur] - 1;
            Straight = list.AsSpan()[..ix].ToArray();
            Loop = list.AsSpan()[ix..].ToArray();
        }
        public readonly int[] Straight;
        public readonly int[] Loop;

        /// <summary>
        /// <para><paramref name="moveNum"/>: 移動回数</para>
        /// </summary>
        /// <param name="moveNum">: 移動回数</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Move(long moveNum) => Move((ulong)moveNum);
        /// <summary>
        /// <para><paramref name="moveNum"/>: 移動回数</para>
        /// </summary>
        /// <param name="moveNum">: 移動回数</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Move(ulong moveNum)
        {
            if (moveNum < (ulong)Straight.Length)
                return Straight[(int)moveNum];
            if (Loop.Length == 0) return -1;
            moveNum -= (ulong)Straight.Length;
            return Loop[(int)(moveNum % (ulong)Loop.Length)];
        }
        /// <summary>
        /// <para><paramref name="moveNum"/>: 移動回数</para>
        /// </summary>
        /// <param name="moveNum">: 移動回数</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Move(BigInteger moveNum)
        {
            if (moveNum < Straight.Length)
                return Straight[(int)moveNum];
            if (Loop.Length == 0) return -1;
            moveNum -= Straight.Length;
            return Loop[(int)(moveNum % Loop.Length)];
        }
    }
}
