namespace WinXmlFixer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.displayT = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.cancelButton = new DevExpress.XtraEditors.SimpleButton();
            this.runLoopButton = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.runAtI = new DevExpress.XtraEditors.TimeEdit();
            this.runOnceButton = new DevExpress.XtraEditors.SimpleButton();
            this.saveConfigButton = new DevExpress.XtraEditors.SimpleButton();
            this.xmlLocationI = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.ftpPassI = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.ftpUserI = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.ftpHostI = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.TestButton = new DevExpress.XtraEditors.SimpleButton();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.logT = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.runAtI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xmlLocationI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ftpPassI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ftpUserI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ftpHostI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.displayT);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 1060);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1695, 67);
            this.panelControl1.TabIndex = 0;
            // 
            // displayT
            // 
            this.displayT.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.displayT.Appearance.Options.UseFont = true;
            this.displayT.Location = new System.Drawing.Point(38, 24);
            this.displayT.Name = "displayT";
            this.displayT.Size = new System.Drawing.Size(18, 24);
            this.displayT.TabIndex = 0;
            this.displayT.Text = "--";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.cancelButton);
            this.panelControl2.Controls.Add(this.runLoopButton);
            this.panelControl2.Controls.Add(this.labelControl5);
            this.panelControl2.Controls.Add(this.runAtI);
            this.panelControl2.Controls.Add(this.runOnceButton);
            this.panelControl2.Controls.Add(this.saveConfigButton);
            this.panelControl2.Controls.Add(this.xmlLocationI);
            this.panelControl2.Controls.Add(this.labelControl4);
            this.panelControl2.Controls.Add(this.ftpPassI);
            this.panelControl2.Controls.Add(this.labelControl3);
            this.panelControl2.Controls.Add(this.ftpUserI);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.ftpHostI);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Controls.Add(this.TestButton);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1695, 542);
            this.panelControl2.TabIndex = 1;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(1515, 448);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(168, 51);
            this.cancelButton.TabIndex = 14;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // runLoopButton
            // 
            this.runLoopButton.Location = new System.Drawing.Point(1515, 391);
            this.runLoopButton.Name = "runLoopButton";
            this.runLoopButton.Size = new System.Drawing.Size(168, 51);
            this.runLoopButton.TabIndex = 13;
            this.runLoopButton.Text = "Run Loop";
            this.runLoopButton.Click += new System.EventHandler(this.runLoopButton_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(38, 202);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(49, 19);
            this.labelControl5.TabIndex = 12;
            this.labelControl5.Text = "Run At";
            // 
            // runAtI
            // 
            this.runAtI.EditValue = new System.DateTime(2022, 4, 10, 0, 0, 0, 0);
            this.runAtI.Location = new System.Drawing.Point(148, 198);
            this.runAtI.Name = "runAtI";
            this.runAtI.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.runAtI.Properties.MaskSettings.Set("mask", "HH:mm:ss");
            this.runAtI.Size = new System.Drawing.Size(168, 28);
            this.runAtI.TabIndex = 11;
            // 
            // runOnceButton
            // 
            this.runOnceButton.Location = new System.Drawing.Point(1515, 334);
            this.runOnceButton.Name = "runOnceButton";
            this.runOnceButton.Size = new System.Drawing.Size(168, 51);
            this.runOnceButton.TabIndex = 10;
            this.runOnceButton.Text = "Run Once";
            this.runOnceButton.Click += new System.EventHandler(this.runOnceButton_Click);
            // 
            // saveConfigButton
            // 
            this.saveConfigButton.Location = new System.Drawing.Point(499, 250);
            this.saveConfigButton.Name = "saveConfigButton";
            this.saveConfigButton.Size = new System.Drawing.Size(168, 51);
            this.saveConfigButton.TabIndex = 9;
            this.saveConfigButton.Text = "Save Config";
            this.saveConfigButton.Click += new System.EventHandler(this.saveConfigButton_Click);
            // 
            // xmlLocationI
            // 
            this.xmlLocationI.Location = new System.Drawing.Point(148, 164);
            this.xmlLocationI.Name = "xmlLocationI";
            this.xmlLocationI.Size = new System.Drawing.Size(519, 26);
            this.xmlLocationI.TabIndex = 8;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(38, 167);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(86, 19);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "xml location";
            // 
            // ftpPassI
            // 
            this.ftpPassI.Location = new System.Drawing.Point(148, 132);
            this.ftpPassI.Name = "ftpPassI";
            this.ftpPassI.Properties.PasswordChar = '*';
            this.ftpPassI.Size = new System.Drawing.Size(519, 26);
            this.ftpPassI.TabIndex = 6;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(38, 135);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(58, 19);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Ftp Pass";
            // 
            // ftpUserI
            // 
            this.ftpUserI.Location = new System.Drawing.Point(148, 100);
            this.ftpUserI.Name = "ftpUserI";
            this.ftpUserI.Size = new System.Drawing.Size(519, 26);
            this.ftpUserI.TabIndex = 4;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(38, 103);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(59, 19);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Ftp User";
            // 
            // ftpHostI
            // 
            this.ftpHostI.Location = new System.Drawing.Point(148, 68);
            this.ftpHostI.Name = "ftpHostI";
            this.ftpHostI.Size = new System.Drawing.Size(519, 26);
            this.ftpHostI.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(38, 71);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(59, 19);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Ftp Host";
            // 
            // TestButton
            // 
            this.TestButton.Location = new System.Drawing.Point(1515, 277);
            this.TestButton.Name = "TestButton";
            this.TestButton.Size = new System.Drawing.Size(168, 51);
            this.TestButton.TabIndex = 0;
            this.TestButton.Text = "Test";
            this.TestButton.ToolTip = "Scan local files on original folder, and put modified in modified folder";
            this.TestButton.ToolTipController = this.toolTipController1;
            this.TestButton.Click += new System.EventHandler(this.TestButton_Click);
            // 
            // toolTipController1
            // 
            this.toolTipController1.ToolTipLocation = DevExpress.Utils.ToolTipLocation.LeftBottom;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.logT);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(0, 542);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(1695, 518);
            this.panelControl3.TabIndex = 2;
            // 
            // logT
            // 
            this.logT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logT.Location = new System.Drawing.Point(2, 2);
            this.logT.Name = "logT";
            this.logT.Size = new System.Drawing.Size(1691, 514);
            this.logT.TabIndex = 0;
            this.logT.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1695, 1127);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "WinXmlFixer 1.01";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.runAtI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xmlLocationI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ftpPassI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ftpUserI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ftpHostI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private System.Windows.Forms.RichTextBox logT;
        private DevExpress.XtraEditors.SimpleButton TestButton;
        private DevExpress.XtraEditors.LabelControl displayT;
        private DevExpress.XtraEditors.TextEdit ftpHostI;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit ftpPassI;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit ftpUserI;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit xmlLocationI;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton saveConfigButton;
        private DevExpress.XtraEditors.SimpleButton runOnceButton;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TimeEdit runAtI;
        private DevExpress.Utils.ToolTipController toolTipController1;
        private DevExpress.XtraEditors.SimpleButton runLoopButton;
        private DevExpress.XtraEditors.SimpleButton cancelButton;
    }
}

