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

namespace Proyecto_Progra_3_beta_v2
{
    public unsafe partial class Form1 : Form
    {
        private Banco mercantil;
        private Banco union;
        private Banco ganadero;
        private App aplicacion;
        private Atm cajero;
        public Form1()
        {
            InitializeComponent();
            banco.Visible = false;
            mercantil = new Banco(20, "Banco Mercantil");
            union = new Banco(20, "Banco Union");
            ganadero = new Banco(20, "Banco Ganadero");
            Llenar();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void Rellenar(Banco banco)//rellena la ventana con el banco selecionado
        {
            label3.Text = banco.GetNombre();
            label6.Text = banco.getTotal + " Bs";
            Actualizar(banco);
        }
        public void Actualizar(Banco banco)//actualiza el grid, nombre, total y historial de la ventana banco
        {
            dataGridView1.Rows.Clear();//vacia el datagrid
            for (int i = 0; i < banco.GetUsuarios().Length; i++)
            {
                int n = dataGridView1.Rows.Add();//da la posicion del grid para guardar
                if (banco.GetUsuarios()[i] != null)
                {
                    dataGridView1.Rows[n].Cells[0].Value = banco.GetUsuarios()[i].getId();
                    dataGridView1.Rows[n].Cells[1].Value = banco.GetUsuarios()[i].Nombre;
                    dataGridView1.Rows[n].Cells[2].Value = banco.GetUsuarios()[i].Apellido;
                    dataGridView1.Rows[n].Cells[3].Value = banco.GetUsuarios()[i].Saldo;
                }
            }
            label6.Text = banco.getTotal + " Bs";//carga el dinero total del banco
            listBox1.Items.Clear();//basia el historial
            foreach (string linea in banco.Lista())
            {
                listBox1.Items.Add(linea);//llena el historial con datos actualizados
            }
        }
        public void Llenar()
        {
            Usuario us1 = new Usuario(1001, "javier", "cruz", "12345678");
            Usuario us2 = new Usuario(1002, "maria", "lopez", "contraseña2");
            Usuario us3 = new Usuario(1003, "luis", "garcia", "contraseña3");
            Usuario us4 = new Usuario(1004, "ana", "martinez", "contraseña4");
            Usuario us5 = new Usuario(1005, "carlos", "fernandez", "contraseña5");
            Usuario us6 = new Usuario(1006, "elena", "gomez", "contraseña6");
            Usuario us7 = new Usuario(1007, "jorge", "diaz", "contraseña7");
            Usuario us8 = new Usuario(1008, "laura", "sanchez", "contraseña8");
            Usuario us9 = new Usuario(1009, "pablo", "rodriguez", "contraseña9");
            Usuario us10 = new Usuario(1010, "lucia", "perez", "contraseña10");
            Usuario us11 = new Usuario(1011, "andres", "romero", "contraseña11");
            Usuario us12 = new Usuario(1012, "paula", "torres", "contraseña12");
            Usuario us13 = new Usuario(1013, "ricardo", "ramirez", "contraseña13");
            Usuario us14 = new Usuario(1014, "sara", "flores", "contraseña14");
            Usuario us15 = new Usuario(1015, "alejandro", "vazquez", "contraseña15");
            Usuario us16 = new Usuario(1016, "marta", "muñoz", "contraseña16");
            Usuario us17 = new Usuario(1017, "victor", "alvarez", "contraseña17");
            Usuario us18 = new Usuario(1018, "rosa", "moreno", "contraseña18");
            Usuario us19 = new Usuario(1019, "fernando", "soto", "contraseña19");
            Usuario us20 = new Usuario(1020, "alicia", "ibañez", "contraseña20");

            us1.Depositar(1500);
            us2.Depositar(2000);
            us3.Depositar(3000);
            us4.Depositar(4500);
            us5.Depositar(1500);
            us6.Depositar(3000);
            us7.Depositar(1500);
            us8.Depositar(4500);
            us9.Depositar(1500);
            us10.Depositar(1500);
            us11.Depositar(1500);
            us12.Depositar(1000);
            us13.Depositar(3000);
            us14.Depositar(4500);
            us15.Depositar(1500);
            us16.Depositar(2000);
            us17.Depositar(4500);
            us18.Depositar(2000);
            us19.Depositar(1500);
            us20.Depositar(3000);


            mercantil.AgregarUsuario(us1);
            mercantil.AgregarUsuario(us2);
            mercantil.AgregarUsuario(us3);
            mercantil.AgregarUsuario(us4);
            mercantil.AgregarUsuario(us5);
            mercantil.AgregarUsuario(us6);
            mercantil.AgregarUsuario(us7);
            mercantil.AgregarUsuario(us8);
            mercantil.AgregarUsuario(us9);
            mercantil.AgregarUsuario(us10);
            mercantil.AgregarUsuario(us11);
            mercantil.AgregarUsuario(us12);
            mercantil.AgregarUsuario(us13);
            mercantil.AgregarUsuario(us14);
            mercantil.AgregarUsuario(us15);
            mercantil.AgregarUsuario(us16);
            mercantil.AgregarUsuario(us17);
            mercantil.AgregarUsuario(us18);
            mercantil.AgregarUsuario(us19);
            mercantil.AgregarUsuario(us20);
            Usuario us01 = new Usuario(1001, "javier", "cruz", "contraseña1");
            Usuario us02 = new Usuario(1002, "maria", "lopez", "contraseña2");
            Usuario us03 = new Usuario(1003, "luis", "garcia", "contraseña3");
            Usuario us04 = new Usuario(1004, "ana", "martinez", "contraseña4");
            Usuario us05 = new Usuario(1005, "carlos", "fernandez", "contraseña5");
            Usuario us06 = new Usuario(1006, "elena", "gomez", "contraseña6");
            Usuario us07 = new Usuario(1007, "jorge", "diaz", "contraseña7");
            Usuario us08 = new Usuario(1008, "laura", "sanchez", "contraseña8");
            Usuario us09 = new Usuario(1009, "pablo", "rodriguez", "contraseña9");
            Usuario us010 = new Usuario(1010, "lucia", "perez", "contraseña10");
            Usuario us011 = new Usuario(1011, "andres", "romero", "contraseña11");
            Usuario us012 = new Usuario(1012, "paula", "torres", "contraseña12");
            Usuario us013 = new Usuario(1013, "ricardo", "ramirez", "contraseña13");
            Usuario us014 = new Usuario(1014, "sara", "flores", "contraseña14");
            Usuario us015 = new Usuario(1015, "alejandro", "vazquez", "contraseña15");
            Usuario us016 = new Usuario(1016, "marta", "muñoz", "contraseña16");
            Usuario us017 = new Usuario(1017, "victor", "alvarez", "contraseña17");
            Usuario us018 = new Usuario(1018, "rosa", "moreno", "contraseña18");
            Usuario us019 = new Usuario(1019, "fernando", "soto", "contraseña19");
            Usuario us020 = new Usuario(1020, "alicia", "ibañez", "contraseña20");

            us01.Depositar(1500);
            us02.Depositar(2000);
            us03.Depositar(3000);
            us04.Depositar(4500);
            us05.Depositar(1500);
            us06.Depositar(3000);
            us07.Depositar(1500);
            us08.Depositar(4500);
            us09.Depositar(1500);
            us010.Depositar(1500);
            us011.Depositar(1500);
            us012.Depositar(1000);
            us013.Depositar(3000);
            us014.Depositar(4500);
            us015.Depositar(1500);
            us016.Depositar(2000);
            us017.Depositar(4500);
            us018.Depositar(2000);
            us019.Depositar(1500);
            us020.Depositar(3000);

            union.AgregarUsuario(us01);
            union.AgregarUsuario(us02);
            union.AgregarUsuario(us03);
            union.AgregarUsuario(us04);
            union.AgregarUsuario(us05);
            union.AgregarUsuario(us06);
            union.AgregarUsuario(us07);
            union.AgregarUsuario(us08);
            union.AgregarUsuario(us09);
            union.AgregarUsuario(us010);
            union.AgregarUsuario(us011);
            union.AgregarUsuario(us012);
            union.AgregarUsuario(us013);
            union.AgregarUsuario(us014);
            union.AgregarUsuario(us015);
            union.AgregarUsuario(us016);
            union.AgregarUsuario(us017);
            union.AgregarUsuario(us018);
            union.AgregarUsuario(us019);
            union.AgregarUsuario(us020);

            Usuario us30 = new Usuario(1001, "javier", "cruz", "contraseña1");
            Usuario us31 = new Usuario(1002, "maria", "lopez", "contraseña2");
            Usuario us32 = new Usuario(1003, "luis", "garcia", "contraseña3");
            Usuario us40 = new Usuario(1004, "ana", "martinez", "contraseña4");
            Usuario us50 = new Usuario(1005, "carlos", "fernandez", "contraseña5");
            Usuario us60 = new Usuario(1006, "elena", "gomez", "contraseña6");
            Usuario us70 = new Usuario(1007, "jorge", "diaz", "contraseña7");
            Usuario us80 = new Usuario(1008, "laura", "sanchez", "contraseña8");
            Usuario us90 = new Usuario(1009, "pablo", "rodriguez", "contraseña9");
            Usuario us100 = new Usuario(1010, "lucia", "perez", "contraseña10");
            Usuario us110 = new Usuario(1011, "andres", "romero", "contraseña11");
            Usuario us120 = new Usuario(1012, "paula", "torres", "contraseña12");
            Usuario us130 = new Usuario(1013, "ricardo", "ramirez", "contraseña13");
            Usuario us140 = new Usuario(1014, "sara", "flores", "contraseña14");
            Usuario us150 = new Usuario(1015, "alejandro", "vazquez", "contraseña15");
            Usuario us160 = new Usuario(1016, "marta", "muñoz", "contraseña16");
            Usuario us170 = new Usuario(1017, "victor", "alvarez", "contraseña17");
            Usuario us180 = new Usuario(1018, "rosa", "moreno", "contraseña18");
            Usuario us190 = new Usuario(1019, "fernando", "soto", "contraseña19");
            Usuario us200 = new Usuario(1020, "alicia", "ibañez", "contraseña20");

            us30.Depositar(1500);
            us31.Depositar(2000);
            us32.Depositar(3000);
            us40.Depositar(4500);
            us50.Depositar(1500);
            us60.Depositar(3000);
            us70.Depositar(1500);
            us80.Depositar(4500);
            us90.Depositar(1500);
            us100.Depositar(1500);
            us110.Depositar(1500);
            us120.Depositar(1000);
            us130.Depositar(3000);
            us140.Depositar(4500);
            us150.Depositar(1500);
            us160.Depositar(2000);
            us170.Depositar(4500);
            us180.Depositar(2000);
            us190.Depositar(1500);
            us200.Depositar(3000);

            ganadero.AgregarUsuario(us30);
            ganadero.AgregarUsuario(us31);
            ganadero.AgregarUsuario(us32);
            ganadero.AgregarUsuario(us40);
            ganadero.AgregarUsuario(us50);
            ganadero.AgregarUsuario(us60);
            ganadero.AgregarUsuario(us70);
            ganadero.AgregarUsuario(us80);
            ganadero.AgregarUsuario(us90);
            ganadero.AgregarUsuario(us100);
            ganadero.AgregarUsuario(us110);
            ganadero.AgregarUsuario(us120);
            ganadero.AgregarUsuario(us130);
            ganadero.AgregarUsuario(us140);
            ganadero.AgregarUsuario(us150);
            ganadero.AgregarUsuario(us160);
            ganadero.AgregarUsuario(us170);
            ganadero.AgregarUsuario(us180);
            ganadero.AgregarUsuario(us190);
            ganadero.AgregarUsuario(us200);
        }//crea los usuarios y los agregar a los bancos

        private void button4_Click_1(object sender, EventArgs e)//boton de cerrar ventana
        {
            Close();
        }

        private void button1_Click_1(object sender, EventArgs e)//boton banco ganadero
        {
            this.banco.Visible = true;
            #region color de la ventana
            this.banco.BackColor = Color.FromArgb(32, 177, 68);//color de la ventana
            //color del datagrid
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.FromArgb(39, 219, 84);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(39, 219, 84);
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(39, 219, 84);
            #endregion
            Banco banco = ganadero;
            Rellenar(banco);//rellena color nombre datos del banco ganadero
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.banco.Visible = true;
            #region color de la ventana
            this.banco.BackColor = Color.FromArgb(91, 199, 216);//color de la ventana
            //color del datagrid
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.FromArgb(29, 167, 182);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(29, 167, 182);
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(29, 167, 182);
            #endregion
            Banco banco = union;
            Rellenar(banco);//rellena color nombre datos del banco union
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.banco.Visible = true;
            #region color de la ventana
            this.banco.BackColor = Color.FromArgb(12, 117, 56);//color de la ventana
            //color del datagrid
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.FromArgb(23, 225, 106);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(23, 225, 106);
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(23, 225, 106);
            #endregion
            Banco banco = mercantil;
            Rellenar(banco);//rellena color nombre datos del banco mercantil
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            //boton tigo money
        }

        private void button6_Click_1(object sender, EventArgs e)//crear cajero automatico
        {
            if (label3.Text == "Banco Ganadero")
            {
                cajero = new Atm(ganadero, union, mercantil, ganadero, Proyecto_Progra_3_beta_v2.Properties.Resources.banco_ganadero, Color.FromArgb(32, 177, 68), Color.FromArgb(39, 219, 84));
            }
            if (label3.Text == "Banco Union")
            {
                cajero = new Atm(ganadero, union, mercantil, union, Proyecto_Progra_3_beta_v2.Properties.Resources.bancounion1_3175327580__2_, Color.FromArgb(91, 199, 216), Color.FromArgb(29, 167, 182));
            }
            if (label3.Text == "Banco Mercantil")
            {
                cajero = new Atm(ganadero, union, mercantil, mercantil, Proyecto_Progra_3_beta_v2.Properties.Resources.Banco_Mercantil_Logo__2_, Color.FromArgb(12, 117, 56), Color.FromArgb(23, 225, 106));
            }
            cajero.ShowDialog();
            //se cierra la ventana y actualiza los datos para el grid y historial
            Actualizar(cajero.GetBanco());
        }

        private void button7_Click_1(object sender, EventArgs e)//crea la ventana App
        {
            if (label3.Text == "Banco Ganadero")
            {
                aplicacion = new App(ganadero, union, mercantil, ganadero);
            }
            if (label3.Text == "Banco Union")
            {
                aplicacion = new App(ganadero, union, mercantil, union);
            }
            if (label3.Text == "Banco Mercantil")
            {
                aplicacion = new App(ganadero, union, mercantil, mercantil);
            }
            aplicacion.ShowDialog();
            //se cierra la ventana y actualiza los datos para el grid y historial
            Actualizar(aplicacion.GetBanco());
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            banco.Visible = false;//se hace no visible la ventana banco y muestro el inicio
            //el logo de UPDS y titulo
        }
    }

}
