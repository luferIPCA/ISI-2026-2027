/*
 * Serviço SOAP CoreWCF
 * Instalar pacotes
 * 
 *  CoreWCF.Primitives
 *  CoreWCF.Http
 *  CoreWCF.ConfigurationManager
 * */

using CoreWCF;
using CoreWCF.Configuration;
using CoreWCF.Channels;
using CalcWCF; // NameSpace do meu projeto

var builder = WebApplication.CreateBuilder(args);

// 1. Registar os serviços do CoreWCF 
builder.Services.AddServiceModelServices();
builder.Services.AddServiceModelMetadata();

var app = builder.Build();

// 2. Mapear o endpoint SOAP
app.UseServiceModel(serviceBuilder =>
{
    serviceBuilder.AddService<Calcwcf>();

    //// Endpoint HTTP
    //serviceBuilder.AddServiceEndpoint<Calcwcf, ICalc>(
    //    new BasicHttpBinding(),
    //    "/CalcService.svc"
    //);

    // Endpoint HTTPS
    serviceBuilder.AddServiceEndpoint<Calcwcf, ICalc>(
        new BasicHttpBinding(BasicHttpSecurityMode.Transport),
        "/CalcService.svc"
    );

    // para tornar publico o wsdl, ie, para usar nno "Add Connected Service do VS"
    var metadata = app.Services.GetRequiredService<
        CoreWCF.Description.ServiceMetadataBehavior>();

    metadata.HttpGetEnabled = true;
    metadata.HttpsGetEnabled = true;
});

// Apenas para demonstrar que serviço está ON 
app.MapGet("/", () => "Servidor CoreWCF a correr com sucesso! Acede a /CalcService.svc?wsdl");

app.Run();
