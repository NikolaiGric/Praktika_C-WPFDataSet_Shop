using System.Linq;
using System.Text;
using System.Windows;
using Пятерочка.Nachenocka_DeshevoDataSetTableAdapters;
using System.Security.Cryptography;
using System.Data;

namespace Пятерочка
{
    public partial class MainWindow : Window
    {
        AuthorizyshinTableAdapter adapter = new AuthorizyshinTableAdapter();
        EmployersTableAdapter employersAdapter = new EmployersTableAdapter();
        RoleeTableAdapter roleeAdapter = new RoleeTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
            /*Manager manager = new Manager();
            manager.Show();
            Close();*/
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var allogins = adapter.GetData().Rows;

            for (int i = 0; i < allogins.Count; i++)
            {
                if (allogins[i]["Login"].ToString() == LoginTbx.Text &&
                    allogins[i]["Password"].ToString() == ComputeSHA256Hash(PasswordTbx.Password).ToString())
                {
                    int employerId = (int)allogins[i]["Employers_ID"];
                    var employeesData = employersAdapter.GetData();
                    var employeeRow = employeesData.AsEnumerable().FirstOrDefault(row => row.Field<int>("ID_Employers") == employerId);

                    if (employeeRow != null)
                    {
                        int roleId = employeeRow.Field<int>("Rolee_ID");
                        var rolesData = roleeAdapter.GetData();
                        var roleRow = rolesData.AsEnumerable().FirstOrDefault(row => row.Field<int>("ID_Rolee") == roleId);

                        if (roleRow != null)
                        {
                            string role = roleRow.Field<string>("Name_Role");
                            switch (role)
                            {
                                case "Admin":
                                    Admin admin = new Admin();
                                    admin.Show();
                                    Close();
                                    break;
                                case "Manager":
                                    Manager manager = new Manager();
                                    manager.Show();
                                    Close();
                                    break;
                                case "Users":
                                    Users users = new Users();
                                    users.Show();
                                    Close();
                                    break;
                                default:
                                    MessageBox.Show("Неизвестная роль пользователя");
                                    break;
                            }
                        }
                    }
                    return;
                }
            }
            MessageBox.Show("Неправильный Логин или Пароль");
        }
    }
}
