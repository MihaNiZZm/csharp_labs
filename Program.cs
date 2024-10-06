using System;
using System.Collections.Generic;

namespace HackathonApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Пути к файлам
            string juniorsFilePath = "Juniors20.csv";
            string teamLeadsFilePath = "Teamleads20.csv";

            // Загружаем джунов и тимлидов
            var juniors = DataLoader.LoadEmployees(juniorsFilePath);
            var teamLeads = DataLoader.LoadEmployees(teamLeadsFilePath);

            // Генерируем случайные вишлисты
            var juniorWishlists = DataLoader.GenerateRandomWishlists(juniors, teamLeads);
            var teamLeadWishlists = DataLoader.GenerateRandomWishlists(teamLeads, juniors);

            // Создаём стратегию формирования команд
            ITeamBuildingStrategy strategy = new SimpleTeamBuildingStrategy();

            // Симуляция хакатонов (например, 1000)
            HackathonSimulator.SimulateHackathons(1000, strategy, teamLeads, juniors, teamLeadWishlists, juniorWishlists);
        }
    }
}
