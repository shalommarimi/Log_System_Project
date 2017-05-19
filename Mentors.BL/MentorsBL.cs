using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentors.BL
{
    public class MentorsBL
    {
        public int MentorID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string RSAID { get; set; }
        public string Role { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
    public class MentorsBusinessLogic
    {
        string consString = ConfigurationManager.ConnectionStrings["Dal"].ConnectionString;
        public IEnumerable<MentorsBL> Mentor
        {
            get
            {
                List<MentorsBL> Mentor = new List<MentorsBL>();
                using (SqlConnection consObj = new SqlConnection(consString))
                {

                    SqlCommand cmdsObj = new SqlCommand("spSelectMentors", consObj);
                    consObj.Open();
                    SqlDataReader readersObj = cmdsObj.ExecuteReader();
                    while (readersObj.Read())
                    {
                        MentorsBL MentorDe = new MentorsBL();
                        MentorDe.MentorID = Convert.ToInt32(readersObj["MentorID"]);
                        MentorDe.FirstName = readersObj["FirstName"].ToString();
                        MentorDe.MiddleName = readersObj["MiddleName"].ToString();
                        MentorDe.Surname = readersObj["Surname"].ToString();
                        MentorDe.Gender = readersObj["Gender"].ToString();
                        MentorDe.DOB = Convert.ToDateTime(readersObj["DOB"]);
                        MentorDe.RSAID = readersObj["RSAID"].ToString();
                        MentorDe.Role = readersObj["Role"].ToString();
                        MentorDe.Mobile = readersObj["Mobile"].ToString();
                        MentorDe.Email = readersObj["Email"].ToString();
                        MentorDe.Username = readersObj["Username"].ToString();
                        MentorDe.Password = readersObj["Password"].ToString();
                        MentorDe.IsActive = Convert.ToBoolean(readersObj["IsActive"]);


                        Mentor.Add(MentorDe);


                    }


                }
                return Mentor;
            }
        }

        public int InsertMentor(MentorsBL Mentor)
        {
            using (SqlConnection consObj = new SqlConnection(consString))
            {

                SqlCommand cmdsObj = new SqlCommand("spInsertMentor", consObj);
                cmdsObj.CommandType = CommandType.StoredProcedure;
                cmdsObj.Parameters.Add(new SqlParameter("@FirstName", Mentor.FirstName));
                cmdsObj.Parameters.Add(new SqlParameter("@MiddleName", Mentor.MiddleName));
                cmdsObj.Parameters.Add(new SqlParameter("@Surname", Mentor.Surname));
                cmdsObj.Parameters.Add(new SqlParameter("@Gender", Mentor.Gender));
                cmdsObj.Parameters.Add(new SqlParameter("@DOB", Mentor.DOB));
                cmdsObj.Parameters.Add(new SqlParameter("@RSAID", Mentor.RSAID));
                cmdsObj.Parameters.Add(new SqlParameter("@Role", Mentor.Role));
                cmdsObj.Parameters.Add(new SqlParameter("@Mobile", Mentor.Mobile));
                cmdsObj.Parameters.Add(new SqlParameter("@Email", Mentor.Email));
                cmdsObj.Parameters.Add(new SqlParameter("@Username", Mentor.Username));
                cmdsObj.Parameters.Add(new SqlParameter("@Password", Mentor.Password));
                cmdsObj.Parameters.Add(new SqlParameter("@IsActive", Mentor.IsActive));
                consObj.Open();
                return Convert.ToInt32(cmdsObj.ExecuteScalar());

            }

        }

        public int UpdateMentor(MentorsBL Mentor)
        {
            using (SqlConnection consObj = new SqlConnection(consString))
            {

                SqlCommand cmdsObj = new SqlCommand("uspMentorsUpdate", consObj);
                cmdsObj.CommandType = CommandType.StoredProcedure;
                cmdsObj.Parameters.Add(new SqlParameter("@MentorID", Mentor.MentorID));
                cmdsObj.Parameters.Add(new SqlParameter("@FirstName", Mentor.FirstName));
                cmdsObj.Parameters.Add(new SqlParameter("@MiddleName", Mentor.MiddleName));
                cmdsObj.Parameters.Add(new SqlParameter("@Surname", Mentor.Surname));
                cmdsObj.Parameters.Add(new SqlParameter("@Gender", Mentor.Gender));
                cmdsObj.Parameters.Add(new SqlParameter("@DOB", Mentor.DOB));
                cmdsObj.Parameters.Add(new SqlParameter("@RSAID", Mentor.RSAID));
                cmdsObj.Parameters.Add(new SqlParameter("@Role", Mentor.Role));
                cmdsObj.Parameters.Add(new SqlParameter("@Mobile", Mentor.Mobile));
                cmdsObj.Parameters.Add(new SqlParameter("@Email", Mentor.Email));
                cmdsObj.Parameters.Add(new SqlParameter("@Username", Mentor.Username));
                cmdsObj.Parameters.Add(new SqlParameter("@Password", Mentor.Password));
                cmdsObj.Parameters.Add(new SqlParameter("@IsActive", Mentor.IsActive)); consObj.Open();
                return Convert.ToInt32(cmdsObj.ExecuteScalar());

            }

        }

        public int DeleteMentor(int MentorID)
        {
            using (SqlConnection consObj = new SqlConnection(consString))
            {

                SqlCommand cmdsObj = new SqlCommand("spDeleteMentor", consObj);
                cmdsObj.CommandType = CommandType.StoredProcedure;
                cmdsObj.Parameters.Add(new SqlParameter("@MentorID", MentorID));
                consObj.Open();
                return Convert.ToInt32(cmdsObj.ExecuteScalar());

            }

        }

    }
}
 