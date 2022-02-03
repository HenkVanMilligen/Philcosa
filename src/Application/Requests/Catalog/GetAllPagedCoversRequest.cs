namespace Philcosa.Application.Requests.Catalog
{
    public class GetAllPagedCoversRequest : PagedRequest
    {
        public string SearchString { get; set; }
    }
}