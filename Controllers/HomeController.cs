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

namespace CustomerPortal.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Authorize]
        public async Task<IActionResult> Index()
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

            List<Battery> activeBatteries = new List<Battery>();
            List<Column> activeColumns = new List<Column>();
            List<Elevator> activeElevators = new List<Elevator>();
            
            foreach(Battery battery in batteryList)
            {
                if (battery.status.ToLower() == "active")
                {
                    activeBatteries.Add(battery);
                }
            }
            ViewBag.activeBatteries = activeBatteries.Count() ;
            ViewBag.BatteriesTotal = batteryList.Count();
            


            return View();
        }

        // public async Task<IActionResult> Privacy()
        // {
        //     //call buildings for customer 3 test function
        //     var buildinglist = await ProductsController.getBuildingListForCustomer(3);
            

        //     // call customerlist to test function
        //     var customerList = await CustomerController.getCustomerList();
        //     return View();
        // }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
