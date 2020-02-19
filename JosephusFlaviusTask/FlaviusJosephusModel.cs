using System;
using System.Collections.Generic;
using System.Text;

namespace JosephusFlaviusTask
{
    public static class FlaviusJosephusModel
    {
        public static IEnumerable<int> ReturnSequence(int n, int k)
        {
            if (k <= 0)
            {
                throw new ArgumentException($"{nameof(k)} is negative or equal to zero.");
            }

            if (n <= 0)
            {
                throw new ArgumentException($"{nameof(n)} is negative or equal to zero.");
            }

            IEnumerable<int> Execute()
            {
                if (n == 1)
                {
                    yield return n;
                    yield break;
                }

                FlaviusJosephusCollection collection = new FlaviusJosephusCollection(n);
                int localK = k;
                int localN = 0;
                int[] arr;
                int arrayToRemoveSize = 0;
                if (n > k)
                {
                    arr = new int[n / k];
                }
                else
                {
                    arr = new int[1];
                }

                for (int i = 1; i <= n; i++)
                {
                    collection.Add(i);
                }

                foreach (var element in collection)
                {
                    localK--;
                    localN++;
                    if (localK == 0)
                    {
                        localK = k;
                        arr[arrayToRemoveSize] = element;
                        arrayToRemoveSize++;
                    }

                    if (localN == n)
                    {
                        for (int i = 0; i < arrayToRemoveSize; i++)
                        {
                            collection.Remove(arr[i]);
                            yield return arr[i];
                        }

                        localN = 0;
                        n = collection.CurrentSize;
                        arrayToRemoveSize = 0;
                    }
                }

                yield return collection[0];
            }

            return Execute();
        }
    }
}
