using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Test {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            var data = new BingHomepage();
            pictureBox1.Image = data.GetImage(Path.GetTempFileName());
            label1.Text = data.GetCopyright;
            linkLabel1.Text = data.GetCopyrightLink;
            linkLabel1.Click += (s, e) => new Process { StartInfo = new ProcessStartInfo(linkLabel1.Text) }.Start();
        }
    }
}