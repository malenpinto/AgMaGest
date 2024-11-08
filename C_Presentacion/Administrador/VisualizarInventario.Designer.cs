namespace AgMaGest.C_Presentacion.Administrador
{
    partial class VisualizarInventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisualizarInventario));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.TBBuscarVehiculo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dataGridInventario = new System.Windows.Forms.DataGridView();
            this.id_Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editar_Vehiculo = new System.Windows.Forms.DataGridViewButtonColumn();
            this.estado_Vehiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patente_Codigo0km_Vehiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_Vehiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marca_Vehiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelo_Vehiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.version_Vehiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anio_Vehiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.km_Vehiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.condicion_Vehiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel10 = new System.Windows.Forms.Panel();
            this.BEliminarVehiculo = new System.Windows.Forms.Button();
            this.BEditarVehiculo = new System.Windows.Forms.Button();
            this.BAgregarVehiculo = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInventario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(200)))), ((int)(((byte)(145)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(35, 658);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(200)))), ((int)(((byte)(145)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1065, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(35, 658);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(200)))), ((int)(((byte)(145)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 658);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1100, 48);
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
            this.panel4.TabIndex = 4;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.BEliminarVehiculo);
            this.panel7.Controls.Add(this.BEditarVehiculo);
            this.panel7.Controls.Add(this.BAgregarVehiculo);
            this.panel7.Controls.Add(this.panel10);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 48);
            this.panel7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1030, 60);
            this.panel7.TabIndex = 3;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Transparent;
            this.panel8.Controls.Add(this.label2);
            this.panel8.Controls.Add(this.pictureBox1);
            this.panel8.Controls.Add(this.TBBuscarVehiculo);
            this.panel8.Controls.Add(this.label1);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(509, 60);
            this.panel8.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Código 0Km/Patente";
            // 
            // TBBuscarVehiculo
            // 
            this.TBBuscarVehiculo.BackColor = System.Drawing.Color.Gainsboro;
            this.TBBuscarVehiculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBBuscarVehiculo.Location = new System.Drawing.Point(204, 15);
            this.TBBuscarVehiculo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TBBuscarVehiculo.Name = "TBBuscarVehiculo";
            this.TBBuscarVehiculo.Size = new System.Drawing.Size(255, 32);
            this.TBBuscarVehiculo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Buscar por ";
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
            // dataGridInventario
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridInventario.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridInventario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_Producto,
            this.editar_Vehiculo,
            this.estado_Vehiculo,
            this.patente_Codigo0km_Vehiculo,
            this.tipo_Vehiculo,
            this.marca_Vehiculo,
            this.modelo_Vehiculo,
            this.version_Vehiculo,
            this.anio_Vehiculo,
            this.km_Vehiculo,
            this.condicion_Vehiculo});
            this.dataGridInventario.Location = new System.Drawing.Point(35, 133);
            this.dataGridInventario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridInventario.Name = "dataGridInventario";
            this.dataGridInventario.RowHeadersWidth = 51;
            this.dataGridInventario.RowTemplate.Height = 24;
            this.dataGridInventario.Size = new System.Drawing.Size(1029, 526);
            this.dataGridInventario.TabIndex = 5;
            // 
            // id_Producto
            // 
            this.id_Producto.HeaderText = "ID";
            this.id_Producto.MinimumWidth = 6;
            this.id_Producto.Name = "id_Producto";
            this.id_Producto.Width = 80;
            // 
            // editar_Vehiculo
            // 
            this.editar_Vehiculo.HeaderText = "Editar";
            this.editar_Vehiculo.MinimumWidth = 6;
            this.editar_Vehiculo.Name = "editar_Vehiculo";
            this.editar_Vehiculo.Width = 125;
            // 
            // estado_Vehiculo
            // 
            this.estado_Vehiculo.HeaderText = "Estado";
            this.estado_Vehiculo.MinimumWidth = 6;
            this.estado_Vehiculo.Name = "estado_Vehiculo";
            this.estado_Vehiculo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.estado_Vehiculo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.estado_Vehiculo.Width = 125;
            // 
            // patente_Codigo0km_Vehiculo
            // 
            this.patente_Codigo0km_Vehiculo.HeaderText = "Código 0Km/Patente";
            this.patente_Codigo0km_Vehiculo.MinimumWidth = 6;
            this.patente_Codigo0km_Vehiculo.Name = "patente_Codigo0km_Vehiculo";
            this.patente_Codigo0km_Vehiculo.Width = 125;
            // 
            // tipo_Vehiculo
            // 
            this.tipo_Vehiculo.HeaderText = "Tipo";
            this.tipo_Vehiculo.MinimumWidth = 6;
            this.tipo_Vehiculo.Name = "tipo_Vehiculo";
            this.tipo_Vehiculo.Width = 125;
            // 
            // marca_Vehiculo
            // 
            this.marca_Vehiculo.HeaderText = "Marca";
            this.marca_Vehiculo.MinimumWidth = 6;
            this.marca_Vehiculo.Name = "marca_Vehiculo";
            this.marca_Vehiculo.Width = 125;
            // 
            // modelo_Vehiculo
            // 
            this.modelo_Vehiculo.HeaderText = "Modelo";
            this.modelo_Vehiculo.MinimumWidth = 6;
            this.modelo_Vehiculo.Name = "modelo_Vehiculo";
            this.modelo_Vehiculo.Width = 125;
            // 
            // version_Vehiculo
            // 
            this.version_Vehiculo.HeaderText = "Version";
            this.version_Vehiculo.MinimumWidth = 6;
            this.version_Vehiculo.Name = "version_Vehiculo";
            this.version_Vehiculo.Width = 125;
            // 
            // anio_Vehiculo
            // 
            this.anio_Vehiculo.HeaderText = "Año";
            this.anio_Vehiculo.MinimumWidth = 6;
            this.anio_Vehiculo.Name = "anio_Vehiculo";
            this.anio_Vehiculo.Width = 125;
            // 
            // km_Vehiculo
            // 
            this.km_Vehiculo.HeaderText = "KM";
            this.km_Vehiculo.MinimumWidth = 6;
            this.km_Vehiculo.Name = "km_Vehiculo";
            this.km_Vehiculo.Width = 125;
            // 
            // condicion_Vehiculo
            // 
            this.condicion_Vehiculo.HeaderText = "Condición";
            this.condicion_Vehiculo.MinimumWidth = 6;
            this.condicion_Vehiculo.Name = "condicion_Vehiculo";
            this.condicion_Vehiculo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.condicion_Vehiculo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.condicion_Vehiculo.Width = 125;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(200)))), ((int)(((byte)(145)))));
            this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel10.Location = new System.Drawing.Point(509, 0);
            this.panel10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(5, 60);
            this.panel10.TabIndex = 14;
            // 
            // BEliminarVehiculo
            // 
            this.BEliminarVehiculo.BackColor = System.Drawing.Color.Transparent;
            this.BEliminarVehiculo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BEliminarVehiculo.Dock = System.Windows.Forms.DockStyle.Left;
            this.BEliminarVehiculo.FlatAppearance.BorderSize = 0;
            this.BEliminarVehiculo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BEliminarVehiculo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BEliminarVehiculo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BEliminarVehiculo.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BEliminarVehiculo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(141)))), ((int)(((byte)(25)))));
            this.BEliminarVehiculo.Image = ((System.Drawing.Image)(resources.GetObject("BEliminarVehiculo.Image")));
            this.BEliminarVehiculo.Location = new System.Drawing.Point(825, 0);
            this.BEliminarVehiculo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BEliminarVehiculo.Name = "BEliminarVehiculo";
            this.BEliminarVehiculo.Size = new System.Drawing.Size(54, 60);
            this.BEliminarVehiculo.TabIndex = 12;
            this.BEliminarVehiculo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BEliminarVehiculo.UseVisualStyleBackColor = false;
            // 
            // BEditarVehiculo
            // 
            this.BEditarVehiculo.BackColor = System.Drawing.Color.Transparent;
            this.BEditarVehiculo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BEditarVehiculo.Dock = System.Windows.Forms.DockStyle.Left;
            this.BEditarVehiculo.FlatAppearance.BorderSize = 0;
            this.BEditarVehiculo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BEditarVehiculo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BEditarVehiculo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BEditarVehiculo.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BEditarVehiculo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(141)))), ((int)(((byte)(25)))));
            this.BEditarVehiculo.Image = ((System.Drawing.Image)(resources.GetObject("BEditarVehiculo.Image")));
            this.BEditarVehiculo.Location = new System.Drawing.Point(773, 0);
            this.BEditarVehiculo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BEditarVehiculo.Name = "BEditarVehiculo";
            this.BEditarVehiculo.Size = new System.Drawing.Size(52, 60);
            this.BEditarVehiculo.TabIndex = 13;
            this.BEditarVehiculo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BEditarVehiculo.UseVisualStyleBackColor = false;
            this.BEditarVehiculo.Click += new System.EventHandler(this.BEditarVehiculo_Click_1);
            // 
            // BAgregarVehiculo
            // 
            this.BAgregarVehiculo.BackColor = System.Drawing.Color.Transparent;
            this.BAgregarVehiculo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BAgregarVehiculo.Dock = System.Windows.Forms.DockStyle.Left;
            this.BAgregarVehiculo.FlatAppearance.BorderSize = 0;
            this.BAgregarVehiculo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BAgregarVehiculo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BAgregarVehiculo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BAgregarVehiculo.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAgregarVehiculo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(141)))), ((int)(((byte)(25)))));
            this.BAgregarVehiculo.Image = global::AgMaGest.Properties.Resources.Icono_MasVehiculo;
            this.BAgregarVehiculo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAgregarVehiculo.Location = new System.Drawing.Point(514, 0);
            this.BAgregarVehiculo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BAgregarVehiculo.Name = "BAgregarVehiculo";
            this.BAgregarVehiculo.Size = new System.Drawing.Size(259, 60);
            this.BAgregarVehiculo.TabIndex = 8;
            this.BAgregarVehiculo.Text = " Nuevo Vehículo";
            this.BAgregarVehiculo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BAgregarVehiculo.UseVisualStyleBackColor = false;
            this.BAgregarVehiculo.Click += new System.EventHandler(this.BAgregarVehiculo_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = global::AgMaGest.Properties.Resources.Icono_Buscar_Admin;
            this.pictureBox1.Location = new System.Drawing.Point(464, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // VisualizarInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 706);
            this.Controls.Add(this.dataGridInventario);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "VisualizarInventario";
            this.Text = "VisualizarInventario";
            this.panel4.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInventario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button BAgregarVehiculo;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox TBBuscarVehiculo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridInventario;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_Producto;
        private System.Windows.Forms.DataGridViewButtonColumn editar_Vehiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado_Vehiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn patente_Codigo0km_Vehiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_Vehiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn marca_Vehiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelo_Vehiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn version_Vehiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn anio_Vehiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn km_Vehiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn condicion_Vehiculo;
        private System.Windows.Forms.Button BEliminarVehiculo;
        private System.Windows.Forms.Button BEditarVehiculo;
        private System.Windows.Forms.Panel panel10;
    }
}