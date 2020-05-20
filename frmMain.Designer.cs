namespace WinMikes
{
    partial class FrmMain
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnListMM = new System.Windows.Forms.Button();
            this.lbEvents = new System.Windows.Forms.ListBox();
            this.btClearEvents = new System.Windows.Forms.Button();
            this.lvDevices = new System.Windows.Forms.ListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDefault = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chInfo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Préiphériques d\'entrée";
            // 
            // btnListMM
            // 
            this.btnListMM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnListMM.Location = new System.Drawing.Point(746, 27);
            this.btnListMM.Name = "btnListMM";
            this.btnListMM.Size = new System.Drawing.Size(109, 48);
            this.btnListMM.TabIndex = 3;
            this.btnListMM.Text = "Refresh";
            this.btnListMM.UseVisualStyleBackColor = true;
            this.btnListMM.Click += new System.EventHandler(this.btnListMM_Click);
            // 
            // lbEvents
            // 
            this.lbEvents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbEvents.FormattingEnabled = true;
            this.lbEvents.Location = new System.Drawing.Point(15, 299);
            this.lbEvents.Name = "lbEvents";
            this.lbEvents.Size = new System.Drawing.Size(715, 199);
            this.lbEvents.TabIndex = 6;
            // 
            // btClearEvents
            // 
            this.btClearEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClearEvents.Location = new System.Drawing.Point(746, 299);
            this.btClearEvents.Name = "btClearEvents";
            this.btClearEvents.Size = new System.Drawing.Size(109, 43);
            this.btClearEvents.TabIndex = 7;
            this.btClearEvents.Text = "Clear";
            this.btClearEvents.UseVisualStyleBackColor = true;
            this.btClearEvents.Click += new System.EventHandler(this.btClearEvents_Click);
            // 
            // lvDevices
            // 
            this.lvDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvDevices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chDefault,
            this.chState,
            this.chInfo});
            this.lvDevices.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvDevices.HideSelection = false;
            this.lvDevices.Location = new System.Drawing.Point(15, 27);
            this.lvDevices.MultiSelect = false;
            this.lvDevices.Name = "lvDevices";
            this.lvDevices.Size = new System.Drawing.Size(715, 266);
            this.lvDevices.TabIndex = 11;
            this.lvDevices.UseCompatibleStateImageBehavior = false;
            this.lvDevices.View = System.Windows.Forms.View.Details;
            // 
            // chName
            // 
            this.chName.Text = "Device";
            this.chName.Width = 280;
            // 
            // chDefault
            // 
            this.chDefault.Text = "Default";
            this.chDefault.Width = 51;
            // 
            // chState
            // 
            this.chState.Text = "State";
            this.chState.Width = 66;
            // 
            // chInfo
            // 
            this.chInfo.Text = "Information";
            this.chInfo.Width = 177;
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(746, 81);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(109, 45);
            this.btnSettings.TabIndex = 12;
            this.btnSettings.Text = "Audio Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 504);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.lvDevices);
            this.Controls.Add(this.btnListMM);
            this.Controls.Add(this.btClearEvents);
            this.Controls.Add(this.lbEvents);
            this.Controls.Add(this.label1);
            this.Name = "FrmMain";
            this.Text = "Win Mikes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnListMM;
        private System.Windows.Forms.ListBox lbEvents;
        private System.Windows.Forms.Button btClearEvents;
        private System.Windows.Forms.ListView lvDevices;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chDefault;
        private System.Windows.Forms.ColumnHeader chState;
        private System.Windows.Forms.ColumnHeader chInfo;
        private System.Windows.Forms.Button btnSettings;
    }
}

