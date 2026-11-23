/*
 * lufer
 * ISI 2026
 * */
using System;
using System.Security.Cryptography;
using System.Web.Services;

/// <summary>
/// Summary description for CalcWs
/// </summary>
[WebService(Namespace = "http://www.ipca.pt/isi/")]
public class CalcWs : System.Web.Services.WebService
{

    public CalcWs()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod(Description = "Calcula a Soma")]
    public int Soma(int x, int y)
    {
        return x + y;
    }

    [WebMethod(Description ="Calcula a Suubtração")]
    public int Sub(int x, int y)
    {
        return x - y;
    }

    [WebMethod()]
    public bool ValidaData(string s)
    {
        DateTime d;
        bool aux = DateTime.TryParse(s, out d);
        return aux;
    }

}
