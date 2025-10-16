namespace Job_application_tracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
		//  skapar objekt av jobbmanager 
            Jobmanager manager = new Jobmanager();

			// while lopp som kör igång programmet 
			bool körprogrammet = true;

			while (körprogrammet)
			{
				Console.WriteLine("\n=== JOB APPLICATION TRACKER ===");
				Console.WriteLine("1) Lägg till ny ansökan");
				Console.WriteLine("2) Visa alla ansökningar");
				Console.WriteLine("3) Filtrera efter status ");
				Console.WriteLine("4) Sortera efter datum ");
				Console.WriteLine("5) Visa statistik ");
				Console.WriteLine("6) Avsluta");
				Console.Write("Val: ");

				string Userchoice = Console.ReadLine();



				switch (Userchoice)
				{
					case "1": manager.Addjobb(); break;
					case "2": manager.ShowAll(); break;
					case "3": manager.ShowByStatus(); break;
					case "4": manager.Showbyddate(); break;
					case "5": manager.show(); break;
					case "6": körprogrammet = false; break;
					default: Console.WriteLine("Fel val."); break;
				}

			}

			Console.WriteLine("Program avslutat!");
		}
	}
}




		
	
    

