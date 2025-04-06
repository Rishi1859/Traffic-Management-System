using Bus.DataLayer;
using Bus.DomainModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BusReservationSystem.Controllers
{
    public class RouteController : Controller
    {
        private readonly ILogger<RouteController> _logger;
        private readonly IConfiguration _configuration;
        string apiurl;
        private readonly BusDbContext _db;

        public RouteController(ILogger<RouteController> logger, IConfiguration configuration, BusDbContext db)
        {
            _logger = logger;
            _configuration = configuration;
            apiurl = _configuration.GetValue<string>("WebAPIBaseUrlRoute");
            _db = db;
        }

        public async Task<IActionResult> Index(string search = "", int PageNo = 1)
        {
            var res = _db.Routes.Where(e => e.FromLocation.Contains(search)).ToList();

            //var res = new List<Route>();
            using (HttpClient client = new HttpClient())
            {
                using (var response = await client.GetAsync(apiurl))
                {
                    var apiresponse = await response.Content.ReadAsStringAsync();
                    res = JsonConvert.DeserializeObject<List<Route>>(apiresponse);
                }
            }

            //Paging
            int noOfRecPerPage = 6;
            int noOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(res.Count) / Convert.ToDouble(noOfRecPerPage)));
            int noOfRecToSkip = (PageNo - 1) * noOfRecPerPage;
            ViewBag.NoOfPages = noOfPages;
            ViewBag.PageNo = PageNo;
            res = res.Skip(noOfRecToSkip).Take(noOfRecPerPage).ToList();

            return View(res);
        }

        public async Task<IActionResult> Details(string id)
        {
            var res = new Route();
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync($"{apiurl}/{id}"))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        res = JsonConvert.DeserializeObject<Route>(apiResponse);
                    }
                    else
                    {
                        ViewBag.StatusCode = response.StatusCode;
                    }
                }
            }
            return View(res);
        }

        public ViewResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Route route)
        {
            var resRoute = new Route();
            using (var client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(route), Encoding.UTF8, "application/json");
                using (var response = await client.PostAsync(apiurl, content))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    resRoute = JsonConvert.DeserializeObject<Route>(apiResponse);
                }
            }
            // ViewData["BusId"] = new SelectList(_db.Buses, "ID", "ID", );
            ViewBag.list = new SelectList(_db.Routes.Include(r => r.FromLocation), "FromLocation");
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(string id)
        {
            var routeData = new Route();
            using (HttpClient client = new HttpClient())
            {
                using (var response = await client.GetAsync($"{apiurl}/{id}"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    routeData = JsonConvert.DeserializeObject<Route>(apiResponse);
                }
            }
            return View(routeData);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, Route route)
        {
            var routeData = new Route();
            using (var client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(route), Encoding.UTF8,
                    "application/json");
                using (var response = await client.PutAsync($"{apiurl}/{id}", content))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    routeData = JsonConvert.DeserializeObject<Route>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteRoute(string id)
        {
            var routeData = new Route();
            using (HttpClient client = new HttpClient())
            {
                using (var response = await client.DeleteAsync($"{apiurl}/{id}"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    routeData = JsonConvert.DeserializeObject<Route>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
