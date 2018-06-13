using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoTab
{
    public class EntitaTabella: TableEntity
    {
        public EntitaTabella(string lastName, string firstName)
        {
            this.PartitionKey = lastName;
            this.RowKey = firstName;
        }

        public EntitaTabella() { }

        public string nome { get; set; }

        public string cognome { get; set; }
    }
}
