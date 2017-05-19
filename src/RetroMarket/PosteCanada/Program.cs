using System;
using System.Text;
using System.Net;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;

namespace RetroMarket.PosteCanada
{
    public class Program : PourvoyeurDeLivraison
    {
        public async Task<Stream> GetRequestStream(HttpWebRequest request)
        {
            return await request.GetRequestStreamAsync();
        }

        public async Task<WebResponse> GetResponse(HttpWebRequest request)
        {
            return await request.GetResponseAsync();
        }

        public float Principale(List<ArticlePanier> monPanier, string codePostal)
        { 
           //ArticlePanier a_1 = new ArticlePanier();
           //a_1.ID = 1;
           //a_1.Poids = 2.5m;
           //ArticlePanier a_2 = new ArticlePanier();
           //a_2.ID = 2;
           //a_2.Poids = 10m;
           //List<ArticlePanier> monPanier = new List<ArticlePanier>();
           //monPanier.Add(a_1);
           //monPanier.Add(a_2);
            Colis colis = new Colis("J2S1H9", codePostal, monPanier);
            nomPourvoyeur = CultureInfo.CurrentCulture.Name == "fr" ? "Poste Canada" : "Canada Post"; // À modifier

            // Your username, password and customer number are imported from the following file
            // CPCWS_Rating_DotNet_Samples\REST\rating\user.xml 
            var username = "67373b41cb4e5281";
            var password = "756a19ad6f248e1b107d5c";
            var mailedBy = "0008544863";

            var url = "https://ct.soa-gw.canadapost.ca/rs/ship/price"; // REST URL

            var method = "POST"; // HTTP Method
            //String responseAsString = ".NET Framework " + Environment.Version.ToString() + "\r\n\r\n";

            // Create mailingScenario object to contain xml request
            mailingscenario mailingScenario = new mailingscenario();
            mailingScenario.parcelcharacteristics = new mailingscenarioParcelcharacteristics();
            mailingScenario.destination = new mailingscenarioDestination();
            mailingscenarioDestinationDomestic destDom = new mailingscenarioDestinationDomestic();
            mailingScenario.destination.Item = destDom;

            // Populate mailingScenario object
            mailingScenario.customernumber = mailedBy;
            mailingScenario.parcelcharacteristics.weight = colis.PoidsTotal; // En kilogramme
            mailingScenario.originpostalcode = colis.adresseOrigine; // Code postal du Père Noël ne fonctionnera peut-être pas avec Purolator
            destDom.postalcode = colis.adresseDestination; // Code postal du cégep

            try
            {

                // Serialize mailingScenario object to String
                StringBuilder mailingScenarioSb = new StringBuilder();
                XmlWriter mailingScenarioXml = XmlWriter.Create(mailingScenarioSb);
                mailingScenarioXml.WriteProcessingInstruction("xml", "version=\"1.0\" encoding=\"UTF-8\"");
                XmlSerializer serializerRequest = new XmlSerializer(typeof(mailingscenario));
                serializerRequest.Serialize(mailingScenarioXml, mailingScenario);

                // Create REST Request
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = method;
                // Set Basic Authentication Header using username and password variables
                string auth = "Basic " + Convert.ToBase64String(Encoding.GetEncoding(0).GetBytes(username + ":" + password));
                request.Headers = new WebHeaderCollection();
                request.Headers["Authorization"] = auth;

                // Write Post Data to Request
                UTF8Encoding encoding = new UTF8Encoding();
                byte[] buffer = encoding.GetBytes(mailingScenarioSb.ToString());
                //request.ContentLength = buffer.Length;
                // Français ou anglais selon la culture (CultureInfo)
                request.Headers["Accept-Language"] = "fr-CA";
                request.Accept = "application/vnd.cpc.ship.rate-v3+xml";
                request.ContentType = "application/vnd.cpc.ship.rate-v3+xml";
                var stream = GetRequestStream(request);
                Stream PostData = stream.Result;
                PostData.Write(buffer, 0, buffer.Length);
                PostData.Dispose();

                // Execute REST Request
                var rep = GetResponse(request);
                HttpWebResponse response = (HttpWebResponse)rep.Result;

                // Deserialize response to pricequotes object
                XmlSerializer serializer = new XmlSerializer(typeof(pricequotes));
                TextReader reader = new StreamReader(response.GetResponseStream());
                pricequotes priceQuotes = (pricequotes)serializer.Deserialize(reader);

                // Retrieve values from pricequotes object
                foreach (var priceQuote in priceQuotes.pricequote)
                {
                    if (priceQuote.servicecode == "DOM.RP")
                    {
                        return (float)priceQuote.pricedetails.due;
                    }
                }
                return 0;
            }
            catch (WebException webEx)
            {
                return 0;
            }
            catch (Exception ex)
            {
                // Misc Exception
               return 0;
            }
        }
    }
}

