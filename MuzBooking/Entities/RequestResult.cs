namespace MuzBooking.Entities
{
    public class RequestResult
    {
        public bool Ok { get; set; }
        public int Amount { get; set; }
        public string? Error { get; set; }
    }
}