using Model.Entitidades;
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
  
        public partial class frmCursos: Form
        {
            DataTable dados;
            int LinhaSelecionada;

            public frmCursos()
            {
                InitializeComponent();
                dados = new DataTable();

                foreach (var atributos in typeof(CursosEntidade).GetProperties())
                {
                    dados.Columns.Add(atributos.Name);
                }

                dados.Rows.Add(1, "DS", "Integral");
                dados.Rows.Add(2, "ADM", "Integral");
                dados.Rows.Add(3, "IF", "Manha");

                dtGridCursos.DataSource = dados;

            }

            private void btnSalvar_Click(object sender, EventArgs e)
            {
                DisciplinaEntidade d = new DisciplinaEntidade();
                d.Id = Convert.ToInt32(numId.Value);
                d.Nome = txtNomeCurso.Text;
                d.Sigla = txtTurno.Text;

                dados.Rows.Add(d.Linha());
                LimparCampos();
            }

            private void btnLimpar_Click(object sender, EventArgs e)
            {
                LimparCampos();
            }

            private void LimparCampos()
            {
                numId.Value = 0;
                txtNomeCurso.Text = "";
                txtTurno.Text = "";
                chkAtivo.Checked = false;
            }

            private void dtGridDisciplina_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                LinhaSelecionada = e.RowIndex;
                txtNomeCurso.Text = dtGridCursos.Rows[LinhaSelecionada].Cells[1].Value.ToString();
                txtTurno.Text = dtGridCursos.Rows[LinhaSelecionada].Cells[2].Value.ToString();
                numId.Value = Convert.ToInt32(dtGridCursos.Rows[LinhaSelecionada].Cells[0].Value.ToString());

                //MessageBox.Show("Novo Valor: " + LinhaSelecionada);
            }

            private void btnExcluir_Click(object sender, EventArgs e)
            {
                dtGridCursos.Rows.RemoveAt(LinhaSelecionada);
            }




            private void btnEditar_Click_1(object sender, EventArgs e)
            {
                DataGridViewRow Editar = dtGridCursos.Rows[LinhaSelecionada];
                Editar.Cells[0].Value = numId.Value;
                Editar.Cells[1].Value = txtNomeCurso.Text;
                Editar.Cells[2].Value = txtTurno.Text;
            }

        private void frmCursos_Load(object sender, EventArgs e)
        {

        }
    }
}
