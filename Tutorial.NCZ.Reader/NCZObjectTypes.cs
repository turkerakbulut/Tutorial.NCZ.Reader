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
    public enum NCZObjectTypes
    {
        FileHeader = 01,
        UserInfo = 02,
        Xtype03 = 03,
        VisibleExtent = 00,//this part is included in the original project
        Other =999,
        //this part is included in the original project
        //this part is included in the original project
        //this part is included in the original project
        //this part is included in the original project
        //this part is included in the original project
        Version = 25, 
        Geometry = 21, 
        GeometryLink = 98,//this part is included in the original project
        Metadata = 99,//this part is included in the original project
        LayerName = 253, 
    }
}