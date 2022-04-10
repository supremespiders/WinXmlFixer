using System;

namespace WinXmlFixer.Models;

public class KnownException:Exception
{
    public KnownException(string s):base(s)
    {
        
    }
}