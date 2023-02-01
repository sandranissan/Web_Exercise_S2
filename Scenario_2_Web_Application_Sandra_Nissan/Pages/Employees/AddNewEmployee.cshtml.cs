using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Scenario_2_Web_Application_Sandra_Nissan.Pages.Employees
{
    
    public class AddNewEmployeeModel : PageModel
    {
		public EmployeeInfo employeeInfo = new EmployeeInfo();
		public String errorMessage = "";
		public String successMessage = "";

		public void OnGet()
        {
			
		}

		public void OnPost() {
		
	       	employeeInfo.FirstName= Request.Form["firtName"];
			employeeInfo.LastName = Request.Form["lastName"];

			if (int.TryParse(Request.Form["rank"], out employeeInfo.Rank))
			{
				

			}
			else
			{

			}


			if (bool.TryParse(Request.Form["isManager"], out employeeInfo.IsManager))
			{

			}
			else
			{

			}

			if (bool.TryParse(Request.Form["isCEO"], out employeeInfo.isCEO))
			{

			}
			else
			{

			}

			if (int.TryParse(Request.Form["managerId"], out employeeInfo.ManagerId))
			{

			}
			else
			{

			}

			if (employeeInfo.FirstName.Length == 0 || employeeInfo.LastName.Length == 0 )
			{
				errorMessage = "All fields are required!";
				return;
			}

			//save new employee to DB

			employeeInfo.FirstName = ""; employeeInfo.LastName = "";


			successMessage = "New employee Added Correctley";


		}

	}


}
