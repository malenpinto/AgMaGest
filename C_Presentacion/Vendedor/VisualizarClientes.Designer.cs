﻿namespace AgMaGest.C_Presentacion.Vendedor
{
    partial class VisualizarClientes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridClientes = new System.Windows.Forms.DataGridView();
            this.id_Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editar_Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGeditar_Cliente = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cuil_cuit_Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.celular_Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email_Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccion_Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.BAgregarEmpresa = new System.Windows.Forms.Button();
            this.BAgregarPersona = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.TBBuscarCliente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.BEliminarCliente = new System.Windows.Forms.Button();
            this.BEditarCliente = new System.Windows.Forms.Button();
            this.BAgregarCliente = new System.Windows.Forms.Button();
            this.BBuscarCliente = new System.Windows.Forms.Button();
            this.BRefrescarCliente = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridClientes)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridClientes
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.dataGridClientes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_Cliente,
            this.editar_Cliente,
            this.DGeditar_Cliente,
            this.cuil_cuit_Cliente,
            this.nombre_Cliente,
            this.celular_Cliente,
            this.email_Cliente,
            this.direccion_Cliente});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridClientes.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridClientes.Location = new System.Drawing.Point(35, 133);
            this.dataGridClientes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridClientes.Name = "dataGridClientes";
            this.dataGridClientes.RowHeadersWidth = 51;
            this.dataGridClientes.RowTemplate.Height = 24;
            this.dataGridClientes.Size = new System.Drawing.Size(1030, 525);
            this.dataGridClientes.TabIndex = 7;
            this.dataGridClientes.SelectionChanged += new System.EventHandler(this.DataGridViewClientes_SelectionChanged);
            // 
            // id_Cliente
            // 
            this.id_Cliente.HeaderText = "ID";
            this.id_Cliente.MinimumWidth = 6;
            this.id_Cliente.Name = "id_Cliente";
            this.id_Cliente.Width = 80;
            // 
            // editar_Cliente
            // 
            this.editar_Cliente.HeaderText = "Estado";
            this.editar_Cliente.MinimumWidth = 6;
            this.editar_Cliente.Name = "editar_Cliente";
            this.editar_Cliente.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.editar_Cliente.Width = 125;
            // 
            // DGeditar_Cliente
            // 
            this.DGeditar_Cliente.HeaderText = "Editar";
            this.DGeditar_Cliente.MinimumWidth = 6;
            this.DGeditar_Cliente.Name = "DGeditar_Cliente";
            this.DGeditar_Cliente.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DGeditar_Cliente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DGeditar_Cliente.Width = 125;
            // 
            // cuil_cuit_Cliente
            // 
            this.cuil_cuit_Cliente.HeaderText = "CUIL/CUIT";
            this.cuil_cuit_Cliente.MinimumWidth = 6;
            this.cuil_cuit_Cliente.Name = "cuil_cuit_Cliente";
            this.cuil_cuit_Cliente.Width = 125;
            // 
            // nombre_Cliente
            // 
            this.nombre_Cliente.HeaderText = "Nombre";
            this.nombre_Cliente.MinimumWidth = 6;
            this.nombre_Cliente.Name = "nombre_Cliente";
            this.nombre_Cliente.Width = 250;
            // 
            // celular_Cliente
            // 
            this.celular_Cliente.HeaderText = "Celular";
            this.celular_Cliente.MinimumWidth = 6;
            this.celular_Cliente.Name = "celular_Cliente";
            this.celular_Cliente.Width = 125;
            // 
            // email_Cliente
            // 
            this.email_Cliente.HeaderText = "Email";
            this.email_Cliente.MinimumWidth = 6;
            this.email_Cliente.Name = "email_Cliente";
            this.email_Cliente.Width = 125;
            // 
            // direccion_Cliente
            // 
            this.direccion_Cliente.HeaderText = "Dirección";
            this.direccion_Cliente.MinimumWidth = 6;
            this.direccion_Cliente.Name = "direccion_Cliente";
            this.direccion_Cliente.Width = 250;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 658);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1100, 48);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(35, 658);
            this.panel2.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1065, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(35, 658);
            this.panel3.TabIndex = 11;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.GhostWhite;
            this.panel6.Controls.Add(this.panel8);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Controls.Add(this.panel9);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(35, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1030, 133);
            this.panel6.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.panel4);
            this.panel8.Controls.Add(this.panel5);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 48);
            this.panel8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1030, 60);
            this.panel8.TabIndex = 7;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.BEliminarCliente);
            this.panel4.Controls.Add(this.BEditarCliente);
            this.panel4.Controls.Add(this.BAgregarEmpresa);
            this.panel4.Controls.Add(this.BAgregarPersona);
            this.panel4.Controls.Add(this.BAgregarCliente);
            this.panel4.Controls.Add(this.panel10);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(473, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(557, 60);
            this.panel4.TabIndex = 4;
            // 
            // BAgregarEmpresa
            // 
            this.BAgregarEmpresa.BackColor = System.Drawing.Color.Transparent;
            this.BAgregarEmpresa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BAgregarEmpresa.FlatAppearance.BorderSize = 2;
            this.BAgregarEmpresa.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.BAgregarEmpresa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BAgregarEmpresa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BAgregarEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAgregarEmpresa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(62)))), ((int)(((byte)(141)))));
            this.BAgregarEmpresa.Location = new System.Drawing.Point(380, 7);
            this.BAgregarEmpresa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BAgregarEmpresa.Name = "BAgregarEmpresa";
            this.BAgregarEmpresa.Size = new System.Drawing.Size(120, 41);
            this.BAgregarEmpresa.TabIndex = 6;
            this.BAgregarEmpresa.Text = "+ Empresa";
            this.BAgregarEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAgregarEmpresa.UseVisualStyleBackColor = false;
            this.BAgregarEmpresa.Visible = false;
            this.BAgregarEmpresa.Click += new System.EventHandler(this.BAgregarEmpresa_Click);
            // 
            // BAgregarPersona
            // 
            this.BAgregarPersona.BackColor = System.Drawing.Color.Transparent;
            this.BAgregarPersona.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BAgregarPersona.FlatAppearance.BorderSize = 2;
            this.BAgregarPersona.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.BAgregarPersona.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BAgregarPersona.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BAgregarPersona.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAgregarPersona.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(62)))), ((int)(((byte)(141)))));
            this.BAgregarPersona.Location = new System.Drawing.Point(247, 7);
            this.BAgregarPersona.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BAgregarPersona.Name = "BAgregarPersona";
            this.BAgregarPersona.Size = new System.Drawing.Size(120, 41);
            this.BAgregarPersona.TabIndex = 5;
            this.BAgregarPersona.Text = "+ Persona";
            this.BAgregarPersona.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAgregarPersona.UseVisualStyleBackColor = false;
            this.BAgregarPersona.Visible = false;
            this.BAgregarPersona.Click += new System.EventHandler(this.BAgregarPersona_Click);
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(5, 60);
            this.panel10.TabIndex = 16;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.Controls.Add(this.BBuscarCliente);
            this.panel5.Controls.Add(this.TBBuscarCliente);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.BRefrescarCliente);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(473, 60);
            this.panel5.TabIndex = 4;
            // 
            // TBBuscarCliente
            // 
            this.TBBuscarCliente.BackColor = System.Drawing.Color.Gainsboro;
            this.TBBuscarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.TBBuscarCliente.Location = new System.Drawing.Point(159, 16);
            this.TBBuscarCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TBBuscarCliente.Name = "TBBuscarCliente";
            this.TBBuscarCliente.Size = new System.Drawing.Size(199, 27);
            this.TBBuscarCliente.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Buscar Cliente";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 108);
            this.panel7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1030, 25);
            this.panel7.TabIndex = 6;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1030, 48);
            this.panel9.TabIndex = 5;
            // 
            // BEliminarCliente
            // 
            this.BEliminarCliente.BackColor = System.Drawing.Color.Transparent;
            this.BEliminarCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BEliminarCliente.Dock = System.Windows.Forms.DockStyle.Left;
            this.BEliminarCliente.FlatAppearance.BorderSize = 0;
            this.BEliminarCliente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BEliminarCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BEliminarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BEliminarCliente.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BEliminarCliente.Image = global::AgMaGest.Properties.Resources.Icono_BorrarVendedor;
            this.BEliminarCliente.Location = new System.Drawing.Point(264, 0);
            this.BEliminarCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BEliminarCliente.Name = "BEliminarCliente";
            this.BEliminarCliente.Size = new System.Drawing.Size(52, 60);
            this.BEliminarCliente.TabIndex = 9;
            this.BEliminarCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BEliminarCliente.UseVisualStyleBackColor = false;
            this.BEliminarCliente.Visible = false;
            this.BEliminarCliente.Click += new System.EventHandler(this.BEliminarCliente_Click);
            // 
            // BEditarCliente
            // 
            this.BEditarCliente.BackColor = System.Drawing.Color.Transparent;
            this.BEditarCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BEditarCliente.Dock = System.Windows.Forms.DockStyle.Left;
            this.BEditarCliente.FlatAppearance.BorderSize = 0;
            this.BEditarCliente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BEditarCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BEditarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BEditarCliente.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BEditarCliente.Image = global::AgMaGest.Properties.Resources.Icono_EditarVendedor;
            this.BEditarCliente.Location = new System.Drawing.Point(212, 0);
            this.BEditarCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BEditarCliente.Name = "BEditarCliente";
            this.BEditarCliente.Size = new System.Drawing.Size(52, 60);
            this.BEditarCliente.TabIndex = 8;
            this.BEditarCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BEditarCliente.UseVisualStyleBackColor = false;
            this.BEditarCliente.Visible = false;
            this.BEditarCliente.Click += new System.EventHandler(this.BEditarCliente_Click);
            // 
            // BAgregarCliente
            // 
            this.BAgregarCliente.BackColor = System.Drawing.Color.Transparent;
            this.BAgregarCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BAgregarCliente.Dock = System.Windows.Forms.DockStyle.Left;
            this.BAgregarCliente.FlatAppearance.BorderSize = 0;
            this.BAgregarCliente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BAgregarCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BAgregarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BAgregarCliente.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAgregarCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(62)))), ((int)(((byte)(141)))));
            this.BAgregarCliente.Image = global::AgMaGest.Properties.Resources.Icono_MasCliente;
            this.BAgregarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAgregarCliente.Location = new System.Drawing.Point(5, 0);
            this.BAgregarCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BAgregarCliente.Name = "BAgregarCliente";
            this.BAgregarCliente.Size = new System.Drawing.Size(207, 60);
            this.BAgregarCliente.TabIndex = 4;
            this.BAgregarCliente.Text = " Nuevo Cliente";
            this.BAgregarCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BAgregarCliente.UseVisualStyleBackColor = false;
            this.BAgregarCliente.Click += new System.EventHandler(this.BAgregarCliente_Click_1);
            // 
            // BBuscarCliente
            // 
            this.BBuscarCliente.BackColor = System.Drawing.Color.Transparent;
            this.BBuscarCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BBuscarCliente.Dock = System.Windows.Forms.DockStyle.Right;
            this.BBuscarCliente.FlatAppearance.BorderSize = 0;
            this.BBuscarCliente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BBuscarCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BBuscarCliente.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BBuscarCliente.Image = global::AgMaGest.Properties.Resources.Icono_BuscarVendedor;
            this.BBuscarCliente.Location = new System.Drawing.Point(369, 0);
            this.BBuscarCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BBuscarCliente.Name = "BBuscarCliente";
            this.BBuscarCliente.Size = new System.Drawing.Size(52, 60);
            this.BBuscarCliente.TabIndex = 5;
            this.BBuscarCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BBuscarCliente.UseVisualStyleBackColor = false;
            this.BBuscarCliente.Click += new System.EventHandler(this.BBuscarEmpleado_Click);
            // 
            // BRefrescarCliente
            // 
            this.BRefrescarCliente.BackColor = System.Drawing.Color.Transparent;
            this.BRefrescarCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BRefrescarCliente.Dock = System.Windows.Forms.DockStyle.Right;
            this.BRefrescarCliente.FlatAppearance.BorderSize = 0;
            this.BRefrescarCliente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BRefrescarCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BRefrescarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BRefrescarCliente.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BRefrescarCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(141)))), ((int)(((byte)(25)))));
            this.BRefrescarCliente.Image = global::AgMaGest.Properties.Resources.Icono_RefescarVendedor;
            this.BRefrescarCliente.Location = new System.Drawing.Point(421, 0);
            this.BRefrescarCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BRefrescarCliente.Name = "BRefrescarCliente";
            this.BRefrescarCliente.Size = new System.Drawing.Size(52, 60);
            this.BRefrescarCliente.TabIndex = 9;
            this.BRefrescarCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BRefrescarCliente.UseVisualStyleBackColor = false;
            this.BRefrescarCliente.Click += new System.EventHandler(this.BRefrescarCliente_Click);
            // 
            // VisualizarClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 706);
            this.Controls.Add(this.dataGridClientes);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "VisualizarClientes";
            this.Text = "VisualizarClientes";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridClientes)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridClientes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button BAgregarPersona;
        private System.Windows.Forms.Button BAgregarEmpresa;
        private System.Windows.Forms.Button BAgregarCliente;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox TBBuscarCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn editar_Cliente;
        private System.Windows.Forms.DataGridViewButtonColumn DGeditar_Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuil_cuit_Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn celular_Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn email_Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccion_Cliente;
        private System.Windows.Forms.Button BBuscarCliente;
        private System.Windows.Forms.Button BEliminarCliente;
        private System.Windows.Forms.Button BEditarCliente;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button BRefrescarCliente;
    }
}