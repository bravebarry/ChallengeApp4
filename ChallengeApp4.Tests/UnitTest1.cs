using NUnit.Framework;

namespace ChallengeApp4.Tests
{
    [TestFixture]
    public class EmployeeTests
    {
        [Test]
        public void Employee_CreateInstanceWithValidParameters_Succeeds()
        {
            // Arrange
            string firstName = "Jan";
            string lastName = "Kowalski";
            int age = 30;

            // Act
            Employee employee = new Employee(firstName, lastName, age);

            // Assert
            Assert.AreEqual(firstName, employee.FirstName);
            Assert.AreEqual(lastName, employee.LastName);
            Assert.AreEqual(age, employee.Age);
            Assert.AreEqual(0, employee.Ratings.Count);
        }

        [Test]
        public void Employee_AddRatings_Succeeds()
        {
            // Arrange
            Employee employee = new Employee("Jan", "Kowalski", 30);
            int[] ratings = { 5, 7, 8, 10 };

            // Act
            employee.Ratings.AddRange(ratings);

            // Assert
            Assert.AreEqual(ratings.Length, employee.Ratings.Count);
            Assert.AreEqual(ratings.Average(), employee.Ratings.Average());
        }

        [Test]
        public void Program_FindHighestRatedEmployee_Succeeds()
        {
            // Arrange
            List<Employee> users = new List<Employee>
            {
                new Employee("Stefan", "Batory", 45),
                new Employee("Marek", "Adamski", 29),
                new Employee("Sebastian", "Nowak", 38)
            };
            users[0].Ratings.AddRange(new int[] { 10, 9, 8, 7, 6 });
            users[1].Ratings.AddRange(new int[] { 5, 5, 5, 5, 5 });
            users[2].Ratings.AddRange(new int[] { 10, 10, 10, 9, 8 });

            Employee expectedEmployee = users[2];

            // Act
            Employee highestRatedEmployee = users.OrderByDescending(e => e.Ratings.Average()).FirstOrDefault();

            // Assert
            Assert.AreEqual(expectedEmployee.FirstName, highestRatedEmployee.FirstName);
            Assert.AreEqual(expectedEmployee.LastName, highestRatedEmployee.LastName);
            Assert.AreEqual(expectedEmployee.Age, highestRatedEmployee.Age);
            Assert.AreEqual(expectedEmployee.Ratings.Average(), highestRatedEmployee.Ratings.Average());
        }
    }
}