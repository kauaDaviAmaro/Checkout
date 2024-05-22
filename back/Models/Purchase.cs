using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Purchase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public required Product Product { get; set; }
        public required User User { get; set; }
        public int Quantity { get; set; }
        public DateTime Date_Purchased { get; set; }
    }
}