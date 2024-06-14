using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace conexion
{
    public partial class Form1 : Form
    {

        private MySqlConnection cnx = null;
        MySqlCommand cmd = null;
        DataTable dt = null;
        Conexion C = null;
        int RR, GG, BB;
        int meR, meG, meB;
        int r2, g2, b2;
        string[] cad = new string[100];
        int cv;
        public Form1()
        {
            InitializeComponent();
            C = new Conexion();
            cnx = C.Cnx();
            Listar();
            btnGuardar.Enabled = false;
            btnColorear.Enabled = false;
        }


        private void btnAbrir_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Todos|*.*|Archivos JPEG|*.jpg|Archivos GIF|*.gif";
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
            Bitmap bmp = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = bmp;
            string[] cad = new string[100];
            cv = 0;
            btnGuardar.Enabled = true;
            btnColorear.Enabled = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && textBox3.Text != null && textBox2.Text != null && textBox1.Text != null
                && Int32.Parse(textBox3.Text) >= 0 && Int32.Parse(textBox2.Text) >= 0 && Int32.Parse(textBox1.Text) >= 0)
            {
                r2 = Int32.Parse(textBox3.Text);
                g2 = Int32.Parse(textBox2.Text);
                b2 = Int32.Parse(textBox1.Text);
                Guardar(txtNombre.Text, int.Parse(txtR.Text), int.Parse(txtG.Text), int.Parse(txtB.Text), r2, g2, b2);
                Listar();
            }
            else
            {
                MessageBox.Show("Debe llenar todas las casillas ", "ADVERTENCIA");
            }
        }


        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Color c = new Color();
            int x, y, mR = 0, mG = 0, mB = 0;
            x = e.X;
            y = e.Y;
            for (int i = x; i < x + 10; i++)
                for (int j = y; j < y + 10; j++)
                {
                    c = bmp.GetPixel(i, j);
                    mR = mR + c.R;
                    mG = mG + c.G;
                    mB = mB + c.B;
                }
            mR = mR / 100;
            mG = mG / 100;
            mB = mB / 100;
            txtR.Text = mR.ToString();
            txtG.Text = mG.ToString();
            txtB.Text = mB.ToString();
        }


        private void btnColorear_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            String aux = "";
            for (int i = 0; i < bmp.Width - 10; i += 10)
                for (int j = 0; j < bmp.Height - 10; j += 10)
                {
                    meR = 0;
                    meG = 0;
                    meB = 0;

                    for (int i2 = i; i2 < i + 10; i2++)
                        for (int j2 = j; j2 < j + 10; j2++)
                        {
                            c = bmp.GetPixel(i2, j2);
                            meR = meR + c.R;
                            meG = meG + c.G;
                            meB = meB + c.B;
                        }
                    meR = meR / 100;
                    meG = meG / 100;
                    meB = meB / 100;
                    bool bandera = false;
                    for (int k = 0; k < dt.Rows.Count; k++)
                    {
                        RR = int.Parse(dt.Rows[k][1].ToString());
                        GG = int.Parse(dt.Rows[k][2].ToString());
                        BB = int.Parse(dt.Rows[k][3].ToString());
                        int RBD = int.Parse(dt.Rows[k][4].ToString());
                        int GBD = int.Parse(dt.Rows[k][5].ToString());
                        int BBD = int.Parse(dt.Rows[k][6].ToString());
                        if (((RR - 10) < meR) && (meR < (RR + 10)) &&
                        ((GG - 10) < meG) && (meG < (GG + 10)) &&
                        ((BB - 10) < meB) && (meB < (BB + 10)))
                        {
                            for (int i2 = i; i2 < i + 10; i2++)
                                for (int j2 = j; j2 < j + 10; j2++)
                                {
                                    bmp2.SetPixel(i2, j2, Color.FromArgb(RBD, GBD, BBD));
                                    bandera = true;
                                }
                            aux = "(" + RR + "," + GG + "," + BB + ") -> (" + RBD + "," + GBD + "," + BBD + ")";
                            int indice = Array.IndexOf(cad, aux);

                            if (indice >= 0)
                            {
                                aux = "";
                            }
                            else
                            {
                                cv++;
                                cad[cv] = aux;

                            }
                        }

                    }
                    if (!bandera)
                    {
                        for (int i2 = i; i2 < i + 10; i2++)
                            for (int j2 = j; j2 < j + 10; j2++)
                            {
                                c = bmp.GetPixel(i2, j2);
                                bmp2.SetPixel(i2, j2, c);

                            }
                    }
                }
            pictureBox1.Image = bmp2;
            if (cv != 0)
            {
                String cadaux = "";
                for (int i = 1; i <= cv; i++)
                {
                    cadaux = cadaux + "\n" + cad[i];
                }
                MessageBox.Show(cadaux, "COLORES MODIFICADOS");
            }
            else
            {
                MessageBox.Show("No se modifico ningun color", "ADVERTENCIA");
            }

        }




        public void Guardar(string nomb, int r1, int g1, int b1, int r2, int g2, int b2)
        {
            // validando el color 
            bool bandera = false;
            for (int k = 0; k < dt.Rows.Count; k++)
            {
                RR = int.Parse(dt.Rows[k][1].ToString());
                GG = int.Parse(dt.Rows[k][2].ToString());
                BB = int.Parse(dt.Rows[k][3].ToString());
                if (((RR - 10) < r1) && (r1 < (RR + 10)) &&
                ((GG - 10) < g1) && (g1 < (GG + 10)) &&
                ((BB - 10) < b1) && (b1 < (BB + 10)))
                {
                    bandera = true;
                }
            }
            if (!bandera)
            {
                try
                {

                    cmd = new MySqlCommand();
                    cmd.Connection = cnx;
                    cmd.CommandText = "INSERT INTO datos(Nombre,R1,G1,B1,R2,G2,B2 )  VALUES(@nomb,@r1,@g1,@b1,@r2,@g2,@b2 )";
                    cmd.Parameters.Add(new MySqlParameter("@nomb", nomb));
                    cmd.Parameters.Add(new MySqlParameter("@r1", r1));
                    cmd.Parameters.Add(new MySqlParameter("@g1", g1));
                    cmd.Parameters.Add(new MySqlParameter("@b1", b1));
                    cmd.Parameters.Add(new MySqlParameter("@r2", r2));
                    cmd.Parameters.Add(new MySqlParameter("@g2", g2));
                    cmd.Parameters.Add(new MySqlParameter("@b2", b2));
                    cnx.Open();
                    MySqlDataReader lector = cmd.ExecuteReader();
                    MessageBox.Show("El color se guardo correctamente", "MENSAJE");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                { cnx.Close(); }
            }
            else
            {
                MessageBox.Show("El color ya se encuentra registrado!!!", "MENSAJE");
            }

        }
        private void Listar()
        {
            dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "SELECT nombre, R1, G1,B1,R2,G2,B2 FROM datos ORDER BY Id DESC"; ;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }










    }
}
