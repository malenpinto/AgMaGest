namespace AgMaGest.C_Presentacion.Cajero
{
    partial class ControlCaja
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.idFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.generarIngreso = new System.Windows.Forms.DataGridViewButtonColumn();
            this.agregarEgreso = new System.Windows.Forms.DataGridViewButtonColumn();
            this.editarVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eliminarVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoTotalCaja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Thistle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(26, 574);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Thistle;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(26, 535);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(809, 39);
            this.panel3.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Thistle;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(809, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(26, 496);
            this.panel2.TabIndex = 4;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idFecha,
            this.generarIngreso,
            this.agregarEgreso,
            this.editarVenta,
            this.eliminarVenta,
            this.totalMonto,
            this.montoTotalCaja});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(26, 106);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(783, 429);
            this.dataGridView1.TabIndex = 7;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Thistle;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(26, 86);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(783, 20);
            this.panel5.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar por Fecha/Monto";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(215, 9);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(179, 27);
            this.textBox1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AgMaGest.Properties.Resources.Icono_Buscar_Cajero;
            this.pictureBox1.Location = new System.Drawing.Point(400, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 49);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.GhostWhite;
            this.panel7.Controls.Add(this.pictureBox1);
            this.panel7.Controls.Add(this.textBox1);
            this.panel7.Controls.Add(this.label1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(26, 39);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(783, 47);
            this.panel7.TabIndex = 5;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Thistle;
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(26, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(809, 39);
            this.panel6.TabIndex = 2;
            // 
            // idFecha
            // 
            this.idFecha.HeaderText = "Fecha";
            this.idFecha.Name = "idFecha";
            this.idFecha.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // generarIngreso
            // 
            this.generarIngreso.HeaderText = "Agregar Ingreso";
            this.generarIngreso.Name = "generarIngreso";
            // 
            // agregarEgreso
            // 
            this.agregarEgreso.HeaderText = "Agregar Egreso";
            this.agregarEgreso.Name = "agregarEgreso";
            this.agregarEgreso.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.agregarEgreso.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // editarVenta
            // 
            this.editarVenta.HeaderText = "Editar";
            this.editarVenta.Name = "editarVenta";
            // 
            // eliminarVenta
            // 
            this.eliminarVenta.HeaderText = "Eliminar";
            this.eliminarVenta.Name = "eliminarVenta";
            // 
            // totalMonto
            // 
            this.totalMonto.HeaderText = "Total Monto";
            this.totalMonto.Name = "totalMonto";
            // 
            // montoTotalCaja
            // 
            this.montoTotalCaja.HeaderText = "Total Monto Caja";
            this.montoTotalCaja.Name = "montoTotalCaja";
            // 
            // ControlCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 574);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ControlCaja";
            this.Text = "ControlCaja";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridViewTextBoxColumn idFecha;
        private System.Windows.Forms.DataGridViewButtonColumn generarIngreso;
        private System.Windows.Forms.DataGridViewButtonColumn agregarEgreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn editarVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn eliminarVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoTotalCaja;
    }
}