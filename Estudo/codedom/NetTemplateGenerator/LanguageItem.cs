using System;

namespace NetTemplateGenerator {
	/// <summary>
	/// Summary description for LanguageItem.
	/// </summary>
	public class LanguageItem {
		public LanguageItem(Language ID, string Name) {
			LanguageID = ID;
			LanguageName = Name;
		}

		public Language LanguageID;
		public string LanguageName;

		public override string ToString() {
			return LanguageName;
		}
	}
}
