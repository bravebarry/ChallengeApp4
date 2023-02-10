namespace ChallengeApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> Users = new List<Employee>();

            Users.Add(new Employee("Stefan", "Batory", 45));
            Users.Add(new Employee("Marek", "Adamski", 29));
            Users.Add(new Employee("Sebastian", "Nowak", 38));

            Users[0].Ratings.AddRange(new int[] { 10, 9, 8, 7, 6 });
            Users[1].Ratings.AddRange(new int[] { 5, 5, 5, 5, 5 });
            Users[2].Ratings.AddRange(new int[] { 10, 10, 10, 9, 8 });

            Employee highestRatedEmployee = Users[0];
            int highestAverageRating = (int)Users[0].Ratings.Average();

            foreach (var employee in Users)
            {
                if (employee.Ratings.Average() > highestAverageRating)
                {
                    highestRatedEmployee = employee;
                    highestAverageRating = (int)employee.Ratings.Average();
                }
            }

            Console.WriteLine("Pracownik z największą średnią ocen:");
            Console.WriteLine("Imię: " + highestRatedEmployee.FirstName);
            Console.WriteLine("Nazwisko: " + highestRatedEmployee.LastName);
            Console.WriteLine("Wiek: " + highestRatedEmployee.Age);
            Console.WriteLine("Oceny: " + string.Join(", ", highestRatedEmployee.Ratings));
        }
    }
}