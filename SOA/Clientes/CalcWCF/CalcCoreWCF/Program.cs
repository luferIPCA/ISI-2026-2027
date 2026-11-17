/*
 * Cliente em .NET 8.0 que usa um serviço soap CoreWCF
 * 
 * */
using System.ServiceModel;
using WS;

// 1. Configurar o binding e o endereçodo endpoint HTTPS 
var binding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);
var endpoint = new EndpointAddress("https://localhost:7042/CalcService.svc");

// 2. Criar uma instância local do serviço
CalcClient client = new CalcClient(binding, endpoint);

try
{
    Console.WriteLine("A comunicar com o serviço CoreWCF...\n");

    int x = 20;
    int y = 4;

    // 3. Invocar as operações quase "assíncronas" - H1

    //int soma = await client.SomaAsync(x, y);
    //Console.WriteLine($"Soma ({x} + {y}) = {soma}");
    //await client.CloseAsync();

   //Console.WriteLine("Depois");

    //3. Invocar métodos mesmo em modoassincrono - H2
    Console.WriteLine("A iniciar o pedido em segundo plano...");

    // 3.1. Lançar a tarefa sem await
    Task<int> taskSoma = client.SomaAsync(20, 4);

    Console.WriteLine("2. O servidor está a trabalhar :)!");

    // Alertar quando a tarefa terminar em background sem dar o aviso CS4014:
    _ = taskSoma.ContinueWith(t =>
    {
        if (t.IsFaulted)
        {
            Console.WriteLine($"[ERRO em Background] A operação falhou: {t.Exception?.InnerException?.Message}");
        }
        else
        {
            Console.WriteLine($"[Notificação] A tarefa terminou! Resultado: {t.Result}");
        }
    });

    Console.WriteLine("O processamento avançou sem esperar pela soma!");
    
}
catch (System.ServiceModel.EndpointNotFoundException)
{
    string urlTentado = client != null ? client.Endpoint.Address.Uri.ToString() : "Desconhecido";
    int portaUsada = client != null ? client.Endpoint.Address.Uri.Port : 0;

    Console.WriteLine("[ERRO] O servidor CoreWCF não foi encontrado na porta especificada!");
    Console.WriteLine($"O cliente tentou usar o endereço: {urlTentado}");
    Console.WriteLine($"Dica: Verifica se o servidor está a correr e se a porta ({portaUsada}) está correta no launchSettings.json.");

    // Aborta se o cliente chegou a ser instanciado
    client?.Abort();
}
catch (Exception ex)
{
    Console.WriteLine($"Erro na chamada SOAP: {ex.Message}");

    // Aborta em caso de outro erro inesperado
    client?.Abort();
}

Console.ReadKey();