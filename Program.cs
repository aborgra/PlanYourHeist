using System;
using System.Collections.Generic;

namespace PlanYourHeist {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Plan Your Heist!");

            // Dictionary<int, string> memberName = new Dictionary<int, string> ();
            // Dictionary<int, int> memberSkillLevel = new Dictionary<int, int> ();
            // Dictionary<int, decimal> memberCourage = new Dictionary<int, decimal> ();
            List<Member> members = new List<Member> ();

            while (true) {

                Console.WriteLine ("Enter team member's name");
                string singleMemberName = Console.ReadLine ();
                if (singleMemberName == "") {
                    break;
                }

                Member member = new Member ();
                member.MemberName = singleMemberName;
                Console.WriteLine ("Enter member skill level (1-50)");
                member.SkillLevel = int.Parse (Console.ReadLine ());
                Console.WriteLine ("Enter member courage level (0.0 - 2.0)");
                member.CourageLevel = decimal.Parse (Console.ReadLine ());

                members.Add (member);

            }
            Console.WriteLine ("Enter bank difficulty level");
            int bankDifficulty = int.Parse (Console.ReadLine ());

            Console.WriteLine ("Enter number of trial runs");
            int trialRuns = int.Parse (Console.ReadLine ());
            int successRun = 0;
            int unsuccessRun = 0;

            for (int i = 0; i < trialRuns; i++) {
                int tempBankDifficulty = bankDifficulty;
                int allMembersSkills = 0;
                Random rand = new Random ();
                int luckValue = rand.Next (-10, 11);

                tempBankDifficulty += luckValue;

                // foreach (KeyValuePair<int, string> member in memberName) {
                //     int skillLevel = memberSkillLevel[member.Key];
                //     allMembersSkills += skillLevel;
                // }

                foreach (Member item in members) {
                    allMembersSkills += item.SkillLevel;
                    Console.WriteLine (item.ToString ());
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