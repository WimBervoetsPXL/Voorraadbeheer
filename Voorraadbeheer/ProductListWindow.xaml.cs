using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Voorraadbeheer.Models;
using Voorraadbeheer.Services;

namespace Voorraadbeheer
{
    /// <summary>
    /// Interaction logic for ProductListWindow.xaml
    /// </summary>
    public partial class ProductListWindow : Window
    {
        private ProductRepository _repository = new ProductRepository();

        public ProductListWindow()
        {
            InitializeComponent();

            ShowProducts();
        }

        private void ShowProducts()
        {
            // Load all products from repository
            productsListBox.Items.Clear();
            foreach (Product product in _repository.GetAllProducts())
            {
                productsListBox.Items.Add(product);
            }
        }

        private void OnAddProduct_Clicked(object sender, RoutedEventArgs e)
        {
            AddProductWindow window = new AddProductWindow();
            if (window.ShowDialog() == true)
            {
                _repository.Add(window.NewProduct);
                ShowProducts();
            }
        }

        private void OnDeleteProduct_Clicked(object sender, RoutedEventArgs e)
        {
            //Product selected = productsListBox.SelectedItem as Product;
            //if(selected is not null)
            //{
            //    ...
            //}

            if(productsListBox.SelectedItem is Product selectedProduct)
            {
                _repository.Remove(selectedProduct);
                ShowProducts();
            }
        }

        private void OnProduct_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (productsListBox.SelectedItem is Product selectedProduct)
            {
                AddProductWindow window = new AddProductWindow(selectedProduct);
                window.Show();
            }
        }
    }
}
