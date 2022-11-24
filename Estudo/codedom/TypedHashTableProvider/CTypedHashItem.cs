using System;
using System.ComponentModel;

namespace TypedHashtable {
	/// <summary>
	/// Summary description for CTypedHashItem.
	/// </summary>
	
	public class CTypedHashItem {
		public int IssueID {
			get {
				return IssueID;
			}
			set {
				IssueID = value;
			}

		}
		public CTypedHashItem() {
			//
			// TODO: Add constructor logic here
			//
		}
		/// <Summary>
		/// This Method is Obsolete.  Cannot call object overrides of a typed Hashtable.
		/// </Summary>
		public object @this(object key) {
			return new object();
		}
	}
}
