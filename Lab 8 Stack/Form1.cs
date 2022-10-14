using System.Text;
using System.Windows.Forms;

namespace Lab_8
{
    public partial class Form1 : Form
    {
        private Stack<char> _stackForMainTextBox = new Stack<char>();
        private Stack<char> _stackForSecondTextBox = new Stack<char>();

        public Form1()
        {
            InitializeComponent();
            MainRichTextBox.TextChanged += MainRichTextBox_TextChanged;
            SecondRichTextBox.TextChanged += SecondRichTextBox_TextChanged;
        }

        private void RestoreTextFromStackOfChars(RichTextBox richTextBox, Stack<char> stackOfOldText)
        {
            Stack<char> tempStack = new Stack<char>();
            StringBuilder previousContent = new StringBuilder();
            while (stackOfOldText.Size > 0)
            {
                tempStack.Push(stackOfOldText.Pop());
            }
            while (tempStack.Size > 0)
            {
                char topChar = tempStack.Pop();
                previousContent.Append(topChar);
                stackOfOldText.Push(topChar);
            }
            richTextBox.Text = previousContent.ToString();
            richTextBox.Select(richTextBox.Text.Length, 0);
        }

        private void SecondRichTextBox_TextChanged(object? sender, EventArgs e)
        {
            if (SecondRichTextBox.Text.Distinct().Count() != SecondRichTextBox.Text.Length)
            {
                RestoreTextFromStackOfChars(SecondRichTextBox, _stackForSecondTextBox);
                return;
            }
            _stackForSecondTextBox.Clear();
            foreach (char character in SecondRichTextBox.Text)
            {
                _stackForSecondTextBox.Push(character);
            }
            DisplayCombinedTextFromFirstAndSecondTextBox();
        }

        private void DisplayCombinedTextFromFirstAndSecondTextBox()
        {
            StringBuilder combinedText = new StringBuilder();
            Stack<char> tempStack = new Stack<char>();

            while (_stackForMainTextBox.Size > 0)
            {
                tempStack.Push(_stackForMainTextBox.Pop());
            }
            while (tempStack.Size > 0)
            {
                char topChar = tempStack.Pop();
                combinedText.Append(topChar);
                _stackForMainTextBox.Push(topChar);
            }

            while (_stackForSecondTextBox.Size > 0)
            {
                tempStack.Push(_stackForSecondTextBox.Pop());
            }
            while (tempStack.Size > 0)
            {
                char topChar = tempStack.Pop();
                combinedText.Append(topChar);
                _stackForSecondTextBox.Push(topChar);
            }
            UnionOfTwoTextBoxes.Text = combinedText.ToString();
        }

        private void MainRichTextBox_TextChanged(object? sender, EventArgs e)
        {
            if (MainRichTextBox.Text.Distinct().Count() != MainRichTextBox.Text.Length)
            {
                RestoreTextFromStackOfChars(MainRichTextBox, _stackForMainTextBox);
                return;
            }

            _stackForMainTextBox.Clear();
            foreach (char character in MainRichTextBox.Text)
            {
                _stackForMainTextBox.Push(character);
            }

            DisplaySize();
            DisplayMinElement();
            DisplayMaxElement();
            DisplayThirdElement();
            DisplaySecondFromEndElement();
            DisplayElementBeforeMin();
            DisplayElementAfterMax();
            DisplayCombinedTextFromFirstAndSecondTextBox();
        }


        private void DisplaySize()
        {
            NumberOfElementsLabel.Text = _stackForMainTextBox.Size.ToString();
        }

        private void DisplayMinElement()
        {
            if (_stackForMainTextBox.Size == 0)
            {
                MinElementLabel.Text = string.Empty;
                return;
            }

            Stack<char> temp = new Stack<char>();
            char minChar = _stackForMainTextBox.Peek();
            int size = _stackForMainTextBox.Size;
            for (int i = 0; i < size; i++)
            {
                temp.Push(_stackForMainTextBox.Peek());
                if (minChar > _stackForMainTextBox.Peek())
                {
                    minChar = _stackForMainTextBox.Peek();
                }
                _stackForMainTextBox.Pop();
            }
            for (int i = 0; i < size; i++)
            {
                _stackForMainTextBox.Push(temp.Pop());
            }
            MinElementLabel.Text = minChar.ToString() + " " + Convert.ToInt32(minChar).ToString();
        }

