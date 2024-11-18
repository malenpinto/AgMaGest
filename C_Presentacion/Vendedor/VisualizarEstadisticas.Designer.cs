namespace AgMaGest.C_Presentacion.Vendedor
{
    partial class VisualizarEstadisticas
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartPedidos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.CBFiltroEstado = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartPedidos)).BeginInit();
            this.SuspendLayout();
            // 
            // chartPedidos
            // 
            chartArea2.Name = "ChartArea1";
            this.chartPedidos.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartPedidos.Legends.Add(legend2);
            this.chartPedidos.Location = new System.Drawing.Point(137, 105);
            this.chartPedidos.Name = "chartPedidos";
            this.chartPedidos.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartPedidos.Series.Add(series2);
            this.chartPedidos.Size = new System.Drawing.Size(571, 382);
            this.chartPedidos.TabIndex = 0;
            // 
            // CBFiltroEstado
            // 
            this.CBFiltroEstado.FormattingEnabled = true;
            this.CBFiltroEstado.Location = new System.Drawing.Point(434, 66);
            this.CBFiltroEstado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CBFiltroEstado.Name = "CBFiltroEstado";
            this.CBFiltroEstado.Size = new System.Drawing.Size(274, 24);
            this.CBFiltroEstado.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(62)))), ((int)(((byte)(141)))));
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.GhostWhite;
            this.label1.Location = new System.Drawing.Point(131, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Estados de Pedidos";
            // 
            // VisualizarEstadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1100, 706);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CBFiltroEstado);
            this.Controls.Add(this.chartPedidos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VisualizarEstadisticas";
            this.Text = "VisualizarEstadisticaMensual";
            ((System.ComponentModel.ISupportInitialize)(this.chartPedidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartPedidos;
        private System.Windows.Forms.ComboBox CBFiltroEstado;
        private System.Windows.Forms.Label label1;
    }
}