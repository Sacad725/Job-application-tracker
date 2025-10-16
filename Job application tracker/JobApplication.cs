using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Job_application_tracker
{
	// skapat jobb application klass som ska dem attributerna som finns där nere 
	


	// enom status  tar hand om och representerar varje jobaAnsökan 
	public enum Status { Applied, interview, Offer, Rejected }
	internal class JobApplication
	{
		public string CompanyName { get; set; }
		public string Positiontitle { get; set; }
		public  Status Applicationstatus { get; set; }
		public DateTime ApplicationDate { get; set; }
		public DateTime ResponseDate { get; set; }
		public int SalaryExpection {  get; set; }


		//  ger tillbaka antal dagar som har gått efter ansökan är skickat 
		public int GetDaysSinceApplied() 
		{
			return (DateTime.Now - ApplicationDate).Days;


		}

		




	}
}
