using System;

namespace Ighan.DataGenerator.Core.Attributes
{
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class DateTimeMaxValueAttribute : Attribute
    {
        public DateTimeMaxValueAttribute(string maxValue)
        {
            MaxValue = DateTime.Parse(maxValue);
        }

        public DateTime MaxValue { get; set; }
    }
}
