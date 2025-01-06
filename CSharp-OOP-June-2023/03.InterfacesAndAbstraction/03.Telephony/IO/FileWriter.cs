using System.IO;
using Telephony.IO.Interfaces;

namespace Telephony.IO;
public class FileWriter : IWriter
{
    public void WriteLine(string line)
    {
        string filePath = "../../../test.txt";

        using StreamWriter sw = new(filePath, true);

        sw.WriteLine(line);
    }
}
