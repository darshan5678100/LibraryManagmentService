using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LibraryManagmentService.dml
{
  public  class DataModelLayer
    {
        //to store user
        static List<Login> UserList = new List<Login>();
        //to store book 
        static List<Book> BookList = new List<Book>();
        //to store requested book
    public  static List<Book> RequestedBook= new List<Book>();
        //creating object for Login class to access login members with index
        Login login = new Login();

        //Admin method to check admin username and password matching or not
        public  bool Admin(string Username,string Password)
        {
            //here i am comparing user enter username with Login class AdminUsername
            //here i am accessing Login class AdminUsername with index by creating indexers in Login class 

            //here i am comparing user enter password with Login class AdminPassword
            //here i am accessing Login class AdminPassword with index by creating indexers in Login class 
            if (Username ==(string)login[0]  && Password == (string)login[1])
                return true;
            else
                return false;
        }

        //User method to check User username and password matching or not
        public bool User(string Username,string Password)
        {
            bool UserLogin = false;
            foreach (var user in UserList)
            {
                 if((string)user[2]==Username && (string)user[3]==Password)
                {
                   UserLogin=true;
                    return UserLogin;
                }
            }
            return UserLogin;
        }

        //AddBook method to add the book inside the collection 
        public  bool AddBook(int id,string name,int copies,string status,DateTime date,string author)
        { 
             BookList.Add(new Book(id, name, copies, status, date, author));
                 return true;
      
        }
        //Search method to search book from the collection
        public Book Search(int id)
        {
            return  BookList.Find(a => a.BookId == id);
        }
        //DisplayAll method to display all books from collection
        public List<Book> DisplayAll()
        {
            return BookList;
        }
        //RemoveBook method to remove book from the collection
        public bool RemoveBook(int id)
        {
            Book BookList1 = BookList.Find(a => a.BookId == id);
            BookList.Remove(BookList1);
            if (BookList1 == null)
            {
                return false;
            }
            return true;
        }
        //Update method to update the book from the collection
        public bool Update(int id,string value,string value1)
        {
            Book BookList1 = BookList.Find(a => a.BookId == id);
            if(value=="bookname")
            {
                BookList1.BookName = value1;
                return true;
            }
            else if(value=="copies")
            {
                BookList1.Copies = int.Parse(value1);
                return true;
            }
            else if(value=="status")
            {
                BookList1.Status = value1;
                return true;
            }
            else if(value=="date")
            {
                BookList1.Date = DateTime.Parse(value1);
                return true;
            }
            else if(value=="author")
            {
                BookList1.Author = value1;
                return true;
            }
            return false;
        }
        //Adduser method used to add user to UserList collection
        public bool Adduser(string UserName,string Password)
        {
            UserList.Add(new Login(UserName, Password));
            return true;
        }
        //RequestBook method to reuset the book from the collection
        public bool RequestBook(int id1,int id2,int id3,string User)
        {
            //here i am accessing user username name using index 
            Login Book1 = UserList.Find(a =>(string)a[2] == User);
            if (id1 != 0)
            {
                Book1.BookId1 = id1;
                Book BookList1 = BookList.Find(a => a.BookId == id1);
                if (id2 != 0)
                {
                    Book1.BookId2 = id2;
                    Book BookList2 = BookList.Find(a => a.BookId == id2);
                    if (id3 != 0)
                    {
                        Book1.BookId3 = id3;
                        Book BookList3 = BookList.Find(a => a.BookId == id3);
                        //here i am adding all books to requested book collection
                        RequestedBook.Add(BookList1);
                        RequestedBook.Add(BookList2);
                        RequestedBook.Add(BookList3);
                    }
                }
            }
            return true;
        }
        //Issue method used to issue the books from admin
        //here i am using return type as a LIST<BOOK> COLLECTION
         public List<Book> Issue(int id1,int id2,int id3,string User)
        {
            //here i am accessing user username name using index 
            Login Book1 = UserList.Find(a => (string)a[2] == User);
            int count = 0;
            List<Book> book11 = new List<Book>();
            Book book1 = BookList.Find(a => a.BookId == id1);
            book11.Add(book1);
            Book1.BookId1 = id1;
            Book1.BookId2 = id2;
            Book1.BookId3 = id3;
            count++;
            if (id2 != 0)
            {
                Book book2 = BookList.Find(a => a.BookId == id2);
                book11.Add(book2);
                count++;
            }
            if (id3 != 0)
            {
                Book book3 = BookList.Find(a => a.BookId == id3);
                book11.Add(book3);
                count++;
            }
            return book11;
        }
        //Transcation method used to display the books issued book in userbook
        //here i am using return type as a LIST<BOOK> COLLECTION
        public List<Book> Transcaton(string User)
        {
            int count = 0;
            List<Book> book11 = new List<Book>();
            //here i am accessing user username name using index 
            Login Book1 = UserList.Find(a => (string)a[2] == User);
            if (Book1.BookId1 != 0)
            {
                Book book1 = BookList.Find(a => a.BookId == Book1.BookId1);
                book11.Add(book1);
                count++;
            }
            if (Book1.BookId2 != 0)
            {
                Book book2 = BookList.Find(a => a.BookId == Book1.BookId2);
                book11.Add(book2);
                count++;
            }
            if (Book1.BookId3 != 0)
            {
                Book book3 = BookList.Find(a => a.BookId == Book1.BookId3);
                book11.Add(book3);
                count++;
            }
            return book11;

        }



        static void Main(string[] args)
        {
        }
    }
}
