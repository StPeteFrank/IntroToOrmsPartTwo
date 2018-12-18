using System;
using System.Linq;

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

      //   System.Console.WriteLine("Enter the SeenAnimals details");
      //   var Species = Console.ReadLine();
      //   var CountOfTimesSeen = int.Parse(Console.ReadLine());
      //   var LocationOfLastSeen = Console.ReadLine();

      //   db.SeenAnimals.Add(new SeenAnimals
      //   {
      //     Species = Species,
      //     CountOfTimesSeen = CountOfTimesSeen,
      //     LocationOfLastSeen = LocationOfLastSeen
      //   });

      //   db.SaveChanges();


      //READ data
      //Display all animals the user has seen

      var allSeenAnimals = db.SeenAnimals;

      foreach (var seenanimal in allSeenAnimals)
      {
        System.Console.WriteLine(seenanimal.Species);
      }
      // Display all animals seen in the Jungle
      var onlySeenInTheJungle = db.SeenAnimals.Where(seenanimal => seenanimal.LocationOfLastSeen == "Jungle");
      System.Console.WriteLine("Animals seen only in the Jungle");
      foreach (var seenanimal in onlySeenInTheJungle)
      {
        System.Console.WriteLine(seenanimal.Species);
      }

      //UPDATE data
      //Update the CountOfTimesSeen and LocationOfLastSeen for an animal
      //Part 1 Find the object(species)
      var Gorilla = db.SeenAnimals.FirstOrDefault(seenanimal => seenanimal.Species == "Gorilla");
      if (Gorilla != null)
      {
        //Part 2 Update the data
        Gorilla.CountOfTimesSeen = 50;
        Gorilla.LocationOfLastSeen = "Desert";
        //Part 3 Save the changes
        db.SaveChanges();
      }

      //DELETE data
      //Remove all animals that I have seen in the Desert
      //Find the object(desertAnimals)
      var desertAnimals = db.SeenAnimals.FirstOrDefault(seenanimal => seenanimal.LocationOfLastSeen == "Desert");
      if (desertAnimals != null)
      {
        //Delete the object
        db.SeenAnimals.Remove(desertAnimals);
        //Save the changes
        db.SaveChanges();
      }
      //Add all the CountOfTimesSeen and get a total number of animals seen
      var totalanimalsseen = db.SeenAnimals.Sum(seenanimal => seenanimal.CountOfTimesSeen);
      Console.WriteLine(totalanimalsseen);

      db.SaveChanges();

      //Get the CountOfTimesSeen of lions, tigers and bears
      var totalofeachanimalseen = db.SeenAnimals.Where(seenanimal => seenanimal.Species == "Lions" || seenanimal.Species == "Tigers" || seenanimal.Species == "Bears" || seenanimal.Species == "Gorilla").Sum(seenanimal => seenanimal.CountOfTimesSeen);
      Console.WriteLine(totalofeachanimalseen);

    }
  }
}
//dotnet ef dbcontext scaffold "server=localhost;database=VacationSafari" Npgsql.EntityFrameworkCore.PostgreSQL -c VacationSafariContext
