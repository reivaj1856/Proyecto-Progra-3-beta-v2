using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proyecto_Progra_3_beta_v2
{
    public class Usuario
    {
        private int id;
        private string nombre;
        private string apellido;
        private double saldo;
        private string contraseña;
        private ArrayList historial;
        public Usuario(int id, string nombre, string apellido, string contraseña)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            saldo = 0;
            this.contraseña = contraseña;
            historial = new ArrayList();
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        public double Saldo
        {
            get { return saldo; }
            set { saldo = value; }
        }
        public void Depositar(double sumar)
        {
            saldo = saldo + sumar;
            DateTime dtToday = DateTime.Now;
            Console.WriteLine(dtToday);
            Lista("" + dtToday);
            Lista("Se hizo un deposito de " + sumar);
            Lista("total saldo en la cuenta " + saldo);
            Lista("");
        }
        public bool transferir(double restar)
        {
            if (saldo >= restar)
            {
                saldo = saldo - restar;
                DateTime dtToday = DateTime.Now;
                Console.WriteLine(dtToday);
                Lista("" + dtToday);
                Lista("Se hizo una transferencia de " + restar);
                Lista("total saldo en la cuenta " + saldo);
                Lista("");
                return true;
            }
            else
            {
                return false;
            }
        }
        public int getId()
        {
            return this.id;
        }
        public string Contraseña
        {
            get { return this.contraseña; }
            set { this.contraseña = value; }
        }
        public void Lista(string linea)
        {
            historial.Add(linea);
        }
        public ArrayList Lista()
        {
            return historial;
        }
        public bool Retiro(double cantidad)
        {
            if (saldo >= cantidad)
            {
                saldo = saldo - cantidad;
                DateTime dtToday = DateTime.Now;
                Console.WriteLine(dtToday);
                Lista("" + dtToday);
                Lista("Se hizo un retiro de " + cantidad);
                Lista("total saldo en la cuenta " + saldo);
                Lista("");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
