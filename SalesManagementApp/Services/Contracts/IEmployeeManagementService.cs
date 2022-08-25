using SalesManagementApp.Entities;
using SalesManagementApp.Models;

namespace SalesManagementApp.Services.Contracts
{
    public interface IEmployeeManagementService
    {
        Task<List<EmployeeModel>> GetEmployees();
        Task<List<EmployeeJobTitle>> GetJobTitles();
    }
}
