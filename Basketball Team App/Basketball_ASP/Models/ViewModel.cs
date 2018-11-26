using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Basketball_ASP.Models
{
    public class ViewModel
    {
        private List<Game> games;
        private int myVar;

        public List<Game> Games
        {
            get { return games; }
            set { games = value; }
        }

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

    }
}