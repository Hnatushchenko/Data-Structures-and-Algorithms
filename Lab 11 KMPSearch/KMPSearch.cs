namespace Lab_11
{
    public class KMPSearch
    {
        public static int Search(string pattern, string text)
        {
            int N = text.Length;
            int M = pattern.Length;

            if (N < M) return -1;
            if (N == M && text == pattern) return 0;
            if (M == 0) return 0;

            int[] lpsArray = CalculateFunc(pattern);

            int i = 0, j = 0;
            while (i < N)
            {
                if (text[i] == pattern[j])
                {
                    i++;
                    j++;
                }

                if (j == M)
                {
                    return i - j;
                }
                else if (i < N && text[i] != pattern[j])
                {
                    if (j != 0)
                    {
                        j = lpsArray[j - 1];
                    }
                    else
                    {
                        i++;
                    }
                }
            }
            return -1;
        }
        public static int[] CalculateFunc(string pattern)
        {
            int[] lpsArray = new int[pattern.Length];

            int j = 0;
            int i = 1;
            lpsArray[0] = 0;

            while (i < pattern.Length)
            {
                if (pattern[i] == pattern[j])
                {
                    lpsArray[i] = j + 1;
                    j++;
                    i++;
                }
                else
                {
                    if (j != 0)
                    {
                        j = lpsArray[j - 1];
                    }
                    else
                    {
                        lpsArray[i] = j;
                        i++;
                    }
                }
            }
            return lpsArray;
        }
    }
}
