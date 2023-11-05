using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RotmgDrops
{
    public partial class MainForm : Form
    {
        private string[] bosses = { "MBC", "VOID", "CULT", "BRIDGE", "MAGE", "KING", "WORM", "CRYSTAL", "QUEEN", "BEEK" };
        private string filePath = "C:\\Users\\Johny\\Desktop\\drops.txt";
        private string logText = "";

        public MainForm()
        {
            InitializeComponent();
            bossList.Items.AddRange(bosses);
            bossList.SelectedIndex = 0;
        }

        private void log_button_Click(object sender, EventArgs e)
        {
            string finalText = "\n" + bossList.Text + ";";
            finalText += logText;
            finalText += getItem(att, att_num, "att");
            finalText += getItem(def, def_num, "def");
            finalText += getItem(life, life_num, "life");
            finalText += getItem(mana, mana_num, "mana");

            finalText += getItem(gwis, gwis_num, "gwis");
            finalText += getItem(gvit, gvit_num, "gvit");
            finalText += getItem(gspd, gspd_num, "gspd");
            finalText += getItem(gdex, gdex_num, "gdex");
            finalText += getItem(gdef, gdef_num, "gdef");
            finalText += getItem(gatt, gatt_num, "gatt");
            finalText += getItem(gmana, gmana_num, "gmana");
            finalText += getItem(glife, glife_num, "glife");
            finalText += getItem(domi, domi_num, "domi");
            finalText += getItem(wyrm, wyrm_num, "wyrm");
            finalText += getItem(mother, mother_num, "mother");

            finalText += getItem(vbow, "vbow");
            finalText += getItem(vquiver, "vquiver");
            finalText += getItem(nil, "nil");
            finalText += getItem(source, "source");
            finalText += getItem(omni, "omni");

            finalText += getItem(colo, "colo");
            finalText += getItem(mseal, "mseal");
            finalText += getItem(bplate, "bplate");
            finalText += getItem(potato, "potato");
            finalText += other.Text;

            //Remove the last char -> ;
            if (finalText[finalText.Length-1] == ';') 
                finalText = finalText.Remove(finalText.Length - 1, 1);

            //Add 0 if empty
            if (finalText.Split(';').Length == 1)
                finalText += ";0";

            //Write dialog -> append
            DialogResult dialogResult = MessageBox.Show(finalText, "Is this correct?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
                if (File.Exists(filePath))
                    File.AppendAllText(filePath, finalText);
        }

        private void bossList_SelectedIndexChanged(object sender, EventArgs e)
        {
            other.Text = "";
            foreach (Control c in this.Controls)
            {
                if (c is CheckBox)
                    ((CheckBox)c).Checked = false;
                if (c is NumericUpDown)
                    ((NumericUpDown)c).Value = 1;
            }
        }

        private string getItem(CheckBox ch, NumericUpDown num, string s)
        {
            string final = "";
            if (ch.Checked)
                for (int i = 0; i < num.Value; i++)
                    final += s + ";";

            return final;
        }

        private string getItem(CheckBox ch, string s)
        {
            if (ch.Checked)
                return s + ";";
            else
                return string.Empty;
        }
    }
}
