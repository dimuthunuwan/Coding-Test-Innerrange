namespace full_stack.Models
{
    public class PagedRequest
    {
        //The page to return
        public int Page { get; set; }

        //The number of rows to return
        public int PageSize { get; set; }
    }
}
