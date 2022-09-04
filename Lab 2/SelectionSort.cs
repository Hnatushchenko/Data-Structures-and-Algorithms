namespace Lab_2
{
    public static class SelectionSort
    {
        public static void Sort(List<Product> products)
        {
            int minimumIndex, i, j;
            Product temp;
            for (i = 0; i < products.Count - 1; i++)
            {
                minimumIndex = i;
                for (j = i + 1; j < products.Count; j++)
                {
                    if (products[j].Name.CompareTo(products[minimumIndex].Name) < 0)
                    {
                        temp = products[j];
                        products[j] = products[minimumIndex];
                        products[minimumIndex] = temp;
                    }
                }
            }
        }
    }
}
