using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Verificador_Codigo.Clases;
using System.Threading;
using System.Runtime.CompilerServices;

namespace Verificador_Codigo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Cargar_Archivo_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFile_examinar_ = new OpenFileDialog();

                openFile_examinar_.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                openFile_examinar_.Filter = "Clases (*.cs)|*.cs|JavaScript (*.js)|*.js|All Files (*.*)|*.*";

                if (openFile_examinar_.ShowDialog(this) == DialogResult.OK)
                {
                    Lbl_Ruta_Archivo.Text = openFile_examinar_.FileName;
                    Lbl_Nombre_Archivo.Text = openFile_examinar_.SafeFileName;


                    Thread hilo_ = new Thread(Examinar_Archivo);
                    hilo_.Start();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Errro: " + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void Examinar_Archivo()
        {
            String ruta_archivo = "";// variable para la ruta del archivo
            StringBuilder texto = new StringBuilder();//    variable para contener el texto del archivo 

            try {
                if (InvokeRequired)
                {
                    Invoke(new Action(() => ruta_archivo = Lbl_Ruta_Archivo.Text));

                    string[] lineas = System.IO.File.ReadAllLines(@"" + Lbl_Ruta_Archivo.Text);

                    foreach (string linea in lineas)
                    {
                        // Use a tab to indent each line of the file.
                        texto.AppendLine(linea);
                    }

                    Invoke(new Action(() => Txt_Archivo.Text = texto.ToString()));
                }

            }
            catch (Exception ex)
            { }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Btn_Revisar_Click(object sender, EventArgs e)
        {
            try
            {
             
                var obj_1 = Revision_Punto1(Lbl_Nombre_Archivo.Text, Lbl_Ruta_Archivo.Text);
              

                await Task.WhenAll(
                    obj_1
                    );


                var resultado_1 = await obj_1;//    variable para contener el resultado numero 1



                //  se cargan los resultados
                Txt_Resultado1.Text = resultado_1.ToString();


            }
            catch (Exception ex)
            {
                throw new Exception("Errro: " + ex.Message);
            }
        }



        #region Revision

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre_archivo"></param>
        /// <param name="ruta_archivo"></param>
        /// <returns></returns>
        public async Task<String> Revision_Punto1(String nombre_archivo, String ruta_archivo)
        {
            String resultado = "";//    variable para colocar el resultado
            bool tieneMayusculas = false;// variable para saber si una palabra esta en mayusculas
            Int32 numero_linea = 0;//   variable para obtener el numero de linea del archivo

            try
            {
                //  validamos que no sea una clase
                if (!nombre_archivo.Contains("cs"))
                {

                    // Read each line of the file into a string array. Each element
                    // of the array is one line of the file.
                    string[] lineas = System.IO.File.ReadAllLines(@"" + ruta_archivo);


                    foreach (string linea in lineas)
                    {
                        //  se incrementa el numero de la linea
                        numero_linea++;

                        //  validamos que tenga la paralabre de function
                        if (linea.Contains("function"))
                        {
                            break;
                        }
                        else//  buscaremos que tenga la palabra var
                        {
                            //  validamos que tenga la paralabre de function
                            if (linea.Contains("var"))
                            {
                                string[] linea_sesion = linea.Split(' ');

                                tieneMayusculas = false;

                                //  se recorren las palabras de la linea
                                for (int palabra = 0; palabra <= linea_sesion.Length - 1; palabra++)
                                {
                                    //  validamos las dos primeras palabras
                                    if (palabra == 1)
                                    {
                                        tieneMayusculas = linea_sesion[palabra].Any(c => char.IsUpper(c));

                                        //  validamos que tenga las letras en mayuscula
                                        if (tieneMayusculas == false)
                                        {
                                            resultado += linea + " Linea[" + numero_linea + "]" + "\n";
                                        }

                                    }
                                    else if (palabra > 1)// si es mayor ya no se leera la linea
                                    {
                                        break;
                                    }
                                }



                            }
                        }
                    }


                }
            }
            catch (Exception ex)
            {

            }

            return resultado;
        }

        #endregion
    }
}
