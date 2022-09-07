namespace Lab_4
{
    public static class QuickSort
    {
        public static void Sort(double[][] matrix)
        {
            Sort(matrix, 0, matrix.Length - 1);
        }
        public static void Sort(double[][] matrix, int leftIndex, int rightIndex)
        {
            int i = leftIndex;
            int j = rightIndex;
            double pivot = matrix[leftIndex][0];

            while (i <= j)
            {
                while (matrix[i][0] < pivot)
                {
                    i++;
                }
                while (matrix[j][0] > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    (matrix[i], matrix[j]) = (matrix[j], matrix[i]);
                    i++;
                    j--;
                }
            }       
            if (leftIndex < j)
                Sort(matrix, leftIndex, j);
            if (i < rightIndex)
                Sort(matrix, i, rightIndex);
        }
    }
}
