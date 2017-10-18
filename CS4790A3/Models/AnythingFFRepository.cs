using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CS4790A3.Models
{
    public class AnythingFFRepository
    {
        //make dummy data
        //for the foriegn key, forget about it


        public static RunnerLineup getRunnerLineup(int? id)
        {
            RunnerLineup runnerLineup = AnythingFF.getRunnerLineup(id);
            return runnerLineup;
        }



        public static Runner getRunner(int? id)
        {
            Runner runner = AnythingFF.getRunner(id);
            return runner;
        }

        public static List<Lineup> getAllLineups()
        {
            List<Lineup> lineup = AnythingFF.getAllLineup();
            return lineup;
        }

        public static List<Runner> getAllRunners()
        {
            List<Runner> runners = AnythingFF.getAllRunners();
            return runners;
        }

        public static void addRunnerAndLineup(Runner runner, List<Lineup> lineup)
        {


            AnythingFF.addRunner(runner);
            foreach (var dude in lineup)
            {
                dude.runnerID = runner.runnerID;
            }
            AnythingFF.addLineupList(lineup);

        }


        public static void addRunner(Runner runner)
        {
            AnythingFF.addRunner(runner);

        }

        public static void removeRunner(Runner runner)
        {
            AnythingFF.removeRunner(runner);

        }





        //Lineup stuff--------

        public static Lineup getLineup(int? id)
        {
            Lineup lineup = AnythingFF.getLineup(id);
            return lineup;
        }



        public static void addLineup(Lineup lineup)
        {
            AnythingFF.addLineup(lineup);
        }

        public static void addLineupList(List<Lineup> lineup)
        {
            AnythingFF.addLineupList(lineup);
        }

        public static void removeLineup(Lineup lineup)
        {
            AnythingFF.removeLineup(lineup);
        }





    }


    public class RunnerLineup
    {
        public RunnerLineup()
        {


        }

        public Runner runner { get; set; }
        public List<Lineup> lineup { get; set; }
    }



}