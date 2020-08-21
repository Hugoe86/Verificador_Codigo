namespace Verificador_Codigo
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Btn_Cargar_Archivo = new System.Windows.Forms.Button();
            this.Txt_Archivo = new System.Windows.Forms.RichTextBox();
            this.Tab_Resultados1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.TblPnl_Panel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Txt_Resultado1 = new System.Windows.Forms.RichTextBox();
            this.Lbl_Etiqueta1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.TblPnl_Panel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Txt_Resultado2 = new System.Windows.Forms.RichTextBox();
            this.Lbl_Etiqueta2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.TblPnl_Panel3 = new System.Windows.Forms.TableLayoutPanel();
            this.Txt_Resultado3 = new System.Windows.Forms.RichTextBox();
            this.Lbl_Etiqueta3 = new System.Windows.Forms.Label();
            this.Btn_Revisar = new System.Windows.Forms.Button();
            this.Lbl_Nombre_Archivo = new System.Windows.Forms.Label();
            this.Lbl_Ruta_Archivo = new System.Windows.Forms.Label();
            this.Btn_Actualizar_Archivo = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.TblPnl_Panel4 = new System.Windows.Forms.TableLayoutPanel();
            this.Txt_Resultado4 = new System.Windows.Forms.RichTextBox();
            this.Lbl_Etiqueta4 = new System.Windows.Forms.Label();
            this.Tab_Resultados1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.TblPnl_Panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.TblPnl_Panel2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.TblPnl_Panel3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.TblPnl_Panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_Cargar_Archivo
            // 
            this.Btn_Cargar_Archivo.Location = new System.Drawing.Point(12, 12);
            this.Btn_Cargar_Archivo.Name = "Btn_Cargar_Archivo";
            this.Btn_Cargar_Archivo.Size = new System.Drawing.Size(620, 23);
            this.Btn_Cargar_Archivo.TabIndex = 0;
            this.Btn_Cargar_Archivo.Text = "Examinar...";
            this.Btn_Cargar_Archivo.UseVisualStyleBackColor = true;
            this.Btn_Cargar_Archivo.Click += new System.EventHandler(this.Btn_Cargar_Archivo_Click);
            // 
            // Txt_Archivo
            // 
            this.Txt_Archivo.Location = new System.Drawing.Point(12, 86);
            this.Txt_Archivo.Name = "Txt_Archivo";
            this.Txt_Archivo.Size = new System.Drawing.Size(619, 391);
            this.Txt_Archivo.TabIndex = 1;
            this.Txt_Archivo.Text = "";
            // 
            // Tab_Resultados1
            // 
            this.Tab_Resultados1.Controls.Add(this.tabPage1);
            this.Tab_Resultados1.Controls.Add(this.tabPage2);
            this.Tab_Resultados1.Controls.Add(this.tabPage3);
            this.Tab_Resultados1.Controls.Add(this.tabPage4);
            this.Tab_Resultados1.Location = new System.Drawing.Point(654, 37);
            this.Tab_Resultados1.Name = "Tab_Resultados1";
            this.Tab_Resultados1.SelectedIndex = 0;
            this.Tab_Resultados1.Size = new System.Drawing.Size(570, 411);
            this.Tab_Resultados1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.TblPnl_Panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(562, 385);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Resultado 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // TblPnl_Panel1
            // 
            this.TblPnl_Panel1.ColumnCount = 1;
            this.TblPnl_Panel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TblPnl_Panel1.Controls.Add(this.Txt_Resultado1, 0, 1);
            this.TblPnl_Panel1.Controls.Add(this.Lbl_Etiqueta1, 0, 0);
            this.TblPnl_Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TblPnl_Panel1.Location = new System.Drawing.Point(3, 3);
            this.TblPnl_Panel1.Name = "TblPnl_Panel1";
            this.TblPnl_Panel1.RowCount = 2;
            this.TblPnl_Panel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TblPnl_Panel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.TblPnl_Panel1.Size = new System.Drawing.Size(556, 379);
            this.TblPnl_Panel1.TabIndex = 0;
            // 
            // Txt_Resultado1
            // 
            this.Txt_Resultado1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Txt_Resultado1.Location = new System.Drawing.Point(3, 97);
            this.Txt_Resultado1.Name = "Txt_Resultado1";
            this.Txt_Resultado1.Size = new System.Drawing.Size(550, 279);
            this.Txt_Resultado1.TabIndex = 8;
            this.Txt_Resultado1.Text = "";
            // 
            // Lbl_Etiqueta1
            // 
            this.Lbl_Etiqueta1.AutoSize = true;
            this.Lbl_Etiqueta1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Etiqueta1.ForeColor = System.Drawing.Color.Teal;
            this.Lbl_Etiqueta1.Location = new System.Drawing.Point(3, 0);
            this.Lbl_Etiqueta1.Name = "Lbl_Etiqueta1";
            this.Lbl_Etiqueta1.Size = new System.Drawing.Size(484, 22);
            this.Lbl_Etiqueta1.TabIndex = 7;
            this.Lbl_Etiqueta1.Text = "Constantes: SESSION_ABIERTA - todo en mayúsculas.";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.TblPnl_Panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(562, 385);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Resultado 2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // TblPnl_Panel2
            // 
            this.TblPnl_Panel2.AutoSize = true;
            this.TblPnl_Panel2.ColumnCount = 1;
            this.TblPnl_Panel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TblPnl_Panel2.Controls.Add(this.Txt_Resultado2, 0, 1);
            this.TblPnl_Panel2.Controls.Add(this.Lbl_Etiqueta2, 0, 0);
            this.TblPnl_Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TblPnl_Panel2.Location = new System.Drawing.Point(3, 3);
            this.TblPnl_Panel2.Name = "TblPnl_Panel2";
            this.TblPnl_Panel2.RowCount = 2;
            this.TblPnl_Panel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TblPnl_Panel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.TblPnl_Panel2.Size = new System.Drawing.Size(556, 379);
            this.TblPnl_Panel2.TabIndex = 0;
            // 
            // Txt_Resultado2
            // 
            this.Txt_Resultado2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Txt_Resultado2.Location = new System.Drawing.Point(3, 97);
            this.Txt_Resultado2.Name = "Txt_Resultado2";
            this.Txt_Resultado2.Size = new System.Drawing.Size(550, 279);
            this.Txt_Resultado2.TabIndex = 9;
            this.Txt_Resultado2.Text = "";
            // 
            // Lbl_Etiqueta2
            // 
            this.Lbl_Etiqueta2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Lbl_Etiqueta2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Etiqueta2.ForeColor = System.Drawing.Color.Teal;
            this.Lbl_Etiqueta2.Location = new System.Drawing.Point(3, 0);
            this.Lbl_Etiqueta2.Name = "Lbl_Etiqueta2";
            this.Lbl_Etiqueta2.Size = new System.Drawing.Size(550, 94);
            this.Lbl_Etiqueta2.TabIndex = 7;
            this.Lbl_Etiqueta2.Text = "Variables de la clase: Nombre_Cliente (cada palabra inicia en mayúscula).";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.TblPnl_Panel3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(562, 385);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Resultado 3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // TblPnl_Panel3
            // 
            this.TblPnl_Panel3.AutoSize = true;
            this.TblPnl_Panel3.ColumnCount = 1;
            this.TblPnl_Panel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TblPnl_Panel3.Controls.Add(this.Txt_Resultado3, 0, 1);
            this.TblPnl_Panel3.Controls.Add(this.Lbl_Etiqueta3, 0, 0);
            this.TblPnl_Panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TblPnl_Panel3.Location = new System.Drawing.Point(3, 3);
            this.TblPnl_Panel3.Name = "TblPnl_Panel3";
            this.TblPnl_Panel3.RowCount = 2;
            this.TblPnl_Panel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TblPnl_Panel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.TblPnl_Panel3.Size = new System.Drawing.Size(556, 379);
            this.TblPnl_Panel3.TabIndex = 1;
            // 
            // Txt_Resultado3
            // 
            this.Txt_Resultado3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Txt_Resultado3.Location = new System.Drawing.Point(3, 97);
            this.Txt_Resultado3.Name = "Txt_Resultado3";
            this.Txt_Resultado3.Size = new System.Drawing.Size(550, 279);
            this.Txt_Resultado3.TabIndex = 9;
            this.Txt_Resultado3.Text = "";
            // 
            // Lbl_Etiqueta3
            // 
            this.Lbl_Etiqueta3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Lbl_Etiqueta3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Etiqueta3.ForeColor = System.Drawing.Color.Teal;
            this.Lbl_Etiqueta3.Location = new System.Drawing.Point(3, 0);
            this.Lbl_Etiqueta3.Name = "Lbl_Etiqueta3";
            this.Lbl_Etiqueta3.Size = new System.Drawing.Size(550, 94);
            this.Lbl_Etiqueta3.TabIndex = 7;
            this.Lbl_Etiqueta3.Text = "Variables locales: nombre_cliente (cada palabra inicia en minúscula).";
            // 
            // Btn_Revisar
            // 
            this.Btn_Revisar.Location = new System.Drawing.Point(654, 12);
            this.Btn_Revisar.Name = "Btn_Revisar";
            this.Btn_Revisar.Size = new System.Drawing.Size(566, 23);
            this.Btn_Revisar.TabIndex = 5;
            this.Btn_Revisar.Text = "Revisar";
            this.Btn_Revisar.UseVisualStyleBackColor = true;
            this.Btn_Revisar.Click += new System.EventHandler(this.Btn_Revisar_Click);
            // 
            // Lbl_Nombre_Archivo
            // 
            this.Lbl_Nombre_Archivo.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Nombre_Archivo.Location = new System.Drawing.Point(12, 46);
            this.Lbl_Nombre_Archivo.Name = "Lbl_Nombre_Archivo";
            this.Lbl_Nombre_Archivo.Size = new System.Drawing.Size(478, 37);
            this.Lbl_Nombre_Archivo.TabIndex = 8;
            // 
            // Lbl_Ruta_Archivo
            // 
            this.Lbl_Ruta_Archivo.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Ruta_Archivo.Location = new System.Drawing.Point(17, 62);
            this.Lbl_Ruta_Archivo.Name = "Lbl_Ruta_Archivo";
            this.Lbl_Ruta_Archivo.Size = new System.Drawing.Size(473, 21);
            this.Lbl_Ruta_Archivo.TabIndex = 9;
            this.Lbl_Ruta_Archivo.Visible = false;
            // 
            // Btn_Actualizar_Archivo
            // 
            this.Btn_Actualizar_Archivo.Location = new System.Drawing.Point(496, 46);
            this.Btn_Actualizar_Archivo.Name = "Btn_Actualizar_Archivo";
            this.Btn_Actualizar_Archivo.Size = new System.Drawing.Size(135, 34);
            this.Btn_Actualizar_Archivo.TabIndex = 10;
            this.Btn_Actualizar_Archivo.Text = "Actualizar archivo";
            this.Btn_Actualizar_Archivo.UseVisualStyleBackColor = true;
            this.Btn_Actualizar_Archivo.Click += new System.EventHandler(this.Btn_Actualizar_Archivo_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.TblPnl_Panel4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(562, 385);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Resultado 4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // TblPnl_Panel4
            // 
            this.TblPnl_Panel4.AutoSize = true;
            this.TblPnl_Panel4.ColumnCount = 1;
            this.TblPnl_Panel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TblPnl_Panel4.Controls.Add(this.Txt_Resultado4, 0, 1);
            this.TblPnl_Panel4.Controls.Add(this.Lbl_Etiqueta4, 0, 0);
            this.TblPnl_Panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TblPnl_Panel4.Location = new System.Drawing.Point(0, 0);
            this.TblPnl_Panel4.Name = "TblPnl_Panel4";
            this.TblPnl_Panel4.RowCount = 2;
            this.TblPnl_Panel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TblPnl_Panel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.TblPnl_Panel4.Size = new System.Drawing.Size(562, 385);
            this.TblPnl_Panel4.TabIndex = 2;
            // 
            // Txt_Resultado4
            // 
            this.Txt_Resultado4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Txt_Resultado4.Location = new System.Drawing.Point(3, 99);
            this.Txt_Resultado4.Name = "Txt_Resultado4";
            this.Txt_Resultado4.Size = new System.Drawing.Size(556, 283);
            this.Txt_Resultado4.TabIndex = 9;
            this.Txt_Resultado4.Text = "";
            // 
            // Lbl_Etiqueta4
            // 
            this.Lbl_Etiqueta4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Lbl_Etiqueta4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Etiqueta4.ForeColor = System.Drawing.Color.Teal;
            this.Lbl_Etiqueta4.Location = new System.Drawing.Point(3, 0);
            this.Lbl_Etiqueta4.Name = "Lbl_Etiqueta4";
            this.Lbl_Etiqueta4.Size = new System.Drawing.Size(556, 96);
            this.Lbl_Etiqueta4.TabIndex = 7;
            this.Lbl_Etiqueta4.Text = "Usar nombres descriptivos para todas las variables, constantes, funciones y métod" +
    "os. No abreviar.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 517);
            this.Controls.Add(this.Btn_Actualizar_Archivo);
            this.Controls.Add(this.Lbl_Ruta_Archivo);
            this.Controls.Add(this.Lbl_Nombre_Archivo);
            this.Controls.Add(this.Btn_Revisar);
            this.Controls.Add(this.Tab_Resultados1);
            this.Controls.Add(this.Txt_Archivo);
            this.Controls.Add(this.Btn_Cargar_Archivo);
            this.Name = "Form1";
            this.Text = "Verificador de codigo";
            this.Tab_Resultados1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.TblPnl_Panel1.ResumeLayout(false);
            this.TblPnl_Panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.TblPnl_Panel2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.TblPnl_Panel3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.TblPnl_Panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_Cargar_Archivo;
        private System.Windows.Forms.RichTextBox Txt_Archivo;
        private System.Windows.Forms.TabControl Tab_Resultados1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button Btn_Revisar;
        private System.Windows.Forms.TableLayoutPanel TblPnl_Panel1;
        private System.Windows.Forms.RichTextBox Txt_Resultado1;
        private System.Windows.Forms.Label Lbl_Etiqueta1;
        private System.Windows.Forms.TableLayoutPanel TblPnl_Panel2;
        private System.Windows.Forms.Label Lbl_Etiqueta2;
        private System.Windows.Forms.Label Lbl_Nombre_Archivo;
        private System.Windows.Forms.Label Lbl_Ruta_Archivo;
        private System.Windows.Forms.RichTextBox Txt_Resultado2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TableLayoutPanel TblPnl_Panel3;
        private System.Windows.Forms.RichTextBox Txt_Resultado3;
        private System.Windows.Forms.Label Lbl_Etiqueta3;
        private System.Windows.Forms.Button Btn_Actualizar_Archivo;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TableLayoutPanel TblPnl_Panel4;
        private System.Windows.Forms.RichTextBox Txt_Resultado4;
        private System.Windows.Forms.Label Lbl_Etiqueta4;
    }
}

