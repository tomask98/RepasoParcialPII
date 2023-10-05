using ModeloParcial.Entidades;
using ModeloParcial.Servicios;
using ModeloParcial.Servicios.Implementacion;
using ModeloParcial.Servicios.Interfaz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModeloParcial.Presentacion
{
    public partial class frmOrdenRetiro : Form
    {
        IServicio servicio = null;
        OrdenRetiro nueva = null;
        public frmOrdenRetiro(FabricaServicio fabrica)
        {
            InitializeComponent();
            servicio = fabrica.CrearServicio();
            nueva = new OrdenRetiro();
        }

        private void frmOrdenRetiro_Load(object sender, EventArgs e)
        {
            dtpFecha.Value = DateTime.Today;
            txtResponsable.Text = "";
            npCantidad.Value = 1;



            CargarMaterial();
        }

        private void CargarMaterial()
        {
            cboMaterial.DataSource = servicio.TraerMaterial();
            cboMaterial.ValueMember = "codigo";
            cboMaterial.DisplayMember = "nombre";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(cboMaterial.SelectedIndex== -1)
            {
                MessageBox.Show("seleccione un material", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrEmpty(txtResponsable.Text))
            {
                MessageBox.Show("Indique el nombre del responsable", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if(npCantidad.Value ==0)
            {
                MessageBox.Show("debe ingresar una cantidad valida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            foreach(DataGridViewRow row  in dgvDetalles.Rows)
            {
                if (row.Cells["ColMaterial"].Value.ToString().Equals(cboMaterial.Text))
                {
                    MessageBox.Show("Este material ya esta cargado....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            Material m = (Material)cboMaterial.SelectedItem;

            int cant = Convert.ToInt32(npCantidad.Value);
            DetalleOrden detalle = new DetalleOrden(m, cant);
            nueva.AgregarDetalle(detalle);

            dgvDetalles.Rows.Add(new object[] { m.Codigo, m.Nombre, m.Stock,cant, "Quitar" });



        }

        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvDetalles.CurrentCell.ColumnIndex==4)
            {
                nueva.quitarDetalle(dgvDetalles.CurrentRow.Index);
                dgvDetalles.Rows.RemoveAt(dgvDetalles.CurrentRow.Index);

            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtResponsable.Text))
            {
                MessageBox.Show("Debe ingresar un Responsable...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (dgvDetalles.Rows.Count == 0)
            {
                MessageBox.Show("Debe ingresar al menos un detalle...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            grabarOrden();
        }

        private void grabarOrden()
        {
            nueva.Fecha = Convert.ToDateTime(dtpFecha.Value);
            nueva.Responsable = txtResponsable.Text;

            if (servicio.crearOrden(nueva))
            {
                MessageBox.Show("Se registró con éxito el presupuesto...", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("NO se pudo registrar el presupuesto...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
