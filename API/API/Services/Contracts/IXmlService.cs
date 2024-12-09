namespace API.Services.Contracts;

public interface IXmlService
{
    string ReadXmlFile();

    void AddCommentToXmlFile(string comment);

    void AddNewElementToXmlFile(string elementName, string elementValue);
}