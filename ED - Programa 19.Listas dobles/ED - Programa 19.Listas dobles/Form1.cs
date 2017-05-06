using System;
using System.Windows.Forms;

namespace ED___Programa_19.Listas_dobles
{
    public partial class Form1 : Form
    {
        Inventario inventario = new Inventario();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto(txtCodigo.Text, txtNombre.Text, int.Parse(txtCantidad.Text), Convert.ToSingle(txtPrecio.Text));
            inventario.agregar(producto);
        }

        private void btnEnInicio_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto(txtCodigo.Text, txtNombre.Text, int.Parse(txtCantidad.Text), Convert.ToSingle(txtPrecio.Text));
            inventario.agregarInicio(producto);
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto(txtCodigo.Text, txtNombre.Text, int.Parse(txtCantidad.Text), Convert.ToSingle(txtPrecio.Text));
            if (inventario.insertar(producto, int.Parse(txtPosicion.Text)))
                txtMostrar.Text = "Se ha insertado el producto " + txtCodigo.Text + " exitosamente.";
            else
                txtMostrar.Text = "No existe esa posición.";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Producto auxiliar = inventario.buscar(txtCodigo.Text);
            if (auxiliar != null)
                txtMostrar.Text = auxiliar.ToString();
            else
                txtMostrar.Text = "No se encontró ese producto.";
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (inventario.borrar(txtCodigo.Text))
                txtMostrar.Text = "El producto " + txtCodigo.Text + " se borró con éxito.";
            else
                txtMostrar.Text = "No existe tal producto.";
        }

        private void btnBorrarPrimero_Click(object sender, EventArgs e)
        {
            if (inventario.borrarPrimero())
                txtMostrar.Text = "El primer producto se borró con éxito.";
            else
                txtMostrar.Text = "No hay productos.";
        }

        private void btnBorrarUltimo_Click(object sender, EventArgs e)
        {
            if (inventario.borrarUltimo())
                txtMostrar.Text = "El último producto se borró con éxito.";
            else
                txtMostrar.Text = "No hay productos.";
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            txtMostrar.Text = inventario.reporte();
        }

        private void btnReporteInv_Click(object sender, EventArgs e)
        {
            txtMostrar.Text = inventario.reporteInverso();
        }
    }
}
