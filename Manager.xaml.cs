using MaterialDesignThemes.Wpf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using Пятерочка.Nachenocka_DeshevoDataSetTableAdapters;
using System.Configuration;

namespace Пятерочка
{
    public partial class Manager : Window
    {
        ProductsTableAdapter Products = new ProductsTableAdapter();
        TypeProductsTableAdapter TypeProducts = new TypeProductsTableAdapter();
        SizeTableAdapter Size = new SizeTableAdapter();
        ReviewsTableAdapter Reviews = new ReviewsTableAdapter();
        FirmsTableAdapter Firms = new FirmsTableAdapter();
        AdsTableAdapter Ads = new AdsTableAdapter();
        GiftsTableAdapter Gifts = new GiftsTableAdapter();

        string now_table;
        int ProductsID;
        int TypeProductID;
        int FirmsID;
        int SizeID;
        int ReviewsID;
        int GiftsID;


        public Manager()
        {
            InitializeComponent();
            TextBox_Data1.Visibility = Visibility.Hidden;
            TextBox_Data2.Visibility = Visibility.Hidden;
            TextBox_Data3.Visibility = Visibility.Hidden;
            ComboBox_Data1.Visibility = Visibility.Hidden;
            ComboBox_Data2.Visibility = Visibility.Hidden;
            ComboBox_Data3.Visibility = Visibility.Hidden;
            ComboBox_Data4.Visibility = Visibility.Hidden;
            ComboBox_Data5.Visibility = Visibility.Hidden;
            Create.Visibility = Visibility.Visible;
            Update.Visibility = Visibility.Visible;
            Delete.Visibility = Visibility.Visible;
            Import.Visibility = Visibility.Hidden;
        }

        private void size_Click(object sender, RoutedEventArgs e)
        {
            AllDataGrid.ItemsSource = Size.GetData();
            TextBox_Data1.Visibility = Visibility.Visible;
            TextBox_Data2.Visibility = Visibility.Visible;
            TextBox_Data3.Visibility = Visibility.Hidden;
            ComboBox_Data1.Visibility = Visibility.Hidden;
            ComboBox_Data2.Visibility = Visibility.Hidden;
            ComboBox_Data3.Visibility = Visibility.Hidden;
            ComboBox_Data4.Visibility = Visibility.Hidden;
            ComboBox_Data5.Visibility = Visibility.Hidden;
            Create.Visibility = Visibility.Visible;
            Update.Visibility = Visibility.Visible;
            Delete.Visibility = Visibility.Visible;
            now_table = "size";
            TextBox_Data1.Text = "";
            TextBox_Data2.Text = "";
            TextBox_Data3.Text = "";
            TextBox_Data1.ToolTip = "Объем размера (10 кг, 3км, 1000$ свиней)";
            TextBox_Data2.ToolTip = "То в чем измеряется товар (кг, км, $)";
            Import.Visibility = Visibility.Visible;

            HintAssist.SetHint(TextBox_Data1, "Указатель") ;
            HintAssist.SetHint(TextBox_Data2, "Наименование");
        }

        private void firms_Click(object sender, RoutedEventArgs e)
        {
            AllDataGrid.ItemsSource = Firms.GetData();
            TextBox_Data1.Visibility = Visibility.Visible;
            TextBox_Data2.Visibility = Visibility.Visible;
            TextBox_Data3.Visibility = Visibility.Hidden;
            ComboBox_Data1.Visibility = Visibility.Hidden;
            ComboBox_Data2.Visibility = Visibility.Hidden;
            ComboBox_Data3.Visibility = Visibility.Hidden;
            ComboBox_Data4.Visibility = Visibility.Hidden;
            ComboBox_Data5.Visibility = Visibility.Hidden;
            Create.Visibility = Visibility.Visible;
            Update.Visibility = Visibility.Visible;
            Delete.Visibility = Visibility.Visible;
            Import.Visibility = Visibility.Hidden;

            now_table = "firms";
            TextBox_Data1.Text = "";
            TextBox_Data2.Text = "";
            TextBox_Data3.Text = "";
            TextBox_Data1.ToolTip = "Название фирмы";
            TextBox_Data2.ToolTip = "Контракт фирмы, в формате: день/месяц/год";


            HintAssist.SetHint(TextBox_Data1, "Название");
            HintAssist.SetHint(TextBox_Data2, "Контракт");
        }

