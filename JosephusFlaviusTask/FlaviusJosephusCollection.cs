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

        public FlaviusJosephusCollection(int size)
        {
            this.arr = new int[size];
            this.currentSize = 0;
        }

        public int CurrentSize
        {
            get { return this.currentSize; }
        }

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

        public void Add(int element)
        {
            if (this.arr.Length - 1 == this.currentSize)
            {
                Array.Resize(ref this.arr, this.arr.Length * Multiplier);
            }

            this.arr[this.currentSize] = element;
            this.currentSize++;
        }

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

        public IEnumerator<int> GetEnumerator()
        {
            return new FlaviusJosephusEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new FlaviusJosephusEnumerator(this);
        }
    }
}
