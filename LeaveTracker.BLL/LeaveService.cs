using LeaveTracker.DAL;

using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
namespace LeaveTracker.BLL
{
    public class LeaveService
    {
        private readonly LeaveDAL _leaveDAL;
        private readonly EmployeeService _employeeService;

        public LeaveService(IConfiguration configuration)
        {
            _leaveDAL = new LeaveDAL(configuration);
            _employeeService = new EmployeeService();
        }

        public List<LeaveRequest> GetAll() => _leaveDAL.GetAllLeaveRequests();

        public LeaveRequest GetById(int id) => _leaveDAL.GetLeaveRequestById(id);

        public string AddLeaveRequest(LeaveRequest leave)
        {
            var all = _leaveDAL.GetAllLeaveRequests();

         
            bool selfOverlap = all.Any(l =>
                l.EmployeeId == leave.EmployeeId &&
                (
                    (leave.StartDate >= l.StartDate && leave.StartDate <= l.EndDate) ||
                    (leave.EndDate >= l.StartDate && leave.EndDate <= l.EndDate) ||
                    (leave.StartDate <= l.StartDate && leave.EndDate >= l.EndDate)
                )
            );

            if (selfOverlap)
            {
                return "You already have a leave request that overlaps with this date range.";
            }

           
            

            
            _leaveDAL.AddLeaveRequest(leave);
            return "Success";
        }


    }
}
