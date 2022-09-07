

namespace Lab_4
{
    public partial class Form1 : Form
    {
        private readonly int maxValue = 100;
        private double[][] matrix;

        public Form1()
        {
            matrix = Array.Empty<double[]>();
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            QuickSort.Sort(matrix);
            MatrixPrinter.ToRichTextBox(richTextBox3, matrix);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            richTextBox3.Clear();
            if (int.TryParse(textBox1.Text, out int size))
            {
                matrix = RandomMatrixGenerator.Generate(size, maxValue);

                richTextBox2.AppendText("Initial matrix:\n");
                MatrixPrinter.ToRichTextBox(richTextBox2, matrix);
            }
            else
            {
                MessageBox.Show("Cannot convert to integer");
            }
        }
    }
}