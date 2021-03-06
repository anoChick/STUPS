﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/19/2012
 * Time: 2:54 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using TestStructure;
    
    /// <summary>
    /// Description of TestResultDetail.
    /// </summary>
    [DefaultProperty("Name")]
    public class TestResultDetail : ITestResultDetail
    {
        public TestResultDetail()
        {
            Timestamp = DateTime.Now;
            DetailType = TestResultDetailTypes.Comment;
            ExternalData = new List<string>();
            UniqueId = Guid.NewGuid();
        }
        
        [XmlAttribute]
        public virtual Guid UniqueId { get; set; }
        [XmlAttribute]
        public virtual DateTime Timestamp { get; set; }
        [XmlAttribute]
        public virtual TestResultDetailTypes DetailType { get; set; }
        [XmlAttribute]
        public virtual string TextDetail { get; set; }
        [XmlIgnore]
        // 20160116
        // public virtual ErrorRecord ErrorDetail { get; set; }
        public virtual Exception ErrorDetail { get; set; }
        [XmlAttribute]
        public virtual string ScreenshotDetail { get; set; }
        [XmlAttribute]
        public virtual string LogDetail { get; set; }
        [XmlIgnore]
        public virtual List<string> ExternalData { get; set; }
        
        [XmlAttribute]
        public virtual string Name
        {
            get {
                if (!string.IsNullOrEmpty(TextDetail))
                    return TextDetail;
                if (ErrorDetail != null)
                    // 20160116
                    // return ErrorDetail.Exception.Message;
                    return ErrorDetail.Message;
                return !string.IsNullOrEmpty(ScreenshotDetail) ? ScreenshotDetail : string.Empty;
            }
        }
        public virtual void AddTestResultDetail(
           TestResultDetailTypes detailType,
           string detail)
        {
            if (TmxHelper.TestCaseStarted == DateTime.MinValue) {
                TmxHelper.TestCaseStarted = DateTime.Now;
            }
            DetailType = detailType;

            switch (detailType) {
                case TestResultDetailTypes.Screenshot:
                    ScreenshotDetail = detail;
                    break;
//                case TestResultDetailTypes.ErrorRecord:
//                    
//                    break;
                case TestResultDetailTypes.Comment:
                    TextDetail = detail;
                    break;
                case TestResultDetailTypes.Log:
                    LogDetail = detail;
                    break;
                case TestResultDetailTypes.ExternalData:
                    ExternalData.Add(detail);
                    break;
                default:
                    throw new Exception("Invalid value for TestResultDetailTypes");
            }
        }
        public virtual void AddTestResultDetail(
           TestResultDetailTypes detailType,
           // 20160116
           // ErrorRecord detail)
           Exception detail)
        {
            if (TmxHelper.TestCaseStarted == DateTime.MinValue)
                TmxHelper.TestCaseStarted = DateTime.Now;
            DetailType = detailType;
            if (detailType == TestResultDetailTypes.ErrorRecord)
                ErrorDetail = detail;
        }
        public virtual object GetDetail()
        {
            // 20160116
            // return null != ErrorDetail ? ErrorDetail.Exception.Message : ScreenshotDetail ?? TextDetail ?? null;
            return null != ErrorDetail ? ErrorDetail.Message : ScreenshotDetail ?? TextDetail ?? null;
        }
        
        [XmlAttribute]
        // 20150805
        // public virtual TestResultStatuses DetailStatus { get; set; }
        public virtual TestStatuses DetailStatus { get; set; }
    }
}
