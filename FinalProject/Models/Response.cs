﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class ResponseData
    {
        public String Status  { get; set; }
        public Exception Error { get; set; }
        public dynamic Data { get; set; }
    }
}