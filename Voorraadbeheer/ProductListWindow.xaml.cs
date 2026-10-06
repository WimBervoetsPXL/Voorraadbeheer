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
using Voorraadbeheer.Application;
using Voorraadbeheer.Domain;
using Voorraadbeheer.Infrastructure;

namespace Voorraadbeheer
{
    /// <summary>
    /// Interaction logic for ProductListWindow.xaml
    /// </summary>
    public partial class ProductListWindow : Window
    {
        private ProductService _service;

        public ProductListWindow()
        {
            InitializeComponent();

            ProductRepository repository = new ProductRepository();
            _service = new ProductService(repository);

            ShowProducts();
        }

        private void ShowProducts()
        {
            // Load all products from repository
            productsListBox.Items.Clear();
            foreach (Product product in _service.GetAllProducts())
            {
                productsListBox.Items.Add(product);
            }
        }

        private void OnAddProduct_Clicked(object sender, RoutedEventArgs e)
        {
            AddProductWindow window = new AddProductWindow(_service);
            if (window.ShowDialog() == true)
            {
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
                _service.Remove(selectedProduct);
                ShowProducts();
            }
        }

        private void OnProduct_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (productsListBox.SelectedItem is Product selectedProduct)
            {
                AddProductWindow window = new AddProductWindow(_service, selectedProduct);
                window.Show();
            }
        }
    }
}