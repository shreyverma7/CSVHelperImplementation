using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVHelperImplementation
{
    public class CSVHandlerImplement
    {
        public void ImplementCSVHandler()
        {
            string importFilePath = @"D:\Bridgelabz Problem statement\CSVHelperImplementation\CSVHelperImplementation\Import.csv";
            string exportFilePath = @"D:\Bridgelabz Problem statement\CSVHelperImplementation\CSVHelperImplementation\Export.csv";
            using (var reader = new StreamReader(importFilePath))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<AddressData>().ToList();
                    Console.WriteLine("Read Data From CSV");
                    foreach (var data in records)
                    {
                        Console.WriteLine(data.Name + "---" + data.Email + "---" + data.Phone + "---" + data.Country);
                    }
                    using (var writer = new StreamWriter(exportFilePath))
                    {
                        using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                        {
                            csvExport.WriteRecords(records);
                        }
                    }
                }
            }
        }
        public void ImplementCSVHandlerToJson()
        {
            string importFilePath = @"D:\Bridgelabz Problem statement\CSVHelperImplementation\CSVHelperImplementation\Import.csv";
            string exportFilePath = @"D:\Bridgelabz Problem statement\CSVHelperImplementation\CSVHelperImplementation\ExportJson.json";
            using (var reader = new StreamReader(importFilePath))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<AddressData>().ToList();
                    Console.WriteLine("Read Data From CSV");
                    foreach (var data in records)
                    {
                        Console.WriteLine(data.Name + "---" + data.Email + "---" + data.Phone + "---" + data.Country);
                    }
                    JsonSerializer serializer = new JsonSerializer();
                    using (var sw = new StreamWriter(exportFilePath))
                    {
                        using (var writer = new JsonTextWriter(sw))
                        {
                            serializer.Serialize(writer, records);
                        }
                    }
                }
            }
        }
        public void ImplementJsonToCsv()
        {
            string importFilePath = @"D:\Bridgelabz Problem statement\CSVHelperImplementation\CSVHelperImplementation\ExportJson.json";
            string exportFilePath = @"D:\Bridgelabz Problem statement\CSVHelperImplementation\CSVHelperImplementation\Sample.csv";
            List<AddressData> list = JsonConvert.DeserializeObject<List<AddressData>>(File.ReadAllText(importFilePath));
            using (var writer = new StreamWriter(exportFilePath))
            {
                using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(list);
                }
            }
        }
    }
}