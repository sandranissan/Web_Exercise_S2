using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Scenario_2_Web_Application_Sandra_Nissan.Pages.Employees
{
    public class EmployeeListModel : PageModel
    {
		public List<EmployeeInfo> listEmployees = new List<EmployeeInfo>();
        public void OnGet()
        {
            try 
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=Scenario2;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString)) { 
                    connection.Open();
                    String sql = "SELECT * FROM employees";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                EmployeeInfo employeeInfo = new EmployeeInfo();
								employeeInfo.EmployeeId = reader.GetInt32(0);
								employeeInfo.FirstName = reader.GetString(1);
                                employeeInfo.LastName = reader.GetString(2);
                                employeeInfo.Salary = reader.GetDecimal(3);
                                employeeInfo.IsManager = reader.GetBoolean(4);
                                employeeInfo.isCEO= reader.GetBoolean(5);
							
                                if (!reader.IsDBNull(6)) // För CEO kommer ManagerId vara null. Om det är CEO = hoppa över.
								{
									employeeInfo.ManagerId = reader.GetInt32(6); // om den datan som hämtas inte är null så är det employee/manager som har ManagerId
								}

								listEmployees.Add(employeeInfo);
                              
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            { 
                Console.WriteLine("Exception: " + ex.ToString());

            }
        }
    }
    public class EmployeeInfo
    {
        public int EmployeeId;
        public string FirstName;
        public string LastName;
        public decimal Salary;
        public bool IsManager;
        public bool isCEO;
        public int ManagerId;
        public int Rank;

    }
}
