string inputBinaryPath = @"../../../Files/example.jpg";
string outputBinaryPath = @"../../../Files/example-output.jpg";
string textPath = @"../../../Files/text.txt";
string outputTextPath = @"../../../Files/output.txt";


////Example stream

//FileStream reader = new(inputBinaryPath, FileMode.Open);

//FileStream writer = new(outputBinaryPath, FileMode.Create);

//byte[] buffer = new byte[100];

//int bytesCount = reader.Read(buffer, 0, buffer.Length);

//while (bytesCount > 0)
//{
//    writer.Write(buffer, 0, bytesCount);

//    bytesCount = reader.Read(buffer, 0, buffer.Length);
//}

//writer.Close();
//reader.Close();





//Example stream reader / writer

//using (StreamReader reader = new(textPath))
//{
//    using (StreamWriter writer = new(outputTextPath))
//    {
//        int index = 1;
//        string line;

//        while ((line = reader.ReadLine()) != null)
//        {
//            Console.WriteLine($"{index}. {line}");
//            writer.WriteLine($"{index}. {line}");
//            index++;
//        }
//    }
//}


//File examples

//string[] lines = File.ReadAllLines(textPath);

//foreach (string line in lines)
//{
//    Console.WriteLine(line);
//}

//File.Copy(inputBinaryPath, outputBinaryPath, true);
//File.Delete(outputBinaryPath);

//byte[] bytes = File.ReadAllBytes(inputBinaryPath);
//byte[] bytesHalf = new byte[bytes.Length / 2];

//for (int i = 0; i < bytes.Length / 2; i++)
//{
//    bytesHalf[i] = bytes[i];
//}

//File.WriteAllBytes(outputBinaryPath, bytesHalf);





//Interface implementation

//public interface IFigure
//{
//    void PrintSurface();
//}

//public class Square : IFigure
//{
//    public int Side { get; set; } = 4;

//    public void PrintSurface()
//    {
//        Console.WriteLine(Side * Side);
//    }
//}

//public class Rectangle : IFigure
//{
//    public int Width { get; set; } = 10;
//    public int Height { get; set; } = 5;

//    public void PrintSurface()
//    {
//        Console.WriteLine(Width * Height);
//    }
//}





//IDisposable

//using (Person person = new())
//{
//    Console.WriteLine("In disposable object scope");
//}

//Console.WriteLine("Out of disposable object scope");

//public class Person : IDisposable
//{
//    public void Dispose()
//    {
//        Console.WriteLine("Disposing.");
//    }
//}