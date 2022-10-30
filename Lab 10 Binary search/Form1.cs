namespace Lab_10
{
    public partial class Form1 : Form
    {
        private int[] numbers;

        public Form1()
        {
            numbers = Array.Empty<int>();
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int position;
            int numberOfComparisons;
            try
            {
                (position, numberOfComparisons) = BinarySearch.Search(numbers, 5);
            }
            catch (ArgumentException exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }
            List<int> positions = new List<int>() { position };

            int forwardPosition = position + 1;
            while (forwardPosition < numbers.Length && numbers[forwardPosition] == 5)
            {
                positions.Add(forwardPosition);
                forwardPosition++;
            }

            int backwardPosition = position - 1;
            while (backwardPosition >= 0 && numbers[backwardPosition] == 5)
            {
                positions.Add(backwardPosition);
                backwardPosition--;
            }

            richTextBox3.AppendText($"Number of comparisons: {numberOfComparisons}\n");
            richTextBox3.AppendText($"Positions: ");
            foreach (var pos in positions)
            {
                richTextBox3.AppendText(pos.ToString() + " ");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            richTextBox3.Clear();

            int maxValue = Convert.ToInt32(textBox2.Text);
            if (int.TryParse(textBox1.Text, out int numberOfElements))
            {
                numbers = SortedArrayGenerator.Generage(numberOfElements, maxValue);
                richTextBox2.AppendText("Initial array:\n");
                foreach (var item in numbers)
                {
                    richTextBox2.AppendText(item.ToString() + " ");
                }
                richTextBox2.AppendText("\n");
            }
            else
            {
                MessageBox.Show("Cannot convert to integer");
            }
        }
    }
}