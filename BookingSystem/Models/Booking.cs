using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace BookingSystem.Models
{
    public class Booking
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Facility { get; set; }
        public string Block { get; set; }
        public int Floor { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string BookedBy { get; set; }
        public string Contact { get; set; }
        public string AdditionalInfo { get; set; }
    }
}
