﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NGK_Handin3.Models
{
    public class Account
    {
        [Key]
        public long AccountId { get; set; }       
        public string Email { get; set; }        
        public string PwHash { get; set; }
        public bool IsWeatherStation { get; set; }
    }
}
