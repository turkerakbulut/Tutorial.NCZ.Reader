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
namespace Tutorial.NCZ.Reader
{
    public class ByteState
    {
        public long Adress { get; set; }
        public byte Value { get; set; }

        public ByteState()
        {
        }

        public ByteState(long adress, byte value)
        {
            this.Adress = adress;
            this.Value = value;
        }

        public ByteState(long address)
        {
            this.Adress = address;
        }
    }
}