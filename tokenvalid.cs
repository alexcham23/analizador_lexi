using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practicav1._2
{
    class tokenvalid
    {
        public Nodo primero = new Nodo();
        public Nodo ultimo = new Nodo();
        //Form1 enviar = new Form1();
        Nodo actual = new Nodo();
        int contar = 1;
        public tokenvalid()
        {
            primero = null;
            ultimo = null;

        }

        public void insertar(string lexema, string id, string token)
        {
            
            Nodo actual = new Nodo();
            actual.setcontador(contar);
            actual.setLexema(lexema);
            actual.setId(id);
            actual.setToken(token);
            if (primero == null)
            {
                primero = actual;
                primero.siguiente = null;
                ultimo = primero;
                contar++;
            }
            else
            {
                ultimo.siguiente = actual;
                actual.siguiente = null;
                ultimo = actual;
                contar++;
            }
            
            Console.WriteLine("Tokenvalid almacenado");
            //imprimir();
            }
        public  void imprimir()
        {
            //enviar.text2.Text = "";
           
           // Nodo actual1 = new Nodo();
            
            
            actual = primero;
            
            if (primero!= null)
            {

                do
                {

                    Console.WriteLine(""+actual.getLexema()+","+actual.getId()+", "+actual.getContador()+", "+actual.getToken());
                   //  enviar.label1.Text = actual1.Lexema;
                    actual = actual.siguiente;
                   
                } while (actual != null);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No hay archivos Guardados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
