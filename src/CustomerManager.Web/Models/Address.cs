﻿namespace CustomerManager.Web.Models
{
	public class Address
	{
        public int Id { get; set; }
        public string Street { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public bool IsDefault { get; set; } = false;
        public int CustomerId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
