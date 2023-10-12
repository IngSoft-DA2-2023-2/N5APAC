using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PAC.WebAPI.Filters
{
    public class ExceptionFilter : Attribute, IExceptionFilter
    {

        public void OnException(ExceptionContext context)
        {
            try
            {
                throw context.Exception;
            }
            catch (ArgumentNullException e)
            {
                context.Result = new ObjectResult(new { e.Message }) { StatusCode = 400 };
            }
            
            catch (Exception e)
            {
                Console.WriteLine($"Mensaje: {e.Message} - Seguimiento de pila: {e.StackTrace}");

                context.Result = new ObjectResult(new
                { Message = "Se encontraron problemas. Vuelve a intentarlo más tarde." })
                { StatusCode = 500 };
            }
        }
    }
}
