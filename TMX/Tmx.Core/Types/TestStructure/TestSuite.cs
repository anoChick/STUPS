﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/19/2012
 * Time: 2:46 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Xml.Serialization;
	using Tmx.Interfaces.TestStructure;
	// using Tmx.Core;
    
    /// <summary>
    /// Description of TestSuite.
    /// </summary>
    public class TestSuite : ITestSuite
    {
        public TestSuite()
        {
            UniqueId = Guid.NewGuid();
            // 20141106 refactoring 01
            TestScenarios = new List<ITestScenario>();
            // TestScenarios = new List<TestScenario>();
            this.Statistics = new TestStat();
            this.enStatus = TestSuiteStatuses.NotTested;
            this.Id = TestData.GetTestSuiteId();
            addDefaultPlatform();
            this.SetNow();
        }
        
        public TestSuite(string testSuiteName, string testSuiteId)
        {
            UniqueId = Guid.NewGuid();
            // 20141106 refactoring 01
            TestScenarios = new List<ITestScenario> ();
            // TestScenarios = new List<TestScenario>();
            this.Statistics = new TestStat();
            this.enStatus = TestSuiteStatuses.NotTested;
            this.Name = testSuiteName;
            this.Id = testSuiteId != string.Empty ? testSuiteId : TestData.GetTestSuiteId();
            addDefaultPlatform();
            this.SetNow();
        }
        
		void addAutogeneratedTestScenario(string testSuiteId)
		{
			TestScenarios.Add(new TestScenario(TestData.Autogenerated, "1", testSuiteId));
		}
		
		void addDefaultPlatform()
		{
            // if (!TestData.TestPlatforms.Any(tp => tp.Name == TestData.DefaultPlatformName)) {
            if (TestData.TestPlatforms.All(tp => tp.Name != TestData.DefaultPlatformName))
                TestData.AddDefaultPlatform();
            // 20141119
			// PlatformId = TestData.GetDefaultPlatformId();
			PlatformUniqueId = TestData.GetDefaultPlatformId();
		}
		
		[XmlAttribute]
        public virtual Guid UniqueId { get; set; }
//		[XmlIgnore]
//        public virtual int DbId { get; set; }
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Id { get; set; }
        // [XmlInclude(typeof(List<ITestScenario>))]
        // 20141106 refactoring 01
        [XmlElement("TestScenarios", typeof(ITestScenario))]
        public virtual List<ITestScenario> TestScenarios { get; set; }
        // [XmlElement("TestScenarios", typeof(TestScenario))]
        // public virtual List<TestScenario> TestScenarios { get; set; }
        [XmlAttribute]
        public virtual string Description { get; set; }

        string _status;
        [XmlAttribute]
        public virtual string Status { get { return _status; } }
        TestSuiteStatuses _enStatus;
        [XmlAttribute]
        public TestSuiteStatuses enStatus        
        { 
            get { return _enStatus; }
            set{
				_enStatus = value;

                switch (value) {
                    case TestSuiteStatuses.Passed:
						_status = TestData.TestStatePassed;
                        break;
                    case TestSuiteStatuses.Failed:
						_status = TestData.TestStateFailed;
                        break;
                    case TestSuiteStatuses.NotTested:
						_status = TestData.TestStateNotTested;
                        break;
                    case TestSuiteStatuses.KnownIssue:
						_status = TestData.TestStateKnownIssue;
                        break;
                    default:
                        throw new Exception("Invalid value for TestSuiteStatuses");
                }
            }
        }
        
        [XmlIgnore]
        public TestStat Statistics { get; set; }
        
        [XmlAttribute]
        public virtual DateTime Timestamp { get; set; }
        public void SetNow()
        {
			Timestamp = DateTime.Now;
        }
        
        [XmlAttribute]
        public virtual double TimeSpent { get; set; }
        public virtual void SetTimeSpent(double timeSpent)
        {
			TimeSpent = timeSpent;
        }
        
        [XmlIgnore]
        public virtual string Tags { get; set; }
        [XmlAttribute]
        // 20141119
        public virtual string PlatformId { get; set; }
        [XmlAttribute]
        public virtual Guid PlatformUniqueId { get; set; }
        
        [XmlIgnore]
        public virtual ScriptBlock[] BeforeScenario { get; set; }
        [XmlIgnore]
        public virtual ScriptBlock[] AfterScenario { get; set; }
        [XmlIgnore]
        public virtual object[] BeforeScenarioParameters { get; set; }
        [XmlIgnore]
        public virtual object[] AfterScenarioParameters { get; set; }
    }
}
