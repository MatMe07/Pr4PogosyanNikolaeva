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
        //public bool x_znak = false, y_znak = false, z_znak = false;

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
                if (Math.Abs(x - y) < 1e-10)
                {
                    MessageBox.Show("Ошибка: деление на ноль (|x-y| = 0)", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (Math.Abs(Math.Cos(z) % Math.PI) < 1e-10)
                {
                    MessageBox.Show("Ошибка: тангенс не определен (cos(z) = 0)", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                res = (Math.Pow(
                    y + Math.Pow(x - 1, (1.0 / 3.0)), (1.0 / 4.0)))
                    /
                    (Math.Abs(x - y) * (
                    Math.Pow(Math.Sin(z), 2)
                    + Math.Tan(z)));
                TxtBoxRes.Text = res.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка вычисления: {ex.Message}");
            }

         

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
            
            //TxtBoxX.Text = x.ToString();
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
