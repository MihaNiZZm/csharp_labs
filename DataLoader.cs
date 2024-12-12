namespace HackathonApp
{
    public class DataLoader
    {
        public IEnumerable<Employee> LoadEmployees(string filePath)
        {
            return File.ReadAllLines(filePath)
                .Skip(1)
                .Select(line => line.Split(';'))
                .Select(parts => new Employee(
                    int.Parse(parts[0].Trim()),
                    parts[1].Trim()
                ));
        }
    }
}
