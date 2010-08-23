/*
Copyright 2010 Sedat Kapanoglu

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace cinali
{
    public class Resource
    {
        const int readBufferSize = 256 * 1024; // 256kb read size

        private static Stream getResourceStream(string name)
        {
            return Assembly.GetExecutingAssembly().GetManifestResourceStream("cinali." + name);
        }

        public static void ExtractFile(string name, string destinationPath)
        {
            using (var stream = getResourceStream(name))
            using (var outputStream = File.Create(destinationPath))
            {
                byte[] buffer = new byte[readBufferSize];
                int readBytes;
                while ((readBytes = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    outputStream.Write(buffer, 0, readBytes);
                }
            }
        }

        public static string[] GetStringArray(string name)
        {
            using(StreamReader reader = new StreamReader(getResourceStream(name)))
            {
                var agents = new List<string>();
                while (!reader.EndOfStream)
                {
                    agents.Add(reader.ReadLine());
                }
                return agents.ToArray();
            }
        }
    }
}
