using System.Drawing;
using System;

namespace AgMaGest.C_Presentacion.Cajero
{
    partial class RegistrarPago
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.BBuscarFacturas = new System.Windows.Forms.Button();
            this.TBBuscarPedido = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dataGridPagos = new System.Windows.Forms.DataGridView();
            this.id_Venta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.generarPago = new System.Windows.Forms.DataGridViewButtonColumn();
            this.editarVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eliminarVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dniVendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreCompletoVendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuil_cuit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreCompletoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoTotalVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BGenerarPago = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPagos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Thistle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(39, 882);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Thistle;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1199, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(39, 882);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Thistle;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(39, 822);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1160, 60);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.GhostWhite;
            this.panel4.Controls.Add(this.BGenerarPago);
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(39, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1160, 162);
            this.panel4.TabIndex = 3;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.GhostWhite;
            this.panel7.Controls.Add(this.BBuscarFacturas);
            this.panel7.Controls.Add(this.TBBuscarPedido);
            this.panel7.Controls.Add(this.label1);
            this.panel7.Location = new System.Drawing.Point(0, 60);
            this.panel7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(673, 71);
            this.panel7.TabIndex = 2;
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
            this.BBuscarFacturas.Image = global::AgMaGest.Properties.Resources.Icono_Buscar_Cajero;
            this.BBuscarFacturas.Location = new System.Drawing.Point(615, 0);
            this.BBuscarFacturas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BBuscarFacturas.Name = "BBuscarFacturas";
            this.BBuscarFacturas.Size = new System.Drawing.Size(58, 71);
            this.BBuscarFacturas.TabIndex = 8;
            this.BBuscarFacturas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BBuscarFacturas.UseVisualStyleBackColor = false;
            this.BBuscarFacturas.Click += new System.EventHandler(this.BBuscarFacturas_Click);
            // 
            // TBBuscarPedido
            // 
            this.TBBuscarPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBBuscarPedido.Location = new System.Drawing.Point(323, 14);
            this.TBBuscarPedido.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TBBuscarPedido.Name = "TBBuscarPedido";
            this.TBBuscarPedido.Size = new System.Drawing.Size(266, 37);
            this.TBBuscarPedido.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar por DNI Vendedor/Cliente";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Thistle;
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1160, 60);
            this.panel6.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Thistle;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 131);
            this.panel5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1160, 31);
            this.panel5.TabIndex = 0;
            // 
            // dataGridPagos
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridPagos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPagos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_Venta,
            this.generarPago,
            this.editarVenta,
            this.eliminarVenta,
            this.dniVendedor,
            this.nombreCompletoVendedor,
            this.cuil_cuit,
            this.nombreCompletoCliente,
            this.montoTotalVenta,
            this.estadoVenta});
            this.dataGridPagos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridPagos.Location = new System.Drawing.Point(39, 162);
            this.dataGridPagos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridPagos.Name = "dataGridPagos";
            this.dataGridPagos.RowHeadersWidth = 51;
            this.dataGridPagos.Size = new System.Drawing.Size(1160, 660);
            this.dataGridPagos.TabIndex = 4;
            // 
            // id_Venta
            // 
            this.id_Venta.HeaderText = "ID Venta";
            this.id_Venta.MinimumWidth = 6;
            this.id_Venta.Name = "id_Venta";
            this.id_Venta.Width = 125;
            // 
            // generarPago
            // 
            this.generarPago.HeaderText = "Generar Pago";
            this.generarPago.MinimumWidth = 6;
            this.generarPago.Name = "generarPago";
            this.generarPago.Width = 125;
            // 
            // editarVenta
            // 
            this.editarVenta.HeaderText = "Editar";
            this.editarVenta.MinimumWidth = 6;
            this.editarVenta.Name = "editarVenta";
            this.editarVenta.Width = 125;
            // 
            // eliminarVenta
            // 
            this.eliminarVenta.HeaderText = "Eliminar";
            this.eliminarVenta.MinimumWidth = 6;
            this.eliminarVenta.Name = "eliminarVenta";
            this.eliminarVenta.Width = 125;
            // 
            // dniVendedor
            // 
            this.dniVendedor.HeaderText = "DNI Vendedor";
            this.dniVendedor.MinimumWidth = 6;
            this.dniVendedor.Name = "dniVendedor";
            this.dniVendedor.Width = 125;
            // 
            // nombreCompletoVendedor
            // 
            this.nombreCompletoVendedor.HeaderText = "Vendedor";
            this.nombreCompletoVendedor.MinimumWidth = 6;
            this.nombreCompletoVendedor.Name = "nombreCompletoVendedor";
            this.nombreCompletoVendedor.Width = 125;
            // 
            // cuil_cuit
            // 
            this.cuil_cuit.HeaderText = "CUIL/CUIT";
            this.cuil_cuit.MinimumWidth = 6;
            this.cuil_cuit.Name = "cuil_cuit";
            this.cuil_cuit.Width = 125;
            // 
            // nombreCompletoCliente
            // 
            this.nombreCompletoCliente.HeaderText = "Cliente";
            this.nombreCompletoCliente.MinimumWidth = 6;
            this.nombreCompletoCliente.Name = "nombreCompletoCliente";
            this.nombreCompletoCliente.Width = 125;
            // 
            // montoTotalVenta
            // 
            this.montoTotalVenta.HeaderText = "Total a pagar";
            this.montoTotalVenta.MinimumWidth = 6;
            this.montoTotalVenta.Name = "montoTotalVenta";
            this.montoTotalVenta.Width = 125;
            // 
            // estadoVenta
            // 
            this.estadoVenta.HeaderText = "Estado venta";
            this.estadoVenta.MinimumWidth = 6;
            this.estadoVenta.Name = "estadoVenta";
            this.estadoVenta.Width = 125;
            // 
            // BGenerarPago
            // 
            this.BGenerarPago.BackColor = System.Drawing.Color.Transparent;
            this.BGenerarPago.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BGenerarPago.FlatAppearance.BorderSize = 2;
            this.BGenerarPago.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.BGenerarPago.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BGenerarPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BGenerarPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BGenerarPago.ForeColor = System.Drawing.Color.BlueViolet;
            this.BGenerarPago.Location = new System.Drawing.Point(751, 69);
            this.BGenerarPago.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BGenerarPago.Name = "BGenerarPago";
            this.BGenerarPago.Size = new System.Drawing.Size(173, 51);
            this.BGenerarPago.TabIndex = 6;
            this.BGenerarPago.Text = "+ Generar Pago";
            this.BGenerarPago.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BGenerarPago.UseVisualStyleBackColor = false;
            this.BGenerarPago.Visible = false;
            this.BGenerarPago.Click += new System.EventHandler(this.BGenerarPago_Click);
            // 
            // RegistrarPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 882);
            this.Controls.Add(this.dataGridPagos);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "RegistrarPago";
            this.Text = "RegistrarPago";
            this.panel4.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPagos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dataGridPagos;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBBuscarPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_Venta;
        private System.Windows.Forms.DataGridViewButtonColumn generarPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn editarVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn eliminarVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn dniVendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreCompletoVendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuil_cuit;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreCompletoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoTotalVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoVenta;
        private System.Windows.Forms.Button BBuscarFacturas;
        private System.Windows.Forms.Button BGenerarPago;
    }
}