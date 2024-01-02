// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

double heighInMetres = 1.88;
Console.WriteLine($"The variable {nameof(heighInMetres)} has the value {heighInMetres}");

Console.OutputEncoding = System.Text.Encoding.UTF8;

string horizontalLine = new('-', 74);
string grinningEmoji = char.ConvertFromUtf32(0x1F600);

Console.WriteLine(grinningEmoji);
Console.WriteLine(horizontalLine);

// Raw literals

string xml = """
    <person age="50">
        <first_name>Mark</first_name>
        </person
    """;

Console.WriteLine(xml);

// Raw interpoler literals

var person = new { FirstName = "Alice", Age = 56 };

string json = $$"""
    {
        "first_name": "{{person.FirstName}}",
        "age":{{person.Age}}",
        "calculations":{{1 + 2}}",
    }
    """;

Console.WriteLine(json);
