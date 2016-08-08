using System;
using System.Runtime.CompilerServices;

namespace WebApp.Attributes
{
    internal class SpParameterAttribute : Attribute
    {
        public string Name { get; set; }

        public SpParameterAttribute([CallerMemberName] string propertyName = null)
        {
            this.Name = '@' + propertyName;
        }
    }
}