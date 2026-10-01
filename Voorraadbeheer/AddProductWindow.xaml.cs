using System.CodeDom;
using System.Windows;
using Voorraadbeheer.Models;

namespace Voorraadbeheer
{
    /// <summary>
    /// Interaction logic for AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        //public AddProductWindow()
        //{
        //    InitializeComponent();   
        //}

        //public AddProductWindow(Product existingProduct)
        //{
        //    InitializeComponent();

        //    idTextBox.Text = existingProduct.Id.ToString();
        //}


        public AddProductWindow(Product product = null)
        {
            InitializeComponent();

            if (product is not null)
            {
                //titleLabel.Content = "Product wijzigen";

                idTextBox.Text = product.Id.ToString();
                nameTextBox.Text = product.Name.ToString();
                priceTextBox.Text = product.Price.ToString();
                stockTextBox.Text = product.Stock.ToString();

                addButton.Visibility = Visibility.Hidden;
            }
        }

        private Product _newProduct;

        public Product NewProduct
        {
            get { return _newProduct; }
        }


        private void OnAddProduct_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(idTextBox.Text);

                _newProduct = new Product(
                    id,
                    nameTextBox.Text,
                    decimal.Parse(priceTextBox.Text),
                    int.Parse(stockTextBox.Text));

                //this.Close(); // NIET DOEN!!!!!!
                this.DialogResult = true; //Deze sluit ook het venster af!
            }
            catch(ArgumentException ae)
            {
                MessageBox.Show(ae.Message);
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Deze data is niet in het juiste formaat.");
            }
        }       
    }
}
