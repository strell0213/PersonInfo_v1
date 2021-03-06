using System;
using System.Collections.Generic;
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

namespace WpfApp24
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {
        Person cd = new Person();
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < cd.ID.Length; i++) {
                IdPersonBox.Items.Add(i);
            }

        }
        string FIOmain = "";
        float telemain = 0;
        string snilsmain = "";
        string emailmain = ""; 

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

            FIOmain = FIOText.Text.ToString();
            telemain = float.Parse(TeleText.Text.ToString());
            snilsmain = SnilsText.Text.ToString();
            emailmain = EmailText.Text.ToString();
                for (int i = 0; i < cd.ID.Length; i++)
                {
                    if (IdPersonBox.SelectedIndex == i)
                    {
                        EmailText.Text.ToLower();
                        string[] FIO1 = FIOmain.Split(' ');
                        string[] email1 = emailmain.Split('@');
                        //fio
                        if (FIO1.Length != 3)
                        {
                            MessageBox.Show("Вы некорректно ввели ФИО.\nПопробуйте еще раз", "PersonInfo v1", MessageBoxButton.OK, MessageBoxImage.Error);
                            cd.snils[i] = "";
                            cd.Tele[i] = 0;
                            cd.EMAIL[i] = "";
                        }
                        else
                        {
                            cd.FIO[i] = FIOmain;
                        }
                        //email
                        if (email1.Length == 1 && EmailText.Text.Contains("com") || EmailText.Text.Contains("ru") || EmailText.Text.Contains("net") || EmailText.Text.Contains("uk") || EmailText.Text.Contains("co") || EmailText.Text.Contains("рф"))
                        {
                            cd.EMAIL[i] = emailmain;
                        }
                        else
                        {
                            MessageBox.Show("Вы некорректно ввели Email.\nПопробуйте еще раз", "PersonInfo v1", MessageBoxButton.OK, MessageBoxImage.Error);
                            cd.snils[i] = "";
                            cd.Tele[i] = 0;
                            cd.FIO[i] = "";
                        }
                        //tele
                        if (TeleText.Text.Length == 11)
                        {
                            cd.Tele[i] = telemain;
                        }
                        else
                        {
                            MessageBox.Show("Вы некорректно ввели телефонный номер.\nПопробуйте еще раз", "PersonInfo v1", MessageBoxButton.OK, MessageBoxImage.Error);
                            cd.snils[i] = "";
                            cd.FIO[i] = "";
                            cd.EMAIL[i] = "";
                        }
                        //snils
                        if (SnilsText.Text.Length == 11)
                        {
                            cd.snils[i] = snilsmain;
                        }
                        else {
                            MessageBox.Show("Вы некорректно ввели снилс.\nПопробуйте еще раз", "PersonInfo v1", MessageBoxButton.OK, MessageBoxImage.Error);
                            cd.Tele[i] = 0;
                            cd.FIO[i] = "";
                            cd.EMAIL[i] = "";

                        }
                        MessageBox.Show("Данные успешно добавлены", "PersonInfo v1", MessageBoxButton.OK, MessageBoxImage.Information);
                        
                    }
                }
            
            
        }

        private void ViewButton_Click(object sender, RoutedEventArgs e)
        {
            ListPerson.Items.Clear();
            for (int i = 0; i < cd.ID.Length; i++) {
                    ListPerson.Items.Add($"{i}.{cd.FIO[i]}");
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            ListPerson.Items.Clear();
            try
            {
                for (int i = 0; i < cd.ID.Length; i++)
                {
                    if (cd.FIO[i].Contains(SearchText.Text) || cd.EMAIL[i].Contains(SearchText.Text) || cd.snils[i].Contains(SearchText.Text) || Convert.ToString(cd.Tele[i]).Contains(SearchText.Text))
                    {
                        ListPerson.Items.Add($"Результаты поиска: \n{cd.FIO[i]}");
                    }
                }
            }
            catch
            {

            }
        }





        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены что хотите удалить данный элемент?", "PersonInfo v1", MessageBoxButton.YesNo, MessageBoxImage.Question);
            
            if (result == MessageBoxResult.Yes)
            {
                string ds = Convert.ToString(ListPerson.SelectedItem);
                for (int i = 0; i < cd.ID.Length; i++)
                {
                    if (ds.Contains(Convert.ToString(i)))
                    {
                        cd.FIO[i] = "";
                        cd.EMAIL[i] = "";
                        cd.snils[i] = "";
                        cd.Tele[i] = 0;
                        ListPerson.SelectedItem = "Удалено";
                    }
                }
                ListPerson.Items.Clear();
                for (int i = 0; i < cd.ID.Length; i++)
                {
                    ListPerson.Items.Add($"{i}.{cd.FIO[i]}");
                }
            }
            else if (result == MessageBoxResult.No) { }

        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
