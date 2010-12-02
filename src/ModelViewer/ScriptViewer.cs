using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DatDigger;
using System.IO;

namespace ModelViewer
{
    public partial class ScriptViewer : Form
    {
        DatDigger.Sections.Script.LuaFile lf;

        public ScriptViewer(DatDigger.Sections.Script.LuaFile path)
        {
            lf = path;
            InitializeComponent();
            this.debugText.Text = lf.DataAsString;            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveAsFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                BinaryWriter stream = new BinaryWriter(sfd.OpenFile());
                stream.Write(lf.Data);
                stream.Flush();
                stream.Close();
            }

        }
    }
}
