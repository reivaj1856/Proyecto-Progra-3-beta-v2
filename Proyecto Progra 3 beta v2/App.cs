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
            panel2.Visible = true;// se vera la ventana de inicio sesion
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            comboBox1.SelectedIndex = 0;//seleciona combobox banco ganadero determinado
        }
        public void Inicio()//envia a menu
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
            panel1.Visible = false;//ventana menu
            panel3.Visible = true;//ventana de transferencia
        }
        #region funcion de transferir
        public void Transferir(Banco beneficiado)
        {
            if (textBox3.Text != "" && textBox4.Text != "")// si esta lleno espacios de id y dinero que quieres enviar
            {
                int id1 = int.Parse(textBox3.Text);
                int precio = int.Parse(textBox4.Text);
                if (beneficiado.Buscar(id1) != null)//busca si el usuario beneficiado existe
                {
                    Usuario us1 = beneficiado.Buscar(id1);//carga el usuario beneficiado
                    if (bancoU.GetNombre() != beneficiado.GetNombre() || id1 != usario.getId())
                    {//verifica que no te envies a ti mismo 
                        if (bancoU.Transaccion(usario.getId(), precio))//verifica que tengas saldo para enviar
                        {
                            beneficiado.Depositar(id1, precio);//deposita en el usuario beneficiado
                            MessageBox.Show("transaccion realizada con exito");
                            Inicio();//manda a la ventana de menu
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

        private void button5_Click(object sender, EventArgs e)//boton de transferir aceptar
        {
            if (comboBox1.SelectedIndex == 0)
            {
                Transferir(banco1);//cuenta del beneficiado del banco ganadero
            }
            if (comboBox1.SelectedIndex == 1)
            {
                Transferir(banco2);//cuenta del beneficiado del banco union
            }
            if (comboBox1.SelectedIndex == 2)
            {
                Transferir(banco3);//cuenta del beneficiado del banco mercantil
            }
        }
        #endregion
        #region botones de menu
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
        private void button11_Click(object sender, EventArgs e)
        {
            Inicio();
        }
        #endregion
        #region funcion de depositar
        private void button8_Click(object sender, EventArgs e)//boton de deposito aceptar
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
        #endregion
        #region funcion de retiro
        private void button6_Click(object sender, EventArgs e)
        {
            Retiro();
        }
        private void Retiro()
        {
            if (textBox5.Text != "")
            {
                double monto = double.Parse(textBox5.Text);
                if (bancoU.Retiro(usario.getId(), monto))//verifica q tengas saldo suficiente
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
        #endregion
        private void button3_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;//ventana  de retirar dinero
            panel1.Visible = false;//ventana de menu
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;//ventana de menu
            panel5.Visible = true;//ventana de mostrar saldo
            label8.Text = usario.Nombre + " - " + usario.Apellido + " - " + usario.getId();//muestra datos de la cuenta
            label10.Text = usario.Saldo + "";//muestra saldo
            listBox1.Items.Clear();//vacia el lisbox de historial
            foreach (string linea in usario.Lista())
            {
                listBox1.Items.Add(linea);//cargar el historial del usuario con datos actualizados
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;//ventana menu
            panel6.Visible = true;// ventana de deposito
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Close();//boton de cerrar ventana App
        }
        private void button14_Click(object sender, EventArgs e)
        {
            InicioDeSesion();//boton de login
        }
        private void InicioDeSesion()
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                int id = int.Parse(textBox1.Text);
                if (bancoU.Buscar(id) != null)//busca si el usuario existe
                {
                    usario = bancoU.Buscar(id);
                    string comparar = usario.Contraseña;//recibe contraseña del usuario que desea acceder
                    if (comparar == textBox2.Text)//compara si la contraseña coincide
                    {
                        panel2.Visible = false;//ventana de inicio de sesion
                        panel1.Visible = true;//ventana menu
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
