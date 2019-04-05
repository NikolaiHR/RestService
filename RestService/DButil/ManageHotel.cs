using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using ModelLibrary.Model;

namespace RestService.DButil
{
    public class ManageHotel:Imanage<Hotel>
    {
        private const string connString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=demo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private const string GET_ALL = "select * from DemoHotel";
        private const string GET_ONE = "select * from DemoHotel where Hotel_No = @id";
        private const string INSERT = "insert into DemoHotel values (@id, @name, @address)";
        private const string DELETE = "delete from DemoHotel where Hotel_No = @id";
        private const string UPDATE = "update DemoHotel" + "set Hotel_No = @HotelId, name = @Name, address = @Address" +
                                      "where Hotel_No = @id";

        public IEnumerable<Hotel> Get()
        {
            List<Hotel> liste = new List<Hotel>();
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(GET_ALL, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Hotel hotel = ReadHotel(reader);
                liste.Add(hotel);
            }
            conn.Close();
            return liste;
        }

        private Hotel ReadHotel(SqlDataReader reader)
        {
            Hotel hotel = new Hotel();
            hotel.HotelNr = reader.GetInt32(0);
            hotel.Name = reader.GetString(1);
            hotel.Address = reader.GetString(2);
            return hotel;
        }

        public Hotel Get(int id)
        {
            Hotel hotel = new Hotel();
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(GET_ONE, conn);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                hotel = ReadHotel(reader);             
            }
            conn.Close();
            return hotel;
        }

        public bool Post(Hotel hotel)
        {
            bool retValue = false;

            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(INSERT, conn);
            cmd.Parameters.AddWithValue("@id", hotel.HotelNr);
            cmd.Parameters.AddWithValue("@name", hotel.Name);
            cmd.Parameters.AddWithValue("@address", hotel.Address);

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

        public bool Put(int id, Hotel hotel)
        {
            bool retValue = false;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(UPDATE, conn);
            cmd.Parameters.AddWithValue("@HotelId", id);
            cmd.Parameters.AddWithValue("@Id", hotel.HotelNr);
            cmd.Parameters.AddWithValue("@Name", hotel.Name);
            cmd.Parameters.AddWithValue("@Address", hotel.Address);

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