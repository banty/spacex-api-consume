using System;
namespace SpaceX.Applicaiton.Exceptions
{
	public class InvalidIdException:Exception
	{
		public InvalidIdException():base("Invalid Launch Id Provided.")
		{
			
		}
		
		public InvalidIdException(string message):base(message)
		{

		}


        public InvalidIdException(string message,Exception ex) : base(message,ex)
        {

        }


    }
}

