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
    /// <summary>
    /// Логика взаимодействия для _3TaskPage.xaml
    /// </summary>
    public partial class _3TaskPage : Page
    {
        public double x = 0;
        public bool x_znak = false;
        public _3TaskPage()
        {
            InitializeComponent();
            ChartPayments.ChartAreas.Add(new ChartArea("Main"));

            var currentSeries = new Series("Series1")
            {
                IsValueShownAsLabel = true
            };
            ChartPayments.Series.Add(currentSeries);

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            boxAnswer.Text = "0";

        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtX_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !CheckInput.Check(e.Text[0], txtB.Text + e.Text[0], out x, ref x_znak);


        }

        private void txtX_TextChanged(object sender, TextChangedEventArgs e)
        {

            CheckInput.CheckNullOrWSpace(txtB);
        }


        private void UpdateChart(object sender, SelectionChangedEventArgs e)
        {
            Series currentSeries = ChartPayments.Series.FirstOrDefault();
        }

    }
}
