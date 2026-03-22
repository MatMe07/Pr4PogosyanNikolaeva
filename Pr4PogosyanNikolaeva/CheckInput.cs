using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;

namespace Pr4PogosyanNikolaeva
{
    public static class CheckInput
    {

        static public bool Check(char simv, string num, out double n, string inputText = "")
        {
            n = 0;

            string newText = num + simv.ToString();

            if (inputText.Contains(",") && newText.Count(c => c == ',') > 1)
                return false;

            if (simv == '.') return false;
            //if (simv == '.') newText += "0";
            //Math.

            if (simv == '-')
            {
                return true;
                //return selectionInd != num.Length-1;
            }

            return double.TryParse(newText, out n);
        }


        static public void CheckNullOrWSpace(TextBox textBox)
        {
            if (textBox != null)
            {

                string text = "";
                int selectionInd = textBox.SelectionStart;

                foreach (char c in textBox.Text)
                {
                    if (char.IsDigit(c)  || c == ',' || c=='-')
                    {
                        text += c;
                    }
                }

                text = text.Replace(" ", "");

                if (string.IsNullOrEmpty(text))
                {

                    textBox.Text = "0";
                    textBox.Select(1, 0);
                    return;
                }

                if (text == "-")
                {
                    textBox.Text = "-";
                    textBox.Select(1, 0);
                    return;
                }

                else if (text.Count(s => s == '-') > 1)
                    text = text.Replace("-", "");
                else if (text.Count(s => s == '-') == 1 || text.EndsWith("-"))
                {
                    //znak = true;
                    //selectionInd = text.LastIndexOf('-')+1;
                    text = text.Replace("-", "");
                    text = "-" + text;
                }



                if (text.Length > 1 && text[0] == '0' && text[1] != ',')
                {
                    text = text.TrimStart('0');
                    if (string.IsNullOrEmpty(text) || text == ",")
                        text = "0";
                }
                else if (text.StartsWith("-0") && text.Length > 2 && text[2] != ',' && text[2] != '0')
                {
                    text = "-" + text.Substring(2).TrimStart('0');
                    if (text == "-" || string.IsNullOrEmpty(text))
                        text = "0";
                }

                //double.TryParse(text, out double value);
                textBox.Text = text;

                textBox.Select(selectionInd, 0);
            }
        
        }


    }
}
