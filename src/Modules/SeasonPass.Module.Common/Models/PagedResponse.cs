using SeasonPass.Core.Models;

namespace SeasonPass.Module.Common.Models;

public interface IPagedResponse<T>
    where T : EntityBase
{
    IList<T> Records { get; }

    long Reference { get; }

    int PageSize { get; }

    bool HasNext { get; }
}

/// <summary>
/// Implementation assumes loading one extra record to determine if next page is available
/// e.g. load 21 records (page size = 20); rely on the extra record to check next page, skip last one in records
/// </summary>
public class PagedResponse<T> : IPagedResponse<T>
    where T : EntityBase
{
    public IList<T> Records { get; init; }

    public long Reference { get; init; }

    public int PageSize { get; init; }

    public bool HasNext { get; init; }

    public PagedResponse(IEnumerable<T> records, int pageSize)
    {
        // by design records should contain one extra record if next page is available thus we trim it to the page size;
        var page = records.Take(pageSize).ToList();

        Reference = page.Count > 0 ? page.Last().Id : 0;
        HasNext = records.Count() > pageSize;
        Records = page;
        PageSize = pageSize;
    }
}
