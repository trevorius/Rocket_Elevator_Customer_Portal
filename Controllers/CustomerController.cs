using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CustomerPortal.Models;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;




namespace CustomerPortal.Controllers
{
    public class CustomerController
    {
        // method to get CustomerList
            public static async Task<List<Customer>> getCustomerList()
        {
            // connexion
            var client = new HttpClient();
            // get call to API
            var response = await client.GetAsync("http://localhost:5501/api/customers");
            // save the response
            var content = response.Content.ReadAsStringAsync().Result;
            // parse response
            var CustomerList = JsonSerializer.Deserialize<List<Customer>>(content);
            // test log to console
            var test3 = CustomerList[0].company_name;
            Console.WriteLine(test3);
            
            return CustomerList;
        }   
    }

}
