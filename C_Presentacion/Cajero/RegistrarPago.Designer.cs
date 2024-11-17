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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.BGenerarPago = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.TBBuscarPedido = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.estadoVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoTotalVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreCompletoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuil_cuit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreCompletoVendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dniVendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eliminarVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editarVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.generarPago = new System.Windows.Forms.DataGridViewButtonColumn();
            this.id_Venta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridPedidos = new System.Windows.Forms.DataGridView();
            this.BBuscarPedido = new System.Windows.Forms.Button();
            this.BRefrescarPedido = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPedidos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Thistle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(35, 706);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Thistle;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1065, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(35, 706);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Thistle;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(35, 658);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1030, 48);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.GhostWhite;
            this.panel4.Controls.Add(this.panel8);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(35, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1030, 130);
            this.panel4.TabIndex = 3;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.GhostWhite;
            this.panel8.Controls.Add(this.BGenerarPago);
            this.panel8.Controls.Add(this.panel10);
            this.panel8.Controls.Add(this.panel9);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 48);
            this.panel8.Margin = new System.Windows.Forms.Padding(4);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1030, 57);
            this.panel8.TabIndex = 12;
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
            this.BGenerarPago.Location = new System.Drawing.Point(495, 7);
            this.BGenerarPago.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BGenerarPago.Name = "BGenerarPago";
            this.BGenerarPago.Size = new System.Drawing.Size(177, 41);
            this.BGenerarPago.TabIndex = 6;
            this.BGenerarPago.Text = "+ Generar Pago";
            this.BGenerarPago.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BGenerarPago.UseVisualStyleBackColor = false;
            this.BGenerarPago.Visible = false;
            this.BGenerarPago.Click += new System.EventHandler(this.BGenerarPago_Click);
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Thistle;
            this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel10.Location = new System.Drawing.Point(473, 0);
            this.panel10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(5, 57);
            this.panel10.TabIndex = 18;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Transparent;
            this.panel9.Controls.Add(this.TBBuscarPedido);
            this.panel9.Controls.Add(this.label2);
            this.panel9.Controls.Add(this.BBuscarPedido);
            this.panel9.Controls.Add(this.BRefrescarPedido);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(473, 57);
            this.panel9.TabIndex = 10;
            // 
            // TBBuscarPedido
            // 
            this.TBBuscarPedido.BackColor = System.Drawing.Color.Gainsboro;
            this.TBBuscarPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.TBBuscarPedido.Location = new System.Drawing.Point(159, 16);
            this.TBBuscarPedido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TBBuscarPedido.Name = "TBBuscarPedido";
            this.TBBuscarPedido.Size = new System.Drawing.Size(199, 27);
            this.TBBuscarPedido.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(3, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Buscar Pedidos";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Thistle;
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1030, 48);
            this.panel6.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Thistle;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 105);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1030, 25);
            this.panel5.TabIndex = 0;
            // 
            // estadoVenta
            // 
            this.estadoVenta.HeaderText = "Estado venta";
            this.estadoVenta.MinimumWidth = 6;
            this.estadoVenta.Name = "estadoVenta";
            this.estadoVenta.Width = 125;
            // 
            // montoTotalVenta
            // 
            this.montoTotalVenta.HeaderText = "Total a pagar";
            this.montoTotalVenta.MinimumWidth = 6;
            this.montoTotalVenta.Name = "montoTotalVenta";
            this.montoTotalVenta.Width = 125;
            // 
            // nombreCompletoCliente
            // 
            this.nombreCompletoCliente.HeaderText = "Cliente";
            this.nombreCompletoCliente.MinimumWidth = 6;
            this.nombreCompletoCliente.Name = "nombreCompletoCliente";
            this.nombreCompletoCliente.Width = 125;
            // 
            // cuil_cuit
            // 
            this.cuil_cuit.HeaderText = "CUIL/CUIT";
            this.cuil_cuit.MinimumWidth = 6;
            this.cuil_cuit.Name = "cuil_cuit";
            this.cuil_cuit.Width = 125;
            // 
            // nombreCompletoVendedor
            // 
            this.nombreCompletoVendedor.HeaderText = "Vendedor";
            this.nombreCompletoVendedor.MinimumWidth = 6;
            this.nombreCompletoVendedor.Name = "nombreCompletoVendedor";
            this.nombreCompletoVendedor.Width = 125;
            // 
            // dniVendedor
            // 
            this.dniVendedor.HeaderText = "DNI Vendedor";
            this.dniVendedor.MinimumWidth = 6;
            this.dniVendedor.Name = "dniVendedor";
            this.dniVendedor.Width = 125;
            // 
            // eliminarVenta
            // 
            this.eliminarVenta.HeaderText = "Eliminar";
            this.eliminarVenta.MinimumWidth = 6;
            this.eliminarVenta.Name = "eliminarVenta";
            this.eliminarVenta.Width = 125;
            // 
            // editarVenta
            // 
            this.editarVenta.HeaderText = "Editar";
            this.editarVenta.MinimumWidth = 6;
            this.editarVenta.Name = "editarVenta";
            this.editarVenta.Width = 125;
            // 
            // generarPago
            // 
            this.generarPago.HeaderText = "Generar Pago";
            this.generarPago.MinimumWidth = 6;
            this.generarPago.Name = "generarPago";
            this.generarPago.Width = 125;
            // 
            // id_Venta
            // 
            this.id_Venta.HeaderText = "ID Venta";
            this.id_Venta.MinimumWidth = 6;
            this.id_Venta.Name = "id_Venta";
            this.id_Venta.Width = 125;
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
            this.dataGridPedidos.Location = new System.Drawing.Point(35, 130);
            this.dataGridPedidos.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridPedidos.Name = "dataGridPedidos";
            this.dataGridPedidos.RowHeadersWidth = 51;
            this.dataGridPedidos.Size = new System.Drawing.Size(1030, 528);
            this.dataGridPedidos.TabIndex = 4;
            this.dataGridPedidos.SelectionChanged += new System.EventHandler(this.DataGridViewClientes_SelectionChanged);
            // 
            // BBuscarPedido
            // 
            this.BBuscarPedido.BackColor = System.Drawing.Color.Transparent;
            this.BBuscarPedido.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BBuscarPedido.Dock = System.Windows.Forms.DockStyle.Right;
            this.BBuscarPedido.FlatAppearance.BorderSize = 0;
            this.BBuscarPedido.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BBuscarPedido.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BBuscarPedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BBuscarPedido.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BBuscarPedido.Image = global::AgMaGest.Properties.Resources.Icono_BuscarCajero;
            this.BBuscarPedido.Location = new System.Drawing.Point(369, 0);
            this.BBuscarPedido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BBuscarPedido.Name = "BBuscarPedido";
            this.BBuscarPedido.Size = new System.Drawing.Size(52, 57);
            this.BBuscarPedido.TabIndex = 9;
            this.BBuscarPedido.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BBuscarPedido.UseVisualStyleBackColor = false;
            this.BBuscarPedido.Click += new System.EventHandler(this.BBuscarPedido_Click);
            // 
            // BRefrescarPedido
            // 
            this.BRefrescarPedido.BackColor = System.Drawing.Color.Transparent;
            this.BRefrescarPedido.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BRefrescarPedido.Dock = System.Windows.Forms.DockStyle.Right;
            this.BRefrescarPedido.FlatAppearance.BorderSize = 0;
            this.BRefrescarPedido.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BRefrescarPedido.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BRefrescarPedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BRefrescarPedido.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BRefrescarPedido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(141)))), ((int)(((byte)(25)))));
            this.BRefrescarPedido.Image = global::AgMaGest.Properties.Resources.Icono_RefescarCajero;
            this.BRefrescarPedido.Location = new System.Drawing.Point(421, 0);
            this.BRefrescarPedido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BRefrescarPedido.Name = "BRefrescarPedido";
            this.BRefrescarPedido.Size = new System.Drawing.Size(52, 57);
            this.BRefrescarPedido.TabIndex = 10;
            this.BRefrescarPedido.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BRefrescarPedido.UseVisualStyleBackColor = false;
            this.BRefrescarPedido.Click += new System.EventHandler(this.BRefrescarPedido_Click);
            // 
            // RegistrarPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 706);
            this.Controls.Add(this.dataGridPedidos);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RegistrarPago";
            this.Text = "RegistrarPago";
            this.panel4.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPedidos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button BGenerarPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoTotalVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreCompletoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuil_cuit;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreCompletoVendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn dniVendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn eliminarVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn editarVenta;
        private System.Windows.Forms.DataGridViewButtonColumn generarPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_Venta;
        private System.Windows.Forms.DataGridView dataGridPedidos;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.TextBox TBBuscarPedido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BBuscarPedido;
        private System.Windows.Forms.Button BRefrescarPedido;
    }
}