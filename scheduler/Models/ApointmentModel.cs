using MessagePack;
using scheduler.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace scheduler.Models
{
    public class ApointmentModel
    {
        [System.ComponentModel.DataAnnotations.Key] 
        public int ApointmentId { get; set; }
        public schedulerUser UserId { get; set; }
        public string ApointmentName { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
