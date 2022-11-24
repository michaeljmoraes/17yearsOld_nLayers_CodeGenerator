using System;
using System.Drawing;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.Reflection;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;

using Microsoft.CSharp;
using Microsoft.VisualBasic;
using Microsoft.JScript;

namespace NetTemplateGenerator
{
	public enum Language : int {
		CSharp		= 0,
		VB			= 1,
		JSharp		= 2,
		JScript		= 3,
		Mondrian	= 4,
		Cobol		= 5
	}
	
	/// <summary>
	/// Summary description for TemplateGenerator.
	/// </summary>
	public class TemplateGenerator : System.Windows.Forms.Form
	{

		private const int LABEL_LEFT = 16;
		private const int LABEL_WIDTH = 160;
		private const int LABEL_HEIGH = 20;
		private const int TEXTBOX_LEFT = 192;
		private const int TEXTBOX_WIDTH = 320;
		private const int TEXTBOX_HEIGHT = 20;
		private const string LBL_PREFIX = "GENLBL_";
		private const string TBX_PREFIX = "GENTBX_";
		private const string GEN_FILE_NAME = "CodeOutput";
		private const string DEF_DIR_NAME = @"C:\CodeDOM\AppOutput\";
		private System.Windows.Forms.TabControl tcOptions;
		private System.Windows.Forms.TabPage tpAppOut;
		private System.Windows.Forms.TabPage tpGeneratorOps;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtIndentString;
		private System.Windows.Forms.ComboBox cboBracingStyle;
		private System.Windows.Forms.CheckBox chkElseOnClose;
		private System.Windows.Forms.CheckBox chkBlankLines;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cboTargetLanguage;
		private System.Windows.Forms.TextBox txtSourceDirectory;
		private System.Windows.Forms.TabPage tpAssembly;
		private System.Windows.Forms.TextBox txtPreview;
		private System.Windows.Forms.Label lblSource;
		private System.Windows.Forms.TextBox txtSourceAssembly;
		private System.Windows.Forms.Button btnSelectAssembly;
		private System.Windows.Forms.Button btnLoad;
		private System.Windows.Forms.Label label2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private Assembly				GeneratorAssembly;
		private Type[]					AssemblyTypes;
		private Hashtable				GenClassTypeValues;
		private NameValueCollection		GenClassTypesCol;

		private System.Windows.Forms.ComboBox cboClasses;
		private System.Windows.Forms.Panel pnlTypes;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label lblType;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button btnGenerate;
		

		public TemplateGenerator()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			cboTargetLanguage.Items.Add(new LanguageItem(Language.CSharp, "C#"));
			cboTargetLanguage.Items.Add(new LanguageItem(Language.VB, "Visual Basic.NET"));
			//cboTargetLanguage.Items.Add(new LanguageItem(Language.JScript, "JScript"));
			
