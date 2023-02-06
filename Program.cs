using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Xml;
using System.Xml.Serialization;


namespace Test
{

public class Program
{
[Serializable]
public class Figures
{
public string Shape { get; set; }
public int Length { get; set; }
public int Width { get; set; }

public override string ToString()
{
return Shape + "\n" + Length + "\n" + Width;
}

public Figures(string a, int b, int c)
{
Shape = a; Length = b; Width = c;

}

}
static List<Figures> figures { get; set; } = new List<Figures>();

static void Main(string[] args)
{
// vod();

Console.WriteLine("Введите путь до файла");
Console.WriteLine("---------------------");

string way = Console.ReadLine();


if (way.Contains("txt"))
{
Console.Clear();
Console.WriteLine("Сохранить - F1; Выход - Escape");
string[] lines = File.ReadAllLines(way);

for (int i = 0; i < lines.Length; i+=3)
{
Figures a = new Figures(lines[i], Convert.ToInt32(lines[i + 1]), Convert.ToInt32(lines[i + 2]));

Console.WriteLine(a);
Convert.ToInt32( lines[i + 1]);
Convert.ToInt32( lines[i + 2]);
figures.Add(a);
}


}
else if (way.Contains("json"))
{
string json = File.ReadAllText(way);
figures = JsonConvert.DeserializeObject<List<Figures>>(json);

Console.Clear();
Console.WriteLine("Для сохранения файла нажмите F1; Для выхода намжмите Escape");
Console.WriteLine("-----------------------------------------------------------");

foreach (var abv in figures)
{
Console.WriteLine(abv);
}

}
else if (way.Contains(".xml"))
{
XmlSerializer xml = new XmlSerializer(typeof(List<Figures>));
using (FileStream fs = new FileStream(way, FileMode.Open))
{
figures = (List<Figures>)xml.Deserialize(fs);


foreach (var abc in figures)
{
Console.WriteLine(abc);
}
}
}



input();
}


static void input()
{
ConsoleKeyInfo a = Console.ReadKey();
if (a.Key == ConsoleKey.F1)
{

Console.Clear();
Console.WriteLine("Введите путь до файла");
string way = Console.ReadLine()!;
if (way.Contains(".txt"))
{
StreamWriter sw = new StreamWriter(way);
foreach (var figure in figures)
{
sw.WriteLine(figure);
}
sw.Close();
}
else if (way.Contains(".json"))
{
string json = JsonConvert.SerializeObject(figures);
StreamWriter sw = new StreamWriter(way);
sw.WriteLine(json);
sw.Close();
}
else if (way.Contains(".xml"))
{
XmlSerializer xml = new XmlSerializer(typeof(List<Figures>));
using (FileStream fs = new FileStream(way, FileMode.OpenOrCreate))
{
xml.Serialize(fs, figures);

}
}
}

}
}
}