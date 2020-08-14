using System;
using Video_Store;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;

namespace TestVideoStore
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void ConnectFromDatabase()
        {
            VSClass test = new VSClass();
            SqlConnection con = new SqlConnection(test.ReturnConnectionString());

            con.Open();

            Assert.AreEqual(con.State.ToString(), "Open");

            con.Close();
        }

        [TestMethod]
        public void DisconnectFromDatabase()
        {
            VSClass test = new VSClass();
            SqlConnection con = new SqlConnection(test.ReturnConnectionString());

            con.Open();

            con.Close();

            Assert.AreEqual(con.State.ToString(), "Closed");

        }
    }
}
