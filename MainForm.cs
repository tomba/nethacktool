using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NetHackTool
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();

			Restore();
		}

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			Save();
		}

		void Save()
		{
			potions.Store(Document.CurrentDocument);
			scrolls.Store(Document.CurrentDocument);
		}

		void Restore()
		{
			SetTitle();
			potions.Restore(Document.CurrentDocument);
			scrolls.Restore(Document.CurrentDocument);
		}

		void SetTitle()
		{
			string title = System.IO.Path.GetFileName(Document.CurrentDocument.DocumentFile);

			if (title == "")
				title = "Untitled";
			this.Text = title + " - NetHackTool";
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.CheckFileExists = true;
			dlg.DefaultExt = "xml";
			dlg.Filter = "Xml files (*.xml)|*.xml";
			dlg.Multiselect = false;
			DialogResult res = dlg.ShowDialog(this);
			if (res != DialogResult.OK)
				return;

			Document doc = new Document();
			doc.DocumentFile = dlg.FileName;
			doc.Restore();

			Document.CurrentDocument = doc;

			Restore();
		}

		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Document.CurrentDocument = new Document();
			Restore();
		}

		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.DefaultExt = "xml";
			dlg.Filter = "Xml files (*.xml)|*.xml";
			DialogResult res = dlg.ShowDialog(this);
			if (res != DialogResult.OK)
				return;

			Save();

			Document.CurrentDocument.DocumentFile = dlg.FileName;

			Document.CurrentDocument.Save();

			SetTitle();
		}

		private void quitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}