using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MwmsBusiness.Mapping
{
    public class UserInfoMap : ClassMap<UserInfo>
    {
        public UserInfoMap()
        {
            Table("UserInfo");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.FullName);
            Map(x => x.Location);
        }
    }
}
