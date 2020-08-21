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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Actualizar_Archivo_Click(object sender, EventArgs e)
        {
            try
            {
                Thread hilo_ = new Thread(Examinar_Archivo);
                hilo_.Start();
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
                var obj_2 = Revision_Punto2(Lbl_Nombre_Archivo.Text, Lbl_Ruta_Archivo.Text);
                var obj_3 = Revision_Punto3(Lbl_Nombre_Archivo.Text, Lbl_Ruta_Archivo.Text);
                var obj_4 = Revision_Punto4(Lbl_Nombre_Archivo.Text, Lbl_Ruta_Archivo.Text);

                //  se ejecutan los metodos
                await Task.WhenAll(
                    obj_1, obj_2, obj_3, obj_4
                    );

                var resultado_1 = await obj_1;//    variable para contener el resultado numero 1
                var resultado_2 = await obj_2;//    variable para contener el resultado numero 2
                var resultado_3 = await obj_3;//    variable para contener el resultado numero 3
                var resultado_4 = await obj_4;//    variable para contener el resultado numero 4


                //  se cargan los resultados
                Txt_Resultado1.Text = resultado_1.ToString();
                Txt_Resultado2.Text = resultado_2.ToString();
                Txt_Resultado3.Text = resultado_3.ToString();
                Txt_Resultado4.Text = resultado_4.ToString();


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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre_archivo"></param>
        /// <param name="ruta_archivo"></param>
        /// <returns></returns>
        public async Task<String> Revision_Punto2(String nombre_archivo, String ruta_archivo)
        {
            String resultado = "";//    variable para colocar el resultado
            bool tieneMayusculas = false;// variable para saber si una palabra esta en mayusculas
            Int32 numero_linea = 0;//   variable para obtener el numero de linea del archivo
            Boolean bandera = false;//  variable para indicar si ya entro a revisar el caracter de la variable
            String liena_sin_espacios = "";//   variable para contener la linea sin espacios
            try
            {
                //  validamos que no sea una clase
                if (nombre_archivo.Contains("cs"))
                {

                    // Read each line of the file into a string array. Each element
                    // of the array is one line of the file.
                    string[] lineas = System.IO.File.ReadAllLines(@"" + ruta_archivo);


                    foreach (string linea in lineas)
                    {
                        //  se quitan los espacios
                        liena_sin_espacios = linea.Trim(); 

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
                            if (linea != "" )
                            {

                                //  validamos que el texto de la liena sea mayor a un caracter
                                if (liena_sin_espacios.Length > 1 )
                                {

                                    //  validamos que no sea comentario
                                    if (liena_sin_espacios.Substring(0, 2) == "//")
                                    {
                                        //  no realiza ninguna accion
                                    }
                                    else//  si no es comentario procede a revisar
                                    {

                                        string[] linea_texto = liena_sin_espacios.Split(' ');//   variable para contener las palabras
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
                                                    resultado += linea + " Linea[" + numero_linea + "]" + "\n";
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return resultado;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre_archivo"></param>
        /// <param name="ruta_archivo"></param>
        /// <returns></returns>
        public async Task<String> Revision_Punto3(String nombre_archivo, String ruta_archivo)
        {
            String resultado = "";//    variable para colocar el resultado
            bool tieneMinusculas = false;// variable para saber si una palabra esta en mayusculas
            Int32 numero_linea = 0;//   variable para obtener el numero de linea del archivo
            String linea_sin_espacios = "";//   variable para contener la linea sin espacios
            Boolean bandera = false;//  variable para indicar si ya entro a revisar el caracter de la variable
            Boolean bandera_asmx = false;//  variable para indicar si ya entro a revisar el caracter de la variable

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

                        //  validamos que tenga informacion la linea
                        if (linea != "")
                        {
                            //  validamos que el texto de la liena sea mayor a un caracter
                            if (linea_sin_espacios.Length > 3)
                            {
                                //  validamos que tenga la paralabra sea var
                                if (linea_sin_espacios.Substring(0, 3) == "var")
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
                                                resultado += linea + " Linea[" + numero_linea + "]" + "\n";
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
                                                resultado += linea + " Linea[" + numero_linea + "]" + "\n";
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
                                                    resultado += linea + " Linea[" + numero_linea + "]" + "\n";
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
                                                    resultado += linea + " Linea[" + numero_linea + "]" + "\n";
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
                                                    resultado += linea + " Linea[" + numero_linea + "]" + "\n";
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
                                                resultado += linea + " Linea[" + numero_linea + "]" + "\n";
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
                                                        resultado += linea + " Linea[" + numero_linea + "]" + "\n";
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
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre_archivo"></param>
        /// <param name="ruta_archivo"></param>
        /// <returns></returns>
        public async Task<String> Revision_Punto4(String nombre_archivo, String ruta_archivo)
        {
            String resultado = "";//    variable para colocar el resultado
            bool tieneMinusculas = false;// variable para saber si una palabra esta en mayusculas
            Int32 numero_linea = 0;//   variable para obtener el numero de linea del archivo
            String linea_sin_espacios = "";//   variable para contener la linea sin espacios
            Boolean bandera = false;//  variable para indicar si ya entro a revisar el caracter de la variable
            Boolean bandera_asmx = false;//  variable para indicar si ya entro a revisar el caracter de la variable
            string[] lineas;//  variable para la captura de las lineas del texto

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
                                    resultado += linea_sin_espacios + " Linea[" + numero_linea + "]" + "\n\n\n";
                                }
                                else if(linea_sin_espacios.Contains("function") && !linea_sin_espacios.Contains("--"))
                                {
                                    resultado += linea_sin_espacios + " Linea[" + numero_linea + "]" + "\n\n\n";
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

                                    resultado += linea_sin_espacios + " Linea[" + numero_linea + "]" + "\n\n\n";

                                }
                                else if (linea_sin_espacios.Contains("var") && linea_sin_espacios.Contains("using"))//  validamos que tenga la palabra var en la linea
                                {
                                    resultado += linea_sin_espacios + " Linea[" + numero_linea + "]" + "\n\n\n";
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }

        #endregion


    }
}
