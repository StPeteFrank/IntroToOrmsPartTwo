using System;

namespace IntroToOrmsPartTwo
{
  class Program
  {
    static void Main(string[] args)
    {
      //Create data
      var db = new VacationSafariContext();

      //   db.SeenAnimals.Add(new SeenAnimals
      //   {
      //     Species = "Lions",
      //     CountOfTimesSeen = 10,
      //     LocationOfLastSeen = "Desert"
      //   });

      //   db.SaveChanges();
      //   db.SeenAnimals.Add(new SeenAnimals
      //   {
      //     Species = "Tigers",
      //     CountOfTimesSeen = 20,
      //     LocationOfLastSeen = "Jungle"
      //   });
      //   db.SeenAnimals.Add(new SeenAnimals
      //   {
      //     Species = "Bears",
      //     CountOfTimesSeen = 30,
      //     LocationOfLastSeen = "Jungle"
      //   });

      //   db.SaveChanges();

      //   db.SaveChanges();

      System.Console.WriteLine("Enter the SeenAnimals details");
      var Species = Console.ReadLine();
      var CountOfTimesSeen = int.Parse(Console.ReadLine());
      var LocationOfLastSeen = Console.ReadLine();

      db.SeenAnimals.Add(new SeenAnimals
      {
        Species = Species,
        CountOfTimesSeen = CountOfTimesSeen,
        LocationOfLastSeen = LocationOfLastSeen
      });

      db.SaveChanges();


      //READ data
      //UPDATE data
      //DELETE data
    }
  }
}
//dotnet ef dbcontext scaffold "server=localhost;database=VacationSafari" Npgsql.EntityFrameworkCore.PostgreSQL -c VacationSafariContext
