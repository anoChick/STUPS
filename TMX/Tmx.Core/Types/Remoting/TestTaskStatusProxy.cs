﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/20/2014
 * Time: 4:05 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Core.Types.Remoting
{
    using System;
    using Interfaces.Remoting;
    using Interfaces.TestStructure;

    /// <summary>
    /// Description of TestTaskStatusProxy.
    /// </summary>
    public class TestTaskStatusProxy : ITestTaskStatusProxy
    {
        public int Id { get; set; }
        public Guid ClientId { get; set; }
        public TestStatuses TestStatus { get; set; }
        public TestTaskStatuses TaskStatus { get; set; }
        public bool TaskFinished { get; set; }
    }
}
