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
				Console.WriteLine("=====Välkommen JOB APPLICATION TRACKER =====");
				Console.WriteLine("1) Lägg till ny ansökan");
				Console.WriteLine("2) uppdatera befinlig ansöka");
				Console.WriteLine("3) Visa alla ansökningar");
				Console.WriteLine("4) Filtrera efter status ");
				Console.WriteLine("5) Sortera efter datum ");
				Console.WriteLine("6) Visa statistik ");
				Console.WriteLine("7) Ta bort en ansöka ");
				Console.WriteLine("8) Avsluta");
				Console.Write("Val: ");

				string Userchoice = Console.ReadLine();



				switch (Userchoice)
				{
					case "1": manager.Addjobb(); break;
					case "2": manager.UpdateStatus(); break;
					case "3": manager.ShowAll(); break;
					case "4": manager.ShowByStatus(); break;
					case "5": manager.Showbyddate(); break;
					case "6": manager.ShowStatistics(); break;
					case "7": manager.DeleteAjobb();break;
					case "8": körprogrammet = false; break;
					default: Console.WriteLine("Fel val försök igen ."); break;
				}

			}

			Console.WriteLine("Program avslutat!");
		}
	}
}




		
	
    

