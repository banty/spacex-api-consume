using System;
namespace SpaceX.Applicaiton.Exceptions
{
	public class NotFoundExcption:Exception
	{
		public NotFoundExcption():base("Launch not found")
		{
		}
        public NotFoundExcption(string message) : base(message)
        {
        }
        public NotFoundExcption(string message,Exception innerException) : base(message,innerException)
        {
        }
    }
}

