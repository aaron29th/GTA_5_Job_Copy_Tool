using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GTA_5_json_editor;
using PS3Lib;

namespace GTA_5_Job_Copy_Tool
{
	public partial class mainForm : Form
	{
		public static PS3API PS3 = new PS3API();

		public mainForm()
		{
			InitializeComponent();
			RPC.PS3 = PS3;
			Output.outputTextbox = outputTextbox;

			Output.write("Version: {0}", Variables.versionStr);

			Functions.checkUpdates();
		}

		private void connectBtn_Click(object sender, EventArgs e)
		{
			PS3.ChangeAPI(tmapiRadio.Checked ? SelectAPI.TargetManager : SelectAPI.ControlConsole);

			if (PS3.ConnectTarget()) 
				Output.write("Connect to " + PS3.GetConsoleName());
			else 
				Output.write("Failed to connect");
		}

		private void attachBtn_Click(object sender, EventArgs e)
		{
			PS3.ChangeAPI(tmapiRadio.Checked ? SelectAPI.TargetManager : SelectAPI.ControlConsole);

			if (!PS3.ConnectTarget())
			{
				Output.write("Not connected :(");
				return;
			}

			if (!PS3.AttachProcess())
			{
				Output.write("Failed to attach");
				return;
			}

			Output.write("Attached");
			RPC.Enable();
			Output.write("RPC enabled");
		}

		private void copyBtn_Click(object sender, EventArgs e)
		{
			Functions.copyJobs(contentIdsTextbox.Lines);
		}

		private void outputTextbox_LinkClicked(object sender, LinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start(e.LinkText);
		}
	}
}
