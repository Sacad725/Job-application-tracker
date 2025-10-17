using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_application_tracker
{
	// jobmanager klass ska ta tand om våra metoder som tex,lägga jobb, visa status ,ändra status, visa alla jobb,
	// skapar list av application som samlar alla ansökningar  

	internal class Jobmanager
	{

		// här kommer sparas alla jobansökningar 
		List<JobApplication> Applications = new List<JobApplication>();


		// metod för att lägga till ny ansöka 
		public void Addjobb()
		{
			// skapar objekt 
			JobApplication NEWjobbs = new JobApplication();

			Console.Clear();
			Console.WriteLine("  kan du lägga till ny JobbAnsökan ");
			Console.WriteLine(" FöretagNamn");
			NEWjobbs.CompanyName = Console.ReadLine();
			Console.WriteLine(" JobbTitel");
			NEWjobbs.Positiontitle = Console.ReadLine();
			Console.WriteLine(" Ange din LöneAnspråk (kr)");
			NEWjobbs.SalaryExpection = Convert.ToInt32(Console.ReadLine());
			NEWjobbs.ApplicationDate = DateTime.Now;
			NEWjobbs.Applicationstatus = Status.Applied;


			// lägger till våra objekt till listan  
			Applications.Add(NEWjobbs);
			Console.WriteLine(" Din ansöka är sparad ");

		}


		// Visar alla ansökningar 
		public void ShowAll()
		{
			if (Applications.Count == 0)
			{
				Console.WriteLine("Inga ansökningar finns ännu.");
				return;
			}

			foreach (var newjobbs in Applications)
			{
				Console.WriteLine(newjobbs.Getsummary());
			}
		}


		// metod för att updatatera status

		public void UpdateStatus()
		{
			// Om det inte finns några ansökningar
			if (Applications.Count == 0)
			{
				Console.WriteLine("Det finns inga ansökningar att uppdatera.");
				return;
			}

			// Visa alla ansökningar först
			Console.WriteLine("Dina ansökningar:");
			int nummer = 1;
			foreach (var ansokan in Applications)
			{
				Console.WriteLine($"{nummer}. {ansokan.CompanyName} - {ansokan.Positiontitle} - Status: {ansokan.Applicationstatus}");
				nummer++;
			}

			// Be användaren välja vilket nummer som ska ändras
			Console.Write("Skriv numret på ansökan du vill ändra: ");
			int userchoice = Convert.ToInt32(Console.ReadLine());

			// Kontrollera att valet finns i listan
			if (userchoice < 1 || userchoice > Applications.Count)
			{
				Console.WriteLine("Fel val. Försök igen.");
				return;
			}

			// Hämta vald ansökan
			JobApplication vald = Applications[userchoice - 1];

			// Visa nuvarande status
			Console.WriteLine($"Nuvarande status är: {vald.Applicationstatus}");

			// Visa valmöjligheter för ny status
			Console.WriteLine("Välj ny status:");
			Console.WriteLine("0 = Applied (Skickad)");
			Console.WriteLine("1 = Interview (Intervju)");
			Console.WriteLine("2 = Offer (Erbjudande)");
			Console.WriteLine("3 = Rejected (Avslag)");

			// Läs in ny status
			int nyStatus = Convert.ToInt32(Console.ReadLine());

			// Ändra status
			vald.Applicationstatus = (Status)nyStatus;

			Console.WriteLine($"Status uppdaterad till: {vald.Applicationstatus}\n");
		}


		// //  Filtrera efter status med hjälp av   (Where)
		public void ShowByStatus()
		{
			Console.WriteLine("Vilken status vill du se?");
			Console.WriteLine("0 = Applied");
			Console.WriteLine("1 = Interview");
			Console.WriteLine("2 = Offer");
			Console.WriteLine("3 = Rejected");

			int siffrastatus = Convert.ToInt32(Console.ReadLine());

			var lista = Applications.Where(x => (int)x.Applicationstatus == siffrastatus);

			foreach (var a in lista)
			{
				Console.WriteLine(a.Getsummary());
			}
		}

		// sorterar efter datum med hjälp av (orderby)
		public void Showbyddate()
		{
			var lista = Applications.OrderBy(x => x.ApplicationDate);

			Console.WriteLine(" Sortera ansökningar efter datum: ");



			// skriver ut resutaten 

			foreach (var x in lista)
			{
				Console.WriteLine(x.Getsummary());
			}

		}



		// 3 Visa statistik  med hjälp av (Count, GroupBy, Average)
		public void ShowStatistics()
		{
			int totalt = Applications.Count;
			Console.WriteLine($"Totalt antal ansökningar: {totalt}");

			// antal per status
			var grupper = Applications.GroupBy(x => x.Applicationstatus);
			foreach (var g in grupper)
				Console.WriteLine($"{g.Key}: {g.Count()} st");

			// genomsnittlig svarstid i dagar
			var svarade = Applications.Where(x => x.ResponseDate.Year > 1);
			if (svarade.Any())
			{
				double medel = svarade.Average(x => (x.ResponseDate - x.ApplicationDate).TotalDays);
				Console.WriteLine($"Genomsnittlig svarstid: {medel:F1} dagar");
			}
			else
				Console.WriteLine("Inga svar ännu.");


		}
	}









	





	

