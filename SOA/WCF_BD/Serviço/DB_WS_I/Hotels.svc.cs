/**
 * lufer
 *
 * Web Services WCF sobre Bases de Dados com ADO.NET (pag. 151 da Sebenta)
 * Typed DataSets
 * 
 * 1ª ConnectionString
 * 2ª Connetar
 * 3º Preparar query
 * 4º Executar query
 * 5º Tratar resultado
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

//OleDB
using System.Configuration;
using System.Data;
using System.Data.OleDb;
//using System.Data.SqlClient;


namespace WCFBD
{
    /// <summary>
    /// Implementa IHotels
    /// </summary>
    public class Hotels : IHotels
    {
        /// <summary>
        /// Devolve todos os hoteis de uma determinada cidade
        /// </summary>
        /// <param name="cidade"></param>
        /// <returns></returns>
        public DataSet GetHotelCidade(string cidade)
        {
            // *1ª ConnectionString
            // *2ª Connetar
            // *3º Preparar query
            //* 4º Executar query
            //* 5º Tratar resultado

           DataSet ds = new DataSet();

            //1 Connection
            string conString = ConfigurationManager.ConnectionStrings["turismoConnectionString"].ConnectionString;
            //string cons = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=c:\temp\turismo.mdb";
            OleDbConnection con = new OleDbConnection(conString);
            //con.ConnectionString = "";


            //2 Query
            string query = "select * from hoteis where cidade=@cidade";

            //3 Adapter
            OleDbDataAdapter da = new OleDbDataAdapter(query, con);
            da.SelectCommand.Parameters.Add("@cidade", OleDbType.VarChar);
            da.SelectCommand.Parameters["@cidade"].Value = cidade;

            //da.SelectCommand.Parameters.AddWithValue("@cidade", cidade);

            //4 Execute

            da.Fill(ds, "Q1");

            return ds;
        }

        #region GetHoteisCapacidade
        public DataSet GetAllHoteisComCapacidade(int capacidade)
        {
            DataSet ds = new DataSet();

            //1º ConnectionString
            string cs = ConfigurationManager.ConnectionStrings["turismoConnectionString"].ConnectionString;

            //2º OpenConnection
            OleDbConnection con = new OleDbConnection(cs);

            //3º Query Parametrizada
            string q = "SELECT nome, (capacidade-ocupacao) as livres, cidade FROM Hoteis WHERE (capacidade-ocupacao)>@capacidade; ";    //aplicar critério            

            //4º Prepara DataAdapter
            OleDbDataAdapter da = new OleDbDataAdapter(q, con);

            //Instancia parâmetros
            da.SelectCommand.Parameters.Add("@capacidade", OleDbType.Integer);
            da.SelectCommand.Parameters["@capacidade"].Value = capacidade;

            //Executa e preenche o DataSet com os resultados
            da.Fill(ds, "Hoteis2");

            return (ds);
        }

        #endregion

        #region GetAllHoteis
        /// <summary>
        /// Devolve toda a informação dos hoteis de determinada localidade
        /// </summary>
        /// <param name="criterio"></param>
        /// <returns></returns>
        public DataSet GetAllHoteis(string cidade)
        {
            DataSet ds = new DataSet();

            //1º ConnectionString
            string cs = ConfigurationManager.ConnectionStrings["turismoConnectionString"].ConnectionString;

            //2º OpenConnection
            OleDbConnection con = new OleDbConnection(cs);

            //3º Query Parametrizada
            string q = "select * from Hoteis where cidade=@cidade";    //aplicar critério
                                                                       //Errado: string q = "select * from Hoteis where cidade=" + cidade;

            //4º Execute
            OleDbDataAdapter da = new OleDbDataAdapter(q, con);

            //Instancia parâmetros
            da.SelectCommand.Parameters.Add("@cidade", OleDbType.VarChar);
            da.SelectCommand.Parameters["@cidade"].Value = cidade;

            //Executa e preenche o DataSet com os resultados
            da.Fill(ds, "Hoteis1");

            return (ds);
        }
        #endregion

        #region Insert

        public bool InsertHotel(Hotel h)
        {
            OleDbConnection con;
            OleDbCommand myCommand;

            //1º ConnectionString
            string cs = ConfigurationManager.ConnectionStrings["turismoConnectionString"].ConnectionString;
            
            //2º OpenConnection
            con = new OleDbConnection(cs);

            //3º Query Parametrizada
            string q = "INSERT INTO Hoteis(Nome,Cidade,Capacidade) VALUES(@nome,@cidade,@capacidade);";
            myCommand = new OleDbCommand(q, con);

            //Instancia parâmetros
            myCommand.Parameters.Add("@nome",OleDbType.VarChar).Value= h.nome;
            myCommand.Parameters.Add("@cidade", OleDbType.VarChar).Value=h.cidade;
            myCommand.Parameters.Add("@capacidade",OleDbType.Integer).Value= h.capacidade;

            //4º Prepara DataAdapter       
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.InsertCommand = myCommand;

            try
            {
                con.Open();
                int count;
                //Executa e preenche o DataSet com os resultados
                count = da.InsertCommand.ExecuteNonQuery();
                return true;
            } catch { }

            return (false);
        }

        #endregion
    }


}
