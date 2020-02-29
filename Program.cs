using System;
using System.Collections.Generic;

namespace PlanYourHeist {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Plan Your Heist!");

            Dictionary<int, string> memberName = new Dictionary<int, string> ();
            Dictionary<int, int> memberSkillLevel = new Dictionary<int, int> ();
            Dictionary<int, decimal> memberCourage = new Dictionary<int, decimal> ();

            while (true) {
                Console.WriteLine ("Enter team member's name");
                string singleMemberName = Console.ReadLine ();
                if (singleMemberName == "") {
                    break;
                }
                memberName.Add (memberName.Count, singleMemberName);
                Console.WriteLine ("Enter member skill level (1-50)");
                memberSkillLevel.Add (memberSkillLevel.Count, int.Parse (Console.ReadLine ()));
                Console.WriteLine ("Enter member courage level (0.0 - 2.0)");
                memberCourage.Add (memberCourage.Count, decimal.Parse (Console.ReadLine ()));
            }
            Console.WriteLine ("Enter bank difficulty level");
            int bankDifficulty = int.Parse (Console.ReadLine ());

            Console.WriteLine ("Enter number of trial runs");
            int trialRuns = int.Parse (Console.ReadLine ());
            int successRun = 0;
            int unsuccessRun = 0;

            for (int i = 0; i < trialRuns; i++) {
                int allMembersSkills = 0;
                Random rand = new Random ();
                int luckValue = rand.Next (-10, 11);

                bankDifficulty += luckValue;

                foreach (KeyValuePair<int, string> member in memberName) {
                    int skillLevel = memberSkillLevel[member.Key];
                    allMembersSkills += skillLevel;
                }

                Console.WriteLine ($"Members combined skill levels: {allMembersSkills}");
                Console.WriteLine ($"Bank difficulty: {bankDifficulty}");
                if (allMembersSkills >= bankDifficulty) {
                    Console.WriteLine ("You've got a chance!");
                    successRun += 1;
                } else {
                    Console.WriteLine ("Maybe find a day job?");
                    unsuccessRun += 1;
                }
            }
            Console.WriteLine ($"Successful trial runs: {successRun}  Unsuccessful trial runs: {unsuccessRun}");
        }
    }
}