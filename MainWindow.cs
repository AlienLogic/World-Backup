using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace World_Backup
{
	public partial class MainWindow : Form
	{
		public string sourceFolderPath;
		public string saveFolderPath;

		private Timer timer;

		private const string MutexName = "MUTEX_SINGLEINSTANCEANDNAMEDPIPE";
		private bool _firstApplicationInstance;
		private System.Threading.Mutex _mutexApplication;

		private bool IsApplicationFirstInstance()
		{
			// Allow for multiple runs but only try and get the mutex once
			if (_mutexApplication == null)
				_mutexApplication = new System.Threading.Mutex(true, MutexName, out _firstApplicationInstance);

			return _firstApplicationInstance;
		}

		public MainWindow()
		{
			if (!IsApplicationFirstInstance())
			{
				MessageBox.Show("Applicazione già in esecuzione.");
				Close();
			}

			InitializeComponent();
			sourceFolder.Text			= Properties.Settings.Default.FOLDER_TO_BACKUP;
			saveFolder.Text				= Properties.Settings.Default.FOLDER_TO_SAVE;

			timeIntervalHours.Value		= Properties.Settings.Default.TIME_INTERVAL_HOURS;
			timeIntervalMinutes.Value	= Properties.Settings.Default.TIME_INTERVAL_MINUTES;
			timeIntervalSeconds.Value	= Properties.Settings.Default.TIME_INTERVAL_SECONDS;

			backupHistoryValue.Value	= Properties.Settings.Default.BACKUP_HISTORY;
			autoStartCheck.Checked		= Properties.Settings.Default.AUTOSTART;

			timer = new Timer();
			timer.Tick += new EventHandler(copyFolders);
			setTimerInterval();

			if (Properties.Settings.Default.AUTOSTART)
				timer.Start();

			timerButton();
		}

		public void setTimerInterval()
		{
			int time = ((int)timeIntervalHours.Value * 3600 + (int)timeIntervalMinutes.Value * 60 + (int)timeIntervalSeconds.Value) * 1000;

			if (time < 1)
			{
				time = 1000;
				timeIntervalSeconds.Value = 1;
			}

			timer.Interval = time;
		}

		private void timerStartStopEvent(object sender, EventArgs e)
		{
			if (Directory.Exists(sourceFolderPath) && Directory.Exists(saveFolderPath))
			{
				if (timer.Enabled)
				{
					timer.Stop();
				}
				else
				{
					setTimerInterval();
					timer.Start();
				}
			}
			else
			{
				MessageBox.Show("Directory mancante forse?");
			}

			timerButton();
		}

		public void timerButton()
		{
			if (timer != null && timer.Enabled)
			{
				sourceFolder.Enabled = false;
				saveFolder.Enabled = false;
				timeIntervalHours.Enabled = false;
				timeIntervalMinutes.Enabled = false;
				timeIntervalSeconds.Enabled = false;
				timerStartStop.Text = "Stop";
			}
			else
			{
				sourceFolder.Enabled = true;
				saveFolder.Enabled = true;
				timeIntervalHours.Enabled = true;
				timeIntervalMinutes.Enabled = true;
				timeIntervalSeconds.Enabled = true;
				timerStartStop.Text = "Start";
			}
		}

		public void copyFolders(object sender, EventArgs e)
		{
			if (Directory.Exists(sourceFolderPath) && Directory.Exists(saveFolderPath))
			{
				string subFolderName = DateTime.Now.ToString("yyyy_MM_dd HH_mm_ss");

				Directory.CreateDirectory(saveFolderPath + "\\" + subFolderName);

				foreach (string dirPath in Directory.GetDirectories(sourceFolderPath, "*", SearchOption.AllDirectories))
					Directory.CreateDirectory(dirPath.Replace(sourceFolderPath, saveFolderPath + "\\" + subFolderName));

				foreach (string newPath in Directory.GetFiles(sourceFolderPath, "*.*", SearchOption.AllDirectories))
					File.Copy(newPath, newPath.Replace(sourceFolderPath, saveFolderPath + "\\" + subFolderName), true);

				textLog.Text += DateTime.Now.ToString() + " - Backup eseguito." + (char)13 + (char)10;

				deleteOlderBackup();
			}
			else
			{
				textLog.Text += DateTime.Now.ToString() + " - Backup non eseguito, directory mancante forse?." + (char)13 + (char)10;
				timer.Stop();
				timerButton();
			}
		}

		private void deleteOlderBackup()
		{
			var di = new DirectoryInfo(saveFolderPath);
			var directories = di.GetDirectories()
								.OrderByDescending(d => d.CreationTime)
								.Select(d => d.FullName)
								.ToList();

			for (int i=0; i<directories.Count; i++)
			{
				if (i >= backupHistoryValue.Value)
				{
					Directory.Delete(directories.ElementAt(i), true);
					textLog.Text += "Backup eliminato: " + directories.ElementAt(i) + (char)13 + (char)10;
				}
			}
		}

		private void selectSourceFolder(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

			if (folderBrowserDialog.ShowDialog() != DialogResult.Cancel)
			{
				sourceFolder.Text = folderBrowserDialog.SelectedPath;
				sourceFolderPath = folderBrowserDialog.SelectedPath;

				Properties.Settings.Default.FOLDER_TO_BACKUP = folderBrowserDialog.SelectedPath;
				Properties.Settings.Default.Save();
			}
		}

		private void selectSaveFolder(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

			if (folderBrowserDialog.ShowDialog() != DialogResult.Cancel)
			{
				saveFolder.Text = folderBrowserDialog.SelectedPath;
				saveFolderPath = folderBrowserDialog.SelectedPath;

				Properties.Settings.Default.FOLDER_TO_SAVE = folderBrowserDialog.SelectedPath;
				Properties.Settings.Default.Save();
			}
		}

		private void saveSourceFolder(object sender, EventArgs e)
		{
			Properties.Settings.Default.FOLDER_TO_BACKUP = sourceFolder.Text;
			Properties.Settings.Default.Save();
			sourceFolderPath = sourceFolder.Text;
		}

		private void saveSaveFolder(object sender, EventArgs e)
		{
			Properties.Settings.Default.FOLDER_TO_SAVE = saveFolder.Text;
			Properties.Settings.Default.Save();
			saveFolderPath = saveFolder.Text;
		}

		private void saveBackupHistory(object sender, EventArgs e)
		{
			Properties.Settings.Default.BACKUP_HISTORY = (int)backupHistoryValue.Value;
			Properties.Settings.Default.Save();
		}

		private void saveTimeIntervalHours(object sender, EventArgs e)
		{
			Properties.Settings.Default.TIME_INTERVAL_HOURS = (byte)timeIntervalHours.Value;
			Properties.Settings.Default.Save();
		}

		private void saveTimeIntervalMinutes(object sender, EventArgs e)
		{
			Properties.Settings.Default.TIME_INTERVAL_MINUTES = (byte)timeIntervalMinutes.Value;
			Properties.Settings.Default.Save();
		}

		private void saveTimeIntervalSeconds(object sender, EventArgs e)
		{
			Properties.Settings.Default.TIME_INTERVAL_SECONDS = (byte)timeIntervalSeconds.Value;
			Properties.Settings.Default.Save();
		}

		private void autoStartCheck_CheckedChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.AUTOSTART = autoStartCheck.Checked;
			Properties.Settings.Default.Save();
		}

		private void openAbout(object sender, EventArgs e)
		{
			Form form = new AboutWindow();
			form.ShowDialog();
		}

		private void formLoad(object sender, EventArgs e)
		{
			Location = Properties.Settings.Default.WINDOW_POSITION;
		}

		private void formClosing(object sender, FormClosingEventArgs e)
		{
			Properties.Settings.Default.WINDOW_POSITION = Location;
			Properties.Settings.Default.Save();
		}
	}
}