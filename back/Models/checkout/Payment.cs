using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Payment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public required string PaymentMethod { get; set; }
        public required Dictionary<string, string> Details { get; set; }
        public string? Note { get; set; }
    }
}