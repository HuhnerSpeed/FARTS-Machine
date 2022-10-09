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
        int _warmupCounterCount;
        bool _randomizerActive = false;
        int _randomizerCounterCount;
        int _activeOptionCounterCount;
        int _currentOptionDuration;
        int _currentOptionCountdown;
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
                this.button_Randomizer.Enabled = true;
                this.button_Attach.Enabled = false;
                this.button_Randomizer.Focus();
            }
            else
            {
                this.textBox_Status.ForeColor = Color.Red;
                this.textBox_Status.Text = "Could not attach. Please try again. Make sure Stranger is running.";
            }
            
        }

        private void button_Randomizer_Click(object sender, EventArgs e)
        {
            this.button_Randomizer.Enabled = false;
            this.buttonStopRandomizer.Enabled = true;
            this._randomizerActive = true;
            this.textBox_Status.Text = "Randomizer started.";
            this._baseHook.StartRandomizer();
            this.timerWarmup.Start();
        }

        private void buttonStopRandomizer_Click(object sender, EventArgs e)
        {
            this.button_Randomizer.Enabled = true;
            this.buttonStopRandomizer.Enabled = false;
            this._randomizerActive = false;
            this._baseHook.ResetActiveOption();
            this._randomizerCounterCount = 0;
            this.timerRandomizer.Stop();
            this.textBoxDuration.Text = "";
            this.textBoxCurrentEffect.Text = "";
            this._warmupCounterCount = 0;
            this.timerWarmup.Stop();
            this.textBox_Status.Text = "Randomizer stopped.";
        }

        private void timerWarmup_Tick(object sender, EventArgs e)
        {
            this._warmupCounterCount++;
            if (this._warmupCounterCount >= 10)
            {
                this.timerWarmup.Stop();
                this.timerRandomizer.Start();
                this._warmupCounterCount = 10;
            }
        }

        private void timerRandomizer_Tick(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(this._baseHook.GetActiveOptionName()) || this._currentOptionDuration < 1)
            {
                this._baseHook.RandomizeNextOption();
                this.textBoxDuration.Text = this._currentOptionCountdown.ToString();
                this.textBoxCurrentEffect.Text = this._baseHook.GetActiveOptionName();
                this._currentOptionDuration = this._baseHook.GetActiveOptionDuration();
                this._currentOptionCountdown = this._currentOptionDuration;
                this.textBoxDuration.Text = this._currentOptionCountdown.ToString();
                this.textBoxCurrentEffect.Text = this._baseHook.GetActiveOptionName();
            }
            else
            {
                this._randomizerCounterCount++;
                this._currentOptionCountdown--;
                this.textBoxDuration.Text = this._currentOptionCountdown.ToString();
            }

            if (this._randomizerCounterCount >= this._currentOptionDuration)
            {
                this._baseHook.ResetActiveOption();
                this._randomizerCounterCount = 0;
                this.timerRandomizer.Stop();
                this.textBoxDuration.Text = "";
                this._warmupCounterCount = 0;
                this.timerWarmup.Start();
            }

        }
    }
}
