/*
 * Calculadora que usa Serviços SOAP
 * lufer
 * */

using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            WS.CalcWsPLusSoapClient ws = new WS.CalcWsPLusSoapClient();

            Console.WriteLine("2+3=" + ws.Soma(2, 3));
            Console.ReadKey();
        }
    }
}
