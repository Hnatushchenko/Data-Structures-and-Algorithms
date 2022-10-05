namespace Lab_6
{
    class CountingSort
    {
        public static void Sort(byte[] array)
        {
            var maxElement = array.Max();
            var occurrences = new int[maxElement + 1];

            for (int i = 0; i < maxElement + 1; i++)
            {
                occurrences[i] = 0;
            }

            for (int i = 0; i < array.Length; i++)
            {
                occurrences[array[i]]++;
            }

            for (byte i = 0, j = 0; i <= maxElement; i++)
            {
                while (occurrences[i] > 0)
                {
                    array[j] = i;
                    j++;
                    occurrences[i]--;
                }
            }
        }
    }
}
