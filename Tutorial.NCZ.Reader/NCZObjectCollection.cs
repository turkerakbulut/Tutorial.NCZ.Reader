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

using System.Collections.Generic;

namespace Tutorial.NCZ.Reader
{
    public class NCZObjectCollection
    {
        private List<BaseNCZObject> _list;

        public List<BaseNCZObject> List
        {
            get { return _list; }
            set { _list = value; }
        }

        public NCZObjectCollection()
        {
            _list = new List<BaseNCZObject>();
        }

        public bool HasFileHeader { get; set; }
        public bool HasVisibleExtent { get; set; }
        public bool HasFileData { get; set; }
        public bool HasMetadata { get; set; }
        public bool HasVersion { get; set; }
        public bool HasUserInfo { get; set; }
        public bool HasLayers { get; set; }

        public BaseNCZObject this[int index]
        {
            get
            {
                return ((BaseNCZObject)_list[index]);
            }
            set
            {
                _list[index] = value;
            }
        }

        public void Add(BaseNCZObject value)
        {
            if (value.NCZObjectType == typeof(NCZFileHeader))
                HasFileHeader = true;
            else if (value.NCZObjectType == typeof(NCZVersion))
                HasVersion = true;
            //else if (value.NCZObjectType == typeof(NCZVisibleExtent))
            //    HasVisibleExtent = true;
            //else if (value.NCZObjectType == typeof(NCZMetadata))
            //    HasMetadata = true;
            else if (value.NCZObjectType == typeof(NCZUserInfo))
                HasMetadata = true;

            _list.Add(value);
        }

        public int IndexOf(BaseNCZObject value)
        {
            return (_list.IndexOf(value));
        }
    }
}