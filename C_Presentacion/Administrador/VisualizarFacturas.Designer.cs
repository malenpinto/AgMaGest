namespace AgMaGest.C_Presentacion.Administrador
{
    partial class VisualizarFacturas
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridEmpleados = new System.Windows.Forms.DataGridView();
            this.fechaFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.num_Factura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado_Factura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desc_Factura = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cuil_Empleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_Empleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TBBuscarFactura = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEmpleados)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
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
            this.panel3.TabIndex = 4;
            // 
            // dataGridEmpleados
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridEmpleados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEmpleados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fechaFactura,
            this.num_Factura,
            this.estado_Factura,
            this.desc_Factura,
            this.cuil_Empleado,
            this.nombre_Empleado,
            this.totalFactura});
            this.dataGridEmpleados.Location = new System.Drawing.Point(35, 133);
            this.dataGridEmpleados.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridEmpleados.Name = "dataGridEmpleados";
            this.dataGridEmpleados.RowHeadersWidth = 51;
            this.dataGridEmpleados.RowTemplate.Height = 24;
            this.dataGridEmpleados.Size = new System.Drawing.Size(1030, 525);
            this.dataGridEmpleados.TabIndex = 5;
            // 
            // fechaFactura
            // 
            this.fechaFactura.HeaderText = "Fecha";
            this.fechaFactura.MinimumWidth = 6;
            this.fechaFactura.Name = "fechaFactura";
            this.fechaFactura.Width = 125;
            // 
            // num_Factura
            // 
            this.num_Factura.HeaderText = "Núm Factura";
            this.num_Factura.MinimumWidth = 6;
            this.num_Factura.Name = "num_Factura";
            this.num_Factura.Width = 80;
            // 
            // estado_Factura
            // 
            this.estado_Factura.HeaderText = "Estado";
            this.estado_Factura.MinimumWidth = 6;
            this.estado_Factura.Name = "estado_Factura";
            this.estado_Factura.Width = 125;
            // 
            // desc_Factura
            // 
            this.desc_Factura.HeaderText = "Descargar Factura";
            this.desc_Factura.MinimumWidth = 6;
            this.desc_Factura.Name = "desc_Factura";
            this.desc_Factura.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.desc_Factura.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.desc_Factura.Width = 125;
            // 
            // cuil_Empleado
            // 
            this.cuil_Empleado.HeaderText = "CUIL Empleado";
            this.cuil_Empleado.MinimumWidth = 6;
            this.cuil_Empleado.Name = "cuil_Empleado";
            this.cuil_Empleado.Width = 125;
            // 
            // nombre_Empleado
            // 
            this.nombre_Empleado.HeaderText = "Nombre Completo";
            this.nombre_Empleado.MinimumWidth = 6;
            this.nombre_Empleado.Name = "nombre_Empleado";
            this.nombre_Empleado.Width = 125;
            // 
            // totalFactura
            // 
            this.totalFactura.HeaderText = "Total";
            this.totalFactura.MinimumWidth = 6;
            this.totalFactura.Name = "totalFactura";
            this.totalFactura.Width = 125;
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
            this.panel8.Controls.Add(this.TBBuscarFactura);
            this.panel8.Controls.Add(this.label1);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(611, 60);
            this.panel8.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Fecha/Núm de Factura";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = global::AgMaGest.Properties.Resources.Icono_Buscar_Admin;
            this.pictureBox1.Location = new System.Drawing.Point(566, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // TBBuscarFactura
            // 
            this.TBBuscarFactura.BackColor = System.Drawing.Color.Gainsboro;
            this.TBBuscarFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBBuscarFactura.Location = new System.Drawing.Point(263, 11);
            this.TBBuscarFactura.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TBBuscarFactura.Name = "TBBuscarFactura";
            this.TBBuscarFactura.Size = new System.Drawing.Size(287, 32);
            this.TBBuscarFactura.TabIndex = 0;
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
            // VisualizarFacturas
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
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "VisualizarFacturas";
            this.Text = "FacturasAdmin";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEmpleados)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridEmpleados;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox TBBuscarFactura;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn num_Factura;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado_Factura;
        private System.Windows.Forms.DataGridViewButtonColumn desc_Factura;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuil_Empleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_Empleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalFactura;
    }
}