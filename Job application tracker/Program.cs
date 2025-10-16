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
				Console.WriteLine("3) Filtrera efter status (LINQ)");
				Console.WriteLine("4) Sortera efter datum (LINQ)");
				Console.WriteLine("5) Visa statistik (LINQ)");
				Console.WriteLine("6) Avsluta");
				Console.Write("Val: ");

				string val = Console.ReadLine();

			}

			Console.WriteLine("Program avslutat!");
		}
	}
}




		
	
    

