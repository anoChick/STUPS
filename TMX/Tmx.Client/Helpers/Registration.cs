﻿/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 7/18/2014
 * Time: 11:37 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Client
{
    using System;
    using RestSharp;
	using Tmx.Interfaces;
	using Tmx.Server;
    
    /// <summary>
    /// Description of Registration.
    /// </summary>
    public class Registration
    {
        public int SendRegistrationInfoAndGetClientId()
        {
			var client = new RestClient(ClientSettings.ServerUrl);
			var request = new RestRequest(UrnList.TestClients_Root + UrnList.TestClients_Clients, Method.POST);
			request.AddBody(
			    new TestClientInformation {
			        Hostname = Environment.MachineName,
			        Username = Environment.UserName,
			        UserDomainName = Environment.UserDomainName,
			        IsInteractive = Environment.UserInteractive,
			        // EnvironmentVersion = Environment.Version.Major + "." + Environment.Version.MajorRevision + "." + Environment.Version.Minor + "." + Environment.Version.MinorRevision + "." + Environment.Version.Build,
			        Fqdn = string.Empty,
			        OsVersion = Environment.OSVersion.VersionString,
			        UptimeSeconds = Environment.TickCount / 1000
			    });
			
			var registrationResponse = client.Execute<TestClientInformation>(request);
			
//			Console.WriteLine(registrationResponse);
//			Console.WriteLine(registrationResponse.Content);
//			Console.WriteLine(registrationResponse.ContentType);
//			Console.WriteLine(registrationResponse.ResponseStatus);
//			Console.WriteLine(registrationResponse.ResponseUri);
//			Console.WriteLine(registrationResponse.StatusCode);
//			Console.WriteLine(registrationResponse.Data.Id);
//			return 111;
			return registrationResponse.Data.Id;
        }
    }
}
