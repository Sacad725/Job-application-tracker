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
			Console.WriteLine("  kan du lägga till ny JobbAnsöka ");
			Console.WriteLine(" FöretagNamn: ");
			NEWjobbs.CompanyName = Console.ReadLine();
			Console.WriteLine(" JobbTitel:");
			NEWjobbs.Positiontitle = Console.ReadLine();
			Console.WriteLine(" Ange din LöneAnspråk: (kr)");
			NEWjobbs.SalaryExpection = Convert.ToInt32(Console.ReadLine());
			NEWjobbs.ApplicationDate = DateTime.Now;
			NEWjobbs.Applicationstatus = Status.Applied;
			NEWjobbs.ResponseDate = default(DateTime);


			// lägger till våra objekt till listan  
			Applications.Add(NEWjobbs);
			Console.WriteLine(" Din ansöka är sparad ");

		}


		// Visar alla ansökningar 
		public void ShowAll()
		{
			Console.Clear();
			if (Applications.Count == 0)
			{
				Console.WriteLine("Inga ansökningar finns ännu.");
				return;
			}
			else
			// skriver ut alla ansökningar som är sparad 
			foreach (var jobbs in Applications)
			{
				Console.WriteLine(jobbs.Getsummary());
			}
		}


		// metod för att updatatera status

		public void UpdateStatus()
		{
			// Om det inte finns några ansökningar

			Console.Clear();
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
			Console.Clear();
			Console.WriteLine("Vilken status vill du se?");
			Console.WriteLine("0 = Applied");
			Console.WriteLine("1 = Interview");
			Console.WriteLine("2 = Offer");
			Console.WriteLine("3 = Rejected");

			int siffrastatus = Convert.ToInt32(Console.ReadLine());

			var lista = Applications.Where(x => (int)x.Applicationstatus == siffrastatus).ToList();

			// Om inga ansökningar hittas 
			if (lista.Count == 0)
			{
				Console.WriteLine(" Ingen Ansökningar  hittas med valda status: ");
				return;

			}
			// Annars skriv ut alla som matchar
			Console.WriteLine($"\nAnsökningar med status: {(Status)siffrastatus}\n");
			foreach (var a in lista)
			{
				Console.WriteLine(a.Getsummary());
			}

		}

		// sorterar efter datum med hjälp av (orderby)
		public void Showbyddate()
		{
			Console.Clear();

			// Om det inte finns några ansökningar i listan
			if (Applications.Count == 0)
			{
				Console.WriteLine("Det finns inga ansökningar att visa.");
				return; // Avslutar metoden
			}

			// Frågar användaren hur de vill sortera ansökningarna
			Console.WriteLine("Hur vill du sortera ansökningarna?");
			Console.WriteLine("1 = Äldsta först");
			Console.WriteLine("2 = Nyaste först");

			// Läser in användarens val och konverterar till ett heltal
			int val = Convert.ToInt32(Console.ReadLine());

			// Skapar en lista som ska innehålla sorterade ansökningar
			List<JobApplication> lista;

			// Om användaren väljer 1  sortera från äldst till nyast
			if (val == 1)
			{
				lista = Applications.OrderBy(x => x.ApplicationDate).ToList();
				Console.WriteLine("\nAnsökningar sorterade efter datum (äldst först):\n");
			}
			// ifall användaren väljer 2  sortera från nyast till äldst
			else if (val == 2)
			{
				lista = Applications.OrderByDescending(x => x.ApplicationDate).ToList();
				Console.WriteLine("\nAnsökningar sorterade efter datum (nyast först):\n");
			}
			// Om användaren skriver något annat än 1 eller 2
			else
			{
				Console.WriteLine("Fel val. Välj 1 eller 2.");
				return; // Avslutar metoden
			}

			// Loopar igenom listan och skriver ut varje ansökan
			foreach (var x in lista)
			{
				Console.WriteLine(x.Getsummary());
			}
		}



		//  Visa statistik  med hjälp av (Count, GroupBy, Average)
		public void ShowStatistics()
		{
			Console.Clear();
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

		/// Ta bort en ansöka 
		
		public void DeleteAjobb()
		{
			Console.Clear();
			if (!Applications.Any())
			{
				Console.WriteLine("Inga ansökningar att ta bort.");
				return;
			}

			for (int i = 0; i < Applications.Count; i++)
			{
				Console.WriteLine($"{i + 1}. {Applications[i].CompanyName} - {Applications[i].Positiontitle}");
			}

			Console.Write("Ange numret på ansökan du vill ta bort: ");
			int val = Convert.ToInt32(Console.ReadLine());

			if (val < 1 || val > Applications.Count)
			{
				Console.WriteLine("Ogiltigt val.");
				return;
			}

			Applications.RemoveAt(val - 1);
			Console.WriteLine("Ansökan borttagen.");
		}
	}


}









	





	

