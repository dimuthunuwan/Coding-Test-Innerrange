using CsvHelper.Configuration.Attributes;

namespace full_stack.Models
{
    public class ValidateEmployee
    {
        [Optional]
        public Boolean IsNameValid { get; set; }=true;
        [Optional]
        public Boolean IsPostCodeValid { get; set; } = true;
        [Optional]
        public Boolean IsStateValid { get; set; } = true;
        [Optional]
        public Boolean IsSalaryValid { get; set; } = true;
        [Optional]
        public Boolean IsPostCodeExist { get; set; } = true;
        [Optional]
        public Boolean IsPostCodeBelongsToState { get; set; } = true;
    }
}
