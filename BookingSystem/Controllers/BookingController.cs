using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using BookingSystem.Models;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Collections.Generic;
using MongoDB.Bson;


namespace BookingSystem.Controllers
{
    public class BookingController : Controller
    {
        private readonly IMongoCollection<Booking> _bookingCollection;
        private readonly IMongoCollection<Facility> _facilityCollection;

        public BookingController(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("MongoDb"));
            var database = client.GetDatabase(configuration["DatabaseName"]);
            _bookingCollection = database.GetCollection<Booking>("Bookings");
            _facilityCollection = database.GetCollection<Facility>("Facilities");
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> BookFacility()
        {
            var facilities = await _facilityCollection.Find(_ => true).ToListAsync();
            return View(facilities);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(Booking booking)
        {
            await _bookingCollection.InsertOneAsync(booking);
            return RedirectToAction("ViewBookings");
        }

        public async Task<IActionResult> ViewBookings()
        {
            var bookings = await _bookingCollection.Find(_ => true).ToListAsync();
            return View(bookings);
        }

        public async Task<IActionResult> AmendBooking(string id)
        {
            var booking = await _bookingCollection.Find(b => b.Id == new ObjectId(id)).FirstOrDefaultAsync();
            return View(booking);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBooking(Booking updatedBooking)
        {
            await _bookingCollection.ReplaceOneAsync(b => b.Id == updatedBooking.Id, updatedBooking);
            return RedirectToAction("ViewBookings");
        }
    }
}
