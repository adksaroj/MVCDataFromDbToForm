using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class EmployeesProcessor
    {
        public static int CreateEmployee(int employeeId, string firstName,
            string lastName, string emailAddress)
        {
            EmployeeDataModel data = new EmployeeDataModel
            {
                EmployeeId = employeeId,
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = emailAddress
            };

            string sql = @"insert into dbo.Employees (EmployeeId, FirstName, LastName, EmailAddress) 
                            values (@EmployeeId, @FirstName, @LastName, @EmailAddress);";
            // values represent parameters from EmployeeDataModel data

            return SqlDataAccess.SaveData(sql, data); //returns no of affercted rows
        }

        public static List<EmployeeDataModel> LoadEmployees()
        {
            string sql = @"select Id, EmployeeId, FirstName, LastName, EmailAddress
                            from dbo.Employees";
            return SqlDataAccess.LoadData<EmployeeDataModel>(sql);
        }
    }
}
