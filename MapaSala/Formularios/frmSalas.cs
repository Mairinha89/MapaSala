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
    public partial class frmSalas : Form
    {
        DataTable dados;
        int LinhaSelecionada;
        public frmSalas()
        {
            InitializeComponent();
            dados = new DataTable();

                foreach (var atributos in typeof(SalasEntidade).GetProperties())
                {
                    dados.Columns.Add(atributos.Name);
                }

                dados.Rows.Add(1, "Sala 2", 20, 20, true, true);
                dados.Rows.Add(2, "Sala 22", 30, 2, false, false);
                dados.Rows.Add(3, "Sala 23", 40, 1, false, true);

                dtGridSalas.DataSource = dados;

           

        }

      

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            SalasEntidade x = new SalasEntidade();
            x.Id = Convert.ToInt32(numId.Text);
           x.Nome = txtNome.Text;
            x.IsLab = chkIsLab.Checked;
            x.NumeroCadeiras = Convert.ToInt32(txtNumCadeira.Value);
            x.NumeroComputadores = Convert.ToInt32(txtNumPc.Value);
            x.Disponivel = chkDisponivel.Checked;

            dados.Rows.Add(x.Linha());
            LimparCampos();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }
        private void LimparCampos()
        {
            numId.Text = "";
            txtNome.Text = "";
            txtNumCadeira.Text = "";
            txtNumPc.Text = "";
            chkDisponivel.Checked = false;
            chkIsLab.Checked = false;
            
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            dtGridSalas.Rows.RemoveAt(LinhaSelecionada);
        }
        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            DataGridViewRow Editar = dtGridSalas.Rows[LinhaSelecionada];
            Editar.Cells[0].Value = numId.Text;
            Editar.Cells[1].Value = txtNome.Text;
            Editar.Cells[2].Value = txtNumCadeira.Text;
            Editar.Cells[3].Value = txtNumPc.Text;
            Editar.Cells[4].Value = chkDisponivel.Checked;
            Editar.Cells[5].Value = chkIsLab.Checked;
        }
        private void dtGridSalas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LinhaSelecionada = e.RowIndex;
            txtNome.Text = dtGridSalas.Rows[LinhaSelecionada].Cells[1].Value.ToString();
            txtNumCadeira.Text = dtGridSalas.Rows[LinhaSelecionada].Cells[2].Value.ToString();
            txtNumPc.Text = dtGridSalas.Rows[LinhaSelecionada].Cells[3].Value.ToString();
            chkIsLab.Checked = Convert.ToBoolean(dtGridSalas.Rows[LinhaSelecionada].Cells[0].Value);
            chkDisponivel.Checked = Convert.ToBoolean(dtGridSalas.Rows[LinhaSelecionada].Cells[0].Value);
            numId.Value = Convert.ToInt32(dtGridSalas.Rows[LinhaSelecionada].Cells[0].Value);

        }

      
        private void btnEditar_Click(object sender, EventArgs e)
        {
            DataGridViewRow Editar = dtGridSalas.Rows[LinhaSelecionada];
            Editar.Cells[0].Value = numId.Value;
            Editar.Cells[1].Value = txtNome.Text;
            Editar.Cells[2].Value = txtNumCadeira.Text;
            Editar.Cells[3].Value = txtNumPc.Text;
            Editar.Cells[4].Value = chkDisponivel.Checked;
            Editar.Cells[5].Value = chkDisponivel.Checked;
        }

        private void frmSalas_Load(object sender, EventArgs e)
        {

        }
    }
}
