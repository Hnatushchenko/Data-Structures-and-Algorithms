namespace Lab_6
{
    internal class ByteArrayGenerator
    {
        public static byte[] Generage(int size)
        {
            byte[] result = new byte[size];
            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                result[i] = Convert.ToByte(random.Next(256));
            }
            return result;
        }
    }
}
