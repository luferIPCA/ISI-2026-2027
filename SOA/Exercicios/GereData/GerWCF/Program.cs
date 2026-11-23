

using CoreWCF;
using CoreWCF.Configuration;
using CoreWCF.Channels;
using GeraWCF; // NameSpace do meu projeto

var builder = WebApplication.CreateBuilder(args);

// 1. Registar os serviços do CoreWCF 
builder.Services.AddServiceModelServices();
builder.Services.AddServiceModelMetadata();

var app = builder.Build();

// 2. Mapear o endpoint SOAP
app.UseServiceModel(serviceBuilder =>
{
    serviceBuilder.AddService<GereData>();
    serviceBuilder.AddService<Country>();

    // Endpoint HTTP
    serviceBuilder.AddServiceEndpoint<GereData, IData>(
        new BasicHttpBinding(),
        "/GereData.svc"
    );

    // Endpoint HTTPS
    serviceBuilder.AddServiceEndpoint<GereData, IData>(
        new BasicHttpBinding(BasicHttpSecurityMode.Transport),
        "/GereData.svc"
    );

    // Endpoint HTTPS -2º Serviço
    serviceBuilder.AddServiceEndpoint<Country, ICountry>(
        new BasicHttpBinding(BasicHttpSecurityMode.Transport),
        "/Country.svc"
    );

    // para tornar publico o wsdl, ie, para usar nno "Add Connected Service do VS"
    var metadata = app.Services.GetRequiredService<
        CoreWCF.Description.ServiceMetadataBehavior>();

    metadata.HttpGetEnabled = true;
    metadata.HttpsGetEnabled = true;
});

// Apenas para demonstrar que serviço está ON 
app.MapGet("/", () => "Servidor CoreWCF a correr com sucesso! Acede a /GereData.svc?wsdl");

app.Run();