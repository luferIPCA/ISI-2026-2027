/*
 * Serviço SOAP CoreWCF
 * Instalar pacotes
 * 
 *  CoreWCF.Primitives
 *  CoreWCF.Http
 *  CoreWCF.ConfigurationManager
 * */
using CoreWCF;

namespace CalcWCF
{
    public class Calcwcf : ICalc
    {
        public int Soma(int x, int y)
        {
            return x + y;
        }
    }
}
