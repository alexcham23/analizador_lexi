using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        public string plan,año,mes,dia,descrip,image;
        tokenvalid a = new tokenvalid();
        int  contador2 = 1;
       // int contador = 1;
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
                Name = "pestaña" + contador2++,
                Text = "Pestaña " + contador2,
            };

            RichTextBox caja = new RichTextBox() //crearemos un caja de texto dentro tabpage con la ayuda del mismo contador sabremos el numero de caja de textos empleados
            {
                Name = "text"+contador2,
            Text = "",
                Dock = DockStyle.Fill,// aqui nos permite que la caja de texto tome  color de letra de tabpage.
                AcceptsTab = true,//aceptaremos el cambio de la caja de texto.

            };

            windows.Controls.Add(caja);//aderimos RichTextBox dentro del tabpage    
            tablero1.Controls.Add(windows);//aderimos tabpage a la ventana de forms.cs

        }

        private void CargarArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
          /*  openFileDialog1.Filter = "Document (*.ly) | *.ly";
            openFileDialog1.FileName = "";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.InitialDirectory = "Escritorio";
            openFileDialog1.CheckFileExists = true;*/
            

           if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                
                selected = tablero1.SelectedIndex;

                string obtener = openFileDialog1.FileName;
                using (StreamReader leer=new StreamReader(obtener))
                {
                    while (!leer.EndOfStream)
                    {
                        if (selected == 0)
                        {
                            //text1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                            text1.AppendText(leer.ReadToEnd());
                            MessageBox.Show("Archivo Abierto", "Lenguajes Proyecto Fase 1", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else if (selected == 1)
                        {
                            //text2.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                            text1.AppendText(leer.ReadToEnd());
                            MessageBox.Show("Archivo Abierto", "Lenguajes Proyecto Fase 1", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        //text1.AppendText(leer.ReadToEnd());
                    }
                }
                  selected = tablero1.SelectedIndex;
                

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
            int digi = 0;
            int espacio = 2;

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
                            || concatenada.Equals(']') || concatenada.Equals('}') || concatenada.Equals(')') || concatenada.Equals('>') || concatenada.Equals('a')
                            || concatenada.Equals('A') || concatenada.Equals('M') || concatenada.Equals('m') || concatenada.Equals('D') || concatenada.Equals('d')
                            || concatenada.Equals('I') || concatenada.Equals('i'))
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
                                    /* //contenedor += concatenada;
                                     addTokens(num, "\n", "10", "salto de linea");
                                     Aux2 = "";
                                     contador++;*/
                                    estado = 0;
                                    //num++;
                                    break;
                                case 'I':
                                    contenedor += concatenada;
                                    Aux2 += concatenada;
                                    estado = 23;
                                    break;
                                case 'i':
                                    contenedor += concatenada;
                                    Aux2 += concatenada;
                                    estado = 23;
                                    break;
                                case 'd':
                                    contenedor += concatenada;
                                    Aux2 += concatenada;
                                    estado = 16;
                                    break;
                                case 'D':
                                    contenedor += concatenada;
                                    Aux2 += concatenada;
                                    estado = 16;
                                    break;
                                case 'm':
                                    contenedor += concatenada;
                                    Aux2 += concatenada;
                                    estado = 12;
                                    break;
                                case 'M':
                                    contenedor += concatenada;
                                    Aux2 += concatenada;
                                    estado = 12;
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
                                    if (Aux2.Equals("Año:") || Aux2.Equals("año:"))
                                    {
                                        contenedor += concatenada;
                                        addTokens(num, contenedor, "13", "Dos Puntos");
                                        contenedor = "";
                                        Aux2 = "";
                                        aux3 = "";
                                        estado = 6;
                                        num++;
                                    }
                                    else if (Aux2.Equals("Mes:") || Aux2.Equals("mes:"))
                                    {
                                        contenedor += concatenada;
                                        addTokens(num, contenedor, "13", "Dos Puntos");
                                        contenedor = "";
                                        Aux2 = "";
                                        aux3 = "";
                                        estado = 14;
                                        num++;
                                    }
                                    else if (Aux2.Equals("Dia:") || Aux2.Equals("dia:"))
                                    {
                                        contenedor += concatenada;
                                        addTokens(num, contenedor, "13", "Dos Puntos");
                                        contenedor = "";
                                        Aux2 = "";
                                        aux3 = "";
                                        estado = 19;
                                        num++;
                                    }
                                    else if (aux.Equals("Diaerror"))
                                    {
                                        contenedor += concatenada;
                                        addTokens(num, contenedor, "13", "Dos Puntos");
                                        contenedor = "";
                                        aux = "";
                                        Aux2 = "";
                                        aux3 = "";
                                        estado = 19;
                                        num++;
                                    }
                                    else
                                    {
                                        contenedor += concatenada;
                                        addTokens(num, contenedor, "13", "Dos Puntos");
                                        contenedor = "";
                                        Aux2 = "";
                                        aux3 = "";
                                        estado = 0;
                                        num++;
                                    }
                                    //inicial = inicial - 1;
                                    break;
                                case '"':
                                    if (aux.Equals("\""))
                                    {
                                        contenedor += concatenada;
                                        aux3 += concatenada;
                                        addTokens(num, contenedor, "14", "Comillas");
                                        contenedor = "";
                                        aux3 = "";
                                        aux = "";
                                        estado = 0;
                                        num++;

                                    }
                                    else
                                    {
                            
                                    contenedor += concatenada;
                                        aux3 += concatenada;
                                        addTokens(num, contenedor, "14", "Comillas");
                                        contenedor = "";
                                        aux3 = "";
                                        estado = 3;
                                        num++;
                                    }
                                    break;
                                case '[':
                                    contenedor += concatenada;
                                    addTokens(num, contenedor, "16", "Corchete Izquierdo");
                                    contenedor = "";
                                    aux = "";
                                    Aux2 = "";
                                    aux3 = "";
                                    num++;
                                    estado = 0;
                                    break;
                                case 'A':
                                    contenedor += concatenada;
                                    Aux2 += concatenada;
                                    estado = 4;
                                    break;
                                case 'a':
                                    contenedor += concatenada;
                                    Aux2 += concatenada;
                                    estado = 4;
                                    break;
                                case '{':
                                    contenedor += concatenada;
                                    addTokens(num, contenedor, "17", "Llave Izquierda");
                                    contenedor = "";
                                    aux = "";
                                    Aux2 = "";
                                    aux3 = "";
                                    num++;
                                    estado = 0;
                                    
                                    break;
                                case '(':
                                    contenedor += concatenada;
                                    addTokens(num, contenedor, "23", "Parentesis Izquierdo");
                                    contenedor = "";
                                    aux = "";
                                    Aux2 = "";
                                    aux3 = "";
                                    num++;
                                    estado = 0;
                                    
                                    break;
                                case '<':
                                    contenedor += concatenada;
                                    addTokens(num, contenedor, "24", "otros");
                                    contenedor = "";
                                    aux = "";
                                    Aux2 = "";
                                    aux3 = "";
                                    num++;
                                    estado = 0;
                                    
                                    break;
                                case ';':
                                    contenedor += concatenada;
                                    addTokens(num, contenedor, "29", "Punto y Coma");
                                    contenedor = "";
                                    aux = "";
                                    Aux2 = "";
                                    aux3 = "";
                                    num++;
                                    estado = 0; ;
                                    break;
                                case '>':
                                    contenedor += concatenada;
                                    addTokens(num, contenedor, "30", "otros");
                                    contenedor = "";
                                    aux = "";
                                    Aux2 = "";
                                    aux3 = "";
                                    num++;
                                    estado = 0;
                                    
                                    break;
                                case ')':
                                    contenedor += concatenada;
                                    addTokens(num, contenedor, "31", "otros");
                                    contenedor = "";
                                    aux = "";
                                    Aux2 = "";
                                    aux3 = "";
                                    num++;
                                    estado = 0;
                                    
                                    break;
                                case '}':
                                    contenedor += concatenada;
                                    addTokens(num, contenedor, "32", "otros");
                                    contenedor = "";
                                    aux = "";
                                    Aux2 = "";
                                    aux3 = "";
                                    num++;
                                    estado = 0;
                                  
                                    break;
                                case ']':
                                    contenedor += concatenada;
                                    addTokens(num, contenedor, "33", "otros");
                                    contenedor = "";
                                    aux = "";
                                    Aux2 = "";
                                    aux3 = "";
                                    num++;
                                    estado = 0;
                                    break;

                            }
                        }
                        else
                        {
                            contenedor += concatenada;
                            addError(errorcount, inicial, contador, contenedor, "Desconocido");
                            aux = contenedor;
                            contenedor = "";
                            estado = 0;
                            errorcount++;
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
                        else if (concatenada.Equals('l')|| concatenada.Equals('L'))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 1;
                        }
                        else if (concatenada.Equals('a')||concatenada.Equals('A'))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 1;
                        }
                        else if (concatenada.Equals('n')|| concatenada.Equals('N'))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 1;
                        }
                        else if (concatenada.Equals('i')||concatenada.Equals('I'))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 1;
                        }
                        else if (concatenada.Equals('f')|| concatenada.Equals('F'))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 1;
                        }
                        else if (concatenada.Equals('c')|| concatenada.Equals('C'))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 1;
                        }
                        else if (concatenada.Equals('d')|| concatenada.Equals('D'))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 1;
                        }
                        else if (concatenada.Equals('o')|| concatenada.Equals('O'))
                        {
                            Aux2 += concatenada;
                            contenedor += concatenada;
                            estado = 1;
                        }
                        else if (concatenada.Equals('r')|| concatenada.Equals('R'))
                        {
                            contenedor += concatenada;

                            Aux2 += concatenada;
                            estado = 1;
                            //inicial = inicial - 1;
                        }
                        else if(concatenada.Equals(' '))
                        {
                            
                            estado = 1;
                            //inicial = inicial - 1;
                        }
                        else if (concatenada.Equals('\t'))
                        {

                            estado = 1;
                            //inicial = inicial - 1;
                        }
                        else if (concatenada.Equals('\n'))
                        {
                            contador++;
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
                        /* else if (concatenada.Equals('"'))
                         {
                             aux3 += concatenada;
                             addTokens(num, aux3, "14", "Comillas");

                             Aux2 += concatenada;
                             estado = 3;
                             aux3 = "";
                             //inicial = inicial - 1;
                         }*/
                        else
                        {

                            estado = 2;
                            inicial = inicial - 2;

                        }

                        inicial++;
                        break;
                    case 2:
                        if (Aux2.Equals("Planificador:") || Aux2.Equals("planificador:"))
                        {
                            addTokens(num, contenedor, "11", "Palabra Reservada");
                            estado = 0;
                            aux = contenedor;
                            contenedor = "";
                            Aux2 = "";
                            aux3 = "";
                            num++;
                            inicial--;
                        }
                        else if (Aux2.Equals("r:") || Aux2.Equals("or:") || Aux2.Equals("dor:") || Aux2.Equals("ador:") || Aux2.Equals("cador:")
                          || Aux2.Equals("icador:") || Aux2.Equals("ficador:") || Aux2.Equals("ificador:") || Aux2.Equals("nificador:") || Aux2.Equals("anificador:")
                          || Aux2.Equals("lanificador:"))
                        {
                            addError(errorcount, inicial, contador, contenedor, "Desconocido");
                            estado = 0;
                            contenedor = "";
                            aux = "";
                            Aux2 = "";
                            aux3 = "";
                            errorcount++;
                            inicial--;
                        }
                        
                        else if (Aux2.Equals(":"))
                        {
                            aux3 += concatenada;
                            addTokens(num, aux3, "13", "Dos Puntos");
                            estado = 0;
                            contenedor = "";
                            Aux2 = "";
                            num++;
                        }
                        else if (concatenada.Equals('P') || concatenada.Equals('p') || concatenada.Equals('l') || concatenada.Equals('L') ||
                           concatenada.Equals('a') || concatenada.Equals('A') || concatenada.Equals('n') || concatenada.Equals('N') ||
                           concatenada.Equals('I') || concatenada.Equals('i') || concatenada.Equals('f') || concatenada.Equals('F') ||
                           concatenada.Equals('C') || concatenada.Equals('c') || concatenada.Equals('o') || concatenada.Equals('O') ||
                           concatenada.Equals('R') || concatenada.Equals('r'))
                        {
                            addError(errorcount, inicial, contador, Aux2, "Desconocido");
                            Aux2 = "";
                            aux = "";
                            contenedor = "";
                            aux3 = "";
                            estado = 2;
                            errorcount++;
                            //inicial--;
                        }
                        else
                        {
                            aux += concatenada;

                            addError(errorcount, inicial, contador, aux, "Desconocido");
                            Aux2 = "";
                            aux = "";
                            contenedor = "";
                            aux3 = "";
                            estado = 1;
                            errorcount++;

                        }
                        inicial++;
                        break;
                    case 3:
                        if (concatenada.Equals('A') || concatenada.Equals('a'))
                        {
                            Aux2 += concatenada;
                            contenedor += concatenada;
                            estado = 3;

                        }
                        else if (concatenada.Equals('B') || concatenada.Equals('b'))
                        {
                            Aux2 += concatenada;
                            contenedor += concatenada;
                            estado = 3;

                        }
                        else if (concatenada.Equals('C') || concatenada.Equals('c'))
                        {
                            Aux2 += concatenada;
                            contenedor += concatenada;
                            estado = 3;

                        }
                        else if (concatenada.Equals('D') || concatenada.Equals('d'))
                        {
                            Aux2 += concatenada;
                            contenedor += concatenada;
                            estado = 3;

                        }
                        else if (concatenada.Equals('E') || concatenada.Equals('e'))
                        {
                            Aux2 += concatenada;
                            contenedor += concatenada;
                            estado = 3;

                        }
                        else if (concatenada.Equals('F') || concatenada.Equals('f'))
                        {
                            Aux2 += concatenada;
                            contenedor += concatenada;
                            estado = 3;

                        }
                        else if (concatenada.Equals('G') || concatenada.Equals('g'))
                        {
                            Aux2 += concatenada;
                            contenedor += concatenada;
                            estado = 3;

                        }
                        else if (concatenada.Equals('H') || concatenada.Equals('h'))
                        {
                            Aux2 += concatenada;
                            contenedor += concatenada;
                            estado = 3;

                        }
                        else if (concatenada.Equals('I') || concatenada.Equals('i'))
                        {
                            Aux2 += concatenada;
                            contenedor += concatenada;
                            estado = 3;

                        }
                        else if (concatenada.Equals('J') || concatenada.Equals('j'))
                        {
                            Aux2 += concatenada;
                            contenedor += concatenada;
                            estado = 3;

                        }
                        else if (concatenada.Equals('K') || concatenada.Equals('k'))
                        {
                            Aux2 += concatenada;
                            contenedor += concatenada;
                            estado = 3;

                        }
                        else if (concatenada.Equals('L') || concatenada.Equals('l'))
                        {
                            Aux2 += concatenada;
                            contenedor += concatenada;
                            estado = 3;

                        }
                        else if (concatenada.Equals('M') || concatenada.Equals('m'))
                        {
                            Aux2 += concatenada;
                            contenedor += concatenada;
                            estado = 3;

                        }
                        else if (concatenada.Equals('N') || concatenada.Equals('n'))
                        {
                            Aux2 += concatenada;
                            contenedor += concatenada;
                            estado = 3;

                        }
                        else if (concatenada.Equals('Ñ') || concatenada.Equals('ñ'))
                        {
                            contenedor += concatenada;
                            estado = 3;

                        }
                        else if (concatenada.Equals('O') || concatenada.Equals('o'))
                        {
                            Aux2 += concatenada;
                            contenedor += concatenada;
                            estado = 3;
                        }
                        else if (concatenada.Equals('P') || concatenada.Equals('p'))
                        {
                            Aux2 += concatenada;
                            contenedor += concatenada;
                            estado = 3;

                        }
                        else if (concatenada.Equals('Q') || concatenada.Equals('q'))
                        {
                            Aux2 += concatenada;
                            contenedor += concatenada;
                            estado = 3;
                        }
                        else if (concatenada.Equals('R') || concatenada.Equals('r'))
                        {
                            Aux2 += concatenada;
                            contenedor += concatenada;
                            estado = 3;

                        }
                        else if (concatenada.Equals('S') || concatenada.Equals('s'))
                        {
                            Aux2 += concatenada;
                            contenedor += concatenada;
                            estado = 3;

                        }
                        else if (concatenada.Equals('T') || concatenada.Equals('t'))
                        {
                            Aux2 += concatenada;
                            contenedor += concatenada;
                            estado = 3;
                        }
                        else if (concatenada.Equals('U') || concatenada.Equals('u'))
                        {
                            contenedor += concatenada;
                            estado = 3;

                        }
                        else if (concatenada.Equals('V') || concatenada.Equals('v'))
                        {
                            Aux2 += concatenada;
                            contenedor += concatenada;
                            estado = 3;

                        }
                        else if (concatenada.Equals('W') || concatenada.Equals('w'))
                        {
                            Aux2 += concatenada;
                            contenedor += concatenada;
                            estado = 3;
                        }
                        else if (concatenada.Equals('Y') || concatenada.Equals('y'))
                        {
                            Aux2 += concatenada;
                            contenedor += concatenada;
                            estado = 3;

                        }
                        else if (concatenada.Equals('Z') || concatenada.Equals('z'))
                        {
                            Aux2 += concatenada;
                            contenedor += concatenada;
                            estado = 3;

                        }
                        else if (concatenada.Equals('"'))
                        {
                            aux3 += concatenada;
                            estado = 7;
                            //inicial--;
                        }
                        else if (concatenada.Equals('\n'))
                        {
                            contenedor += concatenada;
                            contador++;
                            estado = 3;
                        }
                        else
                        {
                            contenedor += concatenada;
                            estado = 3;
                        }
                        inicial++;
                        break;
                    case 4:
                        if (concatenada.Equals('A') || concatenada.Equals('a'))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 4;
                        }
                        else if (concatenada.Equals('Ñ') || concatenada.Equals('ñ'))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 4;
                        }
                        else if (concatenada.Equals('O') || concatenada.Equals('o'))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 4;
                        }
                        else if (concatenada.Equals(' '))
                        {

                            estado = 4;
                            //inicial = inicial - 1;
                        }
                        else if (concatenada.Equals('\t'))
                        {

                            estado =4;
                            //inicial = inicial - 1;
                        }
                        else if (concatenada.Equals('\n'))
                        {
                            contador++;
                            estado = 4;
                        }
                        else if (concatenada.Equals(':'))
                        {
                            Aux2 += concatenada;
                            aux3 = "";
                            estado = 5;
                            inicial = inicial - 1;
                        }
                        else
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 4;
                        }
                        inicial++;
                        break;

                    case 5:
                        if (Aux2.Equals("Año:") || Aux2.Equals("año:"))
                        {
                            addTokens(num, contenedor, "21", "Palabra Reservada");
                            estado = 0;
                            aux = contenedor;
                            contenedor = "";

                            //Aux2 = "";
                            aux3 = "";
                            num++;
                            inicial--;
                        }
                        else if (Aux2.Equals("ño:") || Aux2.Equals("o:"))
                        {
                            addError(errorcount, inicial, contador, contenedor, "Desconocido");
                            estado = 0;
                            contenedor = "";
                            aux = "";
                            Aux2 = "";
                            aux3 = "";
                            errorcount++;
                            inicial--;
                        }
                        else
                        {
                            aux += concatenada;

                            addError(errorcount, inicial, contador, aux, "Desconocido");
                            Aux2 = "";
                            aux = "";
                            contenedor = "";
                            aux3 = "";
                            estado = 4;
                            errorcount++;

                        }
                        inicial++;
                        break;
                    case 6:
                        
                        if (concatenada.Equals('0') || concatenada.Equals('1') || concatenada.Equals('2') || concatenada.Equals('3')
                           || concatenada.Equals('4') || concatenada.Equals('5') || concatenada.Equals('6') || concatenada.Equals('7')
                           || concatenada.Equals('8') || concatenada.Equals('9'))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;

                            estado = 6;
                        }
                        else if (concatenada.Equals('{'))
                        {
                            //aux3 += concatenada;
                            digi = int.Parse(contenedor);
                            estado = 11;
                            inicial--;
                        }
                        else if (concatenada.Equals('\t'))
                        {

                            estado = 6;
                            //inicial = inicial - 1;
                        }
                        else if (concatenada.Equals('\n'))
                        {
                            contador++;
                            estado = 6;
                            }
                            else if (concatenada.Equals(' '))
                            {
                                
                                estado = 6;
                            }
                            else
                            {
                            estado = 10;
                            inicial--;
                        }
                        inicial++;
                        break;
                    case 7:
                        
                        if (concatenada.Equals('['))
                        {
                            if (Aux2.Equals(" "))
                            {
                                aux3 += concatenada;
                                estado = 7;
                                inicial = inicial - espacio;
                                Aux2 = "";
                            }
                            else
                            {
                                aux3 += concatenada;
                                estado = 7;
                                inicial = inicial - 2;
                            }
                        }else if (concatenada.Equals(';'))
                        {
                            if (Aux2.Equals(" "))
                            {
                                aux3 += concatenada;
                                estado = 7;
                                inicial = inicial - espacio;
                                Aux2 = "";
                            }
                            else
                            {
                                aux3 += concatenada;
                                estado = 7;
                                inicial = inicial - 2;
                            }
                        }
                        else if (concatenada.Equals('\t'))
                        {
                            Aux2 = " ";
                            estado = 7;
                            espacio++;
                            //inicial = inicial - 1;
                        }
                        else if (concatenada.Equals('\n'))
                        {
                            Aux2 = " ";
                            contador++;
                            estado = 7;
                            espacio++;
                        }
                        else if (concatenada.Equals(' '))
                        {
                            Aux2 = " ";
                            estado = 7;
                            espacio++;
                        }
                        else if (aux3.Equals("\"[")|| aux3.Equals("\";"))
                        {

                            estado = 9;
                            Aux2 = "";
                            aux3 = "";
                            espacio = 2;
                            inicial--;
                        }
                        
                        else if (aux3 != "\"["|| aux3 != "\";")
                        {
                            aux3 += concatenada;
                            aux = "";
                            estado = 8;
                            espacio = 2;
                            inicial = inicial - 2;
                        }

                        inicial++;
                        break;
                    case 8:
                        if (concatenada.Equals('"'))
                        {
                            contenedor += concatenada;
                            estado = 3;
                            aux = "";
                            aux3 = "";
                            // inicial = inicial - 1;
                        }
                        else
                        {
                            contenedor += concatenada;
                            estado = 3;
                            aux3 = "";
                            //  inicial = inicial - 1;
                        }
                        inicial++;
                        break;
                    case 9:
                        if (aux.Equals("Planificador") || aux.Equals("planificador"))
                        {
                            addTokens(num, contenedor, "12", "Cadena");
                            plan = contenedor;
                            contenedor = "";
                            aux = "";
                            aux = "\"";
                            estado = 0;
                            inicial = inicial - 1;

                        }
                        else if(aux.Equals("Planificador :") || aux.Equals("planificador :"))
                            {
                            addTokens(num, contenedor, "12", "Cadena");
                            plan = contenedor;
                            contenedor = "";
                            aux = "";
                            aux = "\"";
                            estado = 0;
                            inicial = inicial - 1;
                        }
                        else if (aux.Equals("Descripcion") || aux.Equals("descripcion"))
                        {
                            addTokens(num, contenedor, "12", "Cadena");
                            contenedor = "";
                            aux = "";
                            descrip = contenedor;
                            aux = "\"";
                            estado = 0;
                            inicial--;
                        }
                        else if (aux.Equals("Imagen") || aux.Equals("imagen"))
                        {
                            addTokens(num, contenedor, "12", "Cadena");
                            contenedor = "";
                            aux = "";
                            image = contenedor;
                            aux = "\"";
                            estado =0;
                            inicial--;
                        }
                        else if (concatenada.Equals('"'))
                        {
                            contenedor += concatenada;
                            aux3 += concatenada;
                            addTokens(num, contenedor, "14", "Comillas");
                            contenedor = "";
                            aux3 = "";
                            estado = 6;
                            num++;
                        }
                        else
                        {
                            addTokens(num, contenedor, "12", "Cadena");
                            contenedor = "";
                            aux = "";
                            //image = contenedor;
                            estado = 6;
                            inicial--;
                        }
                        inicial++;
                        break;
                    case 10:
                        
                        if (concatenada.Equals('0') || concatenada.Equals('1') || concatenada.Equals('2') || concatenada.Equals('3')
                           || concatenada.Equals('4') || concatenada.Equals('5') || concatenada.Equals('6') || concatenada.Equals('7')
                           || concatenada.Equals('8') || concatenada.Equals('9'))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;

                            estado = 10;
                        }
                        else if (concatenada.Equals(' '))
                        {

                            estado = 10;
                            //inicial = inicial - 1;
                        }
                        else if (concatenada.Equals('\t'))
                        {

                            estado =10;
                            //inicial = inicial - 1;
                        }
                        else if (concatenada.Equals('\n'))
                        {
                            contador++;
                            estado = 4;
                        }
                        else
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 6;
                            inicial--;
                        }
                        inicial++;
                        break;
                    case 11:
                        if (aux.Equals("año") || aux.Equals("Año"))
                        {
                            if (digi < 10000 && digi >= 1)
                            {
                                addTokens(num, contenedor, "25", "Numero");
                                año = contenedor;
                                contenedor = "";
                                aux = "";
                                aux = "\"";
                                estado = 0;
                                digi = 0;
                                num++;
                                inicial = inicial - 1;
                            }
                            else
                            {
                                addError(errorcount, inicial, contador, contenedor, "Desconocido");
                                estado = 0;
                                contenedor = "";
                                aux = "";
                                Aux2 = "";
                                aux3 = "";
                                digi = 0;
                                errorcount++;
                                inicial--;
                            }

                        }
                        else if (aux.Equals("Mes") || aux.Equals("mes"))
                        {
                            if (digi < 12 && digi >= 1)
                            {
                                addTokens(num, contenedor, "25", "Numero");
                                mes = contenedor;
                                contenedor = "";
                                aux = "";
                                aux = "\"";
                                estado = 0;
                                digi = 0;
                                num++;
                                inicial = inicial - 1;
                            }
                            else
                            {
                                addError(errorcount, inicial, contador, contenedor, "Desconocido");
                                estado = 0;
                                contenedor = "";
                                aux = "";
                                Aux2 = "";
                                aux3 = "";
                                digi = 0;
                                errorcount++;
                                inicial--;
                            }

                        }
                        else if (aux.Equals("Dia") || aux.Equals("dia"))
                        {
                            if (digi < 31 && digi >= 1)
                            {
                                addTokens(num, contenedor, "25", "Numero");
                                mes = contenedor;
                                contenedor = "";
                                aux = "";
                                aux = "\"";
                                estado = 0;
                                digi = 0;
                                num++;
                                inicial = inicial - 1;
                            }
                            else
                            {
                                addError(errorcount, inicial, contador, contenedor, "Desconocido");
                                estado = 0;
                                contenedor = "";
                                aux = "";
                                Aux2 = "";
                                aux3 = "";
                                digi = 0;
                                errorcount++;
                                inicial--;
                            }

                        }

                        inicial++;
                        break;
                    case 12:
                        if (concatenada.Equals('M') || concatenada.Equals('m'))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 12;
                        }
                        else if (concatenada.Equals('E') || concatenada.Equals('e'))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 12;
                        }
                        else if (concatenada.Equals('S') || concatenada.Equals('s'))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 12;
                        }
                        else if (concatenada.Equals(' '))
                        {

                            estado = 12;
                            //inicial = inicial - 1;
                        }
                        else if (concatenada.Equals('\t'))
                        {

                            estado = 12;
                            //inicial = inicial - 1;
                        }
                        else if (concatenada.Equals('\n'))
                        {
                            contador++;
                            estado = 12;
                        }
                        else if (concatenada.Equals(':'))
                        {
                            Aux2 += concatenada;
                            aux3 = "";
                            estado = 13;
                            inicial = inicial - 1;
                        }
                        else
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 12;
                        }
                        inicial++;
                        break;
                    case 13:
                        if (Aux2.Equals("Mes:") || Aux2.Equals("mes:"))
                        {
                            addTokens(num, contenedor, "22", "Palabra Reservada");
                            estado = 0;
                            aux = contenedor;
                            contenedor = "";

                            //Aux2 = "";
                            aux3 = "";
                            num++;
                            inicial--;
                        }
                        else if (Aux2.Equals("es:") || Aux2.Equals("s:"))
                        {
                            addError(errorcount, inicial, contador, contenedor, "Desconocido");
                            estado = 0;
                            contenedor = "";
                            aux = "";
                            Aux2 = "";
                            aux3 = "";
                            errorcount++;
                            inicial--;
                        }
                        else
                        {
                            aux += concatenada;

                            addError(errorcount, inicial, contador, aux, "Desconocido");
                            Aux2 = "";
                            aux = "";
                            contenedor = "";
                            aux3 = "";
                            estado = 12;
                            errorcount++;
                            inicial--;

                        }
                        inicial++;
                        break;
                    case 14:
                        
                        if (concatenada.Equals('0') || concatenada.Equals('1') || concatenada.Equals('2') || concatenada.Equals('3')
                           || concatenada.Equals('4') || concatenada.Equals('5') || concatenada.Equals('6') || concatenada.Equals('7')
                           || concatenada.Equals('8') || concatenada.Equals('9'))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;

                            estado = 14;
                        }
                        else if (concatenada.Equals(' '))
                        {

                            estado = 14;
                            //inicial = inicial - 1;
                        }
                        else if (concatenada.Equals('\t'))
                        {

                            estado = 14;
                            //inicial = inicial - 1;
                        }
                        else if (concatenada.Equals('\n'))
                        {
                            contador++;
                            estado = 4;
                        }
                        else if (concatenada.Equals('('))
                        {
                            //aux3 += concatenada;
                            digi = int.Parse(contenedor);
                            estado = 11;
                            inicial--;
                        }
                        else
                        {
                            estado = 15;
                            inicial--;
                        }
                        inicial++;
                        break;
                    case 15:
                        if (concatenada.Equals(' '))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 15;
                            inicial--;
                        }
                        if (concatenada.Equals('0') || concatenada.Equals('1') || concatenada.Equals('2') || concatenada.Equals('3')
                           || concatenada.Equals('4') || concatenada.Equals('5') || concatenada.Equals('6') || concatenada.Equals('7')
                           || concatenada.Equals('8') || concatenada.Equals('9'))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;

                            estado = 10;
                        }
                        /*else if (concatenada.Equals('('))
                        {
                            addError(errorcount, inicial, contador, contenedor, "Desconocido");
                            estado = 0;
                            contenedor = "";
                            aux = "";
                            Aux2 = "";
                            aux3 = "";
                            digi = 0;
                            errorcount++;
                            inicial--;
                        }*/
                        else
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 14;
                            inicial--;
                        }
                        inicial++;
                        break;
                    case 16:
                        if (concatenada.Equals('i') || concatenada.Equals('I'))
                        {
                            //contenedor += concatenada;
                            //Aux2 += concatenada;
                            estado = 17;
                            inicial --;
                        }
                        else if (concatenada.Equals('e') || concatenada.Equals('E'))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 16;
                        }
                        else if (Aux2.Equals("Di") || Aux2.Equals("di"))
                        {

                            estado = 17;
                            inicial--;
                        }
                        else if (Aux2.Equals("De") || Aux2.Equals("de"))
                        {

                            estado = 21;
                            inicial--;
                        }else if (concatenada.Equals('\t'))
                        {
                            estado = 16;
                        }
                        else if (concatenada.Equals('\n'))
                        {
                            contador++;
                            estado = 16;
                        }
                        else if (concatenada.Equals(' '))
                        {
                            estado = 16;
                        }
                        else if (concatenada.Equals(':'))
                        {
                            estado = 16;
                        }
                        inicial++;
                        break;
                    case 17:
                        if (concatenada.Equals('D') || concatenada.Equals('d'))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 17;
                        }
                        else if (concatenada.Equals('I') || concatenada.Equals('i'))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 17;
                        }
                        else if (concatenada.Equals('A') || concatenada.Equals('a'))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 17;
                        }
                        else if (concatenada.Equals(' '))
                        {
                           // Aux2 += concatenada;
                            estado = 17;
                            //inicial = inicial - 1;
                        }
                        else if (concatenada.Equals('\t'))
                        {

                            estado = 17;
                            //inicial = inicial - 1;
                        }
                        else if (concatenada.Equals('\n'))
                        {
                            contador++;
                            estado = 17;
                        }
                        else if (concatenada.Equals(':'))
                        {
                            if (aux.Equals(":"))
                            {
                                aux = "";
                                aux = "Diaerror";
                                estado = 0;
                                inicial = inicial - 1;
                            }
                            else { 
                            Aux2 += concatenada;
                            aux3 = "";
                            estado = 18;
                            inicial = inicial - 1;
                        }
                        }
                        else
                        {
                            
                            
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 17;
                        }
                        inicial++;
                        break;
                    case 18:
                        if (Aux2.Equals("Dia:") || Aux2.Equals("dia:"))
                        {
                            addTokens(num, contenedor, "22", "Palabra Reservada");
                            estado = 0;
                            aux = contenedor;
                            contenedor = "";

                            //Aux2 = "";
                            aux3 = "";
                            num++;
                            inicial--;
                        }
                        else if (Aux2.Equals("ia:") || Aux2.Equals("a:")|| Aux2.Equals(" :"))
                        {
                            addError(errorcount, inicial, contador, contenedor, "Desconocido");
                            estado = 0;
                            contenedor = "";
                            aux = "";
                            Aux2 = "";
                            aux3 = "";
                            errorcount++;
                            inicial--;
                        }
                        else if(Aux2.Equals("Di") || Aux2.Equals("D") || Aux2.Equals("di") || Aux2.Equals("d"))
                        {
                            aux += concatenada;

                            addError(errorcount, inicial, contador, contenedor, "Desconocido");
                            Aux2 = "";
                            aux = "";
                            contenedor = "";
                            aux3 = "";
                            estado = 17;
                            errorcount++;
                            inicial--;
                        }
                        else
                        {
                           // aux += concatenada;

                            addError(errorcount, inicial, contador, contenedor, "Desconocido");
                            Aux2 = "";
                            aux = "";
                            aux = ":";
                            contenedor = "";
                            aux3 = "";
                            estado = 17;
                            errorcount++;
                            inicial--;

                        }
                        inicial++;
                        break;
                    case 19:
                        if (concatenada.Equals('0') || concatenada.Equals('1') || concatenada.Equals('2') || concatenada.Equals('3')
                           || concatenada.Equals('4') || concatenada.Equals('5') || concatenada.Equals('6') || concatenada.Equals('7')
                           || concatenada.Equals('8') || concatenada.Equals('9'))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;

                            estado = 19;
                        }
                        else if (concatenada.Equals(' '))
                        {

                            estado = 19;
                            //inicial = inicial - 1;
                        }
                        else if (concatenada.Equals('\t'))
                        {

                            estado = 19;
                            //inicial = inicial - 1;
                        }
                        else if (concatenada.Equals('\n'))
                        {
                            contador++;
                            estado = 19;
                        }
                        else if (concatenada.Equals('<'))
                        {
                           
                            //aux3 += concatenada;
                            digi = int.Parse(contenedor);
                            estado = 11;
                            inicial--;
                        }
                        else
                        {
                            estado = 20;
                            inicial--;
                        }
                        inicial++;
                        break;
                    case 20:
                        if (concatenada.Equals(' '))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 20;
                            inicial--;
                        }
                        if (concatenada.Equals('0') || concatenada.Equals('1') || concatenada.Equals('2') || concatenada.Equals('3')
                           || concatenada.Equals('4') || concatenada.Equals('5') || concatenada.Equals('6') || concatenada.Equals('7')
                           || concatenada.Equals('8') || concatenada.Equals('9'))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;

                            estado = 20;
                        }
                        else if (aux.Equals("<"))
                        {
                            addError(errorcount, inicial, contador, contenedor, "Desconocido");
                            estado = 0;
                            contenedor = "";
                            aux = "";
                            Aux2 = "";
                            aux3 = "";
                            digi = 0;
                            errorcount++;
                            inicial--;
                        }
                        else
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            aux = ""+concatenada;
                            estado = 20;
                            //inicial--;
                        }
                        inicial++;
                        break;
                    case 21:
                        if (concatenada.Equals('D') || concatenada.Equals('d'))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 21;
                        }
                        else if (concatenada.Equals('E') || concatenada.Equals('e'))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 21;
                        }
                        else if (concatenada.Equals('S') || concatenada.Equals('s'))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 21;
                        }
                        else if (concatenada.Equals('C') || concatenada.Equals('c'))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 21;
                        }
                        else if (concatenada.Equals('R') || concatenada.Equals('r'))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 21;
                        }
                        else if (concatenada.Equals('I') || concatenada.Equals('i'))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 21;
                        }
                        else if (concatenada.Equals('P') || concatenada.Equals('p'))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 21;
                        }
                        else if (concatenada.Equals('O') || concatenada.Equals('o'))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 21;
                        }
                        else if (concatenada.Equals('N') || concatenada.Equals('n'))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 21;
                        }
                        else if (concatenada.Equals(' '))
                        {

                            estado = 21;
                            //inicial = inicial - 1;
                        }
                        else if (concatenada.Equals('\t'))
                        {

                            estado = 21;
                            //inicial = inicial - 1;
                        }
                        else if (concatenada.Equals('\n'))
                        {
                            contador++;
                            estado = 21;
                        }
                        else if (concatenada.Equals(':'))
                        {
                            Aux2 += concatenada;
                            aux3 = "";
                            estado = 22;
                            inicial = inicial - 1;
                        }
                        inicial++;
                        break;
                    case 22:
                        if (Aux2.Equals("Descripcion:") || Aux2.Equals("Descripcion:"))
                        {
                            addTokens(num, contenedor, "11", "Palabra Reservada");
                            estado = 0;
                            aux = contenedor;
                            contenedor = "";
                            Aux2 = "";
                            aux3 = "";
                            num++;
                            inicial--;
                        }
                        else if (Aux2.Equals("n:") || Aux2.Equals("on:") || Aux2.Equals("ion:") || Aux2.Equals("cion:") || Aux2.Equals("pcion:")
                         || Aux2.Equals("ipcion:") || Aux2.Equals("ripcion:") || Aux2.Equals("cripcion:") || Aux2.Equals("scripcion:") || Aux2.Equals("escripcion:"))
                        {
                            addError(errorcount, inicial, contador, contenedor, "Desconocido");
                            estado = 0;
                            contenedor = "";
                            aux = "";
                            Aux2 = "";
                            aux3 = "";
                            errorcount++;
                            inicial--;
                        }
                        else if (Aux2.Equals(":"))
                        {
                            //aux3 += concatenada;
                            //addTokens(num, aux3, "13", "Dos Puntos");
                            estado = 0;
                            contenedor = "";
                            Aux2 = "";
                            num++;
                            inicial--;
                        }
                        inicial++;
                        break;
                    case 23:
                        if (concatenada.Equals('I') || concatenada.Equals('i'))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 23;
                        }
                        else if (concatenada.Equals('M') || concatenada.Equals('m'))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 23;
                        }
                        else if (concatenada.Equals('A') || concatenada.Equals('a'))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 23;
                        }
                        else if (concatenada.Equals('G') || concatenada.Equals('g'))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 23;
                        }
                        else if (concatenada.Equals('E') || concatenada.Equals('e'))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 23;
                        }
                        else if (concatenada.Equals('N') || concatenada.Equals('n'))
                        {
                            contenedor += concatenada;
                            Aux2 += concatenada;
                            estado = 23;
                        }
                        else if (concatenada.Equals(' '))
                        {

                            estado = 23;
                            //inicial = inicial - 1;
                        }
                        else if (concatenada.Equals('\t'))
                        {

                            estado = 23;
                            //inicial = inicial - 1;
                        }
                        else if (concatenada.Equals('\n'))
                        {
                            contador++;
                            estado = 23;
                        }
                        else if (concatenada.Equals(':'))
                        {
                            Aux2 += concatenada;
                            aux3 = "";
                            estado = 24;
                            inicial = inicial - 1;
                        }
                        inicial++;
                        break;
                    case 24:
                        if (Aux2.Equals("Imagen:") || Aux2.Equals("imagen:"))
                        {
                            addTokens(num, contenedor, "11", "Palabra Reservada");
                            estado = 0;
                            aux = contenedor;
                            contenedor = "";
                            Aux2 = "";
                            aux3 = "";
                            num++;
                            inicial--;
                        }
                        else if (Aux2.Equals("n:") || Aux2.Equals("en:") || Aux2.Equals("gen:") || Aux2.Equals("agen:") || Aux2.Equals("magen:"))
                        {
                            addError(errorcount, inicial, contador, contenedor, "Desconocido");
                            estado = 0;
                            contenedor = "";
                            aux = "";
                            Aux2 = "";
                            aux3 = "";
                            errorcount++;
                            inicial--;
                        }
                        else if (Aux2.Equals(":"))
                        {
                            //aux3 += concatenada;
                            //addTokens(num, aux3, "13", "Dos Puntos");
                            estado = 0;
                            contenedor = "";
                            Aux2 = "";
                            num++;
                            inicial--;
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
