using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gazprom.Models
{
    public class FilteredBT
    {
        public IEnumerable<Business_trip> BusinessTrips { get; set; }
        public SelectList TimeFilter { get; set; }
        public int id_access { get; set; }
    }
}