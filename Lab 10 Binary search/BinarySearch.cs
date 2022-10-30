using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10
{
    public class BinarySearch
    {
        public static (int position, int numberOfComparisons) Search(int[] array, int value)
        {
            if (array is null || array.Length == 0)
            {
                return (0, 0);
            }
            int numberOfComparisons = 0;
            return (Search(array, value, 0, array.Length - 1, ref numberOfComparisons), numberOfComparisons);   
        }
        private static int Search(int[] array, int value, int low, int high, ref int numberOfComparisons)
        {
            numberOfComparisons++;
            int middle = low + (high - low) / 2;
            if (low > high)
            {
                throw new ArgumentException("Value was not found");
            }
            if (array[middle] == value)
            {
                return middle;
            }
            if (value < array[middle])
            {
                return Search(array, value, low, middle - 1, ref numberOfComparisons);
            }
            
            return Search(array, value, middle + 1, high, ref numberOfComparisons);      
        }
    }
}
