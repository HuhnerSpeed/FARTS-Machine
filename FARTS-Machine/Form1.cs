using FARTS_Machine.Hooks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FARTS_Machine
{
    public partial class Form1 : Form
    {
        private BaseHook _baseHook;
        public Form1()
        {
            InitializeComponent();
            this._baseHook = new BaseHook();
        }

        private void button_Attach_Click(object sender, EventArgs e)
        {
            this._baseHook.AttachToProcess();
            if (this._baseHook.IsAttached)
            {
                this.textBox_Status.ForeColor = Color.Green;
                this.textBox_Status.Text = "Successfully attached to Stranger's Wrath.";
                this.button_Attach.Text = "Detach from Game";
            }
            else
            {
                this.textBox_Status.ForeColor = Color.Red;
                this.textBox_Status.Text = "Could not attach. Please try again.";
            }
            
        }
    }
}
