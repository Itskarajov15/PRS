using API.Models;
using API.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Authorize]
public class XmlController : ControllerBase
{
    private readonly IXmlService _xmlFileService;

    public XmlController(IXmlService xmlFileService)
    {
        _xmlFileService = xmlFileService;
    }

    [HttpGet("api/xml/download")]
    public IActionResult DownloadXmlFile()
    {
        var content = _xmlFileService.ReadXmlFile();
        var fileName = "file.xml";

        return File(
            System.Text.Encoding.UTF8.GetBytes(content),
            "application/xml",
            fileName
        );
    }

    [HttpGet("api/xml/read")]
    public IActionResult ReadXmlFile()
    {
        var content = _xmlFileService.ReadXmlFile();
        return Ok(content);
    }

    [HttpPost("api/xml/add-comment")]
    public IActionResult AddCommentToXmlFile([FromBody] string comment)
    {
        if (string.IsNullOrWhiteSpace(comment))
        {
            return BadRequest("Comment cannot be empty");
        }

        _xmlFileService.AddCommentToXmlFile(comment);
        return Ok();
    }

    [HttpPost("api/xml/add-element")]
    public IActionResult AddElementToXmlFile([FromBody] XmlElementRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.ElementName) || string.IsNullOrWhiteSpace(request.ElementValue))
        {
            return BadRequest("Element name and value cannot be empty.");
        }

        _xmlFileService.AddNewElementToXmlFile(request.ElementName, request.ElementValue);
        return Ok();
    }
}