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
    public class NCZFeatureClass : BaseObject
    {
        private int _layerCode;

        public int LayerCode
        {
            get { return _layerCode; }
            set { _layerCode = value; }
        }

        private string _layerName;

        public string LayerName
        {
            get { return _layerName; }
            set { _layerName = value; }
        }

        private List<NCZFeature> _features;

        public List<NCZFeature> Features
        {
            get { return _features; }
            set { _features = value; }
        }

        public NCZFeatureClass()
        {
            _features = new List<NCZFeature>();
        }
    }
}