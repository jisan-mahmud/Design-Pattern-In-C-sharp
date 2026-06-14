using System;
using System.Xml;
using System.Xml.Linq;

public interface IDataProcessor
{
    void ProcessData();
}

public class XMLDataProvider
{
    public string GetXMLData()
    {
        XDocument xmlDoc = new XDocument(
         new XElement("User",
          new XElement("Name", "Jisan Mahmud"),
          new XElement("Password", "1234"),
          new XElement("Age", 21)
          )
        );
        return xmlDoc.ToString();
    }
}

public class XmlToJsonAdapter : IDataProcessor
{
    private XMLDataProvider _xmlDataProvider;

    public XmlToJsonAdapter(XMLDataProvider xmlDataProvider)
    {
        _xmlDataProvider = xmlDataProvider;
    }

    public void ProcessData()
    {
        string xmlData = _xmlDataProvider.GetXMLData();
        XDocument doc = System.Xml.Linq.XDocument.Parse(xmlData);
        string convertedJson = Newtonsoft.Json.JsonConvert.SerializeXNode(doc,
         Newtonsoft.Json.Formatting.Indented, true);
        Console.WriteLine(convertedJson);
    }

}

class Program
{
    static void Main()
    {
        XMLDataProvider xmlDataProvider = new XMLDataProvider();
        IDataProcessor dataProcessor = new XmlToJsonAdapter(xmlDataProvider);
        dataProcessor.ProcessData();
    }
}