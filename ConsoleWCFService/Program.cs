using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWCFService
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8000/Teastore/Service");

            ServiceHost selfHost = new ServiceHost(typeof(TeaService), baseAddress);

            try
            {
                selfHost.AddServiceEndpoint(
                    typeof(ITeaStore),
                    new WSHttpBinding(),
                    "TeaService");

                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);

                // start web service
                selfHost.Open();

                Console.WriteLine("Service is ready..... Press <ENTER> to terminate");
                Console.ReadLine();

                // end service
                selfHost.Close();
            }
            catch (CommunicationException e)
            {
                Console.WriteLine("An exception occured: {0}", e.Message);
                selfHost.Abort();
            }
        }
    }
}
