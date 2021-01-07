using System;

namespace Ighan.DataGenerator.Core.Attributes
{
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class DateTimeMinValueAttribute : Attribute
    {
        public DateTimeMinValueAttribute(string minValue)
        {
            MinValue = DateTime.Parse(minValue);
        }

        public DateTime MinValue { get; set; }
    }
}
