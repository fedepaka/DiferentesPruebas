using System.Collections;
using System.ComponentModel;

namespace PruebaWinform
{
    [RunInstaller(true)]
    public partial class MyInstaller : System.Configuration.Install.Installer
    {
        public MyInstaller()
        {
            InitializeComponent();
        }

        //Code to perform at the time of installing application
        public override void Install(System.Collections.IDictionary stateSaver)
        {
            System.Windows.Forms.MessageBox.Show("Installing Application...", "Paka", System.Windows.Forms.MessageBoxButtons.YesNoCancel, System.Windows.Forms.MessageBoxIcon.Information);
        }

        public override void Uninstall(IDictionary savedState)
        {
            System.Windows.Forms.MessageBox.Show("Uninstalling Application...");
        }
    }
}
