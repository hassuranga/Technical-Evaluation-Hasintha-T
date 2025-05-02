using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace LeaveTracker.DAL
{
    public class LeaveDAL
    {
        private readonly string _connectionString;

        public LeaveDAL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("sqlConn");
        }

        public List<LeaveRequest> GetAllLeaveRequests()
        {
            var list = new List<LeaveRequest>();
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetAllLeaveRequests", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new LeaveRequest
                {
                   
                    EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                    StartDate = Convert.ToDateTime(reader["StartDate"]),
                    EndDate = Convert.ToDateTime(reader["EndDate"]),
                    
                });
            }
            return list;
        }

        public LeaveRequest GetLeaveRequestById(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetLeaveRequestById", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Id", id);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new LeaveRequest
                {
                   
                    EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                    StartDate = Convert.ToDateTime(reader["StartDate"]),
                    EndDate = Convert.ToDateTime(reader["EndDate"]),
                   
                };
            }
            return null;
        }

        public void AddLeaveRequest(LeaveRequest leave)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_AddLeaveRequest", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@EmployeeId", leave.EmployeeId);
            cmd.Parameters.AddWithValue("@StartDate", leave.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", leave.EndDate);
           
            conn.Open();
            cmd.ExecuteNonQuery();
        }

       
    }
}
