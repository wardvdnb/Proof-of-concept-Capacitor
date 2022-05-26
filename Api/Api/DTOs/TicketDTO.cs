using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.DTOs
{
    public class TicketDTO
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public IList<EngineerDTO> Engineer { get; set; }
    }
}
