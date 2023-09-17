using CsvHelper.Configuration.Attributes;

namespace full_stack.Models
{
    public class State
    {
        [Index(0)]
        public int Id { get; set; }

        [Index(1)]
        public String Name { get; set; }

        [Index(2)]
        [Optional]
        public String PostCodes { get; set; }
    }
}
