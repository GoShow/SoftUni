﻿using System.IO;
using Vehicles.IO.Interfaces;

namespace Vehicles.IO;

public class FileWriter : IWriter
{
    public void WriteLine(string str)
    {
        using StreamWriter writer = new("../../../test.txt", true);

        writer.WriteLine(str);
    }
}
