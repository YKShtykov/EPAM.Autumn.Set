using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    /// <summary>
    /// Generic collection-set, elements must implement IEquatable interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class Set<T>: IEnumerable<T>
        where T: IEquatable<T>
    {
        private T[] store;
        private int capacity;
        private int currentPosition;

        public Set()
        {
            capacity = 10;
            currentPosition = 0;
            store = new T[capacity];
        }

        private Set(T[] otherStore)
        {
            store = (T[])otherStore.Clone();
            capacity = otherStore.Length;
            currentPosition = otherStore.Length;
        }

        /// <summary>
        /// Intersection between two collections
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>new set-intersection</returns>
        public static Set<T> Intersection(Set<T> lhs, Set<T> rhs)
        {
            return new Set<T>(lhs.GetElements().Intersect(rhs.GetElements()).ToArray());
        }

        /// <summary>
        /// Union of two collections
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>new set-union</returns>
        public static Set<T> Union(Set<T> lhs, Set<T> rhs)
        {
            return new Set<T>(lhs.GetElements().Union(rhs.GetElements()).ToArray());
        }

        /// <summary>
        /// Expect the second set from the first
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>new set expection</returns>
        public static Set<T> Expect(Set<T> lhs, Set<T> rhs)
        {
            return new Set<T>(lhs.GetElements().Except(rhs.GetElements()).ToArray());
        }

        /// <summary>
        /// The method removes equals elements form collections and creates new set
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>new set with elements from two sets</returns>
        public static Set<T> SymmetricExpect(Set<T> lhs, Set<T> rhs)
        {
            var intersection = lhs.GetElements().Intersect(rhs.GetElements());
            var union = lhs.GetElements().Union(rhs.GetElements());
            return new Set<T>(union.Except(intersection).ToArray());
        }

        /// <summary>
        /// Add element to set
        /// </summary>
        /// <param name="element"></param>
        public void Add(T element)
        {
            if (Contains(element)) return;

            try
            {
                store[currentPosition] = element;
                currentPosition++;
            }
            catch (IndexOutOfRangeException)
            {
                IncreaseCapacity();
                Add(element);
            }
        }

        /// <summary>
        /// Add a
        /// </summary>
        /// <param name="array"></param>
        public void Add(IEnumerable<T> array)
        {
            foreach (var item in array)
            {
                Add(item);
            }
        }

        /// <summary>
        /// Remove element from set
        /// </summary>
        /// <param name="element"></param>
        public void Remove(T element)
        {
            for (int i = 0; i < currentPosition; i++)
            {
                if (element.Equals(store[i]))
                {
                    RemoveElement(i);
                    return;
                }
            }
        }

        private bool Contains(T element)
        {
            for (int i = 0; i < currentPosition; i++)
            {
                if (element.Equals(store[i])) return true;
            }

            return false;
        }
        
        private void RemoveElement(int elementposition)
        {
            for (int i = elementposition; i < currentPosition; i++)
            {
                store[i] = store[i + 1];
            }
            currentPosition--;
        }        

        private void IncreaseCapacity()
        {
            capacity = capacity + 100;
            Array.Resize(ref store, capacity);
        }       

        /// <summary>
        /// It returns all elements like Ienumerable
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetElements()
        {
            var tmp = (T[])store.Clone();
            Array.Resize(ref tmp, currentPosition);
            return tmp.AsEnumerable();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < currentPosition; i++)
            {
                yield return store[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
