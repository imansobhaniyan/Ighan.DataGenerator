using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Ighan.DataGenerator.Core
{
    public class Generator
    {
        private static Random random = new Random(DateTime.Now.Millisecond);

        public static List<object> Generate(Type type, int count, Action<object> action = null)
        {
            var result = new List<object>(count);

            var properties = type.GetProperties();

            for (int i = 0; i < count; i++)
            {
                var newItem = Generate(type, properties);
                action?.Invoke(newItem);
                result.Add(newItem);
            }

            return result;
        }

        public static object Generate(Type type)
        {
            return Generate(type, type.GetProperties());
        }

        private static object Generate(Type type, PropertyInfo[] properties)
        {
            var instance = Activator.CreateInstance(type);

            foreach (var property in properties)
            {
                object value = null;
                switch (property.PropertyType.Name)
                {
                    case "Boolean":
                        value = GetRandomeBooleanValue(property);
                        break;
                    case "Char":
                        value = GetRandomeCharacterValue(property);
                        break;
                    case "String":
                        value = GetRandomeStringValue(property);
                        break;
                    case "TimeSpan":
                        value = GetRandomeTimeSpanValue(property);
                        break;
                    case "DateTime":
                        value = GetRandomeDateTimeValue(property);
                        break;
                    case "Int32":
                    case "Int64":
                    case "Single":
                    case "Double":
                        value = GetRandomeNumericValue(property);
                        break;
                }

                if (value != null)
                    property.SetValue(instance, value);
                else if (!property.PropertyType.IsGenericType)
                    property.SetValue(instance, Generate(property.PropertyType));
            }

            return instance;
        }

        private static object GetRandomeBooleanValue(PropertyInfo property)
        {
            return random.Next(0, int.MaxValue) % 2 == 0;
        }

        private static object GetRandomeCharacterValue(PropertyInfo property)
        {
            return Characters[random.Next(Characters.Length)];
        }

        private static object GetRandomeNumericValue(PropertyInfo property)
        {
            return random.Next(0, int.MaxValue);
        }

        private static object GetRandomeDateTimeValue(PropertyInfo property)
        {
            var minValue = property.GetCustomAttribute<Attributes.DateTimeMinValueAttribute>()?.MinValue;
            var maxValue = property.GetCustomAttribute<Attributes.DateTimeMaxValueAttribute>()?.MaxValue;

            DateTime value = minValue ?? DateTime.Now;

            while (true)
            {
                var tempValue = value.AddSeconds(random.NextDouble() * int.MaxValue);

                if (!maxValue.HasValue || tempValue < maxValue.Value)
                {
                    value = tempValue;
                    break;
                }
            }

            return value;
        }

        private static object GetRandomeTimeSpanValue(PropertyInfo property)
        {
            return new TimeSpan(random.Next(0, 24), random.Next(0, 60), random.Next(0, 60));
        }

        private static object GetRandomeStringValue(PropertyInfo property)
        {
            int length = 10;

            StringBuilder result = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                result.Append(Characters[random.Next(0, Characters.Length)]);
            }

            return result.ToString();
        }

        private const string Characters = "abcdefghijklmnopqrstuvwxyz123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ987654321";
    }
}
