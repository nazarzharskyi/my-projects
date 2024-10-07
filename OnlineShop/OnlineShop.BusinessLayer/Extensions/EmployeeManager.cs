using OnlineShop.Data;
using OnlineShop.Data.Entities;
using OnlineShop.Entities;
using OnlineShop.EntityServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OnlineShop.BusinessLayer.Extensions
{
    static class EmployeeManager
    {
        public static void addDataToEmployee(this Employee employee, string position, string hiredate, string salary, string inn, string name, string surname, string phoneNumber, string userBirthDate, string address)
        {
            //public Employee(int employeeId, string position, DateOnly hiredate, uint salary, ulong inn, string name, string surname, string phoneNumber, DateOnly userBirthDate, string address)

            employee.EmployeeId = JsonController<Employee>.LoadIndexer();
            JsonController<Employee>.SaveIndexer(employee.EmployeeId + 1);

            employee.Name = InputCheck.GetString(name);
            employee.Surname = InputCheck.GetString(surname);
            employee.PhoneNumber = InputCheck.GetPhoneNumber(phoneNumber);
            employee.INN = InputCheck.GetINN(inn);
            employee.Address = InputCheck.GetString(address);
            employee.UserBirthDate = InputCheck.GetDataOnly(userBirthDate);
            employee.HireDate = InputCheck.GetDataOnly(hiredate);
            employee.Salary = InputCheck.GetPriceUint(salary);
            employee.Position = InputCheck.GetString(position);
        }
    }
}
