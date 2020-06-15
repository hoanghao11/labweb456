using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class AttendanceController : ApiController
    {
        private ApplicationDbContext _dbContext;
        public AttendanceController()
        {
            _dbContext = new ApplicationDbContext();

        } 

        [HttpPost]
       
        public IHttpActionResult Attend(Attendance attendanceDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Attendances.Any(a => a.AttendeeID == userId && a.CourseID == attendanceDto.CourseID))
                return BadRequest("The Attendance already exists");
            var attendance = new Attendance
            {
                CourseID = attendanceDto.CourseID,
                AttendeeID = userId


            };
            _dbContext.Attendances.Add(attendance);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
