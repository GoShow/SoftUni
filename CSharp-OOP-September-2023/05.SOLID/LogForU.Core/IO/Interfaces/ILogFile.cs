namespace LogForU.Core.IO.Interfaces;

public interface ILogFile
{
    string Name { get; }
    string Extension { get; }
    string Path { get; }
    string FullPath { get; }
    int Size { get; }
}
