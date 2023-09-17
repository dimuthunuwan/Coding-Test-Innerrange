using CsvHelper;
using CsvHelper.Configuration;
using full_stack.Util.Interfaces;
using System.Globalization;

namespace full_stack.Util.Classes
{
    public class CSVService : ICSVService
    {
        
        public IEnumerable<T> ReadCSV<T>(Stream file,Boolean hasHeaderRecord)
        {
            var reader = new StreamReader(file);
            
            //csv.Configuration.HasHeaderRecord = true;
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = hasHeaderRecord,
                MissingFieldFound = null
            };

            var csv = new CsvReader(reader, configuration);

            var records = csv.GetRecords<T>();
            return records;
        }
    

    }
}
