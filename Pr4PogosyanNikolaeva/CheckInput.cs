using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Pr4PogosyanNikolaeva
{
    public static class CheckInput
    {

        static public bool Check(char simv, string num, out double n, ref bool znak)
        {
            n = 0;
            if (simv == ',')
            {
                if (znak) return false;
                else
                {
                    num = $"{num}0";
                    znak = false;
                }
            }

            return double.TryParse(num, out n);
        }


        static public void CheckNullOrWSpace(TextBox textBox)
        {
            if (textBox != null)
            {
                if (textBox.Text.Length > 1)
                {
                    if (textBox.Text.EndsWith(" "))
                        textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
                    else if (textBox.Text.StartsWith(" "))
                        textBox.Text = textBox.Text.Substring(1, textBox.Text.Length - 1);
                    else if (textBox.Text.StartsWith("0"))
                        textBox.Text = textBox.Text.Substring(1, textBox.Text.Length - 1);

                }

                if (textBox.Text.Length == 0) textBox.Text = "0";

                //textBox.Text = x.ToString();
                textBox.Select(textBox.Text.Length, 0);
            }
        }
    }
}
