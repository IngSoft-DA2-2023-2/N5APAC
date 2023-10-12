namespace PAC.Tests.WebApi;
using System.Collections.ObjectModel;

using System.Data;
using Moq;
using PAC.IBusinessLogic;
using PAC.Domain;
using PAC.WebAPI;
using Microsoft.AspNetCore.Mvc;

[TestClass]
public class StudentControllerTest
{
    private Student estudiante;
    private Mock<IStudentLogic> mock;
    private StudentController api;


    [TestInitialize]
    public void InitTest()
    {
        mock = new Mock<IStudentLogic>(MockBehavior.Strict);
        api = new StudentController(mock.Object);
    }

    [ExpectedException(typeof(NullReferenceException))]
    [TestMethod]
    public void PostStudentOk()
    {
         estudiante = new Student();
         estudiante.Id = 1;
         estudiante.Name = "Maria Perez";

         mock.Setup(x => x.InsertStudents(estudiante));
         var result = api.CrearEstudiante(estudiante);
         var objectResult = result as ObjectResult;
         var statusCode = objectResult.StatusCode;

         mock.VerifyAll();
         Assert.AreEqual(200, statusCode);
    }

    [ExpectedException(typeof(NullReferenceException))]
    [TestMethod]
    public void PostStudentFail()
    {
        estudiante = new Student();
        estudiante = null;
        mock.Setup(c => c.InsertStudents(estudiante)).Throws(new NullReferenceException());
        var result = api.CrearEstudiante(estudiante);
        var objectResult = result as ObjectResult;
        var statusCode = objectResult.StatusCode;

        mock.VerifyAll();
        Assert.AreEqual(400, statusCode);
    }
}
