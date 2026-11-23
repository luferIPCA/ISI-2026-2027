
using CoreWCF;

namespace GeraWCF
{
    [ServiceContract(Namespace ="http://www.ipca.pt/isi")]
    public interface ICountry
    {
        [OperationContract]
        string GetCountryFlag(string c);
    }
}
