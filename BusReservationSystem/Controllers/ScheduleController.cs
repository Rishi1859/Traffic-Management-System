using Bus.DataLayer;
using Bus.DomainModels;
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
    public class ScheduleController : Controller
    {
        private readonly ILogger<ScheduleController> _logger;
        private readonly IConfiguration _configuration;
        string apiurl;
        private readonly BusDbContext _db;

        public ScheduleController(ILogger<ScheduleController> logger, IConfiguration configuration, BusDbContext db)
        {
            _logger = logger;
            _configuration = configuration;
            apiurl = _configuration.GetValue<string>("WebAPIBaseUrlSchedule");
            _db = db;
        }

        public async Task<IActionResult> Index(int PageNo = 1)
        {
            var res = new List<Trip>();
            using (HttpClient client = new HttpClient())
            {
                using (var response = await client.GetAsync(apiurl))
                {
                    var apiresponse = await response.Content.ReadAsStringAsync();
                    res = JsonConvert.DeserializeObject<List<Trip>>(apiresponse);
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
            var res = new Trip();
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync($"{apiurl}/{id}"))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        res = JsonConvert.DeserializeObject<Trip>(apiResponse);
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
        //{
        //    //ViewBag.RouteId = _db.Trips.Ro
        //    //return View();
        //}

        [HttpPost]
        public async Task<IActionResult> Create(Trip trip)
        {
            var resTrip = new Trip();
            using (var client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(trip), Encoding.UTF8, "application/json");
                using (var response = await client.PostAsync(apiurl, content))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    resTrip = JsonConvert.DeserializeObject<Trip>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var tripData = new Trip();
            using (HttpClient client = new HttpClient())
            {
                using (var response = await client.GetAsync($"{apiurl}/{id}"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    tripData = JsonConvert.DeserializeObject<Trip>(apiResponse);
                }
            }
            return View(tripData);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Trip trip)
        {
            var tripData = new Trip();
            using (var client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(trip), Encoding.UTF8,
                    "application/json");
                using (var response = await client.PutAsync($"{apiurl}/{id}", content))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    tripData = JsonConvert.DeserializeObject<Trip>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteTrip(int id)
        {
            var tripData = new Trip();
            using (HttpClient client = new HttpClient())
            {
                using (var response = await client.DeleteAsync($"{apiurl}/{id}"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    tripData = JsonConvert.DeserializeObject<Trip>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