        private void DisplayMaxElement()
        {
            if (_stackForMainTextBox.Size == 0)
            {
                MaxElementLabel.Text = string.Empty;
                return;
            }

            Stack<char> temp = new Stack<char>();
            char maxChar = _stackForMainTextBox.Peek();
            int size = _stackForMainTextBox.Size;
            for (int i = 0; i < size; i++)
            {
                temp.Push(_stackForMainTextBox.Peek());
                if (maxChar < _stackForMainTextBox.Peek())
                {
                    maxChar = _stackForMainTextBox.Peek();
                }
                _stackForMainTextBox.Pop();
            }
            for (int i = 0; i < size; i++)
            {
                _stackForMainTextBox.Push(temp.Pop());
            }
            MaxElementLabel.Text = maxChar.ToString() + " " + Convert.ToInt32(maxChar).ToString();
        }

        private void DisplayThirdElement()
        {
            if (_stackForMainTextBox.Size < 3)
            {
                ThirdElementLabel.Text = string.Empty;
                return;
            }

            Stack<char> temp = new Stack<char>();
            int size = _stackForMainTextBox.Size;
            char thirdChar = '\0';
            for (int i = 0; i < size; i++)
            {
                if (_stackForMainTextBox.Size == 3)
                {
                    thirdChar = _stackForMainTextBox.Peek();
                }
                temp.Push(_stackForMainTextBox.Pop());
            }
            for (int i = 0; i < size; i++)
            {
                _stackForMainTextBox.Push(temp.Pop());
            }
            ThirdElementLabel.Text = thirdChar.ToString();
        }

        private void DisplaySecondFromEndElement()
        {
            if (_stackForMainTextBox.Size < 2)
            {
                SecondElementFromEndLabel.Text = string.Empty;
                return;
            }

            char lastChar = _stackForMainTextBox.Pop();
            char secondFromEnd = _stackForMainTextBox.Peek();
            _stackForMainTextBox.Push(lastChar);
            
            SecondElementFromEndLabel.Text = secondFromEnd.ToString();
        }

        private void DisplayElementBeforeMin()
        {
            if (_stackForMainTextBox.Size < 2)
            {
                ElementBeforeMinLabel.Text = string.Empty;
                return;
            }

            Stack<char> temp = new Stack<char>();
            char minChar = _stackForMainTextBox.Peek();
            int minIndex = _stackForMainTextBox.Size - 1;
            int size = _stackForMainTextBox.Size;

            for (int i = 0; i < size; i++)
            {
                char topChar = _stackForMainTextBox.Pop();
                temp.Push(topChar);
                if (minChar > topChar)
                {
                    minChar = topChar;
                    minIndex = size - 1 - i;
                }
            }
            for (int i = 0; i < size; i++)
            {
                char ch = temp.Pop();
                _stackForMainTextBox.Push(ch);
            }
            if (minIndex != 0)
            {
                ElementBeforeMinLabel.Text = GetElementByIndex(minIndex - 1).ToString();
                return;
            }
            ElementBeforeMinLabel.Text = string.Empty;
        }

        private void DisplayElementAfterMax()
        {
            if (_stackForMainTextBox.Size < 2)
            {
                ElementAfterMaxLabel.Text = string.Empty;
                return;
            }
            Stack<char> temp = new Stack<char>();
            char maxChar = _stackForMainTextBox.Peek();
            int maxIndex = _stackForMainTextBox.Size - 1;
            int size = _stackForMainTextBox.Size;

            for (int i = 0; i < size; i++)
            {
                char topChar = _stackForMainTextBox.Pop();
                temp.Push(topChar);
                if (maxChar < topChar)
                {
                    maxChar = topChar;
                    maxIndex = size - 1 - i;
                }
            }
            for (int i = 0; i < size; i++)
            {
                char ch = temp.Pop();
                _stackForMainTextBox.Push(ch);
            }
            if (maxIndex != _stackForMainTextBox.Size - 1)
            {
                ElementAfterMaxLabel.Text = GetElementByIndex(maxIndex + 1).ToString();
                return;
            }
            ElementAfterMaxLabel.Text = string.Empty;
        }

        private void DisplayElementByIndex()
        {
            int index;
            try
            {
                index = int.Parse(IndexOfElementInput.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show($"Cannot convert \"{IndexOfElementInput.Text}\" to number");
                return;
            }
            if (index < 0 || index >= _stackForMainTextBox.Size)
            {
                MessageBox.Show("Index is out of range");
                return;
            }
            ElementByIndexLabel.Text = GetElementByIndex(index).ToString();
        }

        private char GetElementByIndex(int index)
        {
            char[] chars = new char[_stackForMainTextBox.Size];
            for (int i = 0; i < chars.Length; i++)
            {
                chars[chars.Length - 1 - i] = _stackForMainTextBox.Pop();
            }
            foreach (char character in chars)
            {
                _stackForMainTextBox.Push(character);
            }
            return chars[index];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DisplayElementByIndex();
        }
    }
}