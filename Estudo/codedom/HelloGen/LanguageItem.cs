using System;

namespace HelloGen
{
	/// <summary>
	/// Summary description for LanguageItem.
	/// </summary>
	public class LanguageItem
	{
		public Language LanguageID;
		public string LanguageName;
		public int LanguagePreviewID;
		public string SourceExtension;
		public string ExeSuffix;
		
		public LanguageItem(Language ID, string Name, int previewID, string Extension, string Suffix)
		{
			LanguageID = ID;
			LanguageName = Name;
			LanguagePreviewID = previewID;
			SourceExtension = Extension;
			ExeSuffix = Suffix;
		}

		public override string ToString() {
			return LanguageName;
		}
	}
}
