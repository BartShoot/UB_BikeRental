﻿namespace UB_BikeRental.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public VehicleType Type { get; set; }
    }
}
