using Npgsql;
using System.Data;
using System;

namespace TugasPbo
{
    class getting_data
    {
        private static NpgsqlConnection koneksi()
        {
            return new NpgsqlConnection(@"server=localhost;port=5432;user id=postgres;password=admin;database=identitas;");
        }
        public bool ExecuteQuery(out bool info)

        {
            info = true;
            try
            {

                NpgsqlConnection con = koneksi();
                con.Open();
                string sql = "select * from identitas";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return info;
                

            }
            catch (Exception)
            {
                info = false;
                return info;
            }

        }
    }
    class operasi
    {
        private static NpgsqlConnection koneksi()
        {
            return new NpgsqlConnection(@"server=localhost;port=5432;user id=postgres;password=admin;database=identitas;");
        }
        public bool insert(ref bool info)
        {
            try
            {
                NpgsqlConnection con = koneksi();
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("insert into identitas(nim,nama,kelas) values('8','angga','9a')", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                info = true;
                return info;
            }
            catch (Exception)
            {
                return info;
            }

        }

        public bool update(ref bool info)
        {
            try
            {
                NpgsqlConnection con = koneksi();
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("update set nama = angga, kelas = 9b where @nim = 8", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                info = true;
                return info;
            }
            catch (Exception)
            {
                return info;
            }

        }
        public bool Delete(ref bool info)
        {
            try
            {
                NpgsqlConnection con = koneksi();
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("delete from pegawai where nim = 8", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                info = true;
                return info;
            }
            catch (Exception)
            {
                return info;
            }

        }
    }

    class program_utama
    {

        static void Main(string[] args)
        {
            bool info;
            bool ingfo = false;
            getting_data dat = new getting_data();
            operasi op = new operasi();
            if (dat.ExecuteQuery(out info) == true)
            {
                Console.WriteLine("sukses mengambil data");
            }
            else if (dat.ExecuteQuery(out info) == false)
            {
                Console.WriteLine("gagal mengambil data");
            }
            if ((op.insert(ref ingfo) == true) || (op.update(ref ingfo) == true) || (op.Delete(ref ingfo) == true))
                try
                    {
                        Console.WriteLine("program berhasil");
                    }
                catch (Exception)
                {

                }

            else if ((op.insert(ref ingfo) == false) || (op.update(ref ingfo) == false) || (op.Delete(ref ingfo) == false))
                try
                        {
                            Console.WriteLine("program gagal");
                        
                        }
                catch (Exception)
                    {
                    
                    }
           
        }
    }
}