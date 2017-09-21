namespace IntelligentTextEditor
{
    partial class MainForm
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.holaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.saveInToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutEditorToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.palabrasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox = new System.Windows.Forms.TextBox();
            this.listBox = new System.Windows.Forms.ListBox();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.holaToolStripMenuItem,
            this.ayudaToolStripMenuItem,
            this.palabrasToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(284, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // holaToolStripMenuItem
            // 
            this.holaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStrip,
            this.openToolStrip,
            this.saveToolStrip,
            this.saveInToolStrip});
            this.holaToolStripMenuItem.Name = "holaToolStripMenuItem";
            this.holaToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.holaToolStripMenuItem.Text = "Archivo";
            // 
            // newToolStrip
            // 
            this.newToolStrip.Name = "newToolStrip";
            this.newToolStrip.Size = new System.Drawing.Size(141, 22);
            this.newToolStrip.Text = "Nuevo";
            this.newToolStrip.Click += new System.EventHandler(this.newToolStrip_Click);
            // 
            // openToolStrip
            // 
            this.openToolStrip.Name = "openToolStrip";
            this.openToolStrip.Size = new System.Drawing.Size(141, 22);
            this.openToolStrip.Text = "Abrir...";
            this.openToolStrip.Click += new System.EventHandler(this.openToolStrip_Click);
            // 
            // saveToolStrip
            // 
            this.saveToolStrip.Name = "saveToolStrip";
            this.saveToolStrip.Size = new System.Drawing.Size(141, 22);
            this.saveToolStrip.Text = "Guardar...";
            this.saveToolStrip.Click += new System.EventHandler(this.saveToolStrip_Click);
            // 
            // saveInToolStrip
            // 
            this.saveInToolStrip.Name = "saveInToolStrip";
            this.saveInToolStrip.Size = new System.Drawing.Size(141, 22);
            this.saveInToolStrip.Text = "Guardar en...";
            this.saveInToolStrip.Click += new System.EventHandler(this.saveInToolStrip_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manualToolStripMenuItem,
            this.aboutEditorToolStrip});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // manualToolStripMenuItem
            // 
            this.manualToolStripMenuItem.Name = "manualToolStripMenuItem";
            this.manualToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.manualToolStripMenuItem.Text = "Manual";
            // 
            // aboutEditorToolStrip
            // 
            this.aboutEditorToolStrip.Name = "aboutEditorToolStrip";
            this.aboutEditorToolStrip.Size = new System.Drawing.Size(163, 22);
            this.aboutEditorToolStrip.Text = "Acerca del editor";
            this.aboutEditorToolStrip.Click += new System.EventHandler(this.aboutEditorToolStrip_Click);
            // 
            // palabrasToolStripMenuItem
            // 
            this.palabrasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStrip});
            this.palabrasToolStripMenuItem.Name = "palabrasToolStripMenuItem";
            this.palabrasToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.palabrasToolStripMenuItem.Text = "Palabras";
            // 
            // addToolStrip
            // 
            this.addToolStrip.Name = "addToolStrip";
            this.addToolStrip.Size = new System.Drawing.Size(125, 22);
            this.addToolStrip.Text = "Agregar...";
            this.addToolStrip.Click += new System.EventHandler(this.addToolStrip_Click);
            // 
            // textBox
            // 
            this.textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox.Location = new System.Drawing.Point(0, 24);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(284, 237);
            this.textBox.TabIndex = 1;
            this.textBox.Click += new System.EventHandler(this.textBox_Click);
            this.textBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox_MouseClick);
            this.textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            this.textBox.MouseCaptureChanged += new System.EventHandler(this.textBox_MouseCaptureChanged);
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(234, 27);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(50, 30);
            this.listBox.TabIndex = 2;
            this.listBox.Visible = false;
            this.listBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listBox_KeyUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Editor de texto";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFrame_FormClosed);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem holaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStrip;
        private System.Windows.Forms.ToolStripMenuItem openToolStrip;
        private System.Windows.Forms.ToolStripMenuItem saveToolStrip;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutEditorToolStrip;
        private System.Windows.Forms.ToolStripMenuItem saveInToolStrip;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.ToolStripMenuItem palabrasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStrip;
    }
}

