using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Crm.Sdk.Messages;
using System.Net;
using System.ServiceModel.Description;
using Microsoft.Xrm.Tooling.Connector;

namespace Aplicación_de_consola_D365
{
    class Program
    {
        static void Main(string[] args)
        {

            // e.g. https://yourorg.crm.dynamics.com
            string url = "https://prodeaw.crm2.dynamics.com";
            // e.g. you@yourorg.onmicrosoft.com
           //"admin@prodeaw.onmicrosoft.com";
            // e.g. y0urp455w0rd 
          
            string clientId = "dfd45868-59d1-4259-b231-a551108d2ad2";
            string clientSecret = "o4r8Q~K9llAAgyx-B4TN3q4bJF3ar1kMm.LWWbae";
            string userName = clientId;
            string password = clientSecret;//"Password01";
                                           //  RedirectUri = app://58145B91-0C36-4500-8554-080854F2AC97;
                                           // LoginPrompt=Never;
            //RequireNewInstance = True
            //AppId = dfd45868 - 59d1 - 4259 - b231 - a551108d2ad2;
            string conn = $@"
    Url = {url};
    AuthType = ClientSecret;
    ClientId = {clientId};
    ClientSecret = {clientSecret};";

            using (var svc = new CrmServiceClient(conn))
            {

                if (svc.IsReady)
                {
                    WhoAmIRequest request = new WhoAmIRequest();

                    WhoAmIResponse response = (WhoAmIResponse)svc.Execute(request);

                    Console.WriteLine("Your UserId is {0}", response.UserId);

                    Console.WriteLine("Press any key to exit.");
                }
                else Console.WriteLine("There is a problem connecting to D365.");
                Console.ReadLine();
            }
        }
    }
}
