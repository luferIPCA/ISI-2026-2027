using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for CalcWsPLus
/// </summary>
[WebService(Namespace = "http://www.ipca.pt/isi/", Description ="Calculador de ISI")]
public class CalcWsPLus : System.Web.Services.WebService
{

    public CalcWsPLus()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod(Description ="Calcula a Multiplicação")]
    public int Mult(int x, int y)
    {
        return x*y;
    }

    [WebMethod(Description ="Calcula a Soma")]
    public int Soma(int x, int y)
    {
        WS.CalcWsSoapClient ws = new WS.CalcWsSoapClient();
        return ws.Soma(x, y);
    }

}
