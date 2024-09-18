namespace AgMaGest.C_Presentacion.Vendedor
{
    partial class IngresarCliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panelDatosCliente = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.BLimpiar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BAgregarCliente = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TBNumeroCalle = new System.Windows.Forms.TextBox();
            this.LNumeroCalle = new System.Windows.Forms.Label();
            this.TBCalle = new System.Windows.Forms.TextBox();
            this.LCalle = new System.Windows.Forms.Label();
            this.TBLocalidad = new System.Windows.Forms.TextBox();
            this.LLocalidad = new System.Windows.Forms.Label();
            this.TBCelular = new System.Windows.Forms.TextBox();
            this.LCelular = new System.Windows.Forms.Label();
            this.TBPais = new System.Windows.Forms.TextBox();
            this.TBApellido = new System.Windows.Forms.TextBox();
            this.TBProvincia = new System.Windows.Forms.TextBox();
            this.TBNombre = new System.Windows.Forms.TextBox();
            this.LProvincia = new System.Windows.Forms.Label();
            this.LPais = new System.Windows.Forms.Label();
            this.LApellido = new System.Windows.Forms.Label();
            this.LFechaNacimiento = new System.Windows.Forms.Label();
            this.LNombre = new System.Windows.Forms.Label();
            this.panelTitulo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitulo
            // 
            this.panelTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(62)))), ((int)(((byte)(141)))));
            this.panelTitulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTitulo.Controls.Add(this.button2);
            this.panelTitulo.Controls.Add(this.button1);
            this.panelTitulo.Controls.Add(this.label1);
            this.panelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitulo.Location = new System.Drawing.Point(0, 0);
            this.panelTitulo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(1028, 40);
            this.panelTitulo.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.GhostWhite;
            this.button2.Image = global::AgMaGest.Properties.Resources.Icono_atras;
            this.button2.Location = new System.Drawing.Point(24, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 32);
            this.button2.TabIndex = 2;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(11, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 47);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.GhostWhite;
            this.label1.Location = new System.Drawing.Point(90, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(389, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingresar Datos del Cliente";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelDatosCliente
            // 
            this.panelDatosCliente.BackColor = System.Drawing.Color.GhostWhite;
            this.panelDatosCliente.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelDatosCliente.Location = new System.Drawing.Point(0, 40);
            this.panelDatosCliente.Name = "panelDatosCliente";
            this.panelDatosCliente.Size = new System.Drawing.Size(271, 666);
            this.panelDatosCliente.TabIndex = 49;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.BLimpiar);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.BAgregarCliente);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.TBNumeroCalle);
            this.panel1.Controls.Add(this.LNumeroCalle);
            this.panel1.Controls.Add(this.TBCalle);
            this.panel1.Controls.Add(this.LCalle);
            this.panel1.Controls.Add(this.TBLocalidad);
            this.panel1.Controls.Add(this.LLocalidad);
            this.panel1.Controls.Add(this.TBCelular);
            this.panel1.Controls.Add(this.LCelular);
            this.panel1.Controls.Add(this.TBPais);
            this.panel1.Controls.Add(this.TBApellido);
            this.panel1.Controls.Add(this.TBProvincia);
            this.panel1.Controls.Add(this.TBNombre);
            this.panel1.Controls.Add(this.LProvincia);
            this.panel1.Controls.Add(this.LPais);
            this.panel1.Controls.Add(this.LApellido);
            this.panel1.Controls.Add(this.LFechaNacimiento);
            this.panel1.Controls.Add(this.LNombre);
            this.panel1.Location = new System.Drawing.Point(277, 89);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(553, 564);
            this.panel1.TabIndex = 50;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(242, 115);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker1.MaxDate = new System.DateTime(3024, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker1.MinDate = new System.DateTime(1924, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(129, 22);
            this.dateTimePicker1.TabIndex = 70;
            // 
            // BLimpiar
            // 
            this.BLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(75)))), ((int)(((byte)(149)))));
            this.BLimpiar.FlatAppearance.BorderSize = 0;
            this.BLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BLimpiar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BLimpiar.ForeColor = System.Drawing.Color.GhostWhite;
            this.BLimpiar.Location = new System.Drawing.Point(305, 483);
            this.BLimpiar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BLimpiar.Name = "BLimpiar";
            this.BLimpiar.Size = new System.Drawing.Size(160, 50);
            this.BLimpiar.TabIndex = 50;
            this.BLimpiar.Text = "Limpiar";
            this.BLimpiar.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(188, 160);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(294, 22);
            this.textBox1.TabIndex = 69;
            // 
            // BAgregarCliente
            // 
            this.BAgregarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(75)))), ((int)(((byte)(149)))));
            this.BAgregarCliente.FlatAppearance.BorderSize = 0;
            this.BAgregarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BAgregarCliente.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAgregarCliente.ForeColor = System.Drawing.Color.GhostWhite;
            this.BAgregarCliente.Location = new System.Drawing.Point(96, 483);
            this.BAgregarCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BAgregarCliente.Name = "BAgregarCliente";
            this.BAgregarCliente.Size = new System.Drawing.Size(160, 50);
            this.BAgregarCliente.TabIndex = 49;
            this.BAgregarCliente.Text = "Agregar";
            this.BAgregarCliente.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(22, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 23);
            this.label2.TabIndex = 68;
            this.label2.Text = "Email";
            // 
            // TBNumeroCalle
            // 
            this.TBNumeroCalle.Location = new System.Drawing.Point(187, 295);
            this.TBNumeroCalle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TBNumeroCalle.Name = "TBNumeroCalle";
            this.TBNumeroCalle.Size = new System.Drawing.Size(294, 22);
            this.TBNumeroCalle.TabIndex = 67;
            // 
            // LNumeroCalle
            // 
            this.LNumeroCalle.AutoSize = true;
            this.LNumeroCalle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNumeroCalle.ForeColor = System.Drawing.Color.MidnightBlue;
            this.LNumeroCalle.Location = new System.Drawing.Point(21, 292);
            this.LNumeroCalle.Name = "LNumeroCalle";
            this.LNumeroCalle.Size = new System.Drawing.Size(88, 23);
            this.LNumeroCalle.TabIndex = 66;
            this.LNumeroCalle.Text = "Número";
            // 
            // TBCalle
            // 
            this.TBCalle.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.TBCalle.Location = new System.Drawing.Point(188, 250);
            this.TBCalle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TBCalle.Name = "TBCalle";
            this.TBCalle.Size = new System.Drawing.Size(294, 22);
            this.TBCalle.TabIndex = 65;
            // 
            // LCalle
            // 
            this.LCalle.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.LCalle.AutoSize = true;
            this.LCalle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCalle.ForeColor = System.Drawing.Color.MidnightBlue;
            this.LCalle.Location = new System.Drawing.Point(22, 247);
            this.LCalle.Name = "LCalle";
            this.LCalle.Size = new System.Drawing.Size(63, 23);
            this.LCalle.TabIndex = 64;
            this.LCalle.Text = "Calle";
            // 
            // TBLocalidad
            // 
            this.TBLocalidad.Location = new System.Drawing.Point(187, 340);
            this.TBLocalidad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TBLocalidad.Name = "TBLocalidad";
            this.TBLocalidad.Size = new System.Drawing.Size(294, 22);
            this.TBLocalidad.TabIndex = 63;
            // 
            // LLocalidad
            // 
            this.LLocalidad.AutoSize = true;
            this.LLocalidad.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LLocalidad.ForeColor = System.Drawing.Color.MidnightBlue;
            this.LLocalidad.Location = new System.Drawing.Point(21, 337);
            this.LLocalidad.Name = "LLocalidad";
            this.LLocalidad.Size = new System.Drawing.Size(109, 23);
            this.LLocalidad.TabIndex = 62;
            this.LLocalidad.Text = "Localidad";
            // 
            // TBCelular
            // 
            this.TBCelular.Location = new System.Drawing.Point(187, 205);
            this.TBCelular.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TBCelular.Name = "TBCelular";
            this.TBCelular.Size = new System.Drawing.Size(294, 22);
            this.TBCelular.TabIndex = 61;
            // 
            // LCelular
            // 
            this.LCelular.AutoSize = true;
            this.LCelular.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCelular.ForeColor = System.Drawing.Color.MidnightBlue;
            this.LCelular.Location = new System.Drawing.Point(21, 202);
            this.LCelular.Name = "LCelular";
            this.LCelular.Size = new System.Drawing.Size(81, 23);
            this.LCelular.TabIndex = 60;
            this.LCelular.Text = "Celular";
            // 
            // TBPais
            // 
            this.TBPais.Location = new System.Drawing.Point(188, 430);
            this.TBPais.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TBPais.Name = "TBPais";
            this.TBPais.Size = new System.Drawing.Size(294, 22);
            this.TBPais.TabIndex = 59;
            // 
            // TBApellido
            // 
            this.TBApellido.Location = new System.Drawing.Point(187, 70);
            this.TBApellido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TBApellido.Name = "TBApellido";
            this.TBApellido.Size = new System.Drawing.Size(294, 22);
            this.TBApellido.TabIndex = 58;
            // 
            // TBProvincia
            // 
            this.TBProvincia.Location = new System.Drawing.Point(188, 385);
            this.TBProvincia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TBProvincia.Name = "TBProvincia";
            this.TBProvincia.Size = new System.Drawing.Size(294, 22);
            this.TBProvincia.TabIndex = 57;
            // 
            // TBNombre
            // 
            this.TBNombre.Location = new System.Drawing.Point(187, 25);
            this.TBNombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TBNombre.Name = "TBNombre";
            this.TBNombre.Size = new System.Drawing.Size(294, 22);
            this.TBNombre.TabIndex = 56;
            // 
            // LProvincia
            // 
            this.LProvincia.AutoSize = true;
            this.LProvincia.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LProvincia.ForeColor = System.Drawing.Color.MidnightBlue;
            this.LProvincia.Location = new System.Drawing.Point(22, 382);
            this.LProvincia.Name = "LProvincia";
            this.LProvincia.Size = new System.Drawing.Size(99, 23);
            this.LProvincia.TabIndex = 55;
            this.LProvincia.Text = "Provincia";
            // 
            // LPais
            // 
            this.LPais.AutoSize = true;
            this.LPais.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LPais.ForeColor = System.Drawing.Color.MidnightBlue;
            this.LPais.Location = new System.Drawing.Point(22, 427);
            this.LPais.Name = "LPais";
            this.LPais.Size = new System.Drawing.Size(49, 23);
            this.LPais.TabIndex = 54;
            this.LPais.Text = "País";
            // 
            // LApellido
            // 
            this.LApellido.AutoSize = true;
            this.LApellido.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LApellido.ForeColor = System.Drawing.Color.MidnightBlue;
            this.LApellido.Location = new System.Drawing.Point(21, 67);
            this.LApellido.Name = "LApellido";
            this.LApellido.Size = new System.Drawing.Size(92, 23);
            this.LApellido.TabIndex = 52;
            this.LApellido.Text = "Apellido";
            // 
            // LFechaNacimiento
            // 
            this.LFechaNacimiento.AutoSize = true;
            this.LFechaNacimiento.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFechaNacimiento.ForeColor = System.Drawing.Color.MidnightBlue;
            this.LFechaNacimiento.Location = new System.Drawing.Point(21, 112);
            this.LFechaNacimiento.Name = "LFechaNacimiento";
            this.LFechaNacimiento.Size = new System.Drawing.Size(190, 23);
            this.LFechaNacimiento.TabIndex = 53;
            this.LFechaNacimiento.Text = "Fecha Nacimiento";
            // 
            // LNombre
            // 
            this.LNombre.AutoSize = true;
            this.LNombre.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNombre.ForeColor = System.Drawing.Color.MidnightBlue;
            this.LNombre.Location = new System.Drawing.Point(21, 22);
            this.LNombre.Name = "LNombre";
            this.LNombre.Size = new System.Drawing.Size(90, 23);
            this.LNombre.TabIndex = 51;
            this.LNombre.Text = "Nombre";
            // 
            // IngresarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(1028, 706);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelDatosCliente);
            this.Controls.Add(this.panelTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "IngresarCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IngresarCliente";
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panelDatosCliente;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button BLimpiar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button BAgregarCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBNumeroCalle;
        private System.Windows.Forms.Label LNumeroCalle;
        private System.Windows.Forms.TextBox TBCalle;
        private System.Windows.Forms.Label LCalle;
        private System.Windows.Forms.TextBox TBLocalidad;
        private System.Windows.Forms.Label LLocalidad;
        private System.Windows.Forms.TextBox TBCelular;
        private System.Windows.Forms.Label LCelular;
        private System.Windows.Forms.TextBox TBPais;
        private System.Windows.Forms.TextBox TBApellido;
        private System.Windows.Forms.TextBox TBProvincia;
        private System.Windows.Forms.TextBox TBNombre;
        private System.Windows.Forms.Label LProvincia;
        private System.Windows.Forms.Label LPais;
        private System.Windows.Forms.Label LApellido;
        private System.Windows.Forms.Label LFechaNacimiento;
        private System.Windows.Forms.Label LNombre;
    }
}