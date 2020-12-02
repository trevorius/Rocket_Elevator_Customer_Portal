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
using CustomerPortal.Controllers;

namespace CustomerPortal.Controllers
{
    public class ProductsController : Controller
    {
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