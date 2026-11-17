/*
 * Cliente que usa um serviço CoreWCF
 * Cliente em .NET Framewwork <=5.0
 * lufer
 */

using System;

namespace CalcConsoleWCF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WS.CalcClient ws = null;
            try
            {
                // Indicar o endpoint a usar (está do App.config)
                // http: http://localhost:5066/CalcService.svc; name="BasicHttpBinding_ICalc"
                // https: https://localhost:7042/CalcService.svc; name="BasicHttpBinding_ICalc1"
                ws = new WS.CalcClient("BasicHttpBinding_ICalc1");

                Console.WriteLine("Res: {0}", ws.Soma(2, 3));
                
            }
            catch (System.ServiceModel.EndpointNotFoundException)
            {
                // Extrai o URI e a porta do endpoint configurado no cliente
                string url = ws != null ? ws.Endpoint.Address.Uri.ToString() : "Desconhecido";
                int portaUsada = ws != null ? ws.Endpoint.Address.Uri.Port : 0;

                Console.WriteLine("[ERRO] O servidor não foi encontrado na porta especificada!");
                Console.WriteLine($"O cliente tentou usar o endereço: {url}");
                Console.WriteLine("Dica: Verifica se o servidor está a correr e se a porta no launchSettings.json coincide com o endereço do cliente.");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"[ERRO INESPERADO] {ex.Message}");
            }
            Console.ReadKey();
        }
    }
}
