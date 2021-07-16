using System;
using System.Diagnostics;
using System.Windows;

namespace PasswordGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow
    {
        private bool NasNumbers = false;
        private bool NasSymbols = false;
        private int PasswordLenght = 8;


        public MainWindow()
        {
            InitializeComponent();
        }

        // Numbers Checkbox
        private void EnableNumbers(object sender, RoutedEventArgs e)
        {
            EnableNumbersCb.Content = "Numbers: Enabled";
            NasNumbers = true;
        }

        private void DisableNumbers(object sender, RoutedEventArgs e)
        {
            EnableNumbersCb.Content = "Numbers: Disabled";
            NasNumbers = false;
        }
        
        // Symbols Checkbox
        
        private void EnableSymbols(object sender, RoutedEventArgs e)
        {
            EnableSymbolsCb.Content = "Symbols: Enabled";
            NasSymbols = true;
        }

        private void DisableSymbols(object sender, RoutedEventArgs e)
        {
            EnableSymbolsCb.Content = "Symbols: Disabled";
            NasSymbols = false;
        }
        
        // PasswordLenght

        private void LenghtSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int val = (int)LenghtSlider.Value;
            PasswordLenght = val;
            if (val < 10)
            {
                LenghtSliderText.Text = "Password Lenght: 0" + val;
            }
            else
            {
                LenghtSliderText.Text = "Password Lenght: " + val;
            }
        }
        
        // Generate Password

        private void GeneratePassword(object sender, RoutedEventArgs e)
        {
            string chars = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";
            string numbers = "1234567890";
            string symbols = "!@#$%^&*()_+=-";
            string valid = chars;
            string Password = "";
            
            if (NasNumbers)
            {
                valid += numbers;
            }

            if (NasSymbols)
            {
                valid += symbols;
;           }
            
            char[] array = valid.ToCharArray();
            Random rnd = new Random();
            
            for(int i = 0; i < PasswordLenght; i++)
            {
                Password += array[rnd.Next(0, array.Length - 1)];
            }
            
            GenPass.Text = Password;
            GenPass0.Text = "Generated Password:";
        }
    }
}