﻿using System.Text.Json.Serialization;

namespace ApiCatalogo.Models
{
    public class Volume
    {
        public int VolumeId { get; set; }

        public int Pieces { get; set; }
        public decimal Weight { get; set; }
        public decimal Lenght { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }


        //[JsonIgnore]
        public string? OrderId { get; set; }

        [JsonIgnore]
        public virtual Order? Order { get; set; }
    }
}
