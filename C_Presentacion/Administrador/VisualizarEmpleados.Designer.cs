namespace AgMaGest.C_Presentacion.Administrador
{
    partial class VisualizarEmpleados
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisualizarEmpleados));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.TBBuscarEmpleado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dataGridEmpleados = new System.Windows.Forms.DataGridView();
            this.estado_Empleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.perfil_Empleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuil_Empleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dni_Empleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_Empleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellido_Empleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email_Empleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccion_Empleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BAsignarUsuario = new System.Windows.Forms.Button();
            this.BEditarEmpleado = new System.Windows.Forms.Button();
            this.BEliminarEmpleado = new System.Windows.Forms.Button();
            this.BAgregarEmpleado = new System.Windows.Forms.Button();
            this.BBuscarEmpleado = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEmpleados)).BeginInit();
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
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(200)))), ((int)(((byte)(145)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1065, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(35, 706);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(200)))), ((int)(((byte)(145)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(35, 658);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1030, 48);
            this.panel3.TabIndex = 2;
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
            this.panel4.TabIndex = 3;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.BAsignarUsuario);
            this.panel7.Controls.Add(this.BEditarEmpleado);
            this.panel7.Controls.Add(this.BEliminarEmpleado);
            this.panel7.Controls.Add(this.BAgregarEmpleado);
            this.panel7.Controls.Add(this.button2);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 48);
            this.panel7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1030, 60);
            this.panel7.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(200)))), ((int)(((byte)(145)))));
            this.button2.Dock = System.Windows.Forms.DockStyle.Left;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(438, 0);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(5, 60);
            this.button2.TabIndex = 10;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Transparent;
            this.panel8.Controls.Add(this.BBuscarEmpleado);
            this.panel8.Controls.Add(this.TBBuscarEmpleado);
            this.panel8.Controls.Add(this.label1);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(438, 60);
            this.panel8.TabIndex = 5;
            // 
            // TBBuscarEmpleado
            // 
            this.TBBuscarEmpleado.BackColor = System.Drawing.Color.Gainsboro;
            this.TBBuscarEmpleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBBuscarEmpleado.Location = new System.Drawing.Point(160, 13);
            this.TBBuscarEmpleado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TBBuscarEmpleado.Name = "TBBuscarEmpleado";
            this.TBBuscarEmpleado.Size = new System.Drawing.Size(227, 32);
            this.TBBuscarEmpleado.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Buscar Empleado";
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
            // dataGridEmpleados
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridEmpleados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEmpleados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.estado_Empleado,
            this.perfil_Empleado,
            this.cuil_Empleado,
            this.dni_Empleado,
            this.nombre_Empleado,
            this.apellido_Empleado,
            this.email_Empleado,
            this.direccion_Empleado});
            this.dataGridEmpleados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridEmpleados.Location = new System.Drawing.Point(35, 133);
            this.dataGridEmpleados.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridEmpleados.Name = "dataGridEmpleados";
            this.dataGridEmpleados.RowHeadersWidth = 51;
            this.dataGridEmpleados.RowTemplate.Height = 24;
            this.dataGridEmpleados.Size = new System.Drawing.Size(1030, 525);
            this.dataGridEmpleados.TabIndex = 4;
            this.dataGridEmpleados.SelectionChanged += new System.EventHandler(this.DataGridViewEmpleados_SelectionChanged);
            // 
            // estado_Empleado
            // 
            this.estado_Empleado.HeaderText = "Estado";
            this.estado_Empleado.MinimumWidth = 6;
            this.estado_Empleado.Name = "estado_Empleado";
            this.estado_Empleado.Width = 125;
            // 
            // perfil_Empleado
            // 
            this.perfil_Empleado.HeaderText = "Perfil ";
            this.perfil_Empleado.MinimumWidth = 6;
            this.perfil_Empleado.Name = "perfil_Empleado";
            this.perfil_Empleado.Width = 125;
            // 
            // cuil_Empleado
            // 
            this.cuil_Empleado.HeaderText = "CUIL";
            this.cuil_Empleado.MinimumWidth = 6;
            this.cuil_Empleado.Name = "cuil_Empleado";
            this.cuil_Empleado.Width = 125;
            // 
            // dni_Empleado
            // 
            this.dni_Empleado.HeaderText = "DNI";
            this.dni_Empleado.MinimumWidth = 6;
            this.dni_Empleado.Name = "dni_Empleado";
            this.dni_Empleado.Width = 125;
            // 
            // nombre_Empleado
            // 
            this.nombre_Empleado.HeaderText = "Nombre";
            this.nombre_Empleado.MinimumWidth = 6;
            this.nombre_Empleado.Name = "nombre_Empleado";
            this.nombre_Empleado.Width = 125;
            // 
            // apellido_Empleado
            // 
            this.apellido_Empleado.HeaderText = "Apellido";
            this.apellido_Empleado.MinimumWidth = 6;
            this.apellido_Empleado.Name = "apellido_Empleado";
            this.apellido_Empleado.Width = 125;
            // 
            // email_Empleado
            // 
            this.email_Empleado.HeaderText = "Email";
            this.email_Empleado.MinimumWidth = 6;
            this.email_Empleado.Name = "email_Empleado";
            this.email_Empleado.Width = 125;
            // 
            // direccion_Empleado
            // 
            this.direccion_Empleado.HeaderText = "Dirección";
            this.direccion_Empleado.MinimumWidth = 6;
            this.direccion_Empleado.Name = "direccion_Empleado";
            this.direccion_Empleado.Width = 125;
            // 
            // BAsignarUsuario
            // 
            this.BAsignarUsuario.BackColor = System.Drawing.Color.Transparent;
            this.BAsignarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BAsignarUsuario.Dock = System.Windows.Forms.DockStyle.Left;
            this.BAsignarUsuario.FlatAppearance.BorderSize = 0;
            this.BAsignarUsuario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BAsignarUsuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BAsignarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BAsignarUsuario.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAsignarUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(141)))), ((int)(((byte)(25)))));
            this.BAsignarUsuario.Image = global::AgMaGest.Properties.Resources.Icono_User;
            this.BAsignarUsuario.Location = new System.Drawing.Point(787, 0);
            this.BAsignarUsuario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BAsignarUsuario.Name = "BAsignarUsuario";
            this.BAsignarUsuario.Size = new System.Drawing.Size(183, 60);
            this.BAsignarUsuario.TabIndex = 4;
            this.BAsignarUsuario.Text = " Crear Usuario";
            this.BAsignarUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BAsignarUsuario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BAsignarUsuario.UseVisualStyleBackColor = false;
            this.BAsignarUsuario.Visible = false;
            this.BAsignarUsuario.Click += new System.EventHandler(this.BAsignarUsuario_Click);
            // 
            // BEditarEmpleado
            // 
            this.BEditarEmpleado.BackColor = System.Drawing.Color.Transparent;
            this.BEditarEmpleado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BEditarEmpleado.Dock = System.Windows.Forms.DockStyle.Left;
            this.BEditarEmpleado.FlatAppearance.BorderSize = 0;
            this.BEditarEmpleado.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BEditarEmpleado.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BEditarEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BEditarEmpleado.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BEditarEmpleado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(141)))), ((int)(((byte)(25)))));
            this.BEditarEmpleado.Image = ((System.Drawing.Image)(resources.GetObject("BEditarEmpleado.Image")));
            this.BEditarEmpleado.Location = new System.Drawing.Point(735, 0);
            this.BEditarEmpleado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BEditarEmpleado.Name = "BEditarEmpleado";
            this.BEditarEmpleado.Size = new System.Drawing.Size(52, 60);
            this.BEditarEmpleado.TabIndex = 3;
            this.BEditarEmpleado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BEditarEmpleado.UseVisualStyleBackColor = false;
            this.BEditarEmpleado.Visible = false;
            this.BEditarEmpleado.Click += new System.EventHandler(this.BEditarEmpleado_Click);
            // 
            // BEliminarEmpleado
            // 
            this.BEliminarEmpleado.BackColor = System.Drawing.Color.Transparent;
            this.BEliminarEmpleado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BEliminarEmpleado.Dock = System.Windows.Forms.DockStyle.Left;
            this.BEliminarEmpleado.FlatAppearance.BorderSize = 0;
            this.BEliminarEmpleado.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BEliminarEmpleado.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BEliminarEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BEliminarEmpleado.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BEliminarEmpleado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(141)))), ((int)(((byte)(25)))));
            this.BEliminarEmpleado.Image = ((System.Drawing.Image)(resources.GetObject("BEliminarEmpleado.Image")));
            this.BEliminarEmpleado.Location = new System.Drawing.Point(681, 0);
            this.BEliminarEmpleado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BEliminarEmpleado.Name = "BEliminarEmpleado";
            this.BEliminarEmpleado.Size = new System.Drawing.Size(54, 60);
            this.BEliminarEmpleado.TabIndex = 2;
            this.BEliminarEmpleado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BEliminarEmpleado.UseVisualStyleBackColor = false;
            this.BEliminarEmpleado.Visible = false;
            this.BEliminarEmpleado.Click += new System.EventHandler(this.BEliminarEmpleado_Click);
            // 
            // BAgregarEmpleado
            // 
            this.BAgregarEmpleado.BackColor = System.Drawing.Color.Transparent;
            this.BAgregarEmpleado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BAgregarEmpleado.Dock = System.Windows.Forms.DockStyle.Left;
            this.BAgregarEmpleado.FlatAppearance.BorderSize = 0;
            this.BAgregarEmpleado.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BAgregarEmpleado.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BAgregarEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BAgregarEmpleado.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAgregarEmpleado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(141)))), ((int)(((byte)(25)))));
            this.BAgregarEmpleado.Image = global::AgMaGest.Properties.Resources.Icono_MasEmpleado;
            this.BAgregarEmpleado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAgregarEmpleado.Location = new System.Drawing.Point(443, 0);
            this.BAgregarEmpleado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BAgregarEmpleado.Name = "BAgregarEmpleado";
            this.BAgregarEmpleado.Size = new System.Drawing.Size(238, 60);
            this.BAgregarEmpleado.TabIndex = 1;
            this.BAgregarEmpleado.Text = "Ingresar Empleado";
            this.BAgregarEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BAgregarEmpleado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BAgregarEmpleado.UseVisualStyleBackColor = false;
            this.BAgregarEmpleado.Click += new System.EventHandler(this.BAgregarEmpleado_Click);
            // 
            // BBuscarEmpleado
            // 
            this.BBuscarEmpleado.BackColor = System.Drawing.Color.Transparent;
            this.BBuscarEmpleado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BBuscarEmpleado.Dock = System.Windows.Forms.DockStyle.Right;
            this.BBuscarEmpleado.FlatAppearance.BorderSize = 0;
            this.BBuscarEmpleado.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BBuscarEmpleado.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BBuscarEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BBuscarEmpleado.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BBuscarEmpleado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(141)))), ((int)(((byte)(25)))));
            this.BBuscarEmpleado.Image = ((System.Drawing.Image)(resources.GetObject("BBuscarEmpleado.Image")));
            this.BBuscarEmpleado.Location = new System.Drawing.Point(386, 0);
            this.BBuscarEmpleado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BBuscarEmpleado.Name = "BBuscarEmpleado";
            this.BBuscarEmpleado.Size = new System.Drawing.Size(52, 60);
            this.BBuscarEmpleado.TabIndex = 4;
            this.BBuscarEmpleado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BBuscarEmpleado.UseVisualStyleBackColor = false;
            this.BBuscarEmpleado.Click += new System.EventHandler(this.BBuscarEmpleado_Click);
            // 
            // VisualizarEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 706);
            this.Controls.Add(this.dataGridEmpleados);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "VisualizarEmpleados";
            this.Text = "VisualizarEmpleados";
            this.panel4.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEmpleados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView dataGridEmpleados;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox TBBuscarEmpleado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BAgregarEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado_Empleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn perfil_Empleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuil_Empleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn dni_Empleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_Empleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellido_Empleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn email_Empleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccion_Empleado;
        private System.Windows.Forms.Button BAsignarUsuario;
        private System.Windows.Forms.Button BEliminarEmpleado;
        private System.Windows.Forms.Button BEditarEmpleado;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button BBuscarEmpleado;
    }
}