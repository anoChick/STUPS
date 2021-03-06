﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/31/2013
 * Time: 12:10 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System.Management.Automation;
    using Interfaces.TestStructure;

    /// <summary>
    /// Description of TestResultDetailCmdletBase.
    /// </summary>
    public class TestResultDetailCmdletBase : CommonCmdletBase
    {
        public TestResultDetailCmdletBase()
        {
            if (Preferences.AutoEcho)
                Echo = true;
        }
        
        #region Parameters
        [Parameter(Mandatory = false)]
        internal new string Name { get; set; }
        
        [Parameter(Mandatory = false)]
        internal new string Id { get; set; }
        
        [Parameter(Mandatory = true,
                   Position = 0)]
        [ValidateNotNullOrEmpty()]
        public string TestResultDetail { get; set; }
        
        [Parameter(Mandatory = false)]
        public TestStatuses TestResultStatus { get; set; }
        
        [Parameter(Mandatory = false)]
        public SwitchParameter Echo { get; set; }
        
        [Parameter(Mandatory = false)]
        public SwitchParameter Finished { get; set; }
        #endregion Parameters
    }
}
