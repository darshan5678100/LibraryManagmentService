//LOGIN ENTITY I AM ACCESS THIS CLASS MEMBER LIKE ARRAY MEMBERS﻿

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentService.dml
{
   public class Login
    {
          string AdminUsername="admin";
         string AdminPassword="admin";
         string Username;
         string Password;
        public int BookId1;
        public int BookId2;
        public int BookId3;
        public Login()
        { }
        public Login(string name,string password)
        {
            Username = name;
            Password = password;
            
        }
        //indexers to access class member like a array
        public object this[int index]
            {
            get
            {
                if (index == 0)
                    return AdminUsername;
                else if (index == 1)
                    return AdminPassword;
                else if (index == 2)
                    return Username;
                else if (index == 3)
                    return Password;
                return null;
            }
            }
    }
}
