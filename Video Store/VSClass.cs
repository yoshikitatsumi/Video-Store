using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_Store
{
    public class VSClass
    {
        private string conString = @"Data Source=LAPTOP-J9EIJALS\SQLEXPRESS;Initial Catalog=VideoRental;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public SqlConnection con;

        // Constructor
        public VSClass()
        {
            con = new SqlConnection(conString);
        }

        // Method for showing customer
        public DataTable showcustomer()
        {
            DataTable customer = CreateTable();
            customer = ReadData(customer);
            return customer;
        }
        private DataTable CreateTable()
        {
            DataTable customer = new DataTable();
            // Our visual Data Base
            customer.Clear();
            customer.Columns.Add("CustID");
            customer.Columns.Add("FirstName");
            customer.Columns.Add("LastName");
            customer.Columns.Add("Address");
            customer.Columns.Add("Phone");
            // End of visual
            return customer;
        }
        private DataTable ReadData(DataTable customer)
        {

            con.Open();
            string query = "Select * from Customer order by CustID";
            SqlCommand command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                customer.Rows.Add(
                    reader["CustID"],
                    reader["FirstName"],
                    reader["LastName"],
                    reader["Address"],
                    reader["Phone"]
                    );

            }
            reader.Close();

            con.Close();
            return customer;
        }
        // Method - Add customer
        public DataTable addcustomer(string newCFName, string newCLName, string newCAddress, string newCPhone)
        {

            // this puts the parameters into the code so that the data in the text boxes is added to the database
            string NewCustomer = "INSERT INTO Customer (Firstname, Lastname, Address, Phone) VALUES (@Firstname, @Lastname, @Address, @Phone)";

            SqlCommand newdata = new SqlCommand(NewCustomer, con);

            newdata.Parameters.AddWithValue("@Firstname", newCFName);
            newdata.Parameters.AddWithValue("@Lastname", newCLName);
            newdata.Parameters.AddWithValue("@Address", newCAddress);
            newdata.Parameters.AddWithValue("@Phone", newCPhone);

            con.Open(); //open a connection to the database
                        //its a NONQuery as it doesn't return any data its only going up to the server
            newdata.ExecuteNonQuery(); //Run the QueryCustomer
            con.Close(); //Close a connection to the database
                         //a happy message box

            DataTable customer = CreateTable();
            customer = ReadData(customer);
            return customer;
        }
        // Method - Update customer
        public DataTable updatecustomer(string newCustID, string newCFName, string newCLName, string newCAddress, string newCPhone)
        {
            //this updates existing data in the database where the ID of the data equals the ID in the text box
            string updatestatement = "UPDATE Customer set Firstname=@Firstname, Lastname=@Lastname, Address=@Address, Phone=@Phone where CustID = @CustID";
            SqlCommand update = new SqlCommand(updatestatement, con);
            //create the parameters and pass the data from the textboxes
            update.Parameters.AddWithValue("@CustID", newCustID);
            update.Parameters.AddWithValue("@Firstname", newCFName);
            update.Parameters.AddWithValue("@Lastname", newCLName);
            update.Parameters.AddWithValue("@Address", newCAddress);
            update.Parameters.AddWithValue("@Phone", newCPhone);
            con.Open();
            //its NONQuery as data is only going up
            update.ExecuteNonQuery();
            con.Close();

            DataTable customer = CreateTable();
            customer = ReadData(customer);
            return customer;
        }

        // Method for deleting customer
        public DataTable deletecustomer(string newCustID)
        {
            con.Open();
            string DeleteCommand = "Delete Customer where CustID = @CustID";
            SqlCommand DeleteData = new SqlCommand(DeleteCommand, con);
            DeleteData.Parameters.AddWithValue("@CustID", newCustID);

            DeleteData.ExecuteNonQuery();
            con.Close();

            DataTable customer = CreateTable();
            customer = ReadData(customer);
            return customer;

        }
        // Method for showing movies 
        public DataTable showmovies()
        {
            DataTable movies = CreateTable2();
            movies = ReadData2(movies);
            return movies;
        }
        // Method - reset movies
        public DataTable resetmovies(string RMovieID, string RMYear, string MCopies, string MPlot, string RMTitle, string RMGenre, string MCost, string RMRating)
        {
            //this rest existing data in the database where the ID of the data equals the ID in the text box
            string resetstatement = "UPDATE Movies set Title=@Title, Year=@Year, Genre=@Genre, Rental_cost=@Rental_cost, Copies=@Copies, Plot=@Plot, Rating=@Rating where MovieID = @MovieID";
            SqlCommand update = new SqlCommand(resetstatement, con);
            //create the parameters and pass the data from the textboxes
            update.Parameters.AddWithValue("@MovieID", RMovieID);
            update.Parameters.AddWithValue("@Rating", RMRating);
            update.Parameters.AddWithValue("@Title", RMTitle);
            update.Parameters.AddWithValue("@Year", RMYear);
            update.Parameters.AddWithValue("@Rental_cost", MCost);
            update.Parameters.AddWithValue("@Copies", MCopies);
            update.Parameters.AddWithValue("@Plot", MPlot);
            update.Parameters.AddWithValue("@Genre", RMGenre);

            con.Open();
            //its NONQuery as data is only going up
            update.ExecuteNonQuery();
            con.Close();

            DataTable movies = CreateTable2();
            movies = ReadData2(movies);
            return movies;
        }
        private DataTable CreateTable2()
        {
            DataTable movies = new DataTable();
            // Our visual Data Base
            movies.Clear();
            movies.Columns.Add("MovieID");
            movies.Columns.Add("Rating");
            movies.Columns.Add("Title");
            movies.Columns.Add("Year");
            movies.Columns.Add("Genre");
            movies.Columns.Add("Rental_Cost");
            movies.Columns.Add("Copies");
            movies.Columns.Add("Plot");
            // End of visual

            return movies;
        }
        private DataTable ReadData2(DataTable movies)
        {
            con.Open();
            string query = "Select * from Movies order by MovieID";
            SqlCommand command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                movies.Rows.Add(
                    reader["MovieID"],
                    reader["Rating"],
                    reader["Title"],
                    reader["Year"],
                    reader["Genre"],
                    reader["Rental_Cost"],
                    reader["Copies"],
                    reader["Plot"]

                    );
            }
            reader.Close();
            con.Close();
            return movies;
        }
        // Method - Add a movie
        public DataTable addmovies(string newMTitle, string newMGenre, string newMCost, string newMRating)
        {

            // this puts the parameters into the code so that the data in the text boxes is added to the database
            string NewMovies = "INSERT INTO Movies (Rating, Title, Rental_cost, Genre) VALUES (@Rating, @Title, @Rental_cost, @Genre)";

            SqlCommand newdata = new SqlCommand(NewMovies, con);

            newdata.Parameters.AddWithValue("@Title", newMTitle);
            newdata.Parameters.AddWithValue("@Genre", newMGenre);
            newdata.Parameters.AddWithValue("@Rental_cost", newMCost);
            newdata.Parameters.AddWithValue("@Rating", newMRating);

            con.Open(); //open a connection to the database
                        //its a NONQuery as it doesn't return any data its only going up to the server
            newdata.ExecuteNonQuery(); //Run the QueryCustomer
            con.Close(); //Close a connection to the database
                         //a happy message box

            DataTable movies = CreateTable2();
            movies = ReadData2(movies);
            return movies;
        }
        // Method - Update movies
        public DataTable updatemovies(string newMovieID, string newMYear, string newMCopies, string newMPlot, string newMTitle, string newMGenre, string newMCost, string newMRating)
        {
            //this updates existing data in the database where the ID of the data equals the ID in the text box
            string updatestatement = "UPDATE Movies set Title=@Title, Year=@Year, Genre=@Genre, Rental_cost=@Rental_cost, Copies=@Copies, Plot=@Plot, Rating=@Rating where MovieID = @MovieID";
            SqlCommand update = new SqlCommand(updatestatement, con);
            //create the parameters and pass the data from the textboxes
            update.Parameters.AddWithValue("@MovieID", newMovieID);
            update.Parameters.AddWithValue("@Rating", newMRating);
            update.Parameters.AddWithValue("@Title", newMTitle);
            update.Parameters.AddWithValue("@Year", newMYear);
            update.Parameters.AddWithValue("@Rental_cost", newMCost);
            update.Parameters.AddWithValue("@Copies", newMCopies);
            update.Parameters.AddWithValue("@Plot", newMPlot);
            update.Parameters.AddWithValue("@Genre", newMGenre);


            con.Open();
            //its NONQuery as data is only going up
            update.ExecuteNonQuery();
            con.Close();

            DataTable movies = CreateTable2();
            movies = ReadData2(movies);
            return movies;
        }
        // Method for deleting movie

        public DataTable deletemovies(string newMovieID)
        {
            con.Open();
            string DeleteCommand = "Delete Movies where MovieID = @MovieID";
            SqlCommand DeleteData = new SqlCommand(DeleteCommand, con);
            DeleteData.Parameters.AddWithValue("@MovieID", newMovieID);

            DeleteData.ExecuteNonQuery();
            con.Close();

            DataTable movies = CreateTable2();
            movies = ReadData2(movies);
            return movies;
        }

        // Method        
        public DataTable showrented()
        {
            DataTable rented = CreateTable3();
            rented = ReadData3(rented);
            return rented;
        }
        private DataTable CreateTable3()
        {
            DataTable rented = new DataTable();
            // Our visual Data Base
            rented.Clear();
            rented.Columns.Add("RMID");
            rented.Columns.Add("MovieID");
            rented.Columns.Add("Title");
            rented.Columns.Add("CustID");
            rented.Columns.Add("Rental_Cost");
            rented.Columns.Add("DateRented");
            rented.Columns.Add("DateReturned");
            // End of visual
            return rented;
        }
        private DataTable ReadData3(DataTable rented)
        {
            con.Open();
            string query = "Select * from RentedMovies, Movies, Customer Where RentedMovies.MovieIDFK = Movies.MovieID and RentedMovies.CustIDFK = Customer.CustID order by RentedMovies.RMID";
            SqlCommand command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                rented.Rows.Add(
                    reader["RMID"],
                    reader["MovieID"],
                    reader["Title"],
                    reader["CustID"],
                    reader["Rental_Cost"],
                    reader["DateRented"],
                    reader["DateReturned"]
                    );
            }
            reader.Close();
            con.Close();
            return rented;
        }

        public DataTable showoutrented()
        {
            DataTable outrented = CreateTable3();
            outrented = ReadData4(outrented);
            return outrented;
        }

        private DataTable ReadData4(DataTable outrented)
        {
            con.Open();
            string query = "Select * from RentedMovies, Movies, Customer Where RentedMovies.MovieIDFK = Movies.MovieID and RentedMovies.CustIDFK = Customer.CustID and RentedMovies.DateReturned is null order by RentedMovies.RMID";
            SqlCommand command = new SqlCommand(query, con);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                outrented.Rows.Add(
                    reader["RMID"],
                    reader["MovieID"],
                    reader["Title"],
                    reader["CustID"],
                    reader["Rental_Cost"],
                    reader["DateRented"],
                    reader["DateReturned"]
                    );
            }
            reader.Close();
            con.Close();
            return outrented;
        }
        public DataTable returnmovies(string newRMID, string ReturnMovieID, string ReturnCustID, string ReturnMovieIDFK, string ReturnDateRented, string NewDateReturned)
        {

            DataTable returned = CreateTable3();
            returned = ReadData8(returned, ReturnMovieID, ReturnCustID, ReturnMovieIDFK, ReturnDateRented, NewDateReturned, newRMID);
            return returned;
        }
        private DataTable ReadData8(DataTable returned, string newRMID, string ReturnMovieID, string ReturnCustID, string ReturnMovieIDFK, string ReturnDateRented, string NewDateReturned)
        {

            string query = "SELECT CURRENT_TIMESTAMP";
            SqlConnection con = new SqlConnection(conString);

            SqlCommand command = new SqlCommand(query, con);
            con.Open();
            NewDateReturned = command.ExecuteScalar().ToString();



            Console.WriteLine(NewDateReturned);
            
            //this rest existing data in the database where the MovieID of the data equals the ID in the text box
            string resetstatement = "UPDATE RentedMovies set RMID=@RMID, MovieIDFK=@MovieIDFK, CustIDFK=@CustIDFK, DateRented=@DateRented, DateReturned=@DateReturned where newRMID = @RMID";
            SqlCommand update = new SqlCommand(resetstatement, con);


            //create the parameters and pass the data from the textboxes
            update.Parameters.AddWithValue("@RMID", newRMID);
            update.Parameters.AddWithValue("@MovieIDFK", ReturnMovieIDFK);
            update.Parameters.AddWithValue("@CustIDFK", ReturnCustID);
            update.Parameters.AddWithValue("@DateRented", ReturnDateRented);
            update.Parameters.AddWithValue("@DateReturned", NewDateReturned);

            
            //its NONQuery as data is only going up
            update.ExecuteNonQuery();
            con.Close();
            DataTable rented = CreateTable3();
            rented = ReadData3(rented);
            return rented;

        }



        /*        // Method - Issue a movie
                public DataTable issuemovies(string IssueMovieIDFK, string IssueCustIDFK)
                {

                    DataTable issued = CreateTable3();
                    issued = ReadData8(issued, IssueMovieIDFK, IssueCustIDFK);
                    return issued;
                }
                private DataTable ReadData8(DataTable issued, string IssueMovieIDFK, string IssueCustIDFK string DateRented)
                {
                    con.Open();

                    string query = "Select * from RentedMovies, Movies, Customer Where Movies.MovieID = @Movie.ID";
                    SqlCommand command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@Movie.ID", IssueMovieIDFK);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        issued.Rows.Add(
                            reader["RMID"],
                            reader["MovieIDFK"],
                            reader["CustIDFK"],
                            reader["Now()"]
                            );
                    }
                    reader.Close();
                    con.Close();
                    return issued;
        /*
                    // this puts the parameters into the code so that the data in the text boxes is added to the database
                    con.Open();
                    string NewIssue = "INSERT INTO RentedMovies (MovieIDFK, CustIDFK, DateRented) VALUES (@MovieIDFK, @CustIDFK, @DateRented)";

                    SqlCommand newdata = new SqlCommand(NewIssue, con);

                    newdata.Parameters.AddWithValue("@MovieIDFK", IssueMovieIDFK);
                    newdata.Parameters.AddWithValue("@CustIDFK", IssueCustIDFK);
                    newdata.Parameters.AddWithValue("@DateRented", DateRented);
                    //    newdata.Parameters.AddWithValue("@DateRented", IssueDateRented);


                    //its a NONQuery as it doesn't return any data its only going up to the server
                    //    newdata.ExecuteNonQuery(); //Run the QueryCustomer
                    con.Close(); //Close a connection to the database
                                 //a happy message box

            /*        DataTable movies = CreateTable2();
                    movies = ReadData2(movies);
                    return movies;
                    issued = ReadData6(issued);
                    return issued;*/
    }
    /*    private DataTable ReadData6(DataTable issued)
        {
            con.Open();

            string query = "Select * from RentedMovies, Movies, Customer Where Movies.MovieID = @Movie.ID";
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@Movie.ID", IssueMovieIDFK);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                issued.Rows.Add(
                    reader["RMID"],
                    reader["Title"],
                    reader["LastName"],
                    reader["DateRented"],
                    reader["DateReturned"]
                    );
            }
            reader.Close();
            con.Close();
            return unrented;

            // this puts the parameters into the code so that the data in the text boxes is added to the database
            string NewMovies = "INSERT INTO RentedMovies (MovieIDFK, CustIDFK, DateRented) VALUES (@MovieIDFK, @CustIDFK, @DateRented)";

            SqlCommand newdata = new SqlCommand(NewMovies, con);

            newdata.Parameters.AddWithValue("@MovieIDFK", IssueMovieIDFK);
            newdata.Parameters.AddWithValue("@CustIDFK", IssueCustIDFK);
        //    newdata.Parameters.AddWithValue("@DateRented", IssueDateRented);
            

                        //its a NONQuery as it doesn't return any data its only going up to the server
        //    newdata.ExecuteNonQuery(); //Run the QueryCustomer
            con.Close(); //Close a connection to the database
                         //a happy message box

            DataTable movies = CreateTable2();
            movies = ReadData2(movies);
            return movies;
        }*/
}

