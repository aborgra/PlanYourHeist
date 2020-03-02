using System;
using System.Collections.Generic;

namespace PlanYourHeist {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Plan Your Heist!");

            Console.WriteLine ("Enter bank difficulty level");
            int bankDifficulty = int.Parse (Console.ReadLine ());

            List<Dictionary<string, string>> team = new List<Dictionary<string, string>> ();
            decimal tempSkillLevels = 0;
            while (true) {
                Dictionary<string, string> member = new Dictionary<string, string> ();

                Console.WriteLine ("Enter team member's name");
                string singleMemberName = Console.ReadLine ();
                if (singleMemberName == "") {
                    break;
                }
                member.Add ("Name", singleMemberName);
                Console.WriteLine ("Enter member skill level (1-50)");
                member.Add ("Skill", Console.ReadLine ());
                Console.WriteLine ("Enter member courage level (0.0 - 2.0)");
                member.Add ("Courage", Console.ReadLine ());

                decimal skillLevel = decimal.Parse (member["Skill"]);
                decimal courageLevel = decimal.Parse (member["Courage"]) / 2;

                tempSkillLevels += skillLevel * courageLevel;

                Console.WriteLine ($"Current total skill levels: {tempSkillLevels}");

                team.Add (member);

            }

            Console.WriteLine ("Enter number of trial runs");
            int trialRuns = int.Parse (Console.ReadLine ());
            int successRun = 0;
            int unsuccessRun = 0;

            for (int i = 0; i < trialRuns; i++) {
                int tempBankDifficulty = bankDifficulty;
                decimal allMembersSkills = 0;
                Random rand = new Random ();
                int luckValue = rand.Next (-10, 11);

                tempBankDifficulty += luckValue;

                foreach (Dictionary<string, string> member in team) {
                    int skillLevel = int.Parse (member["Skill"]);
                    decimal courageLevel = decimal.Parse (member["Courage"]) / 2;
                    decimal adjustedSkillLevel = skillLevel * courageLevel;
                    allMembersSkills += adjustedSkillLevel;
                }

                Console.WriteLine ($"Members combined skill levels: {allMembersSkills}");
                Console.WriteLine ($"Bank difficulty: {tempBankDifficulty}");
                if (allMembersSkills >= tempBankDifficulty) {
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