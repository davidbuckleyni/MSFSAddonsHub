﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MSFSAddonsHub.Dal.Models
{
   public class AirPortsViewModel
    {

        public int Id { get; set; }

        public string? ICAO { get; set; }

        public string? Name { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }
        [Column(TypeName = "decimal(18,9)")]
        public decimal? LongX { get; set; }
        [Column(TypeName = "decimal(18,9)")]
        public decimal? LatY { get; set; }

        public IEnumerable<IFormFile>? Files { get; set; }

        public int? Version { get; set; }

        public bool? isActive { get; set; }

        public bool? isDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }
    }
}
