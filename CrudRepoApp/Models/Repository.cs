namespace CrudRepoApp.Models
{
    public static class Repository
    {
        private static List<Employee> allEmployees = new();

        public static IEnumerable<Employee> AllEmployees
        {
            get
            {
                return allEmployees;
            }
        }

        public static void create(Employee employee)
        {
            allEmployees.Add(employee);
        }
    }
}
