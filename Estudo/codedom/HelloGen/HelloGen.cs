using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;

using System.Reflection;

using System.IO;
using System.CodeDom;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using Microsoft.VisualBasic;
using Microsoft.JScript;
//using Microsoft.VJSharp;



namespace HelloGen
{
	public enum Language : int {
		CSharp		= 0,
		VB			= 1,
		JScript		= 2,
		JSharp		= 3,
		Mondrian	= 4,
		Cobol		= 5,
		Eiffel		= 6
	}

	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class HelloGen : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TabControl tcLanguages;
		private System.Windows.Forms.TabPage tpCSharp;
		private System.Windows.Forms.TabPage tpVBNET;
		private System.Windows.Forms.TabPage tpJScript;
		private System.Windows.Forms.TabPage tpJSharp;
		private System.Windows.Forms.TextBox txtCSharp;
		private System.Windows.Forms.Button btnPreview;
		private System.Windows.Forms.TextBox txtJSharp;
		private System.Windows.Forms.TextBox txtJScript;
		private System.Windows.Forms.TextBox txtVB;
		private System.Windows.Forms.TextBox txtMondiran;
		private System.Windows.Forms.Button btnCreate;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		
		private System.Windows.Forms.TabPage tpMondrian;
		private System.Windows.Forms.TextBox txtCobol;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TabPage tpGeneratorOps;
		private System.Windows.Forms.TabPage tpResults;
		private System.Windows.Forms.TextBox txtResults;
		private System.Windows.Forms.CheckBox chkBlankLines;
		private System.Windows.Forms.CheckBox chkElseOnClose;
		private System.Windows.Forms.TextBox txtIndentString;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox cboBracingStyle;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tpAppOut;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtBinaryDirectory;
		private System.Windows.Forms.TextBox txtSourceDirectory;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TabPage tpCompilerParams;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtCompilerOptions;
		private System.Windows.Forms.TextBox txtMainClass;
		private System.Windows.Forms.TextBox txtOutAssembly;
		private System.Windows.Forms.CheckBox chkIncludeDebug;
		private System.Windows.Forms.CheckBox chkTreatWarningsAsErrors;
		private System.Windows.Forms.RadioButton rbGenMemory;
		private System.Windows.Forms.RadioButton rbGenExe;
		private System.Windows.Forms.TabControl tcOptions;
		private System.Windows.Forms.Button btnDone;
		

		// User created private members
		private Hashtable PreviewText;
		private const string GEN_APP_NAME = "HelloApp";
		private const string DEF_DIR_NAME = @"C:\CodeDOM\AppOutput\";
		private const string PT_PREFIX = "Language:";


		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cboTargetLanguage;
		private System.Windows.Forms.TabPage tpCobol;
		private System.Windows.Forms.TabPage tpEiffel;
		private System.Windows.Forms.TextBox txtEiffel;
		
		

