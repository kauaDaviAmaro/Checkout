using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public enum Status
    {
        Pending,
        Completed
    }

    public class Purchase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public required int Quantity { get; set; }
        public required DateTime Date_Purchased { get; set; }
        public required Status Status { get; set; }

        public required Product Product { get; set; }
        public required User User { get; set; }
        public required Contact Contact { get; set; }
        public required Address Address { get; set; }
        public required Payment Payment { get; set; }

        public Purchase()
        {
            Status = Status.Pending;
        }
    }
}