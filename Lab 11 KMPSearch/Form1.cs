namespace Lab_11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            richTextBox2.WordWrap = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] words = richTextBox2.Text.Split(new char[] { ' ', ',' });
            int averageLength = (int)words.Average(word => word.Length);
            string? wordToFind = words.FirstOrDefault(word => word.Length == averageLength);

            if (wordToFind is null)
            {
                MessageBox.Show($"There is no word with the length of {averageLength}");
                return;
            }

            string textToSearchIn = richTextBox3.Text;
            int index = KMPSearch.Search(wordToFind, textToSearchIn);
            MessageBox.Show($"The word \"{wordToFind}\" was found at the index {index}");
        }
    }
}