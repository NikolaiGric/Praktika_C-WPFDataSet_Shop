using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using Пятерочка.Nachenocka_DeshevoDataSetTableAdapters;
using static MaterialDesignThemes.Wpf.Theme;


namespace Пятерочка
{

    public partial class Users : Window
    {
        ProductsTableAdapter products = new ProductsTableAdapter();
        ReviewsTableAdapter reviews = new ReviewsTableAdapter();
        AdsTableAdapter ads = new AdsTableAdapter();
        int ProductsID;
        string now_table;
        public Users()
        {
            InitializeComponent();
            Description.Visibility = Visibility.Hidden;
            Stars.Visibility = Visibility.Hidden;
            Create.Visibility = Visibility.Hidden;
            Update.Visibility = Visibility.Hidden;
            Delete.Visibility = Visibility.Hidden;
            Proda.Visibility = Visibility.Hidden;
            Description.Text = "";
        }

        private void Vieww_Click(object sender, RoutedEventArgs e)
        {
            Description.Visibility = Visibility.Hidden;
            Stars.Visibility = Visibility.Hidden;
            Create.Visibility = Visibility.Hidden;
            Update.Visibility = Visibility.Hidden;
            Delete.Visibility = Visibility.Hidden;
            Proda.Visibility = Visibility.Hidden;
            AllDataGrid.ItemsSource = products.GetData();
            now_table = "";
            Description.Text = "";
        }

        private void DDesk_Click(object sender, RoutedEventArgs e)
        {
            Description.Visibility = Visibility.Hidden;
            Stars.Visibility = Visibility.Hidden;
            Create.Visibility = Visibility.Hidden;
            Update.Visibility = Visibility.Hidden;
            Delete.Visibility = Visibility.Hidden;
            Proda.Visibility = Visibility.Hidden;
            AllDataGrid.ItemsSource = ads.GetData();
            now_table = "";
            Description.Text = "";
        }

        private void WWrite_Click(object sender, RoutedEventArgs e)
        {
            Description.Visibility = Visibility.Visible;
            Stars.Visibility = Visibility.Visible;
            Create.Visibility = Visibility.Visible;
            Update.Visibility = Visibility.Visible;
            Delete.Visibility = Visibility.Visible;
            Proda.Visibility = Visibility.Visible;
            AllDataGrid.ItemsSource = reviews.GetData();
            for (int i = 1; i <= 5; i++)
            {
                Stars.Items.Add(i);
            }
            now_table = "rews";

            Proda.ItemsSource = products.GetData();
            Proda.DisplayMemberPath = "Name";
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Description.Text) || Stars.SelectedItem == null || Description.Text.Length > 1000)
            {
                MessageBox.Show("Проверьте корректность введенных данных!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                int selectedValue = (int)Stars.SelectedItem;
                reviews.InsertQuery(selectedValue, Description.Text, ProductsID); // жестко решить завтра типа укажите продукт для отзыва
                AllDataGrid.ItemsSource = reviews.GetData();
            }

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object id = (AllDataGrid.SelectedItem as DataRowView).Row[0];
                if (string.IsNullOrEmpty(Description.Text) || Stars.SelectedItem == null || Description.Text.Length > 1000)
                {
                    MessageBox.Show("Проверьте корректность введенных данных!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                int selectedValue = (int)Stars.SelectedItem;
                reviews.UpdateQuery(selectedValue, Description.Text, ProductsID, Convert.ToInt32(id));
                AllDataGrid.ItemsSource = reviews.GetData();
            }
            catch
            {
                MessageBox.Show("Вы просто так нажали на кнопку!", "Справка", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object id = (AllDataGrid.SelectedItem as DataRowView).Row[0];
                reviews.DeleteQuery(Convert.ToInt32(id));
                AllDataGrid.ItemsSource = reviews.GetData();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547) // 547 - это код ошибки SQL Server для нарушения ограничения внешнего ключа
                {
                    MessageBox.Show("Нельзя удалить роль, так как существуют связанные записи в таблице Employers.",
                                    "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    // Если возникла другая ошибка, выводим стандартное сообщение
                    MessageBox.Show("Ошибка удаления записи: " + ex.Message,
                                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch
            {
                MessageBox.Show("Не тыкай просто так по кнопке удалить! ",
                                    "Хватит", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void AllDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            System.Windows.Controls.DataGrid dataGrid = (System.Windows.Controls.DataGrid)sender;
            DataRowView row_selected = dataGrid.SelectedItem as DataRowView;
            if (row_selected != null && now_table == "rews")
            {
                Description.Text = row_selected["Name_Reviews"].ToString();
            }
        }

        private void Proda_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView ProductsRow1 = (DataRowView)Proda.SelectedItem;
            ProductsID = (int)ProductsRow1["ID_Products"];
        }
    }
}
