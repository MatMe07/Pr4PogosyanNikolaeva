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
using static System.Net.Mime.MediaTypeNames;

namespace Pr4PogosyanNikolaeva
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Func<string, int, int, string> FuncEncDecr { get; set; }
        public int Row { get; set; } = 1;
        public int Col { get; set; } = 1;
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
        }

        private void ValidateInputs()
        {
            bool isTextValid = !string.IsNullOrWhiteSpace(txtInput?.Text);
            bool isRowsValid = !string.IsNullOrWhiteSpace(txtRows?.Text);
            bool isColsValid = !string.IsNullOrWhiteSpace(txtCols?.Text);

            if (btnExecute != null)
                btnExecute.IsEnabled = isTextValid && isRowsValid && isColsValid;
        }

        private void txtInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidateInputs();
        }

        private void txtRowsCol_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out int n);

        }

        private void txtRowsColum_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidateInputs();
            var txtBox = (TextBox)sender;
            
            if (string.IsNullOrWhiteSpace(txtBox?.Text))
            {
                txtBox.Text = "1";
                txtBox.SelectionLength = 1;
            }
            else
            {
                txtBox.Text = txtBox.Text.TrimEnd();
                txtBox.CaretIndex = txtBox.Text.Length;
            }
        }
        /// <summary>
        /// Шифрует текст методом матричной перестановки
        /// </summary>
        /// <param name="text">Исходный текст для шифрования</param>
        /// <param name="row">Количество строк матрицы</param>
        /// <param name="col">Количество столбцов матрицы</param>
        /// <returns>Зашифрованная строка</returns>
        public string Encrypt(string text, int row, int col)
        {
            int matrSize = row * col;
            text = text.PadRight(matrSize);
            string Cipher = "";
            for (int j = 0; j < col; j++)
            {
                for (int i = 0; i < row; i++)
                {
                    Cipher += text[i * col + j];
                }
            }
            return Cipher;
        }
        /// <summary>
        /// Дешифрует текст
        /// </summary>
        /// <param name="text">Зашифрованный текст</param>
        /// <param name="row">Количество строк матрицы</param>
        /// <param name="col">Количество столбцов матрицы</param>
        /// <returns>Расшифрованная строка</returns>
        public string Decrypt(string text, int row, int col)
        {
            int matrSize = row * col;
            text = text.PadRight(matrSize);
            string Cipher = "";
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Cipher += text[j * row + i];
                }
            }
            return Cipher.TrimStart(' ').TrimEnd(' ');
        }

        /// <summary>
        /// Выполняет шифрование или дешифрование с предварительной валидацией входных параметров
        /// </summary>
        /// <param name="text">Входной текст</param>
        /// <param name="row">Количество строк матрицы (должно быть > 0)</param>
        /// <param name="col">Количество столбцов матрицы (должно быть > 0)</param>
        /// <param name="func">Функция шифрования или дешифрования</param>
        /// <returns>Результат шифрования или дешифрования</returns>
        /// <exception cref="ArgumentException">Выбрасывается при row <= 0, col <= 0 или если размер матрицы меньше длины текста</exception>
        public string MatrixCipher(string text, int row, int col, Func<string, int, int, string> func)
        {
            if (row <= 0)
                throw new ArgumentException("Количество строк должно быть больше 0", nameof(row));

            if (col <= 0)
                throw new ArgumentException("Количество столбцов должно быть больше 0", nameof(col));

            int matrixSize = row * col;
            if (matrixSize < text.Length)
                throw new ArgumentException(
                    $"Размер матрицы ({row}*{col} = {matrixSize}) меньше длины текста ({text.Length} символов). ");

            string Cipher = func(text, row, col);
            return Cipher;
        }

        private void rbEncryptDecrtypt_Checked(object sender, RoutedEventArgs e)
        {
            switch((sender  as RadioButton).Content)
            {
                case "Шифровать":
                    {
                        FuncEncDecr = Encrypt;
                        break;
                    }
                case "Дешифровать":
                    {
                        FuncEncDecr = Decrypt;
                        break;
                    }
            } 
        }



        private void btnExecute_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string encrypted = MatrixCipher(txtInput.Text, Row, Col, FuncEncDecr);
                txtResult.Text = encrypted;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка валидации", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неизвестная ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtRows.Text = "1";
            txtCols.Text = "1";
            txtInput.Text = "";
            txtResult.Text = "";
        }
    }
}
