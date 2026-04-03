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

namespace Pr4PogosyanNikolaeva
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Dictionary<string, double> PrepodStavka {  get; set; }
        public double DoxodSelectPrepod { get; set; } = 0;
        public string PrepodSelct = "ассистент";

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            PrepodStavka = new Dictionary<string, double> { 
                {"ассистент", 150},
                {"доцент", 250},
                {"профессор", 350},
            };

        }



        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == true)
            {
                NalogStack.Visibility = Visibility.Visible;
            }
            else NalogStack.Visibility = Visibility.Hidden;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            //DoxodSelectPrepod = PrepodStavka[(sender as RadioButton).Name];
            PrepodSelct = (sender as RadioButton).Content.ToString();
        }
        /// <summary>
        /// Метод вычисляет зарплату
        /// </summary>
        /// <param name="CountHour">Количество часов</param>
        /// <param name="Prepod">Выбранный преподаватель</param>
        /// <returns>Результат вычисления выражения</returns>
        /// <exception cref="ArgumentException">Количестово часов < 0</exception>
        public double CalculateDoxod(double CountHour, string Prepod)
        {
            if (CountHour < 0)
            {
                throw new ArgumentException("Количестово часов < 0");
            }
            double DohodToHour = PrepodStavka[Prepod];
            return CountHour * DohodToHour;
        }

        /// <summary>
        /// Метод вычисляет подоходный налог
        /// </summary>
        /// <param name="money"></param>
        /// <param name="proc">Процент</param>
        /// <returns>Результат вычисления выражения</returns>
        public double CalculateNalog(double money)
        {
            return money * .13;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(CountHourBox.Text, out double res))
            {
                try
                {
                    double ans = CalculateDoxod(res, PrepodSelct);
                    answer.Text = "Зарплата: " + ans.ToString(format:"f2") + " ₽";
                    NalogText.Text = CalculateNalog(ans).ToString(format: "f2") + "₽";

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    CountHourBox.Focus();

                }
            }
            else
            {
                answer.Text = "Зарплата: 0,00 ₽";
                NalogText.Text = "Зарплата: 0,00 ₽";
                MessageBox.Show("Некорректное значение!");
                CountHourBox.Focus();
            }
        }
    }
}
