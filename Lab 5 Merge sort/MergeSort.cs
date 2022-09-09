namespace Lab_5
{
    public static class MergeSort
    {
        public static void Sort(double[] arr)
        {
            Sort(arr, 0, arr.Length - 1);
        }

        public static void Sort(double[] array, int leftIndex, int rightIndex)
        {
            if (leftIndex >= rightIndex)
                return;

            int middleIndex = leftIndex + (rightIndex - leftIndex) / 2;

            Sort(array, leftIndex, middleIndex);
            Sort(array, middleIndex + 1, rightIndex);

            double[] leftArray = new double[middleIndex - leftIndex + 1];
            double[] rightArray = new double[rightIndex - middleIndex];

            for (int i = 0; i < leftArray.Length; i++)
                leftArray[i] = array[leftIndex + i];

            for (int i = 0; i < rightArray.Length; i++)
                rightArray[i] = array[middleIndex + i + 1];

            for (int i = 0, j = 0, k = leftIndex; k <= rightIndex; k++)
            {
                if ((i < leftArray.Length) && (j >= rightArray.Length || leftArray[i] < rightArray[j]))
                {
                    array[k] = leftArray[i];
                    i++;
                }
                else
                {
                    array[k] = rightArray[j];
                    j++;
                }
            }
        }
    }
}
