﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Entites;
using Talabat.Core.Repositories;
using Talabat.Core.Specifications;

namespace Talabat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IGenericRepository<Employee> _employeeRepo;

        public EmployeeController(IGenericRepository<Employee> EmployeeRepo)
        {
            _employeeRepo = EmployeeRepo;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var Spec = new EmployeeWithDepartmentSpecifictions();

            var Employee = await _employeeRepo.GetAllWithSpecAsync(Spec);
            return Ok(Employee);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            var Spec = new EmployeeWithDepartmentSpecifictions(id);
            var Employee = await _employeeRepo.GetEntityWithSpecAsync(Spec);
            return Ok(Employee);
        }
    }
}
