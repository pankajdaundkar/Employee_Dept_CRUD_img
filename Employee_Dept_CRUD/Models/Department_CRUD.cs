using System.Data.SqlClient;

namespace Employee_Dept_CRUD.Models
{
    public class Department_CRUD
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;
        public Department_CRUD(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConnection"));
        }


        public int AddDepartment(Department dept)
        {
            int result = 0;
            string str = "insert into department values(@dname)";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@dname", dept.Dname);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateDepartment(Department dept)
        {
            int result = 0;
            string str = "update department set dname=@dname where did=@did";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@dname", dept.Dname);
            cmd.Parameters.AddWithValue("@did", dept.Did);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteDepartment(int id)
        {
            int result = 0;
            string str = "delete from  department where did=@did";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@did", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public IEnumerable<Department> GetAllDepartments()
        {
            List<Department> list = new List<Department>();
            string qry = "select * from department";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Department dept = new Department();
                    dept.Did = Convert.ToInt32(dr["did"]);
                    dept.Dname = dr["dname"].ToString();
                    list.Add(dept);
                }
            }
            con.Close();
            return list;
        }
        public Department GetDepartmentById(int id)
        {
            Department dept = new Department();
            string qry = "select * from department where did=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dept.Did = Convert.ToInt32(dr["did"]);
                    dept.Dname = dr["dname"].ToString();
                }
            }
            con.Close();
            return dept;
        }

    }
}
