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
        [Authorize]
        public async Task<IActionResult> Products()
        {
            string email = User.Identity.Name;
            Customer customer = await CustomerController.getCustomerByEmail(email);
            ViewBag.customer = customer ;
            // create a list of buildings for customer and stor in viewbag
            var buildingList = await ProductsController.getBuildingListForCustomer(customer.id);
            ViewBag.buildingList = buildingList;
            // creqte a list of batteries and store in Viewbag
            var batteryList = await ProductsController.getBatteryListForBuilding(customer.id);
            ViewBag.batteryList = batteryList;
            // create a list od columns and store in Viewbag
            var columnList = await ProductsController.getColumnListForBattery(customer.id);
            ViewBag.columnList = columnList;
            // create a list of Elevators and store in Viewbag
            var elevatorList = await ProductsController.getElevatorListForColumn(customer.id);
            ViewBag.elevatorList = elevatorList;


            System.Console.WriteLine(email);
            // ViewBag.email = getLoggedInUserEmail();
            return View();
        }
        //Post from product management
        // [Authorize]
        [HttpPost]
        public async Task<IActionResult> intervention(Intervention predefinedIntervention)
        {
            long? customerID = predefinedIntervention.customer_id;
            long? buildingID = predefinedIntervention.building_id;
            long? batteryID = predefinedIntervention.battery_id;
            long? columnID = predefinedIntervention.column_id;
            long? elevatorID = predefinedIntervention.elevator_id;
           
            // print intervention form data
            System.Console.WriteLine("-------------------------------------------------------------");    
            System.Console.WriteLine(predefinedIntervention.author);
            System.Console.WriteLine("-------------------------------------------------------------");    


            //put information in viewbag
            ViewBag.buildingID = buildingID;
            ViewBag.batteryID = batteryID;
            ViewBag.columnID = columnID;
            ViewBag.elevatorID = elevatorID;

            ViewBag.interventionUrl = CustomerController.ApiURL("interventions");
            
            string email = User.Identity.Name;
            Customer customer = await CustomerController.getCustomerByEmail(email);
            ViewBag.customer = customer ;
            // create a list of buildings for customer and stor in viewbag
            var buildingList = await ProductsController.getBuildingListForCustomer(customer.id);
            ViewBag.buildingList = buildingList;
            // creqte a list of batteries and store in Viewbag
            var batteryList = await ProductsController.getBatteryListForBuilding(customer.id);
            ViewBag.batteryList = batteryList;
            // create a list od columns and store in Viewbag
            var columnList = await ProductsController.getColumnListForBattery(customer.id);
            ViewBag.columnList = columnList;
            // create a list of Elevators and store in Viewbag
            var elevatorList = await ProductsController.getElevatorListForColumn(customer.id);
            ViewBag.elevatorList = elevatorList;

            

            return View();
        }
        [Authorize]
        public async Task<IActionResult> intervention()
        {
            string email = User.Identity.Name;
            Customer customer = await CustomerController.getCustomerByEmail(email);
            ViewBag.customer = customer ;
            // create a list of buildings for customer and stor in viewbag
            var buildingList = await ProductsController.getBuildingListForCustomer(customer.id);
            ViewBag.buildingList = buildingList;
            // creqte a list of batteries and store in Viewbag
            var batteryList = await ProductsController.getBatteryListForBuilding(customer.id);
            ViewBag.batteryList = batteryList;
            // create a list od columns and store in Viewbag
            var columnList = await ProductsController.getColumnListForBattery(customer.id);
            ViewBag.columnList = columnList;
            // create a list of Elevators and store in Viewbag
            var elevatorList = await ProductsController.getElevatorListForColumn(customer.id);
            ViewBag.elevatorList = elevatorList;


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
            if(BuildingList.Count > 0)
            {
            var test3 = BuildingList[0].address_of_the_building;
            Console.WriteLine(test3);
            }
            else
            {
                Building Building0 = new Building();
                Building0.address_of_the_building = "no buildings yet";
                BuildingList.Add(Building0);
            }

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