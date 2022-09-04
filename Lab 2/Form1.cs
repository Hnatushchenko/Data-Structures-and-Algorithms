

namespace Lab_2
{
    public partial class Form1 : Form
    {
        Product[] products;
        public Form1()
        {
            products = Array.Empty<Product>();
            InitializeComponent();
        }

        public List<Product> GetProductsWithLowPrice(Product[] products)
        {
            double averagePrice = products.Average(product => product.Price);
            List<Product> productsToSort = new List<Product>();
            foreach (var product in products)
            {
                if (product.Price <= averagePrice)
                {
                    productsToSort.Add(product);
                }
            }
            return productsToSort;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            double averagePrice = products.Average(product => product.Price);
            List<Product> productsToSort = new List<Product>();
            foreach (var product in products)
            {
                if (product.Price <= averagePrice)
                {
                    productsToSort.Add(product);
                }
            }
            SelectionSort.Sort(productsToSort);
            foreach (var product in productsToSort)
            {
                richTextBox3.AppendText($"{product.Name}: {product.Price}\n");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            richTextBox3.Clear();

            if (int.TryParse(textBox1.Text, out int numberOfElements))
            {
                RandomProductGenerator randomProductGenerator = new();
                products = randomProductGenerator.GetRandomProducts(numberOfElements);
                richTextBox2.AppendText("Initial products:\n");
                foreach (var product in products)
                {
                    richTextBox2.AppendText($"{product.Name}: {product.Price}\n");
                }
                richTextBox2.AppendText($"Average price: {products.Average(product => product.Price)}\n");
            }
            else
            {
                MessageBox.Show("Cannot convert to integer");
            }
        }
    }
}