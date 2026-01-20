using CRUD_ADO.Models;
using System.Data;
using System.Collections.Generic;

using Microsoft.Data.SqlClient;
using System.Data.SqlTypes;

namespace CRUD_ADO.DAL
{
    public class StudentDAL
    {
        private readonly string _connectionString; 

        //constructor to intialize the connenction string 
        public StudentDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Insert(Student student)
        {
            using SqlConnection con = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand("sp_InsertStudent", con);
            Console.WriteLine("currently inserting the query"); 
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", student.Name);
            cmd.Parameters.AddWithValue("@Email", student.Email);
            cmd.Parameters.AddWithValue("@Phone", student.Phone);
            cmd.Parameters.AddWithValue("@Age", student.Age);
            cmd.Parameters.AddWithValue("@DeptId", student.DeptId);
            cmd.Parameters.AddWithValue("@Gender", student.Gender);

            SqlParameter outId = new SqlParameter("@StudentId", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output,
            };

            cmd.Parameters.Add(outId);

            con.Open();
            cmd.ExecuteNonQuery();
            return Convert.ToInt32(outId.Value);
        }

        public List<StudentViewModel> readAll()
        {
            List<StudentViewModel> list = new List<StudentViewModel>(); 
            using SqlConnection con = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand("sp_SelectAllStudents", con);
             cmd.CommandType= CommandType.StoredProcedure;

            con.Open();
             
            SqlDataReader dr=cmd.ExecuteReader();

            while (dr.Read()) {
                list.Add(new StudentViewModel
                {
                    Id = Convert.ToInt32(dr["ID"]),
                    Name = dr["Name"].ToString(),
                    Email = dr["Email"].ToString(),
                    Phone = dr["Phone"].ToString(),
                    Age = Convert.ToInt32(dr["Age"]),
                    DepartmentName = dr["dept_name"].ToString(),
                    Gender = dr["Gender"].ToString(),
                    isActive = Convert.ToInt16(dr["isActive"])
                }

                    );
            }

            return list ;
        }

        public StudentViewModel GetStudentById(int id)
        {
            StudentViewModel student = new StudentViewModel();    
            using SqlConnection conn=new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand("sp_SelectStudentWithId", conn);
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id",id);

            conn.Open
                ();

            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read()!=null) {
                //Mapping this data to view model to return it to controller to frontend

            student.Id = Convert.ToInt32(dr["ID"]);
            student.Name = dr["Name"].ToString();
            student.Email = dr["Email"].ToString();
            student.Phone = dr["Phone"].ToString();
            student.Age = Convert.ToInt32(dr["Age"]);
                student.Gender = dr["Gender"].ToString();
                student.DeptId = Convert.ToInt32(dr["dept_id"]);
                student.DepartmentName = dr["dept_name"].ToString(); 

            return student ; 
                }
            return null; 
        }
        public void DeleteStudent(Student student)
        {

            
             using SqlConnection con=new SqlConnection(_connectionString);
            con.Open();

            //using SqlTransaction trn=con.BeginTransaction();

            try
            {

                using SqlCommand cmdStudent = new SqlCommand("sp_DeleteStudent", con);
                cmdStudent.CommandType = CommandType.StoredProcedure;
                cmdStudent.Parameters.AddWithValue("@StudentId", student.Id);
                cmdStudent.ExecuteNonQuery();

                //trn.Commit();
            }
            catch (Exception ex)
            {
                //trn.Rollback();
                throw;
            }

            con.Close(); 
        }

