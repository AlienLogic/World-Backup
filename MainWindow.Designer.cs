namespace World_Backup
{
	partial class MainWindow
	{
		/// <summary>
		/// Variabile di progettazione necessaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Pulire le risorse in uso.
		/// </summary>
		/// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Codice generato da Progettazione Windows Form

		/// <summary>
		/// Metodo necessario per il supporto della finestra di progettazione. Non modificare
		/// il contenuto del metodo con l'editor di codice.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.timeIntervalHours = new System.Windows.Forms.NumericUpDown();
			this.backupHistoryValue = new System.Windows.Forms.NumericUpDown();
			this.saveFolder = new System.Windows.Forms.TextBox();
			this.sourceFolderLabel = new System.Windows.Forms.Label();
			this.sourceFolder = new System.Windows.Forms.TextBox();
			this.timeIntervalMinutes = new System.Windows.Forms.NumericUpDown();
			this.timeIntervalSeconds = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.autoStartCheck = new System.Windows.Forms.CheckBox();
			this.timerStartStop = new System.Windows.Forms.Button();
			this.textLog = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.timeIntervalHours)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.backupHistoryValue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.timeIntervalMinutes)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.timeIntervalSeconds)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// timeIntervalHours
			// 
			resources.ApplyResources(this.timeIntervalHours, "timeIntervalHours");
			this.timeIntervalHours.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.timeIntervalHours.Name = "timeIntervalHours";
			this.timeIntervalHours.ValueChanged += new System.EventHandler(this.saveTimeIntervalHours);
			// 
			// backupHistoryValue
			// 
			resources.ApplyResources(this.backupHistoryValue, "backupHistoryValue");
			this.backupHistoryValue.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.backupHistoryValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.backupHistoryValue.Name = "backupHistoryValue";
			this.backupHistoryValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.backupHistoryValue.ValueChanged += new System.EventHandler(this.saveBackupHistory);
			// 
			// saveFolder
			// 
			resources.ApplyResources(this.saveFolder, "saveFolder");
			this.saveFolder.Name = "saveFolder";
			this.saveFolder.TextChanged += new System.EventHandler(this.saveSaveFolder);
			this.saveFolder.DoubleClick += new System.EventHandler(this.selectSaveFolder);
			// 
			// sourceFolderLabel
			// 
			resources.ApplyResources(this.sourceFolderLabel, "sourceFolderLabel");
			this.sourceFolderLabel.Name = "sourceFolderLabel";
			// 
			// sourceFolder
			// 
			resources.ApplyResources(this.sourceFolder, "sourceFolder");
			this.sourceFolder.Name = "sourceFolder";
			this.sourceFolder.TextChanged += new System.EventHandler(this.saveSourceFolder);
			this.sourceFolder.DoubleClick += new System.EventHandler(this.selectSourceFolder);
			// 
			// timeIntervalMinutes
			// 
			resources.ApplyResources(this.timeIntervalMinutes, "timeIntervalMinutes");
			this.timeIntervalMinutes.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.timeIntervalMinutes.Name = "timeIntervalMinutes";
			this.timeIntervalMinutes.ValueChanged += new System.EventHandler(this.saveTimeIntervalMinutes);
			// 
			// timeIntervalSeconds
			// 
			resources.ApplyResources(this.timeIntervalSeconds, "timeIntervalSeconds");
			this.timeIntervalSeconds.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.timeIntervalSeconds.Name = "timeIntervalSeconds";
			this.timeIntervalSeconds.ValueChanged += new System.EventHandler(this.saveTimeIntervalSeconds);
			// 
			// label3
			// 
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			// 
			// label4
			// 
			resources.ApplyResources(this.label4, "label4");
			this.label4.Name = "label4";
			// 
			// label5
			// 
			resources.ApplyResources(this.label5, "label5");
			this.label5.Name = "label5";
			// 
			// autoStartCheck
			// 
			resources.ApplyResources(this.autoStartCheck, "autoStartCheck");
			this.autoStartCheck.Name = "autoStartCheck";
			this.autoStartCheck.UseVisualStyleBackColor = true;
			this.autoStartCheck.CheckedChanged += new System.EventHandler(this.autoStartCheck_CheckedChanged);
			// 
			// timerStartStop
			// 
			resources.ApplyResources(this.timerStartStop, "timerStartStop");
			this.timerStartStop.Name = "timerStartStop";
			this.timerStartStop.UseVisualStyleBackColor = true;
			this.timerStartStop.Click += new System.EventHandler(this.timerStartStopEvent);
			// 
			// textLog
			// 
			resources.ApplyResources(this.textLog, "textLog");
			this.textLog.Name = "textLog";
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.Transparent;
			this.button1.BackgroundImage = global::World_Backup.Properties.Resources.IMGBIN_minecraft_story_mode_block_in_agar_io_worldcraft_3d_build_amp_craft_png_JPH8rKbr;
			resources.ApplyResources(this.button1, "button1");
			this.button1.FlatAppearance.BorderSize = 0;
			this.button1.Name = "button1";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.openAbout);
			// 
			// Form1
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textLog);
			this.Controls.Add(this.timerStartStop);
			this.Controls.Add(this.autoStartCheck);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.timeIntervalSeconds);
			this.Controls.Add(this.timeIntervalMinutes);
			this.Controls.Add(this.sourceFolder);
			this.Controls.Add(this.sourceFolderLabel);
			this.Controls.Add(this.saveFolder);
			this.Controls.Add(this.backupHistoryValue);
			this.Controls.Add(this.timeIntervalHours);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formClosing);
			this.Load += new System.EventHandler(this.formLoad);
			((System.ComponentModel.ISupportInitialize)(this.timeIntervalHours)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.backupHistoryValue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.timeIntervalMinutes)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.timeIntervalSeconds)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown timeIntervalHours;
		private System.Windows.Forms.NumericUpDown backupHistoryValue;
		private System.Windows.Forms.TextBox saveFolder;
		private System.Windows.Forms.Label sourceFolderLabel;
		private System.Windows.Forms.TextBox sourceFolder;
		private System.Windows.Forms.NumericUpDown timeIntervalMinutes;
		private System.Windows.Forms.NumericUpDown timeIntervalSeconds;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox autoStartCheck;
		private System.Windows.Forms.Button timerStartStop;
		private System.Windows.Forms.TextBox textLog;
		private System.Windows.Forms.Button button1;
	}
}

