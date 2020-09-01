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
using System.Text;

namespace Tutorial.NCZ.Reader
{
    internal class NCZUtility
    {
        /// <summary>
        ///convert text to Pascal Case
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ConvertToPascalCase(string str)
        {
            //if nothing is proivided throw a null argument exception
            if (str == null) throw new ArgumentNullException("str", "Null text cannot be converted!");

            if (str.Length == 0) return str;

            //split the provided string into an array of words
            string[] words = str.Split(' ');

            //loop through each word in the array
            for (int i = 0; i < words.Length; i++)
            {
                //if the current word is greater than 1 character long
                if (words[i].Length > 0)
                {
                    //grab the current word
                    string word = words[i];

                    //convert the first letter in the word to uppercase
                    char firstLetter = char.ToUpper(word[0]);

                    //concantenate the uppercase letter to the rest of the word
                    words[i] = firstLetter + word.Substring(1);
                }
            }

            //return the converted text
            return string.Join(string.Empty, words);
        }

        /// <summary>
        /// Ascii code 32-128 arasi icin
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ConvertToLegalString(string str)
        {
            StringBuilder sb = new StringBuilder();
            char[] array = str.ToCharArray();
            foreach (var chr in array)
            {
                int code = (int)chr;
                if (code > 47 && code < 58 || code > 64 && code < 91 || code > 96 && code < 123 || code == 47 || code == 92)
                    sb.Append(chr);
            }

            return sb.ToString();
        }

        public static string ConvertToLegalString(byte[] data, Encoding encoding)
        {
            encoding = Encoding.GetEncoding("iso-8859-1");
            string str = encoding.GetString(data);
            return ConvertToLegalString(str);
        }

        public static NCZVersionsEnum NCZVersion(string versionName)
        {
            Array array = Enum.GetValues(typeof(NCZVersionsEnum));
            foreach (var item in array)
            {
                string v = item.ToString().Replace("_", ".").Replace("V", "");
                if (versionName.Contains(v))
                    return (NCZVersionsEnum)item;
            }
            return NCZVersionsEnum.Unknown;
        }
    }
}