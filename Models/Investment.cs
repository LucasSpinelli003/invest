using System;
using System.ComponentModel.DataAnnotations;

namespace InvestApi.Models
{
    public class Investment
    {
        [Key]
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int InvestorId { get; set; }
        public int CompanyId { get; set; }

        public Investor Investor { get; set; }
        public Company Company { get; set; }
    }
}
