using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MwmsBusiness
{
    public class MeasuredData
    {
        public virtual int Id { get; set; }
        public virtual DateTime Timestamp { get; set; }
        public virtual double Amount { get; set; }
    }
}
