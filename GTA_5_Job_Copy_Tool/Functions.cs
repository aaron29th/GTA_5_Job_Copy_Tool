using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GTA_5_json_editor;
using Newtonsoft.Json;

namespace GTA_5_Job_Copy_Tool
{
	public static class Functions
	{
		public static List<string> copyJobs(string[] contentIds)
		{
			List<string> successfullyCopied = new List<string>();
			List<string> failed = new List<string>();

			foreach (string id in contentIds)
			{
				if (copyJob(id))
					successfullyCopied.Add(id);
				else
					failed.Add(id);
				Thread.Sleep(1400);
			}

			foreach (string id in failed)
			{
				if (copyJob(id, true))
					successfullyCopied.Add(id);
				Thread.Sleep(1600);
			}

			return successfullyCopied;
		}

		public static bool copyJob(string contentId, bool retry = false)
		{
			if (String.IsNullOrWhiteSpace(contentId))
				return false;

			bool result = RPC.Call(Natives.NETWORK_COPY, contentId, "gta5mission") != 0;
			Output.write("Copy job {0}| {1} | {2}", retry ? "(retry) " : "", contentId, result ? "Success" : "Failed");
			return result;
		}

        public static void checkUpdates()
        {
            // Check if server is online
            if (new Ping().Send(Variables.versionCheckHost).Status != IPStatus.Success)
            {
				Output.write("Failed to check for updates");
				return;
            }

            try
            {
	            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://" + Variables.versionCheckHost + Variables.versionCheckPath);
	            Request.UserAgent = $"GTA5_Job_Copy_Tool_{Variables.version}";

	            var res = Request.GetResponse().GetResponseStream();
	            using (StreamReader sr = new StreamReader(res))
	            {
		            Dictionary<string, object> jsonData = JsonConvert.DeserializeObject<Dictionary<string, object>>(sr.ReadToEnd());

		            if (jsonData.ContainsKey("version"))
		            {
			            Variables.lastestVersion = Convert.ToInt32(jsonData["version"]);
		            }

		            if (jsonData.ContainsKey("lastestDownload"))
		            {
			            Variables.lastestDownloadLink = Convert.ToString(jsonData["lastestDownload"]);
		            }

		            if (jsonData.ContainsKey("startUpMessage") && jsonData["startUpMessage"] != null)
		            {
			            Output.write(jsonData["startUpMessage"].ToString());
		            }
	            }
            }
            catch
            {
	            Output.write("Failed to check for updates");
            }

            if (Variables.version < Variables.lastestVersion)
            {
	            Output.write("There is a new version available" + Environment.NewLine + "Go to: " + Variables.lastestDownloadLink + " to download the lastest version");
            }
        }

    }
}
