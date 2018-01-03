namespace Inators.FunctionsInjectSample
{
    public class ConcatService : IConcatService
    {
        public string Concat(string name, string surname)
        {
            return $"Hello {name} {surname}!";
        }
    }
}