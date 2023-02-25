using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerenciadorDispensa
{
    public partial class DispensaGUI : Form
    {

        private Color placeholder = SystemColors.ButtonShadow;

        //dataview dynamic size offsets
        private int offsetW = 50;
        private int offsetH = 65;
      
        public DispensaGUI()
        {
            InitializeComponent();

        }


        private void DispensaGUI_Load(object sender, EventArgs e)
        {
     
        }

      

        private void DispensaGUI_Resize(object sender, EventArgs e)
        {
            dataview_flyt.Size = new Size(Width - (inputs_flyt.Width + offsetW), Height - offsetH);
        }

        private void qntdEnter(object sender, EventArgs e)
        {
            TextBox t = (TextBox) sender;

            if (t.Text.Equals("qntd...")) t.Text = "";

            if (t.ForeColor != SystemColors.WindowText) t.ForeColor = SystemColors.WindowText;
        }

        private void qntdLeave(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;

            try
            {
                if (t.Text != "") { double val = Convert.ToDouble(t.Text); }
                else { t.Text = "qntd..."; t.ForeColor = placeholder; }
            }
            catch
            {
                MessageBox.Show("Apenas Numeros!");

                t.Text = "qntd...";
                t.ForeColor = placeholder;
            }
        }
        
        private void placeholderEnter(object sender, EventArgs e)
        {
            TextBox t = (TextBox) sender;

            if (t.ForeColor != SystemColors.WindowText) {
                t.ForeColor = SystemColors.WindowText;
                t.Text = "";
            }
        }

        private void acompQntd_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataviewResize(object sender, EventArgs e) {

            int w = dataview_flyt.Width;
            int h = dataview_flyt.Height / 3;

            dispAcomp_dtgv.Size = new Size(w, h);
            protGuarni_dtgv.Size = new Size(w, h);
            sobLanche_dtgv.Size = new Size(w, h);
        }
    }
}
