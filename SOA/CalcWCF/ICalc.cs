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
    [ServiceContract(Namespace ="http://www.ipca.pt/isi/wcf/")]
    public interface ICalc
    {
        [OperationContract]
        int Soma(int x, int y);
    }
}
