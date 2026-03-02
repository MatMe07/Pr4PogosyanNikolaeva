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
    /// Логика взаимодействия для _2TaskPage.xaml
    /// </summary>
    public partial class _2TaskPage : Page
    {

        public double c = 0;
        public double x = 0;
        //public bool x_znak = false;
        public double y = 0;
        //public bool y_znak = false;
        public Func<double, double> func;
        public _2TaskPage()
        {
            InitializeComponent();
            func = Sh;
            boxAnswer.Text = "0";
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            boxAnswer.Text = "0";
            txtX.Text = "0";
            txtY.Text = "0";
            

        }

        public double Sh(double n)
        {
            return Math.Sinh(n);
        }

        public double X2(double n)
        {
            return Math.Pow(n, 2);
        }

        public double EX(double n)
        {
            return Math.Exp(n);
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                x = double.Parse(txtX.Text);
                y = double.Parse(txtY.Text);
            }
            catch { }
            if (x - y == 0)
            {
                c = Math.Pow( func(x), 2) + Math.Pow( y, 2) + Math.Sin(y);
            }
            else if (x - y > 0)
            {
                c = Math.Pow( func(x) - y, 2) + Math.Cos(y);

            }
            else
            {
                c = Math.Pow( y - func(x), 2) + Math.Tan(y);
            }
            boxAnswer.Text = c.ToString();
        }

        private void txtX_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckInput.CheckNullOrWSpace(txtX);

        }

        private void txtX_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !CheckInput.Check(e.Text[0], txtX.Text, out x);
        }

        private void txtY_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckInput.CheckNullOrWSpace(txtY);

        }

        private void txtY_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !CheckInput.Check(e.Text[0], txtY.Text, out y);

        }

        private void rad1_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            switch (radio.Content.ToString())
            {
                case "sh(x)":
                    {
                        func = Sh;
                        break;
                    }
                case "x^2":
                    {
                        func = X2;
                        break;
                    }
                case "e^x":
                    {
                        func = EX;
                        break;
                    }
            }
        }
    }
}
