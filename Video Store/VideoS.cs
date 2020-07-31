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
            // all text boxes with null
            CustID.Text = "";
            CFName.Text = "";
            CLName.Text = "";
            CAddress.Text = "";
            CPhone.Text = "";
            MovieID.Text = "";
            MTitle.Text = "";
            MGenre.Text = "";
            MCost.Text = "";
            MRating.Text = "";
        }
        private void CustBtn_Click(object sender, EventArgs e)
        {
            dataGridView.DataSource = vsclass.showcustomer();
            data = "cust"; // gridview data to text boxes control
        }

        private void MoviesBtn_Click(object sender, EventArgs e)
        {
            dataGridView.DataSource = vsclass.showmovies();
            data = "movie"; // gridview data to text boxes control
        }

        private void RentalsBtn_Click(object sender, EventArgs e)
        {
            dataGridView.DataSource = vsclass.showrented();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            //show the data in the DGV in the text boxes
            string newvalue = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            //show the output on the header
            this.Text = "Row : " + e.RowIndex.ToString() + " Col : " + e.ColumnIndex.ToString() + " Value = " + newvalue;

            if (data == "cust")
            {
                //pass data to the text boxes
                CustID.Text = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                CFName.Text = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                CLName.Text = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                CAddress.Text = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                CPhone.Text = dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                MovieID.Text = "";
                MTitle.Text = "";
                MGenre.Text = "";
                MCost.Text = "";
                MRating.Text = "";
            }
            else if (data == "movie")
            {
                //pass data to the text boxes
                MovieID.Text = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                MRating.Text = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                MTitle.Text = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                MCost.Text = dataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
                MGenre.Text = dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                CustID.Text = "";
                CFName.Text = "";
                CLName.Text = "";
                CAddress.Text = "";
                CPhone.Text = "";
            }
            // all text boxes with null
            CustID.Text = "";
            CFName.Text = "";
            CLName.Text = "";
            CAddress.Text = "";
            CPhone.Text = "";
            MovieID.Text = "";
            MTitle.Text = "";
            MGenre.Text = "";
            MCost.Text = "";
            MRating.Text = "";
        }
        private void AllRBtn_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView.DataSource = vsclass.showallrented();
            // all text boxes with null
            CustID.Text = "";
            CFName.Text = "";
            CLName.Text = "";
            CAddress.Text = "";
            CPhone.Text = "";
            MovieID.Text = "";
            MTitle.Text = "";
            MGenre.Text = "";
            MCost.Text = "";
            MRating.Text = "";
        }
        private void OutRBtn_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView.DataSource = vsclass.showunrented();
            // all text boxes with null
            CustID.Text = "";
            CFName.Text = "";
            CLName.Text = "";
            CAddress.Text = "";
            CPhone.Text = "";
            MovieID.Text = "";
            MTitle.Text = "";
            MGenre.Text = "";
            MCost.Text = "";
            MRating.Text = "";
        }
        private void AddCBtn_Click(object sender, EventArgs e)
        {
            // setting variables to take new customer details
            string NewCFName = CFName.Text;
            string NewCLName = CLName.Text;
            string NewCAddress = CAddress.Text;
            string NewCPhone = CPhone.Text;

            vsclass.addcustomer(CFName.Text, CLName.Text, CAddress.Text, CPhone.Text);

            MessageBox.Show("Data has been Inserted !! ");
            // showing customer list with addition
            dataGridView.DataSource = vsclass.showcustomer();
            data = "cust";
            // all text boxes with null
            CustID.Text = "";
            CFName.Text = "";
            CLName.Text = "";
            CAddress.Text = "";
            CPhone.Text = "";
            MovieID.Text = "";
            MTitle.Text = "";
            MGenre.Text = "";
            MCost.Text = "";
            MRating.Text = "";
        }

        private void AddMBtn_Click(object sender, EventArgs e)
        {
            // setting variables to take new movie details
            string NewMTitle = MTitle.Text;
            string NewMGenre = MGenre.Text;
            string NewMCost = MCost.Text;
            string NewMRating = MRating.Text;

            vsclass.addmovies(MTitle.Text, MGenre.Text, MCost.Text, MRating.Text);

            MessageBox.Show("Data has been Inserted !! ");
            // showing movie list with addition
            dataGridView.DataSource = vsclass.showmovies();
            data = "movie";
            // all text boxes with null
            CustID.Text = "";
            CFName.Text = "";
            CLName.Text = "";
            CAddress.Text = "";
            CPhone.Text = "";
            MovieID.Text = "";
            MTitle.Text = "";
            MGenre.Text = "";
            MCost.Text = "";
            MRating.Text = "";
        }

        private void UpdateCBtn_Click(object sender, EventArgs e)
        {
            // setting variables to take new customer details
            string NewCFName = CFName.Text;
            string NewCLName = CLName.Text;
            string NewCAddress = CAddress.Text;
            string NewCPhone = CPhone.Text;

            vsclass.updatecustomer(CustID.Text, CFName.Text, CLName.Text, CAddress.Text, CPhone.Text);

            MessageBox.Show("Data has been Updated !! ");
            // showing customer list with update
            dataGridView.DataSource = vsclass.showcustomer();
            data = "cust";
            // all text boxes with null
            CustID.Text = "";
            CFName.Text = "";
            CLName.Text = "";
            CAddress.Text = "";
            CPhone.Text = "";
            MovieID.Text = "";
            MTitle.Text = "";
            MGenre.Text = "";
            MCost.Text = "";
            MRating.Text = "";
        }

        private void UpdateMBtn_Click(object sender, EventArgs e)
        {
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

            vsclass.updatemovies(MovieID.Text, NewMYear, NewMCopies, NewMPlot, MTitle.Text, MGenre.Text, MCost.Text, MRating.Text);

            MessageBox.Show("Data has been Updated !! ");
            // showing customer list with update
            dataGridView.DataSource = vsclass.showmovies();
            data = "movie";
            // all text boxes with null
            CustID.Text = "";
            CFName.Text = "";
            CLName.Text = "";
            CAddress.Text = "";
            CPhone.Text = "";
            MovieID.Text = "";
            MTitle.Text = "";
            MGenre.Text = "";
            MCost.Text = "";
            MRating.Text = "";
        }

        private void DeleteCBtn_Click(object sender, EventArgs e)
        {
            vsclass.deletecustomer(CustID.Text);

            MessageBox.Show("Data has been Deleted !! ");
            // showing customer list after deleting
            dataGridView.DataSource = vsclass.showcustomer();
            data = "cust";
            // all text boxes with null
            CustID.Text = "";
            CFName.Text = "";
            CLName.Text = "";
            CAddress.Text = "";
            CPhone.Text = "";
            MovieID.Text = "";
            MTitle.Text = "";
            MGenre.Text = "";
            MCost.Text = "";
            MRating.Text = "";
        }

        private void DeleteMBtn_Click(object sender, EventArgs e)
        {
            vsclass.deletemovies(MovieID.Text);

            MessageBox.Show("Data has been Deleted !! ");
            // showing movie list after deleting
            dataGridView.DataSource = vsclass.showmovies();
            data = "movie";
            // all text boxes with null
            CustID.Text = "";
            CFName.Text = "";
            CLName.Text = "";
            CAddress.Text = "";
            CPhone.Text = "";
            MovieID.Text = "";
            MTitle.Text = "";
            MGenre.Text = "";
            MCost.Text = "";
            MRating.Text = "";
        }
    }

}


