//EXCEPTION LAYER

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentService.exception
{
    //here i am creating custom exception and inherited to Exception class
   public class LibraryException : Exception
    {
        //here i am doing constructor chaining
        public LibraryException() : base()
            {
            Console.WriteLine("OOppss something wents wrong!!");
            }
        public LibraryException(string Message) : base(Message)
        {
            Console.WriteLine("OOppss something wents wrong!!");
        }
        public LibraryException(string Message,Exception InnerException ) 
        {

        }
       
        static void Main(string[] args)
        {

        }
    }
}
