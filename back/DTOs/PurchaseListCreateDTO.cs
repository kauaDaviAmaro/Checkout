namespace Checkout.DTOs
{
    public class PurchaseListCreateDTO
    {
        public int UserId { get; set; }
        public int PaymentId { get; set; }
        public int AddressId { get; set; }
        public int ContactId { get; set; }

        public required List<PurchaseItemDTO> Purchases { get; set; }

        public class PurchaseItemDTO
        {
            public int ProductId { get; set; }
            public int Quantity { get; set; }
        }
    }
}