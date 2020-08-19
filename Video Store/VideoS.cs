using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Video_Store
{
    public partial class VideoS : Form
    {
        VSClass vsclass = new VSClass();
        string data;
        public VideoS()
        {
            InitializeComponent();
            // original button setting
            ReturnMBtn.Enabled = false;
            IssueMBtn.Enabled = false;
            // all text boxes with null
            CustID.Text = ""; CFName.Text = ""; CLName.Text = ""; CAddress.Text = ""; CPhone.Text = "";
            MovieID.Text = ""; MTitle.Text = ""; MGenre.Text = ""; MCost.Text = ""; MRating.Text = "";
        }
        private void CustBtn_Click(object sender, EventArgs e)
        {
            // Show customer list
            ReturnMBtn.Enabled = false;
            IssueMBtn.Enabled = false;
            dataGridView.DataSource = vsclass.showCustomer();
            data = "cust"; // gridview data to text boxes control
        }

        private void MoviesBtn_Click(object sender, EventArgs e)
        {
            // Show movie list
            ReturnMBtn.Enabled = false;
            IssueMBtn.Enabled = true;
            dataGridView.DataSource = vsclass.showMovies();
            data = "movie"; // gridview data to text boxes control
        }

        private void RentalsBtn_Click(object sender, EventArgs e)
        {
            // Show rented movie list
            ReturnMBtn.Enabled = true;
            IssueMBtn.Enabled = true;
            dataGridView.DataSource = vsclass.showRented();
            data = "rented"; // gridview data to text boxes control
        }
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //show the data in the DGV in the text boxes
            string newvalue = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            //show the output on the header
            this.Text = "Row : " + e.RowIndex.ToString() + " Col : " + e.ColumnIndex.ToString() + " Value = " + newvalue;
            // Customer list
            if (data == "cust")
            {
                //pass data to the text boxes
                CustID.Text = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                CFName.Text = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                CLName.Text = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                CAddress.Text = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                CPhone.Text = dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
            // Movie list with price setting
            else if (data == "movie")
            {
                // pass data to the text boxes
                // setting variables to take movie details
                string RMovieID = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                MovieID.Text = RMovieID;
                string RMRating = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                MRating.Text = RMRating;
                string RMTitle = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                MTitle.Text = RMTitle;
                string ReleaseYear = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                string RMYear = ReleaseYear;
                string RMGenre = dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                MGenre.Text = RMGenre;
                string MCopies = dataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
                string MPlot = dataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
                // handling for year, blank, 2000-2010 etc.
                if (ReleaseYear == "")
                {
                    ReleaseYear = "0";
                }
                if (Convert.ToInt32(ReleaseYear.Length) > 4)
                {
                    int YearPosition = ReleaseYear.IndexOf("–");
                    string LatestYear = ReleaseYear.Substring(YearPosition + 1);
                    ReleaseYear = LatestYear;
                }
                // setting old movies to change cost to $2, otherwise $5
                if (Convert.ToInt32(ReleaseYear) < 2015)
                {
                    MCost.Text = "2";
                }
                else
                {
                    MCost.Text = "5";
                }
                vsclass.resetMovies(RMovieID, RMYear, MCopies, MPlot, RMTitle, RMGenre, MCost.Text, RMRating);
            }
            // Rented movie list
            else if (data == "rented")
            {
                // all text boxes with null
                CustID.Text = ""; CFName.Text = ""; CLName.Text = ""; CAddress.Text = ""; CPhone.Text = "";
                MovieID.Text = ""; MTitle.Text = ""; MGenre.Text = ""; MCost.Text = ""; MRating.Text = "";
                //pass data to the text boxes
                RMID.Text = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                MovieID.Text = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                MTitle.Text = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                CustID.Text = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                MCost.Text = dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }
        private void AllRBtn_CheckedChanged(object sender, EventArgs e)
        {
            // Show all rented list
            ReturnMBtn.Enabled = false;
            IssueMBtn.Enabled = false;
            dataGridView.DataSource = vsclass.showAllrented();
            // all text boxes with null
            CustID.Text = ""; CFName.Text = ""; CLName.Text = ""; CAddress.Text = ""; CPhone.Text = "";
            MovieID.Text = ""; MTitle.Text = ""; MGenre.Text = ""; MCost.Text = ""; MRating.Text = "";
        }
        private void OutRBtn_CheckedChanged(object sender, EventArgs e)
        {
            // Show out rented list
            ReturnMBtn.Enabled = false;
            IssueMBtn.Enabled = false;
            dataGridView.DataSource = vsclass.showOutrented();
            // all text boxes with null
            CustID.Text = ""; CFName.Text = ""; CLName.Text = ""; CAddress.Text = ""; CPhone.Text = "";
            MovieID.Text = ""; MTitle.Text = ""; MGenre.Text = ""; MCost.Text = ""; MRating.Text = "";
        }
        private void AddCBtn_Click(object sender, EventArgs e)
        {
            // Add customer
            // setting variables to take new customer details
            string NewCFName = CFName.Text;
            string NewCLName = CLName.Text;
            string NewCAddress = CAddress.Text;
            string NewCPhone = CPhone.Text;
            vsclass.addCustomer(CFName.Text, CLName.Text, CAddress.Text, CPhone.Text);
            MessageBox.Show("Data has been Inserted !! ");
            // showing customer list with addition
            dataGridView.DataSource = vsclass.showCustomer();
            data = "cust";
        }
        private void AddMBtn_Click(object sender, EventArgs e)
        {
            // Add movie
            // setting variables to take new movie details
            string NewMTitle = MTitle.Text;
            string NewMGenre = MGenre.Text;
            string NewMCost = MCost.Text;
            string NewMRating = MRating.Text;
            vsclass.addMovies(MTitle.Text, MGenre.Text, MCost.Text, MRating.Text);
            MessageBox.Show("Data has been Inserted !! ");
            // showing movie list with addition
            dataGridView.DataSource = vsclass.showMovies();
            data = "movie";
        }
        private void UpdateCBtn_Click(object sender, EventArgs e)
        {
            // Update customer
            // setting variables to take new customer details
            string NewCFName = CFName.Text;
            string NewCLName = CLName.Text;
            string NewCAddress = CAddress.Text;
            string NewCPhone = CPhone.Text;
            vsclass.updateCustomer(CustID.Text, CFName.Text, CLName.Text, CAddress.Text, CPhone.Text);
            MessageBox.Show("Data has been Updated !! ");
            // showing customer list with update
            dataGridView.DataSource = vsclass.showCustomer();
            data = "cust";
        }
        private void UpdateMBtn_Click(object sender, EventArgs e)
        {
            // Update Movie
            // setting variables to take new movie details
            string NewMTitle = MTitle.Text;
            string NewMGenre = MGenre.Text;
            string NewMCost = MCost.Text;
            string NewMRating = MRating.Text;
            // setting unchanged variables to read/write again
            int NewMovieID = Convert.ToInt32(MovieID.Text);
            string NewMYear;
            string NewMCopies;
            string NewMPlot;
            NewMYear = dataGridView.Rows[NewMovieID].Cells[3].Value.ToString();
            NewMCopies = dataGridView.Rows[NewMovieID].Cells[5].Value.ToString();
            NewMPlot = dataGridView.Rows[NewMovieID].Cells[6].Value.ToString();
            vsclass.updateMovies(MovieID.Text, NewMYear, NewMCopies, NewMPlot, MTitle.Text, MGenre.Text, MCost.Text, MRating.Text);
            MessageBox.Show("Data has been Updated !! ");
            // showing customer list with update
            dataGridView.DataSource = vsclass.showMovies();
            data = "movie";
        }
        private void DeleteCBtn_Click(object sender, EventArgs e)
        {
            // Delete customer
            vsclass.deleteCustomer(CustID.Text);
            MessageBox.Show("Data has been Deleted !! ");
            // showing customer list after deleting
            dataGridView.DataSource = vsclass.showCustomer();
            data = "cust";
        }
        private void DeleteMBtn_Click(object sender, EventArgs e)
        {
            // Delet movie
            vsclass.deleteMovies(MovieID.Text);
            MessageBox.Show("Data has been Deleted !! ");
            // showing movie list after deleting
            dataGridView.DataSource = vsclass.showMovies();
            data = "movie";
        }
        private void ReturnMBtn_Click(object sender, EventArgs e)
        {
            // Return movie
            string ReturnMovieID = MovieID.Text;
            if (ReturnMovieID == "")
            {
                MessageBox.Show("Choose Movie from Rented Movie list pressing Rentals button on top.");
            }
            string ReturnCustID = CustID.Text;
            string NewDateReturned = "";
            // setting unchanged variables to read/write again
            if (RMID.Text != "")
            {
                int NewRMID = Convert.ToInt32(RMID.Text) - 1;
                string ReturnMovieIDFK = dataGridView.Rows[NewRMID].Cells[1].Value.ToString();
                string ReturnCustIDFK = dataGridView.Rows[NewRMID].Cells[3].Value.ToString();
                string ReturnDateRented = dataGridView.Rows[NewRMID].Cells[5].Value.ToString();
                string DateReturned = dataGridView.Rows[NewRMID].Cells[6].Value.ToString();
                // already returned or not
                if (DateReturned != "")
                {
                    MessageBox.Show("Already returned.");
                }
                vsclass.returnMovies(RMID.Text, ReturnMovieID, ReturnCustIDFK, ReturnMovieIDFK, ReturnDateRented, NewDateReturned);
            }

        }

        private void IssueMBtn_Click(object sender, EventArgs e)
        {
            // issue movie
            string IssueMovieID = MovieID.Text;
            if (IssueMovieID == "")
            {
                MessageBox.Show("Choose Movie from Movie list pressing Movie button on top.");
            }
            string IssueCustID = CustID.Text;
            if (IssueCustID == "")
            {
                MessageBox.Show("Input customers ID in Customer ID box.");
            }
            string NewDateIssued = "";
            // setting unchanged variables to read/write again
            if (NewDateIssued != "")
            {
                MessageBox.Show("Already issued.");
            }
            vsclass.issueMovies(NewDateIssued, IssueMovieID, IssueCustID);
        }
    }
}


