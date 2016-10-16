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
        /// <summary>
        /// Intersection test
        /// </summary>
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

        /// <summary>
        /// union test
        /// </summary>
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

        /// <summary>
        /// Expect test
        /// </summary>
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

        /// <summary>
        /// Symmetric difference test
        /// </summary>
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

        /// <summary>
        /// Symmetric difference test
        /// </summary>
        [Test]
        public void EnumeratorTest()
        {
            Set<int> a = new Set<int>();
            Set<int> b = new Set<int>();
            a.Add(new int[] { 1, 2, 3 });
            foreach (var item in a)
            {
                b.Add(item * 2);
            }

            CollectionAssert.AreEqual(b.GetElements(), new int[] { 2,4,6 });
        }
    }
}
