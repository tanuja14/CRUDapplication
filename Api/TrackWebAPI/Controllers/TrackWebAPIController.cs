using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
//using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
//using System.Web.Mvc;
using TrackWebAPI.Models;

namespace TrackWebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [System.Web.Http.RoutePrefix("")]


    public class TrackWebAPIController : ApiController
    {
        string str = "Data Source=localhost\\SQLEXPRESS01; initial catalog=MyTest_DB; Trusted_Connection=True;";
        public IHttpActionResult GetTrackingDetails()
        {
            List<TrackingOrderDetails> trackingDetails = new List<TrackingOrderDetails>();
            using (SqlConnection con = new SqlConnection(str))
            {

                string query = @"Select SNo,OrderID,ShipmentDate,DeliveryDate from TrackingDetails;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {

                    con.Open();
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        trackingDetails.Add(new TrackingOrderDetails
                        {

                            SNo = Convert.ToInt32(dr["SNo"]),
                            OrderId = Convert.ToInt32(dr["OrderId"]),
                            ShipmentDate = Convert.ToDateTime(dr["ShipmentDate"]),
                            DeliveryDate = Convert.ToDateTime(dr["DeliveryDate"])
                        });

                    }
                    con.Close();
                }



            }

            return Ok(trackingDetails);
        }
        [HttpPost]
        [Route("api/TrackWebAPI/SaveTrackingDetails")]
        public IHttpActionResult SaveTrackingDetails(TrackingOrderDetails t)
        {
            List<TrackingOrderDetails> trackingDetails = new List<TrackingOrderDetails>();
            using (SqlConnection con = new SqlConnection(str))
            {

                string query = Convert.ToString(t.SNo) == "" ? @"SaveTrackingDetails": @"UpdateTrackingDetails";
                SqlParameter param = new SqlParameter();

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    if (Convert.ToString(t.SNo) != "")
                    {
                        cmd.Parameters.Add("@SNo", SqlDbType.Int);
                        cmd.Parameters["@SNo"].Value = t.SNo;
                    }
                    cmd.Parameters.Add("@OrderID", SqlDbType.Int);
                    cmd.Parameters["@OrderID"].Value = t.OrderId;

                    cmd.Parameters.Add("@ShipmentDate", SqlDbType.DateTime);
                    cmd.Parameters["@ShipmentDate"].Value = t.ShipmentDate;

                    cmd.Parameters.Add("@DeliveryDate", SqlDbType.DateTime);
                    cmd.Parameters["@DeliveryDate"].Value = t.DeliveryDate;

                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return Ok("Record Saved");
            }

        }

        [HttpPost]
        [Route("api/TrackWebAPI/DeleteTrackingDetails")]
        public IHttpActionResult DeleteTrackingDetails(TrackingOrderDetails t)
        {
            List<TrackingOrderDetails> trackingDetails = new List<TrackingOrderDetails>();
            using (SqlConnection con = new SqlConnection(str))
            {

                string query = @"DeleteTrackingDetails";
                SqlParameter param = new SqlParameter();

                using (SqlCommand cmd = new SqlCommand(query, con)) {

                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.Add("@SNo", SqlDbType.Int);
                        cmd.Parameters["@SNo"].Value = t.SNo;

                    cmd.ExecuteNonQuery();
                    con.Close();

                }

                return Ok("Record Deleted");
            }
        }
    }
}
