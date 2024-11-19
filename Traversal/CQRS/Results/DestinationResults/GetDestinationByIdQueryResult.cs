namespace Traversal.CQRS.Results.DestinationResults
{
    public class GetDestinationByIdQueryResult
    {
        public int DestinationId { get; set; }
        public string City { get; set; }
        public string Daynight { get; set; }
        public double Price { get; set; }
    }
}
