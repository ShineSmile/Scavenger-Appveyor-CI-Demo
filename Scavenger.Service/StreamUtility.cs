using System.IO;

namespace Scavenger.Service
{
    internal static class StreamUtility
    {
        public static string ReadToEnd(this Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        public static void Write(this Stream stream, string value)
        {
            using (var writer = new StreamWriter(stream))
            {
                writer.Write(value);
                writer.Flush();
            }
        }
    }
}