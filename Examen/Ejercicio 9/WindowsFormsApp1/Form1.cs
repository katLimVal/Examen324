using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        ServiceReference1.WebService1SoapClient ws = new ServiceReference1.WebService1SoapClient();

        public Form1()
        {
            InitializeComponent();
        }

        public void mostrarDatos() {
            this.dataGridView1.DataSource = ws.dsPersona().Tables["persona"];
            // en la web dataGridView1.databind()

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mostrarDatos();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            String ci = textBox1.Text;
            String nombre = textBox2.Text;
            String ap = textBox3.Text;
            String am = textBox4.Text;
            int res = ws.agregarPersona(ci, nombre, ap, am);
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            mostrarDatos();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            String ci= dataGridView1.CurrentRow.Cells[0].Value.ToString();
            int res = ws.eliminarPersona(ci);
            if (res > 0)
            {
                MessageBox.Show("Se elimino registro correctamente");
            }
            else {
                MessageBox.Show("No es posible eliminar");
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox1.ReadOnly = false;
            button1.Enabled = true;
            mostrarDatos();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox1.ReadOnly = true;
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String ci= dataGridView1.CurrentRow.Cells[0].Value.ToString();
            String nombre = textBox2.Text;
            String ap = textBox3.Text;
            String am = textBox4.Text;
            int res = ws.ActualizarDatosPersona(ci,nombre,ap,am);
            if (res > 0)
            {
                MessageBox.Show("Se actualizo registro correctamente");
            }
            else {
                MessageBox.Show("No se actualizo el registro");
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox1.ReadOnly = false;
            button1.Enabled = true;
            mostrarDatos();
        }
    }
}
