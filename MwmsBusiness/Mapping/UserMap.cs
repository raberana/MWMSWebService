using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MwmsBusiness.Mapping
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("User");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.UserName);
            Map(x => x.Password);
            Map(x => x.ClientId);
        }
    }
}
