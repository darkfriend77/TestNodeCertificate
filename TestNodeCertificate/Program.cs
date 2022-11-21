using Ajuna.NetApi;
using Ajuna.NetApi.Model.Extrinsics;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TestNodeCertificate
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Enter url? (defult:wss://ajuna-02.cluster.securitee.tech)");
            var url = Console.ReadLine();
            if (url == null || url.Length == 0)
            {
                url = "wss://ajuna-02.cluster.securitee.tech";
            }

            var client = new SubstrateClient(new Uri(url), ChargeTransactionPayment.Default());

            try
            {
                await client.ConnectAsync(false, false, CancellationToken.None);
            } 
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return;
            }

            Console.WriteLine("Got a valid connection? " + client.IsConnected);

            await client.CloseAsync();
        }
    }
}
