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

        public string GetCountryFlag(string pais)
        {
            WS2.CountryInfoServiceSoapTypeClient ws = new WS2.CountryInfoServiceSoapTypeClient(WS2.CountryInfoServiceSoapTypeClient.EndpointConfiguration.CountryInfoServiceSoap);

            try
            {
                WS2.CountryCurrencyRequest r = new WS2.CountryCurrencyRequest();
                if (r.Body == null)
                {
                    r.Body = new WS2.CountryCurrencyRequestBody();
                }
                r.Body.sCountryISOCode = pais;

                WS2.CountryCurrencyResponse resp = ws.CountryCurrency(r);
                ws.Close();

                if (resp != null && resp.Body != null && resp.Body.CountryCurrencyResult != null)
                {
                    return resp.Body.CountryCurrencyResult.sName;
                }

                return ""; 
            }
            catch
            {
                ws.Abort();
                throw;
            }
        }
    }
}
