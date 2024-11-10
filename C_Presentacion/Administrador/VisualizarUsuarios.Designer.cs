namespace AgMaGest.C_Presentacion.Administrador
{
    partial class VisualizarUsuarios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisualizarUsuarios));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridUsuarios = new System.Windows.Forms.DataGridView();
            this.perfil_Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.password_Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuil_Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dni_Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellido_Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email_Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.BEliminarUsuario = new System.Windows.Forms.Button();
            this.BEditarUsuario = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.BBuscarUsuario = new System.Windows.Forms.Button();
            this.TBBuscarUsuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUsuarios)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(200)))), ((int)(((byte)(145)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(35, 706);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(200)))), ((int)(((byte)(145)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1065, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(35, 706);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(200)))), ((int)(((byte)(145)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(35, 658);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1030, 48);
            this.panel3.TabIndex = 3;
            // 
            // dataGridUsuarios
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridUsuarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.perfil_Usuario,
            this.usuario,
            this.password_Usuario,
            this.cuil_Usuario,
            this.dni_Usuario,
            this.nombre_Usuario,
            this.apellido_Usuario,
            this.email_Usuario});
            this.dataGridUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridUsuarios.Location = new System.Drawing.Point(35, 133);
            this.dataGridUsuarios.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridUsuarios.Name = "dataGridUsuarios";
            this.dataGridUsuarios.RowHeadersWidth = 51;
            this.dataGridUsuarios.RowTemplate.Height = 24;
            this.dataGridUsuarios.Size = new System.Drawing.Size(1030, 525);
            this.dataGridUsuarios.TabIndex = 5;
            // 
            // perfil_Usuario
            // 
            this.perfil_Usuario.HeaderText = "Perfil ";
            this.perfil_Usuario.MinimumWidth = 6;
            this.perfil_Usuario.Name = "perfil_Usuario";
            this.perfil_Usuario.Width = 122;
            // 
            // usuario
            // 
            this.usuario.HeaderText = "Usuario";
            this.usuario.MinimumWidth = 6;
            this.usuario.Name = "usuario";
            this.usuario.Width = 122;
            // 
            // password_Usuario
            // 
            this.password_Usuario.HeaderText = "Password";
            this.password_Usuario.MinimumWidth = 6;
            this.password_Usuario.Name = "password_Usuario";
            this.password_Usuario.Width = 122;
            // 
            // cuil_Usuario
            // 
            this.cuil_Usuario.HeaderText = "CUIL";
            this.cuil_Usuario.MinimumWidth = 6;
            this.cuil_Usuario.Name = "cuil_Usuario";
            this.cuil_Usuario.Width = 123;
            // 
            // dni_Usuario
            // 
            this.dni_Usuario.HeaderText = "DNI";
            this.dni_Usuario.MinimumWidth = 6;
            this.dni_Usuario.Name = "dni_Usuario";
            this.dni_Usuario.Width = 122;
            // 
            // nombre_Usuario
            // 
            this.nombre_Usuario.HeaderText = "Nombre";
            this.nombre_Usuario.MinimumWidth = 6;
            this.nombre_Usuario.Name = "nombre_Usuario";
            this.nombre_Usuario.Width = 122;
            // 
            // apellido_Usuario
            // 
            this.apellido_Usuario.HeaderText = "Apellido";
            this.apellido_Usuario.MinimumWidth = 6;
            this.apellido_Usuario.Name = "apellido_Usuario";
            this.apellido_Usuario.Width = 122;
            // 
            // email_Usuario
            // 
            this.email_Usuario.FillWeight = 200F;
            this.email_Usuario.HeaderText = "Email";
            this.email_Usuario.MinimumWidth = 200;
            this.email_Usuario.Name = "email_Usuario";
            this.email_Usuario.Width = 200;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(35, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1030, 133);
            this.panel4.TabIndex = 6;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.BEliminarUsuario);
            this.panel7.Controls.Add(this.BEditarUsuario);
            this.panel7.Controls.Add(this.button2);
            this.panel7.Controls.Add(this.panel10);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 48);
            this.panel7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1030, 60);
            this.panel7.TabIndex = 7;
            // 
            // BEliminarUsuario
            // 
            this.BEliminarUsuario.BackColor = System.Drawing.Color.Transparent;
            this.BEliminarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BEliminarUsuario.Dock = System.Windows.Forms.DockStyle.Left;
            this.BEliminarUsuario.FlatAppearance.BorderSize = 0;
            this.BEliminarUsuario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BEliminarUsuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BEliminarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BEliminarUsuario.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BEliminarUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(141)))), ((int)(((byte)(25)))));
            this.BEliminarUsuario.Image = ((System.Drawing.Image)(resources.GetObject("BEliminarUsuario.Image")));
            this.BEliminarUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BEliminarUsuario.Location = new System.Drawing.Point(649, 0);
            this.BEliminarUsuario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BEliminarUsuario.Name = "BEliminarUsuario";
            this.BEliminarUsuario.Size = new System.Drawing.Size(128, 60);
            this.BEliminarUsuario.TabIndex = 2;
            this.BEliminarUsuario.Text = " Eliminar";
            this.BEliminarUsuario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BEliminarUsuario.UseVisualStyleBackColor = false;
            this.BEliminarUsuario.Click += new System.EventHandler(this.BEliminarUsuario_Click);
            // 
            // BEditarUsuario
            // 
            this.BEditarUsuario.BackColor = System.Drawing.Color.Transparent;
            this.BEditarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BEditarUsuario.Dock = System.Windows.Forms.DockStyle.Left;
            this.BEditarUsuario.FlatAppearance.BorderSize = 0;
            this.BEditarUsuario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BEditarUsuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BEditarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BEditarUsuario.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BEditarUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(141)))), ((int)(((byte)(25)))));
            this.BEditarUsuario.Image = ((System.Drawing.Image)(resources.GetObject("BEditarUsuario.Image")));
            this.BEditarUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BEditarUsuario.Location = new System.Drawing.Point(500, 0);
            this.BEditarUsuario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BEditarUsuario.Name = "BEditarUsuario";
            this.BEditarUsuario.Size = new System.Drawing.Size(149, 60);
            this.BEditarUsuario.TabIndex = 3;
            this.BEditarUsuario.Text = " Editar";
            this.BEditarUsuario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BEditarUsuario.UseVisualStyleBackColor = false;
            this.BEditarUsuario.Click += new System.EventHandler(this.BEditarUsuario_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.Dock = System.Windows.Forms.DockStyle.Left;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(489, 0);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(11, 60);
            this.button2.TabIndex = 10;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(200)))), ((int)(((byte)(145)))));
            this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel10.Location = new System.Drawing.Point(484, 0);
            this.panel10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(5, 60);
            this.panel10.TabIndex = 5;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Transparent;
            this.panel8.Controls.Add(this.BBuscarUsuario);
            this.panel8.Controls.Add(this.TBBuscarUsuario);
            this.panel8.Controls.Add(this.label1);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(484, 60);
            this.panel8.TabIndex = 5;
            // 
            // BBuscarUsuario
            // 
            this.BBuscarUsuario.BackColor = System.Drawing.Color.Transparent;
            this.BBuscarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BBuscarUsuario.Dock = System.Windows.Forms.DockStyle.Right;
            this.BBuscarUsuario.FlatAppearance.BorderSize = 0;
            this.BBuscarUsuario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BBuscarUsuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BBuscarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BBuscarUsuario.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BBuscarUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(141)))), ((int)(((byte)(25)))));
            this.BBuscarUsuario.Image = ((System.Drawing.Image)(resources.GetObject("BBuscarUsuario.Image")));
            this.BBuscarUsuario.Location = new System.Drawing.Point(432, 0);
            this.BBuscarUsuario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BBuscarUsuario.Name = "BBuscarUsuario";
            this.BBuscarUsuario.Size = new System.Drawing.Size(52, 60);
            this.BBuscarUsuario.TabIndex = 5;
            this.BBuscarUsuario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BBuscarUsuario.UseVisualStyleBackColor = false;
            // 
            // TBBuscarUsuario
            // 
            this.TBBuscarUsuario.BackColor = System.Drawing.Color.Gainsboro;
            this.TBBuscarUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBBuscarUsuario.Location = new System.Drawing.Point(166, 13);
            this.TBBuscarUsuario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TBBuscarUsuario.Name = "TBBuscarUsuario";
            this.TBBuscarUsuario.Size = new System.Drawing.Size(267, 32);
            this.TBBuscarUsuario.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Buscar por CUIL";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(200)))), ((int)(((byte)(145)))));
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 108);
            this.panel6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1030, 25);
            this.panel6.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(200)))), ((int)(((byte)(145)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1030, 48);
            this.panel5.TabIndex = 0;
            // 
            // VisualizarUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 706);
            this.Controls.Add(this.dataGridUsuarios);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VisualizarUsuarios";
            this.Text = "VisualizarUsuarios";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUsuarios)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridUsuarios;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button BEditarUsuario;
        private System.Windows.Forms.Button BEliminarUsuario;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox TBBuscarUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.DataGridViewTextBoxColumn perfil_Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn password_Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuil_Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn dni_Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellido_Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn email_Usuario;
        private System.Windows.Forms.Button BBuscarUsuario;
    }
}