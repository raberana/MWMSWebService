using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MwmsBusiness
{
    public class User
    {
        public virtual int Id { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual string ClientId { get; set; }
        public virtual string ClientName { get; set; }
        public virtual UserInfo Info { get; set; }
        public virtual IList<MeasuredData> Data { get; set; }

        public User()
        {
            Info = new UserInfo() { FullName = "Roj Pogi", Location = "Sa puso mo" };
            Data = new List<MeasuredData>() { 
                new MeasuredData(){ Amount = 34.0, Timestamp = System.DateTime.Now}, 
                new MeasuredData(){ Amount = 35.0, Timestamp = System.DateTime.Now}};
        }
    }
}