        private void typeproducts_Click(object sender, RoutedEventArgs e)
        {
            AllDataGrid.ItemsSource = TypeProducts.GetData();
            TextBox_Data1.Visibility = Visibility.Visible;
            TextBox_Data2.Visibility = Visibility.Hidden;
            TextBox_Data3.Visibility = Visibility.Hidden;
            ComboBox_Data1.Visibility = Visibility.Hidden;
            ComboBox_Data2.Visibility = Visibility.Hidden;
            ComboBox_Data3.Visibility = Visibility.Hidden;
            ComboBox_Data4.Visibility = Visibility.Hidden;
            ComboBox_Data5.Visibility = Visibility.Hidden;
            Create.Visibility = Visibility.Visible;
            Update.Visibility = Visibility.Visible;
            Delete.Visibility = Visibility.Visible;
            Import.Visibility = Visibility.Visible;
            now_table = "typeproducts";
            TextBox_Data1.Text = "";
            TextBox_Data2.Text = "";
            TextBox_Data3.Text = "";
            TextBox_Data1.ToolTip = "Тип продукта, т.е. к какому типу отнести данный продукт";


            HintAssist.SetHint(TextBox_Data1, "Тип");
        }

        private void reviews_Click(object sender, RoutedEventArgs e)
        {
            AllDataGrid.ItemsSource = Reviews.GetData();
            TextBox_Data1.Visibility = Visibility.Hidden;
            TextBox_Data2.Visibility = Visibility.Hidden;
            TextBox_Data3.Visibility = Visibility.Hidden;
            ComboBox_Data1.Visibility = Visibility.Hidden;
            ComboBox_Data2.Visibility = Visibility.Hidden;
            ComboBox_Data3.Visibility = Visibility.Hidden;
            ComboBox_Data4.Visibility = Visibility.Hidden;
            ComboBox_Data5.Visibility = Visibility.Hidden;
            Create.Visibility = Visibility.Hidden;
            Update.Visibility = Visibility.Hidden;
            Delete.Visibility = Visibility.Hidden;
            Import.Visibility = Visibility.Hidden;
            now_table = "reviews";
            TextBox_Data1.Text = "";
            TextBox_Data2.Text = "";
            TextBox_Data3.Text = "";
        }

        private void products_Click(object sender, RoutedEventArgs e)
        {
            AllDataGrid.ItemsSource = Products.GetData();
            TextBox_Data1.Visibility = Visibility.Visible;
            TextBox_Data2.Visibility = Visibility.Visible;
            TextBox_Data3.Visibility = Visibility.Visible;
            ComboBox_Data1.Visibility = Visibility.Visible;
            ComboBox_Data2.Visibility = Visibility.Visible;
            ComboBox_Data3.Visibility = Visibility.Visible;
            ComboBox_Data4.Visibility = Visibility.Visible;
            ComboBox_Data5.Visibility = Visibility.Hidden;
            Create.Visibility = Visibility.Visible;
            Update.Visibility = Visibility.Visible;
            Delete.Visibility = Visibility.Visible;
            Import.Visibility = Visibility.Hidden;
            now_table = "products";
            TextBox_Data1.ToolTip = "Название продукта";
            TextBox_Data2.ToolTip = "Цена продукта";
            TextBox_Data3.ToolTip = "Срок годности продукта, в формате: день/месяц/год";
            ComboBox_Data1.ToolTip = "Объем размера (10 кг, 3км, 1000$ свиней";
            ComboBox_Data2.ToolTip = "Наименование фирмы";
            ComboBox_Data3.ToolTip = "Тип продукта";
            ComboBox_Data4.ToolTip = "Бонусы при покупке";
            TextBox_Data1.Text = "";
            TextBox_Data2.Text = "";
            TextBox_Data3.Text = "";

            HintAssist.SetHint(TextBox_Data1, "Название");
            HintAssist.SetHint(TextBox_Data2, "Цена");
            HintAssist.SetHint(TextBox_Data3, "Срок годности");
            HintAssist.SetHint(ComboBox_Data1, "Указатель размера");
            HintAssist.SetHint(ComboBox_Data2, "Фирма");
            HintAssist.SetHint(ComboBox_Data3, "Тип");
            HintAssist.SetHint(ComboBox_Data4, "Бонусы");

            ComboBox_Data1.ItemsSource = Size.GetData();
            ComboBox_Data1.DisplayMemberPath = "Size";
            ComboBox_Data2.ItemsSource = Firms.GetData();
            ComboBox_Data2.DisplayMemberPath = "Name_Firms";
            ComboBox_Data3.ItemsSource = TypeProducts.GetData();
            ComboBox_Data3.DisplayMemberPath = "Name_TypeProducts";
            ComboBox_Data4.ItemsSource = Gifts.GetData();
            ComboBox_Data4.DisplayMemberPath = "Name_Gifts";
        }

