﻿using System;
using System.Collections.Generic;

namespace Kzrnm.Competitive
{
    public class BitArrayComparer : IComparer<System.Collections.BitArray>
    {
        private readonly bool IsReverse;
        public BitArrayComparer(bool isReverse = false)
        {
            IsReverse = isReverse;
        }
        public static readonly BitArrayComparer Default = new BitArrayComparer(false);
        public static readonly BitArrayComparer Reverse = new BitArrayComparer(true);
        public int Compare(System.Collections.BitArray x, System.Collections.BitArray y)
        {
            if (IsReverse)
                (x, y) = (y, x);
            for (int i = 0; i < x.Length && i < y.Length; i++)
            {
                var cmp = x[i].CompareTo(y[i]);
                if (cmp != 0)
                    return cmp;
            }
            return x.Length.CompareTo(y.Length);
        }
    }
}
