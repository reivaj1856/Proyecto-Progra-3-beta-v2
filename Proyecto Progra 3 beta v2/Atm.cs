using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proyecto_Progra_3_beta_v2
{
    public partial class Atm : Form
    {
        private Banco banco1, banco2, banco3, bancoU;
        private Usuario usario;
        private bool verificado;
        private int posTexbox;
        public Atm(Banco b1, Banco b2, Banco b3, Banco banU, Image img, Color c1, Color c2)
        {
            InitializeComponent();
            verificado = false;
            banco1 = b1;
            banco2 = b2;
            banco3 = b3;
            bancoU = banU;
            comboBox1.SelectedIndex = 0;
            pictureBox8.Image= img;
            pictureBox1.BackColor = c2;
            BackColor = c1;
            label11.BackColor = c2;
            inicioSesion.BackColor = Color.White;
            menu.BackColor = Color.White;
            transBan.BackColor = Color.White;
            depositobancario.BackColor = Color.White;
            retiBan.BackColor = Color.White;
            posTexbox = 0;
        }
        public void Inicio()
        {
            inicioSesion.Visible = false;
            menu.Visible = true;
            transBan.Visible = false;
            depositobancario.Visible = false;
            retiBan.Visible = false;            
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox1.Text != "")
            {
                inicioSesion.Visible = true;
            }
            if (e.KeyChar < 47 || e.KeyChar > 58)
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten numeros");
                return;
            }            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (verificado)
            {
                posTexbox++;
            }
            else {
                posTexbox++;
                InicioDeSesion();
            }
        }

        private void transferencia_Click(object sender, EventArgs e)
        {
            menu.Visible = false;
            transBan.Visible = true;
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

        private void envio_Click(object sender, EventArgs e)
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

        private void button18_Click(object sender, EventArgs e)
        {
            Inicio();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Inicio();
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            Retiro();
        }
        private void Deposito()
        {
            if (textBox5.Text != "")
            {
                int deposito = int.Parse(textBox5.Text);
                bancoU.Depositar(usario.getId(), deposito);
                MessageBox.Show("Se agrego " + deposito + " a su cuenta");
                Inicio();
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Inicio();
        }

        private void aceptaa_Click(object sender, EventArgs e)
        {
            Deposito();
        }
        private void Retiro()
        {
            if (textBox6.Text != "")
            {
                double monto = double.Parse(textBox6.Text);
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

        private void deposito_Click(object sender, EventArgs e)
        {
            menu.Visible= false;
            depositobancario.Visible= true;
            posTexbox = 4;
        }

        private void retiro_Click(object sender, EventArgs e)
        {
            menu.Visible = false;
            retiBan.Visible= true;
            posTexbox = 5;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Rellenar("1");         
        }
        private void Rellenar(string letra) {
            switch (posTexbox) {
                case 0:
                    inicioSesion.Visible= true;
                    textBox1.Text = textBox1.Text + letra;
                    break;
                case 1:
                    textBox2.Text = textBox2.Text + letra;
                    break;
                case 2:
                    textBox3.Text = textBox3.Text + letra;
                    break;
                case 3:
                    textBox4.Text = textBox4.Text + letra;
                    break;
                case 4:
                    textBox5.Text = textBox5.Text + letra;
                    break;
                case 5:
                    textBox6.Text = textBox6.Text + letra;
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Rellenar("2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Rellenar("3");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Rellenar("4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Rellenar("5");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Rellenar("6");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Rellenar("7");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Rellenar("8");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Rellenar("9");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Rellenar("0");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            posTexbox--;
        }

        public void InicioDeSesion()
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
                        inicioSesion.Visible = false;
                        menu.Visible = true;
                        posTexbox = 2;
                        verificado = true;
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
            
        }
        private void Atm_Load(object sender, EventArgs e)
        {

        }
        public Banco GetBanco()
        {
            return bancoU;
        }
    }
}