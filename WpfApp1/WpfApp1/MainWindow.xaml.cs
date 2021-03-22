using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.context;
using WpfApp1.model;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CustomerContext customerContext;
        public MainWindow()
        {
            InitializeComponent();

            customerContext = new CustomerContext();
            customerContext.Customers.Load();
            CustomerGrid.ItemsSource = customerContext.Customers.Local.ToBindingList();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            customerContext.SaveChanges();
            
        }
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerGrid.SelectedItem != null) {
                customerContext.Customers.Remove((Customer)CustomerGrid.SelectedItem);
                customerContext.SaveChanges();
                MessageBox.Show("Действие выполнено");
            }

        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            AddCustomerWindow addCustomerWindow = new AddCustomerWindow();
            addCustomerWindow.Show();
            customerContext.SaveChanges();

        }

    }
}
