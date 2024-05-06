using MySoapService.Middleware;
using MySoapService.ServiceModel.Interfaces;
using SoapCore;
using MySoapService.ServiceModel;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddSoapCore();
        builder.Services.AddSingleton<IBlacklistService, BlacklistService>();

        var port = builder.Configuration.GetValue<int>("SOAPServiceSettings:Port");

        builder.WebHost.ConfigureKestrel(serverOptions => serverOptions.ListenAnyIP(port));

        var app = builder.Build();

        // app.UseMiddleware<BasicAuthMiddleware>();

        app.UseRouting();

        app.UseEndpoints(
            endpoints =>
                endpoints.UseSoapEndpoint<IBlacklistService>(
                    "/BlacklistService.asmx",
                    new SoapEncoderOptions(),
                    SoapSerializer.DataContractSerializer
                )
        );

        app.Run();
    }
}
