using MVC_CRUD_Application.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;

namespace MVC_CRUD_Application.DatabaseModel
{
   
    public class clsStudentDatabase
    {
        private string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        public List<clsStudentModel> GetAllStudents()
        {
            List<clsStudentModel> objstudentModel = new List<clsStudentModel>();
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("Student_spGetStudent", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            con.Open();
                            sda.Fill(dt);
                            con.Close() ;
                            foreach (DataRow dr in dt.Rows)
                            {
                                objstudentModel.Add(new clsStudentModel {
                                                    StudentId = Convert.ToInt32(dr["Id"]),
                                                    Name = Convert.ToString(dr["Name"]),
                                                    Address = Convert.ToString(dr["Address"]),
                                                    City = Convert.ToString(dr["City"])
                                });
                            }
                            return objstudentModel;
                        }
                    }
                }
            }
        }

        public bool AddStudent(clsStudentModel objstudentModel)
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("Student_spInsertStudent", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", objstudentModel.Name);
                    cmd.Parameters.AddWithValue("@Address", objstudentModel.Address);
                    cmd.Parameters.AddWithValue("@City", objstudentModel.City);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public bool UpdateStudent(clsStudentModel objstudentModel)
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("Student_spUpdateStudent", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StudentId", objstudentModel.StudentId);
                    cmd.Parameters.AddWithValue("@Name", objstudentModel.Name);
                    cmd.Parameters.AddWithValue("@Address", objstudentModel.Address);
                    cmd.Parameters.AddWithValue("@City", objstudentModel.City);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i > 0)
                    {
                        return true;
                    }
                    else 
                    {
                        return false;
                    }
                }
            }
        }

        public bool DeleteStudent(int id)
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("Student_DeleteStudentById", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StudentId",id);
                    con.Open() ;
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i > 0)
                    {
                        return true;
                    }
                    else 
                    {
                        return false;
                    }
                }
            }
        }
    }
}