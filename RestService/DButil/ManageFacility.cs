using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ModelLibrary.Model;

namespace RestService.DButil
{
    public class ManageFacility:Imanage<Facility>
    {

        private const string connString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=demo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private const string GET_ALL = "select * from DemoFacilities";
        private const string GET_ONE = "select * from DemoFacilities where Facility_Id = @id";
        private const string INSERT = "insert into DemoFacilities values (@name)";
        private const string DELETE = "delete from DemoFacilities where Facility_Id = @id";
        private const string UPDATE =
            "update DemoFacilities \n set FacilityName = @Name \n where Facility_Id = @Id";
                                      

        public IEnumerable<Facility> Get()
        {
            List<Facility> liste = new List<Facility>();
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(GET_ALL, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Facility facility = ReadFacility(reader);
                liste.Add(facility);
            }
            conn.Close();
            return liste;
        }

        private Facility ReadFacility(SqlDataReader reader)
        {
            Facility facility = new Facility();
            facility.FacilityId = reader.GetInt32(0);
            facility.FacilityName = reader.GetString(1);
            return facility;
        }

        public Facility Get(int id)
        {
            Facility facility = new Facility();
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(GET_ONE, conn);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                facility = ReadFacility(reader);
            }
            conn.Close();
            return facility;
        }

        public bool Post(Facility facility)
        {
            bool retValue = false;

            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(INSERT, conn);
            cmd.Parameters.AddWithValue("@name", facility.FacilityName);

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected == 1)
            {
                retValue = true;
            }

            else
            {
                retValue = false;
            }

            return retValue;
        }

        public bool Put(int id, Facility facility)
        {
            bool retValue = false;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(UPDATE, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Name", facility.FacilityName);

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected == 1)
            {
                retValue = true;
            }

            else
            {
                retValue = false;
            }

            return retValue;
        }

        public bool Delete(int id)
        {
            bool retValue = false;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(DELETE, conn);
            cmd.Parameters.AddWithValue("@Id", id);

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected == 1)
            {
                retValue = true;
            }

            else
            {
                retValue = false;
            }

            return retValue;
        }
    }
}