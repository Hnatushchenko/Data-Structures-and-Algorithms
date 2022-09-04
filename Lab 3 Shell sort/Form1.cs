

namespace Lab_3
{
    public partial class Form1 : Form
    {
        int _maxValue = 1000;
        private double[] numbers;
        public Form1()
        {
            numbers = Array.Empty<double>();
            InitializeComponent();
        }

        /*
            * До парних елементів масиву застосувати функцію √(|x-10|).
        */
        void ApplyIndividualFunction(double[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                    arr[i] = Math.Round(Math.Sqrt(Math.Abs(arr[i] - 10)), 2);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShellSort.Sort(numbers);
            foreach (var item in numbers)
            {
                richTextBox3.AppendText(item.ToString() + " ");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numbers.Length == 0)
                return;

            richTextBox2.AppendText("\nArray after applying individual function:\n");
            ApplyIndividualFunction(numbers);
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
                    numbers[i] = rand.Next(_maxValue);
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