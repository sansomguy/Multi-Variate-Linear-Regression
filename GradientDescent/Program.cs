using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using MatrixManipulation;

namespace GradientDescent
{

    public class CSVRecord
    {
        public double PetalLength { get; set; }
        public double PetalWidth { get; set; }
        public double PistelDiameter { get; set; }
        public double PetalDepth { get; set; }
        public string FlowerName { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ILinearRegression linearRegression = new GradientDescent(
                0.01d,
                0.01d,
                10000
            );
            using(var textReader = File.OpenText("./data.csv"))
            {
                var csv = new CsvReader(textReader);
                var records = new List<CSVRecord>();
                while (csv.Read())
                {
                    records.Add(csv.GetRecord<CSVRecord>());
                }

                var numberOfRecords = records.Count();
                var testRecord = records.First();
                Console.WriteLine(testRecord.FlowerName);
                Console.WriteLine(testRecord.PetalLength);

                var numberOfFeatures = 3;

                var Xs = records
                    .Select((record) => new List<double>() { record.PetalLength, record.PetalWidth, 1 /* Y intercept */ })
                    .SelectMany(record => record)
                    .ToArray()
                    .ToMatrix(columns: numberOfFeatures);

                var Ys = records
                    .Select(record => record.PistelDiameter)
                    .ToArray()
                    .ToMatrix<double>(1);

                linearRegression.Learn(Xs, Ys);

            }

            var prediction = linearRegression.Predict(new double[3] { 1, 1, 1 });
            Console.WriteLine($"Prediction for Petal Diameter: {prediction}");

        }
    }
}