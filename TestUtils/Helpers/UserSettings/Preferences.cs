﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 5/1/2013
 * Time: 3:47 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TestUtils
{
    
    /// <summary>
    /// Description of Preferences.
    /// </summary>
    public class Preferences
    {
        public Preferences()
        {
            AutoLog = false;
        }
        
        public static bool AutoLog { get; set; }
    }
}