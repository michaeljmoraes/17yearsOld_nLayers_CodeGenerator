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
using System.Configuration;
using System.Text;

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
        private System.Windows.Forms.Button cmdGenerateFiles;
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
        private System.Windows.Forms.Label lblBasePath;
        public System.Windows.Forms.TextBox txtBasePath;
        private System.Windows.Forms.Panel pnlObjetos;
        public System.Windows.Forms.CheckBox chkMapper;
        private System.Windows.Forms.Button cmdPreView;
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
        private System.Windows.Forms.TabPage tabpObjects;
        private System.Windows.Forms.TabPage tabpOptions;
        private System.Windows.Forms.TabPage tabpProcedures;
        private System.Windows.Forms.TabPage tabpPreview;
        private System.Windows.Forms.TabPage tabpAppConfiguration;
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
        private GroupBox grpSolutionConfig;
        private GroupBox grpDomains;
        public CheckBox chkDomainRepositoryInterfaces;
        public CheckBox chkDomainModel;
        private GroupBox grpApplication;
        public CheckBox chkDomainAppService;
        public CheckBox chkAppViewModels;
        public CheckBox chkAutoMapper;
        private GroupBox grpData;
        public CheckBox chkDataMigration;
        public CheckBox chkDataRepositoryImplementation;
        private GroupBox grpDataBase;
        public CheckBox chkDataBaseStoredProcedure;
        public CheckBox chkDataBaseFunctions;
        private GroupBox grpWebApi;
        public CheckBox chkWebApiDependencyInjection;
        public CheckBox chkWebApiControllers;
        private Label label1;
        private Label label2;
        public TextBox txtAutoMapperAppendTag;
        public TextBox txtDIAppendTag;
        private Button cmdGenerateAllFiles;
        private Button cmdGenerateOnlySPsFNs;
        private TabPage tabpExplorer;
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
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.stbInformacoes = new System.Windows.Forms.StatusBar();
            this.pnlBotoesNavegacao = new System.Windows.Forms.Panel();
            this.cmdGenerateOnlySPsFNs = new System.Windows.Forms.Button();
            this.cmdPreView = new System.Windows.Forms.Button();
            this.cmdGenerateAllFiles = new System.Windows.Forms.Button();
            this.cmdGenerateFiles = new System.Windows.Forms.Button();
            this.tabcPassos = new System.Windows.Forms.TabControl();
            this.tabpExplorer = new System.Windows.Forms.TabPage();
            this.pnlCampos = new System.Windows.Forms.Panel();
            this.trvTabelasSel = new System.Windows.Forms.TreeView();
            this.pnlBotoesMovimentacao = new System.Windows.Forms.Panel();
            this.cmdIncluirNodes = new System.Windows.Forms.Button();
            this.cmdExcluirNodes = new System.Windows.Forms.Button();
            this.pnlBancoDados = new System.Windows.Forms.Panel();
            this.trvTabelas = new System.Windows.Forms.TreeView();
            this.tabpObjects = new System.Windows.Forms.TabPage();
            this.pnlObjetos = new System.Windows.Forms.Panel();
            this.grpDomains = new System.Windows.Forms.GroupBox();
            this.chkDomainRepositoryInterfaces = new System.Windows.Forms.CheckBox();
            this.chkDomainModel = new System.Windows.Forms.CheckBox();
            this.grpApplication = new System.Windows.Forms.GroupBox();
            this.txtAutoMapperAppendTag = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkDomainAppService = new System.Windows.Forms.CheckBox();
            this.chkAppViewModels = new System.Windows.Forms.CheckBox();
            this.chkAutoMapper = new System.Windows.Forms.CheckBox();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.chkDataMigration = new System.Windows.Forms.CheckBox();
            this.chkDataRepositoryImplementation = new System.Windows.Forms.CheckBox();
            this.grpDataBase = new System.Windows.Forms.GroupBox();
            this.chkDataBaseStoredProcedure = new System.Windows.Forms.CheckBox();
            this.chkDataBaseFunctions = new System.Windows.Forms.CheckBox();
            this.grpWebApi = new System.Windows.Forms.GroupBox();
            this.txtDIAppendTag = new System.Windows.Forms.TextBox();
            this.chkWebApiDependencyInjection = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkWebApiControllers = new System.Windows.Forms.CheckBox();
            this.chkRO = new System.Windows.Forms.CheckBox();
            this.chkEO = new System.Windows.Forms.CheckBox();
            this.chkMapper = new System.Windows.Forms.CheckBox();
            this.chkBC = new System.Windows.Forms.CheckBox();
            this.tabpOptions = new System.Windows.Forms.TabPage();
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
            this.tabpAppConfiguration = new System.Windows.Forms.TabPage();
            this.pnlSaida = new System.Windows.Forms.Panel();
            this.grpSolutionConfig = new System.Windows.Forms.GroupBox();
            this.txtNamespace = new System.Windows.Forms.TextBox();
            this.lblNamespace = new System.Windows.Forms.Label();
            this.txtBasePath = new System.Windows.Forms.TextBox();
            this.lblBasePath = new System.Windows.Forms.Label();
            this.lblMensagem = new System.Windows.Forms.Label();
            this.pnlBotoesNavegacao.SuspendLayout();
            this.tabcPassos.SuspendLayout();
            this.tabpExplorer.SuspendLayout();
            this.pnlCampos.SuspendLayout();
            this.pnlBotoesMovimentacao.SuspendLayout();
            this.pnlBancoDados.SuspendLayout();
            this.tabpObjects.SuspendLayout();
            this.pnlObjetos.SuspendLayout();
            this.grpDomains.SuspendLayout();
            this.grpApplication.SuspendLayout();
            this.grpData.SuspendLayout();
            this.grpDataBase.SuspendLayout();
            this.grpWebApi.SuspendLayout();
            this.tabpOptions.SuspendLayout();
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
            this.tabpAppConfiguration.SuspendLayout();
            this.pnlSaida.SuspendLayout();
            this.grpSolutionConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.White;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            // 
            // stbInformacoes
            // 
            this.stbInformacoes.Location = new System.Drawing.Point(0, 569);
            this.stbInformacoes.Name = "stbInformacoes";
            this.stbInformacoes.Size = new System.Drawing.Size(1073, 19);
            this.stbInformacoes.TabIndex = 0;
            // 
            // pnlBotoesNavegacao
            // 
            this.pnlBotoesNavegacao.Controls.Add(this.cmdGenerateOnlySPsFNs);
            this.pnlBotoesNavegacao.Controls.Add(this.cmdPreView);
            this.pnlBotoesNavegacao.Controls.Add(this.cmdGenerateAllFiles);
            this.pnlBotoesNavegacao.Controls.Add(this.cmdGenerateFiles);
            this.pnlBotoesNavegacao.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotoesNavegacao.Location = new System.Drawing.Point(0, 523);
            this.pnlBotoesNavegacao.Name = "pnlBotoesNavegacao";
            this.pnlBotoesNavegacao.Size = new System.Drawing.Size(1073, 46);
            this.pnlBotoesNavegacao.TabIndex = 5;
            // 
            // cmdGenerateOnlySPsFNs
            // 
            this.cmdGenerateOnlySPsFNs.Location = new System.Drawing.Point(251, 9);
            this.cmdGenerateOnlySPsFNs.Name = "cmdGenerateOnlySPsFNs";
            this.cmdGenerateOnlySPsFNs.Size = new System.Drawing.Size(244, 27);
            this.cmdGenerateOnlySPsFNs.TabIndex = 1;
            this.cmdGenerateOnlySPsFNs.Text = "Generate SPs/FNs for All Entities";
            this.cmdGenerateOnlySPsFNs.Click += new System.EventHandler(this.cmdGenerateAllSPsFNs_Click);
            // 
            // cmdPreView
            // 
            this.cmdPreView.Location = new System.Drawing.Point(716, 9);
            this.cmdPreView.Name = "cmdPreView";
            this.cmdPreView.Size = new System.Drawing.Size(90, 27);
            this.cmdPreView.TabIndex = 0;
            this.cmdPreView.Text = "PreView";
            this.cmdPreView.Visible = false;
            this.cmdPreView.Click += new System.EventHandler(this.cmdVisualizar_Click);
            // 
            // cmdGenerateAllFiles
            // 
            this.cmdGenerateAllFiles.Location = new System.Drawing.Point(12, 9);
            this.cmdGenerateAllFiles.Name = "cmdGenerateAllFiles";
            this.cmdGenerateAllFiles.Size = new System.Drawing.Size(233, 27);
            this.cmdGenerateAllFiles.TabIndex = 0;
            this.cmdGenerateAllFiles.Text = "Generate Files for All Entities";
            this.cmdGenerateAllFiles.Click += new System.EventHandler(this.cmdGenerateAllFiles_Click);
            // 
            // cmdGenerateFiles
            // 
            this.cmdGenerateFiles.Location = new System.Drawing.Point(812, 9);
            this.cmdGenerateFiles.Name = "cmdGenerateFiles";
            this.cmdGenerateFiles.Size = new System.Drawing.Size(246, 27);
            this.cmdGenerateFiles.TabIndex = 0;
            this.cmdGenerateFiles.Text = "Generate Files for Selected Entities";
            this.cmdGenerateFiles.Click += new System.EventHandler(this.cmdGenerateOnlySelected_Click);
            // 
            // tabcPassos
            // 
            this.tabcPassos.Controls.Add(this.tabpExplorer);
            this.tabcPassos.Controls.Add(this.tabpObjects);
            this.tabcPassos.Controls.Add(this.tabpOptions);
            this.tabcPassos.Controls.Add(this.tabpProcedures);
            this.tabcPassos.Controls.Add(this.tabpPreview);
            this.tabcPassos.Controls.Add(this.tabpAppConfiguration);
            this.tabcPassos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabcPassos.Location = new System.Drawing.Point(0, 37);
            this.tabcPassos.Name = "tabcPassos";
            this.tabcPassos.SelectedIndex = 0;
            this.tabcPassos.Size = new System.Drawing.Size(1073, 486);
            this.tabcPassos.TabIndex = 8;
            this.tabcPassos.SelectedIndexChanged += new System.EventHandler(this.tabcPassos_SelectedIndexChanged);
            // 
            // tabpExplorer
            // 
            this.tabpExplorer.Controls.Add(this.pnlCampos);
            this.tabpExplorer.Controls.Add(this.pnlBotoesMovimentacao);
            this.tabpExplorer.Controls.Add(this.pnlBancoDados);
            this.tabpExplorer.Location = new System.Drawing.Point(4, 25);
            this.tabpExplorer.Name = "tabpExplorer";
            this.tabpExplorer.Size = new System.Drawing.Size(1065, 457);
            this.tabpExplorer.TabIndex = 0;
            this.tabpExplorer.Tag = "Seleciona a Tabela ou View que será usada como base para gerção dos Campos";
            this.tabpExplorer.Text = "Database Explorer";
            // 
            // pnlCampos
            // 
            this.pnlCampos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCampos.BackColor = System.Drawing.Color.Silver;
            this.pnlCampos.Controls.Add(this.trvTabelasSel);
            this.pnlCampos.Location = new System.Drawing.Point(554, 0);
            this.pnlCampos.Name = "pnlCampos";
            this.pnlCampos.Size = new System.Drawing.Size(509, 448);
            this.pnlCampos.TabIndex = 7;
            // 
            // trvTabelasSel
            // 
            this.trvTabelasSel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trvTabelasSel.ImageIndex = 0;
            this.trvTabelasSel.ImageList = this.imageList1;
            this.trvTabelasSel.Location = new System.Drawing.Point(10, 7);
            this.trvTabelasSel.Name = "trvTabelasSel";
            this.trvTabelasSel.SelectedImageIndex = 0;
            this.trvTabelasSel.Size = new System.Drawing.Size(490, 434);
            this.trvTabelasSel.TabIndex = 10;
            this.trvTabelasSel.DoubleClick += new System.EventHandler(this.trvTabelasSel_DoubleClick);
            // 
            // pnlBotoesMovimentacao
            // 
            this.pnlBotoesMovimentacao.Controls.Add(this.cmdIncluirNodes);
            this.pnlBotoesMovimentacao.Controls.Add(this.cmdExcluirNodes);
            this.pnlBotoesMovimentacao.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBotoesMovimentacao.Location = new System.Drawing.Point(491, 0);
            this.pnlBotoesMovimentacao.Name = "pnlBotoesMovimentacao";
            this.pnlBotoesMovimentacao.Size = new System.Drawing.Size(57, 457);
            this.pnlBotoesMovimentacao.TabIndex = 9;
            // 
            // cmdIncluirNodes
            // 
            this.cmdIncluirNodes.Location = new System.Drawing.Point(10, 18);
            this.cmdIncluirNodes.Name = "cmdIncluirNodes";
            this.cmdIncluirNodes.Size = new System.Drawing.Size(38, 27);
            this.cmdIncluirNodes.TabIndex = 0;
            this.cmdIncluirNodes.Text = ">";
            this.cmdIncluirNodes.Click += new System.EventHandler(this.cmdIncluirNodes_Click);
            // 
            // cmdExcluirNodes
            // 
            this.cmdExcluirNodes.Location = new System.Drawing.Point(10, 55);
            this.cmdExcluirNodes.Name = "cmdExcluirNodes";
            this.cmdExcluirNodes.Size = new System.Drawing.Size(38, 27);
            this.cmdExcluirNodes.TabIndex = 0;
            this.cmdExcluirNodes.Text = "<";
            this.cmdExcluirNodes.Click += new System.EventHandler(this.cmdExcluirNodes_Click);
            // 
            // pnlBancoDados
            // 
            this.pnlBancoDados.BackColor = System.Drawing.Color.Gray;
            this.pnlBancoDados.Controls.Add(this.trvTabelas);
            this.pnlBancoDados.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBancoDados.Location = new System.Drawing.Point(0, 0);
            this.pnlBancoDados.Name = "pnlBancoDados";
            this.pnlBancoDados.Size = new System.Drawing.Size(491, 457);
            this.pnlBancoDados.TabIndex = 8;
            // 
            // trvTabelas
            // 
            this.trvTabelas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trvTabelas.ImageIndex = 0;
            this.trvTabelas.ImageList = this.imageList1;
            this.trvTabelas.Location = new System.Drawing.Point(10, 9);
            this.trvTabelas.Name = "trvTabelas";
            this.trvTabelas.SelectedImageIndex = 0;
            this.trvTabelas.Size = new System.Drawing.Size(471, 434);
            this.trvTabelas.TabIndex = 4;
            this.trvTabelas.DoubleClick += new System.EventHandler(this.trvTabelas_DoubleClick);
            // 
            // tabpObjects
            // 
            this.tabpObjects.Controls.Add(this.pnlObjetos);
            this.tabpObjects.Location = new System.Drawing.Point(4, 25);
            this.tabpObjects.Name = "tabpObjects";
            this.tabpObjects.Size = new System.Drawing.Size(1065, 457);
            this.tabpObjects.TabIndex = 2;
            this.tabpObjects.Tag = "Check os objetos que deseja Gerar";
            this.tabpObjects.Text = "Objetos";
            // 
            // pnlObjetos
            // 
            this.pnlObjetos.Controls.Add(this.grpDomains);
            this.pnlObjetos.Controls.Add(this.grpApplication);
            this.pnlObjetos.Controls.Add(this.grpData);
            this.pnlObjetos.Controls.Add(this.grpDataBase);
            this.pnlObjetos.Controls.Add(this.grpWebApi);
            this.pnlObjetos.Controls.Add(this.chkRO);
            this.pnlObjetos.Controls.Add(this.chkEO);
            this.pnlObjetos.Controls.Add(this.chkMapper);
            this.pnlObjetos.Controls.Add(this.chkBC);
            this.pnlObjetos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlObjetos.Location = new System.Drawing.Point(0, 0);
            this.pnlObjetos.Name = "pnlObjetos";
            this.pnlObjetos.Size = new System.Drawing.Size(1065, 457);
            this.pnlObjetos.TabIndex = 0;
            // 
            // grpDomains
            // 
            this.grpDomains.Controls.Add(this.chkDomainRepositoryInterfaces);
            this.grpDomains.Controls.Add(this.chkDomainModel);
            this.grpDomains.Location = new System.Drawing.Point(20, 20);
            this.grpDomains.Name = "grpDomains";
            this.grpDomains.Size = new System.Drawing.Size(342, 152);
            this.grpDomains.TabIndex = 16;
            this.grpDomains.TabStop = false;
            this.grpDomains.Text = "1 - Domains";
            // 
            // chkDomainRepositoryInterfaces
            // 
            this.chkDomainRepositoryInterfaces.Checked = true;
            this.chkDomainRepositoryInterfaces.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDomainRepositoryInterfaces.Location = new System.Drawing.Point(27, 66);
            this.chkDomainRepositoryInterfaces.Name = "chkDomainRepositoryInterfaces";
            this.chkDomainRepositoryInterfaces.Size = new System.Drawing.Size(251, 28);
            this.chkDomainRepositoryInterfaces.TabIndex = 13;
            this.chkDomainRepositoryInterfaces.Text = "Create Repository Interfaces";
            this.chkDomainRepositoryInterfaces.CheckedChanged += new System.EventHandler(this.chkMapper_CheckedChanged);
            // 
            // chkDomainModel
            // 
            this.chkDomainModel.Checked = true;
            this.chkDomainModel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDomainModel.Location = new System.Drawing.Point(27, 34);
            this.chkDomainModel.Name = "chkDomainModel";
            this.chkDomainModel.Size = new System.Drawing.Size(192, 27);
            this.chkDomainModel.TabIndex = 13;
            this.chkDomainModel.Text = "Create Domain Model";
            this.chkDomainModel.CheckedChanged += new System.EventHandler(this.chkBC_CheckedChanged);
            // 
            // grpApplication
            // 
            this.grpApplication.Controls.Add(this.txtAutoMapperAppendTag);
            this.grpApplication.Controls.Add(this.label1);
            this.grpApplication.Controls.Add(this.chkDomainAppService);
            this.grpApplication.Controls.Add(this.chkAppViewModels);
            this.grpApplication.Controls.Add(this.chkAutoMapper);
            this.grpApplication.Location = new System.Drawing.Point(705, 20);
            this.grpApplication.Name = "grpApplication";
            this.grpApplication.Size = new System.Drawing.Size(339, 196);
            this.grpApplication.TabIndex = 16;
            this.grpApplication.TabStop = false;
            this.grpApplication.Text = "3 - Application";
            // 
            // txtAutoMapperAppendTag
            // 
            this.txtAutoMapperAppendTag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAutoMapperAppendTag.Location = new System.Drawing.Point(24, 157);
            this.txtAutoMapperAppendTag.Name = "txtAutoMapperAppendTag";
            this.txtAutoMapperAppendTag.Size = new System.Drawing.Size(289, 22);
            this.txtAutoMapperAppendTag.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 23);
            this.label1.TabIndex = 18;
            this.label1.Text = "Append Tag:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkDomainAppService
            // 
            this.chkDomainAppService.Checked = true;
            this.chkDomainAppService.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDomainAppService.Location = new System.Drawing.Point(24, 67);
            this.chkDomainAppService.Name = "chkDomainAppService";
            this.chkDomainAppService.Size = new System.Drawing.Size(249, 28);
            this.chkDomainAppService.TabIndex = 14;
            this.chkDomainAppService.Text = "Create Domain App Service";
            // 
            // chkAppViewModels
            // 
            this.chkAppViewModels.Checked = true;
            this.chkAppViewModels.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAppViewModels.Location = new System.Drawing.Point(24, 34);
            this.chkAppViewModels.Name = "chkAppViewModels";
            this.chkAppViewModels.Size = new System.Drawing.Size(192, 27);
            this.chkAppViewModels.TabIndex = 13;
            this.chkAppViewModels.Text = "Create ViewModels";
            this.chkAppViewModels.CheckedChanged += new System.EventHandler(this.chkBC_CheckedChanged);
            // 
            // chkAutoMapper
            // 
            this.chkAutoMapper.Checked = true;
            this.chkAutoMapper.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoMapper.Location = new System.Drawing.Point(24, 101);
            this.chkAutoMapper.Name = "chkAutoMapper";
            this.chkAutoMapper.Size = new System.Drawing.Size(192, 28);
            this.chkAutoMapper.TabIndex = 13;
            this.chkAutoMapper.Text = "Update AutoMapper";
            this.chkAutoMapper.CheckedChanged += new System.EventHandler(this.chkMapper_CheckedChanged);
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.chkDataMigration);
            this.grpData.Controls.Add(this.chkDataRepositoryImplementation);
            this.grpData.Location = new System.Drawing.Point(380, 20);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(302, 152);
            this.grpData.TabIndex = 16;
            this.grpData.TabStop = false;
            this.grpData.Text = "2 - Data";
            // 
            // chkDataMigration
            // 
            this.chkDataMigration.Checked = true;
            this.chkDataMigration.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDataMigration.Location = new System.Drawing.Point(27, 34);
            this.chkDataMigration.Name = "chkDataMigration";
            this.chkDataMigration.Size = new System.Drawing.Size(192, 27);
            this.chkDataMigration.TabIndex = 13;
            this.chkDataMigration.Text = "Create Migration";
            this.chkDataMigration.CheckedChanged += new System.EventHandler(this.chkBC_CheckedChanged);
            // 
            // chkDataRepositoryImplementation
            // 
            this.chkDataRepositoryImplementation.Checked = true;
            this.chkDataRepositoryImplementation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDataRepositoryImplementation.Location = new System.Drawing.Point(27, 66);
            this.chkDataRepositoryImplementation.Name = "chkDataRepositoryImplementation";
            this.chkDataRepositoryImplementation.Size = new System.Drawing.Size(274, 28);
            this.chkDataRepositoryImplementation.TabIndex = 13;
            this.chkDataRepositoryImplementation.Text = "Create Repository Implementation";
            this.chkDataRepositoryImplementation.CheckedChanged += new System.EventHandler(this.chkMapper_CheckedChanged);
            // 
            // grpDataBase
            // 
            this.grpDataBase.Controls.Add(this.chkDataBaseStoredProcedure);
            this.grpDataBase.Controls.Add(this.chkDataBaseFunctions);
            this.grpDataBase.Location = new System.Drawing.Point(380, 235);
            this.grpDataBase.Name = "grpDataBase";
            this.grpDataBase.Size = new System.Drawing.Size(302, 186);
            this.grpDataBase.TabIndex = 16;
            this.grpDataBase.TabStop = false;
            this.grpDataBase.Text = "5 - DataBase";
            // 
            // chkDataBaseStoredProcedure
            // 
            this.chkDataBaseStoredProcedure.Checked = true;
            this.chkDataBaseStoredProcedure.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDataBaseStoredProcedure.Location = new System.Drawing.Point(21, 31);
            this.chkDataBaseStoredProcedure.Name = "chkDataBaseStoredProcedure";
            this.chkDataBaseStoredProcedure.Size = new System.Drawing.Size(192, 27);
            this.chkDataBaseStoredProcedure.TabIndex = 13;
            this.chkDataBaseStoredProcedure.Text = "Create Stored Procedures";
            this.chkDataBaseStoredProcedure.CheckedChanged += new System.EventHandler(this.chkBC_CheckedChanged);
            // 
            // chkDataBaseFunctions
            // 
            this.chkDataBaseFunctions.Checked = true;
            this.chkDataBaseFunctions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDataBaseFunctions.Location = new System.Drawing.Point(21, 63);
            this.chkDataBaseFunctions.Name = "chkDataBaseFunctions";
            this.chkDataBaseFunctions.Size = new System.Drawing.Size(192, 28);
            this.chkDataBaseFunctions.TabIndex = 13;
            this.chkDataBaseFunctions.Text = "Create Functions";
            this.chkDataBaseFunctions.CheckedChanged += new System.EventHandler(this.chkMapper_CheckedChanged);
            // 
            // grpWebApi
            // 
            this.grpWebApi.Controls.Add(this.txtDIAppendTag);
            this.grpWebApi.Controls.Add(this.chkWebApiDependencyInjection);
            this.grpWebApi.Controls.Add(this.label2);
            this.grpWebApi.Controls.Add(this.chkWebApiControllers);
            this.grpWebApi.Location = new System.Drawing.Point(20, 235);
            this.grpWebApi.Name = "grpWebApi";
            this.grpWebApi.Size = new System.Drawing.Size(342, 186);
            this.grpWebApi.TabIndex = 16;
            this.grpWebApi.TabStop = false;
            this.grpWebApi.Text = "4 - WebApi";
            // 
            // txtDIAppendTag
            // 
            this.txtDIAppendTag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDIAppendTag.Location = new System.Drawing.Point(27, 129);
            this.txtDIAppendTag.Name = "txtDIAppendTag";
            this.txtDIAppendTag.Size = new System.Drawing.Size(289, 22);
            this.txtDIAppendTag.TabIndex = 19;
            // 
            // chkWebApiDependencyInjection
            // 
            this.chkWebApiDependencyInjection.Checked = true;
            this.chkWebApiDependencyInjection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWebApiDependencyInjection.Location = new System.Drawing.Point(27, 63);
            this.chkWebApiDependencyInjection.Name = "chkWebApiDependencyInjection";
            this.chkWebApiDependencyInjection.Size = new System.Drawing.Size(274, 28);
            this.chkWebApiDependencyInjection.TabIndex = 13;
            this.chkWebApiDependencyInjection.Text = "Update Dependency Injection";
            this.chkWebApiDependencyInjection.CheckedChanged += new System.EventHandler(this.chkMapper_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(24, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 23);
            this.label2.TabIndex = 18;
            this.label2.Text = "Append Tag:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkWebApiControllers
            // 
            this.chkWebApiControllers.Checked = true;
            this.chkWebApiControllers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWebApiControllers.Location = new System.Drawing.Point(27, 31);
            this.chkWebApiControllers.Name = "chkWebApiControllers";
            this.chkWebApiControllers.Size = new System.Drawing.Size(192, 27);
            this.chkWebApiControllers.TabIndex = 13;
            this.chkWebApiControllers.Text = "Create Controller";
            this.chkWebApiControllers.CheckedChanged += new System.EventHandler(this.chkBC_CheckedChanged);
            // 
            // chkRO
            // 
            this.chkRO.Checked = true;
            this.chkRO.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRO.Location = new System.Drawing.Point(806, 290);
            this.chkRO.Name = "chkRO";
            this.chkRO.Size = new System.Drawing.Size(192, 28);
            this.chkRO.TabIndex = 15;
            this.chkRO.Text = "Gera Arquivo RO";
            // 
            // chkEO
            // 
            this.chkEO.Checked = true;
            this.chkEO.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEO.Location = new System.Drawing.Point(806, 256);
            this.chkEO.Name = "chkEO";
            this.chkEO.Size = new System.Drawing.Size(192, 28);
            this.chkEO.TabIndex = 14;
            this.chkEO.Text = "Gera Arquivo EO";
            // 
            // chkMapper
            // 
            this.chkMapper.Checked = true;
            this.chkMapper.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMapper.Location = new System.Drawing.Point(806, 322);
            this.chkMapper.Name = "chkMapper";
            this.chkMapper.Size = new System.Drawing.Size(192, 28);
            this.chkMapper.TabIndex = 13;
            this.chkMapper.Text = "Gerar Arquivo Mapper";
            this.chkMapper.CheckedChanged += new System.EventHandler(this.chkMapper_CheckedChanged);
            // 
            // chkBC
            // 
            this.chkBC.Checked = true;
            this.chkBC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBC.Location = new System.Drawing.Point(806, 356);
            this.chkBC.Name = "chkBC";
            this.chkBC.Size = new System.Drawing.Size(192, 27);
            this.chkBC.TabIndex = 13;
            this.chkBC.Text = "Gerar Arquivo BC";
            this.chkBC.CheckedChanged += new System.EventHandler(this.chkBC_CheckedChanged);
            // 
            // tabpOptions
            // 
            this.tabpOptions.Controls.Add(this.pnlCommands);
            this.tabpOptions.Location = new System.Drawing.Point(4, 25);
            this.tabpOptions.Name = "tabpOptions";
            this.tabpOptions.Size = new System.Drawing.Size(1065, 457);
            this.tabpOptions.TabIndex = 1;
            this.tabpOptions.Tag = "Check os itens que deseja Gerar para cada um dos objetos";
            this.tabpOptions.Text = "Opções de Objetos";
            // 
            // pnlCommands
            // 
            this.pnlCommands.Controls.Add(this.grpBC);
            this.pnlCommands.Controls.Add(this.grpMapper);
            this.pnlCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCommands.Location = new System.Drawing.Point(0, 0);
            this.pnlCommands.Name = "pnlCommands";
            this.pnlCommands.Size = new System.Drawing.Size(1065, 457);
            this.pnlCommands.TabIndex = 0;
            // 
            // grpBC
            // 
            this.grpBC.Controls.Add(this.chkTipoSelect);
            this.grpBC.Controls.Add(this.chkRemover);
            this.grpBC.Controls.Add(this.chkPersistir);
            this.grpBC.Controls.Add(this.chkObterTodos);
            this.grpBC.Controls.Add(this.chkObter);
            this.grpBC.Location = new System.Drawing.Point(259, 18);
            this.grpBC.Name = "grpBC";
            this.grpBC.Size = new System.Drawing.Size(480, 250);
            this.grpBC.TabIndex = 19;
            this.grpBC.TabStop = false;
            this.grpBC.Text = "Opções do BC";
            // 
            // chkTipoSelect
            // 
            this.chkTipoSelect.Location = new System.Drawing.Point(230, 37);
            this.chkTipoSelect.Name = "chkTipoSelect";
            this.chkTipoSelect.Size = new System.Drawing.Size(221, 28);
            this.chkTipoSelect.TabIndex = 28;
            this.chkTipoSelect.Text = "Usar procedure para Select";
            this.chkTipoSelect.Visible = false;
            // 
            // chkRemover
            // 
            this.chkRemover.Checked = true;
            this.chkRemover.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRemover.Location = new System.Drawing.Point(34, 180);
            this.chkRemover.Name = "chkRemover";
            this.chkRemover.Size = new System.Drawing.Size(172, 28);
            this.chkRemover.TabIndex = 25;
            this.chkRemover.Text = "Metodo Remover";
            // 
            // chkPersistir
            // 
            this.chkPersistir.Checked = true;
            this.chkPersistir.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPersistir.Location = new System.Drawing.Point(34, 134);
            this.chkPersistir.Name = "chkPersistir";
            this.chkPersistir.Size = new System.Drawing.Size(172, 28);
            this.chkPersistir.TabIndex = 24;
            this.chkPersistir.Text = "Metodo Persistir";
            // 
            // chkObterTodos
            // 
            this.chkObterTodos.Checked = true;
            this.chkObterTodos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkObterTodos.Location = new System.Drawing.Point(34, 88);
            this.chkObterTodos.Name = "chkObterTodos";
            this.chkObterTodos.Size = new System.Drawing.Size(172, 27);
            this.chkObterTodos.TabIndex = 23;
            this.chkObterTodos.Text = "Metodo ObterTodos";
            // 
            // chkObter
            // 
            this.chkObter.Checked = true;
            this.chkObter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkObter.Location = new System.Drawing.Point(34, 42);
            this.chkObter.Name = "chkObter";
            this.chkObter.Size = new System.Drawing.Size(172, 27);
            this.chkObter.TabIndex = 22;
            this.chkObter.Text = "Metodo Obter";
            // 
            // grpMapper
            // 
            this.grpMapper.Controls.Add(this.chkDeleteCommand);
            this.grpMapper.Controls.Add(this.chkUpdateCommand);
            this.grpMapper.Controls.Add(this.chkInsertCommand);
            this.grpMapper.Controls.Add(this.chkKeySelectCommand);
            this.grpMapper.Location = new System.Drawing.Point(19, 18);
            this.grpMapper.Name = "grpMapper";
            this.grpMapper.Size = new System.Drawing.Size(221, 250);
            this.grpMapper.TabIndex = 18;
            this.grpMapper.TabStop = false;
            this.grpMapper.Text = "Opções de Mapper";
            // 
            // chkDeleteCommand
            // 
            this.chkDeleteCommand.Checked = true;
            this.chkDeleteCommand.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDeleteCommand.Location = new System.Drawing.Point(34, 185);
            this.chkDeleteCommand.Name = "chkDeleteCommand";
            this.chkDeleteCommand.Size = new System.Drawing.Size(172, 27);
            this.chkDeleteCommand.TabIndex = 21;
            this.chkDeleteCommand.Text = "Delete Command";
            this.chkDeleteCommand.CheckedChanged += new System.EventHandler(this.chkDeleteCommand_CheckedChanged);
            // 
            // chkUpdateCommand
            // 
            this.chkUpdateCommand.Checked = true;
            this.chkUpdateCommand.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUpdateCommand.Location = new System.Drawing.Point(34, 138);
            this.chkUpdateCommand.Name = "chkUpdateCommand";
            this.chkUpdateCommand.Size = new System.Drawing.Size(172, 28);
            this.chkUpdateCommand.TabIndex = 20;
            this.chkUpdateCommand.Text = "Update Command";
            this.chkUpdateCommand.CheckedChanged += new System.EventHandler(this.chkUpdateCommand_CheckedChanged);
            // 
            // chkInsertCommand
            // 
            this.chkInsertCommand.Checked = true;
            this.chkInsertCommand.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInsertCommand.Location = new System.Drawing.Point(34, 92);
            this.chkInsertCommand.Name = "chkInsertCommand";
            this.chkInsertCommand.Size = new System.Drawing.Size(172, 28);
            this.chkInsertCommand.TabIndex = 19;
            this.chkInsertCommand.Text = "Insert Command";
            this.chkInsertCommand.CheckedChanged += new System.EventHandler(this.chkInsertCommand_CheckedChanged);
            // 
            // chkKeySelectCommand
            // 
            this.chkKeySelectCommand.Checked = true;
            this.chkKeySelectCommand.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKeySelectCommand.Location = new System.Drawing.Point(34, 46);
            this.chkKeySelectCommand.Name = "chkKeySelectCommand";
            this.chkKeySelectCommand.Size = new System.Drawing.Size(172, 28);
            this.chkKeySelectCommand.TabIndex = 18;
            this.chkKeySelectCommand.Text = "Select Command";
            this.chkKeySelectCommand.CheckedChanged += new System.EventHandler(this.chkKeySelectCommand_CheckedChanged);
            // 
            // tabpProcedures
            // 
            this.tabpProcedures.Controls.Add(this.tabcProcedures);
            this.tabpProcedures.Controls.Add(this.pnlBotoesProcedure);
            this.tabpProcedures.Controls.Add(this.pnlProcedures);
            this.tabpProcedures.Location = new System.Drawing.Point(4, 25);
            this.tabpProcedures.Name = "tabpProcedures";
            this.tabpProcedures.Size = new System.Drawing.Size(1065, 457);
            this.tabpProcedures.TabIndex = 5;
            this.tabpProcedures.Tag = "Seleciona a Procedure que deseja utilizar, na aba direito seleciona o Tipo de Pro" +
    "cedure, e entao adicione o item";
            this.tabpProcedures.Text = "Procedures";
            // 
            // tabcProcedures
            // 
            this.tabcProcedures.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabcProcedures.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabcProcedures.Controls.Add(this.tabpSelect);
            this.tabcProcedures.Controls.Add(this.tabpInsert);
            this.tabcProcedures.Controls.Add(this.tabpUpdate);
            this.tabcProcedures.Controls.Add(this.tabpDelete);
            this.tabcProcedures.Location = new System.Drawing.Point(355, 9);
            this.tabcProcedures.Multiline = true;
            this.tabcProcedures.Name = "tabcProcedures";
            this.tabcProcedures.SelectedIndex = 0;
            this.tabcProcedures.Size = new System.Drawing.Size(699, 430);
            this.tabcProcedures.TabIndex = 11;
            // 
            // tabpSelect
            // 
            this.tabpSelect.Controls.Add(this.panel2);
            this.tabpSelect.Location = new System.Drawing.Point(25, 4);
            this.tabpSelect.Name = "tabpSelect";
            this.tabpSelect.Size = new System.Drawing.Size(670, 422);
            this.tabpSelect.TabIndex = 0;
            this.tabpSelect.Text = "Select";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.DarkGray;
            this.panel2.Controls.Add(this.trvSelect);
            this.panel2.Location = new System.Drawing.Point(-2, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(667, 421);
            this.panel2.TabIndex = 11;
            // 
            // trvSelect
            // 
            this.trvSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trvSelect.ImageIndex = 0;
            this.trvSelect.ImageList = this.imageList1;
            this.trvSelect.Location = new System.Drawing.Point(10, 9);
            this.trvSelect.Name = "trvSelect";
            this.trvSelect.SelectedImageIndex = 0;
            this.trvSelect.Size = new System.Drawing.Size(648, 402);
            this.trvSelect.TabIndex = 4;
            // 
            // tabpInsert
            // 
            this.tabpInsert.Controls.Add(this.panel3);
            this.tabpInsert.Location = new System.Drawing.Point(25, 4);
            this.tabpInsert.Name = "tabpInsert";
            this.tabpInsert.Size = new System.Drawing.Size(670, 422);
            this.tabpInsert.TabIndex = 1;
            this.tabpInsert.Text = "Insert";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.DarkGray;
            this.panel3.Controls.Add(this.trvInsert);
            this.panel3.Location = new System.Drawing.Point(-2, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(667, 424);
            this.panel3.TabIndex = 11;
            // 
            // trvInsert
            // 
            this.trvInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trvInsert.ImageIndex = 0;
            this.trvInsert.ImageList = this.imageList1;
            this.trvInsert.Location = new System.Drawing.Point(10, 9);
            this.trvInsert.Name = "trvInsert";
            this.trvInsert.SelectedImageIndex = 0;
            this.trvInsert.Size = new System.Drawing.Size(648, 406);
            this.trvInsert.TabIndex = 4;
            // 
            // tabpUpdate
            // 
            this.tabpUpdate.Controls.Add(this.panel4);
            this.tabpUpdate.Location = new System.Drawing.Point(25, 4);
            this.tabpUpdate.Name = "tabpUpdate";
            this.tabpUpdate.Size = new System.Drawing.Size(670, 422);
            this.tabpUpdate.TabIndex = 2;
            this.tabpUpdate.Text = "Update";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.DarkGray;
            this.panel4.Controls.Add(this.trvUpdate);
            this.panel4.Location = new System.Drawing.Point(-2, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(667, 424);
            this.panel4.TabIndex = 11;
            // 
            // trvUpdate
            // 
            this.trvUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trvUpdate.ImageIndex = 0;
            this.trvUpdate.ImageList = this.imageList1;
            this.trvUpdate.Location = new System.Drawing.Point(10, 9);
            this.trvUpdate.Name = "trvUpdate";
            this.trvUpdate.SelectedImageIndex = 0;
            this.trvUpdate.Size = new System.Drawing.Size(648, 406);
            this.trvUpdate.TabIndex = 4;
            // 
            // tabpDelete
            // 
            this.tabpDelete.Controls.Add(this.panel1);
            this.tabpDelete.Location = new System.Drawing.Point(25, 4);
            this.tabpDelete.Name = "tabpDelete";
            this.tabpDelete.Size = new System.Drawing.Size(670, 422);
            this.tabpDelete.TabIndex = 3;
            this.tabpDelete.Text = "Delete";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Controls.Add(this.trvDelete);
            this.panel1.Location = new System.Drawing.Point(-2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(667, 424);
            this.panel1.TabIndex = 12;
            // 
            // trvDelete
            // 
            this.trvDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trvDelete.ImageIndex = 0;
            this.trvDelete.ImageList = this.imageList1;
            this.trvDelete.Location = new System.Drawing.Point(10, 9);
            this.trvDelete.Name = "trvDelete";
            this.trvDelete.SelectedImageIndex = 0;
            this.trvDelete.Size = new System.Drawing.Size(648, 406);
            this.trvDelete.TabIndex = 4;
            // 
            // pnlBotoesProcedure
            // 
            this.pnlBotoesProcedure.Controls.Add(this.cmdIncluirNodesProcedure);
            this.pnlBotoesProcedure.Controls.Add(this.cmdRemoverNodesProcedure);
            this.pnlBotoesProcedure.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBotoesProcedure.Location = new System.Drawing.Point(298, 0);
            this.pnlBotoesProcedure.Name = "pnlBotoesProcedure";
            this.pnlBotoesProcedure.Size = new System.Drawing.Size(57, 457);
            this.pnlBotoesProcedure.TabIndex = 10;
            // 
            // cmdIncluirNodesProcedure
            // 
            this.cmdIncluirNodesProcedure.Location = new System.Drawing.Point(10, 18);
            this.cmdIncluirNodesProcedure.Name = "cmdIncluirNodesProcedure";
            this.cmdIncluirNodesProcedure.Size = new System.Drawing.Size(38, 27);
            this.cmdIncluirNodesProcedure.TabIndex = 0;
            this.cmdIncluirNodesProcedure.Text = ">";
            this.cmdIncluirNodesProcedure.Click += new System.EventHandler(this.cmdIncluirNodesProcedure_Click);
            // 
            // cmdRemoverNodesProcedure
            // 
            this.cmdRemoverNodesProcedure.Location = new System.Drawing.Point(10, 55);
            this.cmdRemoverNodesProcedure.Name = "cmdRemoverNodesProcedure";
            this.cmdRemoverNodesProcedure.Size = new System.Drawing.Size(38, 27);
            this.cmdRemoverNodesProcedure.TabIndex = 0;
            this.cmdRemoverNodesProcedure.Text = "<";
            this.cmdRemoverNodesProcedure.Click += new System.EventHandler(this.cmdRemoverNodesProcedure_Click);
            // 
            // pnlProcedures
            // 
            this.pnlProcedures.BackColor = System.Drawing.Color.Gray;
            this.pnlProcedures.Controls.Add(this.trvProcedures);
            this.pnlProcedures.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlProcedures.Location = new System.Drawing.Point(0, 0);
            this.pnlProcedures.Name = "pnlProcedures";
            this.pnlProcedures.Size = new System.Drawing.Size(298, 457);
            this.pnlProcedures.TabIndex = 9;
            // 
            // trvProcedures
            // 
            this.trvProcedures.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trvProcedures.ImageIndex = 0;
            this.trvProcedures.ImageList = this.imageList1;
            this.trvProcedures.Location = new System.Drawing.Point(10, 9);
            this.trvProcedures.Name = "trvProcedures";
            this.trvProcedures.SelectedImageIndex = 0;
            this.trvProcedures.Size = new System.Drawing.Size(278, 434);
            this.trvProcedures.TabIndex = 4;
            // 
            // tabpPreview
            // 
            this.tabpPreview.Controls.Add(this.txtPreview);
            this.tabpPreview.Location = new System.Drawing.Point(4, 25);
            this.tabpPreview.Name = "tabpPreview";
            this.tabpPreview.Size = new System.Drawing.Size(1065, 457);
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
            this.txtPreview.Location = new System.Drawing.Point(0, 0);
            this.txtPreview.Name = "txtPreview";
            this.txtPreview.ShowSelectionMargin = true;
            this.txtPreview.Size = new System.Drawing.Size(1065, 457);
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
            // tabpAppConfiguration
            // 
            this.tabpAppConfiguration.Controls.Add(this.pnlSaida);
            this.tabpAppConfiguration.Location = new System.Drawing.Point(4, 25);
            this.tabpAppConfiguration.Name = "tabpAppConfiguration";
            this.tabpAppConfiguration.Size = new System.Drawing.Size(1065, 457);
            this.tabpAppConfiguration.TabIndex = 4;
            this.tabpAppConfiguration.Tag = "Digite o Caminho de Saida do arquivo, o nome do Namespace e o nome da Clase e cli" +
    "que no botão Gerar Arquivo";
            this.tabpAppConfiguration.Text = "App Configuration";
            // 
            // pnlSaida
            // 
            this.pnlSaida.Controls.Add(this.grpSolutionConfig);
            this.pnlSaida.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSaida.Location = new System.Drawing.Point(0, 0);
            this.pnlSaida.Name = "pnlSaida";
            this.pnlSaida.Size = new System.Drawing.Size(1065, 457);
            this.pnlSaida.TabIndex = 0;
            // 
            // grpSolutionConfig
            // 
            this.grpSolutionConfig.Controls.Add(this.txtNamespace);
            this.grpSolutionConfig.Controls.Add(this.lblNamespace);
            this.grpSolutionConfig.Controls.Add(this.txtBasePath);
            this.grpSolutionConfig.Controls.Add(this.lblBasePath);
            this.grpSolutionConfig.Location = new System.Drawing.Point(18, 28);
            this.grpSolutionConfig.Name = "grpSolutionConfig";
            this.grpSolutionConfig.Size = new System.Drawing.Size(626, 176);
            this.grpSolutionConfig.TabIndex = 18;
            this.grpSolutionConfig.TabStop = false;
            this.grpSolutionConfig.Text = "Solution Config";
            // 
            // txtNamespace
            // 
            this.txtNamespace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNamespace.Location = new System.Drawing.Point(147, 41);
            this.txtNamespace.Name = "txtNamespace";
            this.txtNamespace.Size = new System.Drawing.Size(403, 22);
            this.txtNamespace.TabIndex = 8;
            // 
            // lblNamespace
            // 
            this.lblNamespace.Location = new System.Drawing.Point(22, 41);
            this.lblNamespace.Name = "lblNamespace";
            this.lblNamespace.Size = new System.Drawing.Size(120, 19);
            this.lblNamespace.TabIndex = 17;
            this.lblNamespace.Text = "Namespace";
            this.lblNamespace.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBasePath
            // 
            this.txtBasePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBasePath.Location = new System.Drawing.Point(147, 69);
            this.txtBasePath.Name = "txtBasePath";
            this.txtBasePath.Size = new System.Drawing.Size(403, 22);
            this.txtBasePath.TabIndex = 11;
            // 
            // lblBasePath
            // 
            this.lblBasePath.Location = new System.Drawing.Point(22, 69);
            this.lblBasePath.Name = "lblBasePath";
            this.lblBasePath.Size = new System.Drawing.Size(120, 19);
            this.lblBasePath.TabIndex = 10;
            this.lblBasePath.Text = "Base Path: ";
            this.lblBasePath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMensagem
            // 
            this.lblMensagem.BackColor = System.Drawing.Color.White;
            this.lblMensagem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMensagem.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMensagem.Location = new System.Drawing.Point(0, 0);
            this.lblMensagem.Name = "lblMensagem";
            this.lblMensagem.Size = new System.Drawing.Size(1073, 37);
            this.lblMensagem.TabIndex = 9;
            this.lblMensagem.Text = "Favor selecionar a Tabela ou View que deseja utilizar para geraração dos Objetos." +
    "";
            // 
            // frmPrincipal
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(1073, 588);
            this.Controls.Add(this.tabcPassos);
            this.Controls.Add(this.pnlBotoesNavegacao);
            this.Controls.Add(this.stbInformacoes);
            this.Controls.Add(this.lblMensagem);
            this.Name = "frmPrincipal";
            this.Text = "Code Generator";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.pnlBotoesNavegacao.ResumeLayout(false);
            this.tabcPassos.ResumeLayout(false);
            this.tabpExplorer.ResumeLayout(false);
            this.pnlCampos.ResumeLayout(false);
            this.pnlBotoesMovimentacao.ResumeLayout(false);
            this.pnlBancoDados.ResumeLayout(false);
            this.tabpObjects.ResumeLayout(false);
            this.pnlObjetos.ResumeLayout(false);
            this.grpDomains.ResumeLayout(false);
            this.grpApplication.ResumeLayout(false);
            this.grpApplication.PerformLayout();
            this.grpData.ResumeLayout(false);
            this.grpDataBase.ResumeLayout(false);
            this.grpWebApi.ResumeLayout(false);
            this.grpWebApi.PerformLayout();
            this.tabpOptions.ResumeLayout(false);
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
            this.tabpPreview.PerformLayout();
            this.tabpAppConfiguration.ResumeLayout(false);
            this.pnlSaida.ResumeLayout(false);
            this.grpSolutionConfig.ResumeLayout(false);
            this.grpSolutionConfig.PerformLayout();
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

            // Load Soluction Definitions
            this.txtNamespace.Text = CustomConfiguration.SolutionConfig.BaseNameSpace;
            this.txtBasePath.Text = CustomConfiguration.SolutionConfig.TargetBasePath;

            //Read AppendTag
            this.txtAutoMapperAppendTag.Text = CustomConfiguration.ApplicationConfig.AutoMapper.AppendTag;
            this.txtDIAppendTag.Text = CustomConfiguration.WebApiConfig.DependencyInjection.AppendTag;

            HideUnusedTabs();

            LoadDBObjects();

            //CarregarTreeViewProcedures();

        }

        private void HideUnusedTabs()
        {

            tabcPassos.TabPages.RemoveByKey("tabpObjects");
            tabcPassos.TabPages.RemoveByKey("tabpOptions");
            tabcPassos.TabPages.RemoveByKey("tabpProcedures");
            tabcPassos.TabPages.RemoveByKey("tabpPreview");

        }

        private void LoadDBObjects()
        {

            NpgsqlConnection conn = dataAccess.GetConnection(dataAccess.GetConnectionString());
            try
            {
                DataTable dttGlobalName = new DataTable();
                NpgsqlDataReader dtrUserTables;
                NpgsqlDataReader dtrUserViews;
                NpgsqlDataReader dtrUserTabColumns;

                dttGlobalName = dataAccess.GetSelectCommand(conn, "select current_database FROM current_database()");
                dtrUserTables = dataAccess.GetSelectDataReader("SELECT table_name FROM information_schema.tables WHERE table_schema = 'public' ORDER BY table_name");
                //dtrUserViews = dataAccess.GetSelectDataReader("SELECT * FROM USER_VIEWS");

                // ----------------------------------------------------
                // Adiciona o nó do Banco de Dados					  -
                // ----------------------------------------------------
                TreeNode NoPai = new TreeNode();
                NoPai.ImageIndex = 1;
                NoPai.SelectedImageIndex = 1;
                NoPai.Text = Convert.ToString(dttGlobalName.Rows[0][0]);
                NoPai.Tag = "dbinstance";

                trvTabelas.Nodes.Add(NoPai);


                // ----------------------------------------------------
                // Adiciona os Nós das Tabelas   					  -
                // ----------------------------------------------------
                while (dtrUserTables.Read())
                {
                    TreeNode NoFilho = new TreeNode();
                    NoFilho.ImageIndex = 2;
                    NoFilho.SelectedImageIndex = 2;
                    NoFilho.Text = Convert.ToString(dtrUserTables["table_name"]);
                    NoFilho.Tag = NoPai.Text + "." + NoFilho.Text;

                    // ----------------------------------------------------
                    // Adiciona os Nós dos Campos   					  -
                    // ----------------------------------------------------
                    dtrUserTabColumns = dataAccess.GetSelectDataReader(conn, "SELECT table_columns.table_name, table_columns.column_name, table_columns.data_type, table_columns.character_maximum_length AS data_length, table_columns.numeric_precision, table_columns.numeric_scale AS data_scale FROM information_schema.columns table_columns WHERE table_schema = 'public' AND table_columns.table_name = '" + NoFilho.Text + "'");

                    while (dtrUserTabColumns.Read())
                    {
                        TreeNode NoNeto = new TreeNode();
                        NoNeto.ImageIndex = 3;
                        NoNeto.SelectedImageIndex = 3;
                        NoNeto.Text = Convert.ToString(dtrUserTabColumns["column_name"]);
                        //NoNeto.Tag = NoPai.Text + "." + NoFilho.Text + "." + NoNeto.Text;
                        //NoNeto.Tag = Convert.ToString(dtrUserTabColumns["data_type"]) + "|" + Convert.ToString(dtrUserTabColumns["data_length"]) + "|" + Convert.ToString(dtrUserTabColumns["data_scale"]);
                        NoNeto.Tag = Convert.ToString(dtrUserTabColumns["data_type"]);
                        NoNeto.ToolTipText = Convert.ToString(dtrUserTabColumns["data_length"]);

                        NoFilho.Nodes.Add(NoNeto);

                    }

                    dtrUserTabColumns.Close();
                    dtrUserTabColumns = null;

                    //foreach (DataRow LinhaNeto in dttUserTabColumns.Rows)
                    //{

                    //    TreeNode NoNeto = new TreeNode();
                    //    NoNeto.ImageIndex = 3;
                    //    NoNeto.SelectedImageIndex = 3;
                    //    NoNeto.Text = Convert.ToString(LinhaNeto["COLUMN_NAME"]);
                    //    //NoNeto.Tag = NoPai.Text + "." + NoFilho.Text + "." + NoNeto.Text;
                    //    NoNeto.Tag = Convert.ToString(LinhaNeto["DATA_TYPE"]) + "|" + Convert.ToString(LinhaNeto["DATA_LENGTH"]);

                    //    NoFilho.Nodes.Add(NoNeto);

                    //}

                    trvTabelas.Nodes[0].Nodes.Add(NoFilho);

                }

                dtrUserTables.Close();
                dtrUserTables = null;

                //// ----------------------------------------------------
                //// Adiciona os Nós das Views   					  -
                //// ----------------------------------------------------
                //while (dtrUserViews.Read())
                //{
                //    TreeNode NoFilho = new TreeNode();
                //    NoFilho.ImageIndex = 2;
                //    NoFilho.SelectedImageIndex = 2;
                //    NoFilho.Text = Convert.ToString(dtrUserViews["VIEW_NAME"]);
                //    NoFilho.Tag = NoPai.Text + "." + NoFilho.Text;

                //    // ----------------------------------------------------
                //    // Adiciona os Nós dos Campos   					  -
                //    // ----------------------------------------------------
                //    dtrUserTabColumns = dataAccess.GetSelectDataReader(conn, "SELECT A.TABLE_NAME, A.COLUMN_NAME, A.DATA_TYPE, A.DATA_LENGTH, A.DATA_PRECISION, A.DATA_SCALE FROM DBA_TAB_COLUMNS A WHERE A.TABLE_NAME = '" + NoFilho.Text + "'");

                //    while (dtrUserTabColumns.Read())
                //    {

                //        TreeNode NoNeto = new TreeNode();
                //        NoNeto.ImageIndex = 3;
                //        NoNeto.SelectedImageIndex = 3;
                //        NoNeto.Text = Convert.ToString(dtrUserTabColumns["COLUMN_NAME"]);
                //        //NoNeto.Tag = NoPai.Text + "." + NoFilho.Text + "." + NoNeto.Text;
                //        NoNeto.Tag = Convert.ToString(dtrUserTabColumns["DATA_TYPE"]) + "|" + Convert.ToString(dtrUserTabColumns["DATA_LENGTH"]) + "|" + Convert.ToString(dtrUserTabColumns["DATA_SCALE"]);

                //        NoFilho.Nodes.Add(NoNeto);

                //    }

                //    dtrUserTabColumns.Close();
                //    dtrUserTabColumns = null;

                //    trvTabelas.Nodes[0].Nodes.Add(NoFilho);

                //}

                //dtrUserViews.Close();
                //dtrUserViews = null;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
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

                dttGlobalName = dataAccess.GetSelectCommand(conn, "select current_database FROM current_database()");
                string sqlObjects = @"
SELECT 
      CASE prokind
        WHEN 'f' THEN 'FUNCTION'
        WHEN 'p' THEN 'PROCEDURE'
      END AS procedure_type,
      p.proname AS procedure_name
FROM pg_catalog.pg_namespace n JOIN pg_catalog.pg_proc p ON p.pronamespace = n.oid
WHERE p.prokind = ANY ('{f,p}') AND n.nspname = 'public'
ORDER BY p.prokind
";
                dtrProcedures = dataAccess.GetSelectDataReader(sqlObjects);

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
                while (dtrProcedures.Read())
                {
                    string strProcedureType = Convert.ToString(dtrProcedures["procedure_type"]);
                    string strProcedureName = Convert.ToString(dtrProcedures["procedure_name"]);
                    string strNomeNode = strProcedureName == "" ? strProcedureType : strProcedureType + "." + strProcedureName;
                    string strQueryParameters = "";

                    TreeNode NoFilho = new TreeNode();
                    NoFilho.ImageIndex = 2;
                    NoFilho.SelectedImageIndex = 2;
                    NoFilho.Text = strNomeNode;
                    NoFilho.Tag = NoPai.Text + "." + NoFilho.Text;

                    // ----------------------------------------------------
                    // Adiciona os Nós dos Campos   					  -
                    // ----------------------------------------------------
                    strQueryParameters = @"
select proc.routine_type,
       proc.routine_name as procedure_name,
       args.parameter_mode,
       args.parameter_name,
       args.data_type AS parameter_type,
       0 AS parameter_length,
       0 AS parameter_scale
from information_schema.routines proc
left join information_schema.parameters args
          on proc.specific_schema = args.specific_schema
          and proc.specific_name = args.specific_name
where proc.routine_schema not in ('pg_catalog', 'information_schema')
      and proc.routine_type = ANY('{PROCEDURE,FUNCTION}')
      and proc.routine_name= '" + strProcedureName + @"'
      and args.parameter_name IS NOT NULL
order by procedure_name,
         args.ordinal_position
";

                    dtrParameters = dataAccess.GetSelectDataReader(conn, strQueryParameters);

                    while (dtrParameters.Read())
                    {

                        TreeNode NoNeto = new TreeNode();
                        NoNeto.ImageIndex = 3;
                        NoNeto.SelectedImageIndex = 3;
                        NoNeto.Text = Convert.ToString(dtrParameters["parameter_name"]);
                        NoNeto.Tag = NoPai.Text + "." + NoFilho.Text + "." + NoNeto.Text;
                        NoNeto.Tag = Convert.ToString(dtrParameters["parameter_type"]) + "|" + Convert.ToString(dtrParameters["parameter_length"]) + "|" + Convert.ToString(dtrParameters["parameter_scale"]) + "|" + Convert.ToString(dtrParameters["parameter_mode"]);

                        NoFilho.Nodes.Add(NoNeto);

                    }

                    dtrParameters.Close();
                    dtrParameters = null;

                    trvProcedures.Nodes[0].Nodes.Add(NoFilho);

                }

                dtrProcedures.Close();
                dtrProcedures = null;

            }
            catch (Exception ex)
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
            //Add Parent Node First
            if (trvTabelas.SelectedNode == null)
                return;

            TreeNode n1 = (TreeNode)trvTabelas.SelectedNode.Clone();
            trvTabelasSel.Nodes.Add(n1);

        }

        private void cmdExcluirNodes_Click(object sender, System.EventArgs e)
        {
            if (trvTabelasSel.SelectedNode == null)
                return;

            trvTabelasSel.Nodes.Remove(trvTabelasSel.SelectedNode);
        }

        //private string GenerateFile()
        //{
        //    return this.GenerateFile(true, false, false);
        //}

        //private string GenerateFile(bool generateSelected, bool generateAll, bool generateOnlySPsFNs)
        //{

        //    string strResult = string.Empty;

        //    if (this.trvTabelasSel.Nodes.Count == 0)
        //    {
        //        MessageBox.Show("Selecione uma tabela ou view");
        //    }
        //    else
        //    {
        //        try
        //        {

        //            // --------- PARAMETROS DE SAIDA DO ARQUIVO  ------------

        //            StringBuilder sbReturn = new StringBuilder();

        //            //Using Nodes will be created the files for all selected nodes
        //            //this.trvTabelasSel.Nodes
        //            TreeNodeCollection nodes = null;

        //            if (generateSelected)
        //            {
        //                if (!trvTabelasSel.Nodes[0].Tag.ToString().Equals("dbinstance"))
        //                    nodes = trvTabelasSel.Nodes;
        //            }

        //            if (generateAll)
        //            {
        //                nodes = trvTabelas.Nodes[0].Nodes;
        //                this.GenerateAllFiles();
        //            }

        //            if (generateOnlySPsFNs)
        //            {
        //                nodes = trvTabelas.Nodes[0].Nodes;
        //                this.GenerateSPsFNs();
        //            }

        //            if (generateSelected)
        //            {
        //                strResult = this.GenerateSelectedEntities();
        //            }


        //        }
        //        catch (Exception ex)
        //        {
        //            strResult = ex.Message;
        //        }
        //    }
        //    return strResult;

        //}

        private void cmdVisualizar_Click(object sender, System.EventArgs e)
        {
            //this.tabcPassos.TabIndex = 3;
            //this.txtPreview.Text = this.GenerateFile(true, false,false);
        }

        private void mnuItemCopiar_Click(object sender, System.EventArgs e)
        {
            Clipboard.SetDataObject(this.txtPreview.Text);
        }

        private void cmdIncluirNodesProcedure_Click(object sender, System.EventArgs e)
        {
            // add selected items from treeview to the listview on the right hand side
            TreeNode n1 = (TreeNode)trvProcedures.SelectedNode.Clone();
            if (this.tabcProcedures.SelectedTab.Text == "Select")
            {
                trvSelect.Nodes.Add(n1);
            }
            if (this.tabcProcedures.SelectedTab.Text == "Insert")
            {
                trvInsert.Nodes.Add(n1);
            }
            if (this.tabcProcedures.SelectedTab.Text == "Update")
            {
                trvUpdate.Nodes.Add(n1);
            }
            if (this.tabcProcedures.SelectedTab.Text == "Delete")
            {
                trvDelete.Nodes.Add(n1);
            }

        }

        private void cmdRemoverNodesProcedure_Click(object sender, System.EventArgs e)
        {
            if (this.tabcProcedures.Enabled)
            {
                if (this.tabcProcedures.SelectedTab.Text == "Select")
                {
                    trvSelect.Nodes.Remove(trvSelect.SelectedNode);
                }
                if (this.tabcProcedures.SelectedTab.Text == "Insert")
                {
                    trvInsert.Nodes.Remove(trvInsert.SelectedNode);
                }
                if (this.tabcProcedures.SelectedTab.Text == "Update")
                {
                    trvUpdate.Nodes.Remove(trvUpdate.SelectedNode);
                }
                if (this.tabcProcedures.SelectedTab.Text == "Delete")
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

        public bool BasicValidation()
        {
            bool blnReturn = true;

            if (this.txtNamespace.Text == "")
            {
                MessageBox.Show("Obrigatório digitar um Namespace");
                this.txtNamespace.Focus();
                blnReturn = false;
            }

            if (this.txtBasePath.Text == "")
            {
                MessageBox.Show("Obrigatório digitar um caminho de Saída para geração do Arquivo");
                this.txtBasePath.Focus();
                blnReturn = false;
            }

            if (!System.IO.Directory.Exists(this.txtBasePath.Text) && !CustomConfiguration.SolutionConfig.ForceCreateFolder)
            {
                MessageBox.Show("Caminho de Sáida Inválido ou Inexistênte");
                this.txtBasePath.Focus();
                blnReturn = false;
            }

            if (this.trvTabelas.Nodes.Count == 0)
            {
                MessageBox.Show("Need to have nodes to continue");
                blnReturn = false;
            }
            return blnReturn;
        }

        private void cmdGenerateOnlySelected_Click(object sender, System.EventArgs e)
        {
            if (BasicValidation())
                MessageBox.Show(this.GenerateOnlySelected());
        }

        private void cmdGenerateAllSPsFNs_Click(object sender, EventArgs e)
        {
            if (BasicValidation())
                MessageBox.Show(this.GenerateAllSPsFNs());
        }

        private void cmdGenerateAllFiles_Click(object sender, EventArgs e)
        {
            if (BasicValidation())
                MessageBox.Show(this.GenerateAllFiles());
        }

        public string GenerateAllFiles()
        {
            string strResult;
            try
            {
                foreach (TreeNode node in this.trvTabelas.Nodes[0].Nodes)
                {
                    FileGeneratorHelper fileGenerator = new FileGeneratorHelper(node);
                    fileGenerator.SaveAllAssets();
                }
                strResult = "Files created";
            }
            catch (Exception ex)
            {
                strResult = ex.Message;
            }
            return strResult;
        }


        public string GenerateAllSPsFNs()
        {
            string strResult;
            try
            {
                foreach (TreeNode node in this.trvTabelas.Nodes[0].Nodes)
                {
                    FileGeneratorHelper fileGenerator = new FileGeneratorHelper(node);
                    fileGenerator.SaveMergedTemplateDataBase();
                }

                strResult = "Files created";
            }
            catch (Exception ex)
            {
                strResult = ex.Message;
            }
            return strResult;
        }


        private string GenerateOnlySelected()
        {
            
            if (this.trvTabelasSel.Nodes.Count == 0)
                return "Required select a View or a Table";

            string strResult = string.Empty;
            try
            {
                TreeNodeCollection nodes = null;
                if (trvTabelasSel.Nodes[0].Tag.ToString().Equals("dbinstance"))
                    nodes = trvTabelasSel.Nodes[0].Nodes;
                else
                    nodes = trvTabelasSel.Nodes;

                //Using Nodes will be created the files for all selected nodes
                //this.trvTabelasSel.Nodes
                foreach (TreeNode node in nodes)
                {
                    FileGeneratorHelper fileGenerator = new FileGeneratorHelper(node);
                    fileGenerator.SaveAllAssets();
                }

                strResult = "Files created";


            }
            catch (Exception ex)
            {
                strResult = ex.Message;
            }

            return strResult;

        }

        private void trvTabelas_DoubleClick(object sender, EventArgs e)
        {
            cmdIncluirNodes_Click(sender, e);
        }

        private void trvTabelasSel_DoubleClick(object sender, EventArgs e)
        {
            cmdExcluirNodes_Click(sender, e);
        }

    }

}
