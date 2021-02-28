using System;

namespace BDD_Test_Framework.Helpers
{
    public class ElementNameAttribute : Attribute
    {
        private string description;

        public ElementNameAttribute()
        {
        }

        public ElementNameAttribute(string description)
        {
            this.description = description;
        }

        public string Description
        {
            get { return this.description; }
        }
    }
}
