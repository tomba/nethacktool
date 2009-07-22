using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace NetHackTool
{
	public class Document
	{
		public static Document CurrentDocument;

		[XmlIgnore]
		public string DocumentFile = "";

		public Document()
		{
		}

		public class Potion
		{
			public string color;
			public string spell;
			public string price;
		}

		public Potion[] potions;

		public class Scroll
		{
			public string text;
			public string spell;
			public string price;
		}

		public Scroll[] scrolls;

		public void Save()
		{
			XmlSerializer serializer = new XmlSerializer(typeof(Document));
			StreamWriter writer = new StreamWriter(DocumentFile);
			serializer.Serialize(writer, this);
			writer.Close();
		}

		public void Restore()
		{
			XmlSerializer serializer = new XmlSerializer(typeof(Document));
			StreamReader reader = new StreamReader(DocumentFile);
			Document doc = (Document)serializer.Deserialize(reader);
			potions = doc.potions;
			scrolls = doc.scrolls;
			reader.Close();
		}

	}
}
