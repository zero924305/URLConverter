using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace URLConverter.Models
{
    public class URLConverterModel
    {

        public string URLid { get; set; }
        public string UrlOriginal { get; set; } //should be our page
        public string NewUrl { get; set; } 
    }
}
