namespace Lab_10
{
    internal class SortedArrayGenerator
    {
        public static int[] Generage(int size, int maxValue)
        {
            int[] result = new int[size];
            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                result[i] = random.Next(maxValue);
            }
            Array.Sort(result);
            return result;
        }
    }
}
