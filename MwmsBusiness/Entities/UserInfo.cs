using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MwmsBusiness
{
    public class UserInfo
    {
        public virtual int Id { get; set; }
        public virtual string FullName { get; set; }
        public virtual string Location { get; set; }
    }
}
