using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace SfQuery
{
    public class SalesforceClient
    {
        // IMPORTANT: test environment MUST use test.salesforce.com  instead of login.salesforce.com
        private const string LOGIN_ENDPOINT = "https://login.salesforce.com/services/oauth2/token";
        private const string API_ENDPOINT = "/services/data/v20.0/";

        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string AuthToken { get; set; }
        public string InstanceUrl { get; set; }

        static SalesforceClient()
        {
            // SF requires TLS 1.1 or 1.2
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12; // | SecurityProtocolType.Tls11;
        }

        // TODO: use RestSharps
        public void Login()
        {
            String jsonResponse;
            using (var client = new HttpClient())
            {
                var request = new FormUrlEncodedContent(new Dictionary<string, string>
                    {
                        {"grant_type", "password"},
                        {"client_id", ClientId},
                        {"client_secret", ClientSecret},
                        {"username", Username},
                        {"password", Password + Token}
                    }
                );
                request.Headers.Add("X-PrettyPrint", "1");
                var response = client.PostAsync(LOGIN_ENDPOINT, request).Result;
                jsonResponse = response.Content.ReadAsStringAsync().Result;
            }
            Console.WriteLine($"Response: {jsonResponse}");
            var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonResponse);
            AuthToken = values["access_token"];
            InstanceUrl = values["instance_url"];
        }

        public string QueryEndpoints()
        {
            using (var client = new HttpClient())
            {
                string restQuery = InstanceUrl + API_ENDPOINT;
                var request = new HttpRequestMessage(HttpMethod.Get, restQuery);
                request.Headers.Add("Authorization", "Bearer " + AuthToken);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Headers.Add("X-PrettyPrint", "1");
                var response = client.SendAsync(request).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        public string Describe(string sObject)
        {
            using (var client = new HttpClient())
            {
                string restQuery = InstanceUrl + API_ENDPOINT + "sobjects/" + sObject;
                var request = new HttpRequestMessage(HttpMethod.Get, restQuery);
                request.Headers.Add("Authorization", "Bearer " + AuthToken);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Headers.Add("X-PrettyPrint", "1");
                var response = client.SendAsync(request).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        public string Query (string soqlQuery)
        {

            // Testing of expired authentication
            AuthToken = "MY TOKEN";

                //"00Dw0000000lMiE!AQ8AQHXuvoncLRh_Be9VwmPekJYaTXxq_0PoSr96yvpQ0qpG0UV0jwCp0QRdIrvV8rgw56E4uiOHD1Fwj.IGePXVbzDlEhfd";

            InstanceUrl = "https://leap.my.salesforce.com";


            using (var client = new HttpClient())
            {
                string restRequest = InstanceUrl + API_ENDPOINT + "query/?q=" + soqlQuery;
                var request = new HttpRequestMessage(HttpMethod.Get, restRequest);
                request.Headers.Add("Authorization", "Bearer " + AuthToken);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Headers.Add("X-PrettyPrint", "1");
                var response = client.SendAsync(request).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        public async void Update(string acctNum)
        {
            using (var client = new HttpClient())
            {

                //var request = new FormUrlEncodedContent(new Dictionary<string, string>
                //    {
                //        {"Account_Synchronized_Date__c", "2018-10-24T16:00:00"},
                //    }
                //);

                var updDT = new DateTime(2017,11,05,10,03,11).ToUniversalTime();//.ToUniversalTime();

                var jsonParams = "{\"InfoTrack_Account_Sync_Date__c\":\"" + updDT.ToString("yyyy-MM-ddTHH:mm:sss") + "\"}";

                try
                {
                    //client.DefaultRequestHeaders.Add("X-PrettyPrint", "1");
                    //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + AuthToken);

                    var patchMethod = new HttpMethod("PATCH");

                    var uri = new Uri(InstanceUrl + "/services/data/v20.0/sobjects/Account/0012500000SzUQbAAN");
                    var request = new HttpRequestMessage(patchMethod, uri)
                    {
                        Content =  new StringContent(jsonParams, System.Text.Encoding.UTF8, "application/json")
                    };

                    request.Headers.Add("X-PrettyPrint", "1");
                    request.Headers.Add("Authorization", "Bearer " + this.AuthToken);


                    var response = await client.SendAsync(request); // HttpMethod.Patch, InstanceUrl + "/services/data/v20.0/sobjects/Account/0012500000SzUQbAAN", request).Result;

                    var jsonResponse = response.Content.ReadAsStringAsync().Result;

                }
                catch (Exception ex)
                {

                }
                //string restRequest = InstanceUrl + API_ENDPOINT + "query/?q=" + soqlQuery;
                //var request = new HttpRequestMessage(HttpMethod.Get, restRequest);
                //request.Headers.Add("Authorization", "Bearer " + AuthToken);
                //request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //request.Headers.Add("X-PrettyPrint", "1");
                //var response = client.SendAsync(request).Result;
                //return response.Content.ReadAsStringAsync().Result;
            }
        }

    }
}
