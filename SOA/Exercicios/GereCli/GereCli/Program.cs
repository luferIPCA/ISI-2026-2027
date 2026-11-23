using System;

namespace GereCli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WS.GereDataSoapClient ws = new WS.GereDataSoapClient();

            WS2.CountryClient ws2 = new WS2.CountryClient();

            Console.WriteLine(ws.DataValida("12-12-2026"));
            Console.WriteLine(ws.DataValida("32-12-2026"));

            Console.WriteLine(ws2.GetCountryFlag("pt"));

            Console.ReadKey();
        }
    }
}
