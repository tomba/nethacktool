using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NetHackTool
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Document.CurrentDocument = new Document();
			Document.CurrentDocument.DocumentFile = Properties.Settings.Default.LastFile;
			if (Document.CurrentDocument.DocumentFile == null)
				Document.CurrentDocument.DocumentFile = "";

			if (Document.CurrentDocument.DocumentFile.Length > 0)
			{
				try
				{
					Document.CurrentDocument.Restore();
				}
				catch (Exception)
				{
					MessageBox.Show("Failed to load " + Document.CurrentDocument.DocumentFile,
						"Failed to load saved data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					Document.CurrentDocument.DocumentFile = "";
				}
			}

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			MainForm form = new MainForm();
			Application.Run(form);

			if(Document.CurrentDocument.DocumentFile.Length > 0)
				Document.CurrentDocument.Save();
			Properties.Settings.Default.LastFile = Document.CurrentDocument.DocumentFile;
			Properties.Settings.Default.Save();
		}
	}
}