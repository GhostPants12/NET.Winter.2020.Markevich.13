using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace JosephusFlaviusTask
{
    public class FlaviusJosephusCollection : IEnumerable<int>
    {
        public const int Multiplier = 2;
        private int[] arr;
        private int currentSize;

        /// <summary>Initializes a new instance of the <see cref="FlaviusJosephusCollection"/> class.</summary>
        /// <param name="size">The size.</param>
        public FlaviusJosephusCollection(int size)
        {
            this.arr = new int[size];
            this.currentSize = 0;
        }

        /// <summary>Gets the size of the array.</summary>
        /// <value>The size of the current array.</value>
        public int CurrentSize
        {
            get { return this.currentSize; }
        }

        /// <summary>Gets the <see cref="System.Int32"/> at the specified index.</summary>
        /// <param name="index">The index.</param>
        /// <value>The <see cref="System.Int32"/>.</value>
        /// <returns>Element at the specified index.</returns>
        public int this[int index]
        {
            get
            {
                if (index <= this.currentSize)
                {
                    return this.arr[index];
                }

                return 0;
            }
        }

        /// <summary>Adds the specified element to the array.</summary>
        /// <param name="element">The element.</param>
        public void Add(int element)
        {
            if (this.arr.Length - 1 == this.currentSize)
            {
                Array.Resize(ref this.arr, this.arr.Length * Multiplier);
            }

            this.arr[this.currentSize] = element;
            this.currentSize++;
        }

        /// <summary>Removes the specified element from the array..</summary>
        /// <param name="element">The element.</param>
        public void Remove(int element)
        {
            for (int i = 0; i < this.currentSize; i++)
            {
                if (this.arr[i] == element)
                {
                    for (int j = i; j < this.currentSize - 1; j++)
                    {
                        this.arr[j] = this.arr[j + 1];
                    }

                    this.currentSize--;
                    return;
                }
            }
        }

        /// <summary>Returns an enumerator that iterates through the collection.</summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<int> GetEnumerator()
        {
            return new FlaviusJosephusEnumerator(this);
        }

        /// <summary>Returns an enumerator that iterates through a collection.</summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new FlaviusJosephusEnumerator(this);
        }
    }
}
