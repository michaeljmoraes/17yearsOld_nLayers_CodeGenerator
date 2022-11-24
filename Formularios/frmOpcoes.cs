using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace Procwork.CodeGenerator.Formularios
{
	/// <summary>
	/// Summary description for frmOpcoes.
	/// </summary>
	public class frmOpcoes : System.Windows.Forms.Form
	{
		public System.Windows.Forms.CheckBox chkMapper;
		public System.Windows.Forms.TextBox txtCaminhoSaida;
		private System.Windows.Forms.Label lblCaminhoSaida;
		private System.Windows.Forms.OpenFileDialog ofdCaminhoSaida;
		private System.Windows.Forms.Button cmdValidar;
		private System.Windows.Forms.Label lblClasse;
		public System.Windows.Forms.TextBox txtClasse;
		private System.Windows.Forms.Label lblNamespace;
		public System.Windows.Forms.TextBox txtNamespace;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdCancelar;
		public System.Windows.Forms.CheckBox chkEO;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmOpcoes()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
			this.chkMapper = new System.Windows.Forms.CheckBox();
			this.txtCaminhoSaida = new System.Windows.Forms.TextBox();
			this.lblCaminhoSaida = new System.Windows.Forms.Label();
			this.ofdCaminhoSaida = new System.Windows.Forms.OpenFileDialog();
			this.cmdValidar = new System.Windows.Forms.Button();
			this.lblClasse = new System.Windows.Forms.Label();
			this.txtClasse = new System.Windows.Forms.TextBox();
			this.lblNamespace = new System.Windows.Forms.Label();
			this.txtNamespace = new System.Windows.Forms.TextBox();
			this.cmdOK = new System.Windows.Forms.Button();
			this.cmdCancelar = new System.Windows.Forms.Button();
			this.chkEO = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// chkMapper
			// 
			this.chkMapper.Location = new System.Drawing.Point(16, 120);
			this.chkMapper.Name = "chkMapper";
			this.chkMapper.Size = new System.Drawing.Size(472, 24);
			this.chkMapper.TabIndex = 3;
			this.chkMapper.Text = "Gerar Arquivo Mapper";
			this.chkMapper.CheckedChanged += new System.EventHandler(this.chkMapper_CheckedChanged);
			// 
			// txtCaminhoSaida
			// 
			this.txtCaminhoSaida.Location = new System.Drawing.Point(120, 72);
			this.txtCaminhoSaida.Name = "txtCaminhoSaida";
			this.txtCaminhoSaida.Size = new System.Drawing.Size(288, 20);
			this.txtCaminhoSaida.TabIndex = 2;
			this.txtCaminhoSaida.Text = "";
			// 
			// lblCaminhoSaida
			// 
			this.lblCaminhoSaida.Location = new System.Drawing.Point(16, 72);
			this.lblCaminhoSaida.Name = "lblCaminhoSaida";
			this.lblCaminhoSaida.Size = new System.Drawing.Size(100, 16);
			this.lblCaminhoSaida.TabIndex = 2;
			this.lblCaminhoSaida.Text = "Caminho de Saida: ";
			// 
			// cmdValidar
			// 
			this.cmdValidar.Location = new System.Drawing.Point(416, 72);
			this.cmdValidar.Name = "cmdValidar";
			this.cmdValidar.Size = new System.Drawing.Size(72, 23);
			this.cmdValidar.TabIndex = 3;
			this.cmdValidar.Text = "Validar";
			this.cmdValidar.Click += new System.EventHandler(this.cmdValidar_Click);
			// 
			// lblClasse
			// 
			this.lblClasse.Location = new System.Drawing.Point(16, 40);
			this.lblClasse.Name = "lblClasse";
			this.lblClasse.Size = new System.Drawing.Size(100, 16);
			this.lblClasse.TabIndex = 5;
			this.lblClasse.Text = "Classe";
			// 
			// txtClasse
			// 
			this.txtClasse.Location = new System.Drawing.Point(120, 40);
			this.txtClasse.Name = "txtClasse";
			this.txtClasse.Size = new System.Drawing.Size(288, 20);
			this.txtClasse.TabIndex = 1;
			this.txtClasse.Text = "";
			// 
			// lblNamespace
			// 
			this.lblNamespace.Location = new System.Drawing.Point(16, 8);
			this.lblNamespace.Name = "lblNamespace";
			this.lblNamespace.Size = new System.Drawing.Size(100, 16);
			this.lblNamespace.TabIndex = 7;
			this.lblNamespace.Text = "Namespace";
			// 
			// txtNamespace
			// 
			this.txtNamespace.Location = new System.Drawing.Point(120, 8);
			this.txtNamespace.Name = "txtNamespace";
			this.txtNamespace.Size = new System.Drawing.Size(288, 20);
			this.txtNamespace.TabIndex = 0;
			this.txtNamespace.Text = "";
			// 
			// cmdOK
			// 
			this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.cmdOK.Location = new System.Drawing.Point(24, 240);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.Size = new System.Drawing.Size(72, 23);
			this.cmdOK.TabIndex = 5;
			this.cmdOK.Text = "OK";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// cmdCancelar
			// 
			this.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancelar.Location = new System.Drawing.Point(112, 240);
			this.cmdCancelar.Name = "cmdCancelar";
			this.cmdCancelar.Size = new System.Drawing.Size(72, 23);
			this.cmdCancelar.TabIndex = 6;
			this.cmdCancelar.Text = "Cancelar";
			this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
			// 
			// chkEO
			// 
			this.chkEO.Location = new System.Drawing.Point(16, 152);
			this.chkEO.Name = "chkEO";
			this.chkEO.Size = new System.Drawing.Size(472, 24);
			this.chkEO.TabIndex = 4;
			this.chkEO.Text = "Gerar Arquivo EO";
			// 
			// frmOpcoes
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(504, 288);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.chkEO,
																		  this.cmdCancelar,
																		  this.cmdOK,
																		  this.lblNamespace,
																		  this.txtNamespace,
																		  this.lblClasse,
																		  this.txtClasse,
																		  this.cmdValidar,
																		  this.lblCaminhoSaida,
																		  this.txtCaminhoSaida,
																		  this.chkMapper});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmOpcoes";
			this.Text = "Opções";
			this.ResumeLayout(false);

		}
		#endregion

		private void cmdValidar_Click(object sender, System.EventArgs e)
		{
			if(!System.IO.Directory.Exists(this.txtCaminhoSaida.Text))
			{
				MessageBox.Show("diretorio inexistente.");
			}
			
		}

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void cmdCancelar_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void chkMapper_CheckedChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
