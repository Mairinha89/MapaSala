using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model.Entitidades;

namespace MapaSala.Formularios
{
    public partial class frmProfessores : Form
    {
        DataTable dados;
        int LinhaSelecionada;
        public frmProfessores()
        {
            InitializeComponent();
            dados = new DataTable();


            foreach (var atributos in typeof(ProfessoresEntidade).GetProperties())
            {
                dados.Columns.Add(atributos.Name);
            }

            dados.Rows.Add(1, "Fernando", "Fernoka");
            dados.Rows.Add(2, "Alexandre", "Galvani");
            dados.Rows.Add(3, "Eliete", "Elietinha");

            dtGridProfessores.DataSource = dados;

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            ProfessoresEntidade p = new ProfessoresEntidade();
            p.Id = Convert.ToInt32(numId.Value);
            p.Apelido = txtApelido.Text;
            p.Nome = txtNomeCompleto.Text;

            dados.Rows.Add(p.Linha());

            LimparCampos();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            txtApelido.Text = "";
            txtNomeCompleto.Text = "";
            numId.Value = 0;
        }

        private void frmProfessores_Load(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            DataGridViewRow Editar = dtGridProfessores.Rows[LinhaSelecionada];
            Editar.Cells[0].Value = numId.Value;
            Editar.Cells[1].Value = txtNomeCompleto.Text;
            Editar.Cells[2].Value = txtApelido.Text;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            dtGridProfessores.Rows.RemoveAt(LinhaSelecionada);
        }

        private void dtGridProfessores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LinhaSelecionada = e.RowIndex;
            txtNomeCompleto.Text = dtGridProfessores.Rows[LinhaSelecionada].Cells[1].Value.ToString();
            txtApelido.Text = dtGridProfessores.Rows[LinhaSelecionada].Cells[2].Value.ToString();
            numId.Value = Convert.ToInt32(dtGridProfessores.Rows[LinhaSelecionada].Cells[0].Value.ToString());

           
        }
    }
}