			//TODO: Uncomment to enable languages
			//cboTargetLanguage.Items.Add(new LanguageItem(Language.JSharp, "J#"));
			//cboTargetLanguage.Items.Add(new LanguageItem(Language.Mondrian, "Mondrian"));
			//cboTargetLanguage.Items.Add(new LanguageItem(Language.Cobol, "COBOL"));
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
			this.tcOptions = new System.Windows.Forms.TabControl();
			this.tpAssembly = new System.Windows.Forms.TabPage();
			this.panel3 = new System.Windows.Forms.Panel();
			this.lblType = new System.Windows.Forms.Label();
			this.pnlTypes = new System.Windows.Forms.Panel();
			this.btnGenerate = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.btnLoad = new System.Windows.Forms.Button();
			this.cboClasses = new System.Windows.Forms.ComboBox();
			this.btnSelectAssembly = new System.Windows.Forms.Button();
			this.lblSource = new System.Windows.Forms.Label();
			this.txtSourceAssembly = new System.Windows.Forms.TextBox();
			this.tpAppOut = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cboTargetLanguage = new System.Windows.Forms.ComboBox();
			this.txtSourceDirectory = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtIndentString = new System.Windows.Forms.TextBox();
			this.cboBracingStyle = new System.Windows.Forms.ComboBox();
			this.chkElseOnClose = new System.Windows.Forms.CheckBox();
			this.chkBlankLines = new System.Windows.Forms.CheckBox();
			this.tpGeneratorOps = new System.Windows.Forms.TabPage();
			this.txtPreview = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.tcOptions.SuspendLayout();
			this.tpAssembly.SuspendLayout();
			this.panel3.SuspendLayout();
			this.tpAppOut.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tpGeneratorOps.SuspendLayout();
			this.SuspendLayout();
			// 
			// tcOptions
			// 
			this.tcOptions.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.tcOptions.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.tpAssembly,
																					this.tpAppOut,
																					this.tpGeneratorOps});
			this.tcOptions.Location = new System.Drawing.Point(8, 8);
			this.tcOptions.Name = "tcOptions";
			this.tcOptions.SelectedIndex = 0;
			this.tcOptions.Size = new System.Drawing.Size(728, 424);
			this.tcOptions.TabIndex = 14;
			// 
			// tpAssembly
			// 
			this.tpAssembly.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.panel3,
																					 this.pnlTypes,
																					 this.btnGenerate,
																					 this.label2,
																					 this.btnLoad,
																					 this.cboClasses,
																					 this.btnSelectAssembly,
																					 this.lblSource,
																					 this.txtSourceAssembly});
			this.tpAssembly.Location = new System.Drawing.Point(4, 22);
			this.tpAssembly.Name = "tpAssembly";
			this.tpAssembly.Size = new System.Drawing.Size(720, 398);
			this.tpAssembly.TabIndex = 2;
			this.tpAssembly.Text = "Source Assembly";
			this.tpAssembly.Click += new System.EventHandler(this.tpAssembly_Click);
			// 
			// panel3
			// 
			this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.panel3.BackColor = System.Drawing.SystemColors.Window;
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel3.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.lblType});
			this.panel3.Location = new System.Drawing.Point(24, 104);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(688, 32);
			this.panel3.TabIndex = 8;
			// 
			// lblType
			// 
			this.lblType.Location = new System.Drawing.Point(16, 8);
			this.lblType.Name = "lblType";
			this.lblType.Size = new System.Drawing.Size(240, 16);
			this.lblType.TabIndex = 0;
			this.lblType.Text = "Parameters:";
			// 
			// pnlTypes
			// 
			this.pnlTypes.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.pnlTypes.AutoScroll = true;
			this.pnlTypes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlTypes.Location = new System.Drawing.Point(24, 136);
			this.pnlTypes.Name = "pnlTypes";
			this.pnlTypes.Size = new System.Drawing.Size(688, 224);
			this.pnlTypes.TabIndex = 7;
			// 
			// btnGenerate
			// 
			this.btnGenerate.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnGenerate.Location = new System.Drawing.Point(600, 368);
			this.btnGenerate.Name = "btnGenerate";
			this.btnGenerate.Size = new System.Drawing.Size(112, 24);
			this.btnGenerate.TabIndex = 6;
			this.btnGenerate.Text = "Generate Code";
			this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(32, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(104, 16);
			this.label2.TabIndex = 5;
			this.label2.Text = "Generator Class:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnLoad
			// 
			this.btnLoad.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnLoad.Location = new System.Drawing.Point(472, 368);
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.Size = new System.Drawing.Size(112, 24);
			this.btnLoad.TabIndex = 4;
			this.btnLoad.Text = "Load Assembly";
			this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
			// 
			// cboClasses
			// 
			this.cboClasses.Location = new System.Drawing.Point(136, 56);
			this.cboClasses.Name = "cboClasses";
			this.cboClasses.Size = new System.Drawing.Size(368, 21);
			this.cboClasses.TabIndex = 3;
			this.cboClasses.SelectedIndexChanged += new System.EventHandler(this.cboClasses_SelectedIndexChanged);
			// 
			// btnSelectAssembly
			// 
			this.btnSelectAssembly.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnSelectAssembly.Location = new System.Drawing.Point(512, 24);
			this.btnSelectAssembly.Name = "btnSelectAssembly";
			this.btnSelectAssembly.Size = new System.Drawing.Size(32, 20);
			this.btnSelectAssembly.TabIndex = 2;
			this.btnSelectAssembly.Text = ". . .";
			this.btnSelectAssembly.Click += new System.EventHandler(this.btnSelectAssembly_Click);
			// 
			// lblSource
			// 
			this.lblSource.Location = new System.Drawing.Point(16, 24);
			this.lblSource.Name = "lblSource";
			this.lblSource.Size = new System.Drawing.Size(120, 16);
			this.lblSource.TabIndex = 1;
			this.lblSource.Text = "Source Assembly:";
			this.lblSource.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtSourceAssembly
			// 
			this.txtSourceAssembly.Location = new System.Drawing.Point(136, 24);
			this.txtSourceAssembly.Name = "txtSourceAssembly";
			this.txtSourceAssembly.Size = new System.Drawing.Size(368, 20);
			this.txtSourceAssembly.TabIndex = 0;
			this.txtSourceAssembly.Text = "C:\\CodeDOM\\TypedHashtableProvider\\bin\\Debug\\TypedHashtable.dll";
			// 
			// tpAppOut
			// 
			this.tpAppOut.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.groupBox2,
																				   this.groupBox1});
			this.tpAppOut.Location = new System.Drawing.Point(4, 22);
			this.tpAppOut.Name = "tpAppOut";
			this.tpAppOut.Size = new System.Drawing.Size(720, 398);
			this.tpAppOut.TabIndex = 0;
			this.tpAppOut.Text = "Class Output";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.label3,
																					this.label1,
																					this.cboTargetLanguage,
																					this.txtSourceDirectory});
			this.groupBox2.Location = new System.Drawing.Point(16, 16);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(560, 96);
			this.groupBox2.TabIndex = 28;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Target";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(56, 56);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 16);
			this.label3.TabIndex = 30;
			this.label3.Text = "Source:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 16);
			this.label1.TabIndex = 29;
			this.label1.Text = "Target Language:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cboTargetLanguage
			// 
			this.cboTargetLanguage.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cboTargetLanguage.Location = new System.Drawing.Point(112, 24);
			this.cboTargetLanguage.Name = "cboTargetLanguage";
			this.cboTargetLanguage.Size = new System.Drawing.Size(200, 21);
			this.cboTargetLanguage.TabIndex = 28;
			this.cboTargetLanguage.SelectedIndexChanged += new System.EventHandler(this.cboTargetLanguage_SelectedIndexChanged);
			// 
			// txtSourceDirectory
			// 
			this.txtSourceDirectory.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtSourceDirectory.Location = new System.Drawing.Point(112, 56);
			this.txtSourceDirectory.Name = "txtSourceDirectory";
			this.txtSourceDirectory.Size = new System.Drawing.Size(328, 21);
			this.txtSourceDirectory.TabIndex = 27;
			this.txtSourceDirectory.Text = "C:\\CodeDOM\\AppOutput\\";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.label6,
																					this.label5,
																					this.txtIndentString,
																					this.cboBracingStyle,
																					this.chkElseOnClose,
																					this.chkBlankLines});
			this.groupBox1.Location = new System.Drawing.Point(16, 128);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(560, 96);
			this.groupBox1.TabIndex = 27;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Generator Options";
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label6.Location = new System.Drawing.Point(16, 56);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(80, 16);
			this.label6.TabIndex = 11;
			this.label6.Text = "Indent String:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(16, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(80, 16);
			this.label5.TabIndex = 10;
			this.label5.Text = "Bracing Style:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtIndentString
			// 
			this.txtIndentString.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtIndentString.Location = new System.Drawing.Point(104, 56);
			this.txtIndentString.Name = "txtIndentString";
			this.txtIndentString.Size = new System.Drawing.Size(184, 21);
			this.txtIndentString.TabIndex = 9;
			this.txtIndentString.Text = "";
			// 
			// cboBracingStyle
			// 
			this.cboBracingStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cboBracingStyle.Items.AddRange(new object[] {
																 "Block",
																 "C"});
			this.cboBracingStyle.Location = new System.Drawing.Point(104, 24);
			this.cboBracingStyle.Name = "cboBracingStyle";
			this.cboBracingStyle.Size = new System.Drawing.Size(184, 21);
			this.cboBracingStyle.TabIndex = 8;
			this.cboBracingStyle.Text = "Block";
			// 
			// chkElseOnClose
			// 
			this.chkElseOnClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.chkElseOnClose.Location = new System.Drawing.Point(312, 56);
			this.chkElseOnClose.Name = "chkElseOnClose";
			this.chkElseOnClose.Size = new System.Drawing.Size(208, 16);
			this.chkElseOnClose.TabIndex = 7;
			this.chkElseOnClose.Text = "Else on Closing";
			// 
			// chkBlankLines
			// 
			this.chkBlankLines.Checked = true;
			this.chkBlankLines.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkBlankLines.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.chkBlankLines.Location = new System.Drawing.Point(312, 24);
			this.chkBlankLines.Name = "chkBlankLines";
			this.chkBlankLines.Size = new System.Drawing.Size(200, 16);
			this.chkBlankLines.TabIndex = 6;
			this.chkBlankLines.Text = "Blank Line Between Members";
			// 
			// tpGeneratorOps
			// 
			this.tpGeneratorOps.Controls.AddRange(new System.Windows.Forms.Control[] {
																						 this.txtPreview});
			this.tpGeneratorOps.Location = new System.Drawing.Point(4, 22);
			this.tpGeneratorOps.Name = "tpGeneratorOps";
			this.tpGeneratorOps.Size = new System.Drawing.Size(720, 398);
			this.tpGeneratorOps.TabIndex = 1;
			this.tpGeneratorOps.Text = "Preview";
			this.tpGeneratorOps.Visible = false;
			// 
			// txtPreview
			// 
			this.txtPreview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtPreview.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtPreview.Multiline = true;
			this.txtPreview.Name = "txtPreview";
			this.txtPreview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtPreview.Size = new System.Drawing.Size(720, 398);
			this.txtPreview.TabIndex = 1;
			this.txtPreview.Text = "";
			// 
			// button1
			// 
			this.button1.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button1.Location = new System.Drawing.Point(616, 448);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(120, 24);
			this.button1.TabIndex = 15;
			this.button1.Text = "&Done";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.WindowText;
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(744, 1);
			this.panel2.TabIndex = 16;
			// 
			// TemplateGenerator
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(744, 477);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.panel2,
																		  this.button1,
																		  this.tcOptions});
			this.Name = "TemplateGenerator";
			this.Text = ".NET Template Generator";
			this.tcOptions.ResumeLayout(false);
			this.tpAssembly.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.tpAppOut.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.tpGeneratorOps.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new TemplateGenerator());
		}

		private void tpAssembly_Click(object sender, System.EventArgs e) {
		
		}

		private void btnLoad_Click(object sender, System.EventArgs e) {
			InterrogateAssembly();
		}

		private void InterrogateAssembly() {
			GeneratorAssembly = Assembly.LoadFrom(txtSourceAssembly.Text);
			AssemblyTypes = GeneratorAssembly.GetTypes();
			PopulateClassesCBO(AssemblyTypes);
		}


		private void GenerateCode() {
			ICodeGenerator			ntGenerator;
			CodeGeneratorOptions	ntGeneratorOptions = GetGeneratorOptions();
			StringWriter			codePreview;
			StreamWriter			codeFile;
			GeneratorMethods curMethods = (GeneratorMethods)cboClasses.SelectedItem;
			CodeCompileUnit ccu;
			object	AppInstance = GeneratorAssembly.CreateInstance(curMethods.ClassName);
			object[] args = new object[1];
			string[] names = new string[GenClassTypesCol.Count];
			TextBox test;

			int i=0;
			foreach(string name in GenClassTypesCol) {
				names[i] = name;
				i++;
			}

			// Reset values in the current variables collection with user data
			foreach(string name in names) {
				test = (TextBox)(GenClassTypeValues[name]);
				GenClassTypesCol[name] = test.Text;
			}
			
			// Set the app variables in the satellite assembly and Invoke the CodeCompileUnit generator method
			args[0] = GenClassTypesCol;
			curMethods.SetVarsMethod.Invoke(AppInstance, args);
			ccu = (CodeCompileUnit)curMethods.CCUGeneratorMethod.Invoke(AppInstance, null);

			codePreview = new StringWriter();

			ntGenerator = GetLanguageGenerator((Language)cboTargetLanguage.SelectedIndex);
			ntGenerator.GenerateCodeFromCompileUnit(ccu, codePreview, ntGeneratorOptions);

			codeFile = new StreamWriter(txtSourceDirectory.Text);
			codeFile.Write(codePreview.ToString());

			txtPreview.Text	= codePreview.ToString();

            codePreview.Close();
			codeFile.Close();
		}


		private void PopulateClassesCBO(Type[] types) {
			bool bClassFound = false;
			// Find classes in the assembly
			cboClasses.Items.Clear();
			foreach(Type curType in types) {
				GeneratorMethods CurGenMethods = new GeneratorMethods();
				if(curType.IsClass) {
					CurGenMethods.CCUGeneratorMethod = curType.GetMethod("GenerateCCU");
					CurGenMethods.QueryVarsMethod = curType.GetMethod("QueryVariables");
					CurGenMethods.SetVarsMethod = curType.GetMethod("SetVariables");
					CurGenMethods.GetNameMethod = curType.GetMethod("GetName");

					if(CurGenMethods.IsValid()) {
						CurGenMethods.ClassName = curType.FullName;
						if(CurGenMethods.GetNameMethod != null) {
							CurGenMethods.FriendlyName = GetProviderName(CurGenMethods);
						}
						cboClasses.Items.Add(CurGenMethods);
						bClassFound = true;
					}
				}
			}

			if(bClassFound) {
				cboClasses.SelectedIndex = 0;
				CreateTypeControls();
			}

		}

		private string GetProviderName(GeneratorMethods curMethods) {
			object AppInstance = GeneratorAssembly.CreateInstance(curMethods.ClassName);
			return (string)curMethods.GetNameMethod.Invoke(AppInstance, null);
		}

		private void cboClasses_SelectedIndexChanged(object sender, System.EventArgs e) {
			CreateTypeControls();
		}

		private void CreateTypeControls() {
			int curHeight	= 8;
			
			GeneratorMethods curMethods = (GeneratorMethods)cboClasses.SelectedItem;
			TextBox tbText;
	
			pnlTypes.Controls.Clear();

			object AppInstance = GeneratorAssembly.CreateInstance(curMethods.ClassName);
			GenClassTypesCol = (NameValueCollection)curMethods.QueryVarsMethod.Invoke(AppInstance, null);
            
			GenClassTypeValues = new Hashtable(GenClassTypesCol.Count);
			foreach(string name in GenClassTypesCol) {
				tbText = CreateNewTextBox(curHeight, TBX_PREFIX + name, GenClassTypesCol[name]);
				pnlTypes.Controls.Add(CreateNewLabel(curHeight, LBL_PREFIX + name, name + ":"));
				pnlTypes.Controls.Add(tbText);

				GenClassTypeValues.Add(name, tbText);
				curHeight += 32;
			}
			

		}

		private Label CreateNewLabel(int labelTop, string labelName, string labelText) {
			Label NewLabel = new Label();
			
			NewLabel.Left = LABEL_LEFT;
			NewLabel.Width = LABEL_WIDTH;
			NewLabel.Height = LABEL_HEIGH;
			NewLabel.Top = labelTop;

			NewLabel.TextAlign = ContentAlignment.MiddleRight;
			NewLabel.Name = labelName;
			NewLabel.Text = labelText;
		
			return NewLabel;
		}
		private TextBox CreateNewTextBox(int textTop, string textName, string textText) {
			TextBox NewTextBox = new TextBox();

			NewTextBox.Left = TEXTBOX_LEFT;
			NewTextBox.Width = TEXTBOX_WIDTH;
			NewTextBox.Height = TEXTBOX_HEIGHT;
			NewTextBox.Top = textTop;

			NewTextBox.Name = textName;
			NewTextBox.Text = textText;

			return NewTextBox;
		}

		private void button1_Click(object sender, System.EventArgs e) {
			this.Close();
		}

		private void btnGenerate_Click(object sender, System.EventArgs e) {
			GenerateCode();
		}

		private void btnSelectAssembly_Click(object sender, System.EventArgs e) {
			OpenFileDialog ofd = new OpenFileDialog();
			if(ofd.ShowDialog() == DialogResult.OK) {
				txtSourceAssembly.Text = ofd.FileName;
			}
		}



		private void SetOutputStrings() {
			string extenstion = "";
			string Suffix = "";
			string src;
			switch(((LanguageItem)cboTargetLanguage.SelectedItem).LanguageID) {
				case Language.CSharp:
					extenstion = ".cs";
					Suffix = "_CSharp";
					break;
				case Language.VB:
					extenstion = ".vb";
					Suffix = "_VisualBasic";
					break;
				case Language.JSharp:
					extenstion = ".jsl";
					Suffix = "_JSharp";
					break;
				case Language.JScript:
					extenstion = ".js";
					Suffix = "_JScript";
					break;
				case Language.Mondrian:
					extenstion = ".mon";
					Suffix = "_Mondiran";
					break;
				case Language.Cobol:
					extenstion = ".co";
					Suffix = "_COBOL";
					break;
			}
			src = txtSourceDirectory.Text;

			if(src.LastIndexOf(@"\") >= 0) {
				src = src.Substring(0, src.LastIndexOf(@"\"));
				src = src + @"\" + GEN_FILE_NAME + Suffix + extenstion;
				txtSourceDirectory.Text = src;
			} else {
				txtSourceDirectory.Text = DEF_DIR_NAME + GEN_FILE_NAME + Suffix + extenstion;
			}
			
		}

		private ICodeGenerator GetLanguageGenerator(Language OutputLanguage) {
			switch(OutputLanguage) {
				case Language.CSharp:
					return new CSharpCodeProvider().CreateGenerator();
				case Language.VB:
					return new VBCodeProvider().CreateGenerator();
				case Language.JScript:
					return new JScriptCodeProvider().CreateGenerator();
				//TODO: Uncomment to enable languages
				//case Language.JSharp:
				//	return new VJSharpCodeProvider().CreateGenerator();
				//case Language.Mondrian:
				//	return new MondrianProvider().CreateGenerator();
				//case Language.Cobol:
				//	return new COBOLCodeProvider().CreateGenerator();
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

		private void cboTargetLanguage_SelectedIndexChanged(object sender, System.EventArgs e) {
			SetOutputStrings();
		}


	}
}




