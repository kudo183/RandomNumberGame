using System;

namespace RandomNumberGame
{
    static class RandomExtensions
    {
        public static int[] CreateRandomIntArray(this Random rng, int count)
        {
            var array = new int[count];
            for (int i = 0; i < count; i++)
            {
                array[i] = i + 1;
            }

            rng.Shuffle(array);

            return array;
        }

        public static void Shuffle<T>(this Random rng, T[] array)
        {
            int n = array.Length;
            while (n > 1)
            {
                int k = rng.Next(n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }
    }
}
