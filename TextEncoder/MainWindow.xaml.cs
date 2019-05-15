using System;
using System.Diagnostics;
using System.Speech.Synthesis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TextEncoder
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _flag;
        private Morse Morse { get; set; }
        public MainWindow()
        {
            _flag = false;
            InitializeComponent();
            Morse = new Morse();
            Morse.PlayCountSymbol += MorseOnPlayCountSymbol;
            TextOutPut.SelectionStart = 0;
            Ss = new SpeechSynthesizer(){Volume = 100,Rate = 3};
            Ss.SpeakProgress += OnSsOnSpeakProgress;
            Ss.StateChanged += OnSsOnStateChanged;
        }

        private void MorseOnPlayCountSymbol(string s, int i)
        {
            Dispatcher.BeginInvoke(new Action(() => {  TextOutPut.SelectionStart = 0; TextOutPut.SelectionLength = i; }));
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (Decipher.Content == "Зашифровать")
                Dispatcher.Invoke(() => TextOutPut.Text = Morse.ConvertToMorse(TextInput.Text));
            else if (Decipher.Content == "Расшифровать")
                Dispatcher.Invoke(() => TextOutPut.Text = Morse.ConvertToText(TextInput.Text));

        }

        private bool Flag
        {
            get => _flag;
            set
            {
                _flag = value;
                Decipher.IsEnabled = !value;
                ButtonPlay.Content = value ? "Stop" : "Play";
            }
        }

        private async void PlayMorse(object sender, RoutedEventArgs e)
        {
            if (Flag)
            {
                Ss.SpeakAsyncCancelAll();
                Morse.StopMorse();
                Flag = false;
            }
            else
            {
                TextOutPut.Focus();
                Flag = true;
                if (Morse.IsMorse(TextOutPut.Text))
                {
                    await Morse.PlayMorse(TextOutPut.Text).ContinueWith(ex => Dispatcher.Invoke(() => Flag = false));
                }
                else
                {
                    Ss.SpeakAsync(TextOutPut.Text);
                }
            }

        }

        private void OnSsOnStateChanged(object o, StateChangedEventArgs args)
        {
            if (args.State == SynthesizerState.Ready)
            {
                Dispatcher.Invoke(() => Flag = false);
            }
        }

        private void OnSsOnSpeakProgress(object o, SpeakProgressEventArgs args)
        {
            Dispatcher.Invoke(() =>
            {
                TextOutPut.SelectionStart = 0;
                TextOutPut.SelectionLength = args.CharacterPosition + args.CharacterCount;
            });
        }

        public SpeechSynthesizer Ss { get; set; }

        private void TextInput_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            Decipher.Content = Morse.IsMorse(((TextBox)sender).Text) ? "Расшифровать" : "Зашифровать";
            Decipher.IsEnabled = !string.IsNullOrEmpty(((TextBox)sender).Text);
        }

        private void TextInput_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && Decipher.IsEnabled)
                ButtonBase_OnClick(Decipher, null);
        }

        private void TextOutPut_OnTextChanged1(object sender, TextChangedEventArgs e)
        {
            ButtonPlay.IsEnabled = !string.IsNullOrEmpty(((TextBox) sender).Text);
        }

        private void Hyperlink_OnClick(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("http://constalgo.ru"));
        }
    }
}
