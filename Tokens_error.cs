using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practicav1._2
{
    class Tokens_error
    {
        private int contador;
        private int fila;
        private int columna;
        private string caracter;
        private string descripcion;

        public Tokens_error()
        {
            this.Contador = 0;
            this.Fila = 0;
            this.Columna = 0;
            this.Caracter = "";
            this.Descripcion = "";
        }

        public Tokens_error(int contador, int fila, int columna, string caracter, string descripcion)
        {
            this.Contador = contador;
            this.Fila = fila;
            this.Columna = columna;
            this.Caracter = caracter;
            this.Descripcion = descripcion;
        }

        public int Contador { get => contador; set => contador = value; }
        public int Fila { get => fila; set => fila = value; }
        public int Columna { get => columna; set => columna = value; }
        public string Caracter { get => caracter; set => caracter = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
    
}
