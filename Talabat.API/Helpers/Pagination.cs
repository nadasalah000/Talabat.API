using Talabat.API.DTOs;

namespace Talabat.API.Helpers
{
    public class Pagination<T>
    {
        private int? pageIndex;
        public Pagination(int? pageIndex, int pageSize, IReadOnlyList<T> data, int count)
        {
            this.pageIndex = pageIndex;
            PageSize = pageSize;
            Data = data;
            Count = count;
        }

        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int Count { get; set; }
        public IReadOnlyList<T> Data { get; set; }
    }
}
