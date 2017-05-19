using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.BL
{
    public class LearnersDetails
    {

        public int LearnerID { get; set; }
        public string Names { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string RSAID { get; set; }
        public string Learnership { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string IsUserActive { get; set; }
    }

    public class LearnersBusinessLogic
    {
        string consString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        public IEnumerable<LearnersDetails> Learner
        {
            get
            {
                List<LearnersDetails> Learner = new List<LearnersDetails>();
                using (SqlConnection consObj = new SqlConnection(consString))
                {

                    SqlCommand cmdsObj = new SqlCommand("uspSelectLearnersDetails", consObj);
                    consObj.Open();
                    SqlDataReader readersObj = cmdsObj.ExecuteReader();
                    while (readersObj.Read())
                    {
                        LearnersDetails LearnDe = new LearnersDetails();
                        LearnDe.LearnerID = Convert.ToInt32(readersObj["LearnerID"]);
                        LearnDe.Names = readersObj["Names"].ToString();
                        LearnDe.Surname = readersObj["Surname"].ToString();
                        LearnDe.Gender = readersObj["Gender"].ToString();
                        LearnDe.DOB = Convert.ToDateTime(readersObj["DOB"]);
                        LearnDe.RSAID = readersObj["RSAID"].ToString();
                        LearnDe.Learnership = readersObj["Learnership"].ToString();
                        LearnDe.Mobile = readersObj["Mobile"].ToString();
                        LearnDe.Email = readersObj["Email"].ToString();
                        LearnDe.Username = readersObj["Username"].ToString();
                        LearnDe.Password = readersObj["Password"].ToString();
                        LearnDe.IsUserActive = readersObj["IsUserActive"].ToString();


                        Learner.Add(LearnDe);


                    }


                }
                return Learner;
            }
        }

        public int InsertLearner(LearnersDetails Learner)
        {
            using (SqlConnection consObj = new SqlConnection(consString))
            {

                SqlCommand cmdsObj = new SqlCommand("spInsertLearners", consObj);
                cmdsObj.CommandType = CommandType.StoredProcedure;
                cmdsObj.Parameters.Add(new SqlParameter("@Names", Learner.Names));
                cmdsObj.Parameters.Add(new SqlParameter("@Surname", Learner.Surname));
                cmdsObj.Parameters.Add(new SqlParameter("@Gender", Learner.Gender));
                cmdsObj.Parameters.Add(new SqlParameter("@DOB", Learner.DOB));
                cmdsObj.Parameters.Add(new SqlParameter("@RSAID", Learner.RSAID));
                cmdsObj.Parameters.Add(new SqlParameter("@Learnership", Learner.Learnership));
                cmdsObj.Parameters.Add(new SqlParameter("@Mobile", Learner.Mobile));
                cmdsObj.Parameters.Add(new SqlParameter("@Email", Learner.Email));
                cmdsObj.Parameters.Add(new SqlParameter("@Username", Learner.Username));
                cmdsObj.Parameters.Add(new SqlParameter("@Password", Learner.Password));
                cmdsObj.Parameters.Add(new SqlParameter("@IsUserActive", Learner.IsUserActive));
                consObj.Open();
                return Convert.ToInt32(cmdsObj.ExecuteScalar());

            }

        }

        public int UpdateLearner(LearnersDetails Learner)
        {
            using (SqlConnection consObj = new SqlConnection(consString))
            {

                SqlCommand cmdsObj = new SqlCommand("spUpdateLearners", consObj);
                cmdsObj.CommandType = CommandType.StoredProcedure;
                cmdsObj.Parameters.Add(new SqlParameter("@LearnerID", Learner.LearnerID));
                cmdsObj.Parameters.Add(new SqlParameter("@Names", Learner.Names));
                cmdsObj.Parameters.Add(new SqlParameter("@Surname", Learner.Surname));
                cmdsObj.Parameters.Add(new SqlParameter("@Gender", Learner.Gender));
                cmdsObj.Parameters.Add(new SqlParameter("@DOB", Learner.DOB));
                cmdsObj.Parameters.Add(new SqlParameter("@RSAID", Learner.RSAID));
                cmdsObj.Parameters.Add(new SqlParameter("@Learnership", Learner.Learnership));
                cmdsObj.Parameters.Add(new SqlParameter("@Mobile", Learner.Mobile));
                cmdsObj.Parameters.Add(new SqlParameter("@Email", Learner.Email));
                cmdsObj.Parameters.Add(new SqlParameter("@Username", Learner.Username));
                cmdsObj.Parameters.Add(new SqlParameter("@Password", Learner.Password));
                cmdsObj.Parameters.Add(new SqlParameter("@IsUserActive", Learner.IsUserActive)); consObj.Open();
                return Convert.ToInt32(cmdsObj.ExecuteScalar());

            }

        }

        public int DeleteLearner(int LearnerID)
        {
            using (SqlConnection consObj = new SqlConnection(consString))
            {

                SqlCommand cmdsObj = new SqlCommand("spDeleteLearners", consObj);
                cmdsObj.CommandType = CommandType.StoredProcedure;
                cmdsObj.Parameters.Add(new SqlParameter("@LearnerID", LearnerID));
                consObj.Open();
                return Convert.ToInt32(cmdsObj.ExecuteScalar());

            }

        }

    }
}
