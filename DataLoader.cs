using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

        public IEnumerable<Wishlist> GenerateRandomWishlists(IEnumerable<Employee> employees, IEnumerable<Employee> otherEmployees)
        {
            var random = new Random();
            var otherEmployeeIds = otherEmployees.Select(e => e.Id).ToArray();

            return employees.Select(e =>
            {
                var shuffledIds = otherEmployeeIds.OrderBy(_ => random.Next()).ToArray();
                return new Wishlist(e.Id, shuffledIds);
            });
        }
    }
}
