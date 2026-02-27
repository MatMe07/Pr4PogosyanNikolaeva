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

        public double x = 0;
        public bool x_znak = false;
        public double y = 0;
        public bool y_znak = false;
        public _2TaskPage()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            
            boxAnswer.Text = "";
        }

        private void txtX_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckInput.CheckNullOrWSpace(txtX);

        }

        private void txtX_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !CheckInput.Check(e.Text[0], txtX.Text + e.Text[0], out x, ref x_znak);
        }

        private void txtY_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckInput.CheckNullOrWSpace(txtY);

        }

        private void txtY_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !CheckInput.Check(e.Text[0], txtY.Text + e.Text[0], out y, ref y_znak);

        }
    }
}
