using Microsoft.EntityFrameworkCore;
using SalesManagementApp.Data;
using SalesManagementApp.Entities;
using SalesManagementApp.Extensions;
using SalesManagementApp.Models;
using SalesManagementApp.Services.Contracts;

namespace SalesManagementApp.Services
{
    public class EmployeeManagementService : IEmployeeManagementService
    {
        private readonly SalesManagementDbContext salesManagementDbContext;

        public EmployeeManagementService(SalesManagementDbContext salesManagementDbContext)
        {
            this.salesManagementDbContext = salesManagementDbContext;
        }
        public async Task<List<EmployeeModel>> GetEmployees()
        {
            try
            {
                return await this.salesManagementDbContext.Employees.Convert();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<EmployeeJobTitle>> GetJobTitles()
        {
            try
            {
                return await this.salesManagementDbContext.EmployeeJobTitles.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
