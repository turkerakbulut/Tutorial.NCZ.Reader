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
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using System.Text;
using System.Xml.Serialization;

namespace Tutorial.NCZ.Reader
{
    public class NCZFile : BaseObject, IDisposable
    {
        #region Members

        private string _path;
        private NCZObjectCollection _nczObjectList;

        #endregion Members

        #region Properties

        [XmlIgnore]
        public static NCZVersionsEnum NCZVersion { get; set; }

        //public NCZVisibleExtent Extent { get; set; }
        //public static NCZVisibleExtent NCZExtent { get; set; }

        [XmlIgnore]
        public static double Tolerance { get; set; }

        [XmlIgnore]
        public NCZObjectCollection NczObjectList
        {
            get { return _nczObjectList; }
            set { _nczObjectList = value; }
        }

        [XmlIgnore]
        private List<BaseNCZObject> LayerList { get; set; }

        public List<NCZFeatureClass> FeatureClasses { get; set; }
        private static int _layerCount;

        public static int LayerCount
        {
            get { return NCZFile._layerCount; }
            set { NCZFile._layerCount = value; }
        }

        public static Encoding Encode = Encoding.GetEncoding("iso-8859-1");

        #endregion Properties

        #region Constructor

        public NCZFile(string path)
        {
            _path = path;
            _nczObjectList = new NCZObjectCollection();
            LayerList = new List<BaseNCZObject>();
        }

        public NCZFile()
        {
        }

        private void CheckFileAccess()
        {
            FileSecurity fs = System.IO.File.GetAccessControl(_path);

            FileInfo fi = new FileInfo(_path);
            System.Security.Permissions.FileIOPermission fp = new System.Security.Permissions.FileIOPermission
                (System.Security.Permissions.FileIOPermissionAccess.Read, _path);
            if (System.Security.SecurityManager.IsGranted(fp))
            {
                string tempPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + fi.Name;
                File.Copy(_path, tempPath, true);
                _path = tempPath;
            }
        }

        public NCZFile(string path, double tolerance)
        {
            _path = path;
            CheckFileAccess();
            Tolerance = tolerance;
            _nczObjectList = new NCZObjectCollection();
            LayerList = new List<BaseNCZObject>();
        }

        #endregion Constructor

        public void Load()
        {
            try
            {
                int loopCount = 0;
                using (BinaryReader _br = new BinaryReader(File.Open(_path, FileMode.Open, FileAccess.Read, FileShare.Read)))//Create BinaryReader
                {
                    byte initialByte;
                    while (_br.BaseStream.CanSeek)
                    {
                        loopCount++;
                        initialByte = _br.ReadByte();

                        NCZObjectTypes type = (NCZObjectTypes)Enum.Parse(typeof(NCZObjectTypes), initialByte.ToString());

                        switch (type)
                        {
                            case NCZObjectTypes.FileHeader:
                                if (!_nczObjectList.HasFileHeader)
                                {
                                    NCZFileHeader fileHeader = new NCZFileHeader();
                                    fileHeader.Load(_br, true);
                                    _nczObjectList.Add(fileHeader);
                                }
                                break;

                            case NCZObjectTypes.VisibleExtent:
                                //this part is included in the original project
                                break;

                            case NCZObjectTypes.Other:
                                //this part is included in the original project
                                break;

                            case NCZObjectTypes.Version:
                                if (!_nczObjectList.HasVersion)
                                {
                                    NCZVersion version = new NCZVersion();
                                    version.Load(_br, false);
                                    _nczObjectList.Add(version);
                                    NCZVersion = NCZUtility.NCZVersion(version.VersionName);
                                }
                                break;

                            case NCZObjectTypes.Geometry:
                                NCZGeometry geometry = new NCZGeometry();
                                geometry.Load(_br, false);
                                if (geometry.Geometry != null)
                                    _nczObjectList.Add(geometry);
                                break;

                            case NCZObjectTypes.Metadata:
                                    //this part is included in the original project
                                break;

                            case NCZObjectTypes.GeometryLink:
                                //this part is included in the original project.
                                break;

                            default:
                                break;
                        }
                    }
                }
                Console.WriteLine("Dongu Sayisi:" + loopCount);
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(IOException))
                    NCZFileLogger.Log(LogLevel.ERROR, _path + " dosya okunurken hata olustu:" + ex.ToString());
            }
        }

        #region Private Methods

        private void LoadLayerNames(BinaryReader _br)
        {
            //this part is included in the original project
        }

        #endregion Private Methods

        #region IDisposable Members

        public void Dispose()
        {
            GC.Collect();
        }

        #endregion IDisposable Members
    }
}