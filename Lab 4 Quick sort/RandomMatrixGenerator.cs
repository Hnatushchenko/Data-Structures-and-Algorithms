namespace Lab_4
{
    internal class RandomMatrixGenerator
    {
        public static double[][] Generate(int size, int maxValue)
        {
            Random random = new Random();
            double[][] matrix = new double[size][];
            for (int i = 0; i < size; i++)
            {
                matrix[i] = new double[size];
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i][j] = random.Next(maxValue) + Math.Round(random.NextDouble(), 1);
                }
            }
                
            return matrix;
        }
    }
}
