namespace Philcosa.Application.Features.CoverValues.Queries.GetById
{
    public class GetCoverValueByIdResponse
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public decimal? MinValue { get; set; }
        public decimal? MaxValue { get; set; }
    }
}