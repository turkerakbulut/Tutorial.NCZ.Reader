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
    public class NCZPoint : BaseNCZObject
    {
        public string Name { get; set; }
        public NCZCoordinate Coordinate { get; set; }

        public NCZPoint()
        {
        }

        public string ToWKT()
        {
            string geom = "POINT(" + Coordinate.X.ToString() + " " + Coordinate.Y.ToString() + ")";
            return geom;
        }

        public override Type NCZObjectType
        {
            get { return typeof(NCZPoint); }
        }

        public override int Size
        {
            get { return 108; }
        }

        public override void Load(System.IO.BinaryReader br, bool loadByteArray)
        {
            base.Load(br, loadByteArray);
            LayerCode = br.ReadByte();                         
            Coordinate = new NCZCoordinate(br, true);           
            byte[] temp = br.ReadBytes(55);                    
            Name = Encoding.ASCII.GetString(br.ReadBytes(21)).Replace("\0", "");
        }

        public override string ToString()
        {
            return ToWKT();
        }
    }
}