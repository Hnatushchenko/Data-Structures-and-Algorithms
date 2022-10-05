namespace Lab_6
{
    public partial class Form1 : Form
    {
        private byte[] numbers1;
        private byte[] numbers2;
        private byte[] arrayToSort;

        public Form1()
        {
            numbers1 = Array.Empty<byte>();
            numbers2 = Array.Empty<byte>();
            arrayToSort = Array.Empty<byte>();
            InitializeComponent();
        }

        /*
            З двох одновимірних масивів цілих чисел сформувати новий, який включає всі парні числа з першого і непарні з другого масиву. 
        */
        byte[] ApplyIndividualFunction(byte[] array1, byte[] array2)
        {
            int size = array1.Count(e => e % 2 == 0) + array2.Count(e => e % 2 == 1);
            byte[] result = new byte[size];
            
            int i = 0;
            foreach (byte number in array1.Where(e => e % 2 == 0))
            {
                result[i] = number;
                i++;
            }
            foreach (byte number in array2.Where(e => e % 2 == 1))
            {
                result[i] = number;
                i++;
            }
            return result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CountingSort.Sort(arrayToSort);
            foreach (byte number in arrayToSort)
            {
                richTextBox3.AppendText(number.ToString() + " ");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numbers1.Length == 0)
                return;

            richTextBox2.AppendText("\nArray after applying individual function:\n");
            arrayToSort = ApplyIndividualFunction(numbers1, numbers2);
            foreach (var item in arrayToSort)
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
                numbers1 = ByteArrayGenerator.Generage(numberOfElements);
                numbers2 = ByteArrayGenerator.Generage(numberOfElements);
                richTextBox2.AppendText("Initial arrays:\n");
                foreach (var item in numbers1)
                {
                    richTextBox2.AppendText(item.ToString() + " ");
                }
                richTextBox2.AppendText("\n");
                foreach (var item in numbers2)
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