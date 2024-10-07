using OnlineShop.BusinessLayer.Managers;
using OnlineShop.Constants;
using OnlineShop.Data.Entities;
using OnlineShop.Entities;
using OnlineShop.BusinessLayer.Validators;

namespace OnlineShop.BusinessLayer.Services
{
    public class EmployeeService
    {
        private InputManager _inputManager = new();
        private InputValidator _inputValidator = new();
        private OutputManager _outputManager = new();
        private IDGenerator _generatorID = new();
        private CommonEntityService<Employee> _commonEntityService = new();

        private List<Employee> employees = new List<Employee>()
        {
           new(1, 34894, "EmployeeName1", "EmployeeSurName1"),
           new(2, 34314, "EmployeeName2", "EmployeeSurName2")
        };
        public Employee CreateEmployee()
        {
            int userID = _generatorID.InputID(employees);
            ulong inn = 11;//_inputManager.InputINN(_inputValidator, _commonEntityService.GetListType());
            string name = _inputManager.InputName(_inputValidator, _commonEntityService.GetListType());
            string surname = _inputManager.InputName(_inputValidator, _commonEntityService.GetListType());
            return new Employee(userID, inn, name, surname);
        }
        public void AddEmployee()
        {
            employees.Add(CreateEmployee());
            _outputManager.OutputToConsole(NotificationConstants.ADDED, _commonEntityService.GetListType());
        }
        public void RemoveemployeeID(int employeeID)
        {
            var employee = employees.FirstOrDefault(employee => employee.UserID == employeeID);
            if (employee != null)
            {
                employees.Remove(employee);
                _outputManager.OutputToConsole(NotificationConstants.DELETED, _commonEntityService.GetListType());
            }
            else
            {
                _outputManager.OutputToConsole(NotificationConstants.NOT_FOUND, _commonEntityService.GetListType());
            }
        }
        public User Updatebuyer(int employeeID)
        {
            var employee = employees.FirstOrDefault(employee => employee.UserID == employeeID);
            if (employee == null)
            {
                _outputManager.OutputToConsole(NotificationConstants.NOT_FOUND, _commonEntityService.GetListType());
            }
            return employee;
        }
        public Employee GetEmployeeByID()
        {
            var employeeID = _inputManager.InputID(_inputValidator, _commonEntityService.GetListType());
            var employee = employees.FirstOrDefault(employee => employee.UserID == employeeID);
            if (employee == null)
            {
                _outputManager.OutputToConsole(NotificationConstants.NOT_FOUND, _commonEntityService.GetListType());
            }
            return employee;
        }
        public void OutputEmployees()
        {
            _outputManager.OutputToConsole(_commonEntityService.OutputList(employees), _commonEntityService.GetListType());
        }
    }
}
