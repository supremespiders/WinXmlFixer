using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace WinXmlFixer.Extensions;

public static class Util
{
    public static string Location(this Exception ex)
    {
        var st = new StackTrace(ex, true);
        var frame = st.GetFrames().FirstOrDefault(x => x.GetFileLineNumber() != 0);
        if (frame == null) return "NA";
        return $"{Path.GetFileName(frame.GetFileName())} : {frame.GetFileLineNumber()}";
    }
}