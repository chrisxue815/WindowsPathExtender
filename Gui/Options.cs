using System;
using System.Windows.Forms;
using WindowsPathExtender.Properties;

namespace WindowsPathExtender
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
        }

        private void Options_Load(object sender, EventArgs e)
        {
            var settings = Settings.Default;

            textBoxLoadName.Text = settings.LoadName;
            textBoxLoadOut.Text = settings.LoadOutput;
            checkBoxLoadSort.Checked = settings.LoadSort;
            checkBoxLoadCheck.Checked = settings.LoadCheck;
            checkBoxLoadExpand.Checked = settings.LoadExpand;

            textBoxSaveName.Text = settings.SaveName;
            textBoxSaveFormat.Text = settings.SaveFormat;
            textBoxSaveIn.Text = settings.SaveInput;
            textBoxSaveOut.Text = settings.SaveOutput;
            checkBoxSaveBackup.Checked = settings.SaveBackup;
            checkBoxSaveCheck.Checked = settings.SaveCheck;

            switch (settings.LoadLocation)
            {
                case "sys":
                    radioButtonLoadSystem.Checked = true;
                    break;
                case "user":
                    radioButtonLoadUser.Checked = true;
                    break;
                default:
                    radioButtonLoadBoth.Checked = true;
                    break;
            }

            switch (settings.SaveLocation)
            {
                case "user":
                    radioButtonSaveUser.Checked = true;
                    break;
                default:
                    radioButtonSaveSystem.Checked = true;
                    break;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            var settings = Settings.Default;

            settings.LoadName = textBoxLoadName.Text;
            settings.LoadOutput = textBoxLoadOut.Text;
            settings.LoadSort = checkBoxLoadSort.Checked;
            settings.LoadCheck = checkBoxLoadCheck.Checked;
            settings.LoadExpand = checkBoxLoadExpand.Checked;

            settings.SaveName = textBoxSaveName.Text;
            settings.SaveFormat = textBoxSaveFormat.Text;
            settings.SaveInput = textBoxSaveIn.Text;
            settings.SaveOutput = textBoxSaveOut.Text;
            settings.SaveBackup = checkBoxSaveBackup.Checked;
            settings.SaveCheck = checkBoxSaveCheck.Checked;

            if (radioButtonLoadSystem.Checked) settings.LoadLocation = "sys";
            else if (radioButtonLoadUser.Checked) settings.LoadLocation = "user";
            else if (radioButtonLoadBoth.Checked) settings.LoadLocation = "both";

            if (radioButtonSaveSystem.Checked) settings.SaveLocation = "sys";
            else if (radioButtonSaveUser.Checked) settings.SaveLocation = "user";

            settings.Save();

            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
