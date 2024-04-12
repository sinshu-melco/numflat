﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using NUnit.Framework;
using NumFlat;

namespace NumFlatTest.VecTests
{
    public class ComplexTests
    {
        [TestCase(1, 1, 1)]
        [TestCase(2, 2, 2)]
        [TestCase(3, 3, 3)]
        [TestCase(1, 3, 4)]
        [TestCase(2, 5, 4)]
        [TestCase(5, 7, 6)]
        public void Conjugate(int count, int xStride, int dstStride)
        {
            var x = TestVector.RandomComplex(42, count, xStride);

            var expected = x.Select(c => c.Conjugate()).ToVector();

            var actual = TestVector.RandomComplex(0, count, dstStride);
            using (x.EnsureUnchanged())
            {
                Vec.Conjugate(x, actual);
            }

            NumAssert.AreSame(expected, actual, 0);

            TestVector.FailIfOutOfRangeWrite(actual);
        }
    }
}
