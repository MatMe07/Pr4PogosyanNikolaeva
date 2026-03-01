using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Pr4PogosyanNikolaeva.Pages
{
    public partial class _3TaskPage : Page
    {
        public double b = 0, x0 = 0, xk = 0, dx = 0;
        public bool b_znak = false, x0_znak = false, xk_znak = false, dx_znak = false;

        public _3TaskPage()
        {
            InitializeComponent();

            FunctionChart.ChartAreas.Add(new ChartArea("Main"));

            var series = new Series("График функции")
            {
                ChartType = SeriesChartType.Line,
                IsValueShownAsLabel = false
            };

            FunctionChart.Series.Add(series);
        }

        private double CalculateFunction(double x, double b)
        {
            if (Math.Abs(x - b) < 1e-10 || Math.Abs(Math.Pow(b, 3) - Math.Pow(x, 3)) < 1e-10)
                return double.NaN;


            return (Math.Sqrt(Math.Abs(x - b))) 
                / (Math.Pow(Math.Abs(Math.Pow(b, 3) - Math.Pow(x, 3)), 3.0/2.0))
                + Math.Log(Math.Abs(x - b));
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dx <= 0)
                {
                    MessageBox.Show("Шаг должен быть положительным числом!", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (x0 >= xk)
                {
                    MessageBox.Show("Начальное значение должно быть меньше конечного!", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                boxAnswer.Clear();
                FunctionChart.Series[0].Points.Clear();


                for (double x = x0; x <= xk; x += dx)
                {
                    double y = CalculateFunction(x, b);

                    if (!double.IsNaN(y) && !double.IsInfinity(y))
                    {
                        FunctionChart.Series[0].Points.AddXY(x, y);
                        boxAnswer.AppendText($"x = {x:F3}\t y = {y:F6}\r\n");
                    }
                    else
                    {
                        boxAnswer.AppendText($"x = {x:F3}\t y = не определено (разрыв)\r\n");
                    }
                }


                if (FunctionChart.Series[0].Points.Count > 0)
                {
                    FunctionChart.ChartAreas[0].RecalculateAxesScale();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtB.Text = "0";
            txtX0.Text = "0";
            txtXK.Text = "0";
            txtDX.Text = "0";
            boxAnswer.Clear();
            FunctionChart.Series[0].Points.Clear();

            b_znak = false;
            x0_znak = false;
            xk_znak = false;
            dx_znak = false;
        }

        private void TxtBoxB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !CheckInput.Check(e.Text[0], txtB.Text + e.Text[0], out b, ref b_znak);
        }

        private void TxtBoxX0_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !CheckInput.Check(e.Text[0], txtX0.Text + e.Text[0], out x0, ref x0_znak);
        }

        private void TxtBoxXk_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !CheckInput.Check(e.Text[0], txtXK.Text + e.Text[0], out xk, ref xk_znak);
        }

        private void TxtBoxDx_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !CheckInput.Check(e.Text[0], txtDX.Text + e.Text[0], out dx, ref dx_znak);
        }

        private void TxtBoxB_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckInput.CheckNullOrWSpace(sender as TextBox);
        }

      
    }
}
