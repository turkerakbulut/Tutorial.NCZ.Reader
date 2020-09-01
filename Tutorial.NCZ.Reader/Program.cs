#region Copyright (C) 2011-2020 Türker Akbulut

// Copyright (C) 2011-2020 Türker Akbulut
// https://turkerakbulut.com
// 
// Tutorial.NCZ.Reader is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 2 of the License, or
// (at your option) any later version.
// 
// Tutorial.NCZ.Reader is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with Tutorial.NCZ.Reader. If not, see <http://www.gnu.org/licenses/>.

#endregion

using System;
using System.IO;

namespace Tutorial.NCZ.Reader
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("NCZ file path:");

            string path = Console.ReadLine();

            NCZFile file = new NCZFile(path);

            file.Load();

            for (int i = 0; i < file.NczObjectList.List.Count; i++)
                Console.WriteLine(file.NczObjectList[i].ToString());

            Console.Read();
        }
    }
}