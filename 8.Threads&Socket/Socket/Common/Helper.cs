using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

namespace Common
{
    public static class Helper
    {

        #region Work with XML

        public static readonly object Locker = new object();
        public static void WriteStringToXmlFile(string xmlString)
        {
            const string xmlFilePath = @"audit.xml";
            try
            {
                lock (Locker)
                {
                    if (!File.Exists(xmlFilePath))
                    {
                        using var sw = File.CreateText(xmlFilePath);
                        sw.WriteLine(xmlString);
                    }
                    else
                    {
                        using var sw = File.AppendText(xmlFilePath);
                        sw.WriteLine(xmlString);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static bool ValidateXmlString(string xmlString)
        {
            try
            {
                return !string.IsNullOrEmpty(xmlString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }

        public static void WriteObjToXmlFile(SocketMessage socketMessage)
        {
            var xmlSerializer = new XmlSerializer(typeof(SocketMessage));
            lock (Locker)
            {
                using var writer = new StreamWriter(@"..\..\..\audit.xml");
                xmlSerializer.Serialize(writer, socketMessage);
            }
        }

        public static string SerializeObjectToXmlString(SocketMessage socketMessage)
        {
            var xmlSerializer = new XmlSerializer(typeof(SocketMessage));
            using var writer = new StringWriter();
            xmlSerializer.Serialize(writer, socketMessage);
            return writer.ToString();
        }

        public static SocketMessage DeserializeXmlStringToObject(string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(SocketMessage));
            using var reader = new StringReader(xmlString);
            return (SocketMessage)xmlSerializer.Deserialize(reader);
        }

        #endregion

        public static bool IsValidatedEmail(string email)
        {
            const string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";

            return Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
        }

        public static string GetLocalIpAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}
