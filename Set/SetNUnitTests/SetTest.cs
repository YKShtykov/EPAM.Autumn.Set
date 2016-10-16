using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BL;

namespace SetNUnitTests
{
    [TestFixture]
    public class SetTest
    {
        [Test]
        public void IntersectionTest()
        {
            Set<int> a = new Set<int>();
            for (int i = 0; i < 5; i++)
            {
                a.Add(i);
            }
            Set<int> b = new Set<int>();
            for (int i = 0; i < 100; i++)
            {
                b.Add(i);
            }

            Set<int> c = Set<int>.Intersection(a, b);

            CollectionAssert.AreEqual(c.GetElements(),new int[] { 0, 1, 2, 3, 4 });
        }

        [Test]
        public void UnionTest()
        {
            Set<int> a = new Set<int>();
            a.Add(new int[]{ 1,2});
            Set<int> b = new Set<int>();
            b.Add(new int[]{ 3,5});
            Set<int> c = Set<int>.Union(a, b);

            CollectionAssert.AreEqual(c.GetElements(), new int[] { 1,2,3,5 });
        }

        [Test]
        public void ExpectTest()
        {
            Set<int> a = new Set<int>();
            a.Add(new int[] { 1, 2,3 });
            Set<int> b = new Set<int>();
            b.Add(new int[] { 3, 5 });
            Set<int> c = Set<int>.Expect(a, b);

            CollectionAssert.AreEqual(c.GetElements(), new int[] { 1, 2 });
        }

        [Test]
        public void SymmetricExpectTest()
        {
            Set<int> a = new Set<int>();
            a.Add(new int[] { 1, 2, 3 });
            Set<int> b = new Set<int>();
            b.Add(new int[] { 3, 5 });
            Set<int> c = Set<int>.SymmetricExpect(a, b);

            CollectionAssert.AreEqual(c.GetElements(), new int[] { 1, 2,5 });
        }
    }
}
