﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ESL.Api.Models.BusinessEntities;
using ESL.Api.Models.DAL;

namespace ESL.Api.Controllers
{
    [Route("api/[controller]")] // /[action]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            // Maps to string _sql = "ESL.ESL_EMPLOYEELIST_PROC";

            return await _context.Employees.Where(e => e.Disable != "Y").Distinct().OrderBy(e => e.LastName).ThenBy(e => e.FirstName).Take(40).AsNoTracking().ToListAsync();
        }

        [HttpGet("LogTypeList")]
        public async Task<ActionResult<IEnumerable<LogType>>> GetLogTypes()
        {
            return await _context.LogTypes.AsNoTracking().ToListAsync();
        }

        [HttpGet("Plants")]
        public async Task<ActionResult<IEnumerable<Facil>>> GetPlants()
        {
            return await _context.Facilities.Where(f => f.FacilNo <= 13).Select(x => new Facil() { FacilNo = x.FacilNo, FacilName = x.FacilName, FacilAbbr = x.FacilAbbr}).OrderBy(o => o.FacilNo).AsNoTracking().ToListAsync();
        }

        //[HttpGet("{facilNo}")]
        //public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeListByFacilNo(int facilNo)
        //{
        //    return await _context.Employees.Where(e => e.FacilNo == facilNo && e.Disable == null).Distinct().OrderBy(e => e.LastName).ThenBy(e => e.FirstName).Take(40).AsNoTracking().ToListAsync();
        //}

        // GET: api/Employees/5
        [HttpGet("Employee/{employeeNo}")]
        public async Task<ActionResult<Employee>> GetEmployee(int employeeNo)
        {
            // Maps to string _sql = $"SELECT * FROM ESL.ESL_EMPLOYEES WHERE EMPLOYEENO = {employeeNo}";

            var employee = await _context.Employees.FindAsync(employeeNo);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // GET: LastName,FirstName
        [HttpGet("{employeeName}")]
        public async Task<ActionResult<Employee>> GetEmployee(string? employeeName)
        {
            //var employee = null;
            
            // LastName,FirstName format
            if (!string.IsNullOrEmpty(employeeName))
            {
                string firstName = employeeName.Split(',')[1];
                string lastName = employeeName.Split(',')[0];

                // Maps to string _sql = $"SELECT * FROM ESL.ESL_EMPLOYEES WHERE EMPLOYEENO = {employeeNo}";

                return await _context.Employees.Where(e => e.FirstName.ToUpper() == firstName.ToUpper() && e.LastName.ToUpper() == lastName.ToUpper()).FirstOrDefaultAsync();
            }

            return NotFound();
        }

        // PUT: api/Employees/5
        // PUT in this method does NOT maintain previos records.
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[Route("Update")]
        [HttpPut("Update/{employeeNo}")]
        public async Task<IActionResult> PutEmployee(int employeeNo, [FromBody] Employee employee)
        {
            if (employeeNo != employee.EmployeeNo)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(employeeNo))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Create")]
        public async Task<ActionResult<Employee>> PostEmployee([FromBody] Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { employeeNo = employee.EmployeeNo }, employee);
        }

        // DELETE: api/Employees/5
        // Delete in this method does NOT keep previous records.
        //[Route("Delete")]
        [HttpDelete("Remove/{employeeNo}")]
        public async Task<IActionResult> DeleteEmployee(int employeeNo)
        {
            var employee = await _context.Employees.FindAsync(employeeNo);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //[Route("GetEmpFullName")]
        //[HttpGet("{employeeNo}")]
        //public async Task<string> GetEmpFullName(int employeeNo)
        //{
        //    Employee emp = await _context.Employees.FindAsync(employeeNo);

        //    return $"{emp?.FirstName} {emp?.LastName}";
        //}



        private async Task<int> GetEmpID(string fullName)
        {
            var _names = fullName.Split(' ');
            string _firstName = _names[0];
            string _lastName = _names[1];

            return await _context.Employees.Where(e => EF.Functions.Like($"e.FirstName? e.LastName?", fullName)).Select(x => x.EmployeeNo).FirstOrDefaultAsync();
        }

        private async Task<string> GetEmpName(int? employeeNo)
        { 
           if (employeeNo == null)
            {
                return "Employee No cannot be empty.";
            }
            
            //var _names = fullName.Split(' ');
            //string _firstName = _names[0];
            //string _lastName = _names[1];

            return await _context.Employees.Where(e => e.EmployeeNo == employeeNo).Select(emp => $"emp.FirstName? emp.LastName?").FirstOrDefaultAsync();
        }

        private bool EmployeeExists(int employeeNo)
        {
            return _context.Employees.Any(e => e.EmployeeNo == employeeNo);
        }

    }   
}
