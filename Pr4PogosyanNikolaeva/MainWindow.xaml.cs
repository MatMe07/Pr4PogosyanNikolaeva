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
        private string operation = "+";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            operation = rb.Content as string;

        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
           
            if(!double.TryParse(TxtBoxOp1.Text, out double op1) || !double.TryParse(TxtBoxOp2.Text, out double op2))
            {
                MessageBox.Show("Введите корректные данные");
            }
            else
            {
                try
                {
                    double res = Calculate(op1, op2, operation);
                    TxtBoxRes.Text = res.ToString();

                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        /// <summary>
        /// Функция расчета
        /// </summary>
        /// <param name="op1"> Первый операнд </param>
        /// <param name="op2"> Второй операнд </param>
        /// <param name="operat">Операция </param>
        /// <returns> Вычисленное значение </returns>
        /// <exception cref="DivideByZeroException"> Исключение при делении на ноль </exception>
        public double Calculate(double op1, double op2, string operat) {
            if (operat == "+")
            {
                return op1 + op2;
            }
            else if (operat == "-")
            {
                return op1 - op2;
            }
            else if (operat == "*")
            {
                return op1 * op2;
            }

            else
            {
                if(op2 == 0)
                {
                    throw new DivideByZeroException("Нельзя делить на ноль");
                }
                else
                {
                    return op1 / op2;
                }
            }
        }
    }
}
