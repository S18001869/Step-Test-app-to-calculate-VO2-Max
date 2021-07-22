using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepTest
{
    public class Variables
    {
        public static string UserInitials
        {
            get { return name; }
            set { name = value; }
        }
        private static string name = "";

        public static string AgeNumber
        {
            get { return name; }
            set { name = value; }

        }

        public static string GenderChoice
        {
            get { return name; }
            set { name = value; }
        }

        public static string StepHeight
        {
            get { return name; }
            set { name = value; }
        }

        public static string MaxHR
        {
            get { return name; }
            set { name = value; }
        }

        public static string MaxHRCalc
        {
            get { return name; }
            set { name = value; }
        }

        public static string HR80
        {
            get { return name; }
            set { name = value; }
        }

        public static string HR50
        {
            get { return name; }
            set { name = value; }
        }

    }

    public class User
    {
        public User() // New User. Default values
        {

        }

        public void SaveValues(string Initials, int Age, string Gender, int StepHeight, int MaxHR)
        {
            Initials = Variables.UserInitials;
            Age = int.Parse(Variables.AgeNumber);
            Gender = Variables.GenderChoice;
            StepHeight = int.Parse(Variables.StepHeight);
            MaxHR = int.Parse(Variables.MaxHR);
        }
        // Save All values of Current User.
    }
    public static class ListExtensions
    {
        public static T PickRandom<T>(this List<T> enumerable)
        {
            int index = new Random().Next(0, enumerable.Count());
            return enumerable[index];
        }
    }

}



