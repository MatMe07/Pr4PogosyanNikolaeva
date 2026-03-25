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

namespace Pr4PogosyanNikolaeva.Pages
{
    /// <summary>
    /// Логика взаимодействия для _1TaskPage.xaml
    /// </summary>
    public partial class _1TaskPage : Page
    {
        public double x = 0, y = 0, z = 0, res = 0;

        public _1TaskPage()
        {
            InitializeComponent();
        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                x = double.Parse(TxtBoxX.Text);
                y = double.Parse(TxtBoxY.Text);
                z = double.Parse(TxtBoxZ.Text);
            }
            catch { }
            try
            {               
                res = Calculate(x, y, z);
                TxtBoxRes.Text = res.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка вычисления: {ex.Message}");
            }

            TxtBoxRes.Text = res.ToString();

        }


        /// <summary>
        /// Метод выполняет расчет функции по введенным x, y, z
        /// </summary>
        /// <param name="xx">Значение переменной x </param>
        /// <param name="yy">Значение переменной y </param>
        /// <param name="zz">Значение переменной z </param>
        /// <returns>Результат вычисления выражения</returns>
        public double Calculate(double xx,  double yy, double zz)
        {
            
            if (Math.Abs(xx - yy) < 1e-10)
            {
                throw new DivideByZeroException("Деление на ноль (|x-y| = 0)");
            }
            if (Math.Abs(Math.Cos(zz) % Math.PI) < 1e-10)
            {
                throw new ArgumentException("Тангенс не определен (cos(z) = 0)");
            }

            double ress = (Math.Pow(
                yy + Math.Pow(xx - 1, (1.0 / 3.0)), (1.0 / 4.0)))
                /
                (Math.Abs(xx - yy) * (
                Math.Pow(Math.Sin(zz), 2)
                + Math.Tan(zz)));

            return ress;
           
        }

        

        private void TxtBoxX_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckInput.CheckNullOrWSpace(sender as TextBox);

        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            TxtBoxX.Text = "0";
            TxtBoxY.Text = "0";
            TxtBoxZ.Text = "0";
            TxtBoxRes.Text = "0";
            x = 0;
            y = 0;
            z = 0;
            res = 0;


        }

        private void TxtBoxX_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !CheckInput.Check(e.Text[0], TxtBoxX.Text, out x);
            
        }

        private void TxtBoxY_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !CheckInput.Check(e.Text[0], TxtBoxY.Text, out y);
        }

        private void TxtBoxZ_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !CheckInput.Check(e.Text[0], TxtBoxZ.Text, out z);
        }
    }
}
