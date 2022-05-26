using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Api.Models
{
    public class Ticket
    {
        #region Properties
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Created { get; set; }

        //public DateTime Deadline { get; set; }

        public Engineer Engineer { get; set; }
        #endregion

        #region Constructors
        public Ticket()
        {
            Created = DateTime.Now;
        }

        public Ticket(string title, string description) : this()
        {
            Title = title;
            Description = description;
        }
        #endregion

        #region Methods
        #endregion
    }
}