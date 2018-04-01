using System;
using System.Diagnostics;
using System.IO;
using System.Net.Mail;
using System.Text;

namespace StreamsDemo
{
    /// <summary>
    /// Class which works with files.
    /// </summary>
    public static class StreamsExtension
    {
        #region Public members

        #region TODO: Implement by byte copy logic using class FileStream as a backing store stream .   
        
        /// <summary>
        /// Copies one file to another by byte copy.
        /// </summary>
        /// <param name="sourcePath">The source path.</param>
        /// <param name="destinationPath">The destination path.</param>
        /// <returns>Returns number of bytes.</returns>
        public static int ByByteCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            using (FileStream source = new FileStream(sourcePath, FileMode.Open))
            using (FileStream destination = new FileStream(destinationPath, FileMode.Create))
            {
                byte[] mass = { };
                int count = 0;

                for (int i = 0; i < source.Length; i++)
                {
                    source.Read(mass, 0, 1);
                    destination.WriteByte(mass[0]);
                    count++;
                }

                return count;
            }
        }

        #endregion

        #region TODO: Implement by byte copy logic using class MemoryStream as a backing store stream.

        /// <summary>
        /// Copies one file to another in the memory by byte copy.
        /// </summary>
        /// <param name="sourcePath">The source path.</param>
        /// <param name="destinationPath">The destination path.</param>
        /// <returns>Returns number of bytes.</returns>
        public static int InMemoryByByteCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            byte[] arrayOfBytes;

            using (var source = new FileStream(sourcePath, FileMode.Open))
            using (TextReader reader = new StreamReader(source))
            {
                string str = reader.ReadToEnd();
                byte[] temp = Encoding.UTF8.GetBytes(str);
                MemoryStream tempThread = new MemoryStream(temp);
                arrayOfBytes = tempThread.ToArray();

                using (var destination = new FileStream(destinationPath, FileMode.Create))
                using (TextWriter writer = new StreamWriter(destination))
                {
                    char[] textIn = Encoding.UTF8.GetChars(temp);
                    writer.Write(textIn, 0, textIn.Length);

                    return textIn.Length;
                }
            }
        }

        #endregion

        #region TODO: Implement by block copy logic using FileStream buffer.

        /// <summary>
        /// Copies one file to another by block copy.
        /// </summary>
        /// <param name="sourcePath">The source path.</param>
        /// <param name="destinationPath">The destination path.</param>
        /// <returns>Returns number of bytes.</returns>
        public static int ByBlockCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            using (FileStream source = new FileStream(sourcePath, FileMode.Open))
            {
                byte[] bytes = new byte[source.Length];
                int numBytesToRead = (int)source.Length;
                int numBytesRead = 0;

                while (numBytesToRead > 0)
                {
                    int n = source.Read(bytes, numBytesRead, numBytesToRead);

                    if (n == 0)
                        break;

                    numBytesRead += n;
                    numBytesToRead -= n;
                }

                numBytesToRead = bytes.Length;

                using (FileStream destination = new FileStream(destinationPath, FileMode.Create))
                {
                    destination.Write(bytes, 0, numBytesToRead);
                }

                return numBytesToRead;
            }
        }

        #endregion

        #region TODO: Implement by block copy logic using MemoryStream.

        /// <summary>
        /// Copies one file to another in the memory by block copy.
        /// </summary>
        /// <param name="sourcePath">The source path.</param>
        /// <param name="destinationPath">The destination path.</param>
        /// <returns>Returns number of bytes.</returns>
        public static int InMemoryByBlockCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            return InMemoryByByteCopy(sourcePath, destinationPath);
        }

        #endregion

        #region TODO: Implement by block copy logic using class-decorator BufferedStream.

        /// <summary>
        /// Copies one file to another by buffereds copy.
        /// </summary>
        /// <param name="sourcePath">The source path.</param>
        /// <param name="destinationPath">The destination path.</param>
        /// <returns>Returns number of bytes.</returns>
        public static int BufferedCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            using (FileStream source = new FileStream(sourcePath, FileMode.Open))
            { 
                using (FileStream destination = new FileStream(destinationPath, FileMode.Create))
                using (BufferedStream buffer = new BufferedStream(source, (int)source.Length))
                {
                    for (int i = 0; i < source.Length; i++)
                    {
                        destination.WriteByte((byte)buffer.ReadByte());
                    }

                    return (int)destination.Length;
                }
            }
        }

        #endregion

        #region TODO: Implement by line copy logic using FileStream and classes text-adapters StreamReader/StreamWriter

        /// <summary>
        /// Copies one file to another by the line copy.
        /// </summary>
        /// <param name="sourcePath">The source path.</param>
        /// <param name="destinationPath">The destination path.</param>
        /// <returns>Returns number of lines.</returns>
        public static int ByLineCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            using (FileStream source = new FileStream(sourcePath, FileMode.Open))
            using (TextReader reader = new StreamReader(source))
            {
                using (FileStream destination = new FileStream(destinationPath, FileMode.Create))
                using (TextWriter writer = new StreamWriter(destination))
                {
                    string str = String.Empty;
                    int count = 0;

                    for (int i = 0; i < source.Length; i++)
                    {
                        str = reader.ReadLine();
                        writer.WriteLine(str);
                        count++;
                    }

                    return count;
                }
            }
        }

        #endregion

        #region TODO: Implement content comparison logic of two files 

        /// <summary>
        /// Determines whether [is content equals] [the specified source path].
        /// </summary>
        /// <param name="sourcePath">The source path.</param>
        /// <param name="destinationPath">The destination path.</param>
        /// <returns>
        ///   <c>true</c> if [is content equals] [the specified source path]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsContentEquals(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            using (FileStream source = new FileStream(sourcePath, FileMode.Open))
            using (FileStream destination = new FileStream(destinationPath, FileMode.Create))
            {
                if (source.Length != destination.Length)
                {
                    return false;
                }

                for (int i = 0; i < source.Length; i++)
                {
                    if (source.ReadByte() != destination.ReadByte())
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        #endregion

        #endregion

        #region Private members

        #region TODO: Implement validation logic

        /// <summary>
        /// Inputs the validation.
        /// </summary>
        /// <param name="sourcePath">The source path.</param>
        /// <param name="destinationPath">The destination path.</param>
        /// <exception cref="ArgumentException">source path and destination path</exception>
        private static void InputValidation(string sourcePath, string destinationPath)
        {
            if (File.Exists(sourcePath) == false || File.Exists(destinationPath) == false)
            {
                throw new ArgumentException($"File {nameof(sourcePath)} or {nameof(destinationPath)} is not exist!");
            }
        }

        #endregion

        #endregion

    }
}
