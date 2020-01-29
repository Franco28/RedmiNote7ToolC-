// <copyright file=CConfigDO>
// Copyright (c) 2019-2020 All Rights Reserved
// </copyright>
// <author>Franco28</author>
// <date> 29/1/2020 13:16:41</date>
// <summary>A DLL Lib needed by Redmi Note 7 Tool</summary>

using System;

namespace Franco28Tool.Engine
{
  [Serializable()]
  public class CConfigDO
  {
        
        private System.Drawing.Point m_oStartPos;
        private System.Drawing.Size m_oStartSize;
        private System.StringComparison m_oLang;

        public System.Drawing.Point StartPos
        {
            get { return m_oStartPos; }
            set { m_oStartPos = value; }
        }

        public System.Drawing.Size StartSize
        {
            get { return m_oStartSize; }
            set { m_oStartSize = value; }
        }

        public System.StringComparison Lang
        {
            get { return m_oLang; }
            set { m_oLang = value; }
        }
    }
}
