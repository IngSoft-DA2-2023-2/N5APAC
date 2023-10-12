using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PAC.Domain;
using PAC.IBusinessLogic;
using PAC.WebAPI.Filters;

namespace PAC.WebAPI
{

    [ApiController]
    [Route("api/students")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentLogic servicioStudent;

        public StudentController(IStudentLogic servicioStudent)
        {
            this.servicioStudent = servicioStudent;
        }

        [HttpGet]
        public IActionResult ObtenerEstudiantes([FromQuery] int? edad)
        {
            return Ok(servicioStudent.GetStudents(edad));
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerEstudiantePorId([FromRoute] int id)
        {
            return Ok(servicioStudent.GetStudentById(id));
        }

        [ServiceFilter(typeof(AuthorizationFilter))]
        [HttpPost()]
        public IActionResult CrearEstudiante([FromBody] Student estudiante)
        {
            servicioStudent.InsertStudents(estudiante);
            return Ok();
        }
    }
}
