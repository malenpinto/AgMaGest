using System.Drawing;
using System.Windows.Forms;

namespace AgMaGest.C_Presentacion
{
    partial class LoginForm
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
            this.LUsuario = new System.Windows.Forms.Label();
            this.LContrasenia = new System.Windows.Forms.Label();
            this.TBUsuario = new System.Windows.Forms.TextBox();
            this.TBContrasenia = new System.Windows.Forms.TextBox();
            this.CBRecordar = new System.Windows.Forms.CheckBox();
            this.BIniciarSesion = new System.Windows.Forms.Button();
            this.BSalir = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LBienvenidos = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PBPerfil = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBPerfil)).BeginInit();
            this.SuspendLayout();
            // 
            // LUsuario
            // 
            this.LUsuario.AutoSize = true;
            this.LUsuario.BackColor = System.Drawing.Color.Transparent;
            this.LUsuario.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LUsuario.ForeColor = System.Drawing.Color.GhostWhite;
            this.LUsuario.Location = new System.Drawing.Point(475, 378);
            this.LUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LUsuario.Name = "LUsuario";
            this.LUsuario.Size = new System.Drawing.Size(81, 23);
            this.LUsuario.TabIndex = 0;
            this.LUsuario.Text = "Usuario";
            // 
            // LContrasenia
            // 
            this.LContrasenia.AutoSize = true;
            this.LContrasenia.BackColor = System.Drawing.Color.Transparent;
            this.LContrasenia.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LContrasenia.ForeColor = System.Drawing.Color.GhostWhite;
            this.LContrasenia.Location = new System.Drawing.Point(475, 439);
            this.LContrasenia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LContrasenia.Name = "LContrasenia";
            this.LContrasenia.Size = new System.Drawing.Size(123, 23);
            this.LContrasenia.TabIndex = 1;
            this.LContrasenia.Text = "Contraseña";
            // 
            // TBUsuario
            // 
            this.TBUsuario.Location = new System.Drawing.Point(631, 378);
            this.TBUsuario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TBUsuario.Name = "TBUsuario";
            this.TBUsuario.Size = new System.Drawing.Size(132, 22);
            this.TBUsuario.TabIndex = 2;
            this.TBUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBUsuario_KeyPress);
            // 
            // TBContrasenia
            // 
            this.TBContrasenia.Location = new System.Drawing.Point(631, 439);
            this.TBContrasenia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TBContrasenia.Name = "TBContrasenia";
            this.TBContrasenia.Size = new System.Drawing.Size(132, 22);
            this.TBContrasenia.TabIndex = 3;
            // 
            // CBRecordar
            // 
            this.CBRecordar.AutoSize = true;
            this.CBRecordar.BackColor = System.Drawing.Color.Transparent;
            this.CBRecordar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBRecordar.ForeColor = System.Drawing.Color.GhostWhite;
            this.CBRecordar.Location = new System.Drawing.Point(480, 495);
            this.CBRecordar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CBRecordar.Name = "CBRecordar";
            this.CBRecordar.Size = new System.Drawing.Size(172, 25);
            this.CBRecordar.TabIndex = 7;
            this.CBRecordar.Text = "Recordar usuario";
            this.CBRecordar.UseVisualStyleBackColor = false;
            // 
            // BIniciarSesion
            // 
            this.BIniciarSesion.BackColor = System.Drawing.Color.Gray;
            this.BIniciarSesion.FlatAppearance.BorderSize = 0;
            this.BIniciarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BIniciarSesion.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BIniciarSesion.ForeColor = System.Drawing.Color.GhostWhite;
            this.BIniciarSesion.Location = new System.Drawing.Point(480, 545);
            this.BIniciarSesion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BIniciarSesion.Name = "BIniciarSesion";
            this.BIniciarSesion.Size = new System.Drawing.Size(132, 62);
            this.BIniciarSesion.TabIndex = 8;
            this.BIniciarSesion.Text = "Iniciar Sesion";
            this.BIniciarSesion.UseVisualStyleBackColor = true;
            this.BIniciarSesion.Click += new System.EventHandler(this.BIniciarSesion_Click);
            // 
            // BSalir
            // 
            this.BSalir.BackColor = System.Drawing.Color.Gray;
            this.BSalir.FlatAppearance.BorderSize = 0;
            this.BSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BSalir.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BSalir.ForeColor = System.Drawing.Color.GhostWhite;
            this.BSalir.Location = new System.Drawing.Point(631, 545);
            this.BSalir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BSalir.Name = "BSalir";
            this.BSalir.Size = new System.Drawing.Size(133, 62);
            this.BSalir.TabIndex = 9;
            this.BSalir.Text = "Salir";
            this.BSalir.UseVisualStyleBackColor = true;
            this.BSalir.Click += new System.EventHandler(this.BSalir_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(138)))), ((int)(((byte)(208)))));
            this.panel1.Controls.Add(this.LBienvenidos);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1248, 150);
            this.panel1.TabIndex = 10;
            // 
            // LBienvenidos
            // 
            this.LBienvenidos.AutoSize = true;
            this.LBienvenidos.BackColor = System.Drawing.Color.Transparent;
            this.LBienvenidos.Font = new System.Drawing.Font("Cascadia Code SemiLight", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBienvenidos.ForeColor = System.Drawing.Color.GhostWhite;
            this.LBienvenidos.Location = new System.Drawing.Point(463, 27);
            this.LBienvenidos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBienvenidos.Name = "LBienvenidos";
            this.LBienvenidos.Size = new System.Drawing.Size(419, 79);
            this.LBienvenidos.TabIndex = 2;
            this.LBienvenidos.Text = "BIENVENIDOS";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 28);
            this.label1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.GhostWhite;
            this.panel2.Location = new System.Drawing.Point(208, 144);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(785, 2);
            this.panel2.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AgMaGest.Properties.Resources.iconoLogoInicio;
            this.pictureBox1.Location = new System.Drawing.Point(252, -64);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(272, 261);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // PBPerfil
            // 
            this.PBPerfil.BackColor = System.Drawing.Color.Transparent;
            this.PBPerfil.Image = global::AgMaGest.Properties.Resources.Icono_Avatar;
            this.PBPerfil.Location = new System.Drawing.Point(557, 226);
            this.PBPerfil.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PBPerfil.Name = "PBPerfil";
            this.PBPerfil.Size = new System.Drawing.Size(133, 124);
            this.PBPerfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBPerfil.TabIndex = 6;
            this.PBPerfil.TabStop = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(1248, 656);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BSalir);
            this.Controls.Add(this.BIniciarSesion);
            this.Controls.Add(this.CBRecordar);
            this.Controls.Add(this.PBPerfil);
            this.Controls.Add(this.TBContrasenia);
            this.Controls.Add(this.TBUsuario);
            this.Controls.Add(this.LContrasenia);
            this.Controls.Add(this.LUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar Sesión";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBPerfil)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.Label LUsuario;
        private System.Windows.Forms.Label LContrasenia;
        private System.Windows.Forms.TextBox TBUsuario;
        private System.Windows.Forms.TextBox TBContrasenia;
        private System.Windows.Forms.PictureBox PBPerfil;
        private System.Windows.Forms.CheckBox CBRecordar;
        private Button BIniciarSesion;
        private Button BSalir;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Panel panel2;
        private Label label1;
        private Label LBienvenidos;
    }
}