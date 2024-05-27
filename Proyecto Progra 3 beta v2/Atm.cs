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
            #region variablesInicio
            verificado = false;
            banco1 = b1;//sirve de memoria para enviar transferencia a otro banco
            banco2 = b2;//sirve de memoria para enviar transferencia a otro banco
            banco3 = b3;//sirve de memoria para enviar transferencia a otro banco
            bancoU = banU; //define el banco del usuario
            comboBox1.SelectedIndex = 0;//define transferencia Banco comboBox (ganadero)
            pictureBox8.Image= img;//define la imagen del banco
            posTexbox = 0;//define que texbox va a llenar el tacladoNumerico
            #endregion
            #region definirColor
            pictureBox1.BackColor = c2;
            BackColor = c1;
            label11.BackColor = c2;
            inicioSesion.BackColor = Color.White;
            menu.BackColor = Color.White;
            transBan.BackColor = Color.White;
            depositobancario.BackColor = Color.White;
            retiBan.BackColor = Color.White;
            #endregion
            
        }
        public void Inicio() //volver al menu 
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
        #region LimitarSoloNumeros
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < 47 || e.KeyChar > 58)
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten numeros");
                return;
            }            
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < 47 || e.KeyChar > 58)
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten numeros");
                return;
            }
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < 47 || e.KeyChar > 58)
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten numeros");
                return;
            }
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < 47 || e.KeyChar > 58)
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten numeros");
                return;
            }
        }
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < 47 || e.KeyChar > 58)
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten numeros");
                return;
            }
        }
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < 47 || e.KeyChar > 58)
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten numeros");
                return;
            }
        }
        #endregion
        #region botonEnter inicio sesion
        private void button13_Click(object sender, EventArgs e)
        {
            Close();//boton de cerra ventana
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (!verificado) {
                InicioDeSesion();//boton enter solo iniciaSecion
            }
        }
        public void InicioDeSesion()
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
                        inicioSesion.Visible = false;//ventana de inicio de sesion
                        menu.Visible = true;//ventana menu
                        verificado = true;//sesion iniciada
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
        #endregion

        #region botonesMenu
        private void transferencia_Click(object sender, EventArgs e)
        {
            menu.Visible = false;
            transBan.Visible = true;
        }
        private void deposito_Click(object sender, EventArgs e)
        {
            menu.Visible = false;
            depositobancario.Visible = true;
        }
        private void retiro_Click(object sender, EventArgs e)
        {
            menu.Visible = false;
            retiBan.Visible = true;
        }
        #endregion
        #region botones de menu
        private void button18_Click(object sender, EventArgs e)
        {
            Inicio();
        }
        private void button22_Click(object sender, EventArgs e)
        {
            Inicio();
        }
        private void button20_Click(object sender, EventArgs e)
        {
            Inicio();
        }
        #endregion
        #region ventanaTransferir
        private void envio_Click(object sender, EventArgs e)
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
        public void Transferir(Banco beneficiado)
        {
            if (textBox3.Text != "" && textBox4.Text != "")//pregunta si se llenaron los espacios
            {
                int id1 = int.Parse(textBox3.Text);
                int precio = int.Parse(textBox4.Text);
                if (beneficiado.Buscar(id1) != null)//busca si existe el id en el banco seleccionado
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
        #endregion
        #region ventanaDeposito
        private void aceptaa_Click(object sender, EventArgs e)
        {
            Deposito();
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
        #endregion
        #region ventanaRetiro
        private void aceptar_Click(object sender, EventArgs e)
        {
            Retiro();
        }
        private void Retiro()
        {
            if (textBox6.Text != "")
            {
                double monto = double.Parse(textBox6.Text);
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
        #region tecladoNumerico
        private void button1_Click(object sender, EventArgs e)
        {
            Rellenar("1");         
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
            Rellenar("-1");
        }
        private void Rellenar(string letra)
        {
            switch (posTexbox) //postexbox dice que texbox va a llenar el teclado numerico
            {
                case 0:
                    if (letra.Equals("-1"))
                    {
                        if (textBox1.Text.Length > 0) //verifica que el cuadro no este vacio
                        {
                            textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
                        }
                    }
                    else
                    {
                        inicioSesion.Visible = true;
                        textBox1.Text = textBox1.Text + letra;//se aumenta el numero del teclado
                    }
                    break;
                case 1:
                    if (letra.Equals("-1"))
                    {
                        if (textBox2.Text.Length > 0)
                        {
                            textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1, 1);
                        }
                    }
                    else
                    {
                        textBox2.Text = textBox2.Text + letra;
                    }
                    break;
                case 2:
                    if (letra.Equals("-1"))
                    {
                        if (textBox3.Text.Length > 0)
                        {
                            textBox3.Text = textBox3.Text.Remove(textBox3.Text.Length - 1, 1);
                        }
                    }
                    else
                    {
                        textBox3.Text = textBox3.Text + letra;
                    }
                    break;
                case 3:
                    if (letra.Equals("-1"))
                    {
                        if (textBox4.Text.Length > 0)
                        {
                            textBox4.Text = textBox4.Text.Remove(textBox4.Text.Length - 1, 1);
                        }
                    }
                    else
                    {
                        textBox4.Text = textBox4.Text + letra;
                    }
                    break;
                case 4:
                    if (letra.Equals("-1"))
                    {
                        if (textBox5.Text.Length > 0)
                        {
                            textBox5.Text = textBox5.Text.Remove(textBox5.Text.Length - 1, 1);
                        }
                    }
                    else
                    {
                        textBox5.Text = textBox5.Text + letra;
                    }
                    break;
                case 5:
                    if (letra.Equals("-1"))
                    {
                        if (textBox6.Text.Length > 0)
                        {
                            textBox6.Text = textBox6.Text.Remove(textBox6.Text.Length - 1, 1);
                        }
                    }
                    else
                    {
                        textBox6.Text = textBox6.Text + letra;
                    }
                    break;

            }
        }
        #endregion
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")//se escribe una letra en tarjeta de credito
            {
                inicioSesion.Visible = true;//enciende la ventana inicio de sesion
            }
        }
        #region verificaTexboxSeleccionado
        private void textBox6_MouseDown(object sender, MouseEventArgs e)
        {
            posTexbox = 5;
        }

        private void textBox5_MouseDown(object sender, MouseEventArgs e)
        {
            posTexbox = 4;
        }

        private void textBox4_MouseDown(object sender, MouseEventArgs e)
        {
            posTexbox = 3;
        }

        private void textBox3_MouseDown(object sender, MouseEventArgs e)
        {
            posTexbox = 2;
        }

        private void textBox2_MouseDown(object sender, MouseEventArgs e)
        {
            posTexbox = 1;
        }
        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            posTexbox = 0;
        }
        #endregion

        
        private void Atm_Load(object sender, EventArgs e)
        {

        }
        public Banco GetBanco()
        {
            return bancoU;
        }
    }
}