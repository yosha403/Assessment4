using System;
using System.Collections.Generic;

namespace DriveRatingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //TeamMember tm = new TeamMember();
            //Leader leader = new Leader(); 
            try
            {
                List<TeamMember> teamMembers = new List<TeamMember>();
                teamMembers = TeamMemberRepo.GetTeamMembers();
                for (int i = 0; i < teamMembers.Count; i++)
                {
                    Console.Write(teamMembers[i].FirstName + " ");
                    Console.Write(teamMembers[i].LastName + "\t");
                    Console.Write(teamMembers[i].CommonId + "\t");
                    Console.Write(teamMembers[i].DriveRating);
                    Console.WriteLine();
                }
                Console.WriteLine("\nPlease enter your CommonID:");
                string id = Console.ReadLine();
                string name;
                DriveRating rating;
                if (id.StartsWith("t"))
                {
                    foreach (TeamMember member in teamMembers)
                    {
                        if (member.CommonId == id)
                        {
                            name = member.FirstName;
                            rating = member.DriveRating;
                            double bonus = member.CalculateBonus(rating);
                            Console.WriteLine($"\n{name}, Your current Drive Rating is {rating} and you will receive ${bonus} as a bonus.");
                            Console.WriteLine("\nReturn to Title Screen(1)Yes or (2)Exit:");
                        }
                    }
                }               
                else if (id.StartsWith("l"))
                {
                    Console.WriteLine("Would you like to\n(1) Update team member's DRIVE rating\n(2) View the bonus report\n");
                    string choice = Console.ReadLine();
                    if (choice == "2")
                    {
                        foreach (TeamMember member in teamMembers)
                        {
                            if (member.CommonId == id)
                            {
                                rating = member.DriveRating;
                                double bonus = member.CalculateBonus(rating);
                                Console.WriteLine($"\nYour Drive Rating is {rating} and your bonus is ${bonus}.");
                                Console.WriteLine("\nTeam Members:");
                                foreach (TeamMember member1 in teamMembers)
                                {
                                    if (member1.CommonId.StartsWith("t"))
                                    {
                                        DriveRating rating1 = member1.DriveRating;
                                        double bonus1 = member1.CalculateBonus(rating1);
                                        Console.WriteLine($"{member1.LastName},{member1.FirstName} Drive Rating is {rating1} and their bonus is ${bonus1}.");
                                    }
                                }
                                //Console.WriteLine("\nReturn to Title Screen(1)Yes or (2)Exit:");
                            }
                        }
                    }
                    else if (choice == "1")
                    {

                    }
                }
                else if (id.StartsWith("d"))
                {

                    Console.WriteLine("Would you like to\n(1) Update team member's DRIVE rating\n(2) View the bonus report\n");
                    string choice = Console.ReadLine();
                    if (choice == "2")
                    {
                        foreach (TeamMember member in teamMembers)
                        {
                            if (member.CommonId == id)
                            {
                                rating = member.DriveRating;
                                double bonus = member.CalculateBonus(rating);
                                Console.WriteLine($"\nYour Drive Rating is {rating} and your bonus is ${bonus}.");
                                Console.WriteLine("\nTeam Members:");
                                foreach (TeamMember member1 in teamMembers)
                                {
                                    if (member1.CommonId.StartsWith("t")|| member1.CommonId.StartsWith("l"))
                                    {
                                    DriveRating rating1 = member1.DriveRating;
                                    double bonus1 = member1.CalculateBonus(rating1);
                                    Console.WriteLine($"{member1.LastName},{member1.FirstName} Drive Rating is {rating1} and their bonus is ${bonus1}.");
                                    }
                                }
                                //Console.WriteLine("\nReturn to Title Screen(1)Yes or (2)Exit:");
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Please enter valid commonID");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }


    
    //Repository of Team Members
    public static class TeamMemberRepo
    {
        public static List<TeamMember> GetTeamMembers()
        {
            List<TeamMember> teamMembers = new List<TeamMember>
            {
                new TeamMember("Joe", "Spacito", "t1234", DriveRating.AchievingExpectations),
                new TeamMember("Jane", "Carrie", "t1235", DriveRating.AchievingExpectations),
                new TeamMember("Praj", "Nahim", "t1236", DriveRating.AchievingExpectations),
                new Leader("Fitz", "Caldwell", "l2239", DriveRating.AchievingExpectations),
                new Leader("Leslie", "Wrightfield", "l3239", DriveRating.AchievingExpectations),
                new Director("Charlie", "Georgina", "d5538", DriveRating.AchievingExpectations),
            };
            return teamMembers;
        }
    }




    //Team Member class
    public class TeamMember
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CommonId { get; set; }        

        //This is an auto-implemented property for the DriveRating Enum
        public DriveRating DriveRating { get; set; }
       
        public TeamMember()
        {

        }

        public TeamMember(string FirstName,string LastName,string CommonId, DriveRating DriveRating)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.CommonId = CommonId;
            this.DriveRating = DriveRating;
        }
        //public override string ToString()
        //{
        //    string output = $"{LastName},{FirstName} ";
        //    output += $"{CommonId} ";
        //    output += $"{DriveRating}\n";
        //    return output;
        //}

        public virtual double CalculateBonus(DriveRating rating)
        {
            switch (rating)
            {
                case DriveRating.NeedsImprovement:
                    return 0.0;
                case DriveRating.AchievingExpectations:
                    return 1000.0;
                case DriveRating.ExceedExpectations:
                    return 5000.0;
                case DriveRating.RockStar:  
                    return 10000.0;
                default:
                    return 0.0;
            }
        }
    }

    public class Leader : TeamMember
    {
        public Leader(string FirstName, String LastName, string CommonId, DriveRating DriveRating) : base(FirstName, LastName, CommonId, DriveRating)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.CommonId = CommonId;
            this.DriveRating = DriveRating;
        }

        public override double CalculateBonus(DriveRating rating)
        {
            switch (rating)
            {
                case DriveRating.NeedsImprovement:
                    return 0.0;
                case DriveRating.AchievingExpectations:
                    return 2000.0;
                case DriveRating.ExceedExpectations:
                    return 10000.0;
                case DriveRating.RockStar:
                    return 20000.0;
                default:
                    return 0.0;
            }
        }
    }

    public class Director : TeamMember
    {
        public Director(string FirstName, String LastName, string CommonId, DriveRating DriveRating) : base(FirstName, LastName, CommonId, DriveRating)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.CommonId = CommonId;
            this.DriveRating = DriveRating;
        }

        public override double CalculateBonus(DriveRating rating)
        {
            switch (rating)
            {
                case DriveRating.NeedsImprovement:
                    return 0.0;
                case DriveRating.AchievingExpectations:
                    return 3000.0;
                case DriveRating.ExceedExpectations:
                    return 15000.0;
                case DriveRating.RockStar:
                    return 30000.0;
                default:
                    return 0.0;
            }
        }
    }

    //This is the DriveRating Enum
    public enum DriveRating
        {
            NeedsImprovement,
            AchievingExpectations,
            ExceedExpectations,
            RockStar
        }
}