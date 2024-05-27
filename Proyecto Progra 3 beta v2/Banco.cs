using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Progra_3_beta_v2
{
    public class Banco
    {
        private Usuario[] usuarios;
        private ArrayList historial;
        private double total;
        private string nombre;
        public Banco(int tamaño, string nombre)
        {
            usuarios = new Usuario[tamaño];
            historial = new ArrayList();
            total = 0;
            this.nombre = nombre;
        }
        public void Depositar(int id2, double cantidad)
        {
            Usuario us2 = Buscar(id2);
            us2.Depositar(cantidad);
            total = total + cantidad;
            Lista("Se hizo un deposito a la cuenta :" + id2);
            Lista("se deposito la cantidad de " + cantidad);
            Lista("total actual de la cuenta :" + us2.Saldo);
            Lista("");
        }
        public bool Transaccion(int id1, double cantidad)
        {
            Usuario us1 = Buscar(id1);
            if (us1.transferir(cantidad))
            {
                total = total - cantidad;
                Lista("Se hizo una transaccion de la cuenta :" + id1);
                Lista("se envio una cantidad de :" + cantidad);
                Lista("total actual de la cuenta :" + us1.Saldo);
                Lista("");
                return true;
            }
            else
            {
                return false;
            }
        }
        public Usuario Buscar(int id)
        {
            int i = 0;
            Usuario usuario = null;
            bool encontrado = false;
            while (i < usuarios.Length && !encontrado)
            {
                if (usuarios[i] != null && usuarios[i].getId() == id)
                {
                    usuario = usuarios[i];
                    encontrado = true;
                }
                i++;
            }
            return usuario;
        }
        public bool AgregarUsuario(Usuario nuevo)
        {
            bool res = false;
            for (int i = 0; i < usuarios.Length; i++)
            {
                if (usuarios[i] == null)
                {
                    if (!Repetido(nuevo.getId()))
                    {
                        usuarios[i] = nuevo;
                        total = total + usuarios[i].Saldo;
                    }
                }
            }
            return res;
        }
        public string GetNombre()
        {
            return nombre;
        }
        public Usuario[] GetUsuarios()
        {
            return usuarios;
        }
        public bool Repetido(int id)
        {
            int i = 0;
            bool encontrado = false;
            while (i < usuarios.Length && !encontrado)
            {
                if (usuarios[i] != null && usuarios[i].getId() == id)
                {
                    encontrado = true;
                }
                i++;
            }
            return encontrado;
        }
        public double getTotal
        {
            get { return total; }
            set { total = value; }
        }
        public void Lista(string linea)
        {
            historial.Add(linea);
        }
        public ArrayList Lista()
        {
            return historial;
        }
        public bool Retiro(int id1, double cantidad)
        {
            Usuario us1 = Buscar(id1);
            if (us1.Retiro(cantidad))
            {
                total = total - cantidad;
                Lista("Se hizo un retiro de la cuenta :" + id1);
                Lista("se retiro una cantidad de :" + cantidad);
                Lista("total actual de la cuenta :" + us1.Saldo);
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
