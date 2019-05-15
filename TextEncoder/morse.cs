using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace TextEncoder
{
    public class Morse
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool Beep(int frequency, int duration);

        public const string А = ".-";
        public const string Б = "-...";
        public const string В = ".--";
        public const string Г = "--.";
        public const string Д = "-..";
        public const string Е = ".";
        public const string Ж = "...-";
        public const string З = "--..";
        public const string И = "..";
        public const string Й = ".---";
        public const string К = "-.-";
        public const string Л = ".-..";
        public const string М = "--";
        public const string Н = "-.";
        public const string О = "---";
        public const string П = ".--.";
        public const string Р = ".-.";
        public const string С = "...";
        public const string Т = "-";
        public const string У = "..-";
        public const string Ф = "..-.";
        public const string Х = "....";
        public const string Ц = "-.-.";
        public const string Ч = "---.";
        public const string Ш = "----";
        public const string Щ = "--.-";
        public const string Ъ = ".--.-.";
        public const string Ы = "-.--";
        public const string Ь = "-..-";
        public const string Э = "..-..";
        public const string Ю = "..--";
        public const string Я = ".-.-";


        public const string Num0 = "-----";
        public const string Num1 = ".----";
        public const string Num2 = "..---";
        public const string Num3 = "...--";
        public const string Num4 = "....-";
        public const string Num5 = ".....";
        public const string Num6 = "-....";
        public const string Num7 = "--...";
        public const string Num8 = "---..";
        public const string Num9 = "----.";

        /// <summary>
        /// точка
        /// </summary>
        public const string Point = "......";
        /// <summary>
        /// запятая
        /// </summary>
        public const string Comma = ".-.-.-";
        /// <summary>
        /// двоеточие
        /// </summary>
        public const string Colon = "---...";
        /// <summary>
        /// точка с запятой
        /// </summary>
        public const string Semicolon = "-.-.-.";
        /// <summary>
        /// левая круглая скобка
        /// </summary>
        public const string Leftparenthesis = "-.--.-";
        /// <summary>
        /// правая круглая скобка
        /// </summary>
        public const string Rightparenthesis = "-.--.-";
        /// <summary>
        /// апостроф
        /// </summary>
        public const string Apostrophe = ".----.";
        /// <summary>
        /// кавычки
        /// </summary>
        public const string Quotes = ".-..-.";
        /// <summary>
        /// тире
        /// </summary>
        public const string Dash = "-....-";
        /// <summary>
        /// косая черта
        /// </summary>
        public const string Slash = "-..-.";
        /// <summary>
        /// знак вопроса
        /// </summary>
        public const string Questionmark = "..--..";
        /// <summary>
        /// восклицательный знак
        /// </summary>
        public const string Exclamationmark = "--..--";

        public string ConvertToMorse(string text)
        {
            string morse = String.Empty;

            var num = text.ToLower().ToCharArray().GetEnumerator();
            while (num.MoveNext())
            {

                if (num.Current != null)
                    switch ((char)num.Current)
                    {
                        case 'а':
                            morse += А;
                            break;
                        case 'б':
                            morse += Б;
                            break;
                        case 'в':
                            morse += В;
                            break;
                        case 'г':
                            morse += Г;
                            break;
                        case 'д':
                            morse += Д;
                            break;
                        case 'е':
                            morse += Е;
                            break;
                        case 'ж':
                            morse += Ж;
                            break;
                        case 'з':
                            morse += З;
                            break;
                        case 'и':
                            morse += И;
                            break;
                        case 'й':
                            morse += Й;
                            break;
                        case 'к':
                            morse += К;
                            break;
                        case 'л':
                            morse += Л;
                            break;
                        case 'м':
                            morse += М;
                            break;
                        case 'н':
                            morse += Н;
                            break;
                        case 'о':
                            morse += О;
                            break;
                        case 'п':
                            morse += П;
                            break;
                        case 'р':
                            morse += Р;
                            break;
                        case 'с':
                            morse += С;
                            break;
                        case 'т':
                            morse += Т;
                            break;
                        case 'у':
                            morse += У;
                            break;
                        case 'ф':
                            morse += Ф;
                            break;
                        case 'х':
                            morse += Х;
                            break;
                        case 'ц':
                            morse += Ц;
                            break;
                        case 'ч':
                            morse += Ч;
                            break;
                        case 'ш':
                            morse += Ш;
                            break;
                        case 'щ':
                            morse += Щ;
                            break;
                        case 'ъ':
                            morse += Ъ;
                            break;
                        case 'ы':
                            morse += Ы;
                            break;
                        case 'ь':
                            morse += Ь;
                            break;
                        case 'э':
                            morse += Э;
                            break;
                        case 'ю':
                            morse += Ю;
                            break;
                        case 'я':
                            morse += Я;
                            break;


                        case '0':
                            morse += Num0;
                            break;
                        case '1':
                            morse += Num1;
                            break;
                        case '2':
                            morse += Num2;
                            break;
                        case '3':
                            morse += Num3;
                            break;
                        case '4':
                            morse += Num4;
                            break;
                        case '5':
                            morse += Num5;
                            break;
                        case '6':
                            morse += Num6;
                            break;
                        case '7':
                            morse += Num7;
                            break;
                        case '8':
                            morse += Num8;
                            break;
                        case '9':
                            morse += Num9;
                            break;


                        case '.':
                            morse += Point;
                            break;
                        case ',':
                            morse += Comma;
                            break;
                        case ':':
                            morse += Colon;
                            break;
                        case ';':
                            morse += Semicolon;
                            break;
                        case '(':
                            morse += Leftparenthesis;
                            break;
                        case ')':
                            morse += Rightparenthesis;
                            break;
                        case '\'':
                            morse += Apostrophe;
                            break;
                        case '"':
                            morse += Quotes;
                            break;
                        case '-':
                            morse += Dash;
                            break;
                        case '—':
                            morse += Dash;
                            break;
                        case '–':
                            morse += Dash;
                            break;
                        case '/':
                            morse += Slash;
                            break;
                        case '\\':
                            morse += Slash;
                            break;
                        case '?':
                            morse += Questionmark;
                            break;
                        case '!':
                            morse += Exclamationmark;
                            break;

                        case ' ':
                            morse += " ";
                            break;
                    }
                morse += " ";
            }

            return morse;
        }

        public string GetSymbol(string cod)
        {
            var consts = this.GetType().GetFields().FirstOrDefault(f=>(string) f.GetValue(this) == cod)?.Name;
            switch (consts)
            {
                case "Num0":
                    return "0";
                case "Num1":
                    return "1";
                case "Num2":
                    return "2";
                case "Num3":
                    return "3";
                case "Num4":
                    return "4";
                case "Num5":
                    return "5";
                case "Num6":
                    return "6";
                case "Num7":
                    return "7";
                case "Num8":
                    return "8";
                case "Num9":
                    return "9";


                case "Point":
                    return ".";
                case "Comma":
                    return ",";
                case "Colon":
                    return ":";
                case "Semicolon":
                    return ";";
                case "Leftparenthesis":
                case "Rightparenthesis":
                    return "()";
                case "Apostrophe":
                    return "'";
                case "Quotes":
                    return "\"";
                case "Dash":
                    return "-";
                case "Slash":
                    return "/";
                case "Questionmark":
                    return "?";
                case "Exclamationmark":
                    return "!";




                default:
                    return consts;

            }
        }
        public string ConvertToText(string text)
        {
            string textOut = String.Empty;
            string symbol = string.Empty;
            var num = text.ToCharArray().GetEnumerator();

            while (num.MoveNext())
            {
                if (num.Current == null) continue;
                switch (num.Current)
                {
                    case '-':
                        symbol += "-";
                        break;
                    case '.':
                        symbol += ".";
                        break;
                    case ' ':
                        if (symbol == String.Empty)
                        {
                            textOut += " ";
                            break;
                        }
                        textOut += GetSymbol(symbol);
                        symbol = String.Empty;
                        break;
                }
            }

            return textOut.ToLower();
        }
        private CancellationTokenSource cancelTokenSource;
        public event Action<string, int> PlayCountSymbol;
        public async Task PlayMorse(string textMorse)
        {
            cancelTokenSource = new CancellationTokenSource();
            await Task.Factory.StartNew(() =>
            {
                if (!IsMorse(textMorse))
                    throw new Exception("Код морзе содержит ошибки.");
                var num = textMorse.ToCharArray().GetEnumerator();
                int count = 1;
                while (num.MoveNext())
                {
                    if (num.Current == null) continue;
                    OnPlayCountSymbol(textMorse, count);
                    switch (num.Current)
                    {
                        case '-':
                            Beep(1000, 200);
                            break;
                        case '.':
                            Beep(1000, 100);
                            break;
                        case ' ':
                            Thread.Sleep(100);
                            break;
                    }

                    if (cancelTokenSource.Token.IsCancellationRequested)
                        return;
                    count++;
                }
            }).ContinueWith(e=>
            {
                cancelTokenSource.Dispose();
                cancelTokenSource = null;
                if (e.Exception != null)
                {
                    MessageBox.Show(e.Exception.InnerException.Message, "Ошибка");
                }
            });
        }

        public void StopMorse()
        {
            cancelTokenSource?.Cancel();
        }
        public static bool IsMorse(string s)
        {
            var en = s.GetEnumerator();
            while (en.MoveNext())
            {
                if (en.Current != ' ' && en.Current != '.' && en.Current != '-')
                    return false;
            }
            return true;
        }

        protected virtual void OnPlayCountSymbol(string arg1, int arg2)
        {
            PlayCountSymbol?.Invoke(arg1, arg2);
        }
    }
}
