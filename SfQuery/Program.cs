using System;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;

namespace SfQuery
{
    public class Program
    {
        private static SalesforceClient CreateClient()
        {
            return new SalesforceClient
            {
                Username = ConfigurationManager.AppSettings["username"],
                Password = ConfigurationManager.AppSettings["password"],
                Token = ConfigurationManager.AppSettings["token"],
                ClientId = ConfigurationManager.AppSettings["clientId"],
                ClientSecret = ConfigurationManager.AppSettings["clientSecret"]
            };
        }

        static void Main(string[] args)
        {
            var client = CreateClient();

            if (args.Length > 0)
            {
                client.Login();
                Console.WriteLine(client.Query(args[0]));
            }
            else
            {

                //client.Login();

                //var acctDesc = client.Describe("Account");

                //Console.WriteLine(acctDesc);
                //Console.WriteLine(client.Describe("Contact"));
                //Console.WriteLine(client.QueryEndpoints());
                var fields = new []
                {
                    "Name",
                    "LEAP_Finance_ID__c",
                    "LEAP_Firm_GUID__c",
                    "LEAP_Primary_Contact__c",
                    "Account_Status__c",
                    "Solution_Created_Date__c",
                    "Phone",
                    "Fax",
                    "Email__c",
                    "ShippingStreet",
                    "ShippingState",
                    "ShippingCity",
                    "ShippingPostalCode",
                    "ShippingCountry",
                    "LEAP_Username__c",
                    "LEAP_Password__c",
                    "BillingStreet",
                    "BillingCity",
                    "BillingState",
                    "BillingPostalCode",
                    "BillingCountry",
                    "InfoTrack_Account_Sync_Date__c"

                    //"Billing_Account_Number__c",
                  
                };

                //var qry = client.Query("SELECT *  from Account where Solution_Created_Date__c > 2018-10-01 and Account_Status__c = 'Client on Support' limit 20");
                var qry = client.Query("SELECT " +  string.Join(",", fields)  + "  from Account where Solution_Created_Date__c > 2018-10-01 and Account_Status__c = 'Client on Support'");
                //var qry = client.Query("SELECT ShippingStreet, ShippingCity, ShippingState, ShippingPostalCode,ShippingCountry from Account where Solution_Created_Date__c = 2018-10-22");
                
                Console.WriteLine(qry);


               client.Update("sssss");
            }
            Console.ReadLine();
        }
    }
}
