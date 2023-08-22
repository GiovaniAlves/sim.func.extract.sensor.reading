using OfficeOpenXml.Packaging.Ionic.Zlib;
using System;
using System.IO;

namespace SIM.Ports.Func.ExtractSensorReading
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"C:\Users\Coodesh\Documents\Vibracon\sim.func.extract.sensor.reading\src\ports\SIM.Ports.Func.ExtractSensorReading\COMP";
            string outputFilePath = @"C:\Users\Coodesh\Documents\Vibracon\sim.func.extract.sensor.reading\src\ports\SIM.Ports.Func.ExtractSensorReading\output.txt";

            using (FileStream inputStream = new FileStream(inputFilePath, FileMode.Open))
            {
                using (MemoryStream outputStream = new MemoryStream())
                {
                    using (ZlibStream deflateStream = new ZlibStream(inputStream, CompressionMode.Decompress))
                    {
                        deflateStream.CopyTo(outputStream);
                    }
                    byte[] decompressedBytes = outputStream.ToArray();
                    // Salvar os bytes descompactados em um arquivo
                    File.WriteAllBytes(outputFilePath, decompressedBytes);
                    Console.WriteLine("Arquivo zlib descompactado com sucesso.");
                }
            }
        }
    }
}
