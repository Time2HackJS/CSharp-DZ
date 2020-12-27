using System;
using System.IO;
using System.Text.Json;

// Реализация варианта D2

namespace DZ
{
    public enum SensorType { Pressure, Viscosity, Density, Temperature }

    public class Sensor
    {
        public SensorType type { get; set; }
        public int minValue { get; set; }
        public int maxValue { get; set; }
        public string valueName { get; set; }

        public Sensor(
            SensorType type,
            int minValue,
            int maxValue,
            string valueName
        )
        {
            this.type = type;
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.valueName = valueName;
        }
    }

    public class MLine
    {
        public int number { get; set; }
        public Sensor sensor { get; set; }

        public MLine(
            int number,
            Sensor sensor
        )
        {
            this.number = number;
            this.sensor = sensor;
        }
    }

    public class MSystem
    {
        public string name { get; set; }
        public int number { get; set; }
        public string address { get; set; }
        public MLine measureLine { get; set; }

        public MSystem(
            string name,
            int number,
            string address,
            MLine measureLine
        )
        {
            this.name = name;
            this.number = number;
            this.address = address;
            this.measureLine = measureLine;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Sensor sensor = new Sensor(SensorType.Pressure, 0, 100, "m");
            MLine mLine = new MLine(1, sensor);
            MSystem mSystem = new MSystem("imaqtpie", 1, "Moscow", mLine);

            string jsonString = JsonSerializer.Serialize(mSystem);
            Console.WriteLine(jsonString);
        }
    }
}