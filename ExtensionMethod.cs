using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentService.bll
{
    static class ExtensionMethod
    {
        //extension method to check Username contain Alphabets or not
        //if it conatin Alphabets return true else return false
        //extension method for string class
        public static bool Check(this string Name)
        {
            bool Validation = true;
            char[] name = Name.ToCharArray();
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] >= 'a' && name[i] <= 'z' || name[i] >= 'A' && name[i] <= 'Z')
                {
                    Validation = true;
                }
                else
                {
                    Validation = false;
                    break;
                }
            }
            return Validation;
        }

        //extension method for string class
        //extension method to check Password contain 5 lower case Alphabets,1 special character ,1 Upper Case Alphabets
        //if it match above condition returns true else false

        public static bool Password(this string Password)
        {
            int LowerCase = 0;
            int UpperCase = 0;
            int SpecialCharacter = 0;
            char[] name = Password.ToCharArray();
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] >= 'a' && name[i] <= 'z')
                {
                    LowerCase++;
                }
                else if (name[i] >= 'A' && name[i] <= 'Z')
                {
                    UpperCase++;
                }
                else if (!(name[i] >= 'a' && name[i] <= 'z') && !(name[i] >= 'A' && name[i] <= 'Z') && !(name[i] >= '0' && name[i] <= '9'))
                {
                    SpecialCharacter++;
                }
            }
            if (LowerCase > 4 && UpperCase > 0 && SpecialCharacter > 0)
            {
                return true;
            }
            return false;
        }



    }
}
