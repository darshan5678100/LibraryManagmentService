using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagmentService.bll;
using LibraryManagmentService.exception;
using LibraryManagmentService.dml;

namespace LibraryManagmentService
{
    class Program
    {
        static BusinessLogicLayer Business = new BusinessLogicLayer();
        static string Userid;
        static string UserPassword;
         static int RequestedId1 = 0, RequestedId2 = 0, RequestedId3 = 0;
        static int IssuedId1 = 0, IssuedId2 = 0, IssuedId3 = 0;
          static string TrancationUser;
       static int Validation = 0;
        static int Validation1 = 0;


        // method to User login
        public static bool User()
        {
            Console.WriteLine("enter the user name : ");
            string Username = Console.ReadLine();
            TrancationUser = Username;
            Console.WriteLine("enter the password : ");
            string Password = Console.ReadLine();
            if (Business.User(Username, Password))
            {
                Console.WriteLine("Login successfully");
                return true;
            }
            else
                Console.WriteLine("invalid username or password !!!");
            return false;
        }

        //admin login method
        public static bool Admin()
        {
            Console.WriteLine("enter the user name : ");
            string Username = Console.ReadLine();
            Username = Username.ToLower();
            Console.WriteLine("enter the password : ");
            string Password = Console.ReadLine();
            Password = Password.ToLower();
            if (Business.Admin(Username, Password))
            {
                Console.WriteLine("login successfully!!!");
                return true;
            }
            else
            {
                Console.WriteLine("enter valid username or password!!");
                return false;
            }
        }

        //method to add book
        public static void AddBook()
        {
            Console.WriteLine("enter book id ");
            int BookId = int.Parse(Console.ReadLine());
            Console.WriteLine("enter book name");
            string BookName = Console.ReadLine();
            Console.WriteLine("enter book copies");
            int BookCopies = int.Parse(Console.ReadLine());
            Console.WriteLine("enter book status");
            string Status = Console.ReadLine();
            Console.WriteLine("enter date");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("enter author name");
            string Author = Console.ReadLine();
            Business.AddBook(BookId, BookName, BookCopies, Status, date, Author);
            Console.WriteLine("book added successfully");
        }

        //method to remove book
        public static void RemoveBook()
        {
            Console.WriteLine("enter book id");
            int Id = int.Parse(Console.ReadLine());
            if (Business.bookRemove(Id))
            {
                Console.WriteLine("book removed successfully");
            }
            else
            {
                Console.WriteLine("enter valid values");
            }
        }

        //method to update book
        public static void UpdateBook()
        {
            Console.WriteLine("enter book id to update");
            int BookId = int.Parse(Console.ReadLine());
            Console.WriteLine("enter column to update");
            string value = Console.ReadLine();
            value = value.ToLower();
            Console.WriteLine("enter value to update");
            string value1 = Console.ReadLine();
            if (Business.UpdateBook(BookId, value, value1))
            {
                Console.WriteLine("book updated successfully");
            }
            else
            {
                Console.WriteLine("check values....");
            }
           
        }

        //method to search single book
        public static void Search()
        {
            Console.WriteLine("enter valid id");
            int Id = int.Parse(Console.ReadLine());
            Book value = Business.Search(Id);
            if (value != null)
            {
                Console.Write("Book Id : ");
                Console.WriteLine(value.BookId);
                Console.Write("Book name : ");
                Console.WriteLine(value.BookName);
                Console.Write("Book copies : ");
                Console.WriteLine(value.Copies);
                Console.Write("Book status : ");
                Console.WriteLine(value.Status);
                Console.Write("Book dates : ");
                Console.WriteLine(value.Date.ToShortDateString());
                Console.Write("Book author : ");
                Console.WriteLine(value.Author);
            }
            else
            {
                Console.WriteLine("book Id is not present");
            }
        }

