using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFBD
{
   public class Voos : IVoos
    {
        /// <summary>
        /// Devolve toda a informação sobre todos os Hoteis
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllFlights()
        {
            DataSet ds = new DataSet();

            //1º ConnectionString no Web Config

            string cs = ConfigurationManager.ConnectionStrings["VoosConnectionString"].ConnectionString;

            //2º OpenConnection
            OleDbConnection con = new OleDbConnection(cs);      //via OleDB
                                                                //SqlConnection con = new SqlConnection(c);        //via SQLServer


            //3º Query
            string q = "select * from Voos";


            //4º Execute
            OleDbDataAdapter da = new OleDbDataAdapter(q, con);
            //SqlDataAdapter da = new SqlDataAdapter(q, con);    //via SQLServer

            da.Fill(ds, "Voos");

            //Devolve o resultado
            return (ds);
        }
    }
}
