using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace Proyecto_Progra_3_beta_v2
{
    public partial class App : Form
    {
        private Banco banco1, banco2, banco3, bancoU;
        private Usuario usario;
        public App(Banco b1, Banco b2, Banco b3, Banco banU)
        {
            banco1 = b1;
            banco2 = b2;
            banco3 = b3;
            bancoU = banU;
            InitializeComponent();
            label13.Text = bancoU.GetNombre();
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            comboBox1.SelectedIndex = 0;
        }
        public void Inicio()
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }
        public Banco GetBanco()
        {
            return bancoU;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel3.Visible = true;
        }
        public void Transferir(Banco beneficiado)
        {
            if (textBox3.Text != "" && textBox4.Text != "")
            {
                int id1 = int.Parse(textBox3.Text);
                int precio = int.Parse(textBox4.Text);
                if (beneficiado.Buscar(id1) != null)
                {
                    Usuario us1 = beneficiado.Buscar(id1);
                    if (bancoU.GetNombre() != beneficiado.GetNombre() || id1 != usario.getId())
                    {
                        if (bancoU.Transaccion(usario.getId(), precio))
                        {
                            beneficiado.Depositar(id1, precio);
                            MessageBox.Show("transaccion realizada con exito");
                            Inicio();
                        }
                        else
                        {
                            MessageBox.Show("saldo insuficiente");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No puede enivar dinero a usted mismo");
                    }
                }
                else
                {
                    MessageBox.Show("usuario no encontrado");
                }
            }
            else
            {
                MessageBox.Show("llene los espacios");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                Transferir(banco1);
            }
            if (comboBox1.SelectedIndex == 1)
            {
                Transferir(banco2);
            }
            if (comboBox1.SelectedIndex == 2)
            {
                Transferir(banco3);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Inicio();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Inicio();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Inicio();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Deposito();
        }
        private void Deposito()
        {
            if (textBox6.Text != "")
            {
                int deposito = int.Parse(textBox6.Text);
                bancoU.Depositar(usario.getId(), deposito);
                MessageBox.Show("Se agrego " + deposito + " a su cuenta");
                Inicio();
            }
            else
            {
                MessageBox.Show("llene los espacios");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Retiro();
        }
        private void Retiro()
        {
            if (textBox5.Text != "")
            {
                double monto = double.Parse(textBox5.Text);
                if (bancoU.Retiro(usario.getId(), monto))
                {
                    MessageBox.Show("se retiran " + monto + " Bs");
                    Inicio();
                }
                else
                {
                    MessageBox.Show("saldo insuficiente");
                }
            }
            else
            {
                MessageBox.Show("llene los espacios");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel1.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel5.Visible = true;
            label8.Text = usario.Nombre + " - " + usario.Apellido + " - " + usario.getId();
            label10.Text = usario.Saldo + "";
            listBox1.Items.Clear();
            foreach (string linea in usario.Lista())
            {
                listBox1.Items.Add(linea);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel6.Visible = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Inicio();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button14_Click(object sender, EventArgs e)
        {
            InicioDeSesion();
        }
        private void InicioDeSesion()
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                int id = int.Parse(textBox1.Text);
                if (bancoU.Buscar(id) != null)
                {
                    usario = bancoU.Buscar(id);
                    string comparar = usario.Contraseña;
                    if (comparar == textBox2.Text)
                    {
                        panel2.Visible = false;
                        panel1.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("contraseña incorrecta");
                    }
                }
                else
                {
                    MessageBox.Show("Usuario no encontrado");
                }
            }
            else
            {
                MessageBox.Show("llene los espacios");
            }
        }



    }
}
