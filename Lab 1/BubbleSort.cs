namespace Lab_1
{
    public static class BubbleSort
    {
        public static void Sort(double[] arr)
        {
            bool flag;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                flag = false;
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] < arr[j + 1])
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                        flag = true;
                    }
                }
                if (!flag)
                {
                    break;
                }
            }
        }
    }
}
