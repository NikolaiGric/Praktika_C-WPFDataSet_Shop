using MaterialDesignThemes.Wpf;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Пятерочка.Nachenocka_DeshevoDataSetTableAdapters;
using static MaterialDesignThemes.Wpf.Theme;

namespace Пятерочка
{
    public partial class Admin : Window
    {
        RoleeTableAdapter Rolee = new RoleeTableAdapter();
        EmployersTableAdapter Employers = new EmployersTableAdapter();
        AuthorizyshinTableAdapter Authorizyshin = new AuthorizyshinTableAdapter();

        string now_table;
        int RoleeID;
        int EmployersID;

        public Admin()
        {
            InitializeComponent();
            TextBox_Data1.Visibility = Visibility.Visible;
            TextBox_Data2.Visibility = Visibility.Hidden;
            TextBox_Data3.Visibility = Visibility.Hidden;
            PasswordTbx.Visibility = Visibility.Hidden;
            ComboBox_Data1.Visibility = Visibility.Hidden;
        }

        private static StringBuilder ComputeSHA256Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(bytes);
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }
                return builder;
            }
        }

        private void rolee_Click(object sender, RoutedEventArgs e)
        {
            AllDataGrid.ItemsSource = Rolee.GetData();
            TextBox_Data1.Visibility = Visibility.Visible;
            TextBox_Data2.Visibility = Visibility.Hidden;
            TextBox_Data3.Visibility = Visibility.Hidden;
            PasswordTbx.Visibility = Visibility.Hidden;
            ComboBox_Data1.Visibility = Visibility.Hidden;
            now_table = "rolee";
            TextBox_Data1.ToolTip = "Наименование роли";
            TextBox_Data1.Text = "";
            TextBox_Data2.Text = "";
            TextBox_Data3.Text = "";
            HintAssist.SetHint(TextBox_Data1, "Роль");
        }

        private void employers_Click(object sender, RoutedEventArgs e)
        {
            AllDataGrid.ItemsSource = Employers.GetData();
            TextBox_Data1.Visibility = Visibility.Visible;
            TextBox_Data2.Visibility = Visibility.Visible;
            TextBox_Data3.Visibility = Visibility.Visible;
            ComboBox_Data1.Visibility = Visibility.Visible;
            PasswordTbx.Visibility = Visibility.Hidden;
            now_table = "employers";
            TextBox_Data1.Text = "";
            TextBox_Data2.Text = "";
            TextBox_Data3.Text = "";
            TextBox_Data1.ToolTip = "Фамилия Сотрудника";
            TextBox_Data2.ToolTip = "Имя Сотрудника";
            TextBox_Data3.ToolTip = "Отчество Сотрудника";
            ComboBox_Data1.ToolTip = "Роль Сотрудника";

            HintAssist.SetHint(TextBox_Data1, "Фамилия");
            HintAssist.SetHint(TextBox_Data2, "Имя");
            HintAssist.SetHint(TextBox_Data3, "Отчество");
            HintAssist.SetHint(ComboBox_Data1, "Роль");
            ComboBox_Data1.ItemsSource = Rolee.GetData();
            ComboBox_Data1.DisplayMemberPath = "Name_Role";
        }

        private void authorizeyshin_Click(object sender, RoutedEventArgs e)
        {
            AllDataGrid.ItemsSource = Authorizyshin.GetData();
            TextBox_Data1.Visibility = Visibility.Visible;
            TextBox_Data2.Visibility = Visibility.Hidden;
            TextBox_Data3.Visibility = Visibility.Hidden;
            PasswordTbx.Visibility = Visibility.Visible;
            ComboBox_Data1.Visibility = Visibility.Visible;
            now_table = "authorizeyshin";
            TextBox_Data1.Text = "";
            TextBox_Data2.Text = "";
            TextBox_Data3.Text = "";
            TextBox_Data1.ToolTip = "Логин Сотрудника";
            TextBox_Data2.ToolTip = "Пароль Сотрудника";
            ComboBox_Data1.ToolTip = "Фамилия Сотрудника";

            HintAssist.SetHint(TextBox_Data1, "Логин");
            HintAssist.SetHint(TextBox_Data2, "Пароль");
            HintAssist.SetHint(ComboBox_Data1, "Фамилия");
            ComboBox_Data1.ItemsSource = Employers.GetData();
            ComboBox_Data1.DisplayMemberPath = "Last_Name";
        }
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if (now_table == "rolee")
            {
                if (string.IsNullOrEmpty(TextBox_Data1.Text) || TextBox_Data1.Text.Length > 20)
                {
                    MessageBox.Show("Название роли должно быть заполнено и не может быть длиннее 20 символов. Роль должна быть вменяемой", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return; // Прекратить выполнение метода, если условие не выполнено
                }
                if (TextBox_Data1.Text == "Admin" || TextBox_Data1.Text == "Employeer" || TextBox_Data1.Text == "Users" || TextBox_Data1.Text == "Manager")
                {
                    Rolee.InsertQuery(TextBox_Data1.Text);
                    AllDataGrid.ItemsSource = Rolee.GetData();
                }
                else
                {
                    MessageBox.Show("У нас есть 4 роли: \"Admin\", \"Employeer\", \"Users\", \"Manager\", Остальное от лукавого", "Напоминание", MessageBoxButton.OK, MessageBoxImage.Information);

                }
            }
            else if (now_table == "employers")
            {
                if (string.IsNullOrEmpty(TextBox_Data1.Text) || TextBox_Data1.Text.Length > 20 ||
                    string.IsNullOrEmpty(TextBox_Data2.Text) || TextBox_Data2.Text.Length > 15 ||
                    TextBox_Data3.Text.Length > 20 || ComboBox_Data1.SelectedItem == null)
                {
                    MessageBox.Show("Имя и фамилия сотрудника должны быть заполнены и не могут быть длиннее 20 символов. Так же нужно выбрать роль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    Employers.InsertQuery(Convert.ToInt32(RoleeID), TextBox_Data1.Text, TextBox_Data2.Text, TextBox_Data3.Text);
                    
                    AllDataGrid.ItemsSource = Employers.GetData();
                }
                // еще один елюсе
            }
            else if (now_table == "authorizeyshin")
            {
                if (string.IsNullOrEmpty(TextBox_Data1.Text) || string.IsNullOrEmpty(PasswordTbx.Password) || TextBox_Data1.Text.Length > 20 || PasswordTbx.Password.Length > 100 || ComboBox_Data1.SelectedItem == null)
                {
                    MessageBox.Show("Логин и пароль сотрудника должны быть заполнены и соответствовать пределу символов.  Так же нужно выбрать сотрудника", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    Authorizyshin.InsertQuery(Convert.ToInt32(EmployersID), TextBox_Data1.Text, Convert.ToString(ComputeSHA256Hash(PasswordTbx.Password)));
                    ComboBox_Data1.ItemsSource = Authorizyshin.GetData();
                    ComboBox_Data1.DisplayMemberPath = "Last_Name";
                    AllDataGrid.ItemsSource = Authorizyshin.GetData();
                }
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (now_table == "rolee")
                {
                    object id = (AllDataGrid.SelectedItem as DataRowView).Row[0];
                    if (string.IsNullOrEmpty(TextBox_Data1.Text) || TextBox_Data1.Text.Length > 20)
                    {
                        MessageBox.Show("Название роли должно быть заполнено и не может быть длиннее 20 символов.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    if (TextBox_Data1.Text == "Admin" || TextBox_Data1.Text == "Employeer" || TextBox_Data1.Text == "Users" || TextBox_Data1.Text == "Manager")
                    {
                        Rolee.UpdateQuery(TextBox_Data1.Text, Convert.ToInt32(id));
                        AllDataGrid.ItemsSource = Rolee.GetData();
                    }
                    else
                    {
                        MessageBox.Show("У нас есть 4 роли: \"Admin\", \"Employeer\", \"Users\", \"Manager\", Остальное от лукавого", "Напоминание", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                }
                else if (now_table == "employers")
                {
                    if (string.IsNullOrEmpty(TextBox_Data1.Text) || TextBox_Data1.Text.Length > 20 ||
                        string.IsNullOrEmpty(TextBox_Data2.Text) || TextBox_Data2.Text.Length > 15 ||
                        TextBox_Data3.Text.Length > 20 || ComboBox_Data1.SelectedItem == null)
                    {
                        MessageBox.Show("Имя и фамилия сотрудника должны быть заполнены и не могут быть длиннее 20 символов. Так же нужно выбрать роль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    else
                    {
                        object id = (AllDataGrid.SelectedItem as DataRowView).Row[0];
                        Employers.UpdateQuery(Convert.ToInt32(RoleeID), TextBox_Data1.Text, TextBox_Data2.Text, TextBox_Data3.Text, Convert.ToInt32(id));
                        AllDataGrid.ItemsSource = Employers.GetData();
                    }
                }
                else if (now_table == "authorizeyshin")
                {
                    if (string.IsNullOrEmpty(TextBox_Data1.Text) || string.IsNullOrEmpty(PasswordTbx.Password) || TextBox_Data1.Text.Length > 20 || PasswordTbx.Password.Length > 100 || ComboBox_Data1.SelectedItem == null)
                    {
                        MessageBox.Show("Логин и пароль сотрудника должны быть заполнены и соответствовать пределу символов. Так же нужно выбрать сотрудника", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    else 
                    {
                        object id = (AllDataGrid.SelectedItem as DataRowView).Row[0];
                        Authorizyshin.UpdateQuery(Convert.ToInt32(EmployersID), TextBox_Data1.Text, Convert.ToString(ComputeSHA256Hash(PasswordTbx.Password)), Convert.ToInt32(id));
                        AllDataGrid.ItemsSource = Authorizyshin.GetData();
                    }
                }
            }
            catch (Exception ex){ 
                        MessageBox.Show($"Нужно выбрать данные для изменения. {ex}" + "Так же у одной роли может быть только один ", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (now_table == "rolee")
                {
                    try
                    {
                        object id = (AllDataGrid.SelectedItem as DataRowView).Row[0];
                        Rolee.DeleteQuery(Convert.ToInt32(id));
                        AllDataGrid.ItemsSource = Rolee.GetData();
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
                }
                else if (now_table == "employers")
                {
                    try
                    {
                        object id = (AllDataGrid.SelectedItem as DataRowView).Row[0];
                        Employers.DeleteQuery(Convert.ToInt32(id));
                        AllDataGrid.ItemsSource = Employers.GetData();
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
                else if (now_table == "authorizeyshin")
                {
                    object id = (AllDataGrid.SelectedItem as DataRowView).Row[0];
                    Authorizyshin.DeleteQuery(Convert.ToInt32(id));
                    AllDataGrid.ItemsSource = Authorizyshin.GetData();

                }
            }
            catch
            {
                MessageBox.Show("Хватит тыкать!",
                                            "Для Вас", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ComboBox_Data1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (now_table == "employers" && ComboBox_Data1.SelectedItem != null)
            {
                DataRowView RoleeRow1 = (DataRowView)ComboBox_Data1.SelectedItem;
                RoleeID = (int)RoleeRow1["ID_Rolee"];
            }
            else if (now_table == "authorizeyshin" && ComboBox_Data1.SelectedItem != null)
            {
                DataRowView RoleeRow2 = (DataRowView)ComboBox_Data1.SelectedItem;
                EmployersID = (int)RoleeRow2["ID_Employers"];
            }
        }

        private void AllDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                System.Windows.Controls.DataGrid dataGrid = (System.Windows.Controls.DataGrid)sender;
                DataRowView row_selected = dataGrid.SelectedItem as DataRowView;
                if (now_table == "rolee" && row_selected != null)
                {
                    TextBox_Data1.Text = row_selected["Name_Role"].ToString();
                }
                else if (now_table == "employers" && row_selected != null)
                {
                    TextBox_Data1.Text = row_selected["Last_Name"].ToString();
                    TextBox_Data2.Text = row_selected["First_Name"].ToString();
                    TextBox_Data3.Text = row_selected["Middle_Name"].ToString();

                    int selectedRoleeID = Convert.ToInt32(row_selected["Rolee_ID"]);
                    ComboBox_Data1.SelectedItem = FindComboBoxItemByRoleeID(selectedRoleeID);
                }
                else if (now_table == "authorizeyshin" && row_selected != null)
                {
                    TextBox_Data1.Text = row_selected["Login"].ToString();
                    PasswordTbx.Password = row_selected["Password"].ToString();

                    int selectedEmployersID = Convert.ToInt32(row_selected["Employers_ID"]);
                    ComboBox_Data1.SelectedItem = FindComboBoxItemByEmployersID(selectedEmployersID);
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Ошибка: " + ex.Message,
                                            "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private object FindComboBoxItemByRoleeID(int roleeID)
        {
            foreach (var item in ComboBox_Data1.Items)
            {
                DataRowView dataRowView = item as DataRowView;
                if (dataRowView != null && (int)dataRowView["ID_Rolee"] == roleeID)
                {
                    return item;
                }
            }
            return null;
        }
        private object FindComboBoxItemByEmployersID(int employersID)
        {
            foreach (var item in ComboBox_Data1.Items)
            {
                DataRowView dataRowView = item as DataRowView;
                if (dataRowView != null && (int)dataRowView["ID_Employers"] == employersID)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
