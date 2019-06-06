namespace WalutyBusinessLogic.LoadingFromFile
{
    public class CurrencyInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public CurrencyInfo(string name, string code)
        {
            Name = name;
            Code = code;
        }
    }
}
