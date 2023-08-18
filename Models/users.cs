using System;

namespace assessment.Models
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string username { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public Address address { get; set; } = new Address();
    }

    public class Address
    {
        public string street { get; set; } = string.Empty;
        public string suite { get; set; } = string.Empty;
        public string city { get; set; } = string.Empty;
        public string zipcode { get; set; } = string.Empty;
        public Geo geo { get; set; } = new Geo();
    }

    public class Geo
    {
        public string lat { get; set; } = string.Empty;
        public string lng { get; set; } = string.Empty;
    }
}
