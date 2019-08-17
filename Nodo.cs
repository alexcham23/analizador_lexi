using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practicav1._2
{
    class Nodo 
    {
        public int contador;
        public string lexema;
        public string id;
        public string token;
        public Nodo siguiente;

        public Nodo()
        {
            this.contador = 0;
            this.lexema = "";
            this.id = "";
            this.token = "";
            this.siguiente = null;
        }

        public Nodo(int contador, string lexema, string id, string token)
        {
            this.contador = contador;
            this.lexema = lexema;
            this.id = id;
            this.token = token;
        }

        public int getContador()
        {
            return contador;
        }

        public void setcontador(int contador)
        {
            this.contador =  contador;
        }

        public string getLexema()
        {
            return lexema;
        }

        public void setLexema(string lexema)
        {
            this.lexema = lexema;
        }

        public string getId()
        {
            return id;
        }

        public void setId(string id)
        {
            this.id = id;
        }

        public string getToken()
        {
            return token;
        }

        public void setToken(string token)
        {
            this.token = token;
        }

        public Nodo getSiguiente()
        {
            return siguiente;
        }

        public void setSiguiente(Nodo siguiente)
        {
            this.siguiente = siguiente;
        }

        

        /*
        public Nodo(int contador, string lexema, string id, string token)
        {
            this.contador = contador;
            this.lexema = lexema;
            this.id = id;
            this.token = token;
        }

        public int Contador
        {
            get { return contador; }
            set { contador = value; }
        }
        public string Lexema
        {
            get { return lexema; }
            set { lexema = value; }
        }
        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Token
        {
            get { return token; }
            set { token = value; }
        }
        public Nodo Siguiente
        {
            get { return siguiente; }
            set { siguiente = value; }
        }*/
    }
}
