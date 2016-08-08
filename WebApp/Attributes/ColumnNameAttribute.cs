using System;
using System.Runtime.CompilerServices;

namespace WebApp.Attributes
{
    internal class ColumnNameAttribute : Attribute
    {
        public string Name { get; set; }

        public ColumnNameAttribute([CallerMemberName] string propertyName = null)
        {
            this.Name = propertyName;
        }
    }
}