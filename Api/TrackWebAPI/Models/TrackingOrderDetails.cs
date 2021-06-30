using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackWebAPI.Models
{
    public class TrackingOrderDetails
    {
        public int SNo { get; set; }

        public int OrderId { get; set; }
        public DateTime ShipmentDate { get; set; }

        public DateTime DeliveryDate { get; set; }
    }
}