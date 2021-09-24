using System;
using System.Windows.Forms;
using System.IO;

namespace MyFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string SelectedFileMethod
        {
            get
            {
                foreach (Control c in groupBox1.Controls)
                {
                    if (c is RadioButton && ((RadioButton)c).Checked)
                    {
                        return "My" + c.Text;
                    }
                }

                throw new Exception("未选择");
            }
        }

        private string SelectedFileMethodFullName
        {
            get { return "MyFile.Method." + SelectedFileMethod; }
        }

        private void Execute(object sender)
        {
            try
            {
                var instance = this.GetType().Assembly.CreateInstance(SelectedFileMethodFullName);
                var method = instance.GetType().GetMethod(((Control)sender).Text);
                var result = method.Invoke(instance, null);
                richTextBox1.Text = result == null ? "操作成功!" : result.ToString();
            }
            catch (Exception ex)
            {
                richTextBox1.Text = (ex.Message + (ex.InnerException == null ? "" : ex.InnerException.Message));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var fileDirc = Application.StartupPath + @"\files";
            if (!Directory.Exists(fileDirc))
                Directory.CreateDirectory(fileDirc);
        }

        private void btn_click(object sender, EventArgs e)
        {
            Execute(sender);
        }
    }
}
