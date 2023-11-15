namespace SolarSystemAPI.Models;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
public class CelestialBody
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; } 
    
    
    [Required(ErrorMessage = "Name is required")]
    [StringLength(30, ErrorMessage = "Name must not exceed 30 characters.")]
    [BsonElement("name")]
    public string? Name { get; set; }
    
    [BsonElement("mass")]
    public double Mass { get; set; } // Mass in kilograms
    
    [BsonElement("distance from sun in AU")]
    public double DistanceFromSun { get; set; } // Earth is approximately 1 AU from the Sun
    
    [BsonElement("diameter")]
    public double Diameter { get; set; }
    
    
    
    
    
}