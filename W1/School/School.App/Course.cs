using System;

namespace School.App
{
    class Course
    {
        // Fields
        public string Id;
        public string name;
        public string department;
        public int creditHours;
        public List<string> Requirements;
        private static int idSeed = 1;

        // Constructors
        public Course(string name, string department, int creditHours)
        {
            this.name = name;
            this.department = department;
            this.creditHours = creditHours;
            this.Id = department.Substring(0,3) + idSeed.ToString();
            idSeed++;
        }

        // Methods
    }
}