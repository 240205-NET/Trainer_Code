using System;
using System.Text;
using School.Logic;

namespace School.App
{
    class School
    {
        // Fields
        private List<Student> _students;
        private List<Teacher> _teachers;
        private List<Course> _courses;
        private List<Class> _classes;
        
        // Constructor
        public School()
        {
            this._students = new List<Student>();
            this._teachers = new List<Teacher>();
            this._courses = new List<Course>();
            this._classes = new List<Class>();
        
            _students.Add(new Student( "New Guy", "guy@no.com", "1500 Pen. Ave", "", "Washington", "DC", "12345"));
            _teachers.Add(new Teacher(14, 75000, "Science", "Someone New", "new.teach@no.com", "Somewhere", "", "NYC", "NY", "12345"));
        }

        // Methods
        public Student GetStudent(int studentId)
        {
            /*
            // a list is indexed
            // a dictionary is not indexed, but is pairs (entries and keys)
            // you can look up an entry by the key. the Key MUST be unique within the dictionary
            // Dictionary in a loop! 
            foreach( Student s in _students)
            {
                if (s.studentId == studentId)
                {
                    StudentDictionary.Add(s.studentId, s);
                }
            }
            return StudentDictionary.Add(s.studentId, s);
            */

            
            // Only returns the FIRST instance that matches
            foreach( Student s in _students)
            {
                if (s.studentId == studentId)
                {
                    return s;
                }
            }

            return new Student();

            /*
            // returns ALL possible instances that match
            List<Student> result = new List<Student>();
            foreach( Student s in _students)
            {
                if (s.studentId == studentId)
                {
                    result.Add(s);
                }
            }
            return result;
            */

            // List.IndexOf() - searches the list and returns the index of the entry that matches the object sent as a parameter.
            // this method would require a not-insignificant rewrite of our Student class.

            // List.Find() - Accepts a value, searches the list, and returns the instances of the object



            // LINQ (Lin-Que) is all about sorting and filtering
            /* LINQ syntax
            var studentQuery =  from s in _students 
                                where s.studentId == studentId
                                select s;

            return studentQuery.FirstOrDefault();
            */


            // llambda expression syntax
            /*
            return _students.FirstOrDefault(s => s.studentId == studentId);
            */

        }

        public List<Student> GetStudents()
        {
            return _students;
        }

        public List<Teacher> GetTeachers()
        {
            return _teachers;
        }

        public string GetStudentsInfo()
        {
            var sb = new StringBuilder();
            foreach(Student s in _students)
            {
                sb.AppendLine(s.ToString());
            }
            return sb.ToString();
        }

        public string GetTeachersInfo()
        {
            var sb = new StringBuilder();
            foreach(Teacher t in _teachers)
            {
                sb.AppendLine(t.ToString());
            }
            return sb.ToString();
        }

        public string MichaelsGetTeachersInfo(string connectionString){
            var sb = new StringBuilder();
            using SqlConnection connection = new SqlConnection(connectionString);
 
            try{
                connection.Open();
                string cmdText = "SELECT * FROM [School].[Teachers];";
                using SqlCommand cmd = new SqlCommand(cmdText, connection);
                using SqlDataReader reader = cmd.ExecuteReader();
               
                while(reader.Read())
                {
                    // string Id = reader.GetInt32(0); // Id INT PRIMARY KEY,
                    string name = reader.GetString(1); // Name VARCHAR(255) NOT NULL,
                    string email = reader.GetString(2); // Email VARCHAR(255) NOT NULL,
                    string address1 = reader.GetString(3); // Address1 VARCHAR(255)NOT NULL,
                    string address2 = reader.GetString(4); // Address2 VARCHAR(255),
                    string city = reader.GetString(5); // City VARCHAR(255) NOT NULL,
                    string state = reader.GetString(6); // State VARCHAR(255) NOT NULL,
                    int zip = reader.GetInt32(7); // Zip INT NOT NULL,
                    int office = reader.GetInt32(8); // Office INT NOT NULL,
                    decimal salary = reader.GetDecimal(9); // Salary DECIMAL NOT NULL,
                    string subject = reader.GetString(10); // Subject VARCHAR(255) NOT NULL          
                   
                    sb.AppendLine(new Teacher(office, salary, subject, name, email, address1, address2, city, state, zip).ToString());
                }
                connection.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                connection.Close();
            }
 
            return sb.ToString();
        }

        public List<Student> JessiraesGetStudent()
        {
            string cmd2Text = "SELECT * From [School].[Students] WHERE Id = 12;";
            using SqlCommand cmd2 = new SqlCommand(cmd2Text, connection);
            using SqlDataReader reader = cmd2.ExecuteReader();
            Console.WriteLine("Reader Executed...");
            List<Student> students = new List<Student>();

            while (reader.Read())
            {
                int? Id = reader.GetInt32(0);
                string? name = reader.GetString(1) ?? "";
                string? email = reader.GetString(2) ?? "";
                string? address1 = reader.GetString(3) ?? "";
                string? address2 = reader.GetString(4) ?? "";
                string? city = reader.GetString(5) ?? "";
                string? state = reader.GetString(6) ?? "";
                int? zip = reader.GetInt32(7);
                //double? gpa = reader.GetDouble(8);
                students.Add(new Student(Id, name, email, address1, address2, city, state, zip));
            }
            return students;
        }

        public void NabinsAddStudent()
        {
            string connectionString = "./../../ConnectionString";
            using SqlConnection connection = new SqlConnection(connectionString);
            try{
                connection.Open();
                this.student =  new Student("New Guy", "guy@no.com", "1500 Pen. Ave", "apt 1", "Washington", "DC", 12345,4.4);
                string query1 = "INSERT INTO [School].[Students] (name, email, address1, address2, city, state, zip, GPA) VALUES(@id, @name,@email,@address1, @address2,@city,@state, @zip, @GPA)";
                using SqlCommand cmd1 = new SqlCommand(query1, connection);
                cmd1.Parameters.AddWithValue("@id",this.student.studentId);
                cmd1.Parameters.AddWithValue("@name",this.student.name);
                cmd1.Parameters.AddWithValue("@email",this.student.email);
                cmd1.Parameters.AddWithValue("@address1",this.student.address1);
                cmd1.Parameters.AddWithValue("@address2",this.student.address2);
                cmd1.Parameters.AddWithValue("@city",this.student.city);
                cmd1.Parameters.AddWithValue("@state",this.student.state);
                cmd1.Parameters.AddWithValue("@zip",this.student.zip);
                cmd1.Parameters.AddWithValue("@GPA",this.student.gpa);
                cmd1.ExecuteNonQuery();
                connection.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("Error on Database "+ e.Message);
                connection.Close();
            }
        }



    }
}