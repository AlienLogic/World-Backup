using System;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Text;
using System.Xml;

namespace World_Backup
{
	class Settings : SettingsProvider
	{
		public override void Initialize(string name, NameValueCollection config)
		{
			base.Initialize(this.ApplicationName, config);
		}

		public override string ApplicationName
		{
			get => throw new NotImplementedException();
			set => throw new NotImplementedException();
		}

		public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context, SettingsPropertyCollection collection)
		{
			SettingsPropertyValueCollection values = new SettingsPropertyValueCollection();
			foreach (SettingsProperty property in collection)
			{
				SettingsPropertyValue value = new SettingsPropertyValue(property);
				value.IsDirty = false;
				values.Add(value);
			}

			if (!File.Exists(this.GetSavingPath))
				return values;

			using (XmlTextReader tr = new XmlTextReader(this.GetSavingPath))
			{
				try
				{
					tr.ReadStartElement("ID3renamer");
					foreach (SettingsPropertyValue value in values)
					{
						if (IsUserScoped(value.Property))
						{
							try
							{
								tr.ReadStartElement(value.Name);
								value.SerializedValue = tr.ReadContentAsObject();
								tr.ReadEndElement();
							}
							catch (XmlException)
							{ /* ugly */ }
						}
					}
					tr.ReadEndElement();
				}
				catch (XmlException)
				{ /* ugly */ }
			}
			return values;
		}

		public override void SetPropertyValues(SettingsContext context, SettingsPropertyValueCollection collection)
		{
			using (XmlTextWriter tw = new XmlTextWriter(this.GetSavingPath, Encoding.Unicode))
			{
				tw.WriteStartDocument();
				tw.WriteStartElement("ID3renamer");
				foreach (SettingsPropertyValue propertyValue in collection)
				{
					if (IsUserScoped(propertyValue.Property))
					{
						tw.WriteStartElement(propertyValue.Name);
						tw.WriteValue(propertyValue.SerializedValue);
						tw.WriteEndElement();
					}
				}
				tw.WriteEndElement();
				tw.WriteEndDocument();
			}
		}

		private bool IsUserScoped(SettingsProperty property)
		{
			return property.Attributes.ContainsKey(typeof(UserScopedSettingAttribute));
		}

		private string GetSavingPath
		{
			get
			{
				return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Path.DirectorySeparatorChar + "ID3 renamer" + Path.DirectorySeparatorChar + "user.config";
			}
		}
	}
}
