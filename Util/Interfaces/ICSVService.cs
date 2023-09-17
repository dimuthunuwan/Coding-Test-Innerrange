namespace full_stack.Util.Interfaces
{
    public interface ICSVService
    {
        public IEnumerable<T> ReadCSV<T>(Stream file, Boolean hasHeaderRecord);
    }
}
