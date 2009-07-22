namespace NetHackTool
{
	partial class ScrollForm
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.scrollListView = new System.Windows.Forms.ListView();
			this.Color = new System.Windows.Forms.ColumnHeader();
			this.Spell = new System.Windows.Forms.ColumnHeader();
			this.Price = new System.Windows.Forms.ColumnHeader();
			this.Alternatives = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// scrollListView
			// 
			this.scrollListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Color,
            this.Spell,
            this.Price,
            this.Alternatives});
			this.scrollListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.scrollListView.FullRowSelect = true;
			this.scrollListView.GridLines = true;
			this.scrollListView.Location = new System.Drawing.Point(0, 0);
			this.scrollListView.MultiSelect = false;
			this.scrollListView.Name = "scrollListView";
			this.scrollListView.Size = new System.Drawing.Size(654, 387);
			this.scrollListView.TabIndex = 1;
			this.scrollListView.UseCompatibleStateImageBehavior = false;
			this.scrollListView.View = System.Windows.Forms.View.Details;
			this.scrollListView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.scrollListView_MouseUp);
			// 
			// Color
			// 
			this.Color.Text = "Text";
			this.Color.Width = 75;
			// 
			// Spell
			// 
			this.Spell.Text = "Spell";
			this.Spell.Width = 78;
			// 
			// Price
			// 
			this.Price.Text = "Price";
			this.Price.Width = 81;
			// 
			// Alternatives
			// 
			this.Alternatives.Text = "Alternatives";
			this.Alternatives.Width = 188;
			// 
			// ScrollForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.scrollListView);
			this.Name = "ScrollForm";
			this.Size = new System.Drawing.Size(654, 387);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView scrollListView;
		private System.Windows.Forms.ColumnHeader Color;
		private System.Windows.Forms.ColumnHeader Spell;
		private System.Windows.Forms.ColumnHeader Price;
		private System.Windows.Forms.ColumnHeader Alternatives;

	}
}
