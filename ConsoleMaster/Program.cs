using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] letters = { 'f', 'r', 'e', 'd', ' ', 's', 'm', 'i', 't', 'h' };
            string name = "";
            int[] a = new int[10];
            for (int i = 0; i < letters.Length; i++)
            {
                name += letters[i];
                a[i] = i + 1;
                SendMessage(name, a[i]);
            }
            Console.ReadKey();
        }


        /// <summary>
        /// Отправляет приветственное сообщение с указанием имени и числа.
        /// </summary>
        /// <param name="name">Имя получателя сообщения.</param>
        /// <param name="msg">Число</param>
        static void SendMessage(string name, int msg)
        {
            Console.WriteLine("Hello, " + name + "! Count to " + msg);
        }


    }
}
