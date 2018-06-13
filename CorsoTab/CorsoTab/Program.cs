

using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoTab
{
    class Program
    {
        static void Main(string[] args)
        {


            // Parse the connection string and return a reference to the storage account.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            // Create the CloudTable object that represents the "people" table.
           CloudTable table = tableClient.GetTableReference("TestTabella1");



            // Construct the query operation for all customer entities where PartitionKey="Smith".
            TableQuery<EntitaTabella> query = new TableQuery<EntitaTabella>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "testPartvalue"));

            // Print the fields for each customer.
            foreach (EntitaTabella entity in table.ExecuteQuery(query))
            {
                Console.WriteLine("{0}, {1}\t{2}\t{3}", entity.PartitionKey, entity.RowKey,
                    entity.nome, entity.cognome);
            }

            Console.ReadLine();
        }
    }
}
