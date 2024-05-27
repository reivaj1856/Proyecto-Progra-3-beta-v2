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
        public Banco GetBanco()
        {
            return bancoU;
        }
    }
}
