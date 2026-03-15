using Microsoft.Identity.Client;

namespace carseller1.Services.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string message) : base(message) 
        { 
        
        }
    }
}
