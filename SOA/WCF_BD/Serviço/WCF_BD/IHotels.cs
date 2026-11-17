/*
 * by lufer
 * 
 * Web Services sobre Bases de Dados com ADO.NET (pag. 151 da Sebenta)
 * Typed DataSets
 * 
 * Receita:
 * 
 * 1- Incluir System.Data e System.Data."Driver"
 * 2- Definir conexão (directa ou externa)
 * 3- Definir Query
 * 4- Executar Query
 * 5- Tratar resultados
 * 
 * URLS:
 * http://www.connectionstrings.com/
 * https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/connection-strings-and-configuration-files
 * https://www.connectionstrings.com/store-connection-string-in-webconfig/
 * https://blog.elmah.io/the-ultimate-guide-to-connection-strings-in-web-config/
 * ADO.NET
 * https://learn.microsoft.com/pt-pt/dotnet/framework/data/adonet/ado-net-overview
 * https://learn.microsoft.com/en-us/aspnet/mvc/overview/getting-started/introduction/creating-a-connection-string
 */

using System.Runtime.Serialization;
using System.ServiceModel;
using System.Data;

namespace WCFBD
{
    [ServiceContract(Namespace ="http://www.ipca.pt/isi")]
    public interface IHotels
    {

        [OperationContract]
        DataSet GetHotelCidade(string cidade);

        [OperationContract(Name = "GetAllHoteisCidade")]
        DataSet GetAllHoteis(string cidade);

        [OperationContract]
        DataSet GetAllHoteisComCapacidade(int capacidade);

        [OperationContract]
        bool InsertHotel(Hotel h);
    }

    [DataContract]
    public struct Hotel
    {
        [DataMember]
        public string nome;
        [DataMember]
        public string cidade;
        [DataMember]
        public int capacidade;
    }
}
