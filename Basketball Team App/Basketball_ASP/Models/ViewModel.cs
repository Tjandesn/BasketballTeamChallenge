using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Basketball_ASP.Models
{
    public class ViewModel
    {
        public List<AspNetUser> AspNetUsers { get; set; }
        public AspNetUser AspNetUser { get; set; }
        public List<Game> Games { get; set; }
        public Game Game { get; set; }
    }
}