using System;

namespace WinXmlFixer.Models;

public class Config
{
    public string FtpHost { get; set; }
    public string FtpUser { get; set; }
    public string FtpPass { get; set; }
    public string XmlLocation { get; set; }
    public DateTime RunAt { get; set; }
}