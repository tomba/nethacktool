using System;
using System.Collections.Generic;
using System.Text;

namespace NetHackTool
{
	public class Scroll
	{
		int m_price;
		string m_spell;

		public int Price
		{
			get { return m_price; }
		}

		public string Spell
		{
			get { return m_spell; }
		}

		public Scroll(string spell, int price)
		{
			m_spell = spell;
			m_price = price;
		}
	}

	public class ScrollContainer : List<Scroll>
	{
		public static readonly ScrollContainer Scrolls;
		public static readonly string[] ScrollTexts =
			new string[] {
				"ZELGO MER", "JUYED AWK YACC", "NR 9", "XIXAXA XOXAXA XUXAXA", "PRATYAVAYAH", 
				"DAIYEN FOOELS", "LEP GEX VEN ZEA", "PRIRUTSENIE", "ELBIB YLOH", "VERR YED HORRE", 
				"VENZAR BORGAVVE", "THARR", "YUM YUM", "KERNOD WEL", "ELAM EBOW", "DUAM XNAHT", 
				"ANDOVA BEGARIN", "KIRJE", "VE FORBRYDERNE", "HACKEM MUCHE", "VELOX NEB", "FOOBIE BLETCH", 
				"TEMOV", "GARVEN DEH", "READ ME" };

		public static readonly string[] ScrollPrices;

		static ScrollContainer()
		{
			Scrolls = new ScrollContainer();
			Scrolls.Add("identify", 20);
			Scrolls.Add("light", 50);
			Scrolls.Add("enchant weapon", 60);
			Scrolls.Add("enchant armor", 80);
			Scrolls.Add("remove curse", 80);
			Scrolls.Add("confuse monster", 100);
			Scrolls.Add("destroy armor", 100);
			Scrolls.Add("fire", 100);
			Scrolls.Add("food detection", 100);
			Scrolls.Add("gold detection", 100);
			Scrolls.Add("magic mapping", 100);
			Scrolls.Add("scare monster", 100);
			Scrolls.Add("teleportation", 100);
			Scrolls.Add("amnesia", 200);
			Scrolls.Add("create monster", 200);
			Scrolls.Add("earth", 200);
			Scrolls.Add("taming", 200);
			Scrolls.Add("charging", 300);
			Scrolls.Add("genocide", 300);
			Scrolls.Add("punishment", 300);
			Scrolls.Add("stinking cloud", 300);

			Scrolls.Sort(delegate(Scroll p1, Scroll p2) { return p1.Spell.CompareTo(p2.Spell); });
			List<string> textList = new List<string>(ScrollTexts);
			textList.Sort();
			ScrollTexts = textList.ToArray();

			List<int> priceList = new List<int>();
			foreach (Scroll scroll in Scrolls)
			{
				if (priceList.Contains(scroll.Price))
					continue;
				priceList.Add(scroll.Price);
			}
			priceList.Sort();
			ScrollPrices = priceList.ConvertAll<string>(
				delegate(int i) { return i.ToString(); }).ToArray();

			if (Scrolls.Count > ScrollTexts.Length)
				throw new Exception("Scroll count is not the same as scroll color count.");
		}

		void Add(string spell, int price)
		{
			this.Add(new Scroll(spell, price));
		}

		public Scroll this[string spell]
		{
			get
			{
				foreach (Scroll p in this)
					if (p.Spell == spell)
						return p;

				throw new ArgumentOutOfRangeException();
			}
		}
	}

}
