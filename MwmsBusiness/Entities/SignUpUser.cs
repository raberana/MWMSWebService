﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MwmsBusiness
{
    public class SignUpUser : User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ClientId { get; set; }
        public string ClientName { get; set; }
    }
}