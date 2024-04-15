namespace SeasonPass.Module.Common.Models;

public interface IPagedRequest
{
    public long Reference { get; set; }

    public int PageSize { get; set; }
}
