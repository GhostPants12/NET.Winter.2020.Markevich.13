using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace JosephusFlaviusTask
{
    public class FlaviusJosephusEnumerator : IEnumerator<int>
    {
        private readonly FlaviusJosephusCollection flaviusJosephusCollection;
        private int position;

        public FlaviusJosephusEnumerator(FlaviusJosephusCollection collection)
        {
            this.flaviusJosephusCollection = collection;
            this.position = -1;
        }

        public int Current => this.flaviusJosephusCollection[this.position];

        object IEnumerator.Current => this.flaviusJosephusCollection[this.position];

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (this.flaviusJosephusCollection.CurrentSize == 1)
            {
                return false;
            }

            if (this.position >= -1 && this.position < this.flaviusJosephusCollection.CurrentSize - 1)
            {
                this.position++;
                return true;
            }
            else
            {
                this.Reset();
                this.position++;
                return true;
            }
        }

        public void Reset()
        {
            this.position = -1;
        }
    }
}
