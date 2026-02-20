using System;

namespace dominio
{
    internal class DisplayAttribute : Attribute
    {
        public string Name { get; set; }
    }
}