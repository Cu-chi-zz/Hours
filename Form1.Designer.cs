namespace Hours
{
    partial class HoursForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HoursForm));
            this.TopPanel = new System.Windows.Forms.Panel();
            this.ButtonHelp = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.MinimizeButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.HideButton = new System.Windows.Forms.Button();
            this.LabelTotalTime = new System.Windows.Forms.Label();
            this.LabelSeconds = new System.Windows.Forms.Label();
            this.LabelMinutes = new System.Windows.Forms.Label();
            this.LabelHours = new System.Windows.Forms.Label();
            this.LabelDays = new System.Windows.Forms.Label();
            this.LabelFirstOpeningDate = new System.Windows.Forms.Label();
            this.LabelDateNow = new System.Windows.Forms.Label();
            this.LabelFirstLauch = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CheckboxArrondir = new System.Windows.Forms.CheckBox();
            this.ButtonShare = new System.Windows.Forms.Button();
            this.ButtonReset = new System.Windows.Forms.Button();
            this.CheckBoxStartMinimized = new System.Windows.Forms.CheckBox();
            this.TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.DimGray;
            this.TopPanel.Controls.Add(this.ButtonHelp);
            this.TopPanel.Controls.Add(this.pictureBox1);
            this.TopPanel.Controls.Add(this.MinimizeButton);
            this.TopPanel.Controls.Add(this.CloseButton);
            this.TopPanel.Controls.Add(this.HideButton);
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(400, 35);
            this.TopPanel.TabIndex = 0;
            this.TopPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseDown);
            // 
            // ButtonHelp
            // 
            this.ButtonHelp.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ButtonHelp.FlatAppearance.BorderSize = 0;
            this.ButtonHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonHelp.Location = new System.Drawing.Point(281, 7);
            this.ButtonHelp.Name = "ButtonHelp";
            this.ButtonHelp.Size = new System.Drawing.Size(51, 23);
            this.ButtonHelp.TabIndex = 14;
            this.ButtonHelp.Text = "Aide";
            this.ButtonHelp.UseVisualStyleBackColor = false;
            this.ButtonHelp.Click += new System.EventHandler(this.ButtonHelp_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // MinimizeButton
            // 
            this.MinimizeButton.AutoSize = true;
            this.MinimizeButton.BackColor = System.Drawing.Color.SteelBlue;
            this.MinimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.MinimizeButton.Location = new System.Drawing.Point(338, 5);
            this.MinimizeButton.Name = "MinimizeButton";
            this.MinimizeButton.Size = new System.Drawing.Size(25, 25);
            this.MinimizeButton.TabIndex = 1;
            this.MinimizeButton.Text = "_";
            this.MinimizeButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.MinimizeButton.UseVisualStyleBackColor = false;
            this.MinimizeButton.Click += new System.EventHandler(this.MinimizeButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.AutoSize = true;
            this.CloseButton.BackColor = System.Drawing.Color.DarkRed;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.CloseButton.Location = new System.Drawing.Point(370, 5);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(26, 25);
            this.CloseButton.TabIndex = 0;
            this.CloseButton.Text = "X";
            this.CloseButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // HideButton
            // 
            this.HideButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.HideButton.FlatAppearance.BorderSize = 0;
            this.HideButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HideButton.Location = new System.Drawing.Point(38, 7);
            this.HideButton.Name = "HideButton";
            this.HideButton.Size = new System.Drawing.Size(76, 23);
            this.HideButton.TabIndex = 5;
            this.HideButton.Text = "CACHER";
            this.HideButton.UseVisualStyleBackColor = false;
            this.HideButton.Click += new System.EventHandler(this.HideButton_Click);
            // 
            // LabelTotalTime
            // 
            this.LabelTotalTime.AutoSize = true;
            this.LabelTotalTime.Font = new System.Drawing.Font("Montserrat SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTotalTime.Location = new System.Drawing.Point(2, 38);
            this.LabelTotalTime.Name = "LabelTotalTime";
            this.LabelTotalTime.Size = new System.Drawing.Size(268, 52);
            this.LabelTotalTime.TabIndex = 1;
            this.LabelTotalTime.Text = "Vous avez passé 0 heures \r\navec votre pc d\'allumé.";
            // 
            // LabelSeconds
            // 
            this.LabelSeconds.AutoSize = true;
            this.LabelSeconds.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSeconds.Location = new System.Drawing.Point(3, 90);
            this.LabelSeconds.Name = "LabelSeconds";
            this.LabelSeconds.Size = new System.Drawing.Size(96, 23);
            this.LabelSeconds.TabIndex = 2;
            this.LabelSeconds.Text = "0 secondes";
            // 
            // LabelMinutes
            // 
            this.LabelMinutes.AutoSize = true;
            this.LabelMinutes.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.LabelMinutes.Location = new System.Drawing.Point(3, 108);
            this.LabelMinutes.Name = "LabelMinutes";
            this.LabelMinutes.Size = new System.Drawing.Size(86, 23);
            this.LabelMinutes.TabIndex = 3;
            this.LabelMinutes.Text = "0 minutes";
            // 
            // LabelHours
            // 
            this.LabelHours.AutoSize = true;
            this.LabelHours.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.LabelHours.Location = new System.Drawing.Point(3, 126);
            this.LabelHours.Name = "LabelHours";
            this.LabelHours.Size = new System.Drawing.Size(77, 23);
            this.LabelHours.TabIndex = 4;
            this.LabelHours.Text = "0 heures";
            // 
            // LabelDays
            // 
            this.LabelDays.AutoSize = true;
            this.LabelDays.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.LabelDays.Location = new System.Drawing.Point(3, 144);
            this.LabelDays.Name = "LabelDays";
            this.LabelDays.Size = new System.Drawing.Size(64, 23);
            this.LabelDays.TabIndex = 6;
            this.LabelDays.Text = "0 jours";
            // 
            // LabelFirstOpeningDate
            // 
            this.LabelFirstOpeningDate.AutoSize = true;
            this.LabelFirstOpeningDate.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelFirstOpeningDate.Location = new System.Drawing.Point(246, 89);
            this.LabelFirstOpeningDate.Name = "LabelFirstOpeningDate";
            this.LabelFirstOpeningDate.Size = new System.Drawing.Size(154, 23);
            this.LabelFirstOpeningDate.TabIndex = 7;
            this.LabelFirstOpeningDate.Text = "00.00.00 00:00:00";
            // 
            // LabelDateNow
            // 
            this.LabelDateNow.AutoSize = true;
            this.LabelDateNow.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelDateNow.Location = new System.Drawing.Point(246, 126);
            this.LabelDateNow.Name = "LabelDateNow";
            this.LabelDateNow.Size = new System.Drawing.Size(154, 23);
            this.LabelDateNow.TabIndex = 8;
            this.LabelDateNow.Text = "00.00.00 00:00:00";
            // 
            // LabelFirstLauch
            // 
            this.LabelFirstLauch.AutoSize = true;
            this.LabelFirstLauch.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelFirstLauch.Location = new System.Drawing.Point(293, 67);
            this.LabelFirstLauch.Name = "LabelFirstLauch";
            this.LabelFirstLauch.Size = new System.Drawing.Size(103, 23);
            this.LabelFirstLauch.TabIndex = 9;
            this.LabelFirstLauch.Text = "Lancement :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(341, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "Date :";
            // 
            // CheckboxArrondir
            // 
            this.CheckboxArrondir.AutoSize = true;
            this.CheckboxArrondir.Location = new System.Drawing.Point(281, 176);
            this.CheckboxArrondir.Name = "CheckboxArrondir";
            this.CheckboxArrondir.Size = new System.Drawing.Size(115, 17);
            this.CheckboxArrondir.TabIndex = 11;
            this.CheckboxArrondir.Text = "Arrondir les valeurs";
            this.CheckboxArrondir.UseVisualStyleBackColor = true;
            // 
            // ButtonShare
            // 
            this.ButtonShare.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ButtonShare.FlatAppearance.BorderSize = 0;
            this.ButtonShare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonShare.Location = new System.Drawing.Point(107, 172);
            this.ButtonShare.Name = "ButtonShare";
            this.ButtonShare.Size = new System.Drawing.Size(76, 23);
            this.ButtonShare.TabIndex = 12;
            this.ButtonShare.Text = "PARTAGER";
            this.ButtonShare.UseVisualStyleBackColor = false;
            this.ButtonShare.Click += new System.EventHandler(this.ButtonShare_Click);
            // 
            // ButtonReset
            // 
            this.ButtonReset.BackColor = System.Drawing.Color.DarkRed;
            this.ButtonReset.FlatAppearance.BorderSize = 0;
            this.ButtonReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonReset.Location = new System.Drawing.Point(7, 172);
            this.ButtonReset.Name = "ButtonReset";
            this.ButtonReset.Size = new System.Drawing.Size(94, 23);
            this.ButtonReset.TabIndex = 13;
            this.ButtonReset.Text = "RÉINITIALISER";
            this.ButtonReset.UseVisualStyleBackColor = false;
            this.ButtonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // CheckBoxStartMinimized
            // 
            this.CheckBoxStartMinimized.AutoSize = true;
            this.CheckBoxStartMinimized.Location = new System.Drawing.Point(281, 160);
            this.CheckBoxStartMinimized.Name = "CheckBoxStartMinimized";
            this.CheckBoxStartMinimized.Size = new System.Drawing.Size(111, 17);
            this.CheckBoxStartMinimized.TabIndex = 14;
            this.CheckBoxStartMinimized.Text = "Démarrer minimisé";
            this.CheckBoxStartMinimized.UseVisualStyleBackColor = true;
            this.CheckBoxStartMinimized.CheckedChanged += new System.EventHandler(this.ButtonStartMinimized_CheckedChanged);
            // 
            // HoursForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Controls.Add(this.CheckBoxStartMinimized);
            this.Controls.Add(this.ButtonReset);
            this.Controls.Add(this.ButtonShare);
            this.Controls.Add(this.CheckboxArrondir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LabelFirstLauch);
            this.Controls.Add(this.LabelDateNow);
            this.Controls.Add(this.LabelFirstOpeningDate);
            this.Controls.Add(this.LabelDays);
            this.Controls.Add(this.LabelHours);
            this.Controls.Add(this.LabelTotalTime);
            this.Controls.Add(this.LabelMinutes);
            this.Controls.Add(this.LabelSeconds);
            this.Controls.Add(this.TopPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HoursForm";
            this.Text = "Hours";
            this.Load += new System.EventHandler(this.HoursForm_Load);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button MinimizeButton;
        private System.Windows.Forms.Label LabelTotalTime;
        private System.Windows.Forms.Label LabelSeconds;
        private System.Windows.Forms.Label LabelMinutes;
        private System.Windows.Forms.Label LabelHours;
        private System.Windows.Forms.Button HideButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LabelDays;
        private System.Windows.Forms.Label LabelFirstOpeningDate;
        private System.Windows.Forms.Label LabelDateNow;
        private System.Windows.Forms.Label LabelFirstLauch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButtonShare;
        private System.Windows.Forms.Button ButtonReset;
        private System.Windows.Forms.Button ButtonHelp;
        private System.Windows.Forms.CheckBox CheckboxArrondir;
        private System.Windows.Forms.CheckBox CheckBoxStartMinimized;
    }
}

