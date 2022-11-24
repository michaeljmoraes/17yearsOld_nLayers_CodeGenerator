using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using Procwork.CodeGenerator.DataAccess;
using Procwork.CodeGenerator.Formularios;
using Procwork.CodeGenerator.Classes;
using Npgsql;

namespace Procwork.CodeGenerator
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmPrincipal : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.StatusBar stbInformacoes;
		private System.Windows.Forms.Panel pnlBotoesNavegacao;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Button cmdGerarArquivos;
		private System.Windows.Forms.Panel pnlBancoDados;
		private System.Windows.Forms.Panel pnlCampos;
		private System.Windows.Forms.TreeView trvTabelas;
		private System.Windows.Forms.TreeView trvTabelasSel;
		private System.Windows.Forms.Panel pnlBotoesMovimentacao;
		private System.Windows.Forms.Button cmdIncluirNodes;
		private System.Windows.Forms.Button cmdExcluirNodes;
		private System.Windows.Forms.Panel pnlCommands;
		private System.Windows.Forms.Panel pnlSaida;
		private System.Windows.Forms.Label lblNamespace;
		public System.Windows.Forms.TextBox txtNamespace;
		private System.Windows.Forms.Label lblClasse;
		public System.Windows.Forms.TextBox txtClasse;
		private System.Windows.Forms.Label lblCaminhoSaida;
		public System.Windows.Forms.TextBox txtCaminhoSaida;
		private System.Windows.Forms.Panel pnlObjetos;
		public System.Windows.Forms.CheckBox chkMapper;
		private System.Windows.Forms.Button cmdVisualizar;
		private System.Windows.Forms.RichTextBox txtPreview;
		public System.Windows.Forms.CheckBox chkEO;
		private System.Windows.Forms.ContextMenu ctxMnuPreview;
		private System.Windows.Forms.MenuItem mnuItemCopiar;
		private System.Windows.Forms.MenuItem mnuItemSalvarComo;
		public System.Windows.Forms.CheckBox chkRO;
		public System.Windows.Forms.CheckBox chkBC;
		public System.Windows.Forms.CheckBox chkDeleteCommand;
		public System.Windows.Forms.CheckBox chkUpdateCommand;
		public System.Windows.Forms.CheckBox chkInsertCommand;
		public System.Windows.Forms.CheckBox chkKeySelectCommand;
		private System.Windows.Forms.GroupBox grpBC;
		public System.Windows.Forms.CheckBox chkRemover;
		public System.Windows.Forms.CheckBox chkPersistir;
		public System.Windows.Forms.CheckBox chkObterTodos;
		public System.Windows.Forms.CheckBox chkObter;
		public System.Windows.Forms.CheckBox chkTipoSelect;
		private System.Windows.Forms.Label lblMensagem;
		private System.Windows.Forms.Panel pnlBotoesProcedure;
		private System.Windows.Forms.Button cmdIncluirNodesProcedure;
		private System.Windows.Forms.Button cmdRemoverNodesProcedure;
		private System.Windows.Forms.TreeView trvProcedures;
		private System.Windows.Forms.Panel pnlProcedures;
		private System.Windows.Forms.TabControl tabcPassos;
		private System.Windows.Forms.TabPage tabpExplorer;
		private System.Windows.Forms.TabPage tabpObjetos;
		private System.Windows.Forms.TabPage tabpOpcoes;
		private System.Windows.Forms.TabPage tabpProcedures;
		private System.Windows.Forms.TabPage tabpPreview;
		private System.Windows.Forms.TabPage tabpSaida;
		private System.Windows.Forms.TabControl tabcProcedures;
		private System.Windows.Forms.TabPage tabpSelect;
		private System.Windows.Forms.TabPage tabpInsert;
		private System.Windows.Forms.TabPage tabpUpdate;
		private System.Windows.Forms.TabPage tabpDelete;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TreeView trvSelect;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.TreeView trvInsert;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.TreeView trvUpdate;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TreeView trvDelete;
		private System.Windows.Forms.GroupBox grpMapper;
		protected static Data.DataAccess dataAccess = new Data.DataAccess();

		public frmPrincipal()
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmPrincipal));
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.stbInformacoes = new System.Windows.Forms.StatusBar();
			this.pnlBotoesNavegacao = new System.Windows.Forms.Panel();
			this.cmdVisualizar = new System.Windows.Forms.Button();
			this.cmdGerarArquivos = new System.Windows.Forms.Button();
			this.tabcPassos = new System.Windows.Forms.TabControl();
			this.tabpExplorer = new System.Windows.Forms.TabPage();
			this.pnlCampos = new System.Windows.Forms.Panel();
			this.trvTabelasSel = new System.Windows.Forms.TreeView();
			this.pnlBotoesMovimentacao = new System.Windows.Forms.Panel();
			this.cmdIncluirNodes = new System.Windows.Forms.Button();
			this.cmdExcluirNodes = new System.Windows.Forms.Button();
			this.pnlBancoDados = new System.Windows.Forms.Panel();
			this.trvTabelas = new System.Windows.Forms.TreeView();
			this.tabpObjetos = new System.Windows.Forms.TabPage();
			this.pnlObjetos = new System.Windows.Forms.Panel();
			this.chkRO = new System.Windows.Forms.CheckBox();
			this.chkEO = new System.Windows.Forms.CheckBox();
			this.chkMapper = new System.Windows.Forms.CheckBox();
			this.chkBC = new System.Windows.Forms.CheckBox();
			this.tabpOpcoes = new System.Windows.Forms.TabPage();
			this.pnlCommands = new System.Windows.Forms.Panel();
			this.grpBC = new System.Windows.Forms.GroupBox();
			this.chkTipoSelect = new System.Windows.Forms.CheckBox();
			this.chkRemover = new System.Windows.Forms.CheckBox();
			this.chkPersistir = new System.Windows.Forms.CheckBox();
			this.chkObterTodos = new System.Windows.Forms.CheckBox();
			this.chkObter = new System.Windows.Forms.CheckBox();
			this.grpMapper = new System.Windows.Forms.GroupBox();
			this.chkDeleteCommand = new System.Windows.Forms.CheckBox();
			this.chkUpdateCommand = new System.Windows.Forms.CheckBox();
			this.chkInsertCommand = new System.Windows.Forms.CheckBox();
			this.chkKeySelectCommand = new System.Windows.Forms.CheckBox();
			this.tabpProcedures = new System.Windows.Forms.TabPage();
			this.tabcProcedures = new System.Windows.Forms.TabControl();
			this.tabpSelect = new System.Windows.Forms.TabPage();
			this.panel2 = new System.Windows.Forms.Panel();
			this.trvSelect = new System.Windows.Forms.TreeView();
			this.tabpInsert = new System.Windows.Forms.TabPage();
			this.panel3 = new System.Windows.Forms.Panel();
			this.trvInsert = new System.Windows.Forms.TreeView();
			this.tabpUpdate = new System.Windows.Forms.TabPage();
			this.panel4 = new System.Windows.Forms.Panel();
			this.trvUpdate = new System.Windows.Forms.TreeView();
			this.tabpDelete = new System.Windows.Forms.TabPage();
			this.panel1 = new System.Windows.Forms.Panel();
			this.trvDelete = new System.Windows.Forms.TreeView();
			this.pnlBotoesProcedure = new System.Windows.Forms.Panel();
			this.cmdIncluirNodesProcedure = new System.Windows.Forms.Button();
			this.cmdRemoverNodesProcedure = new System.Windows.Forms.Button();
			this.pnlProcedures = new System.Windows.Forms.Panel();
			this.trvProcedures = new System.Windows.Forms.TreeView();
			this.tabpPreview = new System.Windows.Forms.TabPage();
			this.txtPreview = new System.Windows.Forms.RichTextBox();
			this.ctxMnuPreview = new System.Windows.Forms.ContextMenu();
			this.mnuItemCopiar = new System.Windows.Forms.MenuItem();
			this.mnuItemSalvarComo = new System.Windows.Forms.MenuItem();
			this.tabpSaida = new System.Windows.Forms.TabPage();
			this.pnlSaida = new System.Windows.Forms.Panel();
			this.lblNamespace = new System.Windows.Forms.Label();
			this.txtNamespace = new System.Windows.Forms.TextBox();
			this.lblClasse = new System.Windows.Forms.Label();
			this.txtClasse = new System.Windows.Forms.TextBox();
			this.lblCaminhoSaida = new System.Windows.Forms.Label();
			this.txtCaminhoSaida = new System.Windows.Forms.TextBox();
			this.lblMensagem = new System.Windows.Forms.Label();
			this.pnlBotoesNavegacao.SuspendLayout();
			this.tabcPassos.SuspendLayout();
			this.tabpExplorer.SuspendLayout();
			this.pnlCampos.SuspendLayout();
			this.pnlBotoesMovimentacao.SuspendLayout();
			this.pnlBancoDados.SuspendLayout();
			this.tabpObjetos.SuspendLayout();
			this.pnlObjetos.SuspendLayout();
			this.tabpOpcoes.SuspendLayout();
			this.pnlCommands.SuspendLayout();
			this.grpBC.SuspendLayout();
			this.grpMapper.SuspendLayout();
			this.tabpProcedures.SuspendLayout();
			this.tabcProcedures.SuspendLayout();
			this.tabpSelect.SuspendLayout();
			this.panel2.SuspendLayout();
			this.tabpInsert.SuspendLayout();
			this.panel3.SuspendLayout();
			this.tabpUpdate.SuspendLayout();
			this.panel4.SuspendLayout();
			this.tabpDelete.SuspendLayout();
			this.panel1.SuspendLayout();
			this.pnlBotoesProcedure.SuspendLayout();
			this.pnlProcedures.SuspendLayout();
			this.tabpPreview.SuspendLayout();
			this.tabpSaida.SuspendLayout();
			this.pnlSaida.SuspendLayout();
			this.SuspendLayout();
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.White;
			// 
			// stbInformacoes
			// 
			this.stbInformacoes.Location = new System.Drawing.Point(0, 438);
			this.stbInformacoes.Name = "stbInformacoes";
			this.stbInformacoes.Size = new System.Drawing.Size(640, 16);
			this.stbInformacoes.TabIndex = 0;
			// 
			// pnlBotoesNavegacao
			// 
			this.pnlBotoesNavegacao.Controls.AddRange(new System.Windows.Forms.Control[] {
																							 this.cmdVisualizar,
																							 this.cmdGerarArquivos});
			this.pnlBotoesNavegacao.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlBotoesNavegacao.Location = new System.Drawing.Point(0, 398);
			this.pnlBotoesNavegacao.Name = "pnlBotoesNavegacao";
			this.pnlBotoesNavegacao.Size = new System.Drawing.Size(640, 40);
			this.pnlBotoesNavegacao.TabIndex = 5;
			// 
			// cmdVisualizar
			// 
			this.cmdVisualizar.Location = new System.Drawing.Point(280, 8);
			this.cmdVisualizar.Name = "cmdVisualizar";
			this.cmdVisualizar.TabIndex = 0;
			this.cmdVisualizar.Text = "Visualizar";
			this.cmdVisualizar.Click += new System.EventHandler(this.cmdVisualizar_Click);
			// 
			// cmdGerarArquivos
			// 
			this.cmdGerarArquivos.Location = new System.Drawing.Point(368, 8);
			this.cmdGerarArquivos.Name = "cmdGerarArquivos";
			this.cmdGerarArquivos.Size = new System.Drawing.Size(88, 23);
			this.cmdGerarArquivos.TabIndex = 0;
			this.cmdGerarArquivos.Text = "Gerar Arquivos";
			this.cmdGerarArquivos.Click += new System.EventHandler(this.cmdGerarArquivos_Click);
			// 
			// tabcPassos
			// 
			this.tabcPassos.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.tabpExplorer,
																					 this.tabpObjetos,
																					 this.tabpOpcoes,
																					 this.tabpProcedures,
																					 this.tabpPreview,
																					 this.tabpSaida});
			this.tabcPassos.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabcPassos.Location = new System.Drawing.Point(0, 32);
			this.tabcPassos.Name = "tabcPassos";
			this.tabcPassos.SelectedIndex = 0;
			this.tabcPassos.Size = new System.Drawing.Size(640, 366);
			this.tabcPassos.TabIndex = 8;
			this.tabcPassos.SelectedIndexChanged += new System.EventHandler(this.tabcPassos_SelectedIndexChanged);
			// 
			// tabpExplorer
			// 
			this.tabpExplorer.Controls.AddRange(new System.Windows.Forms.Control[] {
																					   this.pnlCampos,
																					   this.pnlBotoesMovimentacao,
																					   this.pnlBancoDados});
			this.tabpExplorer.Location = new System.Drawing.Point(4, 22);
			this.tabpExplorer.Name = "tabpExplorer";
			this.tabpExplorer.Size = new System.Drawing.Size(632, 340);
			this.tabpExplorer.TabIndex = 0;
			this.tabpExplorer.Tag = "Seleciona a Tabela ou View que será usada como base para gerção dos Campos";
			this.tabpExplorer.Text = "Database Explorer";
			// 
			// pnlCampos
			// 
			this.pnlCampos.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.pnlCampos.BackColor = System.Drawing.Color.Silver;
			this.pnlCampos.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.trvTabelasSel});
			this.pnlCampos.Location = new System.Drawing.Point(336, 0);
			this.pnlCampos.Name = "pnlCampos";
			this.pnlCampos.Size = new System.Drawing.Size(296, 336);
			this.pnlCampos.TabIndex = 7;
			// 
			// trvTabelasSel
			// 
			this.trvTabelasSel.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.trvTabelasSel.ImageList = this.imageList1;
			this.trvTabelasSel.Location = new System.Drawing.Point(8, 6);
			this.trvTabelasSel.Name = "trvTabelasSel";
			this.trvTabelasSel.Size = new System.Drawing.Size(280, 324);
			this.trvTabelasSel.TabIndex = 10;
			// 
			// pnlBotoesMovimentacao
			// 
			this.pnlBotoesMovimentacao.Controls.AddRange(new System.Windows.Forms.Control[] {
																								this.cmdIncluirNodes,
																								this.cmdExcluirNodes});
			this.pnlBotoesMovimentacao.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlBotoesMovimentacao.Location = new System.Drawing.Point(288, 0);
			this.pnlBotoesMovimentacao.Name = "pnlBotoesMovimentacao";
			this.pnlBotoesMovimentacao.Size = new System.Drawing.Size(48, 340);
			this.pnlBotoesMovimentacao.TabIndex = 9;
			// 
			// cmdIncluirNodes
			// 
			this.cmdIncluirNodes.Location = new System.Drawing.Point(8, 16);
			this.cmdIncluirNodes.Name = "cmdIncluirNodes";
			this.cmdIncluirNodes.Size = new System.Drawing.Size(32, 23);
			this.cmdIncluirNodes.TabIndex = 0;
			this.cmdIncluirNodes.Text = ">";
			this.cmdIncluirNodes.Click += new System.EventHandler(this.cmdIncluirNodes_Click);
			// 
			// cmdExcluirNodes
			// 
			this.cmdExcluirNodes.Location = new System.Drawing.Point(8, 48);
			this.cmdExcluirNodes.Name = "cmdExcluirNodes";
			this.cmdExcluirNodes.Size = new System.Drawing.Size(32, 23);
			this.cmdExcluirNodes.TabIndex = 0;
			this.cmdExcluirNodes.Text = "<";
			this.cmdExcluirNodes.Click += new System.EventHandler(this.cmdExcluirNodes_Click);
			// 
			// pnlBancoDados
			// 
			this.pnlBancoDados.BackColor = System.Drawing.Color.Gray;
			this.pnlBancoDados.Controls.AddRange(new System.Windows.Forms.Control[] {
																						this.trvTabelas});
			this.pnlBancoDados.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlBancoDados.Name = "pnlBancoDados";
			this.pnlBancoDados.Size = new System.Drawing.Size(288, 340);
			this.pnlBancoDados.TabIndex = 8;
			// 
			// trvTabelas
			// 
			this.trvTabelas.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.trvTabelas.ImageList = this.imageList1;
			this.trvTabelas.Location = new System.Drawing.Point(8, 8);
			this.trvTabelas.Name = "trvTabelas";
			this.trvTabelas.Size = new System.Drawing.Size(272, 320);
			this.trvTabelas.TabIndex = 4;
			// 
			// tabpObjetos
			// 
			this.tabpObjetos.Controls.AddRange(new System.Windows.Forms.Control[] {
																					  this.pnlObjetos});
			this.tabpObjetos.Location = new System.Drawing.Point(4, 22);
			this.tabpObjetos.Name = "tabpObjetos";
			this.tabpObjetos.Size = new System.Drawing.Size(632, 340);
			this.tabpObjetos.TabIndex = 2;
			this.tabpObjetos.Tag = "Check os objetos que deseja Gerar";
			this.tabpObjetos.Text = "Objetos";
			// 
			// pnlObjetos
			// 
			this.pnlObjetos.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.chkRO,
																					 this.chkEO,
																					 this.chkMapper,
																					 this.chkBC});
			this.pnlObjetos.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlObjetos.Name = "pnlObjetos";
			this.pnlObjetos.Size = new System.Drawing.Size(632, 340);
			this.pnlObjetos.TabIndex = 0;
			// 
			// chkRO
			// 
			this.chkRO.Checked = true;
			this.chkRO.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkRO.Location = new System.Drawing.Point(16, 144);
			this.chkRO.Name = "chkRO";
			this.chkRO.Size = new System.Drawing.Size(160, 24);
			this.chkRO.TabIndex = 15;
			this.chkRO.Text = "Gera Arquivo RO";
			// 
			// chkEO
			// 
			this.chkEO.Checked = true;
			this.chkEO.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkEO.Location = new System.Drawing.Point(16, 104);
			this.chkEO.Name = "chkEO";
			this.chkEO.Size = new System.Drawing.Size(160, 24);
			this.chkEO.TabIndex = 14;
			this.chkEO.Text = "Gera Arquivo EO";
			// 
			// chkMapper
			// 
			this.chkMapper.Checked = true;
			this.chkMapper.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkMapper.Location = new System.Drawing.Point(16, 64);
			this.chkMapper.Name = "chkMapper";
			this.chkMapper.Size = new System.Drawing.Size(160, 24);
			this.chkMapper.TabIndex = 13;
			this.chkMapper.Text = "Gerar Arquivo Mapper";
			this.chkMapper.CheckedChanged += new System.EventHandler(this.chkMapper_CheckedChanged);
			// 
			// chkBC
			// 
			this.chkBC.Checked = true;
			this.chkBC.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkBC.Location = new System.Drawing.Point(16, 24);
			this.chkBC.Name = "chkBC";
			this.chkBC.Size = new System.Drawing.Size(160, 24);
			this.chkBC.TabIndex = 13;
			this.chkBC.Text = "Gerar Arquivo BC";
			this.chkBC.CheckedChanged += new System.EventHandler(this.chkBC_CheckedChanged);
			// 
			// tabpOpcoes
			// 
			this.tabpOpcoes.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.pnlCommands});
			this.tabpOpcoes.Location = new System.Drawing.Point(4, 22);
			this.tabpOpcoes.Name = "tabpOpcoes";
			this.tabpOpcoes.Size = new System.Drawing.Size(632, 340);
			this.tabpOpcoes.TabIndex = 1;
			this.tabpOpcoes.Tag = "Check os itens que deseja Gerar para cada um dos objetos";
			this.tabpOpcoes.Text = "Opções de Objetos";
			// 
			// pnlCommands
			// 
			this.pnlCommands.Controls.AddRange(new System.Windows.Forms.Control[] {
																					  this.grpBC,
																					  this.grpMapper});
			this.pnlCommands.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlCommands.Name = "pnlCommands";
			this.pnlCommands.Size = new System.Drawing.Size(632, 340);
			this.pnlCommands.TabIndex = 0;
			// 
			// grpBC
			// 
			this.grpBC.Controls.AddRange(new System.Windows.Forms.Control[] {
																				this.chkTipoSelect,
																				this.chkRemover,
																				this.chkPersistir,
																				this.chkObterTodos,
																				this.chkObter});
			this.grpBC.Location = new System.Drawing.Point(216, 16);
			this.grpBC.Name = "grpBC";
			this.grpBC.Size = new System.Drawing.Size(400, 216);
			this.grpBC.TabIndex = 19;
			this.grpBC.TabStop = false;
			this.grpBC.Text = "Opções do BC";
			// 
			// chkTipoSelect
			// 
			this.chkTipoSelect.Location = new System.Drawing.Point(192, 32);
			this.chkTipoSelect.Name = "chkTipoSelect";
			this.chkTipoSelect.Size = new System.Drawing.Size(184, 24);
			this.chkTipoSelect.TabIndex = 28;
			this.chkTipoSelect.Text = "Usar procedure para Select";
			this.chkTipoSelect.Visible = false;
			// 
			// chkRemover
			// 
			this.chkRemover.Checked = true;
			this.chkRemover.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkRemover.Location = new System.Drawing.Point(28, 156);
			this.chkRemover.Name = "chkRemover";
			this.chkRemover.Size = new System.Drawing.Size(144, 24);
			this.chkRemover.TabIndex = 25;
			this.chkRemover.Text = "Metodo Remover";
			// 
			// chkPersistir
			// 
			this.chkPersistir.Checked = true;
			this.chkPersistir.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkPersistir.Location = new System.Drawing.Point(28, 116);
			this.chkPersistir.Name = "chkPersistir";
			this.chkPersistir.Size = new System.Drawing.Size(144, 24);
			this.chkPersistir.TabIndex = 24;
			this.chkPersistir.Text = "Metodo Persistir";
			// 
			// chkObterTodos
			// 
			this.chkObterTodos.Checked = true;
			this.chkObterTodos.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkObterTodos.Location = new System.Drawing.Point(28, 76);
			this.chkObterTodos.Name = "chkObterTodos";
			this.chkObterTodos.Size = new System.Drawing.Size(144, 24);
			this.chkObterTodos.TabIndex = 23;
			this.chkObterTodos.Text = "Metodo ObterTodos";
			// 
			// chkObter
			// 
			this.chkObter.Checked = true;
			this.chkObter.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkObter.Location = new System.Drawing.Point(28, 36);
			this.chkObter.Name = "chkObter";
			this.chkObter.Size = new System.Drawing.Size(144, 24);
			this.chkObter.TabIndex = 22;
			this.chkObter.Text = "Metodo Obter";
			// 
			// grpMapper
			// 
			this.grpMapper.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.chkDeleteCommand,
																					this.chkUpdateCommand,
																					this.chkInsertCommand,
																					this.chkKeySelectCommand});
			this.grpMapper.Location = new System.Drawing.Point(16, 16);
			this.grpMapper.Name = "grpMapper";
			this.grpMapper.Size = new System.Drawing.Size(184, 216);
			this.grpMapper.TabIndex = 18;
			this.grpMapper.TabStop = false;
			this.grpMapper.Text = "Opções de Mapper";
			// 
			// chkDeleteCommand
			// 
			this.chkDeleteCommand.Checked = true;
			this.chkDeleteCommand.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkDeleteCommand.Location = new System.Drawing.Point(28, 160);
			this.chkDeleteCommand.Name = "chkDeleteCommand";
			this.chkDeleteCommand.Size = new System.Drawing.Size(144, 24);
			this.chkDeleteCommand.TabIndex = 21;
			this.chkDeleteCommand.Text = "Delete Command";
			this.chkDeleteCommand.CheckedChanged += new System.EventHandler(this.chkDeleteCommand_CheckedChanged);
			// 
			// chkUpdateCommand
			// 
			this.chkUpdateCommand.Checked = true;
			this.chkUpdateCommand.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkUpdateCommand.Location = new System.Drawing.Point(28, 120);
			this.chkUpdateCommand.Name = "chkUpdateCommand";
			this.chkUpdateCommand.Size = new System.Drawing.Size(144, 24);
			this.chkUpdateCommand.TabIndex = 20;
			this.chkUpdateCommand.Text = "Update Command";
			this.chkUpdateCommand.CheckedChanged += new System.EventHandler(this.chkUpdateCommand_CheckedChanged);
			// 
			// chkInsertCommand
			// 
			this.chkInsertCommand.Checked = true;
			this.chkInsertCommand.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkInsertCommand.Location = new System.Drawing.Point(28, 80);
			this.chkInsertCommand.Name = "chkInsertCommand";
			this.chkInsertCommand.Size = new System.Drawing.Size(144, 24);
			this.chkInsertCommand.TabIndex = 19;
			this.chkInsertCommand.Text = "Insert Command";
			this.chkInsertCommand.CheckedChanged += new System.EventHandler(this.chkInsertCommand_CheckedChanged);
			// 
			// chkKeySelectCommand
			// 
			this.chkKeySelectCommand.Checked = true;
			this.chkKeySelectCommand.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkKeySelectCommand.Location = new System.Drawing.Point(28, 40);
			this.chkKeySelectCommand.Name = "chkKeySelectCommand";
			this.chkKeySelectCommand.Size = new System.Drawing.Size(144, 24);
			this.chkKeySelectCommand.TabIndex = 18;
			this.chkKeySelectCommand.Text = "Select Command";
			this.chkKeySelectCommand.CheckedChanged += new System.EventHandler(this.chkKeySelectCommand_CheckedChanged);
			// 
			// tabpProcedures
			// 
			this.tabpProcedures.Controls.AddRange(new System.Windows.Forms.Control[] {
																						 this.tabcProcedures,
																						 this.pnlBotoesProcedure,
																						 this.pnlProcedures});
			this.tabpProcedures.Location = new System.Drawing.Point(4, 22);
			this.tabpProcedures.Name = "tabpProcedures";
			this.tabpProcedures.Size = new System.Drawing.Size(632, 340);
			this.tabpProcedures.TabIndex = 5;
			this.tabpProcedures.Tag = "Seleciona a Procedure que deseja utilizar, na aba direito seleciona o Tipo de Pro" +
				"cedure, e entao adicione o item";
			this.tabpProcedures.Text = "Procedures";
			// 
			// tabcProcedures
			// 
			this.tabcProcedures.Alignment = System.Windows.Forms.TabAlignment.Left;
			this.tabcProcedures.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.tabcProcedures.Controls.AddRange(new System.Windows.Forms.Control[] {
																						 this.tabpSelect,
																						 this.tabpInsert,
																						 this.tabpUpdate,
																						 this.tabpDelete});
			this.tabcProcedures.Location = new System.Drawing.Point(296, 8);
			this.tabcProcedures.Multiline = true;
			this.tabcProcedures.Name = "tabcProcedures";
			this.tabcProcedures.SelectedIndex = 0;
			this.tabcProcedures.Size = new System.Drawing.Size(328, 320);
			this.tabcProcedures.TabIndex = 11;
			// 
			// tabpSelect
			// 
			this.tabpSelect.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.panel2});
			this.tabpSelect.Location = new System.Drawing.Point(23, 4);
			this.tabpSelect.Name = "tabpSelect";
			this.tabpSelect.Size = new System.Drawing.Size(301, 312);
			this.tabpSelect.TabIndex = 0;
			this.tabpSelect.Text = "Select";
			// 
			// panel2
			// 
			this.panel2.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.panel2.BackColor = System.Drawing.Color.DarkGray;
			this.panel2.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.trvSelect});
			this.panel2.Location = new System.Drawing.Point(-2, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(304, 312);
			this.panel2.TabIndex = 11;
			// 
			// trvSelect
			// 
			this.trvSelect.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.trvSelect.ImageList = this.imageList1;
			this.trvSelect.Location = new System.Drawing.Point(8, 8);
			this.trvSelect.Name = "trvSelect";
			this.trvSelect.Size = new System.Drawing.Size(288, 296);
			this.trvSelect.TabIndex = 4;
			// 
			// tabpInsert
			// 
			this.tabpInsert.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.panel3});
			this.tabpInsert.Location = new System.Drawing.Point(23, 4);
			this.tabpInsert.Name = "tabpInsert";
			this.tabpInsert.Size = new System.Drawing.Size(301, 312);
			this.tabpInsert.TabIndex = 1;
			this.tabpInsert.Text = "Insert";
			// 
			// panel3
			// 
			this.panel3.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.panel3.BackColor = System.Drawing.Color.DarkGray;
			this.panel3.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.trvInsert});
			this.panel3.Location = new System.Drawing.Point(-2, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(304, 312);
			this.panel3.TabIndex = 11;
			// 
			// trvInsert
			// 
			this.trvInsert.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.trvInsert.ImageList = this.imageList1;
			this.trvInsert.Location = new System.Drawing.Point(8, 8);
			this.trvInsert.Name = "trvInsert";
			this.trvInsert.Size = new System.Drawing.Size(288, 296);
			this.trvInsert.TabIndex = 4;
			// 
			// tabpUpdate
			// 
			this.tabpUpdate.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.panel4});
			this.tabpUpdate.Location = new System.Drawing.Point(23, 4);
			this.tabpUpdate.Name = "tabpUpdate";
			this.tabpUpdate.Size = new System.Drawing.Size(301, 312);
			this.tabpUpdate.TabIndex = 2;
			this.tabpUpdate.Text = "Update";
			// 
			// panel4
			// 
			this.panel4.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.panel4.BackColor = System.Drawing.Color.DarkGray;
			this.panel4.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.trvUpdate});
			this.panel4.Location = new System.Drawing.Point(-2, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(304, 312);
			this.panel4.TabIndex = 11;
			// 
			// trvUpdate
			// 
			this.trvUpdate.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.trvUpdate.ImageList = this.imageList1;
			this.trvUpdate.Location = new System.Drawing.Point(8, 8);
			this.trvUpdate.Name = "trvUpdate";
			this.trvUpdate.Size = new System.Drawing.Size(288, 296);
			this.trvUpdate.TabIndex = 4;
			// 
			// tabpDelete
			// 
			this.tabpDelete.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.panel1});
			this.tabpDelete.Location = new System.Drawing.Point(23, 4);
			this.tabpDelete.Name = "tabpDelete";
			this.tabpDelete.Size = new System.Drawing.Size(301, 312);
			this.tabpDelete.TabIndex = 3;
			this.tabpDelete.Text = "Delete";
			// 
			// panel1
			// 
			this.panel1.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.panel1.BackColor = System.Drawing.Color.DarkGray;
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.trvDelete});
			this.panel1.Location = new System.Drawing.Point(-2, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(304, 312);
			this.panel1.TabIndex = 12;
			// 
			// trvDelete
			// 
			this.trvDelete.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.trvDelete.ImageList = this.imageList1;
			this.trvDelete.Location = new System.Drawing.Point(8, 8);
			this.trvDelete.Name = "trvDelete";
			this.trvDelete.Size = new System.Drawing.Size(288, 296);
			this.trvDelete.TabIndex = 4;
			// 
			// pnlBotoesProcedure
			// 
			this.pnlBotoesProcedure.Controls.AddRange(new System.Windows.Forms.Control[] {
																							 this.cmdIncluirNodesProcedure,
																							 this.cmdRemoverNodesProcedure});
			this.pnlBotoesProcedure.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlBotoesProcedure.Location = new System.Drawing.Point(248, 0);
			this.pnlBotoesProcedure.Name = "pnlBotoesProcedure";
			this.pnlBotoesProcedure.Size = new System.Drawing.Size(48, 340);
			this.pnlBotoesProcedure.TabIndex = 10;
			// 
			// cmdIncluirNodesProcedure
			// 
			this.cmdIncluirNodesProcedure.Location = new System.Drawing.Point(8, 16);
			this.cmdIncluirNodesProcedure.Name = "cmdIncluirNodesProcedure";
			this.cmdIncluirNodesProcedure.Size = new System.Drawing.Size(32, 23);
			this.cmdIncluirNodesProcedure.TabIndex = 0;
			this.cmdIncluirNodesProcedure.Text = ">";
			this.cmdIncluirNodesProcedure.Click += new System.EventHandler(this.cmdIncluirNodesProcedure_Click);
			// 
			// cmdRemoverNodesProcedure
			// 
			this.cmdRemoverNodesProcedure.Location = new System.Drawing.Point(8, 48);
			this.cmdRemoverNodesProcedure.Name = "cmdRemoverNodesProcedure";
			this.cmdRemoverNodesProcedure.Size = new System.Drawing.Size(32, 23);
			this.cmdRemoverNodesProcedure.TabIndex = 0;
			this.cmdRemoverNodesProcedure.Text = "<";
			this.cmdRemoverNodesProcedure.Click += new System.EventHandler(this.cmdRemoverNodesProcedure_Click);
			// 
			// pnlProcedures
			// 
			this.pnlProcedures.BackColor = System.Drawing.Color.Gray;
			this.pnlProcedures.Controls.AddRange(new System.Windows.Forms.Control[] {
																						this.trvProcedures});
			this.pnlProcedures.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlProcedures.Name = "pnlProcedures";
			this.pnlProcedures.Size = new System.Drawing.Size(248, 340);
			this.pnlProcedures.TabIndex = 9;
			// 
			// trvProcedures
			// 
			this.trvProcedures.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.trvProcedures.ImageList = this.imageList1;
			this.trvProcedures.Location = new System.Drawing.Point(8, 8);
			this.trvProcedures.Name = "trvProcedures";
			this.trvProcedures.Size = new System.Drawing.Size(232, 320);
			this.trvProcedures.TabIndex = 4;
			// 
			// tabpPreview
			// 
			this.tabpPreview.Controls.AddRange(new System.Windows.Forms.Control[] {
																					  this.txtPreview});
			this.tabpPreview.Location = new System.Drawing.Point(4, 22);
			this.tabpPreview.Name = "tabpPreview";
			this.tabpPreview.Size = new System.Drawing.Size(632, 340);
			this.tabpPreview.TabIndex = 3;
			this.tabpPreview.Tag = "Previsualização do Arquivo final.";
			this.tabpPreview.Text = "Preview";
			// 
			// txtPreview
			// 
			this.txtPreview.AcceptsTab = true;
			this.txtPreview.AutoSize = true;
			this.txtPreview.CausesValidation = false;
			this.txtPreview.ContextMenu = this.ctxMnuPreview;
			this.txtPreview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtPreview.Name = "txtPreview";
			this.txtPreview.ShowSelectionMargin = true;
			this.txtPreview.Size = new System.Drawing.Size(632, 340);
			this.txtPreview.TabIndex = 0;
			this.txtPreview.Text = "";
			this.txtPreview.WordWrap = false;
			// 
			// ctxMnuPreview
			// 
			this.ctxMnuPreview.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						  this.mnuItemCopiar,
																						  this.mnuItemSalvarComo});
			// 
			// mnuItemCopiar
			// 
			this.mnuItemCopiar.Index = 0;
			this.mnuItemCopiar.Text = "Copiar";
			this.mnuItemCopiar.Click += new System.EventHandler(this.mnuItemCopiar_Click);
			// 
			// mnuItemSalvarComo
			// 
			this.mnuItemSalvarComo.Index = 1;
			this.mnuItemSalvarComo.Text = "Salvar Como";
			// 
			// tabpSaida
			// 
			this.tabpSaida.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.pnlSaida});
			this.tabpSaida.Location = new System.Drawing.Point(4, 22);
			this.tabpSaida.Name = "tabpSaida";
			this.tabpSaida.Size = new System.Drawing.Size(632, 340);
			this.tabpSaida.TabIndex = 4;
			this.tabpSaida.Tag = "Digite o Caminho de Saida do arquivo, o nome do Namespace e o nome da Clase e cli" +
				"que no botão Gerar Arquivo";
			this.tabpSaida.Text = "Saida";
			// 
			// pnlSaida
			// 
			this.pnlSaida.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.lblNamespace,
																				   this.txtNamespace,
																				   this.lblClasse,
																				   this.txtClasse,
																				   this.lblCaminhoSaida,
																				   this.txtCaminhoSaida});
			this.pnlSaida.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlSaida.Name = "pnlSaida";
			this.pnlSaida.Size = new System.Drawing.Size(632, 340);
			this.pnlSaida.TabIndex = 0;
			// 
			// lblNamespace
			// 
			this.lblNamespace.Location = new System.Drawing.Point(16, 16);
			this.lblNamespace.Name = "lblNamespace";
			this.lblNamespace.Size = new System.Drawing.Size(100, 16);
			this.lblNamespace.TabIndex = 17;
			this.lblNamespace.Text = "Namespace";
			// 
			// txtNamespace
			// 
			this.txtNamespace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtNamespace.Location = new System.Drawing.Point(120, 16);
			this.txtNamespace.Name = "txtNamespace";
			this.txtNamespace.Size = new System.Drawing.Size(336, 20);
			this.txtNamespace.TabIndex = 8;
			this.txtNamespace.Text = "";
			// 
			// lblClasse
			// 
			this.lblClasse.Location = new System.Drawing.Point(16, 48);
			this.lblClasse.Name = "lblClasse";
			this.lblClasse.Size = new System.Drawing.Size(100, 16);
			this.lblClasse.TabIndex = 15;
			this.lblClasse.Text = "Classe";
			// 
			// txtClasse
			// 
			this.txtClasse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtClasse.Location = new System.Drawing.Point(120, 48);
			this.txtClasse.Name = "txtClasse";
			this.txtClasse.Size = new System.Drawing.Size(336, 20);
			this.txtClasse.TabIndex = 9;
			this.txtClasse.Text = "";
			// 
			// lblCaminhoSaida
			// 
			this.lblCaminhoSaida.Location = new System.Drawing.Point(16, 80);
			this.lblCaminhoSaida.Name = "lblCaminhoSaida";
			this.lblCaminhoSaida.Size = new System.Drawing.Size(100, 16);
			this.lblCaminhoSaida.TabIndex = 10;
			this.lblCaminhoSaida.Text = "Caminho de Saida: ";
			// 
			// txtCaminhoSaida
			// 
			this.txtCaminhoSaida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtCaminhoSaida.Location = new System.Drawing.Point(120, 80);
			this.txtCaminhoSaida.Name = "txtCaminhoSaida";
			this.txtCaminhoSaida.Size = new System.Drawing.Size(336, 20);
			this.txtCaminhoSaida.TabIndex = 11;
			this.txtCaminhoSaida.Text = "";
			// 
			// lblMensagem
			// 
			this.lblMensagem.BackColor = System.Drawing.Color.White;
			this.lblMensagem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMensagem.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblMensagem.Name = "lblMensagem";
			this.lblMensagem.Size = new System.Drawing.Size(640, 32);
			this.lblMensagem.TabIndex = 9;
			this.lblMensagem.Text = "Favor selecionar a Tabela ou View que deseja utilizar para geraração dos Objetos." +
				"";
			// 
			// frmPrincipal
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(640, 454);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.tabcPassos,
																		  this.pnlBotoesNavegacao,
																		  this.stbInformacoes,
																		  this.lblMensagem});
			this.Name = "frmPrincipal";
			this.Text = "Code Generator";
			this.Load += new System.EventHandler(this.frmPrincipal_Load);
			this.pnlBotoesNavegacao.ResumeLayout(false);
			this.tabcPassos.ResumeLayout(false);
			this.tabpExplorer.ResumeLayout(false);
			this.pnlCampos.ResumeLayout(false);
			this.pnlBotoesMovimentacao.ResumeLayout(false);
			this.pnlBancoDados.ResumeLayout(false);
			this.tabpObjetos.ResumeLayout(false);
			this.pnlObjetos.ResumeLayout(false);
			this.tabpOpcoes.ResumeLayout(false);
			this.pnlCommands.ResumeLayout(false);
			this.grpBC.ResumeLayout(false);
			this.grpMapper.ResumeLayout(false);
			this.tabpProcedures.ResumeLayout(false);
			this.tabcProcedures.ResumeLayout(false);
			this.tabpSelect.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.tabpInsert.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.tabpUpdate.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.tabpDelete.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.pnlBotoesProcedure.ResumeLayout(false);
			this.pnlProcedures.ResumeLayout(false);
			this.tabpPreview.ResumeLayout(false);
			this.tabpSaida.ResumeLayout(false);
			this.pnlSaida.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmPrincipal());
		}

		private void frmPrincipal_Load(object sender, System.EventArgs e)
		{
			
			// Carrega as configuraçoes padrões
			Configuracao configuracao = new Configuracao();
			this.txtCaminhoSaida.Text = configuracao.ObterParametroDoXML("caminhosaida");
			this.txtNamespace.Text = configuracao.ObterParametroDoXML("namespace");

			CarregarTreeView();

			CarregarTreeViewProcedures();

		}

		private void CarregarTreeView()
		{

			NpgsqlConnection conn = dataAccess.GetConnection(dataAccess.GetConnectionString());
			try
			{
				DataTable dttGlobalName = new DataTable();
                NpgsqlDataReader dtrUserTables;
				NpgsqlDataReader dtrUserViews;
				NpgsqlDataReader dtrUserTabColumns;
				
				dttGlobalName = dataAccess.GetSelectCommand(conn,"SELECT * FROM GLOBAL_NAME");
				dtrUserTables = dataAccess.GetSelectDataReader("SELECT * FROM USER_TABLES");
				dtrUserViews =  dataAccess.GetSelectDataReader("SELECT * FROM USER_VIEWS");

				// ----------------------------------------------------
				// Adiciona o nó do Banco de Dados					  -
				// ----------------------------------------------------
				TreeNode NoPai = new TreeNode();
				NoPai.ImageIndex = 1;
				NoPai.SelectedImageIndex = 1;
				NoPai.Text = Convert.ToString(dttGlobalName.Rows[0][0]);
				NoPai.Tag = NoPai.Text;
				
				trvTabelas.Nodes.Add(NoPai);


				// ----------------------------------------------------
				// Adiciona os Nós das Tabelas   					  -
				// ----------------------------------------------------
				while(dtrUserTables.Read())
				{
					TreeNode NoFilho = new TreeNode();
					NoFilho.ImageIndex = 2;
					NoFilho.SelectedImageIndex = 2;
					NoFilho.Text = Convert.ToString(dtrUserTables["TABLE_NAME"]);
					NoFilho.Tag = NoPai.Text + "." + NoFilho.Text;

					// ----------------------------------------------------
					// Adiciona os Nós dos Campos   					  -
					// ----------------------------------------------------
					dtrUserTabColumns = dataAccess.GetSelectDataReader(conn,"SELECT A.TABLE_NAME, A.COLUMN_NAME, A.DATA_TYPE, A.DATA_LENGTH, A.DATA_PRECISION, A.DATA_SCALE FROM DBA_TAB_COLUMNS A WHERE A.TABLE_NAME = '" + NoFilho.Text + "'");

					while(dtrUserTabColumns.Read())
					{
						TreeNode NoNeto = new TreeNode();
						NoNeto.ImageIndex = 3;
						NoNeto.SelectedImageIndex = 3;
						NoNeto.Text = Convert.ToString(dtrUserTabColumns["COLUMN_NAME"]);
						//NoNeto.Tag = NoPai.Text + "." + NoFilho.Text + "." + NoNeto.Text;
						NoNeto.Tag = Convert.ToString(dtrUserTabColumns["DATA_TYPE"]) + "|" + Convert.ToString(dtrUserTabColumns["DATA_LENGTH"]) + "|" + Convert.ToString(dtrUserTabColumns["DATA_SCALE"]);
						
						NoFilho.Nodes.Add(NoNeto);

					}

					dtrUserTabColumns.Close();
					dtrUserTabColumns = null;

//					foreach(DataRow LinhaNeto in dttUserTabColumns.Rows)
//					{
//
//						TreeNode NoNeto = new TreeNode();
//						NoNeto.ImageIndex = 3;
//						NoNeto.SelectedImageIndex = 3;
//						NoNeto.Text = Convert.ToString(LinhaNeto["COLUMN_NAME"]);
//						//NoNeto.Tag = NoPai.Text + "." + NoFilho.Text + "." + NoNeto.Text;
//						NoNeto.Tag = Convert.ToString(LinhaNeto["DATA_TYPE"]) + "|" + Convert.ToString(LinhaNeto["DATA_LENGTH"]);
//						
//						NoFilho.Nodes.Add(NoNeto);
//
//					}
					
					trvTabelas.Nodes[0].Nodes.Add(NoFilho);

				}

				dtrUserTables.Close();
				dtrUserTables = null;
				
				// ----------------------------------------------------
				// Adiciona os Nós das Views   					  -
				// ----------------------------------------------------
				while(dtrUserViews.Read())
				{
					TreeNode NoFilho = new TreeNode();
					NoFilho.ImageIndex = 2;
					NoFilho.SelectedImageIndex = 2;
					NoFilho.Text = Convert.ToString(dtrUserViews["VIEW_NAME"]);
					NoFilho.Tag = NoPai.Text + "." + NoFilho.Text;

					// ----------------------------------------------------
					// Adiciona os Nós dos Campos   					  -
					// ----------------------------------------------------
					dtrUserTabColumns = dataAccess.GetSelectDataReader(conn,"SELECT A.TABLE_NAME, A.COLUMN_NAME, A.DATA_TYPE, A.DATA_LENGTH, A.DATA_PRECISION, A.DATA_SCALE FROM DBA_TAB_COLUMNS A WHERE A.TABLE_NAME = '" + NoFilho.Text + "'");
					
					while(dtrUserTabColumns.Read())
					{

						TreeNode NoNeto = new TreeNode();
						NoNeto.ImageIndex = 3;
						NoNeto.SelectedImageIndex = 3;
						NoNeto.Text = Convert.ToString(dtrUserTabColumns["COLUMN_NAME"]);
						//NoNeto.Tag = NoPai.Text + "." + NoFilho.Text + "." + NoNeto.Text;
						NoNeto.Tag = Convert.ToString(dtrUserTabColumns["DATA_TYPE"]) + "|" + Convert.ToString(dtrUserTabColumns["DATA_LENGTH"]) + "|" + Convert.ToString(dtrUserTabColumns["DATA_SCALE"]);

						NoFilho.Nodes.Add(NoNeto);

					}

					dtrUserTabColumns.Close();
					dtrUserTabColumns = null;
					
					trvTabelas.Nodes[0].Nodes.Add(NoFilho);

				}

				dtrUserViews.Close();
				dtrUserViews = null;


			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message,ex);
			}
			finally
			{
				dataAccess.CloseConnection(conn);
			}
			
		}


		private void CarregarTreeViewProcedures()
		{

			NpgsqlConnection conn = dataAccess.GetConnection(dataAccess.GetConnectionString());
			try
			{
				DataTable dttGlobalName = new DataTable();
				NpgsqlDataReader dtrProcedures;
				NpgsqlDataReader dtrParameters;
				
				dttGlobalName = dataAccess.GetSelectCommand(conn,"SELECT * FROM GLOBAL_NAME");
				dtrProcedures = dataAccess.GetSelectDataReader("SELECT A.OBJECT_NAME, A.PROCEDURE_NAME FROM USER_PROCEDURES A");

				// ----------------------------------------------------
				// Adiciona o nó do Banco de Dados					  -
				// ----------------------------------------------------
				TreeNode NoPai = new TreeNode();
				NoPai.ImageIndex = 1;
				NoPai.SelectedImageIndex = 1;
				NoPai.Text = Convert.ToString(dttGlobalName.Rows[0][0]);
				NoPai.Tag = NoPai.Text;
				
				trvProcedures.Nodes.Add(NoPai);


				// ----------------------------------------------------
				// Adiciona os Nós das Procedures  					  -
				// ----------------------------------------------------
				while(dtrProcedures.Read())
				{
					
					// PARA O ORACLE O CAMPO OBJECT_NAME E USADO TANTO PARA INFORMAR O 
					// NOME DA PACKAGE OU O NOME DA PROCEDURE,
					// QUANDO EXISTE APENAS A PROCEDURE ENTAO O OBJECT NAME SERA O NOME DA PROCEDURE

					
					string strNomePackage = Convert.ToString(dtrProcedures["OBJECT_NAME"]);
					string strNomeProcedure = Convert.ToString(dtrProcedures["PROCEDURE_NAME"]);
					string strNomeNode =  strNomeProcedure == ""?strNomePackage:strNomePackage + "." + strNomeProcedure;
					string strQueryParameters = "";

					TreeNode NoFilho = new TreeNode();
					NoFilho.ImageIndex = 2;
					NoFilho.SelectedImageIndex = 2;
					NoFilho.Text = strNomeNode;
					NoFilho.Tag = NoPai.Text + "." + NoFilho.Text;

					// ----------------------------------------------------
					// Adiciona os Nós dos Campos   					  -
					// ----------------------------------------------------
					if(strNomePackage != "" && strNomeProcedure.Trim() == "")
					{
						strQueryParameters = "SELECT PACKAGE_NAME,OBJECT_NAME,ARGUMENT_NAME, A.DATA_TYPE, A.DATA_LENGTH, A.DATA_SCALE, A.IN_OUT FROM ALL_ARGUMENTS A WHERE OBJECT_NAME = '" + strNomePackage + "'";
					}
					else 
					{
						strQueryParameters = "SELECT PACKAGE_NAME,OBJECT_NAME,ARGUMENT_NAME, A.DATA_TYPE, A.DATA_LENGTH,A.DATA_SCALE, A.IN_OUT FROM ALL_ARGUMENTS A WHERE PACKAGE_NAME = '" + strNomePackage + "' AND OBJECT_NAME= '" + strNomeProcedure + "'";
					}

					dtrParameters = dataAccess.GetSelectDataReader(conn,strQueryParameters);

					while(dtrParameters.Read())
					{

						TreeNode NoNeto = new TreeNode();
						NoNeto.ImageIndex = 3;
						NoNeto.SelectedImageIndex = 3;
						NoNeto.Text = Convert.ToString(dtrParameters["ARGUMENT_NAME"]);
						//NoNeto.Tag = NoPai.Text + "." + NoFilho.Text + "." + NoNeto.Text;
						NoNeto.Tag = Convert.ToString(dtrParameters["DATA_TYPE"]) + "|" + Convert.ToString(dtrParameters["DATA_LENGTH"]) + "|" + Convert.ToString(dtrParameters["DATA_SCALE"]) + "|" + Convert.ToString(dtrParameters["IN_OUT"]);
						
						NoFilho.Nodes.Add(NoNeto);

					}

					dtrParameters.Close();
					dtrParameters = null;

					trvProcedures.Nodes[0].Nodes.Add(NoFilho);

				}

				dtrProcedures.Close();
				dtrProcedures = null;

			}
			catch(Exception ex)
			{
				throw ex;
			}
			finally
			{
				dataAccess.CloseConnection(conn);
			}
			
		}


		private void cmdIncluirNodes_Click(object sender, System.EventArgs e)
		{
			// add selected items from treeview to the listview on the right hand side
			TreeNode n1 = (TreeNode)trvTabelas.SelectedNode.Clone();
			trvTabelasSel.Nodes.Add(n1);
			this.txtClasse.Text = n1.Text.Replace("|","");
		}

		private void cmdExcluirNodes_Click(object sender, System.EventArgs e)
		{
			trvTabelasSel.Nodes.Remove(trvTabelasSel.SelectedNode);
		}

		private void cmdGerarArquivos_Click(object sender, System.EventArgs e)
		{
			if(this.txtNamespace.Text == "")
			{
				MessageBox.Show("Obrigatório digitar um Namespace");
				this.txtNamespace.Focus();
			}
			else if(this.txtClasse.Text == "")
			{
				MessageBox.Show("Obrigatório digitar um nome para a Classe");
				this.txtClasse.Focus();
			}
			else if(this.txtCaminhoSaida.Text == "")
			{
				MessageBox.Show("Obrigatório digitar um caminho de Saída para geração do Arquivo");
				this.txtCaminhoSaida.Focus();
			}
			else if(!System.IO.Directory.Exists(this.txtCaminhoSaida.Text))
			{
				MessageBox.Show("Caminho de Sáida Inválido ou Inexistênte");
				this.txtCaminhoSaida.Focus();
			}  
			else
			{
				this.Arquivo();
			}
			
		}

		private string Arquivo()
		{
			return this.Arquivo(false);
		}

		private string Arquivo(bool visualizar_)
		{
			
			string strRetorno = "";
			
			if(this.trvTabelasSel.Nodes.Count == 0)
			{
				MessageBox.Show("Selecione uma tabela ou view");
			}
			else if(this.trvTabelasSel.Nodes.Count > 1)
			{
				MessageBox.Show("É permitido selecionar apenas uma tabela");
			}
			else if(this.chkMapper.Checked && this.chkInsertCommand.Checked && 
				this.trvInsert.Nodes.Count == 0)
			{
				MessageBox.Show("Você selecinou Gerar Command Insert, obrigatorio selecionar a procedure a ser usada");
			}
			else if(this.chkMapper.Checked && this.chkInsertCommand.Checked && 
				this.trvInsert.Nodes.Count > 1)
			{
				MessageBox.Show("Você selecinou Mais de uma procedure para o comando Insert, obrigatório apenas uma procedure");
			}
			else if(this.chkMapper.Checked && this.chkUpdateCommand.Checked && 
				this.trvUpdate.Nodes.Count == 0)
			{
				MessageBox.Show("Você selecinou Gerar Command Update, obrigatorio selecionar a procedure a ser usada");
			}
			else if(this.chkMapper.Checked && this.chkUpdateCommand.Checked && 
				this.trvUpdate.Nodes.Count > 1)
			{
				MessageBox.Show("Você selecinou Mais de uma procedure para o comando Update, obrigatório apenas uma procedure");
			}
			else if(this.chkMapper.Checked && this.chkDeleteCommand.Checked && 
				this.trvDelete.Nodes.Count == 0)
			{
				MessageBox.Show("Você selecinou Gerar Command Delete, obrigatorio selecionar a procedure a ser usada");
			}
			else if(this.chkMapper.Checked && this.chkDeleteCommand.Checked && 
				this.trvDelete.Nodes.Count > 1)
			{
				MessageBox.Show("Você selecinou Mais de uma procedure para o comando Delete, obrigatório apenas uma procedure");
			}
			else if(this.chkMapper.Checked && this.chkKeySelectCommand.Checked && 
				this.trvSelect.Nodes.Count == 0)
			{
				MessageBox.Show("Você selecinou Gerar Command SelectCommand, obrigatorio selecionar a procedure a ser usada");
			}
			else if(this.chkMapper.Checked && this.chkKeySelectCommand.Checked && 
				this.trvSelect.Nodes.Count > 1)
			{
				MessageBox.Show("Você selecinou Mais de uma procedure para o comando SelectCommand, obrigatório apenas uma procedure");
			}
			else
			{
			
				GeraArquivo CriarArquivos = new GeraArquivo();

				// ----------------------------------------------
				// Alimenta os atributos necessários para 
				// para a geração dos arquivos
				// ----------------------------------------------

				// --------- CAMPO USADO COMO TIME STAMP ---------
				Configuracao conf = new Configuracao();
				CriarArquivos.CampoTimeStamp = conf.ObterParametroDoXML("CampoTimeStamp");
				
				conf = null;
				
				// --------- PARAMETROS DE SAIDA DO ARQUIVO  ------------
				CriarArquivos.ColecaoNodes = this.trvTabelasSel.Nodes[0];
				CriarArquivos.Namespace = this.txtNamespace.Text;
				CriarArquivos.Classe = this.txtClasse.Text;
			
				if(!visualizar_) CriarArquivos.CaminhoSaida = this.txtCaminhoSaida.Text;

			
				// -------- PARAMETROS DO CONTEUDO DO ARQUIVO --------------
				CriarArquivos.GeraKeySelectCommand = this.chkKeySelectCommand.Checked;
				CriarArquivos.GeraInsertCommand = this.chkInsertCommand.Checked;
				CriarArquivos.GeraUpdateCommand = this.chkUpdateCommand.Checked;
				CriarArquivos.GeraDeleteCommand = this.chkDeleteCommand.Checked;

				// -----------------------------------------------
				// Chama método para criação dos Arquivos
				// -----------------------------------------------
			
				//***************************************************
				// Gera o Arquivo BC
				if(this.chkBC.Checked)
				{
				
					CriarArquivos.GeraMetodoObter = this.chkObter.Checked;
					CriarArquivos.GeraMetodoObterTodos = this.chkObterTodos.Checked;
					CriarArquivos.GeraMetodoPersistir = this.chkPersistir.Checked;
					CriarArquivos.GeraMetodoRemover = this.chkRemover.Checked;

					if(visualizar_) 
					{
						strRetorno = CriarArquivos.VisualizarBC();

					}
					else
					{
						CriarArquivos.GerarBC();
					}
				
				}

			
				//***************************************************
				// Gera o Arquivo EO
				if(this.chkEO.Checked)
				{
					if(visualizar_) 
					{
						strRetorno = CriarArquivos.VisualizarEO();
					}
					else
					{
						CriarArquivos.GerarEO();
					}
				
				}

				//***************************************************
				// Gera o Arquivo RO
				if(this.chkRO.Checked)
				{
					if(visualizar_) 
					{
						strRetorno = CriarArquivos.VisualizarRO();
					}
					else
					{
						CriarArquivos.GerarRO();
					}
				
				}

				//***************************************************
				// Gera o Arquivo Mapper
				if(this.chkMapper.Checked)
				{
				
					if(this.chkKeySelectCommand.Checked && this.trvSelect.Nodes.Count == 0)
					{
						MessageBox.Show("Selecione uma procedure para o " + this.chkKeySelectCommand.Text);
					}
					else if(this.chkInsertCommand.Checked && this.trvInsert.Nodes.Count == 0)
					{
						MessageBox.Show("Selecione uma procedure para o " + this.chkInsertCommand.Text);
					}
					else if(this.chkUpdateCommand.Checked && this.trvUpdate.Nodes.Count == 0)
					{
						MessageBox.Show("Selecione uma procedure para o " + this.chkUpdateCommand.Text);
					}
					else if(this.chkDeleteCommand.Checked && this.trvDelete.Nodes.Count == 0)
					{
						MessageBox.Show("Selecione uma procedure para o " + this.chkDeleteCommand.Text);
					}
					else 
					{
				
						CriarArquivos.trnProcedureSelect = (this.trvSelect.Nodes.Count != 0)?this.trvSelect.Nodes[0]:null;
						CriarArquivos.trnProcedureInsert = (this.trvInsert.Nodes.Count != 0)?this.trvInsert.Nodes[0]:null;
						CriarArquivos.trnProcedureUpdate = (this.trvUpdate.Nodes.Count != 0)?this.trvUpdate.Nodes[0]:null;
						CriarArquivos.trnProcedureDelete = (this.trvDelete.Nodes.Count != 0)?this.trvDelete.Nodes[0]:null;

						if(visualizar_) 
						{
							strRetorno = CriarArquivos.VisualizarMapper();
						}
						else
						{
							CriarArquivos.GerarMapper();
						}
					}
				
				}
			}
			return strRetorno;

		}

		private void cmdVisualizar_Click(object sender, System.EventArgs e)
		{
			this.tabcPassos.TabIndex = 3;
			this.txtPreview.Text = this.Arquivo(true);
		}

		private void mnuItemCopiar_Click(object sender, System.EventArgs e)
		{
			Clipboard.SetDataObject(this.txtPreview.Text);
		}

		private void cmdIncluirNodesProcedure_Click(object sender, System.EventArgs e)
		{
			// add selected items from treeview to the listview on the right hand side
			TreeNode n1 = (TreeNode)trvProcedures.SelectedNode.Clone();
			if(this.tabcProcedures.SelectedTab.Text == "Select")
			{
				trvSelect.Nodes.Add(n1);
			}
			if(this.tabcProcedures.SelectedTab.Text == "Insert")
			{
				trvInsert.Nodes.Add(n1);
			}
			if(this.tabcProcedures.SelectedTab.Text == "Update")
			{
				trvUpdate.Nodes.Add(n1);
			}
			if(this.tabcProcedures.SelectedTab.Text == "Delete")
			{
				trvDelete.Nodes.Add(n1);
			}

		}

		private void cmdRemoverNodesProcedure_Click(object sender, System.EventArgs e)
		{
			if(this.tabcProcedures.Enabled)
			{
				if(this.tabcProcedures.SelectedTab.Text == "Select")
				{
					trvSelect.Nodes.Remove(trvSelect.SelectedNode);
				}
				if(this.tabcProcedures.SelectedTab.Text == "Insert")
				{
					trvInsert.Nodes.Remove(trvInsert.SelectedNode);
				}
				if(this.tabcProcedures.SelectedTab.Text == "Update")
				{
					trvUpdate.Nodes.Remove(trvUpdate.SelectedNode);
				}
				if(this.tabcProcedures.SelectedTab.Text == "Delete")
				{
					trvDelete.Nodes.Remove(trvDelete.SelectedNode);
				}
			}

		}

		private void chkKeySelectCommand_CheckedChanged(object sender, System.EventArgs e)
		{
			this.trvSelect.Enabled = this.chkKeySelectCommand.Checked;
		}

		private void chkInsertCommand_CheckedChanged(object sender, System.EventArgs e)
		{
			this.trvInsert.Enabled = this.chkInsertCommand.Checked;
		}

		private void chkUpdateCommand_CheckedChanged(object sender, System.EventArgs e)
		{
			this.trvUpdate.Enabled = this.chkUpdateCommand.Checked;
		}

		private void chkDeleteCommand_CheckedChanged(object sender, System.EventArgs e)
		{
			this.trvDelete.Enabled = this.chkDeleteCommand.Checked;
		}

		private void tabcPassos_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.lblMensagem.Text = this.tabcPassos.SelectedTab.Tag.ToString();
		}

		private void chkBC_CheckedChanged(object sender, System.EventArgs e)
		{
			this.grpBC.Enabled = this.chkBC.Checked;
		}

		private void chkMapper_CheckedChanged(object sender, System.EventArgs e)
		{
			this.grpMapper.Enabled = this.chkMapper.Checked;
			this.trvProcedures.Enabled = this.chkMapper.Checked;
			this.tabcProcedures.Enabled = this.chkMapper.Checked;
		}



	}
}
