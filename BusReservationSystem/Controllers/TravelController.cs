using Bus.DataLayer;
using Bus.DomainModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    public class TravelController : Controller
    {
        private readonly ILogger<TravelController> _logger;
        private readonly IConfiguration _configuration;
        string apiurl;
        private readonly BusDbContext _db;

        public TravelController(ILogger<TravelController> logger, IConfiguration configuration, BusDbContext db)
        {
            _logger = logger;
            _configuration = configuration;
            apiurl = _configuration.GetValue<string>("WebAPIBaseUrl");
            _db = db;
        }

        //[Authorize(Roles="Admin")]
        public async Task<IActionResult> Index(string search= "",int PageNo = 1)
        {
            var bus = new List<BusDetails>();
           
            using (HttpClient client = new HttpClient())
            {
                using (var response = await client.GetAsync(apiurl))
                {
                    var apiresponse = await response.Content.ReadAsStringAsync();
                    bus = JsonConvert.DeserializeObject<List<BusDetails>>(apiresponse);
                }
            }

            ViewBag.search = search;
            bus = _db.Buses.Where(e => e.BusName.Contains(search)).ToList();

            //Paging
            int noOfRecPerPage = 6;
            int noOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(bus.Count) / Convert.ToDouble(noOfRecPerPage)));
            int noOfRecToSkip = (PageNo - 1) * noOfRecPerPage;
            ViewBag.NoOfPages = noOfPages;
            ViewBag.PageNo = PageNo;
            bus = bus.Skip(noOfRecToSkip).Take(noOfRecPerPage).ToList();

            return View(bus);
        }

        public async Task<IActionResult> Details(string id)
        {
            var bus = new BusDetails();
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync($"{apiurl}/{id}"))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        bus = JsonConvert.DeserializeObject<BusDetails>(apiResponse);
                    }
                    else
                    {
                        ViewBag.StatusCode = response.StatusCode;
                    }
                }
            }
            return View(bus);

        }
        public ViewResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(BusDetails busDetails)
        {
            var resbus = new BusDetails();
            using (var client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(busDetails), Encoding.UTF8, "application/json");
                using (var response = await client.PostAsync(apiurl, content))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    resbus = JsonConvert.DeserializeObject<BusDetails>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(string id)
        {
            var busdata = new BusDetails();
            using (HttpClient client = new HttpClient())
            {
                using (var response = await client.GetAsync($"{apiurl}/{id}"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    busdata = JsonConvert.DeserializeObject<BusDetails>(apiResponse);
                }
            }
            return View(busdata);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, BusDetails busDetails)
        {
            var busdata = new BusDetails();
            using (var client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(busDetails), Encoding.UTF8,
                    "application/json");
                using (var response = await client.PutAsync($"{apiurl}/{id}", content))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    busdata = JsonConvert.DeserializeObject<BusDetails>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteBus(string id)
        {
            var busdata = new BusDetails();
            using (HttpClient client = new HttpClient())
            {
                using (var response = await client.DeleteAsync($"{apiurl}/{id}"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    busdata = JsonConvert.DeserializeObject<BusDetails>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }

    }
}
