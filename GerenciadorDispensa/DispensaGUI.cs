using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BLL;
using DTO;

namespace GerenciadorDispensa
{
    public partial class DispensaGUI : Form
    {

        private CentroBLL c = new CentroBLL();

        private Color placeHolderColor = SystemColors.ButtonShadow;
        
        //dataview dynamic size offsets
        private int offsetW = 50;
        private int offsetH = 80;

        private int dispensaID;
      
        public DispensaGUI()
        {
            InitializeComponent();

            dispensa_dtgv.AutoSize = false;

        }

        private void DispensaGUI_Load(object sender, EventArgs e)
        {
            //setting months in mesfilter_cbx
            for (int i = 1; i <= 12; i++) {
                mesfilter_cbx.Items.Add(i);
            }

            retrieve();
        }

        //retrieve data from database
        private void retrieve() {
            try
            {

                string query = "select date(data) as data, assist, colab, total, sobremesa, qntd_sobremesa, proteina, qntd_proteina from tb_dispensa; ";

                dispensa_dtgv.DataSource = c.consultaComQuery(query, "tb_dispensa");
                dispensa_dtgv.DataMember = "tb_dispensa";
                dispensa_dtgv.AutoSize = true;


            }
            catch (Exception ex)
            {
                MessageBox.Show(null, "Não foi possível fazer a consulta. Erro: " + ex.Message, "Exception!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                else { t.Text = "qntd..."; t.ForeColor = placeHolderColor; }
            }
            catch
            {
                MessageBox.Show(null, "Somente Números!", "Error de Entrada!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                t.Text = "qntd...";
                t.ForeColor = placeHolderColor;
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
                t.ForeColor = placeHolderColor;

                if (t.Name == "lancheM_txt")
                    t.Text = "manha...";
                else
                    t.Text = "tarde...";
            }
        
        }




        private void datagridviewResize(object sender, EventArgs e)
        {
            int w = dataview_flyt.Width;
            int h = dataview_flyt.Height;

            Control c = (Control)sender;

            c.Size = new Size(w, h);

            if (c.Name == "acompGuarnLanche_dtgv") c.Location = new Point(0, dispensa_dtgv.Size.Height);
        }

        private void saveData_btn_Click(object sender, EventArgs e)
        {

            if (assist_txt.Text != "" && colab_txt.Text != "" && projet_txt.Text != "" && proteina_txt.Text != "" 
                 && proteinaQntd_txt.Text != ""
                 && sobremesa_txt.Text != "" && sobremesaQntd_txt.Text != "" 
                 && (acomp_txt.Text != "" || acomp2_txt.Text != "" || acomp3_txt.Text != "" || acomp4_txt.Text != "")
                 && (acompQntd_txt.Text != "" || acompQntd2_txt.Text != "" || acompQntd3_txt.Text != "" || acompQntd4_txt.Text != "")
                 && (guarnicao_txt.Text != "" && guarnicaoQntd_txt.Text != "" || guarnicao2_txt.Text != "" && guarnicaoQntd2_txt.Text != "")
                 && lancheM_txt.Text != "" && lancheMQntd_txt.Text != "" && lancheT_txt.Text != "" && lancheTQntd_txt.Text != "" 
                 && total_txt.Text != "")
            {

                try
                {
                    //conecta e faz o insert no banco de dados
                    //cadastra dispensa
                    Dispensa d = new Dispensa(Convert.ToInt16(assist_txt.Text),
                        Convert.ToInt16(projet_txt.Text), Convert.ToInt16(colab_txt.Text),
                        Convert.ToInt16(total_txt.Text), proteina_txt.Text, Convert.ToInt16(proteinaQntd_txt.Text),
                        sobremesa_txt.Text, Convert.ToInt16(sobremesaQntd_txt.Text));

                    Acompanhamento[] acomps = {
                        acomp_txt.Text != "" && acompQntd_txt.Text != "" ? new Acompanhamento(acomp_txt.Text, Convert.ToInt16(acompQntd_txt.Text)) : null,
                        acomp2_txt.Text != "" && acompQntd2_txt.Text != "" ? new Acompanhamento(acomp2_txt.Text, Convert.ToInt16(acompQntd2_txt.Text)) : null,
                        acomp3_txt.Text != "" && acompQntd3_txt.Text != "" ? new Acompanhamento(acomp3_txt.Text, Convert.ToInt16(acompQntd3_txt.Text)) : null,
                        acomp4_txt.Text != "" && acompQntd4_txt.Text != "" ? new Acompanhamento(acomp4_txt.Text, Convert.ToInt16(acompQntd4_txt.Text)) : null
                    };



                    Guarnicao[] guarns = {
                        guarnicao_txt.Text != "" && guarnicaoQntd_txt.Text != "" ? new Guarnicao(guarnicao_txt.Text, Convert.ToInt16(guarnicaoQntd_txt.Text)) : null,
                        guarnicao2_txt.Text != "" && guarnicaoQntd2_txt.Text != "" ? new Guarnicao(guarnicao2_txt.Text, Convert.ToInt16(guarnicaoQntd2_txt.Text)) : null
                    };

                    Lanche m = new Lanche(lancheM_txt.Text, "manha", Convert.ToInt16(lancheMQntd_txt.Text));
                    Lanche t = new Lanche(lancheT_txt.Text, "tarde", Convert.ToInt16(lancheTQntd_txt.Text));

                    c.cadastrarAcompanhamento(acomps);
                    c.cadastrarDispensa(d);
                    c.cadastrarGuarnicao(guarns);
                    c.cadastrarLanche(m);
                    c.cadastrarLanche(t);

                    retrieve();

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.StackTrace, "Error ao Inserir!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch(FormatException ex){
                    MessageBox.Show(ex.StackTrace, "Caractere digitado é invalido!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                catch(Exception ex){
                    MessageBox.Show(ex.StackTrace, "Error! Contate o desenvolvedor!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("Por favor preencha todos os campos!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clearText_btn_Click(object sender, EventArgs e)
        {
            //limpando valores
            assist_txt.Text = "";
            colab_txt.Text = "";
            total_txt.Text = "";
            projet_txt.Text = "";
            proteina_txt.Text = "";
            sobremesa_txt.Text = "";
            acomp_txt.Text = "";
            guarnicao_txt.Text = "";

            lancheM_txt.Text = "manha...";
            lancheM_txt.ForeColor = placeHolderColor;

            lancheMQntd_txt.Text = "qntd...";
            lancheMQntd_txt.ForeColor = placeHolderColor;

            lancheT_txt.Text = "tarde...";
            lancheT_txt.ForeColor = placeHolderColor;

            lancheTQntd_txt.Text = "qntd...";
            lancheTQntd_txt.ForeColor = placeHolderColor;

            guarnicaoQntd_txt.Text = "qntd...";
            guarnicaoQntd_txt.ForeColor = placeHolderColor;

            proteinaQntd_txt.Text = "qntd...";
            proteinaQntd_txt.ForeColor = placeHolderColor;

            sobremesaQntd_txt.Text = "qntd...";
            sobremesaQntd_txt.ForeColor = placeHolderColor;

            acompQntd_txt.Text = "qntd...";
            acompQntd_txt.ForeColor = placeHolderColor;
        }

        private void mesfilter_cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            //conigura os dias de acordo com mes selecionado
            diafilter_cbx.Items.Clear();

            int days, mes = mesfilter_cbx.SelectedIndex + 1;

            if (mes == 2)
                days = 28;
            else  
                if(mes < 8)
                    if (mes % 2 != 0)
                        days = 31;
                    else
                        days = 30;
                else
                    if (mes % 2 != 0)
                        days = 30;
                    else
                        days = 31;

            for (int i = 1; i <= days; i++)
            {
                diafilter_cbx.Items.Add(i);
            }
        }

        private void lancheTQntd_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void lancheT_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dispensa_dtgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string data = dispensa_dtgv.Rows[e.RowIndex].Cells[0].Value.ToString().Split(' ')[0];

            

        }
    }
}
