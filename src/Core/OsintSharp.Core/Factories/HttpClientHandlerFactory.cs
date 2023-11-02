using OsintSharp.Core.Interfaces;

namespace OsintSharp.Core.Factories;

public class HttpClientHandlerFactory : IFactory<HttpClientHandler>
{
    public HttpClientHandler Create()
    {
        var handler = new HttpClientHandler
        {
            ClientCertificateOptions = ClientCertificateOption.Automatic,
            UseDefaultCredentials = false,
            PreAuthenticate = false,
            UseProxy = false,
            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
        };

        return handler;
    }
}
