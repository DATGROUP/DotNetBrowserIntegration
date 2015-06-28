using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNetIntegration
{

    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public partial class BrowserDemo : Form
    {
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        [System.Runtime.InteropServices.ComVisibleAttribute(true)]
        public class ScriptingObject
        {
            public void onError(String message)
            {
                MessageBox.Show(message, ".NET Client code");
            }

            public void onSuccess()
            {

            }

        };

        public BrowserDemo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser1.AllowWebBrowserDrop = false;
            webBrowser1.AllowNavigation = false;
            webBrowser1.IsWebBrowserContextMenuEnabled = false;
            webBrowser1.WebBrowserShortcutsEnabled = false;

            webBrowser1.ObjectForScripting = new ScriptingObject();
            // Uncomment the following line when you are finished debugging. 
            //webBrowser1.ScriptErrorsSuppressed = true
            this.webBrowser1.Url = new Uri(textBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser1.Document.InvokeScript("eval", new String[] { "" + txtNameSpace.Text + ".remove()" });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.Document.InvokeScript("eval", new String[] { ""+txtNameSpace.Text + ".add()" });
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            button2.Enabled = true;
            button3.Enabled = true;
        }




    }
}
