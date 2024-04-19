using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Encryptor_polybius_square_byShuupa
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
        SolidColorBrush ButtonActive = new SolidColorBrush(Color.FromArgb(255,255,255,255));
        SolidColorBrush ButtonInactive = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
        private void ConditionChanged(double sliderval)
        {
            switch (sliderval)
            {
                case 0:
                    EDPlacement.Content = "TEXT TO DECRYPT";
                    EDConfirmer.Content = "DECRYPTED TEXT";
                    Encryptor_BTN.Background = ButtonInactive;
                    Decryptor_BTN.Background = ButtonActive;
                    Console.Text +=  $" {DateTime.Now.ToString("HH:mm:ss")} | Program condition changed: [C1010]\r\n";
                    Console.ScrollToEnd();
                    break;
                case 1:
                    EDPlacement.Content = "TEXT TO ENCRYPT";
                    EDConfirmer.Content = "ENCRYPTED TEXT";
                    
                    Encryptor_BTN.Background = ButtonActive;
                    Decryptor_BTN.Background = ButtonInactive;
                    Console.Text += $" {DateTime.Now.ToString("HH:mm:ss")} | Program condition changed: [C1011]\r\n";
                    Console.ScrollToEnd();
                    break;
            }
            
        }
        private double sliderval = 2;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sliderval = 0;
            ConditionChanged(sliderval);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            sliderval = 1;
            ConditionChanged(sliderval);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            INFO INFOTABLE = new INFO();
            INFOTABLE.Show();
        }
        private char[,] polybiusSquare = {
            {'A', 'B', 'C', 'D', 'E'},
            {'F', 'G', 'H', 'I', 'K'},
            {'L', 'M', 'N', 'O', 'P'},
            {'Q', 'R', 'S', 'T', 'U'},
            {'V', 'W', 'X', 'Y', 'Z'}
        };
        private string EncryptPolybiusSquare(string input)
        {
            StringBuilder result = new StringBuilder();
            bool containsDigit = false;
            Console.Text += $"\r\n {DateTime.Now.ToString("HH:mm:ss")} (ENCRYPTOR STARTED) [E1010] \r\n";
            Console.Text += $" {DateTime.Now.ToString("HH:mm:ss")} | Task started...\r\n";
            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    containsDigit = true;
                    break;
                }
                if (c == 'J')
                {
                    result.Append("24 ");
                }
                else if (char.IsLetter(c))
                {
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if (polybiusSquare[i, j] == char.ToUpper(c))
                            {
                                result.Append($"{i + 1}{j + 1} ");
                                Console.Text += $" Letter found: {c} Digit defined: {i + 1}{j + 1}  \r\n";
                            }
                        }
                    }
                }
            }
            if (containsDigit)
            {
                Console.Text += $" {DateTime.Now.ToString("HH:mm:ss")} | Task interrupted: Input contains a digit. [C1110]\r\n";
                Console.Text += $" {DateTime.Now.ToString("HH:mm:ss")} (ENCRYPTOR SHUTDOWN) [E1011] \r\n";
                return "";
            }
            Console.Text += $" {DateTime.Now.ToString("HH:mm:ss")} | Task accomplished...\r\n";
            Console.Text += $" {DateTime.Now.ToString("HH:mm:ss")} (ENCRYPTOR SHUTDOWN) [E1011]\r\n";
            return result.ToString().Trim();
        }
        private string DecryptPolybiusSquare(string input)
        {
            StringBuilder result = new StringBuilder();
            string[] pairs = input.Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);
            bool containsLetter = false;
            Console.Text += $"\r\n {DateTime.Now.ToString("HH:mm:ss")} (DECRYPTOR STARTED) [D1010] \r\n";
            Console.Text += $" {DateTime.Now.ToString("HH:mm:ss")} | Task started...\r\n";

            // Проход по парам
            foreach (var pair in pairs)
            {
                if (char.IsDigit(pair[0]) && char.IsDigit(pair[1]) && input != "56")
                {
                    int row = int.Parse(pair[0].ToString()) - 1;
                    int col = int.Parse(pair[1].ToString()) - 1;
                    char decryptedChar = polybiusSquare[row, col];
                    result.Append(decryptedChar);
                    Console.Text += $" Digit found: {row + 1}{col + 1} Letter defined: {decryptedChar} \r\n";
                }
                else
                {
                    containsLetter = true;
                    break;
                }
            }
            if (containsLetter)
            {
                Console.Text += $" {DateTime.Now.ToString("HH:mm:ss")} | Task interrupted: Input contains a letter. [C1110]\r\n";
            }
            else
            {
                Console.Text += $" {DateTime.Now.ToString("HH:mm:ss")} | Task accomplished...\r\n";
            }

            Console.Text += $" {DateTime.Now.ToString("HH:mm:ss")} (DECRYPTOR SHUTDOWN) [D1011]\r\n";

            return result.ToString();
        }
        private void Run_Click(object sender, RoutedEventArgs e)
        {
            string inputText = textUpperED.Text.ToUpper();
            switch (sliderval)
            {
                case 0:
                    Thread.Sleep(millisecondsTimeout: 1);
                    textLowerED.Text = "";
                    string decryptedText = DecryptPolybiusSquare(inputText);
                    textLowerED.Text = decryptedText;
                    Console.ScrollToEnd();
                    break;

                case 1:
                    textLowerED.Text = "";
                    string encryptedText = EncryptPolybiusSquare(inputText);
                    textLowerED.Text = encryptedText;
                    Console.ScrollToEnd();
                    break;
                case 2:
                    Console.Text += $" {DateTime.Now.ToString("HH:mm:ss")} Select an operation. [C1110] \r\n";
                    Console.ScrollToEnd();
                    break;
            }
        }
    }
}
