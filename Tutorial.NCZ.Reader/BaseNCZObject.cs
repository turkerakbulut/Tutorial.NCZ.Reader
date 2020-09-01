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
using System.Xml.Serialization;

namespace Tutorial.NCZ.Reader
{
    public abstract class BaseNCZObject
    {
        //Members
        private long _firstBytePosition;

        private byte[] _data;
        private ByteState _firstByte;

        [XmlIgnore]
        public abstract Type NCZObjectType { get; }

        private byte _layerCode;

        //Properties
        [XmlIgnore]
        public ByteState FirstByte
        {
            get { return _firstByte; }
            set { _firstByte = value; }
        }

        [XmlIgnore]
        public byte[] Data
        {
            get { return _data; }
            set
            {
                _data = value;
            }
        }

        [XmlIgnore]
        public byte LayerCode
        {
            get { return _layerCode; }
            set { _layerCode = value; }
        }

        public abstract int Size { get; }

        //Const
        public BaseNCZObject() { }

        //Virtual Method
        public virtual void Load(BinaryReader br, bool loadByteArray)
        {
            _firstBytePosition = br.BaseStream.Position + 1;
            if (loadByteArray)
                _data = br.ReadBytes(this.Size);

            if (_data != null)
                _firstByte = new ByteState(_firstBytePosition, _data[0]);
            else
            {
                _firstByte = new ByteState(_firstBytePosition);
            }
        }

        /// <summary>
        /// 0 ise size kadar geri gidecektir
        /// </summary>
        /// <param name="br"></param>
        /// <param name="size"></param>
        public virtual void Back(BinaryReader br, int size)
        {
            int len = 0;
            if (size > 0)
                len = size;
            else
                len = Size;

            if (br.BaseStream.Position > len)
                br.BaseStream.Position = br.BaseStream.Position - len;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString();
        }
    }
}