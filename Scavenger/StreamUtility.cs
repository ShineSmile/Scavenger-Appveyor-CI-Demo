using System;
using System.IO;

namespace Scavenger
{
    public static class StreamUtility
    {
        /// <summary>
        ///     Read stream as string.
        /// </summary>
        /// <param name="stream"></param>
        /// <exception cref="ArgumentException">
        ///     Stream will close after reader dispose. Don't call it MORE THAN ONCE for same
        ///     stream.
        /// </exception>
        /// <returns>stream content as string</returns>
        public static string ReadToEnd(this Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        /// <summary>
        ///     An extend for writing string to stream.
        /// </summary>
        /// <param name="stream">the stream be writed into string</param>
        /// <param name="value">string for writing to the stream</param>
        /// <exception cref="ArgumentException">
        ///     Stream will close after writer dispose. Don't call it MORE THAN ONCE for same
        ///     stream.
        /// </exception>
        public static void Write(this Stream stream, string value)
        {
            using (var writer = new StreamWriter(stream))
            {
                writer.Write(value);
            }
        }
    }
}