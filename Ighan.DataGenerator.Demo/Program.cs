using Ighan.DataGenerator.Core;
using Ighan.DataGenerator.Core.Attributes;

using System;
using System.Collections.Generic;

namespace Ighan.DataGenerator.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var dt = DateTime.Now;

            var instance =  Generator.Generate(typeof(Test), 1000);

            var period = DateTime.Now - dt;

            Console.WriteLine("Hello World!");
        }

        public class Test
        {
            public int VarInt { get; set; }

            public long VarLong { get; set; }

            public float VarFloat { get; set; }

            public double VarDouble { get; set; }

            public bool VarBool { get; set; }

            public char VarChar { get; set; }

            public string VarString { get; set; }

            public TimeSpan VarTimeSpan { get; set; }

            [DateTimeMinValue("2020/01/07 00:00:00")]
            [DateTimeMaxValue("2020/02/08 00:00:00")]
            public DateTime VarDateTime { get; set; }

            public InnerTest InnerTest { get; set; }

            public List<InnerTest> InnerTests { get; set; }
        }

        public class InnerTest
        {
            public int VarInt { get; set; }

            public long VarLong { get; set; }

            public float VarFloat { get; set; }

            public double VarDouble { get; set; }

            public bool VarBool { get; set; }

            public char VarChar { get; set; }

            public string VarString { get; set; }

            public TimeSpan VarTimeSpan { get; set; }

            [DateTimeMinValue("2020/01/07 00:00:00")]
            [DateTimeMaxValue("2020/02/08 00:00:00")]
            public DateTime VarDateTime { get; set; }
        }
    }
}
