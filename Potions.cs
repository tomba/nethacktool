using System;
using System.Collections.Generic;
using System.Text;

namespace NetHackTool
{
	public class Potion
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

		public Potion(string spell, int price)
		{
			m_spell = spell;
			m_price = price;
		}
	}

	public class PotionContainer : List<Potion>
	{
		public static readonly PotionContainer Potions;
		public static readonly string[] PotionColors =
			new string[] {
				"ruby", "pink", "orange", "yellow", "emerald", "dark green", "cyan", "sky blue", "brilliant blue",
				"magenta", "purple-red", "puce", "milky", "swirly", "bubbly", "smoky", "cloudy", "effervescent", "black",
				"golden", "brown", "fizzy", "dark", "white", "murky"
			};
		public static readonly string[] PotionPrices;

		static PotionContainer()
		{
			Potions = new PotionContainer();
			Potions.Add("booze", 50);
			Potions.Add("fruit juice", 50);
			Potions.Add("see invisible", 50);
			Potions.Add("sickness", 50);
			Potions.Add("confusion", 100);
			Potions.Add("extra healing", 100);
			Potions.Add("hallucination", 100);
			Potions.Add("healing", 100);
			Potions.Add("restore ability", 100);
			Potions.Add("sleeping", 100);
			Potions.Add("blindness", 150);
			Potions.Add("gain energy", 150);
			Potions.Add("invisibility", 150);
			Potions.Add("monster detection", 150);
			Potions.Add("object detection", 150);
			Potions.Add("enlightenment", 200);
			Potions.Add("full healing", 200);
			Potions.Add("levitation", 200);
			Potions.Add("polymorph", 200);
			Potions.Add("speed", 200);
			Potions.Add("acid", 250);
			Potions.Add("oil", 250);
			Potions.Add("gain ability", 300);
			Potions.Add("gain level", 300);
			Potions.Add("paralysis", 300);

			Potions.Sort(delegate(Potion p1, Potion p2) { return p1.Spell.CompareTo(p2.Spell); });
			List<string> colorList = new List<string>(PotionColors);
			colorList.Sort();
			PotionColors = colorList.ToArray();

			List<int> priceList = new List<int>();
			foreach (Potion potion in Potions)
			{
				if (priceList.Contains(potion.Price))
					continue;
				priceList.Add(potion.Price);
			}
			priceList.Sort();
			PotionPrices = priceList.ConvertAll<string>(
				delegate(int i) { return i.ToString(); }).ToArray();

			if (Potions.Count > PotionColors.Length)
				throw new Exception("Potion count is not the same as potion color count.");
		}

		void Add(string spell, int price)
		{
			base.Add(new Potion(spell, price));
		}

		public Potion this[string spell]
		{
			get
			{
				foreach (Potion p in this)
					if (p.Spell == spell)
						return p;

				throw new ArgumentOutOfRangeException();
			}
		}
	}

}
