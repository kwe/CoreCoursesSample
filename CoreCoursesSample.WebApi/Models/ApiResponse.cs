﻿using CoreCoursesSample.WebApi.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCoursesSample.WebApi.Models
{
    public class ApiResponse
    {
        public bool Status { get; set; }
        public Course Course { get; set; }
        public ModelStateDictionary ModelState { get; set; }
    }
}