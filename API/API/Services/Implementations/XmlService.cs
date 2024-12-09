using API.Services.Contracts;
using System.Xml;

namespace API.Services.Implementations;

public class XmlService : IXmlService
{
    private const string _xmlFilePath = "file.xml";

    public string ReadXmlFile()
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(_xmlFilePath);

        using (var stringWriter = new StringWriter())
        using (var xmlTextWriter = new XmlTextWriter(stringWriter))
        {
            xmlTextWriter.Formatting = Formatting.Indented;
            doc.WriteTo(xmlTextWriter);
            return stringWriter.ToString();
        }
    }

    public void AddCommentToXmlFile(string comment)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(_xmlFilePath);

        XmlNode root = doc.DocumentElement!;

        XmlComment xmlComment = doc.CreateComment(comment);
        root.AppendChild(xmlComment);

        doc.Save(_xmlFilePath);
    }

    public void AddNewElementToXmlFile(string elementName, string elementValue)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(_xmlFilePath);

        XmlNode root = doc.DocumentElement!;

        XmlElement newElement = doc.CreateElement(elementName);
        newElement.InnerText = elementValue;

        root.AppendChild(newElement);

        doc.Save(_xmlFilePath);
    }
}