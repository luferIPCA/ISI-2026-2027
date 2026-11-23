
using CoreWCF;

namespace GeraWCF
{
    [ServiceContract(Namespace ="https://www.ipca.pt/isi")]
    public interface IData
    {
        [OperationContract]
        bool ValidDate(string s);

    }
}
