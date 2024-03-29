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
//using Newtonsoft.Json;

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;




namespace CustomerPortal.Controllers
{
    public class CustomerController : Controller

    {
        [Authorize]
        public async Task<IActionResult> ChangeInfo()
        {
             string email = User.Identity.Name;
            Customer customer = await CustomerController.getCustomerByEmail(email);
            ViewBag.customer = customer ;
            

            System.Console.WriteLine(email);
            // ViewBag.email = getLoggedInUserEmail();

            return View();
        }
        [Authorize]
        [HttpPost]
        // post updated user from view
        public async Task<IActionResult> ChangeInfo(Customer updatedCustomer)
        {
        System.Console.WriteLine(updatedCustomer);

        var updatedCustomerJson = JsonSerializer.Serialize(updatedCustomer);

        

        //var content2 = JsonConvert.SerializeObject(updatedCustomer);
        System.Console.WriteLine(updatedCustomerJson);

        var content = new StringContent(updatedCustomerJson, Encoding.UTF8, 
                                    "application/json");

        System.Console.WriteLine(content);
        // update user 
        var client = new HttpClient();
        var response = await client.PutAsync(ApiURL("Customers/", updatedCustomer.id), content);

        System.Console.WriteLine(response);



            return View();
        }
  




        // Api call Url so only one line has to be changed when we go to production
        public static string ApiURL(string parameter,long? variable = null)
        {  
            // define base variables for final conection string 
            string URLreturn ;
            // string baseUrl = "http://localhost:5501/api/";
            string baseUrl = "https://rocket-elevators-status.azurewebsites.net/api/";

            // logic for the return string so it correspondes to api end points
            if(variable == null)
            {            
                URLreturn =  baseUrl + parameter ;
            }
            else
            {
                URLreturn = baseUrl + parameter + $"{variable}";
            }
            // return an valid api endpoint from the given parameters
            return URLreturn;
        }
        // method to get CustomerList
            public static async Task<List<Customer>> getCustomerList()
        {
            
            // connexion
            var client = new HttpClient();
            // get call to API
            var response = await client.GetAsync( ApiURL("customers"));
            // save the response
            var content = response.Content.ReadAsStringAsync().Result;
            // parse response
            var CustomerList = JsonSerializer.Deserialize<List<Customer>>(content);
            // test log to console
            var test3 = CustomerList[0].company_name;
            Console.WriteLine(test3);
            
            return CustomerList;
        } 

        public static async Task<Customer> getCustomerByEmail(string email)
        {
            // connexion
            var client = new HttpClient();
            // get call to api 
            var response = await client.GetAsync( ApiURL("Customers/email/" + email));
            // save the response
            var content = response.Content.ReadAsStringAsync().Result;
            //parse response
            var customer = JsonSerializer.Deserialize<Customer>(content);

            return customer;

        }

        // a voir si temps de changer le register pour un post
        // public static async Task<Boolean> isEmailOnRegisterList(string email)
        // {
        //     //connexion
        //     var client = new HttpClient();
        //     HttpResponseMessage response = await client.PostAsJsonAsync("email", email);
        //     response.EnsureSuccessStatusCode();

            

        //     // return URI of the created resource.
        //     return response.Content;

        // } 
    }

}
