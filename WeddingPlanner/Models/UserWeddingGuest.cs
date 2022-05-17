using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingPlanner.Models
{
    public class UserWeddingGuest
    {
        [Key]
        public int UserWeddingGuestId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /**********************************************************************
        Relationship properties below

        Foreign Keys: id of a different (foreign) model.

        Navigation props:
            data type is a related model
            MUST use .Include or else nav props will be null.
        **********************************************************************/

        public int UserId { get; set; }
        public User Guest { get; set; } = null!;
        public int WeddingId { get; set; }
        public Wedding Wedding { get; set; } = null!;
    }
}