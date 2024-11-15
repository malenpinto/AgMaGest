namespace AgMaGest.C_Presentacion.Vendedor
{
    partial class VisualizarPedidos
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridPedidos = new System.Windows.Forms.DataGridView();
            this.id_VerVentas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descargarFact_verVentas = new System.Windows.Forms.DataGridViewButtonColumn();
            this.estado_verVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numFact_verVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaFact_verVentas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuitCliente_verVentas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente_verVentas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detalle_verVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalFact__verVentas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.BBuscarFacturas = new System.Windows.Forms.Button();
            this.TBBuscarFactura = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPedidos)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(35, 666);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1065, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(35, 666);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 666);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1100, 40);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(35, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1030, 48);
            this.panel4.TabIndex = 3;
            // 
            // dataGridPedidos
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridPedidos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPedidos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_VerVentas,
            this.descargarFact_verVentas,
            this.estado_verVenta,
            this.numFact_verVenta,
            this.fechaFact_verVentas,
            this.cuitCliente_verVentas,
            this.Cliente_verVentas,
            this.detalle_verVenta,
            this.totalFact__verVentas});
            this.dataGridPedidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridPedidos.Location = new System.Drawing.Point(35, 133);
            this.dataGridPedidos.Name = "dataGridPedidos";
            this.dataGridPedidos.RowHeadersWidth = 51;
            this.dataGridPedidos.RowTemplate.Height = 24;
            this.dataGridPedidos.Size = new System.Drawing.Size(1030, 533);
            this.dataGridPedidos.TabIndex = 4;
            // 
            // id_VerVentas
            // 
            this.id_VerVentas.HeaderText = "ID Venta";
            this.id_VerVentas.MinimumWidth = 6;
            this.id_VerVentas.Name = "id_VerVentas";
            this.id_VerVentas.Width = 80;
            // 
            // descargarFact_verVentas
            // 
            this.descargarFact_verVentas.HeaderText = "Descargar Factura";
            this.descargarFact_verVentas.MinimumWidth = 6;
            this.descargarFact_verVentas.Name = "descargarFact_verVentas";
            this.descargarFact_verVentas.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.descargarFact_verVentas.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.descargarFact_verVentas.Width = 125;
            // 
            // estado_verVenta
            // 
            this.estado_verVenta.HeaderText = "Estado";
            this.estado_verVenta.MinimumWidth = 6;
            this.estado_verVenta.Name = "estado_verVenta";
            this.estado_verVenta.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.estado_verVenta.Width = 125;
            // 
            // numFact_verVenta
            // 
            this.numFact_verVenta.HeaderText = "Núm Factura";
            this.numFact_verVenta.MinimumWidth = 6;
            this.numFact_verVenta.Name = "numFact_verVenta";
            this.numFact_verVenta.Width = 125;
            // 
            // fechaFact_verVentas
            // 
            this.fechaFact_verVentas.HeaderText = "Fecha Venta";
            this.fechaFact_verVentas.MinimumWidth = 6;
            this.fechaFact_verVentas.Name = "fechaFact_verVentas";
            this.fechaFact_verVentas.Width = 125;
            // 
            // cuitCliente_verVentas
            // 
            this.cuitCliente_verVentas.HeaderText = "CUIT/CUIL";
            this.cuitCliente_verVentas.MinimumWidth = 6;
            this.cuitCliente_verVentas.Name = "cuitCliente_verVentas";
            this.cuitCliente_verVentas.Width = 125;
            // 
            // Cliente_verVentas
            // 
            this.Cliente_verVentas.HeaderText = "Cliente";
            this.Cliente_verVentas.MinimumWidth = 6;
            this.Cliente_verVentas.Name = "Cliente_verVentas";
            this.Cliente_verVentas.Width = 250;
            // 
            // detalle_verVenta
            // 
            this.detalle_verVenta.HeaderText = "Detalle Factura";
            this.detalle_verVenta.MinimumWidth = 6;
            this.detalle_verVenta.Name = "detalle_verVenta";
            this.detalle_verVenta.Width = 125;
            // 
            // totalFact__verVentas
            // 
            this.totalFact__verVentas.HeaderText = "Total Factura";
            this.totalFact__verVentas.MinimumWidth = 6;
            this.totalFact__verVentas.Name = "totalFact__verVentas";
            this.totalFact__verVentas.Width = 125;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.GhostWhite;
            this.panel5.Controls.Add(this.panel10);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(35, 48);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1030, 85);
            this.panel5.TabIndex = 5;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel10.Location = new System.Drawing.Point(475, 0);
            this.panel10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(5, 60);
            this.panel10.TabIndex = 16;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Transparent;
            this.panel7.Controls.Add(this.BBuscarFacturas);
            this.panel7.Controls.Add(this.TBBuscarFactura);
            this.panel7.Controls.Add(this.label1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(475, 60);
            this.panel7.TabIndex = 5;
            // 
            // BBuscarFacturas
            // 
            this.BBuscarFacturas.BackColor = System.Drawing.Color.Transparent;
            this.BBuscarFacturas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BBuscarFacturas.Dock = System.Windows.Forms.DockStyle.Right;
            this.BBuscarFacturas.FlatAppearance.BorderSize = 0;
            this.BBuscarFacturas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BBuscarFacturas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BBuscarFacturas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BBuscarFacturas.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BBuscarFacturas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(141)))), ((int)(((byte)(25)))));
            this.BBuscarFacturas.Image = global::AgMaGest.Properties.Resources.Icono_Buscar_Vendedor;
            this.BBuscarFacturas.Location = new System.Drawing.Point(423, 0);
            this.BBuscarFacturas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BBuscarFacturas.Name = "BBuscarFacturas";
            this.BBuscarFacturas.Size = new System.Drawing.Size(52, 60);
            this.BBuscarFacturas.TabIndex = 7;
            this.BBuscarFacturas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BBuscarFacturas.UseVisualStyleBackColor = false;
            this.BBuscarFacturas.Click += new System.EventHandler(this.BBuscarFacturas_Click);
            // 
            // TBBuscarFactura
            // 
            this.TBBuscarFactura.BackColor = System.Drawing.Color.Gainsboro;
            this.TBBuscarFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBBuscarFactura.Location = new System.Drawing.Point(176, 15);
            this.TBBuscarFactura.Name = "TBBuscarFactura";
            this.TBBuscarFactura.Size = new System.Drawing.Size(237, 32);
            this.TBBuscarFactura.TabIndex = 0;
            this.TBBuscarFactura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloNumeros_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Buscar Pedidos";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 60);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1030, 25);
            this.panel6.TabIndex = 0;
            // 
            // VisualizarPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1100, 706);
            this.Controls.Add(this.dataGridPedidos);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VisualizarPedidos";
            this.Text = "VisualizarVentas";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPedidos)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dataGridPedidos;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox TBBuscarFactura;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_VerVentas;
        private System.Windows.Forms.DataGridViewButtonColumn descargarFact_verVentas;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado_verVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn numFact_verVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaFact_verVentas;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuitCliente_verVentas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente_verVentas;
        private System.Windows.Forms.DataGridViewTextBoxColumn detalle_verVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalFact__verVentas;
        private System.Windows.Forms.Button BBuscarFacturas;
        private System.Windows.Forms.Panel panel10;
    }
}