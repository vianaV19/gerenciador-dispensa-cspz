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
        private int offsetH = 80;
      
        public DispensaGUI()
        {
            InitializeComponent();

            dispensa_dtgv.AutoSize = false;

        }


        private void DispensaGUI_Load(object sender, EventArgs e)
        {

            try
            {

                string query = "select data, assist, colab, total from tb_dispensa; ";

                dispensa_dtgv.DataSource = c.consultaComQuery(query, "tb_dispensa");
                dispensa_dtgv.DataMember = "tb_dispensa";
                dispensa_dtgv.AutoSize = true;

                query = "select d.data, a.acompanhamento, a.qntd, g.guarnicao, g.qntd, l.lanche, l.turno, l.qntd from tb_acompanhamento as a inner join tb_dispensa d inner join tb_guarnicao g inner join tb_lanche l";

                acompGuarnLanche_dtgv.DataSource = c.consultaComQuery(query, "tb_acompanhamento");
                acompGuarnLanche_dtgv.DataMember = "tb_acompanhamento";
                acompGuarnLanche_dtgv.AutoSize = true;

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

        private void placeholderLancheLeave(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;

            if (t.Text == "" || t.Text.Trim() == "") {
                t.ForeColor = SystemColors.ButtonShadow;

                if (t.Name == "lancheM_txt")
                    t.Text = "manha...";
                else
                    t.Text = "tarde...";
            }
        
        }




        private void datagridviewResize(object sender, EventArgs e)
        {
            int w = dataview_flyt.Width;
            int h = dataview_flyt.Height / 2;

            Control c = (Control)sender;

            c.Size = new Size(w, h);

            if (c.Name == "acompGuarnLanche_dtgv") c.Location = new Point(0, dispensa_dtgv.Size.Height);
        }
    }
}
