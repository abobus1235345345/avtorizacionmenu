using System;

using System.IO;
using System.Linq;

using System.Windows;


namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            //Получаем текст из элементов управления  
            string name = Name.Text;
            string surname = Surname.Text;
            //Проверяет, пустые ли строки `name` или `surname
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname))
            {
                MessageBox.Show("Введите имя и фамилию.");
                return;
            }
            //Вызывает метод `GetUserRole`, передавая ему имя и фамилию, и сохраняет результат
            string role = GetUserRole(name, surname);
            //вызов окна
            Window window = GetWindow(role);
            //Проверяет, вернул ли метод `GetWindow` непустой объект окна. если да то.Show
            if (window != null)
            {
                window.Show();
            }
            //если неверно
            else

            {
                MessageBox.Show("Пользователь не найден.");
            }
        }

        private string GetUserRole(string name, string surname)
        {
            return File.ReadLines("Employees.txt")//открывает файл
                       .Select(line => line.Split(' '))//Разбивает каждую строку на массив подстрок, используя пробел (' ') в качестве разделителя
                       .FirstOrDefault(parts => parts[0] == name && parts[1] == surname)?[2];//находит 1 и 2 элемент в файле
        }

        private Window GetWindow(string role)//выбирает роли
        {
            switch (role)//выбирает один из вариантов
            {
                case "User":
                    return new UserWindow();
                case "Admin":
                    return new AdminWindow();
                default:
                    return null;
            }
        }
    }
}







