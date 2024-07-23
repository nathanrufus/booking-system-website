using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookingSystem.Models
{
    public class Facility
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Block { get; set; }
        public int Floor { get; set; }
        public string Description { get; set; }
        public TimeSpan OpenTime { get; set; }
        public TimeSpan CloseTime { get; set; }
    }
}
