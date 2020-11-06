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
using Telerik;
using Telerik.WinControls.UI;

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
        private void RBtn_Cargar_Archivo_Click(object sender, EventArgs e)
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
                throw new Exception("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RBtn_Actualizar_Archivo_Click(object sender, EventArgs e)
        {
            try
            {
                Thread hilo_ = new Thread(Examinar_Archivo);
                hilo_.Start();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
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
        private async void RBtn_Revisar_Click(object sender, EventArgs e)
        {

            try
            {
                Waiting_Bar_Revisando.Visible = true;
                Waiting_Bar_Revisando.StartWaiting();

                var obj_1 = Revision_Punto1(Lbl_Nombre_Archivo.Text, Lbl_Ruta_Archivo.Text);
                var obj_2 = Revision_Punto2(Lbl_Nombre_Archivo.Text, Lbl_Ruta_Archivo.Text);
                var obj_3 = Revision_Punto3(Lbl_Nombre_Archivo.Text, Lbl_Ruta_Archivo.Text);
                var obj_4 = Revision_Punto4(Lbl_Nombre_Archivo.Text, Lbl_Ruta_Archivo.Text);
                var obj_6 = Revision_Punto6(Lbl_Nombre_Archivo.Text, Lbl_Ruta_Archivo.Text);
                var obj_7 = Revision_Punto7(Lbl_Nombre_Archivo.Text, Lbl_Ruta_Archivo.Text);
                var obj_8 = Revision_Punto8(Lbl_Nombre_Archivo.Text, Lbl_Ruta_Archivo.Text);
                var obj_9 = Revision_Punto9(Lbl_Nombre_Archivo.Text, Lbl_Ruta_Archivo.Text);
                var obj_10 = Revision_Punto10(Lbl_Nombre_Archivo.Text, Lbl_Ruta_Archivo.Text);
                var obj_11 = Revision_Punto11(Lbl_Nombre_Archivo.Text, Lbl_Ruta_Archivo.Text);
                var obj_12 = Revision_Punto12(Lbl_Nombre_Archivo.Text, Lbl_Ruta_Archivo.Text);
                var obj_13 = Revision_Punto13(Lbl_Nombre_Archivo.Text, Lbl_Ruta_Archivo.Text);

                //  se ejecutan los metodos
                await Task.WhenAll(
                    obj_1, obj_2, obj_3, obj_4, obj_6, obj_7, obj_8, obj_9, obj_10, obj_11, obj_12, obj_13
                    );

                var resultado_1 = await obj_1;//    variable para contener el resultado numero 1
                var resultado_2 = await obj_2;//    variable para contener el resultado numero 2
                var resultado_3 = await obj_3;//    variable para contener el resultado numero 3
                var resultado_4 = await obj_4;//    variable para contener el resultado numero 4
                var resultado_6 = await obj_6;//    variable para contener el resultado numero 6
                var resultado_7 = await obj_7;//    variable para contener el resultado numero 7
                var resultado_8 = await obj_8;//    variable para contener el resultado numero 8
                var resultado_9 = await obj_9;//    variable para contener el resultado numero 8
                var resultado_10 = await obj_10;//    variable para contener el resultado numero 10
                var resultado_11 = await obj_11;//    variable para contener el resultado numero 11
                var resultado_12 = await obj_12;//    variable para contener el resultado numero 12
                var resultado_13 = await obj_13;//    variable para contener el resultado numero 13


                //  se cargan los resultados
                Txt_Resultado1.Text = resultado_1.ToString();
                Txt_Resultado2.Text = resultado_2.ToString();
                Txt_Resultado3.Text = resultado_3.ToString();
                Txt_Resultado4.Text = resultado_4.ToString();
                Txt_Resultado6.Text = resultado_6.ToString();
                Txt_Resultado7.Text = resultado_7.ToString();
                Txt_Resultado8.Text = resultado_8.ToString();
                Txt_Resultado9.Text = resultado_9.ToString();
                Txt_Resultado10.Text = resultado_10.ToString();
                Txt_Resultado11.Text = resultado_11.ToString();
                Txt_Resultado12.Text = resultado_12.ToString();
                Txt_Resultado13.Text = resultado_13.ToString();


                Waiting_Bar_Revisando.StopWaiting();
                Waiting_Bar_Revisando.Visible = false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resultado"></param>
        /// <returns></returns>
        public StringBuilder Mensaje_Todo_Bien(StringBuilder resultado)
        {
            StringBuilder mensaje_ = new StringBuilder();//  variable para establecer el mensaje de la operación realizada
            string variable_ = "";

            try {

                variable_ = resultado.ToString().Trim();

                //  se indica que todo esta bien
                if (variable_.Length == 0)
                {
                    mensaje_.AppendLine("TODO BIEN :)");
                }
                else
                {
                    mensaje_ = resultado;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }

            return mensaje_;
        }




        #region Revisión

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre_archivo"></param>
        /// <param name="ruta_archivo"></param>
        /// <returns></returns>
        public async Task<StringBuilder> Revision_Punto1(String nombre_archivo, String ruta_archivo)
        {
            ////String resultado = "";//    variable para colocar el resultado
            bool tieneMayusculas = false;// variable para saber si una palabra esta en mayúsculas
            Int32 numero_linea = 0;//   variable para obtener el numero de linea del archivo
            String linea_sin_espacios = "";//   variable para contener la linea sin espacios
            StringBuilder lineas_resultado = new StringBuilder();//    variable para colocar el resultado

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
                        //  se quitan los espacios
                        linea_sin_espacios = linea.Trim();

                        //  se incrementa el numero de la linea
                        numero_linea++;

                        //  validamos que tenga la palabra de function
                        if (linea.Contains("function"))
                        {
                            break;
                        }
                        else//  buscaremos que tenga la palabra var
                        {
                            //   validamos que tenga texto
                            if (linea_sin_espacios != "")
                            {
                                //  validamos que no sea un comentario 
                                if (linea_sin_espacios.Substring(0, 2) == "//")
                                {
                                    //  no se realiza ninguna accion
                                }
                                //  validamos que sea var
                                else if (linea_sin_espacios.Substring(0, 3) == "var")
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
                                                lineas_resultado.AppendLine(linea + " Linea[" + numero_linea + "]");
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
                else
                {
                }

                //  se revisa si no se tuvo errores en la revisión
                lineas_resultado = Mensaje_Todo_Bien(lineas_resultado);

            }
            catch (Exception ex)
            {
                lineas_resultado.AppendLine(ex.Message + "[linea" + numero_linea + "]" + "[" + linea_sin_espacios + "]");
            }

            return lineas_resultado;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre_archivo"></param>
        /// <param name="ruta_archivo"></param>
        /// <returns></returns>
        public async Task<StringBuilder> Revision_Punto2(String nombre_archivo, String ruta_archivo)
        {
            ////String resultado = "";//    variable para colocar el resultado
            bool tieneMayusculas = false;// variable para saber si una palabra esta en mayusculas
            Int32 numero_linea = 0;//   variable para obtener el numero de linea del archivo
            Boolean bandera = false;//  variable para indicar si ya entro a revisar el caracter de la variable
            String linea_sin_espacios = "";//   variable para contener la linea sin espacios

            StringBuilder lineas_resultado = new StringBuilder();//    variable para colocar el resultado

            try
            {
                //  validamos que no sea una clase
                if (nombre_archivo.Contains("cs") && !nombre_archivo.Contains("asmx"))
                {

                    // Read each line of the file into a string array. Each element
                    // of the array is one line of the file.
                    string[] lineas = System.IO.File.ReadAllLines(@"" + ruta_archivo);


                    foreach (string linea in lineas)
                    {
                        //  se incrementa el numero de la linea
                        numero_linea++;

                        //  se quitan los espacios
                        linea_sin_espacios = linea.Trim();


                        //  validamos que no sea linea de using ni de class
                        if (linea.Contains("using") || linea.Contains("class") || linea.Contains("namespace"))
                        {
                            //  no realiza ninguna accion

                        }
                        else//  si lee la linea que no son using, class y namespace
                        {
                            //  validamos que tenga informacion la linea
                            if (linea != "")
                            {

                                //  validamos que el texto de la liena sea mayor a un caracter
                                if (linea_sin_espacios.Length > 1)
                                {

                                    //  validamos que no sea comentario
                                    if (linea_sin_espacios.Substring(0, 2) == "//")
                                    {
                                        //  no realiza ninguna accion
                                    }
                                    else//  si no es comentario procede a revisar
                                    {

                                        string[] linea_texto = linea_sin_espacios.Split(' ');//   variable para contener las palabras
                                        string[] linea_variable_ = linea_texto[2].Split('_');//   variable para contener las palabras

                                        tieneMayusculas = false;


                                        //  se recorren las palabras de la linea
                                        for (int palabra = 0; palabra <= linea_variable_.Length - 1; palabra++)
                                        {
                                            foreach (char caracter_palabra in linea_variable_[palabra])
                                            {
                                                tieneMayusculas = Char.IsUpper(caracter_palabra);

                                                //  validamos que tenga las letras en mayuscula
                                                if (tieneMayusculas == false)
                                                {
                                                    //resultado += linea + " Linea[" + numero_linea + "]" + "\n";
                                                    lineas_resultado.AppendLine(linea + " Linea[" + numero_linea + "]");
                                                    bandera = true;
                                                    break;
                                                }

                                                break;

                                            }

                                            //  validamos que la bandera este indicada
                                            if (bandera == true)
                                            {
                                                bandera = false;
                                                break;
                                            }

                                        }

                                    }
                                }
                            }

                        }
                    }

                }
                else
                {
                }



                //  se revisa si no se tuvo errores en la revisión
                lineas_resultado = Mensaje_Todo_Bien(lineas_resultado);
            }
            catch (Exception ex)
            {
                lineas_resultado.AppendLine(ex.Message + "[linea" + numero_linea + "]" + "[" + linea_sin_espacios + "]");
            }

            return lineas_resultado;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre_archivo"></param>
        /// <param name="ruta_archivo"></param>
        /// <returns></returns>
        public async Task<StringBuilder> Revision_Punto3(String nombre_archivo, String ruta_archivo)
        {
            ////String resultado = "";//    variable para colocar el resultado
            bool tieneMinusculas = false;// variable para saber si una palabra esta en mayusculas
            Int32 numero_linea = 0;//   variable para obtener el numero de linea del archivo
            String linea_sin_espacios = "";//   variable para contener la linea sin espacios
            Boolean bandera = false;//  variable para indicar si ya entro a revisar el caracter de la variable
            Boolean bandera_asmx = false;//  variable para indicar si ya entro a revisar el caracter de la variable

            StringBuilder lineas_resultado = new StringBuilder();//    variable para colocar el resultado


            try
            {
                //  validamos que no sea una clase
                if (nombre_archivo.Contains(".js"))
                {

                    // Read each line of the file into a string array. Each element
                    // of the array is one line of the file.
                    string[] lineas = System.IO.File.ReadAllLines(@"" + ruta_archivo);


                    foreach (string linea in lineas)
                    {
                        //  se quitan los espacios
                        linea_sin_espacios = linea.Trim();

                        //  se incrementa el numero de la linea
                        numero_linea++;

                        //  validamos que tenga información la linea
                        if (linea != "")
                        {
                            //  validamos que el texto de la linea sea mayor a un carácter
                            if (linea_sin_espacios.Length > 3)
                            {
                                //  validamos que tenga la palabra sea var
                                if (linea_sin_espacios.Substring(0, 3) == "var")
                                {
                                    string[] linea_texto = linea_sin_espacios.Replace("$", " ").Split(' ');//   variable para contener las palabras
                                    string[] linea_variable_ = linea_texto[1].Split('_');//   variable para contener las palabras

                                    //  se recorren las palabras de la linea
                                    for (int palabra = 0; palabra <= linea_variable_.Length - 1; palabra++)
                                    {
                                        foreach (char caracter_palabra in linea_variable_[palabra])
                                        {
                                            tieneMinusculas = Char.IsLower(caracter_palabra);

                                            //  validamos que tenga las letras en mayúscula
                                            if (tieneMinusculas == false)
                                            {
                                                lineas_resultado.AppendLine( linea_sin_espacios + " Linea[" + numero_linea + "]");
                                                bandera = true;
                                                break;
                                            }

                                            break;

                                        }

                                        //  validamos que la bandera este indicada
                                        if (bandera == true)
                                        {
                                            bandera = false;
                                            break;
                                        }

                                    }

                                }
                                else if (linea_sin_espacios.Contains("catch"))//    validamos que sea catch
                                {
                                    string[] linea_texto = linea_sin_espacios.Replace("(", "").Replace(")", "").Split(' ');//   variable para contener las palabras
                                    string[] linea_variable_ = linea_texto[2].Split('_');//   variable para contener las palabras

                                    //  se recorren las palabras de la linea
                                    for (int palabra = 0; palabra <= linea_variable_.Length - 1; palabra++)
                                    {
                                        foreach (char caracter_palabra in linea_variable_[palabra])
                                        {
                                            tieneMinusculas = Char.IsLower(caracter_palabra);

                                            //  validamos que tenga las letras en mayuscula
                                            if (tieneMinusculas == false)
                                            {
                                                lineas_resultado.AppendLine(linea_sin_espacios + " Linea[" + numero_linea + "]");
                                                bandera = true;
                                                break;
                                            }

                                            break;

                                        }

                                        //  validamos que la bandera este indicada
                                        if (bandera == true)
                                        {
                                            bandera = false;
                                            break;
                                        }

                                    }
                                }
                                else if (linea_sin_espacios.Contains("function") && !linea_sin_espacios.Contains("--"))
                                {

                                    if (linea_sin_espacios.Substring(0, 8) == "function")// validamos que sea una funcion
                                    {
                                        string[] linea_texto = linea_sin_espacios.Replace("(", " ").Replace(")", " ").Split(' ');//   variable para contener las palabras
                                        string[] linea_variable_ = linea_texto[2].Split('_');//   variable para contener las palabras

                                        //  se recorren las palabras de la linea
                                        for (int palabra = 0; palabra <= linea_variable_.Length - 1; palabra++)
                                        {
                                            foreach (char caracter_palabra in linea_variable_[palabra])
                                            {
                                                tieneMinusculas = Char.IsLower(caracter_palabra);

                                                //  validamos que tenga las letras en mayuscula
                                                if (tieneMinusculas == false)
                                                {
                                                    lineas_resultado.AppendLine( linea_sin_espacios + " Linea[" + numero_linea + "]" );
                                                    bandera = true;
                                                    break;
                                                }

                                                break;

                                            }

                                            //  validamos que la bandera este indicada
                                            if (bandera == true)
                                            {
                                                bandera = false;
                                                break;
                                            }

                                        }
                                    }
                                    else if (linea_sin_espacios.Substring(0, 8) == "success:"
                                                || linea_sin_espacios.Substring(0, 8) == "results:"
                                                || linea_sin_espacios.Substring(0, 5) == "data:"

                                                )// validamos que sea una funcion con la palabra success
                                    {
                                        string[] linea_texto = linea_sin_espacios.Replace("(", " ").Replace(")", " ").Split(' ');//   variable para contener las palabras
                                        string[] linea_variable_ = linea_texto[3].Split('_');//   variable para contener las palabras

                                        //  se recorren las palabras de la linea
                                        for (int palabra = 0; palabra <= linea_variable_.Length - 1; palabra++)
                                        {
                                            foreach (char caracter_palabra in linea_variable_[palabra])
                                            {
                                                tieneMinusculas = Char.IsLower(caracter_palabra);

                                                //  validamos que tenga las letras en mayuscula
                                                if (tieneMinusculas == false)
                                                {
                                                    lineas_resultado.AppendLine(linea_sin_espacios + " Linea[" + numero_linea + "]");
                                                    bandera = true;
                                                    break;
                                                }

                                                break;

                                            }

                                            //  validamos que la bandera este indicada
                                            if (bandera == true)
                                            {
                                                bandera = false;
                                                break;
                                            }

                                        }
                                    }
                                    else if (linea_sin_espacios.Contains("('click'"))// validamos que sea una funcion con la palabra success
                                    {
                                        string[] linea_texto = linea_sin_espacios.Replace("(", " ").Replace(")", " ").Split(' ');//   variable para contener las palabras
                                        string[] linea_variable_ = linea_texto[6].Split('_');//   variable para contener las palabras

                                        //  se recorren las palabras de la linea
                                        for (int palabra = 0; palabra <= linea_variable_.Length - 1; palabra++)
                                        {
                                            foreach (char caracter_palabra in linea_variable_[palabra])
                                            {
                                                tieneMinusculas = Char.IsLower(caracter_palabra);

                                                //  validamos que tenga las letras en mayuscula
                                                if (tieneMinusculas == false)
                                                {
                                                    lineas_resultado.AppendLine(linea_sin_espacios + " Linea[" + numero_linea + "]");
                                                    bandera = true;
                                                    break;
                                                }

                                                break;

                                            }

                                            //  validamos que la bandera este indicada
                                            if (bandera == true)
                                            {
                                                bandera = false;
                                                break;
                                            }

                                        }
                                    }
                                    else
                                    {
                                        //String xx = linea_sin_espacios;                                        
                                    }
                                }

                            }


                        }
                    }
                }
                else if (nombre_archivo.Contains(".asmx"))//    validamos que sea el controlador
                {
                    // Read each line of the file into a string array. Each element
                    // of the array is one line of the file.
                    string[] lineas = System.IO.File.ReadAllLines(@"" + ruta_archivo);


                    foreach (string linea in lineas)
                    {
                        //  se quitan los espacios
                        linea_sin_espacios = linea.Trim();

                        //  se incrementa el numero de la linea
                        numero_linea++;

                        //  validamos que tenga informacion la linea
                        if (linea != "")
                        {
                            //  validamos que el texto de la liena sea mayor a un caracter
                            if (linea_sin_espacios.Length > 3)
                            {
                                //  validamos que tenga la paralabra sea var
                                if (linea_sin_espacios.Substring(0, 3) == "Cls"
                                    || linea_sin_espacios.Substring(0, 3) == "str" || linea_sin_espacios.Substring(0, 3) == "Str"
                                    || linea_sin_espacios.Substring(0, 3) == "var"
                                    )
                                {
                                    string[] linea_texto = linea_sin_espacios.Split(' ');//   variable para contener las palabras
                                    string[] linea_variable_ = linea_texto[1].Split('_');//   variable para contener las palabras

                                    //  se recorren las palabras de la linea
                                    for (int palabra = 0; palabra <= linea_variable_.Length - 1; palabra++)
                                    {
                                        foreach (char caracter_palabra in linea_variable_[palabra])
                                        {
                                            tieneMinusculas = Char.IsLower(caracter_palabra);

                                            //  validamos que tenga las letras en mayuscula
                                            if (tieneMinusculas == false)
                                            {
                                                lineas_resultado.AppendLine(linea_sin_espacios + " Linea[" + numero_linea + "]");
                                                bandera = true;
                                                break;
                                            }

                                            break;

                                        }

                                        //  validamos que la bandera este indicada
                                        if (bandera == true)
                                        {
                                            bandera = false;
                                            break;
                                        }

                                    }

                                }
                                else if (linea_sin_espacios.Contains("var") && linea_sin_espacios.Contains("using"))//  validamos que tenga la palabra var en la linea
                                {
                                    string[] linea_texto = linea_sin_espacios.Split(' ');//   variable para contener las palabras

                                    //  se recorren las palabras de la linea
                                    for (int palabra = 0; palabra <= linea_texto.Length - 1; palabra++)
                                    {

                                        if (bandera_asmx == true)//  validamos que la bandera este activa
                                        {

                                            string[] linea_variable_ = linea_texto[palabra].Split('_');//   variable para contener las palabras

                                            //  se recorren las palabras de la linea
                                            for (int contador = 0; contador <= linea_variable_.Length - 1; contador++)
                                            {
                                                foreach (char caracter_palabra in linea_variable_[contador])
                                                {
                                                    tieneMinusculas = Char.IsLower(caracter_palabra);

                                                    //  validamos que tenga las letras en mayuscula
                                                    if (tieneMinusculas == false)
                                                    {
                                                        lineas_resultado.AppendLine(linea_sin_espacios + " Linea[" + numero_linea + "]");
                                                        bandera_asmx = false;
                                                        break;
                                                    }

                                                    break;
                                                }

                                                bandera_asmx = false;
                                                break;
                                            }
                                        }

                                        if (linea_texto[palabra] == "(var")//    validamos que la palabra sea var
                                        {
                                            bandera_asmx = true;
                                        }


                                    }
                                }
                            }


                        }
                    }
                }
                else
                {
                }

                //  se revisa si no se tuvo errores en la revisión
                lineas_resultado = Mensaje_Todo_Bien(lineas_resultado);

            }
            catch (Exception ex)
            {
                lineas_resultado.AppendLine(ex.Message + "[linea" + numero_linea + "]" + "[" + linea_sin_espacios + "]");
            }

            return lineas_resultado;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre_archivo"></param>
        /// <param name="ruta_archivo"></param>
        /// <returns></returns>
        public async Task<StringBuilder> Revision_Punto4(String nombre_archivo, String ruta_archivo)
        {
            ////String resultado = "";//    variable para colocar el resultado
            bool tieneMinusculas = false;// variable para saber si una palabra esta en mayusculas
            Int32 numero_linea = 0;//   variable para obtener el numero de linea del archivo
            String linea_sin_espacios = "";//   variable para contener la linea sin espacios
            Boolean bandera = false;//  variable para indicar si ya entro a revisar el caracter de la variable
            Boolean bandera_asmx = false;//  variable para indicar si ya entro a revisar el caracter de la variable
            string[] lineas;//  variable para la captura de las lineas del texto
            String linea_anterior = "";//   variable para contener la linea anterior
            StringBuilder lineas_resultado = new StringBuilder();//    variable para colocar el resultado

            try
            {
                //  validamos que no sea una clase
                if (nombre_archivo.Contains(".js"))
                {

                    // Read each line of the file into a string array. Each element
                    // of the array is one line of the file.
                    lineas = System.IO.File.ReadAllLines(@"" + ruta_archivo);


                    foreach (string linea in lineas)
                    {
                        //  se quitan los espacios
                        linea_sin_espacios = linea.Trim();

                        //  se incrementa el numero de la linea
                        numero_linea++;

                        //  validamos que tenga informacion la linea
                        if (linea != "")
                        {
                            //  validamos que el texto de la liena sea mayor a un caracter
                            if (linea_sin_espacios.Length > 3)
                            {
                                //  validamos que tenga la paralabra sea var
                                if (linea_sin_espacios.Substring(0, 3) == "var")
                                {
                                    //resultado += linea_sin_espacios + " Linea[" + numero_linea + "]" + "<br /><br /><br />";
                                    lineas_resultado.AppendLine(linea_sin_espacios + " Linea[" + numero_linea + "]");
                                }
                                else if (linea_sin_espacios.Contains("function") && !linea_sin_espacios.Contains("--"))
                                {
                                    //resultado += linea_sin_espacios + " Linea[" + numero_linea + "]" + "<br /><br /><br />";
                                    lineas_resultado.AppendLine(linea_sin_espacios + " Linea[" + numero_linea + "]");
                                }
                            }


                        }
                    }
                }
                else if (nombre_archivo.Contains(".asmx"))//    validamos que sea el controlador
                {
                    // Read each line of the file into a string array. Each element
                    // of the array is one line of the file.
                    lineas = System.IO.File.ReadAllLines(@"" + ruta_archivo);


                    foreach (string linea in lineas)
                    {
                        //  se quitan los espacios
                        linea_sin_espacios = linea.Trim();

                        //  se incrementa el numero de la linea
                        numero_linea++;

                        //  validamos que tenga informacion la linea
                        if (linea_sin_espacios != "")
                        {
                            //  validamos que el texto de la liena sea mayor a un caracter
                            if (linea_sin_espacios.Length >= 5)
                            {
                                //  validamos que tenga la paralabra sea var
                                if (linea_sin_espacios.Substring(0, 5) == "strin" || linea_sin_espacios.Substring(0, 5) == "Strin")
                                {
                                    //resultado += linea_sin_espacios + " Linea[" + numero_linea + "]" + "\n\n\n";
                                    lineas_resultado.AppendLine(linea_sin_espacios + " Linea[" + numero_linea + "]");
                                }
                            }
                            //  validamos que el texto de la liena sea mayor a un caracter
                            else if (linea_sin_espacios.Length > 3)
                            {
                                //  validamos que tenga la paralabra sea var
                                if (linea_sin_espacios.Substring(0, 3) == "Cls"
                                    || linea_sin_espacios.Substring(0, 3) == "var" || linea_sin_espacios.Substring(0, 4) == "List"
                                    || linea_sin_espacios.Substring(0, 3) == "dou" || linea_sin_espacios.Substring(0, 4) == "Dou"
                                    || linea_sin_espacios.Substring(0, 3) == "dec" || linea_sin_espacios.Substring(0, 4) == "Dec"
                                    )
                                {

                                    //resultado += linea_sin_espacios + " Linea[" + numero_linea + "]" + "\n\n\n"; 
                                    lineas_resultado.AppendLine(linea_sin_espacios + " Linea[" + numero_linea + "]");

                                }

                                else if (linea_sin_espacios.Contains("var") && linea_sin_espacios.Contains("using"))//  validamos que tenga la palabra var en la linea
                                {
                                   //lineas_resultado.AppendLine( linea_sin_espacios + " Linea[" + numero_linea + "]" + "\n\n\n";
                                    lineas_resultado.AppendLine(linea_sin_espacios + " Linea[" + numero_linea + "]");
                                }
                            }
                        }
                    }
                }
                else
                {
                }


                //  se revisa si no se tuvo errores en la revisión
                lineas_resultado = Mensaje_Todo_Bien(lineas_resultado);
            }
            catch (Exception ex)
            {
                lineas_resultado.AppendLine( ex.Message + "[linea" + numero_linea + "]" + "[" + linea_sin_espacios + "]");
            }

            return lineas_resultado;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre_archivo"></param>
        /// <param name="ruta_archivo"></param>
        /// <returns></returns>
        public async Task<StringBuilder> Revision_Punto6(String nombre_archivo, String ruta_archivo)
        {
            ////String resultado = "";//    variable para colocar el resultado
            bool tieneMinusculas = false;// variable para saber si una palabra esta en mayusculas
            Int32 numero_linea = 0;//   variable para obtener el numero de linea del archivo
            String linea_sin_espacios = "";//   variable para contener la linea sin espacios
            Boolean bandera = false;//  variable para indicar si ya entro a revisar el caracter de la variable
            Boolean bandera_asmx = false;//  variable para indicar si ya entro a revisar el caracter de la variable
            string[] lineas;//  variable para la captura de las lineas del texto
            String linea_anterior = "";//   variable para contener la linea anterior
            StringBuilder lineas_resultado = new StringBuilder();//    variable para colocar el resultado

            try
            {
                //  validamos que no sea una clase
                if (nombre_archivo.Contains(".js"))
                {

                    // Read each line of the file into a string array. Each element
                    // of the array is one line of the file.
                    lineas = System.IO.File.ReadAllLines(@"" + ruta_archivo);


                    foreach (string linea in lineas)
                    {
                        //  se quitan los espacios
                        linea_sin_espacios = linea.Trim();

                        //  se incrementa el numero de la linea
                        numero_linea++;


                        if (numero_linea == 1)//    validamos que sea la primera linea
                        {
                            linea_anterior = linea.Trim();
                        }
                        else//  continuamos revisando el documento
                        {
                            //  validamos que tenga informacion la linea
                            if (linea != "")
                            {
                                //  validamos que el texto de la liena sea mayor a un caracter
                                if (linea_sin_espacios.Length > 3)
                                {
                                    //  validamos que tenga la paralabra sea var
                                    if (linea_sin_espacios.Substring(0, 3) == "var")
                                    {
                                        //  validamos que tenga comentario
                                        if (linea_sin_espacios.Contains("//"))
                                        {
                                            //  si tiene comentario, es correcto
                                        }
                                        else//  se notifica que no tiene comentario la variable
                                        {
                                            //  validamos que tenga comentario la linea anterior
                                            if (linea_anterior.Contains("//"))
                                            {
                                                //  si tiene comentario, es correcto
                                            }
                                            else//  se notifica que no tiene comentario la variable
                                            {
                                                lineas_resultado.AppendLine(linea_sin_espacios + " Linea[" + numero_linea + "]");
                                            }
                                        }

                                    }

                                }


                            }

                            //  se asigna el valor de la nueva linea anterior
                            linea_anterior = linea.Trim();
                        }
                    }
                }
                else if (nombre_archivo.Contains(".asmx"))//    validamos que sea el controlador
                {
                    // Read each line of the file into a string array. Each element
                    // of the array is one line of the file.
                    lineas = System.IO.File.ReadAllLines(@"" + ruta_archivo);


                    foreach (string linea in lineas)
                    {
                        //  se incrementa el numero de la linea
                        numero_linea++;


                        if (numero_linea == 1)//    validamos que sea la primera linea
                        {
                            linea_anterior = linea.Trim();
                        }
                        else//  continuamos revisando el documento
                        {
                            //  se quitan los espacios
                            linea_sin_espacios = linea.Trim();


                            //  validamos que tenga informacion la linea
                            if (linea != "")
                            {
                                //  validamos que el texto de la liena sea mayor a un caracter
                                if (linea_sin_espacios.Length >= 5)
                                {
                                    //  validamos que tenga la paralabra sea var
                                    if (linea_sin_espacios.Substring(0, 5) == "strin" || linea_sin_espacios.Substring(0, 5) == "Strin")
                                    {
                                        //  validamos que tenga comentario
                                        if (linea_sin_espacios.Contains("//"))
                                        {
                                            //  si tiene comentario, es correcto
                                        }
                                        else//  se revisa si la linea anterior tiene comentario
                                        {
                                            //  validamos que tenga comentario la linea anterior
                                            if (linea_anterior.Contains("//"))
                                            {
                                                //  si tiene comentario, es correcto
                                            }
                                            else//  se notifica que no tiene comentario la variable
                                            {
                                                lineas_resultado.AppendLine(linea_sin_espacios + " Linea[" + numero_linea + "]");
                                            }
                                        }
                                    }
                                    //  validamos que sea catch
                                    else if (linea_sin_espacios.Contains("catch"))
                                    {
                                        //  validamos que tenga comentario
                                        if (linea_sin_espacios.Contains("//"))
                                        {
                                            //  si tiene comentario, es correcto
                                        }
                                        else//  se notifica que no tiene comentario la variable
                                        {
                                            //  validamos que tenga comentario la linea anterior
                                            if (linea_anterior.Contains("//"))
                                            {
                                                //  si tiene comentario, es correcto
                                            }
                                            else//  se notifica que no tiene comentario la variable
                                            {
                                                lineas_resultado.AppendLine(linea_sin_espacios + " Linea[" + numero_linea + "]");
                                            }
                                        }
                                    }
                                }
                                //  validamos que el texto de la liena sea mayor a un caracter
                                else if (linea_sin_espacios.Length > 3)
                                {
                                    //  validamos que tenga la paralabra sea var
                                    if (linea_sin_espacios.Substring(0, 3) == "Cls"
                                            || linea_sin_espacios.Substring(0, 3) == "var" || linea_sin_espacios.Substring(0, 4) == "List"
                                            || linea_sin_espacios.Substring(0, 3) == "dou" || linea_sin_espacios.Substring(0, 4) == "Dou"
                                            || linea_sin_espacios.Substring(0, 3) == "dec" || linea_sin_espacios.Substring(0, 4) == "Dec"
                                         )
                                    {

                                        //  validamos que tenga comentario
                                        if (linea_sin_espacios.Contains("//"))
                                        {
                                            //  si tiene comentario, es correcto
                                        }
                                        else//  se revisa si la linea anterior tiene comentario
                                        {
                                            //  validamos que tenga comentario la linea anterior
                                            if (linea_anterior.Contains("//"))
                                            {
                                                //  si tiene comentario, es correcto
                                            }
                                            else//  se notifica que no tiene comentario la variable
                                            {
                                                lineas_resultado.AppendLine(linea_sin_espacios + " Linea[" + numero_linea + "]");
                                            }
                                        }

                                    }
                                    else if (linea_sin_espacios.Contains("var") && linea_sin_espacios.Contains("using"))//  validamos que tenga la palabra var en la linea
                                    {
                                        //  validamos que tenga comentario
                                        if (linea_sin_espacios.Contains("//"))
                                        {
                                            //  si tiene comentario, es correcto
                                        }
                                        else//  se notifica que no tiene comentario la variable
                                        {
                                            //  validamos que tenga comentario la linea anterior
                                            if (linea_anterior.Contains("//"))
                                            {
                                                //  si tiene comentario, es correcto
                                            }
                                            else//  se notifica que no tiene comentario la variable
                                            {
                                                lineas_resultado.AppendLine(linea_sin_espacios + " Linea[" + numero_linea + "]");
                                            }
                                        }
                                    }
                                    else if (linea_sin_espacios.Contains("catch"))//  validamos que tenga la palabra var en la linea
                                    {
                                        //  validamos que tenga comentario
                                        if (linea_sin_espacios.Contains("//"))
                                        {
                                            //  si tiene comentario, es correcto
                                        }
                                        else//  se notifica que no tiene comentario la variable
                                        {
                                            //  validamos que tenga comentario la linea anterior
                                            if (linea_anterior.Contains("//"))
                                            {
                                                //  si tiene comentario, es correcto
                                            }
                                            else//  se notifica que no tiene comentario la variable
                                            {
                                                lineas_resultado.AppendLine(linea_sin_espacios + " Linea[" + numero_linea + "]");
                                            }
                                        }
                                    }


                                }
                            }

                            //  se asigna el valor de la nueva linea anterior
                            linea_anterior = linea.Trim();

                        }
                    }
                }
                else
                {
                }

                //  se revisa si no se tuvo errores en la revisión
                lineas_resultado = Mensaje_Todo_Bien(lineas_resultado);
            }
            catch (Exception ex)
            {
                lineas_resultado.AppendLine( ex.Message + "[linea" + numero_linea + "]" + "[" + linea_sin_espacios + "]");
            }

            return lineas_resultado;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre_archivo"></param>
        /// <param name="ruta_archivo"></param>
        /// <returns></returns>
        public async Task<StringBuilder> Revision_Punto7(String nombre_archivo, String ruta_archivo)
        {
            ////String resultado = "";//    variable para colocar el resultado
            bool tieneMayusculas = false;// variable para saber si una palabra esta en mayusculas
            Int32 numero_linea = 0;//   variable para obtener el numero de linea del archivo
            String linea_sin_espacios = "";//   variable para contener la linea sin espacios
            String linea_sin_comentarios = "";//   variable para contener la linea sin espacios

            StringBuilder lineas_resultado = new StringBuilder();//    variable para colocar el resultado

            try
            {
                //  validamos que no sea una clase
                if (nombre_archivo.Contains("cs") && !nombre_archivo.Contains("asmx"))
                {

                    // Read each line of the file into a string array. Each element
                    // of the array is one line of the file.
                    string[] lineas = System.IO.File.ReadAllLines(@"" + ruta_archivo);


                    foreach (string linea in lineas)
                    {
                        //  se quitan los espacios
                        linea_sin_espacios = linea.Trim();

                        //  se incrementa el numero de la linea
                        numero_linea++;

                        //  validamos que no sea linea de using ni de class
                        if (linea.Contains("using") || linea.Contains("class") || linea.Contains("namespace"))
                        {
                            //  no realiza ninguna accion

                        }
                        else//  si lee la linea que no son using, class y namespace
                        {
                            //  validamos que tenga informacion la linea
                            if (linea != "")
                            {

                                //  validamos que el texto de la liena sea mayor a un caracter
                                if (linea_sin_espacios.Length > 1)
                                {

                                    //  validamos que no sea comentario
                                    if (linea_sin_espacios.Substring(0, 2) == "//")
                                    {
                                        //  no realiza ninguna accion
                                    }
                                    else//  si no es comentario procede a revisar
                                    {
                                        linea_sin_comentarios = "";

                                        //  validamos que tenga la palabra fecha
                                        if (linea_sin_espacios.Contains("fecha") || linea_sin_espacios.Contains("Fecha"))
                                        {
                                            //  validamos que tenga comentario
                                            if (linea_sin_espacios.Contains("//"))
                                            {
                                                //  se quitan los comentarios
                                                foreach (char caracter in linea_sin_espacios)
                                                {
                                                    if (caracter != '/')//  validamos que no sea inicio de comentario
                                                    {
                                                        linea_sin_comentarios += caracter;

                                                    }
                                                    else//  si es comentario, se cierra el ciclo
                                                    {
                                                        break;
                                                    }
                                                }
                                            }
                                            else//  si no tiene comentario se agrega la liena normal
                                            {
                                                linea_sin_comentarios = linea_sin_espacios;
                                            }


                                            //validamos que no sea un filtro
                                            if (linea_sin_comentarios.Contains("filtro") || linea_sin_comentarios.Contains("Filtro"))
                                            {
                                                //  es correcto, no se realiza ninguna accion
                                            }
                                            else
                                            {
                                                //  validamos que tenga el tipo de dato datetime
                                                if (linea_sin_comentarios.Contains("datetime") || linea_sin_comentarios.Contains("DateTime"))
                                                {
                                                    //  es correcto, no se realiza ninguna accion

                                                }
                                                else//  se indica que no tiene el tipo de variable correcta
                                                {
                                                    lineas_resultado.AppendLine(linea_sin_espacios + " Linea[" + numero_linea + "]");
                                                }
                                            }
                                        }


                                    }
                                }
                            }

                        }
                    }
                }
                else
                {
                }

                //  se revisa si no se tuvo errores en la revisión
                lineas_resultado = Mensaje_Todo_Bien(lineas_resultado);
            }
            catch (Exception ex)
            {
                lineas_resultado.AppendLine( ex.Message + "[linea" + numero_linea + "]" + "[" + linea_sin_espacios + "]");
            }

            return lineas_resultado;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre_archivo"></param>
        /// <param name="ruta_archivo"></param>
        /// <returns></returns>
        public async Task<StringBuilder> Revision_Punto8(String nombre_archivo, String ruta_archivo)
        {
            ////String resultado = "";//    variable para colocar el resultado
            bool tieneMayusculas = false;// variable para saber si una palabra esta en mayusculas
            Int32 numero_linea = 0;//   variable para obtener el numero de linea del archivo
            String linea_sin_espacios = "";//   variable para contener la linea sin espacios
            String linea_sin_comentarios = "";//   variable para contener la linea sin espacios
            StringBuilder lineas_resultado = new StringBuilder();//    variable para colocar el resultado

            try
            {
                //  validamos que no sea una clase
                if (nombre_archivo.Contains("cs") && !nombre_archivo.Contains("asmx"))
                {

                    // Read each line of the file into a string array. Each element
                    // of the array is one line of the file.
                    string[] lineas = System.IO.File.ReadAllLines(@"" + ruta_archivo);


                    foreach (string linea in lineas)
                    {
                        //  se quitan los espacios
                        linea_sin_espacios = linea.Trim();

                        //  se incrementa el numero de la linea
                        numero_linea++;

                        //  validamos que no sea linea de using ni de class
                        if (linea.Contains("using") || linea.Contains("class") || linea.Contains("namespace"))
                        {
                            //  no realiza ninguna accion

                        }
                        else//  si lee la linea que no son using, class y namespace
                        {
                            //  validamos que tenga informacion la linea
                            if (linea != "")
                            {

                                //  validamos que el texto de la liena sea mayor a un caracter
                                if (linea_sin_espacios.Length > 1)
                                {

                                    //  validamos que no sea comentario
                                    if (linea_sin_espacios.Substring(0, 2) == "//")
                                    {
                                        //  no realiza ninguna accion
                                    }
                                    else//  si no es comentario procede a revisar
                                    {
                                        linea_sin_comentarios = "";

                                        //  validamos que tenga comentario
                                        if (linea_sin_espacios.Contains("//"))
                                        {
                                            //  se quitan los comentarios
                                            foreach (char caracter in linea_sin_espacios)
                                            {
                                                if (caracter != '/')//  validamos que no sea inicio de comentario
                                                {
                                                    linea_sin_comentarios += caracter;

                                                }
                                                else//  si es comentario, se cierra el ciclo
                                                {
                                                    break;
                                                }
                                            }
                                        }
                                        else//  si no tiene comentario se agrega la liena normal
                                        {
                                            linea_sin_comentarios = linea_sin_espacios;
                                        }


                                        //  validamos que tenga la palabra monto, saldo, dinero
                                        if (linea_sin_comentarios.Contains("Monto") || linea_sin_comentarios.Contains("monto")
                                            || linea_sin_comentarios.Contains("Saldo") || linea_sin_comentarios.Contains("saldo")
                                            || linea_sin_comentarios.Contains("Dinero") || linea_sin_comentarios.Contains("dinero")
                                            )
                                        {
                                            //  validamos que tenga el tipo de dato datetime
                                            if (linea_sin_comentarios.Contains("Decimal") || linea_sin_comentarios.Contains("decimal"))
                                            {
                                                //  es correcto, no se realiza ninguna accion

                                            }
                                            else//  se indica que no tiene el tipo de variable correcta
                                            {
                                                lineas_resultado.AppendLine(linea_sin_espacios + " Linea[" + numero_linea + "]");
                                            }
                                        }



                                    }
                                }
                            }

                        }
                    }
                }
                else
                {
                }

                //  se revisa si no se tuvo errores en la revisión
                lineas_resultado = Mensaje_Todo_Bien(lineas_resultado);
            }
            catch (Exception ex)
            {
                lineas_resultado.AppendLine( ex.Message + "[linea" + numero_linea + "]" + "[" + linea_sin_espacios + "]");
            }

            return lineas_resultado;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre_archivo"></param>
        /// <param name="ruta_archivo"></param>
        /// <returns></returns>
        public async Task<StringBuilder> Revision_Punto9(String nombre_archivo, String ruta_archivo)
        {
            ////String resultado = "";//    variable para colocar el resultado
            bool tieneMayusculas = false;// variable para saber si una palabra esta en mayusculas
            Int32 numero_linea = 0;//   variable para obtener el numero de linea del archivo
            String linea_sin_espacios = "";//   variable para contener la linea sin espacios

            StringBuilder lineas_resultado = new StringBuilder();//    variable para colocar el resultado

            try
            {


                // Read each line of the file into a string array. Each element
                // of the array is one line of the file.
                string[] lineas = System.IO.File.ReadAllLines(@"" + ruta_archivo);


                foreach (string linea in lineas)
                {
                    //  se quitan los espacios
                    linea_sin_espacios = linea.Trim();

                    //  se incrementa el numero de la linea
                    numero_linea++;


                    //  validamos que tenga informacion la linea
                    if (linea != "")
                    {
                        //  validamos que el texto de la liena sea mayor a un caracter
                        if (linea_sin_espacios.Length > 1)
                        {
                            //  validamos que tenga la palabra monto, saldo, dinero
                            if (linea_sin_espacios.Contains("cont_"))
                            {

                               lineas_resultado.AppendLine( linea_sin_espacios + " Linea[" + numero_linea + "]" );

                            }
                            //else if (linea_sin_comentarios.Contains("Cont_"))// validamos que este bien escrita para revisar las otras letras sean mayusculas
                            //{

                            //   lineas_resultado.AppendLine( linea_sin_espacios + " Linea[" + numero_linea + "]" );

                            //}
                                                    }

                    }
                }



                //  se revisa si no se tuvo errores en la revisión
                lineas_resultado = Mensaje_Todo_Bien(lineas_resultado);
            }
            catch (Exception ex)
            {
               lineas_resultado.AppendLine( ex.Message+ "[linea" + numero_linea + "]" + "[" + linea_sin_espacios + "]");
            }

            return lineas_resultado;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre_archivo"></param>
        /// <param name="ruta_archivo"></param>
        /// <returns></returns>
        public async Task<StringBuilder> Revision_Punto10(String nombre_archivo, String ruta_archivo)
        {
            //String resultado = "";//    variable para colocar el resultado
            Int32 numero_linea = 0;//   variable para obtener el numero de linea del archivo
            String linea_sin_espacios = "";//   variable para contener la linea sin espacios
            String linea_anterior = "";//   variable para contener la linea anterior

            StringBuilder lineas_resultado = new StringBuilder();//    variable para colocar el resultado

            try
            {
                //  validamos que no sea una clase
                if (nombre_archivo.Contains(".js"))
                {

                    // Read each line of the file into a string array. Each element
                    // of the array is one line of the file.
                    string[] lineas = System.IO.File.ReadAllLines(@"" + ruta_archivo);


                    foreach (string linea in lineas)
                    {

                        //  se incrementa el numero de la linea
                        numero_linea++;


                        if (numero_linea == 1)//    validamos que sea la primera linea
                        {
                            linea_anterior = linea.Trim();
                        }
                        else//  continuamos revisando el documento
                        {

                            //  se quitan los espacios
                            linea_sin_espacios = linea.Trim();

                            //  validamos que tenga informacion la linea
                            if (linea != "")
                            {

                                if (linea_sin_espacios.Contains("function") && !linea_sin_espacios.Contains("--"))
                                {
                                    //  se valida que sea una funcion
                                    if (linea_sin_espacios.Substring(0, 8) == "function")// validamos que sea una funcion
                                    {
                                        lineas_resultado.AppendLine(Tiene_Comentario_La_Funcion(linea_anterior, linea_sin_espacios, numero_linea));
                                    }
                                    //  validamos que sea success, results, data
                                    else if (linea_sin_espacios.Substring(0, 8) == "success:"
                                                || linea_sin_espacios.Substring(0, 8) == "results:"
                                                || linea_sin_espacios.Substring(0, 5) == "data:"
                                                || linea_sin_espacios.Substring(0, 7) == "finish:"
                                                || linea_sin_espacios.Substring(0, 15) == "processResults:"
                                                || linea_sin_espacios.Substring(0, 10) == "formatter:"

                                                )// validamos que sea una funcion con la palabra success
                                    {
                                       lineas_resultado.AppendLine( Tiene_Comentario_La_Funcion(linea_anterior, linea_sin_espacios, numero_linea));
                                    }
                                    //  validamos que sea callback
                                    else if (linea_sin_espacios.Substring(0, 9) == "callback:")
                                    {
                                       lineas_resultado.AppendLine( Tiene_Comentario_La_Funcion(linea_anterior, linea_sin_espacios, numero_linea));
                                    }
                                    //  validamos que sea click
                                    else if (linea_sin_espacios.Contains("('click'"))// validamos que sea una funcion con la palabra success
                                    {
                                       lineas_resultado.AppendLine( Tiene_Comentario_La_Funcion(linea_anterior, linea_sin_espacios, numero_linea));
                                    }
                                    else
                                    {
                                        //String xx = linea_sin_espacios;                                        
                                    }
                                }
                                //  validamos que sea callback

                            }

                            //  se registra la linea como linea anterior
                            linea_anterior = linea.Trim();

                        }
                    }
                }
                else
                {
                }

                //  se revisa si no se tuvo errores en la revisión
                lineas_resultado = Mensaje_Todo_Bien(lineas_resultado);
            }
            catch (Exception ex)
            {
               lineas_resultado.AppendLine( ex.Message+ "[linea" + numero_linea + "]" + "[" + linea_sin_espacios + "]");
            }

            return lineas_resultado;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre_archivo"></param>
        /// <param name="ruta_archivo"></param>
        /// <returns></returns>
        public async Task<StringBuilder> Revision_Punto11(String nombre_archivo, String ruta_archivo)
        {
            //String resultado = "";//    variable para colocar el resultado
            Int32 numero_linea = 0;//   variable para obtener el numero de linea del archivo
            String linea_sin_espacios = "";//   variable para contener la linea sin espacios
            Boolean es_encabezado = false;//   variable para indicar cuando se esta leyendo un encabezado
            String texto_encabezado = "";// variable para agregar el texto de un encabezado
            String nombre_variables = "";//   variable con la que se estara obteniendo el nombre de las variables
            String nombre_funciones = "";//   variable con la que se estara obteniendo el nombre de la funcion
            Boolean bandera_parametros = false;//   variable para indicar cuando se comienza a capturar el nombre de las variables

            StringBuilder lineas_resultado = new StringBuilder();//    variable para colocar el resultado

            try
            {
                //  validamos que no sea una clase
                if (nombre_archivo.Contains(".js"))
                {

                    // Read each line of the file into a string array. Each element
                    // of the array is one line of the file.
                    string[] lineas = System.IO.File.ReadAllLines(@"" + ruta_archivo);


                    foreach (string linea in lineas)
                    {

                        //  se incrementa el numero de la linea
                        numero_linea++;

                        //if (numero_linea == 50)
                        //{
                        //    string x = "";
                        //}

                        //  se quitan los espacios
                        linea_sin_espacios = linea.Trim();

                        //  validamos que tenga informacion la linea
                        if (linea_sin_espacios != "")
                        {
                            //  validamos la longitud de la linea
                            if (linea_sin_espacios.Length > 8)
                            {

                                if (es_encabezado == true)// validamos que la bandera este activa
                                {
                                    texto_encabezado += linea_sin_espacios + "\n";

                                    if (linea_sin_espacios.Contains("=") && linea_sin_espacios.Contains("*/"))// validamos que sea fin de comentario de funcion
                                    {
                                        es_encabezado = false;
                                    }
                                }
                                // validamos que sea inicio de comentario de funcion
                                else if (linea_sin_espacios.Contains("/*") && linea_sin_espacios.Contains("="))
                                {
                                    //  se indica que es encabezado
                                    es_encabezado = true;

                                    //  se limpia la variable
                                    texto_encabezado = "";

                                    //  se asigna el texto del comentario
                                    texto_encabezado += linea_sin_espacios + "\n";
                                }
                                // validamos que sea una funcion
                                else if (linea_sin_espacios.Substring(0, 8) == "function" && !linea_sin_espacios.Contains("--"))
                                {
                                    lineas_resultado.AppendLine(Revisar_Parametros_En_Encabezado(linea_sin_espacios, "function", texto_encabezado, numero_linea).ToString());

                                }
                                // validamos que sea una funcion con la palabra success
                                else if ((linea_sin_espacios.Substring(0, 8) == "success:")
                                            && !linea_sin_espacios.Contains("--")
                                        )
                                {
                                    lineas_resultado.AppendLine(Revisar_Parametros_En_Encabezado(linea_sin_espacios, "success", texto_encabezado, numero_linea).ToString());

                                }
                                else if ((linea_sin_espacios.Substring(0, 8) == "results:")
                                          && !linea_sin_espacios.Contains("--")
                                      )
                                {
                                    lineas_resultado.AppendLine(Revisar_Parametros_En_Encabezado(linea_sin_espacios, "results", texto_encabezado, numero_linea).ToString());

                                }
                                else if ((linea_sin_espacios.Substring(0, 5) == "data:")
                                          && !linea_sin_espacios.Contains("--") && linea_sin_espacios.Substring(linea_sin_espacios.Length - 1, 1) != ","
                                      )
                                {
                                    lineas_resultado.AppendLine(Revisar_Parametros_En_Encabezado(linea_sin_espacios, "data", texto_encabezado, numero_linea).ToString());

                                }
                                else if ((linea_sin_espacios.Substring(0, 9) == "callback:")
                                         && !linea_sin_espacios.Contains("--")
                                     )
                                {
                                    lineas_resultado.AppendLine(Revisar_Parametros_En_Encabezado(linea_sin_espacios, "callback", texto_encabezado, numero_linea).ToString());

                                }
                                else if ((linea_sin_espacios.Substring(0, 7) == "finish:")
                                          && !linea_sin_espacios.Contains("--")
                                      )
                                {
                                    lineas_resultado.AppendLine(Revisar_Parametros_En_Encabezado(linea_sin_espacios, "finish", texto_encabezado, numero_linea).ToString());

                                }
                                //  validamos la longitud, que sea mayor a 15
                                else if (linea_sin_espacios.Length >= 15)
                                {
                                    //  validamos que sea processResults
                                    if ((linea_sin_espacios.Substring(0, 15) == "processResults:")
                                         && !linea_sin_espacios.Contains("--")
                                     )
                                    {
                                        lineas_resultado.AppendLine(Revisar_Parametros_En_Encabezado(linea_sin_espacios, "processResults", texto_encabezado, numero_linea).ToString());

                                    }
                                }
                                //  validamos la longitud, que sea mayor a 10
                                else if (linea_sin_espacios.Length >= 10)
                                {
                                    //  validamos que sea formatter
                                    if ((linea_sin_espacios.Substring(0, 10) == "formatter:")
                                            && !linea_sin_espacios.Contains("--")
                                        )
                                    {
                                        lineas_resultado.AppendLine(Revisar_Parametros_En_Encabezado(linea_sin_espacios, "formatter", texto_encabezado, numero_linea).ToString());

                                    }
                                }
                                //  validamos que sea evento click
                                else if (linea_sin_espacios.Contains("('click'") && !linea_sin_espacios.Contains("--"))// validamos que sea una funcion con la palabra success
                                {
                                    lineas_resultado.AppendLine(Revisar_Parametros_Click_En_Encabezado(linea_sin_espacios, "click", texto_encabezado, numero_linea).ToString());

                                }
                                else
                                {
                                    //String xx = "";
                                }
                            }

                        }
                    }
                }
                else
                {
                }

                //  se revisa si no se tuvo errores en la revisión
                lineas_resultado = Mensaje_Todo_Bien(lineas_resultado);
            }
            catch (Exception ex)
            {
               lineas_resultado.AppendLine( ex.Message+ "[linea" + numero_linea + "]" + "[" + linea_sin_espacios + "]");
            }

            return lineas_resultado;
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="nombre_archivo"></param>
       /// <param name="ruta_archivo"></param>
       /// <returns></returns>
        public async Task<StringBuilder> Revision_Punto12(String nombre_archivo, String ruta_archivo)
        {
            //String resultado = "";//    variable para colocar el resultado
            Int32 numero_linea = 0;//   variable para obtener el numero de linea del archivo
            String linea_sin_espacios = "";//   variable para contener la linea sin espacios
            String linea_anterior = "";//   variable para contener la linea anterior

            StringBuilder lineas_resultado = new StringBuilder();//    variable para colocar el resultado

            try
            {
                //  validamos que no sea una clase
                if (nombre_archivo.Contains(".js") || nombre_archivo.Contains(".asmx"))
                {

                    // Read each line of the file into a string array. Each element
                    // of the array is one line of the file.
                    string[] lineas = System.IO.File.ReadAllLines(@"" + ruta_archivo);


                    foreach (string linea in lineas)
                    {

                        //  se incrementa el numero de la linea
                        numero_linea++;

                        //  se quitan los espacios
                        linea_sin_espacios = linea.Trim();

                        if (numero_linea == 1)//    validamos que sea la primera linea
                        {
                            linea_anterior = linea.Trim();
                        }
                        else//  continuamos revisando el documento
                        {
                            //  se quitan los espacios
                            linea_sin_espacios = linea.Trim();

                            //  validamos que tenga informacion la linea
                            if (linea_sin_espacios != "")
                            {


                                //  validamos la longitud
                                if (linea_sin_espacios.Length >= 5)
                                {
                                    if (!linea_sin_espacios.Contains("[//")
                                                 && !linea_sin_espacios.Contains("try")
                                                 && !linea_sin_espacios.Contains("});")
                                                 && !linea_sin_espacios.Contains("},")
                                                 && !linea_sin_espacios.Contains("};")
                                                 && !linea_sin_espacios.Contains("}]")
                                                 && !linea_sin_espacios.Contains("formatter")

                                                 )
                                    {
                                        //  validamos que contenga las palabras claves
                                        if (linea_sin_espacios.Substring(0, 5) == ("while"))
                                        {
                                           lineas_resultado.AppendLine( Tiene_Comentario_El_Ciclo_(linea_anterior, linea_sin_espacios, numero_linea));
                                        }
                                    }
                                }
                                //  validamos la longitud
                                else if (linea_sin_espacios.Length > 2)
                                {
                                    if (!linea_sin_espacios.Contains("[//")
                                                  && !linea_sin_espacios.Contains("try")
                                                  && !linea_sin_espacios.Contains("});")
                                                  && !linea_sin_espacios.Contains("},")
                                                  && !linea_sin_espacios.Contains("};")
                                                  && !linea_sin_espacios.Contains("}]")
                                                  && !linea_sin_espacios.Contains("formatter")

                                                  )
                                    {
                                        //  validamos que sea for
                                        if (linea_sin_espacios.Substring(0, 3) == ("for"))
                                        {
                                           lineas_resultado.AppendLine( Tiene_Comentario_El_Ciclo_(linea_anterior, linea_sin_espacios, numero_linea));
                                        }
                                        //  validamos que contenga las palabras claves
                                        else if (linea_sin_espacios.Substring(0, 2) == ("do"))
                                        {
                                           lineas_resultado.AppendLine( Tiene_Comentario_El_Ciclo_(linea_anterior, linea_sin_espacios, numero_linea));
                                        }
                                    }
                                }
                            }
                        }

                        //  se registra la linea como linea anterior
                        linea_anterior = linea.Trim();

                    }
                }
                else
                {
                }

                //  se revisa si no se tuvo errores en la revisión
                lineas_resultado = Mensaje_Todo_Bien(lineas_resultado);
            }
            catch (Exception ex)
            {
               lineas_resultado.AppendLine( ex.Message+ "[linea" + numero_linea + "]" + "[" + linea_sin_espacios + "]");
            }

            return lineas_resultado;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre_archivo"></param>
        /// <param name="ruta_archivo"></param>
        /// <returns></returns>
        public async Task<StringBuilder> Revision_Punto13(String nombre_archivo, String ruta_archivo)
        {
            //String resultado = "";//    variable para colocar el resultado
            Int32 numero_linea = 0;//   variable para obtener el numero de linea del archivo
            String linea_sin_espacios = "";//   variable para contener la linea sin espacios
            String linea_anterior = "";//   variable para contener la linea anterior

            StringBuilder lineas_resultado = new StringBuilder();//    variable para colocar el resultado

            try
            {
                //  validamos que no sea una clase
                if (nombre_archivo.Contains(".js") || nombre_archivo.Contains(".asmx"))
                {

                    // Read each line of the file into a string array. Each element
                    // of the array is one line of the file.
                    string[] lineas = System.IO.File.ReadAllLines(@"" + ruta_archivo);


                    foreach (string linea in lineas)
                    {

                        //  se incrementa el numero de la linea
                        numero_linea++;

                        //  se quitan los espacios
                        linea_sin_espacios = linea.Trim();

                        if (numero_linea == 1)//    validamos que sea la primera linea
                        {
                            linea_anterior = linea.Trim();
                        }
                        else//  continuamos revisando el documento
                        {
                            //  se quitan los espacios
                            linea_sin_espacios = linea.Trim();

                            //  validamos que tenga informacion la linea
                            if (linea_sin_espacios != "")
                            {
                                //  validamos la longitud
                                if (linea_sin_espacios.Length >= 4)
                                {
                                    //  validamos las palabras claves
                                    if (!linea_sin_espacios.Contains("[//")
                                                && !linea_sin_espacios.Contains("try")
                                                && !linea_sin_espacios.Contains("});")
                                                && !linea_sin_espacios.Contains("},")
                                                && !linea_sin_espacios.Contains("};")
                                                && !linea_sin_espacios.Contains("}]")
                                                && !linea_sin_espacios.Contains("],")
                                                )
                                    {
                                        //  validamos que contenga las palabras claves
                                        if (linea_sin_espacios.Substring(0, 4) == ("else"))
                                        {
                                           lineas_resultado.AppendLine( Tiene_Comentario_El_Ciclo_(linea_anterior, linea_sin_espacios, numero_linea));
                                        }
                                        else if (linea_sin_espacios.Substring(0, 4) == ("case"))
                                        {
                                           lineas_resultado.AppendLine( Tiene_Comentario_El_Ciclo_(linea_anterior, linea_sin_espacios, numero_linea));
                                        }

                                    }
                                }
                                //  validamos la longitud
                                else if (linea_sin_espacios.Length >= 2)
                                {
                                    //  validamos las palabras claves
                                    if (!linea_sin_espacios.Contains("[//")
                                                && !linea_sin_espacios.Contains("try")
                                                && !linea_sin_espacios.Contains("});")
                                                && !linea_sin_espacios.Contains("},")
                                                && !linea_sin_espacios.Contains("};")
                                                && !linea_sin_espacios.Contains("}]")
                                                && !linea_sin_espacios.Contains("],")
                                                )
                                    {
                                        //  validamos la palabra if
                                        if (linea_sin_espacios.Substring(0, 2) == ("if"))
                                        {
                                           lineas_resultado.AppendLine( Tiene_Comentario_El_Ciclo_(linea_anterior, linea_sin_espacios, numero_linea));
                                        }

                                    }
                                }
                            }
                        }

                        //  se registra la linea como linea anterior
                        linea_anterior = linea.Trim();

                    }
                }
                else
                {
                }

                //  se revisa si no se tuvo errores en la revisión
                lineas_resultado = Mensaje_Todo_Bien(lineas_resultado);
            }
            catch (Exception ex)
            {
               lineas_resultado.AppendLine( ex.Message+ "[linea" + numero_linea + "]" + "[" + linea_sin_espacios + "]");
            }

            return lineas_resultado;
        }


        #endregion



        #region Funciones
        /// <summary>
        /// 
        /// </summary>
        /// <param name="linea_anterior"></param>
        /// <param name="linea_sin_espacios"></param>
        /// <param name="numero_linea"></param>
        /// <returns></returns>
        public string Tiene_Comentario_La_Funcion(string linea_anterior,string linea_sin_espacios,int numero_linea)
        {
            String resultado = "";//    variable que indica el mensaje de la operacion realizada
            try
            {
                //    validamos que tenga comentarios
                if (linea_anterior.Contains("========*/"))
                {
                    //  si tiene comentarios la funcion, no se realiza ninguna operacion
                }
                else//  se indica qie funcion no tiene comentario
                {
                    resultado = linea_sin_espacios + " Linea[" + numero_linea + "]";
                }
            }
            catch (Exception ex)
            { 
            }

            return resultado;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="linea_sin_espacios"></param>
        /// <param name="Texto_Funcion"></param>
        /// <param name="texto_encabezado"></param>
        /// <returns></returns>
        public StringBuilder Revisar_Parametros_En_Encabezado(String linea_sin_espacios, String Texto_Funcion, String texto_encabezado, Int32 numero_linea)
        {
            //String resultado = "";//    variable para colocar el resultado
            Boolean es_encabezado = false;//   variable para indicar cuando se esta leyendo un encabezado
            String nombre_variables = "";//   variable con la que se estara obteniendo el nombre de las variables
            String nombre_funciones = "";//   variable con la que se estara obteniendo el nombre de la funcion
            Boolean bandera_parametros = false;//   variable para indicar cuando se comienza a capturar el nombre de las variables

            StringBuilder lineas_resultado = new StringBuilder();//    variable para colocar el resultado

            try
            {

                nombre_funciones = "";
                string[] linea_nombre_funcion = linea_sin_espacios.Split(' ');//   variable para contener las palabras
 
                //  se recorre el arreglo de la funcion
                foreach (string registro in linea_nombre_funcion)
                {
                    //  validamos que este activa la bandera
                    if (bandera_parametros == true)
                    {
                        string[] linea_nombre_funcion_segmentada = registro.Split('(');//   variable para contener las palabras

                        nombre_funciones = linea_nombre_funcion_segmentada[0];

                        bandera_parametros = false;
                        break;
                    }
                    //  validamos que contenga el nombre de function
                    else if (registro.Contains(Texto_Funcion))
                    {
                        bandera_parametros = true;
                    }
                }

                //  validamos que el encabezao y la funcion sean igual
                if (texto_encabezado.Contains(nombre_funciones))
                {
                    //  se estaran obteniendo los parametros de la funcion
                    string[] linea_texto = linea_sin_espacios.Split('(');//   variable para contener las palabras
                    nombre_variables = "";

                    //  se recorre el arreglo de la funcion
                    foreach (string registro in linea_texto)
                    {

                        //  validamos que este marcada la bandera 
                        if (registro.Contains(")"))
                        {
                            nombre_variables = "";
                            nombre_variables = registro.Replace(')', ' ').Replace('{', ' ');


                            string[] linea_texto_funcion = nombre_variables.Split(',');//   variable para contener las palabras

                            //  validamos que sea mayor a 1
                            foreach (string registro_variables in linea_texto_funcion)
                            {
                                String variable_sin_caracteres = registro_variables;
                                variable_sin_caracteres = variable_sin_caracteres.Replace('}', ' ');

                                variable_sin_caracteres = variable_sin_caracteres.Trim();

                                //  validamos que se encuentre dentro del encabezado
                                if (texto_encabezado.Trim().Contains(variable_sin_caracteres.Trim() + ":"))
                                {

                                }
                                else // se indica que no esta registrado en el encabezado
                                {
                                    lineas_resultado.AppendLine("El parámetro " + registro_variables + "no esta declarado" + "\n" + texto_encabezado + linea_sin_espacios + "Linea[" + numero_linea + "]");
                                }

                            }

                        }
                        else
                        {
                        }
                    }

                }
                else
                {
                    lineas_resultado.AppendLine("No tiene encabezado");
                    lineas_resultado.AppendLine(texto_encabezado);
                    lineas_resultado.AppendLine("Linea[" + numero_linea + "]");
                }
            }
            catch (Exception e)
            {
                lineas_resultado.AppendLine( e.Message);
            }

            return lineas_resultado;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="linea_sin_espacios"></param>
        /// <param name="Texto_Funcion"></param>
        /// <param name="texto_encabezado"></param>
        /// <returns></returns>
        public StringBuilder Revisar_Parametros_Click_En_Encabezado(String linea_sin_espacios, String Texto_Funcion, String texto_encabezado, Int32 numero_linea)
        {
            //String resultado = "";//    variable para colocar el resultado
            Boolean es_encabezado = false;//   variable para indicar cuando se esta leyendo un encabezado
            String nombre_variables = "";//   variable con la que se estara obteniendo el nombre de las variables
            String nombre_funciones = "";//   variable con la que se estara obteniendo el nombre de la funcion
            Boolean bandera_parametros = false;//   variable para indicar cuando se comienza a capturar el nombre de las variables

            StringBuilder lineas_resultado = new StringBuilder();//    variable para colocar el resultado

            try
            {

                nombre_funciones = "";
                string[] linea_nombre_funcion = linea_sin_espacios.Split('#');//   variable para contener las palabras
                string[] linea_nombre_funcion_segundo_ajuste = linea_nombre_funcion[1].Split(')');//   variable para contener las palabras
                nombre_funciones = linea_nombre_funcion_segundo_ajuste[0];
                nombre_funciones = nombre_funciones.Replace('\'', ' ');
                nombre_funciones = nombre_funciones.Trim();

                //  validamos que el encabezao y la funcion sean igual
                if (texto_encabezado.Contains(nombre_funciones))
                {
                    //  se estaran obteniendo los parametros de la funcion
                    string[] linea_texto = linea_sin_espacios.Split('(');//   variable para contener las palabras
                    nombre_variables = "";

                    //  se recorre el arreglo de la funcion
                    foreach (string registro in linea_texto)
                    {
                        //  validamos que no tenga #
                        if (registro.Contains("#"))
                        { }
                        //  validamos que este marcada la bandera 
                        else if (registro.Contains(")"))
                        {
                            nombre_variables = "";
                            nombre_variables = registro.Replace(')', ' ').Replace('{', ' ');


                            string[] linea_texto_funcion = nombre_variables.Split(',');//   variable para contener las palabras

                            //  validamos que sea mayor a 1
                            foreach (string registro_variables in linea_texto_funcion)
                            {
                                //  validamos que se encuentre dentro del encabezado
                                if (texto_encabezado.Trim().Contains(registro_variables.Trim() + ":"))
                                {

                                }
                                else // se indica que no esta registrado en el encabezado
                                {
                                    lineas_resultado.AppendLine("El parámetro " + registro_variables + "no esta declarado" + "\n" + texto_encabezado + linea_sin_espacios + "Linea[" + numero_linea + "]");
                                }

                            }

                        }
                        else
                        {
                        }
                    }

                }
            }
            catch (Exception e)
            {
                lineas_resultado.AppendLine(e.Message);
            }

            return lineas_resultado;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="linea_anterior"></param>
        /// <param name="linea_sin_espacios"></param>
        /// <param name="numero_linea"></param>
        /// <returns></returns>
        public string Tiene_Comentario_El_Ciclo_(string linea_anterior, string linea_sin_espacios, int numero_linea)
        {
            String resultado = "";//    variable que indica el mensaje de la operacion realizada

            try
            {
                //    validamos que tenga comentarios
                if (linea_anterior.Contains("//"))
                {
                    //  si tiene comentarios la funcion, no se realiza ninguna operacion
                }
                //    validamos que tenga comentarios
                else if (linea_sin_espacios.Contains("//"))
                {
                    //  si tiene comentarios la funcion, no se realiza ninguna operacion
                }
                else//  se indica qie funcion no tiene comentario
                {
                    resultado = linea_sin_espacios + " Linea[" + numero_linea + "]";
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
