using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practicav1._2
{

    public partial class Form1 : Form
    {
        static List<Nodo> Tokens=new List<Nodo>();
        static List<Tokens_error> error = new List<Tokens_error>();
        tokenvalid a = new tokenvalid();
        int contador = 1;
        int selected;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void NuevaPestañaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage windows = new TabPage()//permitira crear pestañas nuevas, el contador permitira saber el numero de pestañas creadas
            {
                Name = "pestaña" + contador++,
                Text = "Pestaña " + contador,
            };

            RichTextBox caja = new RichTextBox() //crearemos un caja de texto dentro tabpage con la ayuda del mismo contador sabremos el numero de caja de textos empleados
            {
                Name = "text1",
                Text = "",
                Dock = DockStyle.Fill,// aqui nos permite que la caja de texto tome el tamaño de tabpage.
                AcceptsTab = true,//aceptaremos el cambio de la caja de texto.

            };

            windows.Controls.Add(caja);//aderimos RichTextBox dentro del tabpage    
            tablero1.Controls.Add(windows);//aderimos tabpage a la ventana de forms.cs

        }

        private void CargarArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Document (*.ly) | *.ly";
            openFileDialog1.FileName = "";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.InitialDirectory = "Escritorio";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                selected = tablero1.SelectedIndex;
                if (selected == 0)
                {
                    text1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                    MessageBox.Show("Archivo Abierto", "Lenguajes Proyecto Fase 1", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if (selected == 1)
                {
                    text2.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                    MessageBox.Show("Archivo Abierto", "Lenguajes Proyecto Fase 1", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int selected1 = tablero1.SelectedIndex;
            if (selected1 == 0)
            {
                string cadena = text1.Text;
                automatanalizer(cadena);

            }
            else if (selected1 == 1)
            {
                string cadena = text2.Text;
                automatanalizer(cadena);
            }
        }
        public void addTokens(int contador, string lexema, string id, string token)
        {
            Nodo nuevo = new Nodo(contador, lexema, id, token);
            Tokens.Add(nuevo);
        }

        public void addError(int contador, int fila, int columna, string caracter, string descripcion)
        {
            Tokens_error Nuevo = new Tokens_error(contador, fila, columna, caracter, descripcion);
            error.Add(Nuevo);
        }
        private void Imprimir_Click(object sender, EventArgs e)
        {

            
            
            mostrar();
            mostrar2();
            
        }

        private void automatanalizer(string cadena)
        {
            tokenvalid actual = new tokenvalid();
            int inicial = 0;
            int estado = 0;
            char concatenada;
            string contenedor = "";
           string aux = "";
            string Aux2 = "";
            string aux3 = "";
            int contador = 0;
            int num=1;
            int errorcount=1;

            while (inicial < cadena.Length)
            {
                /*
                 Planificador:"ClanA"
	Descripcion:"no lo se para terminar";
	Imagen:"Path";
                 */

                concatenada = cadena[inicial];
                switch (estado)
                {
                    case 0:
                        if (concatenada.Equals(' ') || concatenada.Equals('\f') || concatenada.Equals('\t') || concatenada.Equals('\b') || concatenada.Equals('\n')
                            || concatenada.Equals('\r') || concatenada.Equals('P') || concatenada.Equals('p') || concatenada.Equals(':') || concatenada.Equals('"')
                            || concatenada.Equals('[') || concatenada.Equals('{') || concatenada.Equals('(') || concatenada.Equals('<') || concatenada.Equals(';')
                            || concatenada.Equals(']') || concatenada.Equals('}') || concatenada.Equals(')') || concatenada.Equals('>'))
                        {
                            switch (concatenada)
                            {
                                case ' ':
                                case '\f':
                                case '\t':
                                case '\b':
                                case '\r':
                                    estado = 0;
                                    break;
                                case '\n':
                                    contador++;
                                    break;

                                case 'P':
                                    contenedor += concatenada;
                                    Aux2 += concatenada;
                                    estado = 1;
                                    break;
                                case 'p':
                                    contenedor += concatenada;
                                    Aux2 += concatenada;
                                    estado = 1;
                                    break;
                                case ':':
                                    contenedor += concatenada;
                                    addTokens(num,contenedor, "13", "Dos Puntos");
                                    Aux2 += concatenada;
                                    estado = 0;
                                    //inicial = inicial - 1;
                                    break;
                                case '"':
                                    aux3 = "";
                                    contenedor += concatenada;
                                    aux3 += concatenada;
                                    actual.insertar(contenedor, "14", "Comillas");
                                    contenedor = "";
                                    estado = 4;
                                    break;
                                case '[':
                                    contenedor += concatenada;
                                    actual.insertar(contenedor, "16", "otros");
                                    contenedor = "";
                                    estado = 9;
                                    break;
                                case '{':
                                    contenedor += concatenada;
                                    actual.insertar(contenedor, "17", "otros");
                                    contenedor = "";
                                    estado = 12;
                                    break;
                                case '(':
                                    contenedor += concatenada;
                                    actual.insertar(contenedor, "23", "otros");
                                    contenedor = "";
                                    estado = 13;

                                    break;
                                case '<':
                                    contenedor += concatenada;
                                    actual.insertar(contenedor, "24", "otros");
                                    contenedor = "";
                                    estado = 14;
                                    break;
                                case ';':
                                    contenedor += concatenada;
                                    actual.insertar(contenedor, "29", "otros");
                                    contenedor = "";
                                    estado = 15;
                                    break;
                                case '>':
                                    contenedor += concatenada;
                                    actual.insertar(contenedor, "30", "otros");
                                    contenedor = "";
                                    estado = 0;
                                    break;
                                case ')':
                                    contenedor += concatenada;
                                    actual.insertar(contenedor, "31", "otros");
                                    contenedor = "";
                                    estado = 0;
                                    break;
                                case '}':
                                    contenedor += concatenada;
                                    actual.insertar(contenedor, "32", "otros");
                                    contenedor = "";
                                    estado = 0;
                                    break;
                                case ']':
                                    contenedor += concatenada;
                                    actual.insertar(contenedor, "33", "otros");
                                    contenedor = "";
                                    estado = 0;
                                    break;

                            }
                        }
                        else
                        {
                            contenedor += concatenada;
                            addError(errorcount,inicial, contador,contenedor, "Desconocido");
                            contenedor = "";
                            estado = 0;
                        }
                        inicial++;
                        break;
                    case 1:
                        if (concatenada.Equals('P') || concatenada.Equals('p'))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 1;
                        }
                        else if (concatenada.Equals('l'))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 1;
                        }
                        else if (concatenada.Equals('a'))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 1;
                        }
                        else if (concatenada.Equals('n'))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 1;
                        }
                        else if (concatenada.Equals('i'))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 1;
                        }
                        else if (concatenada.Equals('f'))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 1;
                        }
                        else if (concatenada.Equals('c'))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 1;
                        }
                        else if (concatenada.Equals('d'))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 1;
                        }
                        else if (concatenada.Equals('o'))
                        {
                            Aux2 += concatenada;
                            contenedor += concatenada;
                            estado = 1;
                        }
                        else if (concatenada.Equals('r'))
                        {
                            contenedor += concatenada;

                            Aux2 += concatenada;
                            estado = 1;
                            //inicial = inicial - 1;
                        }
                        else if (concatenada.Equals(':'))
                        {

                            Aux2 += concatenada;
                            aux3 = "";
                            estado = 2;
                            inicial = inicial - 1;
                        }
                        else if (concatenada.Equals('"'))
                        {
                            aux3 += concatenada;
                            addTokens(num, aux3, "14", "Comillas");

                            Aux2 += concatenada;
                            estado = 3;
                            aux3 = "";
                            //inicial = inicial - 1;
                        }
                        else
                        {
                            if (Aux2 != null)
                            {
                                estado = 2;
                            }
                            else {
                                aux += concatenada;
                                estado = 1;
                                addError(errorcount, inicial, contador, aux, "Desconocido");
                                //inicial = inicial - 1;
                            }
                        }



                        inicial++;
                        break;
                    case 2:
                        if (Aux2.Equals("Planificador:") || Aux2.Equals("planificador:"))
                        {
                            addTokens(num, contenedor, "11", "Palabra Reservada");
                            estado = 0;
                            contenedor = "";
                            num++;
                            inicial--;
                        }
                        if (concatenada.Equals(':'))
                        {
                            aux3 += concatenada;
                            addTokens(num, aux3, "13", "Dos Puntos");
                            estado = 1;
                            num++;
                        }
                        else
                        {
                            Aux2 += concatenada;
                            addError(errorcount, inicial, contador, contenedor, "Desconocido");
                            Aux2 = "";
                            aux="";
                            contenedor = "";
                            aux3 = "";
                            estado =2;
                            errorcount++;
                            //inicial--;
                        }
                        inicial++;
                        break;
                }

                }
            }
           
        
       
        private void Tab1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected = tablero1.SelectedIndex;
            label1.Text = selected.ToString();
        }
        public void mostrar()
        {

            for (int i=0;i<Tokens.Count;i++)
            {
                Nodo actual1 = Tokens.ElementAt(i);
               
                Console.WriteLine("" + actual1.getContador() + ","+ actual1.lexema + ", " + actual1.id + ", " + actual1.token);
            }

           /* if ( != null)
            {

                do
                {

                    Console.WriteLine(""+ actual1.contador + "," + actual1.id + ", " + actual1.lexema + ", " + actual1.lexema);
                    //  enviar.label1.Text = actual1.Lexema;
                    actual1 = actual1.siguiente;

                } while (actual1 != null);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No hay archivos Guardados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }
        public void mostrar2()
        {
            for (int i = 0; i < error.Count; i++)
            {
                Tokens_error actual1 = error.ElementAt(i);

                Console.WriteLine("" + actual1.Contador + "," + actual1.Fila + ", " + actual1.Columna+ ", " + actual1.Caracter+", "+actual1.Descripcion);
            }
        }
    }
}
