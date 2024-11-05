using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InvestApi.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Industry { get; set; }
        public ICollection<Investment> Investments { get; set; }
    }
}
