namespace Lab_3
{
    public static class ShellSort
    {
        public static void Sort(double[] arr)
        {
            for (int gap = arr.Length / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < arr.Length; i++)
                {
                    for (int j = i - gap; j >= 0 && arr[j] > arr[j + gap]; j -= gap)
                    {
                        (arr[j], arr[j + gap]) = (arr[j + gap], arr[j]);
                    }
                }
            }
        }
    }
}
