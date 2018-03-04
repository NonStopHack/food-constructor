using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Configuration;
using System.Diagnostics;

namespace FoodConstructor.Models.Repository
{
    public static class MongoBDClient
    {
        private static object syncRoot = new Object();
        private static volatile MongoClient client;

        public static MongoClient GetClient()
        {
            try
            {
                if (client != null)
                {
                    return client;
                }
                else
                {
                    lock (syncRoot)
                    {
                        if (client == null)
                        {
                            string connectionString = ConfigurationManager.ConnectionStrings["MongoDb"].ConnectionString;
                            client = new MongoClient(connectionString);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception occured during mongoDB client initializing: {ex.Message}");
            }

            return client;
        }

    }
}