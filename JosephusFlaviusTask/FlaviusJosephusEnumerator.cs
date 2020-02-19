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

        /// <summary>Initializes a new instance of the <see cref="FlaviusJosephusEnumerator"/> class.</summary>
        /// <param name="collection">The collection.</param>
        public FlaviusJosephusEnumerator(FlaviusJosephusCollection collection)
        {
            this.flaviusJosephusCollection = collection;
            this.position = -1;
        }

        /// <summary>Gets the element in the collection at the current position of the enumerator.</summary>
        public int Current => this.flaviusJosephusCollection[this.position];

        /// <summary>Gets the element in the collection at the current position of the enumerator.</summary>
        object IEnumerator.Current => this.flaviusJosephusCollection[this.position];

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
        }

        /// <summary>Advances the enumerator to the next element of the collection.</summary>
        /// <returns>
        ///   <span class="keyword">
        ///     <span class="languageSpecificText">
        ///       <span class="cs">true</span>
        ///       <span class="vb">True</span>
        ///       <span class="cpp">true</span>
        ///     </span>
        ///   </span>
        ///   <span class="nu">
        ///     <span class="keyword">true</span> (<span class="keyword">True</span> in Visual Basic)</span> if the enumerator was successfully advanced to the next element; <span class="keyword"><span class="languageSpecificText"><span class="cs">false</span><span class="vb">False</span><span class="cpp">false</span></span></span><span class="nu"><span class="keyword">false</span> (<span class="keyword">False</span> in Visual Basic)</span> if the enumerator has passed the end of the collection.
        /// </returns>
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

        /// <summary>Sets the enumerator to its initial position, which is before the first element in the collection.</summary>
        public void Reset()
        {
            this.position = -1;
        }
    }
}
