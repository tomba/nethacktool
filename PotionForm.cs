using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.IO.IsolatedStorage;

namespace NetHackTool
{
	public partial class PotionForm : UserControl
	{
		ListBox m_listBox;

		public PotionForm()
		{
			InitializeComponent();

			potionListView.Items.Clear();

			foreach (string color in PotionContainer.PotionColors)
			{
				ListViewItem item = new ListViewItem(color);
				ListViewItem.ListViewSubItem subItem;
				subItem = item.SubItems.Add(""); subItem.Name = "spell";
				subItem = item.SubItems.Add(""); subItem.Name = "price";
				subItem = item.SubItems.Add(""); subItem.Name = "alt";

				potionListView.Items.Add(item);
			}

			m_listBox = new ListBox();
			m_listBox.Parent = potionListView;
			m_listBox.Hide();
			m_listBox.Leave += new EventHandler(m_comboBox_Leave);
			m_listBox.MouseClick += new MouseEventHandler(m_comboBox_MouseClick);
			m_listBox.KeyPress += new KeyPressEventHandler(m_listBox_KeyPress);
			potionListView.Columns[0].Width = -1;
			potionListView.Columns[3].Width = -2;

			UpdateAlternatives();
		}

		public void Clear()
		{
			foreach (ListViewItem item in potionListView.Items)
			{
				item.SubItems["spell"].Text = "";
				item.SubItems["price"].Text = "";
			}

			UpdateAlternatives();
		}

		public void Store(Document doc)
		{
			doc.potions = new Document.Potion[potionListView.Items.Count];
			for (int i = 0; i < potionListView.Items.Count; i++)
			{
				ListViewItem item = potionListView.Items[i];
				doc.potions[i] = new Document.Potion();
				doc.potions[i].color = item.Text;
				doc.potions[i].spell = item.SubItems["spell"].Text;
				doc.potions[i].price = item.SubItems["price"].Text;
			}
		}

		public void Restore(Document doc)
		{
			if (doc.potions == null)
			{
				Clear();
				return;
			}

			for (int i = 0; i < doc.potions.Length; i++)
			{
				Document.Potion save = doc.potions[i];
				ListViewItem item = potionListView.FindItemWithText(save.color);
				item.SubItems["spell"].Text = save.spell;
				item.SubItems["price"].Text = save.price;
			}

			UpdateAlternatives();
		}

		void m_comboBox_MouseClick(object sender, MouseEventArgs e)
		{
			for (int i = 0; i < m_listBox.Items.Count; i++)
			{
				if (m_listBox.GetItemRectangle(i).Contains(e.Location))
				{
					ListViewItem.ListViewSubItem subItem =
						(ListViewItem.ListViewSubItem)m_listBox.Tag;
					subItem.Text = m_listBox.Text;
					m_listBox.Hide();
					UpdateAlternatives();
					break;
				}
			}

		}

		void m_comboBox_Leave(object sender, EventArgs e)
		{
			m_listBox.Hide();
		}

		void m_listBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\n' || e.KeyChar == '\r')
			{
				ListViewItem.ListViewSubItem subItem =
					(ListViewItem.ListViewSubItem)m_listBox.Tag;
				subItem.Text = m_listBox.Text;
				m_listBox.Hide();
				UpdateAlternatives();
			}
		}

		void UpdateAlternatives()
		{
			List<string> spells = new List<string>();
			foreach (Potion p in PotionContainer.Potions)
				spells.Add(p.Spell);

			foreach (ListViewItem item in potionListView.Items)
			{
				spells.Remove(item.SubItems["spell"].Text);
			}

			foreach (ListViewItem item in potionListView.Items)
			{
				if (item.SubItems["spell"].Text.Length > 0)
				{
					item.SubItems["alt"].Text = "";
					continue;
				}

				if (item.SubItems["price"].Text.Length == 0)
				{
					item.SubItems["alt"].Text = string.Join("/", spells.ToArray());
					continue;
				}

				List<string> filteredSpells = new List<string>();
				foreach (string spell in spells)
				{
					if (PotionContainer.Potions[spell].Price.ToString() == item.SubItems["price"].Text)
						filteredSpells.Add(spell);
				}
				item.SubItems["alt"].Text = string.Join("/", filteredSpells.ToArray());

			}
		}


		private void potionListView_MouseUp(object sender, MouseEventArgs e)
		{
			ListViewItem item = potionListView.GetItemAt(e.X, e.Y);

			if (item == null)
				return;

			int subItemNum = -1;
			ListViewItem.ListViewSubItem subItem = null;

			for (int i = 1; i < item.SubItems.Count; i++)
			{
				if (item.SubItems[i].Bounds.Contains(e.Location))
				{
					subItem = item.SubItems[i];
					subItemNum = i;
					break;
				}
			}

			if (subItem == null)
				return;

			Rectangle r = subItem.Bounds;

			m_listBox.Location = r.Location;
			m_listBox.Width = r.Width + 20;
			m_listBox.Tag = subItem;
			m_listBox.Items.Clear();

			if (subItem.Name == "spell")
			{
				m_listBox.Items.Add("");
				m_listBox.Items.AddRange(GetAvailablePotions(subItem.Text));
				m_listBox.SelectedItem = subItem.Text;
			}
			else if (subItem.Name == "price")
			{
				m_listBox.Items.Add("");
				m_listBox.Items.AddRange(PotionContainer.PotionPrices);
				m_listBox.SelectedItem = subItem.Text;
			}
			else
			{
				return;
			}

			m_listBox.Height = m_listBox.PreferredHeight;
			if (m_listBox.Bounds.Bottom > m_listBox.Parent.Bottom)
			{
				m_listBox.Top -= m_listBox.Bounds.Bottom - m_listBox.Parent.ClientRectangle.Bottom;
				if (m_listBox.Top <= 0)
					m_listBox.Top = 1;
				if (m_listBox.Bounds.Bottom > m_listBox.Parent.Bottom)
					m_listBox.Height -= m_listBox.Bounds.Bottom - m_listBox.Parent.ClientRectangle.Bottom;
			}


			m_listBox.Visible = true;
			m_listBox.BringToFront();
			m_listBox.Focus();
		}

		string[] GetAvailablePotions(string skipSpell)
		{
			List<string> spells = new List<string>();
			foreach (Potion p in PotionContainer.Potions)
				spells.Add(p.Spell);

			foreach (ListViewItem item in potionListView.Items)
			{
				if (item.SubItems["spell"].Text != skipSpell)
					spells.Remove(item.SubItems["spell"].Text);
			}

			return spells.ToArray();
		}
	}
}