        private void gifts_Click(object sender, RoutedEventArgs e)
        {
            AllDataGrid.ItemsSource = Gifts.GetData();
            TextBox_Data1.Visibility = Visibility.Visible;
            TextBox_Data2.Visibility = Visibility.Visible;
            TextBox_Data3.Visibility = Visibility.Hidden;
            ComboBox_Data1.Visibility = Visibility.Hidden;
            ComboBox_Data2.Visibility = Visibility.Hidden;
            ComboBox_Data3.Visibility = Visibility.Hidden;
            ComboBox_Data4.Visibility = Visibility.Hidden;
            ComboBox_Data5.Visibility = Visibility.Hidden;
            Create.Visibility = Visibility.Visible;
            Update.Visibility = Visibility.Visible;
            Delete.Visibility = Visibility.Visible;
            Import.Visibility = Visibility.Visible;
            now_table = "gifts";
            TextBox_Data1.Text = "";
            TextBox_Data2.Text = "";
            TextBox_Data3.Text = "";
            TextBox_Data1.ToolTip = "Что за бонусы предоставляются за покупку данного товара";
            TextBox_Data2.ToolTip = "Описание данных бонусов";

            HintAssist.SetHint(TextBox_Data1, "Бонусы");
            HintAssist.SetHint(TextBox_Data2, "Описание");
        }

