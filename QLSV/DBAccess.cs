using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace QLSV
{

    internal class DBAccess
    {
        SqlConnection con;
        private void Open()
        {
            con = new SqlConnection(@"Data Source=LAPTOP-UJLMGMV1;Initial Catalog=QLSV;Integrated Security=True");
            con.Open();
        }
        private void Close()
        {
            con.Close();
        }
        //Sinh vien
        public DataTable DSSinhVien()
        {
            DataTable dt = new DataTable();
            Open();
            string sql = "SELECT [FirstName], [LastName], [StudentCode], [Email], [Phone], [MajorID], [Gender], [Addresses], [IdentityNumber], [Cohort], [DOB], [Note] FROM [QLSV].[dbo].[Students] WHERE [IsDeleted] = 0;";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            Close();
            return dt;
        }
        public void InsertSV(string ho, string ten, string masv, string email, string sdt, string chuyennganh, string gioitinh, string diachi, string cccd, string nienkhoa, DateTime ngaysinh, string ghichu, int a = 0)
        {
            Open();
            string sql = "INSERT INTO [QLSV].[dbo].[Students] " +
                         "([FirstName], [LastName], [StudentCode], [Email], [Phone], [MajorID], [Gender], [Addresses], [IdentityNumber], [Cohort], [DOB], [Note], [IsDeleted]) " +
                         "VALUES (@ho, @ten, @masv, @email, @sdt, @chuyennganh, @gioitinh, @diachi, @cccd, @nienkhoa, @ngaysinh, @ghichu, @a)";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@ho", ho);
                cmd.Parameters.AddWithValue("@ten", ten);
                cmd.Parameters.AddWithValue("@masv", masv);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@sdt", sdt);
                cmd.Parameters.AddWithValue("@chuyennganh", chuyennganh);
                cmd.Parameters.AddWithValue("@gioitinh", gioitinh);
                cmd.Parameters.AddWithValue("@diachi", diachi);
                cmd.Parameters.AddWithValue("@cccd", cccd);
                cmd.Parameters.AddWithValue("@nienkhoa", nienkhoa);
                cmd.Parameters.AddWithValue("@ngaysinh", ngaysinh);
                cmd.Parameters.AddWithValue("@ghichu", ghichu);
                cmd.Parameters.AddWithValue("@a", a);

                cmd.ExecuteNonQuery();
            }
            Close();
        }

        public void DeleteSV(int a, string ma)
        {
            Open();
            string sql = "UPDATE [QLSV].[dbo].[Students] SET   [IsDeleted] = @a WHERE [StudentCode] = @masv";
            SqlCommand cmd = new SqlCommand(sql, con);
            a = 1;
            cmd.Parameters.AddWithValue("@a", a);
            cmd.Parameters.AddWithValue("@masv", ma);
            cmd.ExecuteNonQuery();
            Close();
        }
        public void UpdateSV(string ho, string ten, string email, string sdt, string chuyennganh, string gioitinh, string diachi, string cccd, string nienkhoa, DateTime ngaysinh, string ghichu, string ma)
        {
            Open();
            string sqlUpdate = "UPDATE [QLSV].[dbo].[Students] " +  // Thêm khoảng trắng ở đây
                         "SET [FirstName] = @ho, " +
                         "[LastName] = @ten, " +
                         "[Email] = @email, " +
                         "[Phone] = @sdt, " +
                         "[MajorID] = @chuyennganh, " +
                         "[Gender] = @gioitinh, " +
                         "[Addresses] = @diachi, " +
                         "[IdentityNumber] = @cccd, " +
                         "[Cohort] = @nienkhoa, " +
                         "[DOB] = @ngaysinh, " +
                         "[Note] = @ghichu " +
                         "WHERE [StudentCode] = @ma AND [IsDeleted] = 0 ";

            using (SqlCommand cmd = new SqlCommand(sqlUpdate, con))
            {
                cmd.Parameters.AddWithValue("@ho", ho);
                cmd.Parameters.AddWithValue("@ten", ten);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@sdt", sdt);
                cmd.Parameters.AddWithValue("@chuyennganh", chuyennganh);
                cmd.Parameters.AddWithValue("@gioitinh", gioitinh);
                cmd.Parameters.AddWithValue("@diachi", diachi);
                cmd.Parameters.AddWithValue("@cccd", cccd);
                cmd.Parameters.AddWithValue("@nienkhoa", nienkhoa);
                cmd.Parameters.AddWithValue("@ngaysinh", ngaysinh);
                cmd.Parameters.AddWithValue("@ghichu", ghichu);
                cmd.Parameters.AddWithValue("@ma", ma);

                cmd.ExecuteNonQuery();
            }
            Close();
        }
        public int CountStudentsByID(string studentID)
        {
            Open();
            int count = 0;
            string query = "SELECT COUNT(*) FROM Students WHERE StudentCode = @StudentID AND IsDeleted = 0"; // Giả sử bạn có cột IsDeleted

            
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@StudentID", studentID);
                    count = (int)cmd.ExecuteScalar();
                }
            Close ();   
            return count;
        }
        //Sinh vien
        //Danh muc mon hoc
        public DataTable DSCourseCategories()
        {
            DataTable dt = new DataTable();
            Open();
            string sql = "SELECT [CourseCatID], [CourseCatName] FROM [QLSV].[dbo].[CourseCategories] WHERE [IsDeleted] = 0;"; // Truy vấn SQL
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            Close();
            return dt;
        }
        public void InsertCourseCategory(string courseCatName, int isDeleted = 0)
        {
            Open();
            string sqlInsert = "INSERT INTO [QLSV].[dbo].[CourseCategories] ([CourseCatName], [IsDeleted]) " +
                               "VALUES (@courseCatName, @isDeleted);";

            using (SqlCommand cmd = new SqlCommand(sqlInsert, con))
            {
                cmd.Parameters.AddWithValue("@courseCatName", courseCatName);
                cmd.Parameters.AddWithValue("@isDeleted", isDeleted);

                cmd.ExecuteNonQuery();
            }
            Close();
        }
        public void UpdateCourseCategory(string courseCatName, string courseCatID)
        {
            Open();
            string sqlUpdate = "UPDATE [QLSV].[dbo].[CourseCategories] " +
                               "SET [CourseCatName] = @courseCatName " +
                               "WHERE [CourseCatID] = @courseCatID AND [IsDeleted] = 0 ";

            using (SqlCommand cmd = new SqlCommand(sqlUpdate, con))
            {
                cmd.Parameters.AddWithValue("@courseCatName", courseCatName);
                cmd.Parameters.AddWithValue("@courseCatID", courseCatID);

                cmd.ExecuteNonQuery();
            }
            Close();
        }

        public void DeleteCourseCategory(string courseCatID)
        {
            Open();
            string sqlDelete = "UPDATE [QLSV].[dbo].[CourseCategories] " +
                               "SET " +
                               "[IsDeleted] = 1 " +
                               "WHERE [CourseCatID] = @courseCatID";

            using (SqlCommand cmd = new SqlCommand(sqlDelete, con))
            {
                cmd.Parameters.AddWithValue("@courseCatID", courseCatID);
                cmd.ExecuteNonQuery();
            }
            Close();
        }
        //Danh muc mon hoc
        // Mon hoc
        public DataTable DSCourses()
        {
            DataTable dt = new DataTable();
            Open();
            string sql = "SELECT [CourseID],[CourseCode], [CourseName], [CourseCredits], [CourseCatID], [ClassSessions], [MaxAllowedAbsences],PointToPass FROM [QLSV].[dbo].[Courses] WHERE [IsDeleted] = 0;";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            Close();
            return dt;
        }
        public void InsertCourse(string courseCode, string courseName, string courseCredits, string courseCatID, string classSessions, string maxAllowedAbsences, float PointToPass, bool isDeleted = false)
        {
            Open();
            string sql = "INSERT INTO [QLSV].[dbo].[Courses] " +
                         "([CourseCode], [CourseName], [CourseCredits], [CourseCatID], [ClassSessions], [MaxAllowedAbsences], PointToPass,[IsDeleted]) " +
                         "VALUES (@courseCode, @courseName, @courseCredits, @courseCatID, @classSessions, @maxAllowedAbsences,@PointToPass, @isDeleted)";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@courseCode", courseCode);
                cmd.Parameters.AddWithValue("@courseName", courseName);
                cmd.Parameters.AddWithValue("@courseCredits", courseCredits);
                cmd.Parameters.AddWithValue("@courseCatID", courseCatID);
                cmd.Parameters.AddWithValue("@classSessions", classSessions);
                cmd.Parameters.AddWithValue("@maxAllowedAbsences", maxAllowedAbsences);
                cmd.Parameters.AddWithValue("@PointToPass", PointToPass);
                cmd.Parameters.AddWithValue("@isDeleted", isDeleted);

                cmd.ExecuteNonQuery();
            }
            Close();
        }
        public void UpdateCourse(string courseName, string courseCredits, string courseCatID, string classSessions, string maxAllowedAbsences, float PointToPass, string courseCode)
        {
            Open();
            string sqlUpdate = "UPDATE [QLSV].[dbo].[Courses] " +
                               "SET " +
                               "[CourseName] = @courseName, " +
                               "[CourseCredits] = @courseCredits, " +
                               "[CourseCatID] = @courseCatID, " +
                               "[ClassSessions] = @classSessions, " +
                               "[MaxAllowedAbsences] = @maxAllowedAbsences," +
                               "[PointToPass] = @PointToPass " +
                               "WHERE [CourseCode] = @courseCode AND [IsDeleted] = 0";

            using (SqlCommand cmd = new SqlCommand(sqlUpdate, con))
            {

                cmd.Parameters.AddWithValue("@courseName", courseName);
                cmd.Parameters.AddWithValue("@courseCredits", courseCredits);
                cmd.Parameters.AddWithValue("@courseCatID", courseCatID);
                cmd.Parameters.AddWithValue("@classSessions", classSessions);
                cmd.Parameters.AddWithValue("@maxAllowedAbsences", maxAllowedAbsences);
                cmd.Parameters.AddWithValue("@PointToPass", PointToPass);
                cmd.Parameters.AddWithValue("@courseCode", courseCode);
                cmd.ExecuteNonQuery();
            }
            Close();
        }
        public void DeleteCourse(string courseCode, bool a = true)
        {
            Open();
            string sql = "UPDATE [QLSV].[dbo].[Courses] SET [IsDeleted] = @a WHERE [CourseCode] = @courseCode";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@a", a);
                cmd.Parameters.AddWithValue("@courseCode", courseCode);
                cmd.ExecuteNonQuery();
            }
            Close();
        }

        //Mon hoc

        // Dau diem
        public DataTable DSAssessmentTypes()
        {
            DataTable dt = new DataTable();
            Open();
            string sql = "SELECT  [AssTypeID], [CourseID], [AssTypeName], [WeightPercentage], [ExamsNo] FROM [QLSV].[dbo].[AssessmentTypes] WHERE [IsDeleted] = 0;";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            Close();
            return dt;
        }
        public DataTable DSDauDiemTheoMaMon(string id)
        {
            DataTable dt = new DataTable();
            Open();
            string sql = "SELECT  [AssTypeID], [CourseID], [AssTypeName], [WeightPercentage], [ExamsNo] FROM [QLSV].[dbo].[AssessmentTypes] WHERE [IsDeleted] = 0 AND CourseID=@id";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            Close();
            return dt;
        }
        public void AddAssessmentType(string courseId, string assTypeName, float weightPercentage, string examsNo)
        {
            Open();
            string sql = "INSERT INTO [QLSV].[dbo].[AssessmentTypes] ([CourseID], [AssTypeName], [WeightPercentage], [ExamsNo], [IsDeleted]) VALUES (@courseId, @assTypeName, @weightPercentage, @examsNo, 0);";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@courseId", courseId);
                cmd.Parameters.AddWithValue("@assTypeName", assTypeName);
                cmd.Parameters.AddWithValue("@weightPercentage", weightPercentage);
                cmd.Parameters.AddWithValue("@examsNo", examsNo);

                cmd.ExecuteNonQuery();
            }
            Close();
        }
        public void UpdateAssessmentType(string assTypeId, string courseId, string assTypeName, float weightPercentage, string examsNo)
        {
            Open();
            string sql = "UPDATE [QLSV].[dbo].[AssessmentTypes] SET [CourseID] = @courseId, [AssTypeName] = @assTypeName, [WeightPercentage] = @weightPercentage, [ExamsNo] = @examsNo WHERE [AssTypeID] = @assTypeId AND [IsDeleted] = 0;";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@assTypeId", assTypeId);
                cmd.Parameters.AddWithValue("@courseId", courseId);
                cmd.Parameters.AddWithValue("@assTypeName", assTypeName);
                cmd.Parameters.AddWithValue("@weightPercentage", weightPercentage);
                cmd.Parameters.AddWithValue("@examsNo", examsNo);

                cmd.ExecuteNonQuery();
            }
            Close();
        }
        public void DeleteAssessmentType(string assTypeId, string courseId)
        {
            Open();
            string sql = "UPDATE [QLSV].[dbo].[AssessmentTypes] SET [IsDeleted] = 1 WHERE [AssTypeID] = @assTypeId";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@assTypeId", assTypeId);
                cmd.Parameters.AddWithValue("@courseId", courseId);
                cmd.ExecuteNonQuery();
            }
            Close();
        }
        //Dau diem
        //Nganh hoc

        public DataTable DSMajors()
        {
            DataTable dt = new DataTable();
            Open();
            string sql = "SELECT TOP (1000) [MajorID], [MajorName] FROM [QLSV].[dbo].[Majors] WHERE [IsDeleted] = 0;";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            Close();
            return dt;
        }
        public void AddMajor(string majorName)
        {
            Open();
            string sql = "INSERT INTO [QLSV].[dbo].[Majors] ([MajorName], [IsDeleted]) VALUES (@majorName, 0);";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@majorName", majorName);
                cmd.ExecuteNonQuery();
            }
            Close();
        }
        public void UpdateMajor(string majorId, string majorName)
        {
            Open();
            string sql = "UPDATE [QLSV].[dbo].[Majors] SET [MajorName] = @majorName WHERE [MajorID] = @majorId AND [IsDeleted] = 0;";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@majorId", majorId);
                cmd.Parameters.AddWithValue("@majorName", majorName);
                cmd.ExecuteNonQuery();
            }
            Close();
        }
        public void DeleteMajor(string majorId)
        {
            Open();
            string sql = "UPDATE [QLSV].[dbo].[Majors] SET [IsDeleted] = 1 WHERE [MajorID] = @majorId;";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@majorId", majorId);
                cmd.ExecuteNonQuery();
            }
            Close();
        }
        //Nganh hoc
        //Diem
        public DataTable getIDFromCode(string id)
        {
            DataTable dt = new DataTable();
            Open();
            string sql = @"
              SELECT 
                    StudentID
                FROM 
                    Students
                WHERE
                    StudentCode = @id;
           
";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            Close();
            return dt;
        }


        public DataTable getCodeFromID(string id)
        {
            DataTable dt = new DataTable();
            Open();
            string sql = @"
              SELECT 
                    StudentCode
                FROM 
                    Students
                WHERE
                    StudentID = @id;
           
";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            Close();
            return dt;
        }
        public int GetIdFromClassName(string id)
        {
            int classID= -1;
            Open();
            string sql = @"
              SELECT 
                    ClassID
                FROM 
                    Classes
                WHERE
                    ClassName = @id;
           
";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        classID = reader.GetInt32(reader.GetOrdinal("ClassID"));
                    }
                }
            }
            Close();
            return classID;
        }
        public int GetIdFromTypeName(string id)
        {
            int AssTypeID = -1;
            Open();
            string sql = @"
              SELECT 
                    AssTypeID
                FROM 
                    AssessmentTypes
                WHERE
                    AssTypeName = @id;
           
";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        AssTypeID = reader.GetInt32(reader.GetOrdinal("AssTypeID"));
                    }
                }
            }
            Close();
            return AssTypeID;
        }
        public DataTable DSDiem()
        {
            DataTable dt = new DataTable();
            Open();
            string sql = @"
                   SELECT 
                    s.ScoreID, 
                    st.StudentCode, 
                    c.ClassName,
                    a.AssTypeName, 
                    s.ScoreValue
                FROM 
                    Scores s
                JOIN 
                    Students st ON s.StudentID = st.StudentID
                JOIN 
                    Classes c ON s.ClassID = c.ClassID
		        JOIN 
                    AssessmentTypes a ON s.AssTypeID = a.AssTypeID
                WHERE
                    s.IsDeleted = 0;          
            ";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            Close();
            return dt;
        }
        public void AddScores(string masv, string lop, string maloaidiem, float diemso)
        {
            Open();
            string sql = "INSERT INTO Scores (StudentID,ClassID, AssTypeID, ScoreValue,IsDeleted) VALUES (@masv,@lop, @maloaidiem, @diemso,@delete)";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@masv", masv);
                cmd.Parameters.AddWithValue("@lop", lop);
                cmd.Parameters.AddWithValue("@maloaidiem", maloaidiem);
                cmd.Parameters.AddWithValue("@diemso", diemso);
                cmd.Parameters.AddWithValue("@delete", 0);
                cmd.ExecuteNonQuery();
            }
            Close();
        }
        public void UpdateScore(int scoreId, int ClassID, string masv, string maloaidiem, float diemso)
        {
            Open();
            string sql = "UPDATE Scores SET StudentID = @masv,ClassID=@classid, AssTypeID = @maloaidiem, ScoreValue = @diemso WHERE ScoreID = @scoreId";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@scoreId", scoreId);
                cmd.Parameters.AddWithValue("@classid", ClassID);
                cmd.Parameters.AddWithValue("@masv", masv);
                cmd.Parameters.AddWithValue("@maloaidiem", maloaidiem);
                cmd.Parameters.AddWithValue("@diemso", diemso);
                cmd.ExecuteNonQuery();
            }
            Close();
        }

        public DataTable DSDiemTheoClass(int classID)
        {
            DataTable dt = new DataTable();
            Open();
            string sql = @"
              SELECT 
                    s.ScoreID, 
                    st.StudentCode, 
                    c.ClassName,
                    a.AssTypeName, 
                    s.ScoreValue
                FROM 
                    Scores s
                JOIN 
                    Students st ON s.StudentID = st.StudentID
                JOIN 
                    Classes c ON s.ClassID = c.ClassID
		        JOIN 
                    AssessmentTypes a ON s.AssTypeID = a.AssTypeID
                WHERE
                    s.IsDeleted = 0 AND s.ClassID=@classID;
           
            ";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@classID", classID);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            Close();
            return dt;
        }
        //Diem
        //Kì học
        public DataTable DSSemester()
        {
            DataTable dt = new DataTable();
            Open();
            string sql = @"
                SELECT 
                    SemesterID, 
                    SemesterName, 
                    Years 
                FROM 
                    Semesters 
                WHERE 
                    IsDeleted = 0
                ";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            Close();
            return dt;
        }

        public void AddSemester(string semesterName, int year)
        {
            Open();
            string sql = "INSERT INTO Semesters (SemesterName, Years, IsDeleted) VALUES (@semesterName, @year, 0)";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@semesterName", semesterName);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.ExecuteNonQuery();
            }
            Close();
        }

        public void UpdateSemester(string semesterName, string year, string semesterId)
        {
            Open();
            string sql = "UPDATE Semesters SET SemesterName = @semesterName, Years = @year WHERE SemesterID = @semesterId AND IsDeleted = 0";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@semesterId", semesterId);
                cmd.Parameters.AddWithValue("@semesterName", semesterName);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.ExecuteNonQuery();
            }
            Close();
        }
        public void DeleteSemesters(string SemesterID)
        {
            Open();
            string sql = "UPDATE Semesters SET [IsDeleted] = 1 WHERE [SemesterID] = @SemesterID;";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@SemesterID", SemesterID);
                cmd.ExecuteNonQuery();
            }
            Close();
        }
        //ki hoc
        //Lop hoc

        public DataTable DSClasses()
        {
            DataTable dt = new DataTable();
            Open();
            string sql = @"
                SELECT 
                    ClassID,
                    CourseID, 
                    SemesterID, 
                    ClassName 
                FROM 
                    Classes
                WHERE 
                    IsDeleted = 0
                ";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            Close();
            return dt;
        }



        public void AddClasses(int CourseID, string SemesterID, string ClassName)
        {
            Open();
            string sql = "INSERT INTO Classes (CourseID, SemesterID,ClassName, IsDeleted) VALUES (@CourseID, @SemesterID,@ClassName, 0)";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@CourseID", CourseID);
                cmd.Parameters.AddWithValue("@SemesterID", SemesterID);
                cmd.Parameters.AddWithValue("@ClassName", ClassName);
                cmd.ExecuteNonQuery();
            }
            Close();
        }

        public void UpdateClass(string CourseID, string SemesterID, string ClassName, string id)
        {
            Open();
            string sql = "UPDATE Classes SET CourseID = @CourseID, SemesterID = @SemesterID, ClassName =@ClassName WHERE ClassID = @ClassID";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@CourseID", CourseID);
                cmd.Parameters.AddWithValue("@SemesterID", SemesterID);
                cmd.Parameters.AddWithValue("@ClassName", ClassName);
                cmd.Parameters.AddWithValue("@ClassId", id);
                cmd.ExecuteNonQuery();
            }
            Close();
        }
        public void DeleteClass(string ClassID)
        {
            Open();
            string sql = "UPDATE Classes SET [IsDeleted] = 1 WHERE [ClassID] = @ClassID;";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@ClassID", ClassID);
                cmd.ExecuteNonQuery();
            }
            Close();
        }
        //Lop hoc
        //Ghi danh
        public DataTable DSEnrollments()
        {
            DataTable dt = new DataTable();
            Open();
            string sql = @"
            SELECT 
	           e.EnrollID,
                c.ClassName,
                st.StudentCode,
                e.Absences,
                e.ExamsNo,
                e.ExamsTime,
                e.ExamsPoint
            FROM  
	            Enroll e
            JOIN 
                    Students st ON e.StudentID = st.StudentID
            JOIN 
                    Classes c ON e.ClassID = c.ClassID
            Where 
	                e.IsDeleted = 0;


        ";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            Close();
            return dt;
        }
        public DataTable DSEnrollmentsTheoID(int id)
        {
            DataTable dt = new DataTable();
            Open();
            string sql = @"
                   SELECT 
	           e.EnrollID,
                c.ClassName,
                st.StudentCode,
                e.Absences,
                e.ExamsNo,
                e.ExamsTime,
                e.ExamsPoint
            FROM  
	            Enroll e
            JOIN 
                    Students st ON e.StudentID = st.StudentID
            JOIN 
                    Classes c ON e.ClassID = c.ClassID
            Where 
	                e.IsDeleted = 0 AND e.ClassID=@id;

        ";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            Close();
            return dt;
        }
        public void AddEnrollment(int studentID, int classID, int absences, int examsNo, DateTime examsTime, float ExamsPoint)
        {
            Open();
            string sql = "INSERT INTO Enroll (StudentID, ClassID, Absences, ExamsNo, ExamsTime, ExamsPoint, IsDeleted) VALUES (@StudentID, @ClassID, @Absences, @ExamsNo,@ExamsTime,@ExamsPoint, 0)";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@StudentID", studentID);
                cmd.Parameters.AddWithValue("@ClassID", classID);
                cmd.Parameters.AddWithValue("@Absences", absences);
                cmd.Parameters.AddWithValue("@ExamsNo", examsNo);
                cmd.Parameters.AddWithValue("@ExamsTime", examsTime);
                cmd.Parameters.AddWithValue("@ExamsPoint", ExamsPoint);
                cmd.ExecuteNonQuery();
            }
            Close();
        }

        public void UpdateEnrollment(int enrollID, int studentID, int classID, int absences, int examsNo, DateTime examsTime, float ExamsPoint)
        {
            Open();
            string sql = "UPDATE Enroll SET StudentID = @StudentID, ClassID = @ClassID, Absences = @Absences, ExamsNo = @ExamsNo, ExamsTime = @examsTime, ExamsPoint = @ExamsPoint WHERE EnrollID = @EnrollID";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@EnrollID", enrollID);
                cmd.Parameters.AddWithValue("@StudentID", studentID);
                cmd.Parameters.AddWithValue("@ClassID", classID);
                cmd.Parameters.AddWithValue("@Absences", absences);
                cmd.Parameters.AddWithValue("@ExamsNo", examsNo);
                cmd.Parameters.AddWithValue("@examsTime", examsTime);
                cmd.Parameters.AddWithValue("@ExamsPoint", ExamsPoint);
                cmd.ExecuteNonQuery();
            }
            Close();
        }

        public void DeleteEnrollment(int enrollID)
        {
            Open();
            string sql = "UPDATE Enroll SET IsDeleted = 1 WHERE EnrollID = @EnrollID";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@EnrollID", enrollID);
                cmd.ExecuteNonQuery();
            }
            Close();
        }

        //ghi danh
        //Thong ke theo sinh vien
        public string getIDFromCodeString(string id)
        {
            string studentID = null;
            Open();

            // Check if StudentCode exists
            string checkSql = @"
                SELECT COUNT(*)
                FROM Students
                WHERE StudentCode = @id;
            ";

            using (SqlCommand checkCmd = new SqlCommand(checkSql, con))
            {
                checkCmd.Parameters.AddWithValue("@id", id);
                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    // Retrieve StudentID if StudentCode exists
                    string sql = @"
                SELECT 
                    StudentID
                FROM 
                    Students
                WHERE
                    StudentCode = @id;
            ";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                studentID = reader["StudentID"].ToString();
                            }
                        }
                    }
                }
                else
                {
                    studentID = "StudentCode does not exist.";
                }
            }

            Close();
            return studentID;
        }
        public List<string> getClassFromEnroll(string id)
        {
            List<string> classIDs = new List<string>();
            Open();
            string sql = @"
        SELECT 
            ClassID
        FROM 
            Enroll
        WHERE
            StudentID = @id;
    ";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        classIDs.Add(reader["ClassID"].ToString());
                    }
                }
            }
            Close();
            return classIDs;
        }
        public string getIDCourseFromClassID(string id)
        {
            string classIDs = "";
            Open();
            string sql = @"
        SELECT 
            CourseID
        FROM 
            Classes
        WHERE
            ClassID = @id;
    ";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        classIDs = reader["CourseID"].ToString();
                    }
                }
            }
            Close();
            return classIDs;
        }
        public DataTable ClassFromID(string id)
        {
            DataTable dt = new DataTable();
            Open();
            string sql = @"
                SELECT 
                    st.StudentCode,
                    cl.ClassName,
                    sm.SemesterName
                FROM 
                    Enroll e
                JOIN 
	                Students st on e.StudentID=st.StudentID
                JOIN 
                    Classes cl ON e.ClassID = cl.ClassID
                JOIN 
                    Courses c ON cl.CourseID = c.CourseID
                JOIN 
                    Semesters sm ON cl.SemesterID = sm.SemesterID
                WHERE 
                    st.StudentCode = @id AND
                    cl.IsDeleted = 0 AND
                    c.IsDeleted = 0 AND
                    sm.IsDeleted = 0 AND
                    e.IsDeleted = 0;
                ";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            Close();
            return dt;
        }
        public DataTable CourseFromClassID(string id)
        {
            DataTable dt = new DataTable();
            Open();
            string sql = @"
               SELECT 
                    st.StudentCode,
                    c.CourseName,
                    sm.SemesterName
                FROM 
                    Enroll e
                JOIN 
	                Students st on e.StudentID=st.StudentID
                JOIN 
                    Classes cl ON e.ClassID = cl.ClassID
                JOIN 
                    Courses c ON cl.CourseID = c.CourseID
                JOIN 
                    Semesters sm ON cl.SemesterID = sm.SemesterID
                WHERE 
                    st.StudentCode = @id AND
                    cl.IsDeleted = 0 AND
                    c.IsDeleted = 0 AND
                    sm.IsDeleted = 0 AND
                    e.IsDeleted = 0;
                ";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            Close();
            return dt;
        }
        //Thong ke theo sinh vien
        //Thong ke nganh hoc
        public DataTable DSMajorsTheoID(string id)
        {
            DataTable dt = new DataTable();
            Open();
            string sql = "SELECT[FirstName], [LastName], [StudentCode], [Email], [Phone], [MajorID], [Gender], [Addresses], [IdentityNumber], [Cohort], [DOB], [Note] FROM[QLSV].[dbo].[Students] WHERE MajorID=@id ";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            Close();
            return dt;
        }
        //THong ke nganh hoc
        //Thong ke mon hoc trong muc mon hoc
        public DataTable DSCoursesTheoCourseCate(string id)
        {
            DataTable dt = new DataTable();
            Open();
            string sql = "SELECT [CourseID],[CourseCode], [CourseName], [CourseCredits], [CourseCatID], [ClassSessions], [MaxAllowedAbsences],PointToPass FROM [QLSV].[dbo].[Courses] WHERE CourseCatID=@id";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            Close();
            return dt;
        }
        //Thong ke mon hoc trong muc mon hoc
        //Danh sach lop hoc theo ky
        public DataTable DSClassesTheoKy(string id)
        {
            DataTable dt = new DataTable();
            Open();
            string sql = @"
                SELECT 
                    ClassID,
                    CourseID, 
                    SemesterID, 
                    ClassName 
                FROM 
                    Classes
                WHERE 
                    SemesterID=@id
                ";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            Close();
            return dt;
        }
        //Danh sach lop hoc theo ky
        //Thong ke sinh vien truot mon
        public DataTable DSSinhVienTruotSBV()
        {
            DataTable dt = new DataTable();
            Open();
            string sql = "SELECT " +
                "s.StudentID, " +
                "s.FirstName, " +
                "s.LastName, " +
                "e.Absences, " +
                "c.MaxAllowedAbsences, " +
                "e.ClassID " +
                "FROM dbo.Students s " +
                "JOIN dbo.Enroll e ON s.StudentID = e.StudentID " +
                "JOIN dbo.Classes cl ON e.ClassID = cl.ClassID " +
                "JOIN dbo.Courses c ON cl.CourseID = c.CourseID " +
                "WHERE e.Absences > c.MaxAllowedAbsences AND e.IsDeleted = 0 AND s.IsDeleted = 0;";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            Close();
            return dt;
        }
        public DataTable DSSinhVienTruotDoSoDiem()
        {
            DataTable dt = new DataTable();
            Open();
            string sql = "SELECT " +
                        "s.StudentID, " +
                        "s.FirstName, " +
                        "s.LastName, " +
                        "AVG(sc.ScoreValue) * 0.4 + e.ExamsPoint * 0.6 AS FinalScore, " +
                        "c.PointToPass " +
                        "FROM dbo.Students s " +
                        "JOIN dbo.Enroll e ON s.StudentID = e.StudentID " +
                        "JOIN dbo.Classes cl ON e.ClassID = cl.ClassID " +
                        "JOIN dbo.Courses c ON cl.CourseID = c.CourseID " +
                        "JOIN dbo.Scores sc ON s.StudentID = sc.StudentID " +
                        "GROUP BY s.StudentID, s.FirstName, s.LastName, e.ExamsPoint, c.PointToPass " +
                        "HAVING AVG(sc.ScoreValue) * 0.4 + e.ExamsPoint * 0.6 < c.PointToPass;";



            using (SqlCommand cmd = new SqlCommand(sql, con))
            {

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            Close();
            return dt;
        }
        public string getStudentFromEnroll(string id)
        {
            string classIDs = "";
            Open();
            string sql = @"
        SELECT 
            CourseID
        FROM 
            Classes
        WHERE
            ClassID = @id;
    ";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        classIDs = reader["CourseID"].ToString();
                    }
                }
            }
            Close();
            return classIDs;
        }
        public DataTable DSSinhVienTruotTheoKy(int id)  
        {
            DataTable dt = new DataTable();
            Open();
            string sql  = @"
                    SELECT 
                        s.StudentID,
                        s.FirstName,
                        s.LastName,
                        s.StudentCode,
                        sem.SemesterName,
                        c.CourseName,
                        AVG(sc.ScoreValue) * 0.4 + e.ExamsPoint * 0.6 AS FinalScore, 
                        c.PointToPass,
                        e.Absences,
                        c.MaxAllowedAbsences
                    FROM 
                        dbo.Students s
                    JOIN 
                        dbo.Scores sc ON s.StudentID = sc.StudentID
                    JOIN 
                        dbo.Classes cl ON sc.ClassID = cl.ClassID
                    JOIN 
                        dbo.Courses c ON cl.CourseID = c.CourseID
                    JOIN 
                        dbo.Semesters sem ON cl.SemesterID = sem.SemesterID
                    JOIN 
                        dbo.Enroll e ON s.StudentID = e.StudentID AND e.ClassID = cl.ClassID
                    WHERE 
                        s.IsDeleted = 0
                        AND sc.IsDeleted = 0
                        AND cl.IsDeleted = 0
                        AND c.IsDeleted = 0
                        AND sem.IsDeleted = 0
                        AND e.IsDeleted = 0
                        AND sem.SemesterID = @id
                    GROUP BY
                        s.StudentID,
                        s.FirstName,
                        s.LastName,
                        s.StudentCode,
                        sem.SemesterName,
                        c.CourseName,
                        e.ExamsPoint,
                        c.PointToPass,
                        e.Absences,
                        c.MaxAllowedAbsences
                    HAVING 
                        (AVG(sc.ScoreValue) * 0.4 + e.ExamsPoint * 0.6 < c.PointToPass OR e.Absences > c.MaxAllowedAbsences)
                    ORDER BY 
                        sem.SemesterName,
                        s.StudentID;
                    ";
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            Close();
            return dt;
        }
        public DataTable DSSinhVienTruotTheoNganh(int id)
        {
            DataTable dt = new DataTable();
            Open();
            string sql= @"
                    SELECT 
                        s.StudentID,
                        s.FirstName,
                        s.LastName,
                        s.StudentCode,
                        m.MajorName,
                        c.CourseName,
                        AVG(sc.ScoreValue) * 0.4 + e.ExamsPoint * 0.6 AS FinalScore, 
                        c.PointToPass,
                        e.Absences,
                        c.MaxAllowedAbsences
                    FROM 
                        dbo.Students s
                    JOIN 
                        dbo.Scores sc ON s.StudentID = sc.StudentID
                    JOIN 
                        dbo.Classes cl ON sc.ClassID = cl.ClassID
                    JOIN 
                        dbo.Courses c ON cl.CourseID = c.CourseID
                    JOIN 
                        dbo.Majors m ON s.MajorID = m.MajorID
                    JOIN 
                        dbo.Enroll e ON s.StudentID = e.StudentID AND e.ClassID = cl.ClassID
                    WHERE 
                        s.IsDeleted = 0
                        AND sc.IsDeleted = 0
                        AND cl.IsDeleted = 0
                        AND c.IsDeleted = 0
                        AND m.IsDeleted = 0
                        AND e.IsDeleted = 0
                        AND m.MajorID = @id
                    GROUP BY
                        s.StudentID,
                        s.FirstName,
                        s.LastName,
                        s.StudentCode,
                        m.MajorName,
                        c.CourseName,
                        e.ExamsPoint,
                        c.PointToPass,
                        e.Absences,
                        c.MaxAllowedAbsences
                    HAVING 
                        (AVG(sc.ScoreValue) * 0.4 + e.ExamsPoint * 0.6 < c.PointToPass OR e.Absences > c.MaxAllowedAbsences)
                    ORDER BY 
                        m.MajorName,
                        s.StudentID;
                    ";




            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            Close();
            return dt;
        }
        public DataTable DSSinhVienTruotTheoClass(int id)
        {
            DataTable dt = new DataTable();
            Open();
            string sql = @"
                    SELECT 
                        s.StudentID,
                        s.FirstName,
                        s.LastName,
                        s.StudentCode,
                        cl.ClassID,
                        c.CourseName,
                        AVG(sc.ScoreValue) * 0.4 + e.ExamsPoint * 0.6 AS FinalScore, 
                        c.PointToPass,
                        e.Absences,
                        c.MaxAllowedAbsences
                    FROM 
                        dbo.Students s
                    JOIN 
                        dbo.Scores sc ON s.StudentID = sc.StudentID
                    JOIN 
                        dbo.Classes cl ON sc.ClassID = cl.ClassID
                    JOIN 
                        dbo.Courses c ON cl.CourseID = c.CourseID
                    JOIN 
                        dbo.Majors m ON s.MajorID = m.MajorID
                    JOIN 
                        dbo.Enroll e ON s.StudentID = e.StudentID AND e.ClassID = cl.ClassID
                    WHERE 
                        s.IsDeleted = 0
                        AND sc.IsDeleted = 0
                        AND cl.IsDeleted = 0
                        AND c.IsDeleted = 0
                        AND m.IsDeleted = 0
                        AND e.IsDeleted = 0
                        AND cl.ClassID = @id
                    GROUP BY
                        s.StudentID,
                        s.FirstName,
                        s.LastName,
                        s.StudentCode,
                        m.MajorName,
                        c.CourseName,
                        e.ExamsPoint,
                        c.PointToPass,
                        e.Absences,
                        c.MaxAllowedAbsences,
                        cl.ClassID
                    HAVING 
                        (AVG(sc.ScoreValue) * 0.4 + e.ExamsPoint * 0.6 < c.PointToPass OR e.Absences > c.MaxAllowedAbsences)
                    ORDER BY 
                        cl.ClassID,
                        s.StudentID;
                    ";




            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            Close();
            return dt;
        }
        //Thong ke sinh vien truot mon

    }
}
