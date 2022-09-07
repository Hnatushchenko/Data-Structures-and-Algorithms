using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    internal class MatrixPrinter
    {
        public static void ToRichTextBox(RichTextBox richTextBox, double[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    richTextBox.AppendText(matrix[j][i].ToString() + " ");
                }
                richTextBox.AppendText("\n");
            }
        }
    }
}
