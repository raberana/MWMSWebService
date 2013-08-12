﻿using FluentNHibernate.Mapping;
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
            Table("Users");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.UserName);
            Map(x => x.Password);
            Map(x => x.ClientName);
            Map(x => x.ClientId);
            HasMany(x => x.Data)
                .KeyColumn("ClientId")
                .Inverse()
                .Cascade.AllDeleteOrphan();
        }
    }
}
