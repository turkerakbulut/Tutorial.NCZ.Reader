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
    public class NCZUserInfo : BaseNCZObject
    {
        public const int totalByteSize = 371;
        private string _userName;

        private byte[] _data;

        public byte[] Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public NCZUserInfo()
        {
        }

        public void Load(BinaryReader br)
        {
            _data = br.ReadBytes(totalByteSize);
        }

        public override Type NCZObjectType
        {
            get { throw new NotImplementedException(); }
        }

        public override int Size
        {
            get { throw new NotImplementedException(); }
        }
    }
}