using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace RetroMarket.PosteCanada
{
    class TestClients
    {
        static void Main(string[] args)
        {
            EstimatingTestClient.TestClient estimatingClient = new EstimatingTestClient.TestClient();
            estimatingClient.CallGetQuickEstimate();

            Console.ReadLine();
        }
    }
}
