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
    public class NCZVersion : BaseNCZObject
    {
        public string VersionName { get; set; }

        public override Type NCZObjectType
        {
            get { return typeof(NCZVersion); }
        }

        public override int Size
        {
            get { return 24; }
        }

        public override void Load(System.IO.BinaryReader br, bool loadByteArray)
        {
            base.Load(br, loadByteArray);
            byte[] temp = br.ReadBytes(4);
            this.VersionName = NCZUtility.ConvertToLegalString(Encoding.ASCII.GetString(br.ReadBytes(14)));
            this.Data = br.ReadBytes(6);
        }

        public override string ToString()
        {
            return "Version: " + VersionName;
        }
    }
}