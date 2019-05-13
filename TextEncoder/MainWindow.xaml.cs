using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Speech.Synthesis;
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

namespace TextEncoder
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Morse Morse { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Morse = new Morse();
            Morse.PlayCountSymbol += MorseOnPlayCountSymbol;
            TextOutPut.SelectionStart = 0;

        }

        private void MorseOnPlayCountSymbol(string s, int i)
        {
            Dispatcher.Invoke(() =>
            {
                TextOutPut.Focus(); TextOutPut.SelectionStart = 0; TextOutPut.SelectionLength = i; });
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Name == "Encrypt")
                Dispatcher.Invoke(() => TextOutPut.Text = Morse.ConvertToMorse(TextInput.Text));
            else if (((Button)sender).Name == "Decipher")
                Dispatcher.Invoke(() => TextOutPut.Text = Morse.ConvertToText(TextInput.Text));

        }

        private async void PlayMorse(object sender, RoutedEventArgs e)
        {
            ButtonPlay.IsEnabled = false;
            if (Morse.IsMorse(TextOutPut.Text))
            {
                await Morse.PlayMorse(TextOutPut.Text).ContinueWith(ex =>
                {
                    Dispatcher.Invoke(() => ButtonPlay.IsEnabled = true);
                });
            }
            else
            {
                Ss = new SpeechSynthesizer
                {
                    Volume = 100,
                    Rate = 3
                };
                Ss.SpeakProgress += (o, args) => { Dispatcher.Invoke(() =>
                {
                    TextOutPut.Focus();
                    TextOutPut.SelectionStart = 0; TextOutPut.SelectionLength = args.CharacterPosition + args.CharacterCount;
                });};
                Ss.StateChanged += (o, args) => {
                    if (args.State == SynthesizerState.Ready)
                    {
                        Dispatcher.Invoke(() => ButtonPlay.IsEnabled = true);
                        Ss.Dispose();
                    }
                };
                Ss.SpeakAsync(TextOutPut.Text);
            }

        }

        public SpeechSynthesizer Ss { get; set; }

        private void TextInput_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if(string.IsNullOrEmpty(((TextBox)sender).Text))
            {
                Decipher.IsEnabled = Encrypt.IsEnabled = false;
                return;
            }
            Decipher.IsEnabled = Morse.IsMorse(((TextBox)sender).Text);
            Encrypt.IsEnabled = !Decipher.IsEnabled;
        }

        private void TextInput_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && Decipher.IsEnabled)
                ButtonBase_OnClick(Decipher, null);
            else if (e.Key == Key.Enter && Encrypt.IsEnabled)
                ButtonBase_OnClick(Encrypt, null);

        }

        private void TextOutPut_OnTextChanged1(object sender, TextChangedEventArgs e)
        {
            ButtonPlay.IsEnabled = !string.IsNullOrEmpty(((TextBox) sender).Text);
        }

        private async void StopMorse(object sender, RoutedEventArgs e)
        {
            Ss?.Dispose();
            Morse.StopMorse();
        }
    }
}
