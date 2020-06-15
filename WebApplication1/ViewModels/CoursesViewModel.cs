using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class CoursesViewModel
    {
        public IEnumerable<Course> UpCommingCourses { get; set; }
        public bool ShowAction{ get; set; }
        
    }
    


}