        public void UpdateStudent(Student student)
        {
              using SqlConnection con = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand("sp_UpdateStudent", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", student.Name);
            cmd.Parameters.AddWithValue("@Email", student.Email);
            cmd.Parameters.AddWithValue("@Phone", student.Phone);
            cmd.Parameters.AddWithValue("@Age", student.Age);
            cmd.Parameters.AddWithValue("@Gender", student.Gender);
            cmd.Parameters.AddWithValue("@DeptId", student.DeptId);
            cmd.Parameters.AddWithValue("@Id",student.Id);

            con.Open();

            cmd.ExecuteNonQuery();

            con.Close(); 
        }

        public List<Department> GetAllDepartments()
        {
            List<Department> departments = new List<Department>();
            using SqlConnection conn= new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand("sp_getAllDepartments", conn);

            conn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while(dr.Read())
            {
                departments.Add(
                        new Department
                        {
                            DeptId = Convert.ToInt32(dr["dept_id"]),
                            DeptName = dr["dept_name"].ToString()
                        }
                    );
            }

            return departments; 
        }


        public List<DocTypeViewModel> GetAllDocTypes()
        {
            List<DocTypeViewModel>  doc_types= new List<DocTypeViewModel>();    
            using SqlConnection con= new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand("sp_GetAllDocTypes", con); 

            con.Open(); 
            SqlDataReader dr=cmd.ExecuteReader();

            while (dr.Read())
            {
                doc_types.Add(new DocTypeViewModel
                {
                    DocId = Convert.ToInt32(dr["DocId"]),
                    DocName = dr["DocName"].ToString(),

                });
             }

            return doc_types;
        }

        public void InsertStudentDocuments(int StudentId, int DocId)
        {
            using SqlConnection conn= new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand("sp_InsertStudentDocuments", conn);
            cmd.CommandType=CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@StudentId", StudentId);
            cmd.Parameters.AddWithValue("@DocId",DocId);

            conn.Open();

            cmd.ExecuteNonQuery();

        }

        public void InsertStudentDocumentFiles(int  StudentId, int DocId,string FileName,string FilePath)
        {
             using SqlConnection conn= new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand("sp_InsertStudentDocumentFile", conn);
             cmd.CommandType = CommandType.StoredProcedure; 
             
            cmd.Parameters.AddWithValue("@StudentId",StudentId);
            cmd.Parameters.AddWithValue("@DocId", DocId);
            cmd.Parameters.AddWithValue("@FileName", FileName);
            cmd.Parameters.AddWithValue("@FilePath", FilePath);


            conn.Open();

            cmd.ExecuteNonQuery();

        }

        public List<StudentDocumentViewModel> GetStudentDocuments(int StudentId)
        {
            List <StudentDocumentViewModel> sd=new List<StudentDocumentViewModel>();

            using SqlConnection con= new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand("sp_GetStudentDocuments", con);
            cmd.CommandType= CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@StudentId", StudentId);

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                sd.Add(new StudentDocumentViewModel
                {
                    StudentId = dr["StudentId"]== DBNull.Value ? 0 :   Convert.ToInt32(dr["StudentId"]),
                    DocumentId = Convert.ToInt32(dr["DocId"]),
                    DocumentName = dr["DocName"].ToString(),
                    FilePath = dr["FilePath"]==DBNull.Value ? null : dr["FilePath"].ToString(),
                    FileName = dr["FileName"]==DBNull.Value ? null : dr["FileName"].ToString()
                });
            }

            return sd; 
        }

        public void UpdateStudentDocumentFile(int StudentId,int DocId,string FileName,string FilePath)
        {
            using SqlConnection con = new SqlConnection(_connectionString);
            con.Open();

            using SqlTransaction txn = con.BeginTransaction();

            try
            {


                using SqlCommand cmd = new SqlCommand("sp_UpdateStudentDocumentFile", con, txn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentId", StudentId);
                cmd.Parameters.AddWithValue("@DocId", DocId);
                cmd.Parameters.AddWithValue("@FileName", FileName);
                cmd.Parameters.AddWithValue("@FilePath", FilePath);
                cmd.ExecuteNonQuery();


                using SqlCommand cmd1 = new SqlCommand("sp_UpdateStudentDocumentFile", con, txn);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@StudentId", StudentId);
                cmd1.Parameters.AddWithValue("@DocId", DocId);
                cmd.ExecuteNonQuery();

                txn.Commit();

            }
            catch (Exception ex)
            {
                txn.Rollback();
                throw;
            }

            con.Close();
            
        }
    }
}
