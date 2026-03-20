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

        

        /// <summary>
        /// Метод вычисляет значение функции
        /// </summary>
        /// <param name="x">Значение переменной x</param>
        /// <param name="b">Значение параметра b</param>
        /// <returns></returns>
        public double CalculateFunction(double x, double bb)
        {
            if (Math.Abs(x - bb) < 1e-10 || Math.Abs(Math.Pow(bb, 3) - Math.Pow(x, 3)) < 1e-10)
                return double.NaN;

            return (Math.Sqrt(Math.Abs(x - bb)))
                / (Math.Pow(Math.Abs(Math.Pow(bb, 3) - Math.Pow(x, 3)), 3.0 / 2.0))
                + Math.Log(Math.Abs(x - bb));
        }

        /// <summary>
        /// Метод вычисляет значения точек графика 
        /// </summary>
        /// <param name="x0"> Начальное значение x</param>
        /// <param name="xk"> Конечное значение x</param>
        /// <param name="dx">Шаг dx</param>
        /// <param name="b"> Параметр b</param>
        /// <returns> Список значений x, y </returns>
        public List<(double x, double y, bool isValid)> TabulateFunction(double xx0, double xxk, double dxx, double bb)
        {
            var results = new List<(double x, double y, bool isValid)>();

            for (double x = xx0; x <= xxk + dxx / 2; x += dxx)
            {
                double y = CalculateFunction(x, bb);
                bool isValid = !double.IsNaN(y) && !double.IsInfinity(y);
                results.Add((x, y, isValid));
            }

            return results;
        }

     
        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                b = double.Parse(txtB.Text);
                dx = double.Parse(txtDX.Text);
                x0 = double.Parse(txtX0.Text);
                xk = double.Parse(txtXK.Text);
            }
            catch
            { }

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

                var points = TabulateFunction(x0, xk, dx, b);

                boxAnswer.Clear();
                FunctionChart.Series[0].Points.Clear();

                for (int i = 0; i < points.Count; i++)
                {
                    if (points[i].isValid)
                    {
                        FunctionChart.Series[0].Points.AddXY(points[i].x, points[i].y);
                        boxAnswer.AppendText($"x{i} = {points[i].x:F3}\t y{i} = {points[i].y:F6}\r\n");
                    }
                    else
                    {
                        boxAnswer.AppendText($"x{i} = {points[i].x:F3}\t y{i} = не определено (разрыв)\r\n");
                    }
                }

                if (FunctionChart.Series[0].Points.Count > 0)
                {
                    FunctionChart.ChartAreas[0].RecalculateAxesScale();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка вычисления: {ex.Message}", "Ошибка",
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
            b = 0;
            x0 = 0;
            xk = 0;
            dx = 0;

        }

        private void TxtBoxB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !CheckInput.Check(e.Text[0], txtB.Text, out b);
        }

        private void TxtBoxX0_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !CheckInput.Check(e.Text[0], txtX0.Text, out x0);
        }

        private void TxtBoxXk_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !CheckInput.Check(e.Text[0], txtXK.Text , out xk);
        }

        private void TxtBoxDx_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !CheckInput.Check(e.Text[0], txtDX.Text, out dx);
        }

        private void TxtBoxB_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckInput.CheckNullOrWSpace(sender as TextBox);
        }

      
    }
}
