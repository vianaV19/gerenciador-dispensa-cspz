


namespace gerenciador_dispensa
{
    using System.Data;
    using MySql.Data.MySqlClient;
    public partial class CentroSocial : Form
    {
        public CentroSocial()
        {
            InitializeComponent();

            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void CentroSocial_Load(object sender, EventArgs e)
        {
            string query = "select data, assist, colab, total, proteina, qntd_proteina, sobremesa, qntd_sobremesa from tb_dispensa";
            DataSet dataSet = new DataSet();

            try {

                BDConnection conn = BDConnection.getInstance();
                MySqlDataAdapter cmd = new MySqlDataAdapter(query, conn.GetConnection());

                cmd.Fill(dataSet, "tb_dispensa");
                dispensa_dtgv.DataSource = dataSet;
                dispensa_dtgv.DataMember = "tb_dispensa";

                query = "select d.data, a.acompanhamento, a.qntd from tb_acompanhamento as a inner join tb_dispensa as d on(d.id = a.id_dispensa)";

                cmd = new MySqlDataAdapter(query, conn.GetConnection());
                cmd.Fill(dataSet, "tb_acompanhamento");
                acomp_dtgv.DataSource = dataSet;
                acomp_dtgv.DataMember = "tb_acompanhamento";

                query = "select d.data, g.guarnicao, g.qntd from tb_guarnicao as g inner join tb_dispensa as d on(d.id = g.id_dispensa)";

                cmd = new MySqlDataAdapter(query, conn.GetConnection());
                cmd.Fill(dataSet, "tb_guarnicao");
                guarnicao_dtgv.DataSource = dataSet;
                guarnicao_dtgv.DataMember = "tb_guarnicao";

                query = "select d.data, l.lanche, l.turno, l.qntd from tb_lanche as l inner join tb_dispensa as d on(d.id = l.id_dispensa)";

                cmd = new MySqlDataAdapter(query, conn.GetConnection());
                cmd.Fill(dataSet, "tb_lanche");
                lanche_dtgv.DataSource = dataSet;
                lanche_dtgv.DataMember = "tb_lanche";

                cmd.Dispose();
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message);
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void editaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
       
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //incluir 

            if (assist_txt.Text != "" && colab_txt.Text != "" && projetos_txt.Text != "" && proteina_txt.Text != "" && proteinaQntd_txt.Text != ""
                 && sobremesa_txt.Text != "" && sobremesaQntd_txt.Text != "" && acompanhamento_txt.Text != "" && acompanhamentoQntd_txt.Text != ""
                 && guarnicao_txt.Text != "" && guarnicaoQntd_txt.Text != "" && lanche_txt.Text != ""
                 && turno_txt.Text != "" && lancheQntd_txt.Text != "" && total_txt.Text != "")
            {
                String query = "insert into tb_dispensa " +
                    "( assist, colab, total, proteina, qntd_proteina, sobremesa, qntd_sobremesa) " +
                    "values " +
                    "( @assist, @colab, @total, @proteina, @qntd_proteina, @sobremesa, @qntd_sobremesa)";
                try
                {
                    //conecta e faz o insert no banco de dados
                    BDConnection conn = BDConnection.getInstance();
                    MySqlCommand cmd = new MySqlCommand(query, conn.GetConnection());
                  
                    cmd.Parameters.Add("@assist", MySqlDbType.UInt32).Value = Convert.ToInt32(assist_txt.Text);
                    cmd.Parameters.Add("@colab", MySqlDbType.UInt32).Value = Convert.ToInt32(colab_txt.Text);
                    cmd.Parameters.Add("@total", MySqlDbType.UInt32).Value = Convert.ToInt32(total_txt.Text);
                    cmd.Parameters.Add("@proteina", MySqlDbType.String).Value = proteina_txt.Text;
                    cmd.Parameters.Add("@qntd_proteina", MySqlDbType.Int32).Value = Convert.ToInt32(proteinaQntd_txt.Text);
                    cmd.Parameters.Add("@sobremesa", MySqlDbType.String).Value = sobremesa_txt.Text;
                    cmd.Parameters.Add("@qntd_sobremesa", MySqlDbType.UInt32).Value = Convert.ToInt32(sobremesaQntd_txt.Text);

                    cmd.ExecuteNonQuery();

                    cmd.Connection.Close();

                }
                catch (MySqlException ex)
            {
                    MessageBox.Show(ex.StackTrace, "Error Mysql!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else {
                MessageBox.Show("Por favor preencha todos os campos!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
       
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}