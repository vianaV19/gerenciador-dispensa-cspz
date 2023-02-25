using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;
using BLL;

namespace GerenciadorDispensa
{
    public partial class DispensaGUI : Form
    {

        private CentroBLL c = new CentroBLL();

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
            try
            {

                string query = "select data, assist, colab, total from tb_dispensa";

                dispAcomp_dtgv.DataSource = c.consulta("tb_dispensa");
                dispAcomp_dtgv.DataMember = "tb_dispensa";
                dispAcomp_dtgv.AutoSize = true;

                //query = "select d.data, a.acompanhamento, a.qntd from tb_acompanhamento as a inner join tb_dispensa as d on(d.id = a.id_dispensa)";

                //acomp_dtgv.DataSource = c.consultaComQuery(query, "tb_acompanhamento");
                //acomp_dtgv.DataMember = "tb_acompanhamento";
                //acomp_dtgv.AutoSize = true;

                //query = "select d.data, g.guarnicao, g.qntd from tb_guarnicao as g inner join tb_dispensa as d on(d.id = g.id_dispensa)";


                //guarnicao_dtgv.DataSource = c.consultaComQuery(query, "tb_guarnicao");
                //guarnicao_dtgv.DataMember = "tb_guarnicao";
                //guarnicao_dtgv.AutoSize = true;

                //query = "select d.data, l.lanche, l.turno, l.qntd from tb_lanche as l inner join tb_dispensa as d on(d.id = l.id_dispensa)";

                //lanche_dtgv.DataSource = c.consultaComQuery(query, "tb_lanche"); ;
                //lanche_dtgv.DataMember = "tb_lanche";
                //lanche_dtgv.AutoSize = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
