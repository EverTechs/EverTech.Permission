using System.Collections.Generic;

namespace EverTech.Permission.Libs
{
    public class PageResult<T>
    {
        public int Total { get; set; }
        public List<T> DataList { get; set; }
    }
}
