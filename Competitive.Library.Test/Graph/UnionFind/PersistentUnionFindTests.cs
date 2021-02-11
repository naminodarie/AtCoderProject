﻿using FluentAssertions;
using System;
using Xunit;


namespace Kzrnm.Competitive.Graph
{
    public class PersistentUnionFindTests
    {
        [Fact]
        public void Simple()
        {
            var ufs = new PersistentUnionFind[2];
            ufs[0] = new PersistentUnionFind(2);
            ufs[1] = ufs[0].Merge(0, 1);
            ufs[0].Same(0, 1).Should().BeFalse();
            ufs[1].Same(0, 1).Should().BeTrue();
            ufs[1].Size(0).Should().Be(2);
        }

        [Fact]
        public void Line()
        {
            int n = 50000;
            var ufs = new PersistentUnionFind[n];
            ufs[0] = new PersistentUnionFind(n);
            for (int i = 0; i + 1 < n; i++)
            {
                ufs[i + 1] = ufs[i].Merge(i, i + 1);
            }
            for (int i = 0; i < n - 1; i++)
            {
                ufs[i].Size(0).Should().Be(i + 1);
                ufs[i].Size(i).Should().Be(i + 1);
            }
            ufs[^1].Size(0).Should().Be(n);
        }

        [Fact]
        public void LineReverse()
        {
            int n = 50000;
            var ufs = new PersistentUnionFind[n];
            ufs[^1] = new PersistentUnionFind(n);
            for (int i = n - 2; i >= 0; i--)
            {
                ufs[i] = ufs[i + 1].Merge(i, i + 1);
            }
            ufs[0].Size(0).Should().Be(n);
        }
    }
}
