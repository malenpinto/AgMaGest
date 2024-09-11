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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BSalirForm = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TBNumeroCalle = new System.Windows.Forms.TextBox();
            this.LNumeroCalle = new System.Windows.Forms.Label();
            this.TBCalle = new System.Windows.Forms.TextBox();
            this.LCalle = new System.Windows.Forms.Label();
            this.TBLocalidad = new System.Windows.Forms.TextBox();
            this.LLocalidad = new System.Windows.Forms.Label();
            this.TBCelular = new System.Windows.Forms.TextBox();
            this.TBEmail = new System.Windows.Forms.TextBox();
            this.LEmail = new System.Windows.Forms.Label();
            this.LCelular = new System.Windows.Forms.Label();
            this.TBPais = new System.Windows.Forms.TextBox();
            this.TBApellido = new System.Windows.Forms.TextBox();
            this.TBProvincia = new System.Windows.Forms.TextBox();
            this.TBNombre = new System.Windows.Forms.TextBox();
            this.LProvincia = new System.Windows.Forms.Label();
            this.LPais = new System.Windows.Forms.Label();
            this.BLimpiar = new System.Windows.Forms.Button();
            this.LApellido = new System.Windows.Forms.Label();
            this.LFechaNacimiento = new System.Windows.Forms.Label();
            this.LNombre = new System.Windows.Forms.Label();
            this.BAgregarCliente = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(62)))), ((int)(((byte)(141)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.BSalirForm);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 82);
            this.panel1.TabIndex = 5;
            // 
            // BSalirForm
            // 
            this.BSalirForm.BackColor = System.Drawing.Color.Transparent;
            this.BSalirForm.Dock = System.Windows.Forms.DockStyle.Right;
            this.BSalirForm.FlatAppearance.BorderSize = 0;
            this.BSalirForm.Image = global::AgMaGest.Properties.Resources.BSalir;
            this.BSalirForm.Location = new System.Drawing.Point(575, 0);
            this.BSalirForm.Name = "BSalirForm";
            this.BSalirForm.Size = new System.Drawing.Size(49, 80);
            this.BSalirForm.TabIndex = 1;
            this.BSalirForm.UseVisualStyleBackColor = false;
            this.BSalirForm.Click += new System.EventHandler(this.BSalirForm_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(25, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(414, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingresar Datos del Cliente";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(288, 203);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker1.MaxDate = new System.DateTime(3024, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker1.MinDate = new System.DateTime(1924, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(98, 20);
            this.dateTimePicker1.TabIndex = 48;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(178, 254);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(294, 20);
            this.textBox1.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(53, 242);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 21);
            this.label2.TabIndex = 46;
            this.label2.Text = "Email";
            // 
            // TBNumeroCalle
            // 
            this.TBNumeroCalle.Location = new System.Drawing.Point(178, 452);
            this.TBNumeroCalle.Margin = new System.Windows.Forms.Padding(2);
            this.TBNumeroCalle.Name = "TBNumeroCalle";
            this.TBNumeroCalle.Size = new System.Drawing.Size(294, 20);
            this.TBNumeroCalle.TabIndex = 45;
            // 
            // LNumeroCalle
            // 
            this.LNumeroCalle.AutoSize = true;
            this.LNumeroCalle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNumeroCalle.ForeColor = System.Drawing.Color.MidnightBlue;
            this.LNumeroCalle.Location = new System.Drawing.Point(53, 440);
            this.LNumeroCalle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LNumeroCalle.Name = "LNumeroCalle";
            this.LNumeroCalle.Size = new System.Drawing.Size(72, 21);
            this.LNumeroCalle.TabIndex = 44;
            this.LNumeroCalle.Text = "Número";
            // 
            // TBCalle
            // 
            this.TBCalle.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.TBCalle.Location = new System.Drawing.Point(178, 403);
            this.TBCalle.Margin = new System.Windows.Forms.Padding(2);
            this.TBCalle.Name = "TBCalle";
            this.TBCalle.Size = new System.Drawing.Size(294, 20);
            this.TBCalle.TabIndex = 43;
            // 
            // LCalle
            // 
            this.LCalle.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.LCalle.AutoSize = true;
            this.LCalle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCalle.ForeColor = System.Drawing.Color.MidnightBlue;
            this.LCalle.Location = new System.Drawing.Point(53, 390);
            this.LCalle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LCalle.Name = "LCalle";
            this.LCalle.Size = new System.Drawing.Size(50, 21);
            this.LCalle.TabIndex = 42;
            this.LCalle.Text = "Calle";
            // 
            // TBLocalidad
            // 
            this.TBLocalidad.Location = new System.Drawing.Point(178, 502);
            this.TBLocalidad.Margin = new System.Windows.Forms.Padding(2);
            this.TBLocalidad.Name = "TBLocalidad";
            this.TBLocalidad.Size = new System.Drawing.Size(294, 20);
            this.TBLocalidad.TabIndex = 41;
            // 
            // LLocalidad
            // 
            this.LLocalidad.AutoSize = true;
            this.LLocalidad.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LLocalidad.ForeColor = System.Drawing.Color.MidnightBlue;
            this.LLocalidad.Location = new System.Drawing.Point(53, 490);
            this.LLocalidad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LLocalidad.Name = "LLocalidad";
            this.LLocalidad.Size = new System.Drawing.Size(87, 21);
            this.LLocalidad.TabIndex = 40;
            this.LLocalidad.Text = "Localidad";
            // 
            // TBCelular
            // 
            this.TBCelular.Location = new System.Drawing.Point(178, 353);
            this.TBCelular.Margin = new System.Windows.Forms.Padding(2);
            this.TBCelular.Name = "TBCelular";
            this.TBCelular.Size = new System.Drawing.Size(294, 20);
            this.TBCelular.TabIndex = 39;
            // 
            // TBEmail
            // 
            this.TBEmail.Location = new System.Drawing.Point(178, 304);
            this.TBEmail.Margin = new System.Windows.Forms.Padding(2);
            this.TBEmail.Name = "TBEmail";
            this.TBEmail.Size = new System.Drawing.Size(294, 20);
            this.TBEmail.TabIndex = 38;
            // 
            // LEmail
            // 
            this.LEmail.AutoSize = true;
            this.LEmail.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LEmail.ForeColor = System.Drawing.Color.MidnightBlue;
            this.LEmail.Location = new System.Drawing.Point(53, 291);
            this.LEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LEmail.Name = "LEmail";
            this.LEmail.Size = new System.Drawing.Size(51, 21);
            this.LEmail.TabIndex = 37;
            this.LEmail.Text = "Email";
            // 
            // LCelular
            // 
            this.LCelular.AutoSize = true;
            this.LCelular.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCelular.ForeColor = System.Drawing.Color.MidnightBlue;
            this.LCelular.Location = new System.Drawing.Point(53, 341);
            this.LCelular.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LCelular.Name = "LCelular";
            this.LCelular.Size = new System.Drawing.Size(65, 21);
            this.LCelular.TabIndex = 36;
            this.LCelular.Text = "Celular";
            // 
            // TBPais
            // 
            this.TBPais.Location = new System.Drawing.Point(178, 601);
            this.TBPais.Margin = new System.Windows.Forms.Padding(2);
            this.TBPais.Name = "TBPais";
            this.TBPais.Size = new System.Drawing.Size(294, 20);
            this.TBPais.TabIndex = 35;
            // 
            // TBApellido
            // 
            this.TBApellido.Location = new System.Drawing.Point(178, 155);
            this.TBApellido.Margin = new System.Windows.Forms.Padding(2);
            this.TBApellido.Name = "TBApellido";
            this.TBApellido.Size = new System.Drawing.Size(294, 20);
            this.TBApellido.TabIndex = 34;
            // 
            // TBProvincia
            // 
            this.TBProvincia.Location = new System.Drawing.Point(178, 551);
            this.TBProvincia.Margin = new System.Windows.Forms.Padding(2);
            this.TBProvincia.Name = "TBProvincia";
            this.TBProvincia.Size = new System.Drawing.Size(294, 20);
            this.TBProvincia.TabIndex = 33;
            // 
            // TBNombre
            // 
            this.TBNombre.Location = new System.Drawing.Point(178, 105);
            this.TBNombre.Margin = new System.Windows.Forms.Padding(2);
            this.TBNombre.Name = "TBNombre";
            this.TBNombre.Size = new System.Drawing.Size(294, 20);
            this.TBNombre.TabIndex = 32;
            // 
            // LProvincia
            // 
            this.LProvincia.AutoSize = true;
            this.LProvincia.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LProvincia.ForeColor = System.Drawing.Color.MidnightBlue;
            this.LProvincia.Location = new System.Drawing.Point(53, 539);
            this.LProvincia.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LProvincia.Name = "LProvincia";
            this.LProvincia.Size = new System.Drawing.Size(81, 21);
            this.LProvincia.TabIndex = 31;
            this.LProvincia.Text = "Provincia";
            // 
            // LPais
            // 
            this.LPais.AutoSize = true;
            this.LPais.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LPais.ForeColor = System.Drawing.Color.MidnightBlue;
            this.LPais.Location = new System.Drawing.Point(53, 589);
            this.LPais.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LPais.Name = "LPais";
            this.LPais.Size = new System.Drawing.Size(39, 21);
            this.LPais.TabIndex = 30;
            this.LPais.Text = "País";
            // 
            // BLimpiar
            // 
            this.BLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(75)))), ((int)(((byte)(149)))));
            this.BLimpiar.FlatAppearance.BorderSize = 0;
            this.BLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BLimpiar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BLimpiar.ForeColor = System.Drawing.Color.GhostWhite;
            this.BLimpiar.Location = new System.Drawing.Point(271, 647);
            this.BLimpiar.Margin = new System.Windows.Forms.Padding(2);
            this.BLimpiar.Name = "BLimpiar";
            this.BLimpiar.Size = new System.Drawing.Size(191, 41);
            this.BLimpiar.TabIndex = 26;
            this.BLimpiar.Text = "Limpiar";
            this.BLimpiar.UseVisualStyleBackColor = false;
            // 
            // LApellido
            // 
            this.LApellido.AutoSize = true;
            this.LApellido.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LApellido.ForeColor = System.Drawing.Color.MidnightBlue;
            this.LApellido.Location = new System.Drawing.Point(53, 143);
            this.LApellido.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LApellido.Name = "LApellido";
            this.LApellido.Size = new System.Drawing.Size(74, 21);
            this.LApellido.TabIndex = 28;
            this.LApellido.Text = "Apellido";
            // 
            // LFechaNacimiento
            // 
            this.LFechaNacimiento.AutoSize = true;
            this.LFechaNacimiento.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFechaNacimiento.ForeColor = System.Drawing.Color.MidnightBlue;
            this.LFechaNacimiento.Location = new System.Drawing.Point(53, 192);
            this.LFechaNacimiento.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LFechaNacimiento.Name = "LFechaNacimiento";
            this.LFechaNacimiento.Size = new System.Drawing.Size(154, 21);
            this.LFechaNacimiento.TabIndex = 29;
            this.LFechaNacimiento.Text = "Fecha Nacimiento";
            // 
            // LNombre
            // 
            this.LNombre.AutoSize = true;
            this.LNombre.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNombre.ForeColor = System.Drawing.Color.MidnightBlue;
            this.LNombre.Location = new System.Drawing.Point(53, 93);
            this.LNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LNombre.Name = "LNombre";
            this.LNombre.Size = new System.Drawing.Size(73, 21);
            this.LNombre.TabIndex = 27;
            this.LNombre.Text = "Nombre";
            // 
            // BAgregarCliente
            // 
            this.BAgregarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(75)))), ((int)(((byte)(149)))));
            this.BAgregarCliente.FlatAppearance.BorderSize = 0;
            this.BAgregarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BAgregarCliente.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAgregarCliente.ForeColor = System.Drawing.Color.GhostWhite;
            this.BAgregarCliente.Location = new System.Drawing.Point(57, 647);
            this.BAgregarCliente.Margin = new System.Windows.Forms.Padding(2);
            this.BAgregarCliente.Name = "BAgregarCliente";
            this.BAgregarCliente.Size = new System.Drawing.Size(191, 41);
            this.BAgregarCliente.TabIndex = 25;
            this.BAgregarCliente.Text = "Agregar";
            this.BAgregarCliente.UseVisualStyleBackColor = false;
            // 
            // IngresarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(667, 574);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TBNumeroCalle);
            this.Controls.Add(this.LNumeroCalle);
            this.Controls.Add(this.TBCalle);
            this.Controls.Add(this.LCalle);
            this.Controls.Add(this.TBLocalidad);
            this.Controls.Add(this.LLocalidad);
            this.Controls.Add(this.TBCelular);
            this.Controls.Add(this.TBEmail);
            this.Controls.Add(this.LEmail);
            this.Controls.Add(this.LCelular);
            this.Controls.Add(this.TBPais);
            this.Controls.Add(this.TBApellido);
            this.Controls.Add(this.TBProvincia);
            this.Controls.Add(this.TBNombre);
            this.Controls.Add(this.LProvincia);
            this.Controls.Add(this.LPais);
            this.Controls.Add(this.BLimpiar);
            this.Controls.Add(this.LApellido);
            this.Controls.Add(this.LFechaNacimiento);
            this.Controls.Add(this.LNombre);
            this.Controls.Add(this.BAgregarCliente);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "IngresarCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IngresarCliente";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBNumeroCalle;
        private System.Windows.Forms.Label LNumeroCalle;
        private System.Windows.Forms.TextBox TBCalle;
        private System.Windows.Forms.Label LCalle;
        private System.Windows.Forms.TextBox TBLocalidad;
        private System.Windows.Forms.Label LLocalidad;
        private System.Windows.Forms.TextBox TBCelular;
        private System.Windows.Forms.TextBox TBEmail;
        private System.Windows.Forms.Label LEmail;
        private System.Windows.Forms.Label LCelular;
        private System.Windows.Forms.TextBox TBPais;
        private System.Windows.Forms.TextBox TBApellido;
        private System.Windows.Forms.TextBox TBProvincia;
        private System.Windows.Forms.TextBox TBNombre;
        private System.Windows.Forms.Label LProvincia;
        private System.Windows.Forms.Label LPais;
        private System.Windows.Forms.Button BLimpiar;
        private System.Windows.Forms.Label LApellido;
        private System.Windows.Forms.Label LFechaNacimiento;
        private System.Windows.Forms.Label LNombre;
        private System.Windows.Forms.Button BAgregarCliente;
        private System.Windows.Forms.Button BSalirForm;
    }
}