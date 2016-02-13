using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HippoBilling.Service
{
    public class OrderBy
    {
        public int Column { get; set; }
        public string Direction { get; set; }

        public OrderBy(int column, string direction)
        {
            Column = column;
            Direction = direction;
        }

        public bool IsAsc()
        {
            return "asc".Equals(this.Direction, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}