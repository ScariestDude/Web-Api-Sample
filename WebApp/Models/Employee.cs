using System;
using WebApp.Attributes;
using WebApp.Utilities;

namespace WebApp.Models
{
    public class Employee
    {
        [ColumnName]
        public int Id { get; set; }

        [ColumnName]
        [SpParameter]
        public string Name { get; set; }

        [ColumnName]
        [SpParameter]
        public Sex Sex { get; set; }

        [ColumnName]
        [SpParameter]
        public string Position { get; set; }

        [ColumnName]
        [SpParameter]
        public DateTime Birthday { get; set; }

        [ColumnName]
        [SpParameter]
        public string Location { get; set; }

        [ColumnName]
        [SpParameter]
        public string Email { get; set; }

        [ColumnName]
        [SpParameter]
        public string PhoneNumber { get; set; }
    }
}