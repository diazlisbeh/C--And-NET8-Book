partial class Program
{
    private const string DigitsOnlyText = @"^\d+$";
    private const string CommaSeparatorText =
      "(?:^|,)(?=[^\"]|(\")?)\"?((?(1)[^\"]*|[^,\"]*))\"?(?=,|$)";
}
