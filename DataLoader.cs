using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HackathonApp
{
    public static class DataLoader
    {
        /// <summary>
        /// Загружает сотрудников из CSV-файла.
        /// </summary>
        /// <param name="filePath">Путь к CSV-файлу.</param>
        /// <returns>Список сотрудников.</returns>
        public static IEnumerable<Employee> LoadEmployees(string filePath)
        {
            return File.ReadAllLines(filePath)
                .Skip(1) // Пропускаем первую строку с заголовками
                .Select(line => line.Split(';')) // Разделитель - точка с запятой
                .Select(parts => new Employee(
                    int.Parse(parts[0].Trim()), // ID
                    parts[1].Trim()             // Имя
                ));
        }


        /// <summary>
        /// Генерирует случайные списки предпочтений для сотрудников.
        /// </summary>
        /// <param name="employees">Список сотрудников, для которых нужно создать вишлисты.</param>
        /// <param name="otherEmployees">Список других сотрудников, которых можно добавлять в предпочтения.</param>
        /// <returns>Сгенерированные списки предпочтений.</returns>
        public static IEnumerable<Wishlist> GenerateRandomWishlists(IEnumerable<Employee> employees, IEnumerable<Employee> otherEmployees)
        {
            var random = new Random();
            var otherEmployeeIds = otherEmployees.Select(e => e.Id).ToArray();

            return employees.Select(e =>
            {
                // Перемешиваем массив других сотрудников
                var shuffledIds = otherEmployeeIds.OrderBy(_ => random.Next()).ToArray();
                return new Wishlist(e.Id, shuffledIds);
            });
        }
    }
}
