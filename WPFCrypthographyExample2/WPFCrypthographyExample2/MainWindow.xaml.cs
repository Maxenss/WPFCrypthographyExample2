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

namespace WPFCrypthographyExample2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btDecode_Click(object sender, RoutedEventArgs e)
        {
            string encodedWord = tbDecodeStartWord.Text;
            string keyWord = tbDecodeKey.Text;
            

            if (encodedWord.Equals(""))
            {
                MessageBox.Show("Некорректное значение слова.", "Ошибка");
                return;
            }

            if (keyWord.Equals(""))
            {
                MessageBox.Show("Некорректное значение ключа.", "Ошибка");
                return;
            }

            if (encodedWord.Length != keyWord.Length)
            {
                MessageBox.Show("Ключ и слово должны быть одной длины", "Ошибка");
                return;
            }

            tbDecodeResult.Text = Cryptograghy.Decode(encodedWord.ToLower(), keyWord.ToLower());
        }

        private void btEncode_Click(object sender, RoutedEventArgs e)
        {
            string word = tbEncodeStartWord.Text;
            string keyWord = tbEncodeKey.Text;


            if (word.Equals(""))
            {
                MessageBox.Show("Некорректное значение слова.", "Ошибка");
                return;
            }

            if (keyWord.Equals(""))
            {
                MessageBox.Show("Некорректное значение ключа.", "Ошибка");
                return;
            }

            if (word.Length != keyWord.Length) {
                MessageBox.Show("Ключ и слово должны быть одной длины", "Ошибка");
                return;
            }

            tbEncodeResult.Text = Cryptograghy.Encode(word.ToLower(), keyWord.ToLower());
        }
    }
}
