namespace NetHackTool
{
	partial class PotionForm
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
			this.potionListView = new System.Windows.Forms.ListView();
			this.Color = new System.Windows.Forms.ColumnHeader();
			this.Spell = new System.Windows.Forms.ColumnHeader();
			this.Price = new System.Windows.Forms.ColumnHeader();
			this.Alternatives = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// potionListView
			// 
			this.potionListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Color,
            this.Spell,
            this.Price,
            this.Alternatives});
			this.potionListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.potionListView.FullRowSelect = true;
			this.potionListView.GridLines = true;
			this.potionListView.Location = new System.Drawing.Point(0, 0);
			this.potionListView.MultiSelect = false;
			this.potionListView.Name = "potionListView";
			this.potionListView.Size = new System.Drawing.Size(654, 387);
			this.potionListView.TabIndex = 1;
			this.potionListView.UseCompatibleStateImageBehavior = false;
			this.potionListView.View = System.Windows.Forms.View.Details;
			this.potionListView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.potionListView_MouseUp);
			// 
			// Color
			// 
			this.Color.Text = "Color";
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
			// Potions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.potionListView);
			this.Name = "Potions";
			this.Size = new System.Drawing.Size(654, 387);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView potionListView;
		private System.Windows.Forms.ColumnHeader Color;
		private System.Windows.Forms.ColumnHeader Spell;
		private System.Windows.Forms.ColumnHeader Price;
		private System.Windows.Forms.ColumnHeader Alternatives;

	}
}
