using FoodConstructor.Models;
using System;
using System.Collections.Generic;

namespace FoodConstructor
{
    public class MockDataConfig
    {
        public static List<Company> Companies;
        public static List<IssuePoint> IssuePoints;

        public static void InitMockData()
        {
            Companies = new List<Company>();
            IssuePoints = new List<IssuePoint>();
            Random rnd = new Random();
            int companiesCount = rnd.Next(5, 10);
            for(int i = 0; i < companiesCount; i++)
            {
                var companyTitle = $"DefaultCompany {i}";
                Company company = Company.CreateTestCompany(companyTitle);
                int issuePointsCount = rnd.Next(5, 10);
                for(int j = 0; j < issuePointsCount; j++)
                {
                    var ip = IssuePoint.CreateTestIssuePoint($"{companyTitle} company issue point {i}");
                    IssuePoints.Add(ip);
                    company.IssuePointsIds.Add(ip.Id);
                }
                
                Companies.Add(company);
            }
        }
    }
}