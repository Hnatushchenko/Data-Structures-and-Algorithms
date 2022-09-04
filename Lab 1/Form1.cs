

namespace Lab_1
{
    public partial class Form1 : Form
    {
        private int _maxValue = 1000;
        private double[] numbers;

        public Form1()
        {
            numbers = Array.Empty<double>();
            InitializeComponent();
        }

        double[] RemoveMaxAndMinElement(double[] arr)
        {
            arr = arr.Where((value, index) => index != Array.IndexOf(arr, arr.Max())).ToArray();
            arr = arr.Where((value, index) => index != Array.IndexOf(arr, arr.Min())).ToArray();
            return arr;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BubbleSort.Sort(numbers);
            foreach (var item in numbers)
            {
                richTextBox3.AppendText(item.ToString() + " ");
            }
        }
        // «читити, виключити з нього м≥н≥мальний та максимальний елементи
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox2.AppendText("\nArray after removing max and min elements:\n");
            numbers = RemoveMaxAndMinElement(numbers);
            foreach (var item in numbers)
            {
                richTextBox2.AppendText(item.ToString() + " ");
            }
            richTextBox2.AppendText("\n");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            richTextBox3.Clear();

            if (int.TryParse(textBox1.Text, out int numberOfElements))
            {
                Random rand = new Random();
                numbers = new double[numberOfElements];
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] = rand.Next(_maxValue) + Math.Round(rand.NextDouble(), 2);
                }
                richTextBox2.AppendText("Initial array:\n");
                foreach (var item in numbers)
                {
                    richTextBox2.AppendText(item.ToString() + " ");
                }

            }
            else
            {
                MessageBox.Show("Cannot convert to integer");
            }
        }
    }
}