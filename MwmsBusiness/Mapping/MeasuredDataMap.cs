using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MwmsBusiness.Mapping
{
    public class MeasuredDataMap : ClassMap<MeasuredData>
    {
        public MeasuredDataMap()
        {
            Table("MeasuredData");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Timestamp);
            Map(x => x.Amount);
        }
    }
}