        private void ads_Click(object sender, RoutedEventArgs e)
        {
            AllDataGrid.ItemsSource = Ads.GetData();
            TextBox_Data1.Visibility = Visibility.Hidden;
            TextBox_Data2.Visibility = Visibility.Hidden;
            TextBox_Data3.Visibility = Visibility.Hidden;
            ComboBox_Data1.Visibility = Visibility.Hidden;
            ComboBox_Data2.Visibility = Visibility.Hidden;
            ComboBox_Data3.Visibility = Visibility.Hidden;
            ComboBox_Data4.Visibility = Visibility.Hidden; 
            ComboBox_Data5.Visibility = Visibility.Visible; 
            Create.Visibility = Visibility.Visible;
            Update.Visibility = Visibility.Visible;
            Delete.Visibility = Visibility.Visible;
            Import.Visibility = Visibility.Hidden;
            now_table = "ads";
            ComboBox_Data5.ToolTip = "Продукт";
            TextBox_Data1.Text = "";
            TextBox_Data2.Text = "";
            TextBox_Data3.Text = "";

            ComboBox_Data5.ItemsSource = Products.GetData();
            ComboBox_Data5.DisplayMemberPath = "Name";

            TextBox_Data1.ToolTip = "Выберите продукт для добавления в доску объявлений";
            HintAssist.SetHint(ComboBox_Data5, "Продукт");
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if (now_table == "size")
            {
                if (string.IsNullOrEmpty(TextBox_Data1.Text) || TextBox_Data1.Text.Length > 20 || 
                    string.IsNullOrEmpty(TextBox_Data2.Text) || TextBox_Data2.Text.Length > 20)
                {
                    MessageBox.Show("Название размера и его наименование должно быть заполнено и не может быть длиннее 20 символов.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return; // Прекратить выполнение метода, если условие не выполнено
                }
                else { 
                    Size.InsertQuery(TextBox_Data1.Text, TextBox_Data2.Text);
                    ComboBox_Data1.ItemsSource = Size.GetData();
                    AllDataGrid.ItemsSource = Size.GetData();
                }
            }
            else if (now_table == "firms")
            {
                try
                {
                    if (string.IsNullOrEmpty(TextBox_Data1.Text) || TextBox_Data1.Text.Length > 30 ||
                        string.IsNullOrEmpty(TextBox_Data2.Text))
                    {
                        MessageBox.Show("Правильно ли введен формат даты? Название фирмы не должно превышать 30 символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        Firms.InsertQuery(TextBox_Data1.Text, TextBox_Data2.Text);
                        ComboBox_Data2.ItemsSource = Firms.GetData();
                        AllDataGrid.ItemsSource = Firms.GetData();
                    }
                }
                catch
                {
                    MessageBox.Show("Пожалуйста правильно введите формат даты", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            else if (now_table == "ads")
            {
                try
                {
                    if (ComboBox_Data5.SelectedItem == null)
                    {
                        MessageBox.Show("Требуется выбрать товар", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        Ads.InsertQuery((int)ProductsID);
                        AllDataGrid.ItemsSource = Ads.GetData();
                    }
                }
                catch
                {
                    MessageBox.Show("Пж выбери продукт", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else if (now_table == "gifts")
            {
                if (string.IsNullOrEmpty(TextBox_Data1.Text) || TextBox_Data1.Text.Length > 120 ||
                    string.IsNullOrEmpty(TextBox_Data2.Text) || TextBox_Data1.Text.Length > 300)
                {
                    MessageBox.Show("Наименование бонуса должен быть заполнен и не должен превышать 120 символов, как и описание бонуса должно быть заполнено и не превышать 300 символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    Gifts.InsertQuery(TextBox_Data1.Text, TextBox_Data2.Text);
                    ComboBox_Data5.ItemsSource = Gifts.GetData();
                    AllDataGrid.ItemsSource = Gifts.GetData();
                }

            }
            else if (now_table == "typeproducts")
            {
                if (string.IsNullOrEmpty(TextBox_Data1.Text) || TextBox_Data1.Text.Length > 30)
                {
                    MessageBox.Show("Тип продукта должен быть заполнен и соответствовать пределу символов.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    TypeProducts.InsertQuery(TextBox_Data1.Text);
                    ComboBox_Data3.ItemsSource = TypeProducts.GetData();
                    AllDataGrid.ItemsSource = TypeProducts.GetData();
                }
            }
            else if (now_table == "products")
            {
                try
                {
                    if (string.IsNullOrEmpty(TextBox_Data1.Text) || string.IsNullOrEmpty(TextBox_Data2.Text) || string.IsNullOrEmpty(TextBox_Data3.Text) ||
                         Convert.ToInt32(TextBox_Data2.Text) < 0 ||
                        TextBox_Data1.Text.Length > 100 ||
                        ComboBox_Data1.SelectedItem == null || ComboBox_Data2.SelectedItem == null ||
                        ComboBox_Data3.SelectedItem == null || ComboBox_Data4.SelectedItem == null)
                    {
                        MessageBox.Show("Проверьте корректность введенных данных!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    else
                    {
                        Products.InsertQuery(Convert.ToInt32(TypeProductID),
                                            (int)FirmsID,
                                            (int)SizeID,
                                            TextBox_Data1.Text,
                                            Convert.ToInt32(TextBox_Data2.Text),
                                            TextBox_Data3.Text,
                                            (int)GiftsID
                                            );
                        AllDataGrid.ItemsSource = Products.GetData();
                    }
                }
                catch
                {
                    MessageBox.Show("Пожалуйста правильно введите формат даты", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (now_table == "size")
                {
                    object id = (AllDataGrid.SelectedItem as DataRowView).Row[0];
                    if (string.IsNullOrEmpty(TextBox_Data1.Text) || TextBox_Data1.Text.Length > 20 ||
                        string.IsNullOrEmpty(TextBox_Data2.Text) || TextBox_Data2.Text.Length > 20)
                    {
                        MessageBox.Show("Название размера и его наименование должно быть заполнено и не может быть длиннее 20 символов.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return; // Прекратить выполнение метода, если условие не выполнено
                    }
                    else
                    {
                        Size.UpdateQuery(TextBox_Data1.Text, TextBox_Data2.Text, Convert.ToInt32(id));
                        AllDataGrid.ItemsSource = Size.GetData();
                    }
                }
                else if (now_table == "firms")
                {
                    object id = (AllDataGrid.SelectedItem as DataRowView).Row[0];
                    if (string.IsNullOrEmpty(TextBox_Data1.Text) || TextBox_Data1.Text.Length > 30 ||
                        string.IsNullOrEmpty(TextBox_Data2.Text))
                    {
                        MessageBox.Show("Правильно ли введен формат даты? Название фирмы не должно превышать 30 символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        Firms.UpdateQuery(TextBox_Data1.Text, TextBox_Data2.Text, Convert.ToInt32(id));
                        ComboBox_Data1.ItemsSource = Firms.GetData();
                        AllDataGrid.ItemsSource = Firms.GetData();
                    }
                }
                else if (now_table == "ads")
                {
                    object id = (AllDataGrid.SelectedItem as DataRowView).Row[0];

                    if (ComboBox_Data5.SelectedItem == null)
                    {
                        MessageBox.Show("Пж выбери продукт", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        Ads.UpdateQuery((int)ProductsID, Convert.ToInt32(id));
                        ComboBox_Data5.ItemsSource = Ads.GetData();
                        AllDataGrid.ItemsSource = Ads.GetData();
                    }
                   

                }
                else if (now_table == "gifts")
                {
                    object id = (AllDataGrid.SelectedItem as DataRowView).Row[0];
                    if (string.IsNullOrEmpty(TextBox_Data1.Text) || TextBox_Data1.Text.Length > 120 ||
                        string.IsNullOrEmpty(TextBox_Data2.Text) || TextBox_Data1.Text.Length > 300)
                    {
                        MessageBox.Show("Наименование бонуса должен быть заполнен и не должен превышать 120 символов, как и описание бонуса должно быть заполнено и не превышать 300 символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        Gifts.UpdateQuery(TextBox_Data1.Text, TextBox_Data2.Text, Convert.ToInt32(id));
                        ComboBox_Data5.ItemsSource = Gifts.GetData();
                        AllDataGrid.ItemsSource = Gifts.GetData();
                    }
                    

                }
                else if (now_table == "typeproducts")
                {
                    object id = (AllDataGrid.SelectedItem as DataRowView).Row[0];
                    if (string.IsNullOrEmpty(TextBox_Data1.Text) || TextBox_Data1.Text.Length > 30)
                    {
                        MessageBox.Show("Тип продукта должен быть заполнен и соответствовать пределу символов.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    else
                    {
                        TypeProducts.UpdateQuery(TextBox_Data1.Text, Convert.ToInt32(id));
                        ComboBox_Data1.ItemsSource = TypeProducts.GetData();
                        AllDataGrid.ItemsSource = TypeProducts.GetData();
                    }
                    
                }
                else if (now_table == "products")
                {
                    object id = (AllDataGrid.SelectedItem as DataRowView).Row[0];
                    if (string.IsNullOrEmpty(TextBox_Data1.Text) || string.IsNullOrEmpty(TextBox_Data2.Text) || string.IsNullOrEmpty(TextBox_Data3.Text) ||
                         Convert.ToInt32(TextBox_Data2.Text) < 0 ||
                        TextBox_Data1.Text.Length > 100 ||
                        ComboBox_Data1.SelectedItem == null || ComboBox_Data2.SelectedItem == null ||
                        ComboBox_Data3.SelectedItem == null || ComboBox_Data4.SelectedItem == null )
                    {
                        MessageBox.Show("Проверьте корректность введенных данных!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    else
                    {
                        AllDataGrid.ItemsSource = Products.GetData();
                        Products.UpdateQuery(Convert.ToInt32(TypeProductID),
                            (int)FirmsID,
                            (int)SizeID,
                            TextBox_Data1.Text,
                            Convert.ToInt32(TextBox_Data2.Text),
                            TextBox_Data3.Text,
                            Convert.ToInt32(GiftsID),
                            Convert.ToInt32(id));
                        AllDataGrid.ItemsSource = Products.GetData();
                    }
                }
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("Нельзя нажать на кнопку изменить не выбрав данные", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object selectedItem = AllDataGrid.SelectedItem;
                if (selectedItem == null)
                {
                    MessageBox.Show("Нельзя нажимать на кнопку без выбора данных!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                object id = (selectedItem as DataRowView).Row[0];
                int entityId = Convert.ToInt32(id);

                if (now_table == "size")
                {
                    DeleteRecordWithRelatedData(() => Size.DeleteQuery(entityId), Size.GetData);
                }
                else if (now_table == "firms")
                {
                    DeleteRecordWithRelatedData(() => Firms.DeleteQuery(entityId), Firms.GetData);
                }
                else if (now_table == "gifts")
                {
                    DeleteRecordWithRelatedData(() => Gifts.DeleteQuery(entityId), Gifts.GetData);
                }
                else if (now_table == "ads")
                {
                    DeleteRecordWithRelatedData(() => Ads.DeleteQuery(entityId), Ads.GetData);
                }
                else if (now_table == "typeproducts")
                {
                    DeleteRecordWithRelatedData(() => TypeProducts.DeleteQuery(entityId), TypeProducts.GetData);
                }
                else if (now_table == "products")
                {
                    DeleteProductWithRelatedData(entityId);
                }
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("Нельзя нажимать на кнопку без выбора данных!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void DeleteRecordWithRelatedData(Action deleteQuery, Func<IEnumerable> getData)
        {
            try
            {
                deleteQuery();
                AllDataGrid.ItemsSource = getData();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547) // 547 - это код ошибки SQL Server для нарушения ограничения внешнего ключа
                {
                    MessageBox.Show("Нельзя удалить запись, так как существуют связанные записи в других таблицах.",
                                    "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    // Если возникла другая ошибка, выводим стандартное сообщение
                    MessageBox.Show("Ошибка удаления записи: " + ex.Message,
                                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void DeleteProductWithRelatedData(int productId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Пятерочка.Properties.Settings.Nachenocka_DeshevoConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Удаление связанных записей из таблицы Ads
                        using (SqlCommand deleteAdsCommand = new SqlCommand("DELETE FROM Ads WHERE Products_ID = @ProductId", connection, transaction))
                        {
                            deleteAdsCommand.Parameters.AddWithValue("@ProductId", productId);
                            deleteAdsCommand.ExecuteNonQuery();
                        }

                        // Удаление связанных записей из таблицы Reviews
                        using (SqlCommand deleteReviewsCommand = new SqlCommand("DELETE FROM Reviews WHERE Products_ID = @ProductId", connection, transaction))
                        {
                            deleteReviewsCommand.Parameters.AddWithValue("@ProductId", productId);
                            deleteReviewsCommand.ExecuteNonQuery();
                        }

                        // Удаление записи из таблицы Products
                        using (SqlCommand deleteProductCommand = new SqlCommand("DELETE FROM Products WHERE ID_Products = @ProductId", connection, transaction))
                        {
                            deleteProductCommand.Parameters.AddWithValue("@ProductId", productId);
                            deleteProductCommand.ExecuteNonQuery();
                        }

                        // Подтверждение транзакции
                        transaction.Commit();

                        // Обновление данных в DataGrid
                        AllDataGrid.ItemsSource = Products.GetData();
                    }
                    catch (SqlException ex)
                    {
                        // Откат транзакции в случае ошибки
                        transaction.Rollback();
                        MessageBox.Show("Ошибка удаления записи: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }


        private void ComboBox_Data1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string selected = ComboBox_Data1.SelectedItem as string;
                if (now_table == "products")
                {
                    DataRowView TypeProductRow1 = (DataRowView)ComboBox_Data1.SelectedItem;
                    SizeID = (int)TypeProductRow1["ID_Size"];
                }
                else if (now_table == "ads")
                {
                    DataRowView ProductsRow1 = (DataRowView)ComboBox_Data1.SelectedItem;
                    ProductsID = (int)ProductsRow1["ID_Products"];
                }
            }
            catch
            {

            }
        }

        private void ComboBox_Data2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try { 
            string selected = ComboBox_Data2.SelectedItem as string;
            if (now_table == "products")
            {
                DataRowView FirmsRow1 = (DataRowView)ComboBox_Data2.SelectedItem;
                FirmsID = (int)FirmsRow1["ID_Firms"];
            }
        }
            catch
            {
            
            }

}

        private void ComboBox_Data3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try {

            string selected = ComboBox_Data3.SelectedItem as string;
            if (now_table == "products")
            {
                DataRowView SizeRow1 = (DataRowView)ComboBox_Data3.SelectedItem;
                    TypeProductID = (int)SizeRow1["ID_TypeProducts"];
            }
        }
            catch
            {
            
            }
}

        private void AllDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            System.Windows.Controls.DataGrid dataGrid = (System.Windows.Controls.DataGrid)sender;
            DataRowView row_selected = dataGrid.SelectedItem as DataRowView;
            if (now_table == "size" && row_selected != null)
            {
                TextBox_Data1.Text = row_selected["Size"].ToString();
                TextBox_Data2.Text = row_selected["Name_Size"].ToString();
            }
            else if (now_table == "firms" && row_selected != null)
            {
                TextBox_Data1.Text = row_selected["Name_Firms"].ToString();
                TextBox_Data2.Text = row_selected["Contracts"].ToString();
            }
            else if (now_table == "gifts" && row_selected != null)
            {
                TextBox_Data1.Text = row_selected["Name_Gifts"].ToString();
                TextBox_Data2.Text = row_selected["Description"].ToString();
            }
            else if (now_table == "typeproducts" && row_selected != null)
            {
                TextBox_Data1.Text = row_selected["Name_TypeProducts"].ToString();
            }
            else if (now_table == "reviews" && row_selected != null)
            {
                TextBox_Data1.Text = row_selected["Name_Stars"].ToString();
                TextBox_Data2.Text = row_selected["Name_Reviews"].ToString();
            }
            else if (now_table == "ads" && row_selected != null)
            {
                int selectedAdsID = Convert.ToInt32(row_selected["Products_ID"]);
                ComboBox_Data5.SelectedItem = FindComboBoxItemByAdsID(selectedAdsID);
            }
            else if (now_table == "products" && row_selected != null)
            {
                    TextBox_Data1.Text = row_selected["Name"].ToString();
                    TextBox_Data2.Text = row_selected["Price"].ToString();
                    TextBox_Data3.Text = row_selected["Products_Life"].ToString();


                    int selectedSizeID = Convert.ToInt32(row_selected["Size_ID"]);
                    ComboBox_Data1.SelectedItem = FindComboBoxItemBySizeID(selectedSizeID);
                    int selectedFirmsID = Convert.ToInt32(row_selected["Firms_ID"]);
                    ComboBox_Data2.SelectedItem = FindComboBoxItemByFirmsID(selectedFirmsID);
                    int selectedTypeProductsID = Convert.ToInt32(row_selected["TypeProducts_ID"]);
                    ComboBox_Data3.SelectedItem = FindComboBoxItemByTypeProductsID(selectedTypeProductsID);

                    int selectedGiftsID = Convert.ToInt32(row_selected["Gifts_ID"]);
                    ComboBox_Data4.SelectedItem = FindComboBoxItemByGiftsID(selectedGiftsID);

                }
        }

        private void ComboBox_Data4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try { 
            string selected = ComboBox_Data4.SelectedItem as string;
            if (now_table == "products")
            {
                DataRowView GiftsRow1 = (DataRowView)ComboBox_Data4.SelectedItem;
                GiftsID = (int)GiftsRow1["ID_Gifts"];
            }
        }
            catch
            {
                MessageBox.Show("Ошибка, чиним!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
}

        private void ComboBox_Data5_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try { 
            string selected = ComboBox_Data5.SelectedItem as string;
            DataRowView AdsRow1 = (DataRowView)ComboBox_Data5.SelectedItem;
            ProductsID = (int)AdsRow1["ID_Products"];
        }
            catch
            {
                MessageBox.Show("Ошибка, чиним!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
}
        private object FindComboBoxItemByAdsID(int adsID)
        {
            foreach (var item in ComboBox_Data5.Items)
            {
                DataRowView dataRowView = item as DataRowView;
                if (dataRowView != null && (int)dataRowView["ID_Products"] == adsID)
                {
                    return item;
                }
            }
            return null;
        }
        
        private object FindComboBoxItemByTypeProductsID(int adsID)
        {
            foreach (var item in ComboBox_Data3.Items)
            {
                DataRowView dataRowView = item as DataRowView;
                if (dataRowView != null && (int)dataRowView["ID_TypeProducts"] == adsID)
                {
                    return item;
                }
            }
            return null;
        }
        private object FindComboBoxItemByFirmsID(int adsID)
        {
            foreach (var item in ComboBox_Data2.Items)
            {
                DataRowView dataRowView = item as DataRowView;
                if (dataRowView != null && (int)dataRowView["ID_Firms"] == adsID)
                {
                    return item;
                }
            }
            return null;
        }
        private object FindComboBoxItemBySizeID(int adsID)
        {
            foreach (var item in ComboBox_Data1.Items)
            {
                DataRowView dataRowView = item as DataRowView;
                if (dataRowView != null && (int)dataRowView["ID_Size"] == adsID)
                {
                    return item;
                }
            }
            return null;
        }
        private object FindComboBoxItemByGiftsID(int adsID)
        {
            foreach (var item in ComboBox_Data4.Items)
            {
                DataRowView dataRowView = item as DataRowView;
                if (dataRowView != null && (int)dataRowView["ID_Gifts"] == adsID)
                {
                    return item;
                }
            }
            return null;
        }
        internal class sizemodel
        {
            public string Size_Size {get; set; }
            public string Name_Size { get; set; }
        }
        internal class giftsmodel
        {
            public string Description {get; set; }
            public string Name_Gifts {get; set; }
        }
        internal class typeproductsmodel
        {
            public string Name_typeproducts { get; set; }
        }
        private void Import_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (now_table == "size")
                {
                    List<sizemodel> forImport = ConverterLaba.DeserializeObject<List<sizemodel>>();
                    foreach (var item in forImport)
                    {
                        Size.InsertQuery(item.Name_Size, item.Size_Size);
                    }
                    AllDataGrid.ItemsSource = null;
                    AllDataGrid.ItemsSource = Size.GetData();

                }
                else if (now_table == "gifts")
                {
                    List<giftsmodel> forImport = ConverterLaba.DeserializeObject<List<giftsmodel>>();
                    foreach (var item in forImport)
                    {
                        Gifts.InsertQuery(item.Name_Gifts, item.Description);
                    }
                    AllDataGrid.ItemsSource = null;
                    AllDataGrid.ItemsSource = Gifts.GetData();
                }
                else if (now_table == "typeproducts")
                {
                    List<typeproductsmodel> forImport = ConverterLaba.DeserializeObject<List<typeproductsmodel>>();
                    foreach (var item in forImport)
                    {
                        TypeProducts.InsertQuery(item.Name_typeproducts);
                    }
                    AllDataGrid.ItemsSource = null;
                    AllDataGrid.ItemsSource = TypeProducts.GetData();
                }
            }
            catch
            {
                MessageBox.Show("Выберите файл!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }
    }
}
