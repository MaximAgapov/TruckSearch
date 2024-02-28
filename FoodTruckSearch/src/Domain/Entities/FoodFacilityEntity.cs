using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace FoodTruckSearch.Domain.Entities;

public class FoodFacilityEntity
{
    [Key]
    public int locationid { get; set; }
    public string? Applicant { get; set; }
    public string? FacilityType { get; set; }
    public int cnn { get; set; }
    public string? LocationDescription { get; set; }
    public string? Address { get; set; }
    public string? blocklot { get; set; }
    public string? block { get; set; }
    public string? lot { get; set; }
    public string? permit { get; set; }
    public string? Status { get; set; }
    public string? FoodItems { get; set; }
    public string? X { get; set; }
    public string? Y { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string? Schedule { get; set; }
    public string? dayshours { get; set; }
    public string? NOISent { get; set; }
    public string? Approved { get; set; }
    public int Received { get; set; }
    public int PriorPermit { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public string? Location { get; set; }
    public Point? Coordinates { get; set; }
}
