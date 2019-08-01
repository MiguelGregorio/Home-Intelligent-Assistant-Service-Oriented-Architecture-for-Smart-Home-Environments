using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using HIAWebService.Models;
using Microsoft.AspNetCore.Mvc;

namespace HIAWebService.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class ValuesController : Controller
    {

        //connection string
        private string conStr = "Server=tcp:hiadatabases2.database.windows.net; Database=HIADataBase; User ID =miguelbruno@hiadatabases2;Password=1qazZAQ!; Trusted_Connection=False; Encrypt=True";



        [Route("/GetUser/")]
        public List<User> GetUser()
        {
            List<User> UserList = new List<User>();
            SqlConnection connection = new SqlConnection(this.conStr);
            connection.Open();
            SqlCommand cmd = new SqlCommand("Select * from tb_User ", connection);
            cmd.CommandType = CommandType.Text;
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                User user = new User();
                user.Email = sdr["Email"].ToString();
                user.Password = sdr["Password"].ToString();
                user.FirstName= sdr["FirstName"].ToString();
                user.LastName= sdr["LastName"].ToString();
                user.PhoneNumber= sdr["PhoneNumber"].ToString();
                user.Birthday= sdr["Birthday"].ToString();
                user.Address = sdr["Address"].ToString();
                user.Gender= sdr["Gender"].ToString();


                UserList.Add(user);

            }
            return UserList;
        }

        [Route("/GetUser/{id}")]
        public List<User> GetUser(string id)
        {
            List<User> UserList = new List<User>();
            SqlConnection connection = new SqlConnection(this.conStr);
            connection.Open();
            SqlCommand cmd = new SqlCommand("Select * from tb_User where Email ='"+ id + "'", connection);
            cmd.CommandType = CommandType.Text;
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                User user = new User();
                user.Email = sdr["Email"].ToString();
                user.Password = sdr["Password"].ToString();
                user.FirstName = sdr["FirstName"].ToString();
                user.LastName = sdr["LastName"].ToString();
                user.PhoneNumber = sdr["PhoneNumber"].ToString();
                user.Birthday = sdr["Birthday"].ToString();
                user.Gender = sdr["Gender"].ToString();
                user.Address = sdr["Address"].ToString();

                UserList.Add(user);

            }
            return UserList;
        }


        [Route("/GetHD/")]
        public List<HealthData> GetHD()
        {
            List<HealthData> HDList = new List<HealthData>();
            SqlConnection connection = new SqlConnection(this.conStr);
            connection.Open();
            SqlCommand cmd = new SqlCommand("Select * from tb_HealthData ", connection);
            cmd.CommandType = CommandType.Text;
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                HealthData hd = new HealthData();
                hd.Email = sdr["Email"].ToString();
                hd.Weight = sdr["Weight"].ToString();
                hd.Height = sdr["Height"].ToString();
                hd.BloodType = sdr["BloodType"].ToString();
                hd.Diabetes = sdr["Diabetes"].ToString();
                hd.Epilepsy = sdr["Epilepsy"].ToString();
                hd.Asma = sdr["Asma"].ToString();
                hd.Allergies = sdr["Allergies"].ToString();
                hd.Observations = sdr["Observations"].ToString();

                HDList.Add(hd);

            }
            return HDList;
        }


        [Route("/AddUser/")]//done
        [HttpPost]
        public int AddUser(string email, string password, string firstname, string lastname, string phonenumber, string birthday,string gender, string address)
        {
            int status = 0;
            SqlConnection connection = new SqlConnection(this.conStr);
            SqlCommand cmd = new SqlCommand();
            try
            {

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string q = "Insert into tb_User(Email, Password, FirstName, LastName, PhoneNumber, Birthday, Gender, Address) values('" + email + "', '" + password + "', '" + firstname + "', '" + lastname + "', '" + phonenumber + "', '" + birthday + "', '" + gender + "', '" + address + "') insert into tb_HealthData (Email) values ('"+email+ "')  insert into tb_RealTimeData (Email) values ('" + email + "') ";
                cmd = new SqlCommand(q, connection);
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteReader();
                status = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                cmd.Dispose();
            }
            return status;


        }

        [Route("/AddLeituraBandas/")] //Done
        [HttpPost]
        public int AddLeituraBandas(string Email, string Data, string Identifier, string Sequencia, string AnalogData, string DigitalInput)
        {
            int status = 0;
            SqlConnection connection = new SqlConnection(this.conStr);
            SqlCommand cmd = new SqlCommand();
            try
            {

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string q = "Insert into tb_LeituraBandas (Email, Data, Identifier, Sequencia, AnalogData, DigitalInput) values ('"+Email+"', '"+Data+"', '"+Identifier+"', '"+Sequencia+"', '"+AnalogData+"', '"+DigitalInput+"')";
                cmd = new SqlCommand(q, connection);
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteReader();
                status = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                cmd.Dispose();
            }
            return status;


        }

        [Route("/Confirm/{Email}/{Password}")]//done
        public bool Confirm(string Email, string Password)
        {

            SqlConnection connection = new SqlConnection(this.conStr);
            connection.Open();
            SqlCommand cmd = new SqlCommand("select FirstName from tb_User where Email='" + Email + "'and Password='" + Password + "'", connection);
            cmd.CommandType = CommandType.Text;
            SqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.HasRows)
            {
                return true;
            }

            return false;


        }


        [Route("/AddSOSEvent/")] //done
        [HttpPost]
        public int AddSOSEvent(string Email)
        {
            int status = 0;
            SqlConnection connection = new SqlConnection(this.conStr);
            SqlCommand cmd = new SqlCommand();
            try
            {

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string q = "insert into tb_SOSEvent(Email) values('"+Email+"')";
                cmd = new SqlCommand(q, connection);
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteReader();
                status = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                cmd.Dispose();
            }
            return status;


        }


        

        [Route("/GetUserInfo")]
        public List<UserInfo> GetUserInfo()
        {
            List<UserInfo> UserList = new List<UserInfo>();
            SqlConnection connection = new SqlConnection(this.conStr);
            connection.Open();
            SqlCommand cmd = new SqlCommand("select C.Email, C.FirstName, C.LastName, C.PhoneNumber, C.Birthday, C.Address, C.Gender, P.Weight, P.Height, P.BloodType, P.Diabetes, P.Epilepsy, P.Asma, P.Allergies, P.Observations, S.Lat, S.Lng, S.BPM, S.Temperatura from tb_User as C join tb_HealthData as P  on C.Email = P.Email and C.Email= (select top (1) Email from tb_SOSEvent where Relatorio IS NULL) join tb_RealTimeData as S on S.Email=C.Email", connection);
            cmd.CommandType = CommandType.Text;
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                UserInfo user = new UserInfo();
                user.Email = sdr["Email"].ToString();
                user.FirstName = sdr["FirstName"].ToString();
                user.LastName = sdr["LastName"].ToString();
                user.PhoneNumber = sdr["PhoneNumber"].ToString();
                user.Birthday = sdr["Birthday"].ToString();
                user.Address = sdr["Address"].ToString();
                user.Gender = sdr["Gender"].ToString();

                user.Weight = sdr["Weight"].ToString();
                user.Height = sdr["Height"].ToString();
                user.BloodType = sdr["BloodType"].ToString();
                user.Diabetes = sdr["Diabetes"].ToString();
                user.Epilepsy = sdr["Epilepsy"].ToString();
                user.Asma = sdr["Asma"].ToString();
                user.Allergies = sdr["Allergies"].ToString();
                user.Observations = sdr["Observations"].ToString();

                user.Lat = sdr["Lat"].ToString();
                user.Lng = sdr["Lng"].ToString();
                user.BPM = sdr["BPM"].ToString();
                user.Temperatura = sdr["Temperatura"].ToString();






                UserList.Add(user);

            }
            return UserList;

        }


        [Route("/GetUserAll/")]
        public List<UserInfo> GetUserAll()
        {
            List<UserInfo> UserList = new List<UserInfo>();
            SqlConnection connection = new SqlConnection(this.conStr);
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from tb_User as C join tb_HealthData as P on C.Email=P.Email  join tb_RealTimeData as S on C.Email=S.Email   ", connection);
            cmd.CommandType = CommandType.Text;
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                UserInfo user = new UserInfo();
                user.Email = sdr["Email"].ToString();
                user.FirstName = sdr["FirstName"].ToString();
                user.LastName = sdr["LastName"].ToString();
                user.PhoneNumber = sdr["PhoneNumber"].ToString();
                user.Birthday = sdr["Birthday"].ToString();
                user.Address = sdr["Address"].ToString();
                user.Gender = sdr["Gender"].ToString();

                user.Weight = sdr["Weight"].ToString();
                user.Height = sdr["Height"].ToString();
                user.BloodType = sdr["BloodType"].ToString();
                user.Diabetes = sdr["Diabetes"].ToString();
                user.Epilepsy = sdr["Epilepsy"].ToString();
                user.Asma = sdr["Asma"].ToString();
                user.Allergies = sdr["Allergies"].ToString();
                user.Observations = sdr["Observations"].ToString();

                user.Lat = sdr["Lat"].ToString();
                user.Lng = sdr["Lng"].ToString();
                user.BPM = sdr["BPM"].ToString();
                user.Temperatura = sdr["Temperatura"].ToString();






                UserList.Add(user);

            }
            return UserList;
        }


        [Route("/ConfirmLogin/{Email}/{Password}")]//done
        public List<UserData> ConfirmLogin(string Email, string Password)
        {
            List<UserData> UserList = new List<UserData>();
            SqlConnection connection = new SqlConnection(this.conStr);
            connection.Open();
            SqlCommand cmd = new SqlCommand("select C.Email, C.FirstName, C.LastName, C.PhoneNumber, C.Birthday, C.Address, C.Gender, P.Weight, P.Height, P.BloodType, P.Diabetes, P.Epilepsy, P.Asma, P.Allergies, P.Observations  from tb_User as C join tb_HealthData as P  on C.Email=P.Email and C.Email='"+Email+"' and C.Password='"+Password+"' ", connection);
            cmd.CommandType = CommandType.Text;
            SqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.HasRows)
            {

                while (sdr.Read())
                {
                    UserData user = new UserData();
                    user.Email = sdr["Email"].ToString();
                    user.FirstName = sdr["FirstName"].ToString();
                    user.LastName = sdr["LastName"].ToString();
                    user.PhoneNumber = sdr["PhoneNumber"].ToString();
                    user.Birthday = sdr["Birthday"].ToString();
                    user.Address = sdr["Address"].ToString();
                    user.Gender = sdr["Gender"].ToString();
 
                    user.Weight = sdr["Weight"].ToString();
                    user.Height = sdr["Height"].ToString();
                    user.BloodType = sdr["BloodType"].ToString();
                    user.Diabetes = sdr["Diabetes"].ToString();
                    user.Epilepsy = sdr["Epilepsy"].ToString();
                    user.Asma = sdr["Asma"].ToString();
                    user.Allergies = sdr["Allergies"].ToString();
                    user.Observations = sdr["Observations"].ToString();

                    UserList.Add(user);
                }


                return UserList;

            }

            return null;
        }


        [Route("/UpdateData")]//done
        [HttpPost]
        public int UpdateData(string Email,  string PhoneNumber,  string Address,  string Weight, string Height, string BloodType, string Diabetes, string Epilepsy, string Asma, string Allergies, string Observations)
        {
            int status = 0;
            SqlConnection connection = new SqlConnection(this.conStr);
            SqlCommand cmd = new SqlCommand();
            try
            {



                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string q = "UPDATE tb_User SET PhoneNumber = '" + PhoneNumber + "' ,Address = '" + Address + "' where Email='"+Email+"'  UPDATE tb_HealthData SET Weight='"+Weight+"' , Height='"+Height+"' , BloodType='"+BloodType+"' , Diabetes='"+Diabetes+"', Epilepsy='"+Epilepsy+"', Asma='"+Asma+"', Allergies='"+Allergies+"', Observations='"+Observations+"' WHERE Email='"+Email+"'" ;
                cmd = new SqlCommand(q, connection);
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteReader();
                status = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                cmd.Dispose();
            }
            return status;


        }


        [Route("/UpdateRealTimeCoordinates")] //done
        [HttpPost]
        public int UpdateRealTimeCoordinates(string Email, String Lat, String Lng)
        {
            int status = 0;
            SqlConnection connection = new SqlConnection(this.conStr);
            SqlCommand cmd = new SqlCommand();
            try
            {



                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string q = "Update tb_RealTimeData set Lat = '"+Lat+"', Lng='"+Lng+"' where Email= '"+Email+"'";
                cmd = new SqlCommand(q, connection);
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteReader();
                status = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                cmd.Dispose();
            }
            return status;


        }


        [Route("/UpdateRealTimeBPM")] //done
        [HttpPost]
        public int UpdateRealTimeBPM(string Email, String BPM)
        {
            int status = 0;
            SqlConnection connection = new SqlConnection(this.conStr);
            SqlCommand cmd = new SqlCommand();
            try
            {



                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string q = "Update tb_RealTimeData set BPM = '" + BPM + "' where Email= '" + Email + "'";
                cmd = new SqlCommand(q, connection);
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteReader();
                status = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                cmd.Dispose();
            }
            return status;


        }

        [Route("/UpdateRealTimeTemperatura")] //done
        [HttpPost]
        public int UpdateRealTimeTemperatura(string Email, String Temperatura)
        {
            int status = 0;
            SqlConnection connection = new SqlConnection(this.conStr);
            SqlCommand cmd = new SqlCommand();
            try
            {



                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string q = "Update tb_RealTimeData set Temperatura = '" + Temperatura + "' where Email= '" + Email + "'";
                cmd = new SqlCommand(q, connection);
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteReader();
                status = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                cmd.Dispose();
            }
            return status;


        }


        [Route("/GetLeituras/{Email}")]
        public List<LeituraBandas> GetLeituras(string Email)
        {
            List<LeituraBandas> UserList = new List<LeituraBandas>();
            SqlConnection connection = new SqlConnection(this.conStr);
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from tb_LeituraBandas where Email='"+Email+"'", connection);
            cmd.CommandType = CommandType.Text;
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                LeituraBandas user = new LeituraBandas();
                user.LeituraID= sdr["LeituraID"].ToString();
                user.Email = sdr["Email"].ToString();
                user.Data = sdr["Data"].ToString();
                user.Identifier = sdr["Identifier"].ToString();
                user.Sequencia = sdr["Sequencia"].ToString();
                user.AnalogData = sdr["AnalogData"].ToString();
                user.DigitalInput = sdr["DigitalInput"].ToString();


                UserList.Add(user);

            }
            return UserList;
        }



        [Route("/AddBlob/")] 
        [HttpPost]
        public int AddBlob(string Email, string Date, string blob)
        {
            int status = 0;
            SqlConnection connection = new SqlConnection(this.conStr);
            SqlCommand cmd = new SqlCommand();
            try
            {

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string q = "insert into tb_LeituraBandas (Email, Date, Blob) values ('"+Email+"', '"+Date+"', CAST('"+blob+"' AS nvarchar(MAX))) ";
                cmd = new SqlCommand(q, connection);
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteReader();
                status = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                cmd.Dispose();
            }
            return status;


        }

        [Route("/GetBlob/{Email}")]
        public List<BlobM> GetBlob(string Email)
        {
            List<BlobM> UserList = new List<BlobM>();
            SqlConnection connection = new SqlConnection(this.conStr);
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from tb_LeituraBandas where Email='"+Email+"'", connection);
            cmd.CommandType = CommandType.Text;
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                BlobM user = new BlobM();
                user.IDM = sdr["IDM"].ToString();
                user.Email = sdr["Email"].ToString();
                user.Date = sdr["Date"].ToString();
                user.Blob = sdr["Blob"];


                UserList.Add(user);

            }
            return UserList;
        }


        [Route("/GetBlobED/{Email}/{Data}")]
        public List<BlobM> GetBlobED(string Email, string Data)
        {
            List<BlobM> UserList = new List<BlobM>();
            SqlConnection connection = new SqlConnection(this.conStr);
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from tb_LeituraBandas where Email='" + Email + "' and Date='"+Data+"'", connection);
            cmd.CommandType = CommandType.Text;
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                BlobM user = new BlobM();
                user.IDM = sdr["IDM"].ToString();
                user.Email = sdr["Email"].ToString();
                user.Date = sdr["Date"].ToString();
                user.Blob = sdr["Blob"];


                UserList.Add(user);

            }
            return UserList;
        }


        [Route("/UpdateRelatorio")]
        [HttpPost]
        public int UpdateRelatorio(string Relatorio, string Data, string NomeOperador)
        {
            int status = 0;
            SqlConnection connection = new SqlConnection(this.conStr);
            SqlCommand cmd = new SqlCommand();
            try
            {



                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string q = "update tb_SOSEvent set Relatorio='"+Relatorio+"', Data='"+Data+"', NomeOperador='"+NomeOperador+"' where SOSID=(select MIN(SOSID) from tb_SOSEvent where Relatorio IS NULL)";
                cmd = new SqlCommand(q, connection);
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteReader();
                status = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                cmd.Dispose();
            }
            return status;


        }



        /*// GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }


    public class UserInfo
    {

        public string Weight { get; set; }

        public string Height { get; set; }

        public string BloodType { get; set; }

        public string Diabetes { get; set; }

        public string Epilepsy { get; set; }

        public string Asma { get; set; }

        public string Allergies { get; set; }

        public string Observations { get; set; }

        public string FirstName { get; set; }

        public string Email { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Birthday { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }

        public string Lat { get; set; }

        public string Lng { get; set; }

        public string BPM { get; set; }

        public string Temperatura { get; set; }

    }
}


//update tb_RealTimeData set Lng = '11111' where Email = (select Email from tb_SOSEvent where SosID='6')