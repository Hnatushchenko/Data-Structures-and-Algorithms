namespace Lab_5
{
    public partial class Form1 : Form
    {
        int _maxValue = 2000;
        private double[] numbers;
        public Form1()
        {
            numbers = Array.Empty<double>();
            InitializeComponent();
        }

        /*
            * Задано одномірний масив дійсних чисел.
            * Виключити з нього моду (елемент, який повторюється найчастіше).
        */
        double[] ApplyIndividualFunction(double[] arr)
        {
            if (arr == null || arr.Length == 0)
                return Array.Empty<double>();
            
            double mod = 0;
            int maxNumberOfOccurences = 0;
            int count = 0;
            foreach (double number in arr)
            {
                count = arr.Count(d => d == number);
                if (count > maxNumberOfOccurences)
                {
                    maxNumberOfOccurences = count;
                    mod = number;
                }
            }
            return arr.Where(d => d != mod).ToArray();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MergeSort.Sort(numbers);
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
            numbers = ApplyIndividualFunction(numbers);
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