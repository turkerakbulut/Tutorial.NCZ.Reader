
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
    public class NCZGeometry : BaseNCZObject
    {
        private BaseNCZObject _geometry;

        public BaseNCZObject Geometry
        {
            get { return _geometry; }
            set { _geometry = value; }
        }

        public NCZGeometry()
        {
            //_geometryList = new List<BaseNCZObject>();
        }

        public override Type NCZObjectType
        {
            get { return typeof(NCZGeometry); }
        }

        public override int Size
        {
            get { throw new NotImplementedException(); }
        }

        public override void Load(System.IO.BinaryReader br, bool loadByteArray)
        {
            long position = br.BaseStream.Position;

            base.Load(br, loadByteArray);
            byte first = br.ReadByte();
            byte second = br.ReadByte();
            bool isGeom = true;
            for (int i = 0; i < 3; i++)
            {
                byte checkByte = br.ReadByte();
                if (checkByte != 0)
                {
                    isGeom = false;
                    break;
                }
            }

            if (isGeom)
            {
                NCZGeometryTypes geomType = (NCZGeometryTypes)Enum.Parse(typeof(NCZGeometryTypes),
                br.ReadByte().ToString());
                switch (geomType)
                {
                    case NCZGeometryTypes.Unknown:
                        break;

                    case NCZGeometryTypes.Point:
                        NCZPoint p = new NCZPoint();
                        p.Load(br, false);
                        _geometry = p;
                        break;

                    //case NCZGeometryTypes.Line:
                    //    //NCZLine line = new NCZLine();
                    //    //line.Load(br, false);
                    //    //_geometry = line;
                    //    break;

                    //case NCZGeometryTypes.Circle:
                    //    break;

                    //case NCZGeometryTypes.Arc:
                    //    break;

                    //case NCZGeometryTypes.Text:
                    //    break;

                    //case NCZGeometryTypes.Symbol:
                    //    break;

                    //case NCZGeometryTypes.Polyline:
                    //    //this part is included in the original project
                    //    break;

                    //case NCZGeometryTypes.Box:
                    //    break;

                    default:
                        br.BaseStream.Position = position; 
                        break;
                }
            }
            else
            {
                br.BaseStream.Position = position;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (this._geometry != null)
            {
                sb.Append(_geometry.ToString());
            }
            else
            {
                sb.Append("NULL");
            }

            return sb.ToString();
        }
    }
}