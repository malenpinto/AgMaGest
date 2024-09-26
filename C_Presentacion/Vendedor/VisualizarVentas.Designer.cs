﻿namespace AgMaGest.C_Presentacion.Vendedor
{
    partial class VisualizarVentas
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
            this.dataGridVentas = new System.Windows.Forms.DataGridView();
            this.id_VerVentas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ver_verVentas = new System.Windows.Forms.DataGridViewButtonColumn();
            this.editar_Venta = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cuitCliente_verVentas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente_verVentas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaFact_verVentas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalFact__verVentas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVentas)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            // dataGridVentas
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_VerVentas,
            this.ver_verVentas,
            this.editar_Venta,
            this.cuitCliente_verVentas,
            this.Cliente_verVentas,
            this.fechaFact_verVentas,
            this.totalFact__verVentas});
            this.dataGridVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridVentas.Location = new System.Drawing.Point(35, 133);
            this.dataGridVentas.Name = "dataGridVentas";
            this.dataGridVentas.RowHeadersWidth = 51;
            this.dataGridVentas.RowTemplate.Height = 24;
            this.dataGridVentas.Size = new System.Drawing.Size(1030, 533);
            this.dataGridVentas.TabIndex = 4;
            // 
            // id_VerVentas
            // 
            this.id_VerVentas.HeaderText = "ID";
            this.id_VerVentas.MinimumWidth = 6;
            this.id_VerVentas.Name = "id_VerVentas";
            this.id_VerVentas.Width = 80;
            // 
            // ver_verVentas
            // 
            this.ver_verVentas.HeaderText = "Visualizar";
            this.ver_verVentas.MinimumWidth = 6;
            this.ver_verVentas.Name = "ver_verVentas";
            this.ver_verVentas.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ver_verVentas.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ver_verVentas.Width = 125;
            // 
            // editar_Venta
            // 
            this.editar_Venta.HeaderText = "Editar";
            this.editar_Venta.MinimumWidth = 6;
            this.editar_Venta.Name = "editar_Venta";
            this.editar_Venta.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.editar_Venta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.editar_Venta.Width = 125;
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
            // fechaFact_verVentas
            // 
            this.fechaFact_verVentas.HeaderText = "Fecha Venta";
            this.fechaFact_verVentas.MinimumWidth = 6;
            this.fechaFact_verVentas.Name = "fechaFact_verVentas";
            this.fechaFact_verVentas.Width = 125;
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
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(35, 48);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1030, 85);
            this.panel5.TabIndex = 5;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Transparent;
            this.panel7.Controls.Add(this.pictureBox1);
            this.panel7.Controls.Add(this.textBox1);
            this.panel7.Controls.Add(this.label1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(524, 60);
            this.panel7.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = global::AgMaGest.Properties.Resources.Icono_Buscar_Vendedor;
            this.pictureBox1.Location = new System.Drawing.Point(479, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(231, 11);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(237, 32);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Buscar por CUIL/CUIT";
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
            // VisualizarVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1100, 706);
            this.Controls.Add(this.dataGridVentas);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VisualizarVentas";
            this.Text = "VisualizarVentas";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVentas)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dataGridVentas;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_VerVentas;
        private System.Windows.Forms.DataGridViewButtonColumn ver_verVentas;
        private System.Windows.Forms.DataGridViewButtonColumn editar_Venta;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuitCliente_verVentas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente_verVentas;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaFact_verVentas;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalFact__verVentas;
    }
}