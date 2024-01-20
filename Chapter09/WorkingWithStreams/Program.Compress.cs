﻿using Packt.Shared;
using System.IO.Compression;
using System.Xml;
partial class Program
{
    private static void Compress(string algorithm = "gzip")
    {
        string filePath = Combine(CurrentDirectory, $"streams.{algorithm}");
        FileStream file = File.Create( filePath );
        Stream compressor;
        if(algorithm == "gzip")
        {
            compressor = new GZipStream(file,CompressionMode.Compress);
        }
        else
        {
            compressor = new BrotliStream(file, CompressionMode.Compress);
        }
        using (compressor)
        {
            using(XmlWriter xml = XmlWriter.Create(compressor))
            {
                xml.WriteStartDocument();
                xml.WriteStartElement("callsigns");
                foreach(string item in Viper.Callsigns)
                {
                    xml.WriteElementString("callsigns", item);
                }
            }
        }
        OutPutFileInfo(filePath);
        WriteLine("Reading the compressed XML file:");
        file = File.Open(filePath, FileMode.Open);
        Stream decompressor;
        if(algorithm == "gzip")
        {
            decompressor = new GZipStream(file, CompressionMode.Decompress);
        }
        else
        {
            decompressor = new BrotliStream(file, CompressionMode.Decompress);
        }
        using (decompressor) 
        using (XmlReader reader = XmlReader.Create(decompressor)) 
        while(reader.Read())
            {
                // Check if we are on an element node named callsign.
                if ((reader.NodeType == XmlNodeType.Element)
                  && (reader.Name == "callsign"))
                {
                    reader.Read(); // Move to the text inside element.
                    WriteLine($"{reader.Value}"); // Read its value.
                }
                // Alternative syntax with property pattern matching:
                // if (reader is { NodeType: XmlNodeType.Element,
                //   Name: "callsign" })
            }
    }

}
