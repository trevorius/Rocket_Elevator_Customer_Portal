using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CustomerPortal.Models;
using CustomerPortal.Controllers;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;


// SignInManager<IdentityUser> SignInManager;
// UserManager<IdentityUser> UserManager;

namespace CustomerPortal.Controllers
{
    public class ProductsController : Controller
    {
        // private readonly UserManager<IdentityUser> _userManager;
        // private readonly SignInManager<IdentityUser> _signInManager;
        
        // public async Task<string> getLoggedInUserEmail(IdentityUser user)
        // {
        //     var email = await _userManager.GetEmailAsync(user);
        //     return email;
        // }



        //         public class UserRepository : IUserRepository
        // {
        //     private readonly IHttpContextAccessor _httpContextAccessor;

        //     public UserRepository(IHttpContextAccessor httpContextAccessor)
        //     {
        //         _httpContextAccessor = httpContextAccessor;
        //     }

        //     public void LogCurrentUser()
        //     {
        //         var username = _httpContextAccessor.HttpContext.User.Identity.Name;
        //         service.LogAccessRequest(username);
        //     }
        // }


        // private readonly UserManager<ApplicationUser> _userManager;
    
        // public ProductsController(UserManager<ApplicationUser> userManager)
        // {
        //     _userManager = userManager;
        // }

        // public async Task<IActionResult> getUserEmail()
        // {
        //     System.Web.HttpContext.Current.User.Identity.Name();

        //     var userId =  User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
        //     var userName =  User.FindFirstValue(ClaimTypes.Name); // will give the user's userName
            
        //     // For ASP.NET Core <= 3.1
        //     ApplicationUser applicationUser = await _userManager.GetUserAsync(User);
        //     string userEmail = applicationUser?.Email; // will give the user's Email

        // // // For ASP.NET Core >= 5.0
        // // var userEmail =  User.FindFirstValue(ClaimTypes.Email) // will give the user's Email
        // }

        // public static string getCurrentUserEmail()
        // {
        //     var name = User.identity.name; 
            
        //     // if (SignInManager2.IsSignedIn(User))
        //     // {
        //     // var userEmail = UserManager2.GetUserName(User);
        //     // return userEmail;
        //     // }
        // }

        public async Task<IActionResult> Products()
        {
            string email = User.Identity.Name;
            System.Console.WriteLine(email);
            // ViewBag.email = getLoggedInUserEmail();
            return View();
        }
        public static async Task<List<Building>> getBuildingListForCustomer(long id)
        {
            // connexion
            var client = new HttpClient();
            // get call to API
            var response = await client.GetAsync(CustomerController.ApiURL("buildings/for-customer-",id));
            // save the response
            var content = response.Content.ReadAsStringAsync().Result;
            // parse response
            var BuildingList = JsonSerializer.Deserialize<List<Building>>(content);
            // test log to console
            var test3 = BuildingList[0].address_of_the_building;
            Console.WriteLine(test3);

            return BuildingList;
        }
        public static async Task<List<Battery>> getBatteryListForBuilding(long id)
        {
            // connexion
            var client = new HttpClient();
            // get call to API
            var response = await client.GetAsync(CustomerController.ApiURL("batteries/for-building-",id));
            // save the response
            var content = response.Content.ReadAsStringAsync().Result;
            // parse response
            var BatteryList = JsonSerializer.Deserialize<List<Battery>>(content);
            // test log to console
            var test3 = BatteryList[0].status;
            Console.WriteLine(test3);

            return BatteryList;
        }
        public static async Task<List<Column>> getColumnListForBattery(long id)
        {
            // connexion
            var client = new HttpClient();
            // get call to API
            var response = await client.GetAsync(CustomerController.ApiURL("columns/for-battery-",id));
            // save the response
            var content = response.Content.ReadAsStringAsync().Result;
            // parse response
            var ColumnList = JsonSerializer.Deserialize<List<Column>>(content);
            // test log to console
            var test3 = ColumnList[0].status;
            Console.WriteLine(test3);

            return ColumnList;
        }
        public static async Task<List<Elevator>> getElevatorListForColumn(long id)
        {
            // connexion
            var client = new HttpClient();
            // get call to API
            var response = await client.GetAsync(CustomerController.ApiURL("elevators/for-column-",id));
            // save the response
            var content = response.Content.ReadAsStringAsync().Result;
            // parse response
            var ElevatorList = JsonSerializer.Deserialize<List<Elevator>>(content);
            // test log to console
            var test3 = ElevatorList[0].serial_number;
            Console.WriteLine(test3);

            return ElevatorList;
        }


    }
}