		public HelloGen()
		{
			// Required for Windows Form Designer support
			InitializeComponent();

			PreviewText = new Hashtable();
			PreviewText.Add(PT_PREFIX + ((int)Language.CSharp).ToString(), txtCSharp);
			PreviewText.Add(PT_PREFIX + ((int)Language.VB).ToString(), txtVB);
			PreviewText.Add(PT_PREFIX + ((int)Language.JScript).ToString(), txtJScript);
			
			cboTargetLanguage.Items.Add(new LanguageItem(Language.CSharp, "C#", 0, ".cs", "_CSharp"));
			cboTargetLanguage.Items.Add(new LanguageItem(Language.VB, "Visual Basic.NET", 1, ".vb", "_VisualBasic"));
			cboTargetLanguage.Items.Add(new LanguageItem(Language.JScript, "JScript", 2, ".js", "_JScript"));

			
			/*
			 * INFO: To add new languages:
			 * 1)  Add the language to the Language enumeration 
			 * 2)  Modify the two lines below to reflect the properties of that language. 
			 * 3)  Add a case statement for the language int the GetLanguageCompiler and GetLanguageGenerator Functions 
			 * 4)  Add a tab page and TextBox to the UI
			 */

			//TODO: Uncomment to enable JSharp
			//PreviewText.Add(PT_PREFIX + ((int)Language.JSharp).ToString(), txtJSharp);

			//TODO: Uncomment to enable JSharp
			//cboTargetLanguage.Items.Add(new LanguageItem(Language.JSharp, "J#", 3, ".jsl", "_JSharp"));

			cboTargetLanguage.SelectedIndex = 0;
			SetOutputStrings();
			txtIndentString.Text = "    ";

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tcLanguages = new System.Windows.Forms.TabControl();
			this.tpCSharp = new System.Windows.Forms.TabPage();
			this.txtCSharp = new System.Windows.Forms.TextBox();
			this.tpVBNET = new System.Windows.Forms.TabPage();
			this.txtVB = new System.Windows.Forms.TextBox();
			this.tpJScript = new System.Windows.Forms.TabPage();
			this.txtJScript = new System.Windows.Forms.TextBox();
			this.tpJSharp = new System.Windows.Forms.TabPage();
			this.txtJSharp = new System.Windows.Forms.TextBox();
			this.tpMondrian = new System.Windows.Forms.TabPage();
			this.txtMondiran = new System.Windows.Forms.TextBox();
			this.tpCobol = new System.Windows.Forms.TabPage();
			this.txtCobol = new System.Windows.Forms.TextBox();
			this.tpEiffel = new System.Windows.Forms.TabPage();
			this.txtEiffel = new System.Windows.Forms.TextBox();
			this.btnPreview = new System.Windows.Forms.Button();
			this.btnCreate = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.tcOptions = new System.Windows.Forms.TabControl();
			this.tpAppOut = new System.Windows.Forms.TabPage();
			this.cboTargetLanguage = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtBinaryDirectory = new System.Windows.Forms.TextBox();
			this.txtSourceDirectory = new System.Windows.Forms.TextBox();
			this.tpGeneratorOps = new System.Windows.Forms.TabPage();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtIndentString = new System.Windows.Forms.TextBox();
			this.cboBracingStyle = new System.Windows.Forms.ComboBox();
			this.chkElseOnClose = new System.Windows.Forms.CheckBox();
			this.chkBlankLines = new System.Windows.Forms.CheckBox();
			this.tpCompilerParams = new System.Windows.Forms.TabPage();
			this.rbGenMemory = new System.Windows.Forms.RadioButton();
			this.rbGenExe = new System.Windows.Forms.RadioButton();
			this.txtOutAssembly = new System.Windows.Forms.TextBox();
			this.txtMainClass = new System.Windows.Forms.TextBox();
			this.txtCompilerOptions = new System.Windows.Forms.TextBox();
			this.chkTreatWarningsAsErrors = new System.Windows.Forms.CheckBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.chkIncludeDebug = new System.Windows.Forms.CheckBox();
			this.label7 = new System.Windows.Forms.Label();
			this.tpResults = new System.Windows.Forms.TabPage();
			this.txtResults = new System.Windows.Forms.TextBox();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.btnDone = new System.Windows.Forms.Button();
			this.tcLanguages.SuspendLayout();
			this.tpCSharp.SuspendLayout();
			this.tpVBNET.SuspendLayout();
			this.tpJScript.SuspendLayout();
			this.tpJSharp.SuspendLayout();
			this.tpMondrian.SuspendLayout();
			this.tpCobol.SuspendLayout();
			this.tpEiffel.SuspendLayout();
			this.tcOptions.SuspendLayout();
			this.tpAppOut.SuspendLayout();
			this.tpGeneratorOps.SuspendLayout();
			this.tpCompilerParams.SuspendLayout();
			this.tpResults.SuspendLayout();
			this.SuspendLayout();
			// 
			// tcLanguages
			// 
			this.tcLanguages.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.tcLanguages.Controls.AddRange(new System.Windows.Forms.Control[] {
																					  this.tpCSharp,
																					  this.tpVBNET,
																					  this.tpJScript,
																					  this.tpJSharp,
																					  this.tpMondrian,
																					  this.tpCobol,
																					  this.tpEiffel});
			this.tcLanguages.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tcLanguages.HotTrack = true;
			this.tcLanguages.Location = new System.Drawing.Point(8, 152);
			this.tcLanguages.Multiline = true;
			this.tcLanguages.Name = "tcLanguages";
			this.tcLanguages.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.tcLanguages.SelectedIndex = 0;
			this.tcLanguages.Size = new System.Drawing.Size(728, 304);
			this.tcLanguages.TabIndex = 0;
			this.tcLanguages.SelectedIndexChanged += new System.EventHandler(this.tcLanguages_SelectedIndexChanged);
			// 
			// tpCSharp
			// 
			this.tpCSharp.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.txtCSharp});
			this.tpCSharp.Location = new System.Drawing.Point(4, 22);
			this.tpCSharp.Name = "tpCSharp";
			this.tpCSharp.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.tpCSharp.Size = new System.Drawing.Size(720, 278);
			this.tpCSharp.TabIndex = 0;
			this.tpCSharp.Text = "C#";
			// 
			// txtCSharp
			// 
			this.txtCSharp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtCSharp.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtCSharp.Multiline = true;
			this.txtCSharp.Name = "txtCSharp";
			this.txtCSharp.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtCSharp.Size = new System.Drawing.Size(720, 278);
			this.txtCSharp.TabIndex = 0;
			this.txtCSharp.Text = "";
			// 
			// tpVBNET
			// 
			this.tpVBNET.Controls.AddRange(new System.Windows.Forms.Control[] {
																				  this.txtVB});
			this.tpVBNET.Location = new System.Drawing.Point(4, 22);
			this.tpVBNET.Name = "tpVBNET";
			this.tpVBNET.Size = new System.Drawing.Size(720, 278);
			this.tpVBNET.TabIndex = 1;
			this.tpVBNET.Text = "VB.NET";
			// 
			// txtVB
			// 
			this.txtVB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtVB.Font = new System.Drawing.Font("Courier New", 8.25F);
			this.txtVB.Multiline = true;
			this.txtVB.Name = "txtVB";
			this.txtVB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtVB.Size = new System.Drawing.Size(720, 278);
			this.txtVB.TabIndex = 1;
			this.txtVB.Text = "";
			// 
			// tpJScript
			// 
			this.tpJScript.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.txtJScript});
			this.tpJScript.Location = new System.Drawing.Point(4, 22);
			this.tpJScript.Name = "tpJScript";
			this.tpJScript.Size = new System.Drawing.Size(720, 278);
			this.tpJScript.TabIndex = 2;
			this.tpJScript.Text = "JScript";
			// 
			// txtJScript
			// 
			this.txtJScript.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtJScript.Font = new System.Drawing.Font("Courier New", 8.25F);
			this.txtJScript.Multiline = true;
			this.txtJScript.Name = "txtJScript";
			this.txtJScript.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtJScript.Size = new System.Drawing.Size(720, 278);
			this.txtJScript.TabIndex = 1;
			this.txtJScript.Text = "";
			// 
			// tpJSharp
			// 
			this.tpJSharp.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.txtJSharp});
			this.tpJSharp.Location = new System.Drawing.Point(4, 22);
			this.tpJSharp.Name = "tpJSharp";
			this.tpJSharp.Size = new System.Drawing.Size(720, 278);
			this.tpJSharp.TabIndex = 3;
			this.tpJSharp.Text = "J#.NET";
			// 
			// txtJSharp
			// 
			this.txtJSharp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtJSharp.Font = new System.Drawing.Font("Courier New", 8.25F);
			this.txtJSharp.Multiline = true;
			this.txtJSharp.Name = "txtJSharp";
			this.txtJSharp.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtJSharp.Size = new System.Drawing.Size(720, 278);
			this.txtJSharp.TabIndex = 1;
			this.txtJSharp.Text = "";
			// 
			// tpMondrian
			// 
			this.tpMondrian.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.txtMondiran});
			this.tpMondrian.Location = new System.Drawing.Point(4, 22);
			this.tpMondrian.Name = "tpMondrian";
			this.tpMondrian.Size = new System.Drawing.Size(720, 278);
			this.tpMondrian.TabIndex = 4;
			this.tpMondrian.Text = "Mondrian";
			// 
			// txtMondiran
			// 
			this.txtMondiran.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtMondiran.Font = new System.Drawing.Font("Courier New", 8.25F);
			this.txtMondiran.Multiline = true;
			this.txtMondiran.Name = "txtMondiran";
			this.txtMondiran.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtMondiran.Size = new System.Drawing.Size(720, 278);
			this.txtMondiran.TabIndex = 1;
			this.txtMondiran.Text = "";
			// 
			// tpCobol
			// 
			this.tpCobol.Controls.AddRange(new System.Windows.Forms.Control[] {
																				  this.txtCobol});
			this.tpCobol.Location = new System.Drawing.Point(4, 22);
			this.tpCobol.Name = "tpCobol";
			this.tpCobol.Size = new System.Drawing.Size(720, 278);
			this.tpCobol.TabIndex = 5;
			this.tpCobol.Text = "Cobol";
			// 
			// txtCobol
			// 
			this.txtCobol.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtCobol.Font = new System.Drawing.Font("Courier New", 8.25F);
			this.txtCobol.Multiline = true;
			this.txtCobol.Name = "txtCobol";
			this.txtCobol.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtCobol.Size = new System.Drawing.Size(720, 278);
			this.txtCobol.TabIndex = 2;
			this.txtCobol.Text = "";
			// 
			// tpEiffel
			// 
			this.tpEiffel.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.txtEiffel});
			this.tpEiffel.Location = new System.Drawing.Point(4, 22);
			this.tpEiffel.Name = "tpEiffel";
			this.tpEiffel.Size = new System.Drawing.Size(720, 278);
			this.tpEiffel.TabIndex = 6;
			this.tpEiffel.Text = "Eiffel";
			// 
			// txtEiffel
			// 
			this.txtEiffel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtEiffel.Font = new System.Drawing.Font("Courier New", 8.25F);
			this.txtEiffel.Multiline = true;
			this.txtEiffel.Name = "txtEiffel";
			this.txtEiffel.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtEiffel.Size = new System.Drawing.Size(720, 278);
			this.txtEiffel.TabIndex = 3;
			this.txtEiffel.Text = "";
			// 
			// btnPreview
			// 
			this.btnPreview.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnPreview.Location = new System.Drawing.Point(344, 464);
			this.btnPreview.Name = "btnPreview";
			this.btnPreview.Size = new System.Drawing.Size(120, 24);
			this.btnPreview.TabIndex = 3;
			this.btnPreview.Text = "Generate Preview";
			this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
			// 
			// btnCreate
			// 
			this.btnCreate.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCreate.Location = new System.Drawing.Point(476, 464);
			this.btnCreate.Name = "btnCreate";
			this.btnCreate.Size = new System.Drawing.Size(120, 24);
			this.btnCreate.TabIndex = 10;
			this.btnCreate.Text = "Create Application";
			this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Black;
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(744, 1);
			this.panel2.TabIndex = 12;
			// 
			// tcOptions
			// 
			this.tcOptions.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.tcOptions.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.tpAppOut,
																					this.tpGeneratorOps,
																					this.tpCompilerParams,
																					this.tpResults});
			this.tcOptions.Location = new System.Drawing.Point(8, 8);
			this.tcOptions.Name = "tcOptions";
			this.tcOptions.SelectedIndex = 0;
			this.tcOptions.Size = new System.Drawing.Size(728, 136);
			this.tcOptions.TabIndex = 13;
			this.tcOptions.SelectedIndexChanged += new System.EventHandler(this.tcOptions_SelectedIndexChanged);
			// 
			// tpAppOut
			// 
			this.tpAppOut.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.cboTargetLanguage,
																				   this.label1,
																				   this.label3,
																				   this.label2,
																				   this.txtBinaryDirectory,
																				   this.txtSourceDirectory});
			this.tpAppOut.Location = new System.Drawing.Point(4, 22);
			this.tpAppOut.Name = "tpAppOut";
			this.tpAppOut.Size = new System.Drawing.Size(720, 110);
			this.tpAppOut.TabIndex = 0;
			this.tpAppOut.Text = "Application Output";
			// 
			// cboTargetLanguage
			// 
			this.cboTargetLanguage.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cboTargetLanguage.Location = new System.Drawing.Point(440, 48);
			this.cboTargetLanguage.Name = "cboTargetLanguage";
			this.cboTargetLanguage.Size = new System.Drawing.Size(200, 21);
			this.cboTargetLanguage.TabIndex = 27;
			this.cboTargetLanguage.SelectedIndexChanged += new System.EventHandler(this.cboTargetLanguage_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(440, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 16);
			this.label1.TabIndex = 28;
			this.label1.Text = "Target Language:";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(40, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 16);
			this.label3.TabIndex = 26;
			this.label3.Text = "Source:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(8, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 16);
			this.label2.TabIndex = 25;
			this.label2.Text = "Binary Output:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtBinaryDirectory
			// 
			this.txtBinaryDirectory.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtBinaryDirectory.Location = new System.Drawing.Point(96, 16);
			this.txtBinaryDirectory.Name = "txtBinaryDirectory";
			this.txtBinaryDirectory.Size = new System.Drawing.Size(328, 21);
			this.txtBinaryDirectory.TabIndex = 23;
			this.txtBinaryDirectory.Text = "C:\\CodeDOM\\AppOutput\\bin\\";
			this.txtBinaryDirectory.TextChanged += new System.EventHandler(this.txtBinaryDirectory_TextChanged);
			// 
			// txtSourceDirectory
			// 
			this.txtSourceDirectory.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtSourceDirectory.Location = new System.Drawing.Point(96, 48);
			this.txtSourceDirectory.Name = "txtSourceDirectory";
			this.txtSourceDirectory.Size = new System.Drawing.Size(328, 21);
			this.txtSourceDirectory.TabIndex = 21;
			this.txtSourceDirectory.Text = "C:\\CodeDOM\\AppOutput\\";
			// 
			// tpGeneratorOps
			// 
			this.tpGeneratorOps.Controls.AddRange(new System.Windows.Forms.Control[] {
																						 this.label6,
																						 this.label5,
																						 this.txtIndentString,
																						 this.cboBracingStyle,
																						 this.chkElseOnClose,
																						 this.chkBlankLines});
			this.tpGeneratorOps.Location = new System.Drawing.Point(4, 22);
			this.tpGeneratorOps.Name = "tpGeneratorOps";
			this.tpGeneratorOps.Size = new System.Drawing.Size(720, 110);
			this.tpGeneratorOps.TabIndex = 1;
			this.tpGeneratorOps.Text = "Generator Options";
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label6.Location = new System.Drawing.Point(8, 50);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(80, 16);
			this.label6.TabIndex = 5;
			this.label6.Text = "Indent String:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(8, 18);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(80, 16);
			this.label5.TabIndex = 4;
			this.label5.Text = "Bracing Style:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtIndentString
			// 
			this.txtIndentString.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtIndentString.Location = new System.Drawing.Point(96, 48);
			this.txtIndentString.Name = "txtIndentString";
			this.txtIndentString.Size = new System.Drawing.Size(184, 21);
			this.txtIndentString.TabIndex = 3;
			this.txtIndentString.Text = "";
			// 
			// cboBracingStyle
			// 
			this.cboBracingStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cboBracingStyle.Items.AddRange(new object[] {
																 "Block",
																 "C"});
			this.cboBracingStyle.Location = new System.Drawing.Point(96, 16);
			this.cboBracingStyle.Name = "cboBracingStyle";
			this.cboBracingStyle.Size = new System.Drawing.Size(184, 21);
			this.cboBracingStyle.TabIndex = 2;
			this.cboBracingStyle.Text = "Block";
			// 
			// chkElseOnClose
			// 
			this.chkElseOnClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.chkElseOnClose.Location = new System.Drawing.Point(304, 50);
			this.chkElseOnClose.Name = "chkElseOnClose";
			this.chkElseOnClose.Size = new System.Drawing.Size(208, 16);
			this.chkElseOnClose.TabIndex = 1;
			this.chkElseOnClose.Text = "Else on Closing";
			// 
			// chkBlankLines
			// 
			this.chkBlankLines.Checked = true;
			this.chkBlankLines.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkBlankLines.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.chkBlankLines.Location = new System.Drawing.Point(304, 18);
			this.chkBlankLines.Name = "chkBlankLines";
			this.chkBlankLines.Size = new System.Drawing.Size(200, 16);
			this.chkBlankLines.TabIndex = 0;
			this.chkBlankLines.Text = "Blank Line Between Members";
			// 
			// tpCompilerParams
			// 
			this.tpCompilerParams.Controls.AddRange(new System.Windows.Forms.Control[] {
																						   this.rbGenMemory,
																						   this.rbGenExe,
																						   this.txtOutAssembly,
																						   this.txtMainClass,
																						   this.txtCompilerOptions,
																						   this.chkTreatWarningsAsErrors,
																						   this.label9,
																						   this.label8,
																						   this.chkIncludeDebug,
																						   this.label7});
			this.tpCompilerParams.Location = new System.Drawing.Point(4, 22);
			this.tpCompilerParams.Name = "tpCompilerParams";
			this.tpCompilerParams.Size = new System.Drawing.Size(720, 110);
			this.tpCompilerParams.TabIndex = 3;
			this.tpCompilerParams.Text = "Compiler Parameters";
			// 
			// rbGenMemory
			// 
			this.rbGenMemory.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.rbGenMemory.Location = new System.Drawing.Point(512, 80);
			this.rbGenMemory.Name = "rbGenMemory";
			this.rbGenMemory.Size = new System.Drawing.Size(192, 16);
			this.rbGenMemory.TabIndex = 12;
			this.rbGenMemory.Text = "Generate in Memory and Execute";
			// 
			// rbGenExe
			// 
			this.rbGenExe.Checked = true;
			this.rbGenExe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.rbGenExe.Location = new System.Drawing.Point(512, 56);
			this.rbGenExe.Name = "rbGenExe";
			this.rbGenExe.Size = new System.Drawing.Size(184, 16);
			this.rbGenExe.TabIndex = 11;
			this.rbGenExe.TabStop = true;
			this.rbGenExe.Text = "Generate Executable File";
			// 
			// txtOutAssembly
			// 
			this.txtOutAssembly.Enabled = false;
			this.txtOutAssembly.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtOutAssembly.Location = new System.Drawing.Point(112, 72);
			this.txtOutAssembly.Name = "txtOutAssembly";
			this.txtOutAssembly.Size = new System.Drawing.Size(200, 21);
			this.txtOutAssembly.TabIndex = 10;
			this.txtOutAssembly.Text = "";
			// 
			// txtMainClass
			// 
			this.txtMainClass.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtMainClass.Location = new System.Drawing.Point(112, 44);
			this.txtMainClass.Name = "txtMainClass";
			this.txtMainClass.Size = new System.Drawing.Size(200, 21);
			this.txtMainClass.TabIndex = 9;
			this.txtMainClass.Text = "";
			// 
			// txtCompilerOptions
			// 
			this.txtCompilerOptions.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtCompilerOptions.Location = new System.Drawing.Point(112, 16);
			this.txtCompilerOptions.Name = "txtCompilerOptions";
			this.txtCompilerOptions.Size = new System.Drawing.Size(200, 21);
			this.txtCompilerOptions.TabIndex = 8;
			this.txtCompilerOptions.Text = "";
			// 
			// chkTreatWarningsAsErrors
			// 
			this.chkTreatWarningsAsErrors.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.chkTreatWarningsAsErrors.Location = new System.Drawing.Point(336, 80);
			this.chkTreatWarningsAsErrors.Name = "chkTreatWarningsAsErrors";
			this.chkTreatWarningsAsErrors.Size = new System.Drawing.Size(168, 16);
			this.chkTreatWarningsAsErrors.TabIndex = 7;
			this.chkTreatWarningsAsErrors.Text = "Treat Warnings as Errors";
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label9.Location = new System.Drawing.Point(8, 72);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(96, 16);
			this.label9.TabIndex = 5;
			this.label9.Text = "Output Assembly:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label8.Location = new System.Drawing.Point(32, 44);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(72, 16);
			this.label8.TabIndex = 4;
			this.label8.Text = "Main Class:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// chkIncludeDebug
			// 
			this.chkIncludeDebug.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.chkIncludeDebug.Location = new System.Drawing.Point(336, 56);
			this.chkIncludeDebug.Name = "chkIncludeDebug";
			this.chkIncludeDebug.Size = new System.Drawing.Size(136, 16);
			this.chkIncludeDebug.TabIndex = 3;
			this.chkIncludeDebug.Text = "Include Debug Info";
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label7.Location = new System.Drawing.Point(8, 16);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(96, 16);
			this.label7.TabIndex = 0;
			this.label7.Text = "Compiler Options:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tpResults
			// 
			this.tpResults.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.txtResults});
			this.tpResults.Location = new System.Drawing.Point(4, 22);
			this.tpResults.Name = "tpResults";
			this.tpResults.Size = new System.Drawing.Size(720, 110);
			this.tpResults.TabIndex = 2;
			this.tpResults.Text = "Compiler Results";
			// 
			// txtResults
			// 
			this.txtResults.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtResults.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtResults.Multiline = true;
			this.txtResults.Name = "txtResults";
			this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtResults.Size = new System.Drawing.Size(720, 110);
			this.txtResults.TabIndex = 4;
			this.txtResults.Text = "";
			// 
			// tabPage1
			// 
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(720, 110);
			this.tabPage1.TabIndex = 3;
			this.tabPage1.Text = "Compiler Parameters";
			// 
			// btnDone
			// 
			this.btnDone.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.btnDone.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnDone.Location = new System.Drawing.Point(608, 464);
			this.btnDone.Name = "btnDone";
			this.btnDone.Size = new System.Drawing.Size(120, 24);
			this.btnDone.TabIndex = 14;
			this.btnDone.Text = "&Done";
			this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
			// 
			// HelloGen
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(744, 493);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.tcOptions,
																		  this.btnDone,
																		  this.panel2,
																		  this.btnCreate,
																		  this.btnPreview,
																		  this.tcLanguages});
			this.Name = "HelloGen";
			this.Text = "CodeDOM Simple Application Generator";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.tcLanguages.ResumeLayout(false);
			this.tpCSharp.ResumeLayout(false);
			this.tpVBNET.ResumeLayout(false);
			this.tpJScript.ResumeLayout(false);
			this.tpJSharp.ResumeLayout(false);
			this.tpMondrian.ResumeLayout(false);
			this.tpCobol.ResumeLayout(false);
			this.tpEiffel.ResumeLayout(false);
			this.tcOptions.ResumeLayout(false);
			this.tpAppOut.ResumeLayout(false);
			this.tpGeneratorOps.ResumeLayout(false);
			this.tpCompilerParams.ResumeLayout(false);
			this.tpResults.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new HelloGen());
		}


		#region FormCode
		/// <summary>
		/// UI code 
		/// </summary>
		private void Form1_Load(object sender, System.EventArgs e) {
		
		}

		private void btnPreview_Click(object sender, System.EventArgs e) {
			GeneratePreview();
		}

		private void btnCreate_Click(object sender, System.EventArgs e) {
			GenerateProgram();
		}

		// Sets the path for the application and generated source code.
		private void SetOutputStrings() {
			string src;
			string bin;
			string extension = ((LanguageItem)cboTargetLanguage.SelectedItem).SourceExtension;
			string Suffix = ((LanguageItem)cboTargetLanguage.SelectedItem).ExeSuffix;

			src = txtSourceDirectory.Text;
			bin = txtBinaryDirectory.Text;

			if(src.LastIndexOf(@"\") >= 0) {
				src = src.Substring(0, src.LastIndexOf(@"\"));
				src = src + @"\" + GEN_APP_NAME + extension;
				txtSourceDirectory.Text = src;
			} else {
				txtSourceDirectory.Text = DEF_DIR_NAME + GEN_APP_NAME + extension;
			}
			
			if(bin.LastIndexOf(@"\") >= 0) {
				bin = bin.Substring(0, bin.LastIndexOf(@"\"));
				bin = bin + @"\" + GEN_APP_NAME + Suffix + ".exe";
				txtBinaryDirectory.Text = bin;
			} else {
				txtBinaryDirectory.Text = DEF_DIR_NAME + @"bin\" + GEN_APP_NAME + Suffix + ".exe";
			}
		}


		#endregion

		#region CodeGeneration
		/// <summary>
		/// Code region for the generation of simple applications
		/// </summary>
		/// 

		private void GeneratePreview() {
			ICodeGenerator			hwGenerator;
			CodeCompileUnit			hwCompileUnit;
			StringWriter			CodeText;
			TemplateConstructor		HelloWorldApp = new TemplateConstructor();
			CodeGeneratorOptions	GeneratorOptions = GetGeneratorOptions();

			// Create our source Graph for each language
			foreach(LanguageItem Lang in cboTargetLanguage.Items) {	
				if(Lang.LanguageID == Language.JScript) {
					HelloWorldApp.UseFullNamespace = true;
				} else {
					HelloWorldApp.UseFullNamespace = false;
				}
				hwCompileUnit = HelloWorldApp.GenerateCCU();
				hwGenerator = GetLanguageGenerator(Lang.LanguageID);

				CodeText = new StringWriter();
				hwGenerator.GenerateCodeFromCompileUnit(hwCompileUnit, CodeText, GeneratorOptions);
				
				((TextBox)PreviewText[PT_PREFIX + Lang.LanguagePreviewID ]).Text = CodeText.ToString();
				
				CodeText.Close();
			}
		}

		private void GenerateProgram() {
			ICodeGenerator			hwGenerator;
			ICodeCompiler			hwCompiler;
			CodeCompileUnit			hwCompileUnit;
			CompilerParameters		hwCompilerParameters;
			CompilerResults			hwResults;
			StreamWriter			CodeFile;
			StringBuilder			CompResults;
			TemplateConstructor		HelloWorldApp = new TemplateConstructor();
			CodeGeneratorOptions	GeneratorOptions = GetGeneratorOptions();
			CodeFile = new StreamWriter(txtSourceDirectory.Text);

			if((Language)cboTargetLanguage.SelectedIndex == Language.JScript) {
				HelloWorldApp.UseFullNamespace = true;
			} else {
				HelloWorldApp.UseFullNamespace = false;
			}

			//hwCompileUnit = CreateBaseCompileUnit();
			hwCompileUnit = HelloWorldApp.GenerateCCU();

			// Get the current CodeDOM language generator and compiler
			hwGenerator = GetLanguageGenerator((Language)cboTargetLanguage.SelectedIndex);
			hwCompiler = GetLanguageCompiler((Language)cboTargetLanguage.SelectedIndex);

			// Add language specifics
			CreateExtendedCompileUnit(hwGenerator, ref hwCompileUnit, GeneratorOptions, HelloWorldApp);

			hwGenerator.GenerateCodeFromCompileUnit(hwCompileUnit, CodeFile, GeneratorOptions);
			CodeFile.Close();

			hwCompilerParameters = GetCompilerParameters();
			hwResults = hwCompiler.CompileAssemblyFromDom(hwCompilerParameters, hwCompileUnit);

			CompResults = new StringBuilder(250);
			if(hwResults.NativeCompilerReturnValue == 0) {
				CompResults.Append("Assembly compiled successfully with a return value of 0!\r\n");
				CompResults.Append("Compiler:" + hwCompiler.ToString());

				if(hwCompilerParameters.GenerateInMemory) {
					ExecuteCompiledAssembly(hwResults.CompiledAssembly);
				}

			// Compile failed
			} else {
				CompResults.Append("Assembly compiled unsuccessfully with a return value of: " + hwResults.NativeCompilerReturnValue.ToString() + "!\n\r");
				CompResults.Append("Compiler:" + hwCompiler.ToString());				
			}
			if(hwResults.Errors.Count > 0) {
				foreach(CompilerError ce in hwResults.Errors) {
					CompResults.Append(ce.ErrorText + " \r\n");
					CompResults.Append("Number: " + ce.ErrorNumber.ToString() + " \r\n");
					CompResults.Append("Line: " + ce.Line.ToString() + " \r\n");
				}
			}

			txtResults.Text = CompResults.ToString();
			tcOptions.SelectedTab = tpResults;
		}

		private void ExecuteCompiledAssembly(Assembly hwApp) {
			try {
				object	AppInstance = hwApp.CreateInstance("HelloWorld.HelloApplication");
				object[] args		= new object[0];
				Type ClassType		= hwApp.GetType("HelloWorld.HelloApplication");
				MethodInfo	MainMethod	= ClassType.GetMethod("Main");
				MainMethod.Invoke(AppInstance, args);
			} catch(TargetInvocationException e) {
				MessageBox.Show(e.InnerException.Message);
			} catch(Exception e) {
				MessageBox.Show(e.Message);
			}

		}

		private void CreateExtendedCompileUnit(ICodeGenerator hwGenerator,
												ref CodeCompileUnit hwCompileUnit, 
												CodeGeneratorOptions GeneratorOptions,
												TemplateConstructor HelloWorldApp) {
			StringWriter			CodeText = new StringWriter();

			// Generate code with text placeholder
			hwGenerator.GenerateCodeFromCompileUnit(hwCompileUnit, CodeText, GeneratorOptions);
			HelloWorldApp.SourceText = new CodePrimitiveExpression(CodeText.ToString());
			hwCompileUnit = HelloWorldApp.GenerateCCU();
		}

		private ICodeGenerator GetLanguageGenerator(Language OutputLanguage) {
			switch(OutputLanguage) {
				case Language.CSharp:
					return new CSharpCodeProvider().CreateGenerator();
				case Language.VB:
					return new VBCodeProvider().CreateGenerator();
				case Language.JScript:
					return new JScriptCodeProvider().CreateGenerator();
				//TODO: Comment out to enable support for languages
				//case Language.JSharp:
				//	return new VJSharpCodeProvider().CreateGenerator();
				//case Language.Mondrian:
				//	return new MondrianProvider().CreateGenerator();
				//case Language.Cobol:
				//	return new COBOLCodeProvider().CreateGenerator();
				//case Language.Eiffel:
				//	return new ISE.CodeDomProxy.CEiffelCodeDomProvider().CreateGenerator();
				default:
					return null;
			}
		}


		private ICodeCompiler GetLanguageCompiler(Language OutputLanguage) {
			switch(OutputLanguage) {
				case Language.CSharp:
					return new CSharpCodeProvider().CreateCompiler();
				case Language.VB:
					return new VBCodeProvider().CreateCompiler();
				case Language.JScript:
					return new JScriptCodeProvider().CreateCompiler();
				//TODO: Uncomment to enable languages
				//case Language.JSharp:
				//	return new VJSharpCodeProvider().CreateCompiler();
				//case Language.Mondrian:
				//	return new MondrianProvider().CreateCompiler();
				//case Language.Cobol:
				//	return new COBOLCodeProvider().CreateCompiler();
				//case Language.Eiffel:
				//	return new ISE.CodeDomProxy.CEiffelCodeDomProvider().CreateCompiler();
				default:
					return null;
			}
		}

		private CodeGeneratorOptions GetGeneratorOptions() {
			CodeGeneratorOptions GeneratorOptions = new CodeGeneratorOptions();

			GeneratorOptions.BlankLinesBetweenMembers = chkBlankLines.Checked;
			GeneratorOptions.BracingStyle = cboBracingStyle.Text;
			GeneratorOptions.ElseOnClosing = chkElseOnClose.Checked;
			GeneratorOptions.IndentString = txtIndentString.Text;
			
			return GeneratorOptions;
		}

		private CompilerParameters GetCompilerParameters() {
			CompilerParameters hwCompilerParameters = new CompilerParameters();
			
			if(txtCompilerOptions.Text.Length > 0) 
				hwCompilerParameters.CompilerOptions = txtCompilerOptions.Text ;

			hwCompilerParameters.ReferencedAssemblies.Add("System.dll");
			hwCompilerParameters.ReferencedAssemblies.Add("System.Drawing.dll");
			hwCompilerParameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");

			hwCompilerParameters.GenerateExecutable = true;
			hwCompilerParameters.GenerateInMemory = rbGenMemory.Checked;
			hwCompilerParameters.IncludeDebugInformation = chkIncludeDebug.Checked ;
			
			if(txtMainClass.Text.Length > 0) 
				hwCompilerParameters.MainClass = txtMainClass.Text ;

			hwCompilerParameters.OutputAssembly = txtBinaryDirectory.Text;
			hwCompilerParameters.TreatWarningsAsErrors = chkTreatWarningsAsErrors.Checked;

			return hwCompilerParameters;
		}

		private CodeMethodInvokeExpression CreateMethodCall(string objectName, string methodName, string[] args) {
			return new CodeMethodInvokeExpression();
		}
		#endregion

		private void txtBinaryDirectory_TextChanged(object sender, System.EventArgs e) {
			txtOutAssembly.Text = txtBinaryDirectory.Text;
		}

		private void btnDone_Click(object sender, System.EventArgs e) {
			this.Close();
		}

		private void cboTargetLanguage_SelectedIndexChanged(object sender, System.EventArgs e) {
			SetOutputStrings();
		}

		private void tcOptions_SelectedIndexChanged(object sender, System.EventArgs e) {
		
		}

		private void tcLanguages_SelectedIndexChanged(object sender, System.EventArgs e) {
		
		}

	}
}