        //method to display all book
        public static void Display()
        {
            int validation = 0;
            List<Book> book = Business.DisplayAll();
            foreach (var value in book)
            {
                validation = 1;
                Console.Write("Book Id : ");
                Console.WriteLine(value.BookId);
                Console.Write("Book name : ");
                Console.WriteLine(value.BookName);
                Console.Write("Book copies : ");
                Console.WriteLine(value.Copies);
                Console.Write("Book status : ");
                Console.WriteLine(value.Status);
                Console.Write("Book dates : ");
                Console.WriteLine(value.Date.ToShortDateString());
                Console.Write("Book author : ");
                Console.WriteLine(value.Author);
                Console.WriteLine("=============================");
            }
                if(validation!=1)
                    Console.WriteLine("no book found");
            
        }

        //method to Add user
        public static void AddUser(string username, string password)
        {
            if (username != null)
            {
                Console.WriteLine(username + " requested for user login id");
                Console.WriteLine("username :" + Program.Userid);
                Console.WriteLine("password : " + Program.UserPassword);

                Console.WriteLine("press 1 to add user ");
                Console.WriteLine("press 2 to exit");
                int Userid = int.Parse(Console.ReadLine());
                if (Userid == 1)
                {
                    if (Business.Adduser(username, password))
                    {
                        Console.WriteLine("user added successfully");
                    }
                    else
                        Console.WriteLine("user not added opps!!!");
                }
                else
                    Console.WriteLine("thank you");
            }
            else
            {
                Console.WriteLine("no Request for Adding user");
            }
        }

        //method use to send request to admin to add user
        public static void UserRegistration()
        {
            Console.WriteLine("enter user name");
            string name = Console.ReadLine();
            Console.WriteLine("enter password");
            Console.WriteLine("password should contain one Upper case,One special chatacter,minimum 5 lower case");
            string password = Console.ReadLine();
            Console.WriteLine("confirm password");
            string password1 = Console.ReadLine();
            if (password == password1)
            {
                if (Business.CheckUser(name, password))
                {
                    Console.WriteLine("request sent to user thank u!!!");
                    Userid = name;
                    UserPassword = password;
                }
                else
                    Console.WriteLine("enter valid username or password");
            }
            else
            {
                Console.WriteLine("password is not matching");
            }
        }
        //method to requesting book from user
        public static void RequestBook()
        {
            int k = 0;
            int i = 0;
            int j = 0;
            while (k < 4)
            {
                Console.WriteLine("enter book id to request");
                int BookId = int.Parse(Console.ReadLine());
                k++;
                i++;
                if (i == 1)
                {
                    RequestedId1 = BookId;
                }
                if (i == 2)
                {
                    RequestedId2 = BookId;
                }
                if (i == 3)
                {
                    RequestedId3= BookId;
                }
                if (i == 4)
                {
                    Console.WriteLine("u can request only 3 books at a time");
                    throw new LibraryException("u requseted more then 3 books");
                }
                Console.WriteLine("to request another book press 1");
                Console.WriteLine("to end request press 4");
                j = int.Parse(Console.ReadLine());
                if (j == 4)
                    k = j;
            }
            if (Business.RequestBook(RequestedId1,RequestedId2,RequestedId3,TrancationUser))
            {
                Console.WriteLine("requset send to admin successfully");
                Validation = 1;
            }
            else
            {
                Console.WriteLine("check the book id");
            }

        }
        //method to issue book from admin
        public static void Issue()
        {
            if (Validation == 1)
            {
                List<Book> book11 = Business.IssueBook(RequestedId1, RequestedId2, RequestedId3, TrancationUser);
                Console.WriteLine("====================requested books are=========");
                foreach (var value in book11)
                {
                    Console.Write("Book Id : ");
                    Console.WriteLine(value.BookId);
                    Console.Write("Book name : ");
                    Console.WriteLine(value.BookName);
                    Console.Write("Book copies : ");
                    Console.WriteLine(value.Copies);
                    Console.Write("Book status : ");
                    Console.WriteLine(value.Status);
                    Console.Write("Book dates : ");
                    Console.WriteLine(value.Date);
                    Console.Write("Book author : ");
                    Console.WriteLine(value.Author);
                    Console.WriteLine("+++++++++++++++++++++++++");
                }
                if (RequestedId1 != 0)
                {
                    Console.WriteLine("enter " + RequestedId1 + " to issue book of id" + RequestedId1 + "  else enter 0");
                    IssuedId1 = int.Parse(Console.ReadLine());
                }
                if (RequestedId2 != 0)
                {
                    Console.WriteLine("enter " + RequestedId2 + " to issue book of id" + RequestedId2 + " else enter 0");
                    IssuedId2 = int.Parse(Console.ReadLine());
                }
                if (RequestedId3 != 0)
                {
                    Console.WriteLine("enter " + RequestedId3 + " to issue book of id" + RequestedId3 + " else enter 0");
                    IssuedId3 = int.Parse(Console.ReadLine());
                }
                Business.IssueBook(IssuedId1, IssuedId2, IssuedId3, Userid);
                Console.WriteLine("book issued successfully");
                Validation1 = 1;
            }
            else
            {
                Console.WriteLine("no books are requested");
            }
        }

