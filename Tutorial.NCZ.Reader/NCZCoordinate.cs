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
using System.Text;

namespace Tutorial.NCZ.Reader
{
    public class NCZCoordinate : BaseObject
    {
        private double x;

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        private double y;

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        private double z;

        public double Z
        {
            get { return z; }
            set { z = value; }
        }

        private double _latitude;

        public double Latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }

        private double _longitude;

        public double Longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }

        public NCZCoordinate()
        {
        }

        public NCZCoordinate(BinaryReader br, bool hasZ)
        {
            this.x = br.ReadDouble();
            this.y = br.ReadDouble();
            if (hasZ)
                this.z = br.ReadDouble();
        }

        /// <summary>
        /// Sadece X ve Y Koordinatlarına bakılmaktadır....
        /// </summary>
        /// <param name="otherCoordinate"></param>
        /// <param name="tolerance"></param>
        /// <returns></returns>
        public bool Equals(NCZCoordinate otherCoordinate, double tolerance)
        {
            double deltaX = Math.Abs(X - otherCoordinate.X);
            double deltaY = Math.Abs(Y - otherCoordinate.Y);
            if (deltaX < tolerance && deltaY < tolerance)
                return true;
            else
                return false;
        }

        public bool Equals(NCZCoordinate otherCoordinate, int precision)
        {
            if (Math.Round(X, precision) == Math.Round(otherCoordinate.X, precision) && Math.Round(Y, precision) == Math.Round(otherCoordinate.Y, precision))
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("X:" + X + ",");
            sb.Append("Y:" + Y + ",");
            sb.Append("Z:" + Z);

            return sb.ToString();
        }
    }
}