//ITS BUSINESS LOGIC LAYER

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagmentService.dml;
using LibraryManagmentService.exception;

namespace LibraryManagmentService.bll
{
    public class BusinessLogicLayer
    {
      static  DataModelLayer Data = new DataModelLayer();
       
        //Admin method to check validations of admin username and password to ADMIN LOGIN
            public  bool Admin(string Username,string Password)
        {
            // i am using CHECK() EXTENSION METHOD OF STRING CLASS to check
            //username contains only alphabets or not
            if (Username.Check() && Password.Length>4 && Password.Length<15)
            {
                return Data.Admin(Username, Password);
            }
            return false;
        }

        //User method to check validations of user username and password to USER LOGIN
        public  bool User(string Username,string Password)
        {
            // i am using CHECK() EXTENSION METHOD OF STRING CLASS to check
            //username contains only alphabets or not and PASSWORD() EXTENSION METHOD
            //OF STRING  CLASS to check Password contain 5 lower case Alphabets,1 special character ,1 Upper Case Alphabets
            if (Username.Check() && Password.Length>6 && Password.Length<15 && Password.Password())
            {
                return Data.User(Username, Password);
            }
            return false;
        }

        //User method to check validations of user username and password to USER REGISTRATION
        public bool CheckUser(string Username,string Password)
        {
            if (Username.Check() && Password.Length > 6 && Password.Length < 15 && Password.Password())
            {
                return true;
            }
            return false;
        }

        // Addbook method to check validations to ADD BOOK inside collection
        public  void AddBook(int id,string name,int copies,string status,DateTime date,string author)
        {
            if (id > 0 && id < 100)
            {
                // i am using CHECK() EXTENSION METHOD OF STRING CLASS to check
                //book name contains only alphabets or not 
                if (name.Check() && author.Check() && name.Length>2 && name.Length<15 && author.Length>2 && author.Length<15)
                {
                    if (copies > 0 && copies < 200)
                    {
                        if (status.Equals("new") || status.Equals("old"))
                        {
                            Data.AddBook(id, name, copies, status, date, author);
                        }
                        else
                            throw new LibraryException("enter  valid status");
                        //here i am throwing custom exception
                    }
                    else
                        throw new LibraryException("enter valid copies");
                    //here i am throwing custom exception
                }
                else
                    throw new LibraryException("enter valid bookname or author name");
            }
            else
                throw new LibraryException("enter valid book id");
        }

        //bookRemove method to check validations to REMOVE BOOK from collection
        public bool bookRemove(int id)
        {
            if(id>0 && id<100)
            {
     return  Data.RemoveBook(id);
            }
            return false;
        }

        //Search method to check validations to DISPLAY SINGLE BOOK from collection
        public Book Search(int id)
        {
            if(id>0 && id<101)
            {
                return Data.Search( id);
            }
            return null;
        }

        //DisplayAll method to check validations to DISPLAY ALL BOOK from collection
        public List<Book> DisplayAll()
        {
            return Data.DisplayAll();
        }

        //UpadateBook method to check validations to UPDATE BOOK from collection
        public bool UpdateBook(int id,string value,string value1)
        {
            if(id>0 && id<101)
            {
                // i am using CHECK() EXTENSION METHOD OF STRING CLASS to check
                //user enter column name contains only alphabets or not
                if (value.Check() && value.Length>0)
                {
                    if (value == "bookname")
                    {
                        // i am using CHECK() EXTENSION METHOD OF STRING CLASS to check
                        //book name contains only alphabets or not
                        if (value1.Check() && value1.Length > 0 && value1.Length < 15)
                        {
                            Data.Update(id, value, value1);
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("enter valid book name");
                            return false;
                        }
                    }
                    else if (value == "copies")
                    {
                        int copies = int.Parse(value1);
                        if (copies > 0 && copies < 200)
                        {
                            Data.Update(id, value, value1);
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("enter valid copies");
                            return false;
                        }
                    }
                    else if (value == "status")
                    {
                        if (value1 == "new" || value1 == "old")
                        {
                            Data.Update(id, value, value1);
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("enter valid status");
                        }
                    }
                    else if (value == "author")
                    {
                        // i am using CHECK() EXTENSION METHOD OF STRING CLASS to check
                        // author name contains only alphabets or not
                        if (value1.Check())
                        {
                            Data.Update(id, value, value1);
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("enter valid author name");
                            return false;
                    }
                    }
                    else
                    {
                        Console.WriteLine("enter valid column name");
                    }
                    
                }
            }
            return false;
        }

        //Adduser method check validations FOR ADDING USER TO LOGIN
        public bool Adduser(string Username,string Password)
        {
            // i am using CHECK() EXTENSION METHOD OF STRING CLASS to check
            //username contains only alphabets or not and PASSWORD() EXTENSION METHOD
            //OF STRING  CLASS to check Password contain 5 lower case Alphabets,1 special character ,1 Upper Case Alphabets
            if (Username.Check() && Password.Password())
            {
            return  Data.Adduser(Username, Password);
            }
            return false;
        }
        //RequestBook method check validaations FOR REQUSTING BOOK TO ADMIN FROM USER
        public bool RequestBook(int id1,int id2,int id3,string bookname)
        {
            if (id1 > 0 && id1 < 20 && id2 >=0 && id2 < 20 && id3 >=0 && id3 <20)
            {
                Data.RequestBook(id1, id2, id3,bookname);
                return true;
            }
            else
            {
                Console.WriteLine("book id not present");
            }
            return false;
        }

        //IssueBook method check validations TO ISSUE BOOK FROM USER TO ADMIN
        public List<Book> IssueBook(int id1,int id2,int id3,string user)
        {
            return Data.Issue(id1, id2, id3,user);
        }

        //Transcation method check validations TO DISPLAY ISSUED BOOK
        public List<Book> Transcation(string username)
        {
            return Data.Transcaton(username);
        }



        static void Main(string[] args)
        {
        }
    }
}
