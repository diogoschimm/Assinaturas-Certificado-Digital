namespace CertificadoDigital
{
    partial class FrmAssinador
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
            this.btnAssinarXml = new System.Windows.Forms.Button();
            this.txtCaminhoCertificado = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnVerificarAssinatura = new System.Windows.Forms.Button();
            this.btnCriptografar = new System.Windows.Forms.Button();
            this.btnDescriptografar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAssinarXml
            // 
            this.btnAssinarXml.Location = new System.Drawing.Point(37, 77);
            this.btnAssinarXml.Name = "btnAssinarXml";
            this.btnAssinarXml.Size = new System.Drawing.Size(147, 23);
            this.btnAssinarXml.TabIndex = 0;
            this.btnAssinarXml.Text = "Assinar XML";
            this.btnAssinarXml.UseVisualStyleBackColor = true;
            this.btnAssinarXml.Click += new System.EventHandler(this.btnAssinarXml_Click);
            // 
            // txtCaminhoCertificado
            // 
            this.txtCaminhoCertificado.Location = new System.Drawing.Point(37, 45);
            this.txtCaminhoCertificado.Name = "txtCaminhoCertificado";
            this.txtCaminhoCertificado.Size = new System.Drawing.Size(306, 20);
            this.txtCaminhoCertificado.TabIndex = 1;
            this.txtCaminhoCertificado.Text = "C:\\Users\\Diogo.DCBTOR\\Desktop\\MeuCert.pfx";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(349, 45);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(138, 20);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.Text = "senhaCert";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Local Certificado Digital (PFX)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(349, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Senha";
            // 
            // btnVerificarAssinatura
            // 
            this.btnVerificarAssinatura.Location = new System.Drawing.Point(193, 77);
            this.btnVerificarAssinatura.Name = "btnVerificarAssinatura";
            this.btnVerificarAssinatura.Size = new System.Drawing.Size(150, 23);
            this.btnVerificarAssinatura.TabIndex = 5;
            this.btnVerificarAssinatura.Text = "Verificar Assinatura";
            this.btnVerificarAssinatura.UseVisualStyleBackColor = true;
            this.btnVerificarAssinatura.Click += new System.EventHandler(this.btnVerificarAssinatura_Click);
            // 
            // btnCriptografar
            // 
            this.btnCriptografar.Location = new System.Drawing.Point(37, 126);
            this.btnCriptografar.Name = "btnCriptografar";
            this.btnCriptografar.Size = new System.Drawing.Size(147, 23);
            this.btnCriptografar.TabIndex = 6;
            this.btnCriptografar.Text = "Criptografar XML";
            this.btnCriptografar.UseVisualStyleBackColor = true;
            this.btnCriptografar.Click += new System.EventHandler(this.btnCriptografar_Click);
            // 
            // btnDescriptografar
            // 
            this.btnDescriptografar.Location = new System.Drawing.Point(193, 126);
            this.btnDescriptografar.Name = "btnDescriptografar";
            this.btnDescriptografar.Size = new System.Drawing.Size(150, 23);
            this.btnDescriptografar.TabIndex = 7;
            this.btnDescriptografar.Text = "Descriptografar XML";
            this.btnDescriptografar.UseVisualStyleBackColor = true;
            this.btnDescriptografar.Click += new System.EventHandler(this.btnDescriptografar_Click);
            // 
            // FrmAssinador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 234);
            this.Controls.Add(this.btnDescriptografar);
            this.Controls.Add(this.btnCriptografar);
            this.Controls.Add(this.btnVerificarAssinatura);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtCaminhoCertificado);
            this.Controls.Add(this.btnAssinarXml);
            this.Name = "FrmAssinador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAssinarXml;
        private System.Windows.Forms.TextBox txtCaminhoCertificado;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnVerificarAssinatura;
        private System.Windows.Forms.Button btnCriptografar;
        private System.Windows.Forms.Button btnDescriptografar;
    }
}