        //method to display transcation book in user 
        static void Transcation()
        {
            if (Validation1 == 1)
            {
                List<Book> book11 = Business.Transcation(TrancationUser);
                Console.WriteLine("==========================issued books are=================");
                foreach (var value in book11)
                {
                    Console.Write("Book Id : ");
                    Console.WriteLine(value.BookId);
                    Console.Write("Book name : ");
                    Console.WriteLine(value.BookName);
                    Console.Write("Book copies : ");
                    Console.WriteLine(value.Copies);
                    Console.Write("Book status : ");
                    Console.WriteLine(value.Status);
                    Console.Write("Book dates : ");
                    Console.WriteLine(value.Date);
                    Console.Write("Book author : ");
                    Console.WriteLine(value.Author);
                    Console.WriteLine("+++++++++++++++++++++++++");
                }
                RequestedId1 = 0;
                RequestedId2 = 0;
                RequestedId3 = 0;
                IssuedId1 = 0;
                IssuedId2 = 0;
                IssuedId3 = 0;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("========no transcation yet====");
                Console.ForegroundColor = ConsoleColor.Black;
            }
        }
        //this our main method
        static void Main(string[] args)
        {

            try
            {
                int continoue = 1;
                while (continoue==1)
                {
                    try
                    {

                        Console.WriteLine("=========welcome to Library==========");
                        Console.WriteLine("enter 1 for Admin login");
                        Console.WriteLine("enter 2 for User login");
                        Console.WriteLine("enter 3 for User registartion");

                        //here i am taking input from the user and passing to the switch

                        int user = int.Parse(Console.ReadLine());
                        string repeat = "0";
                        switch (user)
                        {
                            case 1:
                                //here i am calling admin method for login if admin method return true
                                //it will go inside the switch else it go outside switch block
                                if (Admin())
                                {
                                    while (repeat == "0")
                                    {
                                        Console.WriteLine("enter 1 to add book");
                                        Console.WriteLine("enter 2 to remove book");
                                        Console.WriteLine("enter 3 to update book");
                                        Console.WriteLine("enter 4 to search book");
                                        Console.WriteLine("enter 5 to display all book");
                                        Console.WriteLine("enter 6 to Add user");
                                        Console.WriteLine("enter 7 to issue book");
                                        int value = int.Parse(Console.ReadLine());
                                        //here i am taking input from the user and passing to the nesstered switch
                                        switch (value)
                                        {
                                            case 1:
                                        //if user enter 1 control while come to case 1 here i am calling
                                        //AddBook method to add book inside the List<book> collection
                                                AddBook();
                                                break;
                                            case 2:
                                                //if user enter 2 control while come to case 2 here i am calling
                                                //RemoveBook method to remove the book from List<book> collection
                                                RemoveBook();
                                                break;
                                            case 3:
                                                //if user enter 3 control while come to case 3 here i am calling
                                                //UpdateBook method to update the book present inside the List<book> collection
                                                UpdateBook();
                                                break;
                                            case 4:
                                                //if user enter 4 control while come to case 4 here i am calling
                                                //Search  method to display single book from the List<book> collection
                                                Search();
                                                break;
                                            case 5:
                                                //if user enter 5 control while come to case 5 here i am calling
                                                //Display method to display all book from  the List<book> collection
                                                Display();
                                                break;
                                            case 6:
                                                //if user enter 6 control while come to case 6 here i am calling
                                                //AddUser method to add user 
                                                AddUser(Userid, UserPassword);
                                                break;
                                            //if user enter 7 control while come to case 7 here i am calling
                                            //Issue method to issue book 
                                            case 7:Issue();
                                                break;
                                            default:
                                                //if user enter other then this number control while come to default here i am
                                                //print default message 
                                                //if user enter other then digits he will get exception i am handing extension below using try catch
                                                Console.WriteLine("enter valid digit");
                                                break;
                                        }
                                        //where i am asking  user to continoue in same page if he enter 0 it will contionue otherwise
                                        //it will go to home page
                                        Console.WriteLine("enter 0 to continoue as admin");
                                        Console.WriteLine("enter anything to exit");
                                        repeat = Console.ReadLine();
                                    }

                                }
                                break;
                            case 2:
                                //if user enter 2 control while come to case 2 here i am calling
                                //User method to login user if username  and password match it will inside
                                //if block
                                if (User())
                                {
                                    int UserRepeat = 0;
                                    while (UserRepeat == 0)
                                    {
                                        //here i am taking input from the user and passing to the nesstered switch

                                        Console.WriteLine("enter 1 to display all books");
                                        Console.WriteLine("enter 2 to request books");
                                        Console.WriteLine("enter 3 to transcation books");
                                        int UserValue = int.Parse(Console.ReadLine());
                                        switch (UserValue)
                                        {
                                            case 1:
                                                //if user enter 1 control while come to case 1 here i am calling
                                                //Display method to display all book from  the List<book> collection
                                                Display();
                                                break;
                                            case 2:
                                                //if user enter 2 control while come to case 2 here i am calling
                                                //RequestBook method to requset book as a user
                                                RequestBook();
                                                break;
                                            case 3:
                                                //if user enter 3 control while come to case 3 here i am calling
                                                //Transcation method to display issued books from admin
                                                Transcation();
                                                break;
                                        }
                                        //where i am asking  user to continoue in same page if he enter 0 it will contionue otherwise
                                        //it will go to home page
                                        Console.WriteLine("enter 0 to contionue as user");
                                        Console.WriteLine("enter 1 to exit");
                                   UserRepeat = int.Parse(Console.ReadLine());
                                    }
                                }
                                //user username or password while not match it while comehere exits else block
                                else
                                {
                                    Console.WriteLine("invalid user name or password");
                                }

                                break;

                            case 3:
                                //if user enter 3 control while come to case 3 here i am calling
                                //UserRegistration method to user registration
                                UserRegistration();
                                break;
                        }

                    }
                    //here i am handling exception with catch block and print exception message
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    //where i am asking  user to continoue in same page if he enter 1 it will contionue otherwise
                    //it will stop exicution
                    Console.WriteLine("enter anything to stop");
                    Console.WriteLine("enter 1 to home page");
                    continoue = int.Parse(Console.ReadLine());
                }
            }
            //here i am handling exception of home page with catch block and print exception message
            catch (Exception e)
            {
                Console.WriteLine("something went wrong");
            }

        }
    }
}
