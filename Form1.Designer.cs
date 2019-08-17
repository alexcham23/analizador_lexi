namespace practicav1._2
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaPestañaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarArchivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarArchivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualDeAplicacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tablero1 = new System.Windows.Forms.TabControl();
            this.tab1 = new System.Windows.Forms.TabPage();
            this.text1 = new System.Windows.Forms.RichTextBox();
            this.tab2 = new System.Windows.Forms.TabPage();
            this.text2 = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.imprimir = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tablero1.SuspendLayout();
            this.tab1.SuspendLayout();
            this.tab2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaPestañaToolStripMenuItem,
            this.cargarArchivoToolStripMenuItem,
            this.guardarArchivoToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // nuevaPestañaToolStripMenuItem
            // 
            this.nuevaPestañaToolStripMenuItem.Name = "nuevaPestañaToolStripMenuItem";
            this.nuevaPestañaToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.nuevaPestañaToolStripMenuItem.Text = "Nueva Pestaña";
            this.nuevaPestañaToolStripMenuItem.Click += new System.EventHandler(this.NuevaPestañaToolStripMenuItem_Click);
            // 
            // cargarArchivoToolStripMenuItem
            // 
            this.cargarArchivoToolStripMenuItem.Name = "cargarArchivoToolStripMenuItem";
            this.cargarArchivoToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.cargarArchivoToolStripMenuItem.Text = "Cargar Archivo";
            this.cargarArchivoToolStripMenuItem.Click += new System.EventHandler(this.CargarArchivoToolStripMenuItem_Click);
            // 
            // guardarArchivoToolStripMenuItem
            // 
            this.guardarArchivoToolStripMenuItem.Name = "guardarArchivoToolStripMenuItem";
            this.guardarArchivoToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.guardarArchivoToolStripMenuItem.Text = "Guardar Archivo";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.SalirToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manualDeAplicacionToolStripMenuItem,
            this.acercaDeToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // manualDeAplicacionToolStripMenuItem
            // 
            this.manualDeAplicacionToolStripMenuItem.Name = "manualDeAplicacionToolStripMenuItem";
            this.manualDeAplicacionToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.manualDeAplicacionToolStripMenuItem.Text = "Manual de Aplicacion";
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.acercaDeToolStripMenuItem.Text = "Acerca de.....";
            // 
            // tablero1
            // 
            this.tablero1.Controls.Add(this.tab1);
            this.tablero1.Controls.Add(this.tab2);
            this.tablero1.Location = new System.Drawing.Point(13, 42);
            this.tablero1.Name = "tablero1";
            this.tablero1.SelectedIndex = 0;
            this.tablero1.Size = new System.Drawing.Size(331, 374);
            this.tablero1.TabIndex = 1;
            // 
            // tab1
            // 
            this.tab1.Controls.Add(this.text1);
            this.tab1.Location = new System.Drawing.Point(4, 22);
            this.tab1.Name = "tab1";
            this.tab1.Padding = new System.Windows.Forms.Padding(3);
            this.tab1.Size = new System.Drawing.Size(323, 348);
            this.tab1.TabIndex = 0;
            this.tab1.Text = "Pestaña 1";
            this.tab1.UseVisualStyleBackColor = true;
            // 
            // text1
            // 
            this.text1.Location = new System.Drawing.Point(0, 0);
            this.text1.Name = "text1";
            this.text1.Size = new System.Drawing.Size(323, 348);
            this.text1.TabIndex = 0;
            this.text1.Text = "";
            // 
            // tab2
            // 
            this.tab2.Controls.Add(this.text2);
            this.tab2.Location = new System.Drawing.Point(4, 22);
            this.tab2.Name = "tab2";
            this.tab2.Padding = new System.Windows.Forms.Padding(3);
            this.tab2.Size = new System.Drawing.Size(323, 348);
            this.tab2.TabIndex = 1;
            this.tab2.Text = "Pestaña 2";
            this.tab2.UseVisualStyleBackColor = true;
            // 
            // text2
            // 
            this.text2.Location = new System.Drawing.Point(0, 0);
            this.text2.Name = "text2";
            this.text2.Size = new System.Drawing.Size(327, 352);
            this.text2.TabIndex = 0;
            this.text2.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Document (*.ly) | *.ly";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(407, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Analizar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(423, 207);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // imprimir
            // 
            this.imprimir.Location = new System.Drawing.Point(426, 270);
            this.imprimir.Name = "imprimir";
            this.imprimir.Size = new System.Drawing.Size(75, 23);
            this.imprimir.TabIndex = 4;
            this.imprimir.Text = "imprimir";
            this.imprimir.UseVisualStyleBackColor = true;
            this.imprimir.Click += new System.EventHandler(this.Imprimir_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.imprimir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tablero1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tablero1.ResumeLayout(false);
            this.tab1.ResumeLayout(false);
            this.tab2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaPestañaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarArchivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarArchivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualDeAplicacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.TabControl tablero1;
        private System.Windows.Forms.TabPage tab1;
        private System.Windows.Forms.RichTextBox text1;
        private System.Windows.Forms.TabPage tab2;
        private System.Windows.Forms.RichTextBox text2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button imprimir;
    }
}

