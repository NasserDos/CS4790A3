using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace CS4790A3.Models
{
    public class AnythingFF
    {

        public static Runner getRunner(int? id)
        {
            AnythingFFDbContext db = new AnythingFFDbContext();
            Runner runner = db.runners.Find(id);
            return runner;
        }

        public static List<Runner> getAllRunners()
        {
            AnythingFFDbContext db = new AnythingFFDbContext();
            return db.runners.ToList();
        }

        public static void addRunner(Runner runner)
        {
            AnythingFFDbContext db = new AnythingFFDbContext();
            db.runners.Add(runner);
            // db.Entry(course).State = EntityState.Added;
            db.SaveChanges();
        }

        public static void removeRunner(Runner runner)
        {
            AnythingFFDbContext db = new AnythingFFDbContext();
            db.Entry(runner).State = EntityState.Deleted;
            db.runners.Remove(runner);
            db.SaveChanges();
        }

        //--------------------Lineup

        public static Lineup getLineup(int? id)
        {
            AnythingFFDbContext db = new AnythingFFDbContext();
            Lineup lineup = db.lineups.Find(id);
            return lineup;
        }

        public static List<Lineup> getAllLineup()
        {
            AnythingFFDbContext db = new AnythingFFDbContext();
            return db.lineups.ToList();
        }

        public static void addLineup(Lineup lineup)
        {
            AnythingFFDbContext db = new AnythingFFDbContext();
            db.lineups.Add(lineup);
            // db.Entry(course).State = EntityState.Added;
            db.SaveChanges();
        }


        public static void addLineupList(List<Lineup> lineup)
        {
            AnythingFFDbContext db = new AnythingFFDbContext();
            List<Lineup> temp = new List<Lineup>();

            foreach(var person in lineup)
            {
                if (person.firstName != null)
                {
                    person.firstName.Replace(" ", "");
                }
                if (person.lastName != null)
                {
                    person.lastName.Replace(" ", "");
                }

                if (person.firstName == "") person.firstName = null;
                if (person.lastName == "") person.lastName = null;

                if (person.firstName !=null && person.lastName !=null
                    && person.tShirt != null)
                {
                    db.lineups.Add(person);
                }
            }

            db.SaveChanges();
        }


        public static void removeLineup(Lineup lineup)
        {
            AnythingFFDbContext db = new AnythingFFDbContext();
            db.Entry(lineup).State = EntityState.Deleted;
            db.lineups.Remove(lineup);
            db.SaveChanges();
        }







        public static RunnerLineup getRunnerLineup(int? id)
        {
            AnythingFFDbContext db = new AnythingFFDbContext();
            RunnerLineup runnerLineup = new RunnerLineup();

            runnerLineup.runner = db.runners.Find(id);

            var lineup = db.lineups.Where(theLineup =>
            theLineup.runnerID == runnerLineup.runner.runnerID
            );

            runnerLineup.lineup = lineup.ToList();

            return runnerLineup;
        }



    }//end AnythingFF








    [Table("Runner")]
    public class Runner
    {

        [Key]
        public int runnerID { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string firstName { get; set; }

        
        [Required]
        [DisplayName("Last Name")]
        public string lastName { get; set; }


        [DisplayName("Suffix")]
        public string suffix  { get; set; }

        [DisplayName("Anonymous")]
        public bool anonymous { get; set; }

        [Required]
        [DisplayName("Phone")]
        public string phone { get; set; }

        [EmailAddress]
        [Required]
        [DisplayName("Email")]
        public string email { get; set; }

        
        [DisplayName("T-Shirt")]
        public string tShirt { get; set; }

        [Required]
        [DisplayName("Emergency Contact")]
        public string emergencyName { get; set; }

        [Required]
        [DisplayName("Contact's Phone")]
        public string emergencyPhone { get; set; }

        [Required]
        [DisplayName("Number of Adult")]
        public int numberOfAdult { get; set; }

        [Required]
        [DisplayName("Number of Child")]
        public int numberOfChild { get; set; }


        public ICollection<Lineup> lineup { get; set; }
    }



    [Table("Lineup")]
    public class Lineup
    {


        [Key]
        public int lineupID { get; set; }
        
        [DisplayName("First Name")]
        public string firstName { get; set; }

        [DisplayName("Last Name")]
        public string lastName { get; set; }

        [DisplayName("T-Shirt")]
        public string tShirt { get; set; }


        
        public int runnerID { get; set; }


    }




    public class AnythingFFDbContext : DbContext
    {
        public DbSet<Runner> runners { get; set; }
        public DbSet<Lineup> lineups { get; set; }

    }
}