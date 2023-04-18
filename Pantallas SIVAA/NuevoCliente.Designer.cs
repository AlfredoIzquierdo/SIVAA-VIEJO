namespace Pantallas_SIVAA
{
    partial class NuevoCliente
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NuevoCliente));
            panel2 = new Panel();
            button3 = new Button();
            pictureBox3 = new PictureBox();
            txtCiudad = new TextBox();
            txtEstado = new TextBox();
            txtColonia = new TextBox();
            txtNoExterior = new TextBox();
            txtAgregarCorreo = new TextBox();
            mtxtTelefono = new MaskedTextBox();
            pictureBox15 = new PictureBox();
            txtApellidoMat = new TextBox();
            txtApellidoPat = new TextBox();
            txtNombreCliente = new TextBox();
            txtRfc = new TextBox();
            pictureBox7 = new PictureBox();
            pictureBox5 = new PictureBox();
            panel1 = new Panel();
            btnReportes = new Button();
            imageList2 = new ImageList(components);
            btnCobros = new Button();
            btnVentas = new Button();
            btnCitas = new Button();
            btnStock = new Button();
            btnPedidos = new Button();
            panel7 = new Panel();
            label8 = new Label();
            panel6 = new Panel();
            pictureBox8 = new PictureBox();
            label2 = new Label();
            label5 = new Label();
            label3 = new Label();
            label4 = new Label();
            label1 = new Label();
            label7 = new Label();
            pictureBox13 = new PictureBox();
            pictureBox10 = new PictureBox();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox15).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            panel1.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox13).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.None;
            panel2.Controls.Add(button3);
            panel2.Controls.Add(pictureBox3);
            panel2.Controls.Add(txtCiudad);
            panel2.Controls.Add(txtEstado);
            panel2.Controls.Add(txtColonia);
            panel2.Controls.Add(txtNoExterior);
            panel2.Controls.Add(txtAgregarCorreo);
            panel2.Controls.Add(mtxtTelefono);
            panel2.Controls.Add(pictureBox15);
            panel2.Controls.Add(txtApellidoMat);
            panel2.Controls.Add(txtApellidoPat);
            panel2.Controls.Add(txtNombreCliente);
            panel2.Controls.Add(txtRfc);
            panel2.Controls.Add(pictureBox7);
            panel2.Controls.Add(pictureBox5);
            panel2.Font = new Font("Century", 9F, FontStyle.Regular, GraphicsUnit.Point);
            panel2.Location = new Point(95, 92);
            panel2.Name = "panel2";
            panel2.Size = new Size(643, 477);
            panel2.TabIndex = 80;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(51, 58, 86);
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Century", 10F, FontStyle.Regular, GraphicsUnit.Point);
            button3.ForeColor = Color.White;
            button3.Location = new Point(246, 381);
            button3.Margin = new Padding(2, 3, 2, 3);
            button3.Name = "button3";
            button3.Size = new Size(176, 35);
            button3.TabIndex = 11;
            button3.Text = "Guardar";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.FromArgb(232, 232, 232);
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(80, 157);
            pictureBox3.Margin = new Padding(2, 3, 2, 3);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(34, 40);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 76;
            pictureBox3.TabStop = false;
            // 
            // txtCiudad
            // 
            txtCiudad.Location = new Point(298, 331);
            txtCiudad.Margin = new Padding(2, 3, 2, 3);
            txtCiudad.Name = "txtCiudad";
            txtCiudad.PlaceholderText = "Ciudad";
            txtCiudad.Size = new Size(263, 26);
            txtCiudad.TabIndex = 10;
            // 
            // txtEstado
            // 
            txtEstado.Location = new Point(82, 331);
            txtEstado.Margin = new Padding(2, 3, 2, 3);
            txtEstado.Name = "txtEstado";
            txtEstado.PlaceholderText = "Estado";
            txtEstado.Size = new Size(199, 26);
            txtEstado.TabIndex = 9;
            // 
            // txtColonia
            // 
            txtColonia.Location = new Point(298, 287);
            txtColonia.Margin = new Padding(2, 3, 2, 3);
            txtColonia.Name = "txtColonia";
            txtColonia.PlaceholderText = "Colonia";
            txtColonia.Size = new Size(263, 26);
            txtColonia.TabIndex = 8;
            // 
            // txtNoExterior
            // 
            txtNoExterior.Location = new Point(82, 287);
            txtNoExterior.Margin = new Padding(2, 3, 2, 3);
            txtNoExterior.MaxLength = 3;
            txtNoExterior.Name = "txtNoExterior";
            txtNoExterior.PlaceholderText = "No. exterior";
            txtNoExterior.Size = new Size(199, 26);
            txtNoExterior.TabIndex = 7;
            // 
            // txtAgregarCorreo
            // 
            txtAgregarCorreo.Location = new Point(123, 161);
            txtAgregarCorreo.Margin = new Padding(2, 3, 2, 3);
            txtAgregarCorreo.Name = "txtAgregarCorreo";
            txtAgregarCorreo.PlaceholderText = "Agregar correo";
            txtAgregarCorreo.Size = new Size(437, 26);
            txtAgregarCorreo.TabIndex = 4;
            // 
            // mtxtTelefono
            // 
            mtxtTelefono.Location = new Point(122, 221);
            mtxtTelefono.Margin = new Padding(3, 4, 3, 4);
            mtxtTelefono.Mask = "000-000-0000";
            mtxtTelefono.Name = "mtxtTelefono";
            mtxtTelefono.PromptChar = '-';
            mtxtTelefono.Size = new Size(188, 26);
            mtxtTelefono.TabIndex = 5;
            // 
            // pictureBox15
            // 
            pictureBox15.BackColor = Color.FromArgb(232, 232, 232);
            pictureBox15.Image = (Image)resources.GetObject("pictureBox15.Image");
            pictureBox15.Location = new Point(79, 217);
            pictureBox15.Margin = new Padding(2, 3, 2, 3);
            pictureBox15.Name = "pictureBox15";
            pictureBox15.Size = new Size(34, 40);
            pictureBox15.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox15.TabIndex = 74;
            pictureBox15.TabStop = false;
            // 
            // txtApellidoMat
            // 
            txtApellidoMat.Location = new Point(123, 109);
            txtApellidoMat.Margin = new Padding(2, 3, 2, 3);
            txtApellidoMat.Name = "txtApellidoMat";
            txtApellidoMat.PlaceholderText = "Apellido materno";
            txtApellidoMat.Size = new Size(438, 26);
            txtApellidoMat.TabIndex = 3;
            // 
            // txtApellidoPat
            // 
            txtApellidoPat.Location = new Point(123, 67);
            txtApellidoPat.Margin = new Padding(2, 3, 2, 3);
            txtApellidoPat.Name = "txtApellidoPat";
            txtApellidoPat.PlaceholderText = "Apellido paterno";
            txtApellidoPat.Size = new Size(438, 26);
            txtApellidoPat.TabIndex = 2;
            // 
            // txtNombreCliente
            // 
            txtNombreCliente.Location = new Point(123, 24);
            txtNombreCliente.Margin = new Padding(2, 3, 2, 3);
            txtNombreCliente.Name = "txtNombreCliente";
            txtNombreCliente.PlaceholderText = "Nombre del cliente";
            txtNombreCliente.Size = new Size(438, 26);
            txtNombreCliente.TabIndex = 1;
            // 
            // txtRfc
            // 
            txtRfc.Location = new Point(370, 221);
            txtRfc.Margin = new Padding(2, 3, 2, 3);
            txtRfc.MaxLength = 13;
            txtRfc.Name = "txtRfc";
            txtRfc.PlaceholderText = "RFC";
            txtRfc.Size = new Size(190, 26);
            txtRfc.TabIndex = 6;
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = Color.FromArgb(232, 232, 232);
            pictureBox7.Image = (Image)resources.GetObject("pictureBox7.Image");
            pictureBox7.Location = new Point(325, 213);
            pictureBox7.Margin = new Padding(2, 3, 2, 3);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(34, 40);
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.TabIndex = 68;
            pictureBox7.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.FromArgb(232, 232, 232);
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(81, 20);
            pictureBox5.Margin = new Padding(2, 3, 2, 3);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(34, 40);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 70;
            pictureBox5.TabStop = false;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel1.BackColor = Color.FromArgb(82, 101, 143);
            panel1.Controls.Add(btnReportes);
            panel1.Controls.Add(btnCobros);
            panel1.Controls.Add(btnVentas);
            panel1.Controls.Add(btnCitas);
            panel1.Controls.Add(btnStock);
            panel1.Controls.Add(btnPedidos);
            panel1.Location = new Point(5, 77);
            panel1.Margin = new Padding(1, 3, 1, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(82, 480);
            panel1.TabIndex = 78;
            // 
            // btnReportes
            // 
            btnReportes.BackColor = Color.FromArgb(82, 101, 143);
            btnReportes.FlatStyle = FlatStyle.Flat;
            btnReportes.ForeColor = Color.White;
            btnReportes.ImageAlign = ContentAlignment.TopCenter;
            btnReportes.ImageKey = "bar-chart.png";
            btnReportes.ImageList = imageList2;
            btnReportes.Location = new Point(0, 377);
            btnReportes.Margin = new Padding(2, 3, 2, 3);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(80, 76);
            btnReportes.TabIndex = 11;
            btnReportes.Text = "Reportes";
            btnReportes.TextAlign = ContentAlignment.BottomCenter;
            btnReportes.TextImageRelation = TextImageRelation.ImageAboveText;
            btnReportes.UseVisualStyleBackColor = false;
            // 
            // imageList2
            // 
            imageList2.ColorDepth = ColorDepth.Depth8Bit;
            imageList2.ImageStream = (ImageListStreamer)resources.GetObject("imageList2.ImageStream");
            imageList2.TransparentColor = Color.Transparent;
            imageList2.Images.SetKeyName(0, "archive.png");
            imageList2.Images.SetKeyName(1, "bar-chart.png");
            imageList2.Images.SetKeyName(2, "book-open.png");
            imageList2.Images.SetKeyName(3, "calendar.png");
            imageList2.Images.SetKeyName(4, "dollar-sign.png");
            imageList2.Images.SetKeyName(5, "package.png");
            imageList2.Images.SetKeyName(6, "shopping-cart.png");
            imageList2.Images.SetKeyName(7, "Calle.png");
            // 
            // btnCobros
            // 
            btnCobros.BackColor = Color.FromArgb(82, 101, 143);
            btnCobros.FlatStyle = FlatStyle.Flat;
            btnCobros.ForeColor = Color.White;
            btnCobros.ImageAlign = ContentAlignment.TopCenter;
            btnCobros.ImageKey = "dollar-sign.png";
            btnCobros.ImageList = imageList2;
            btnCobros.Location = new Point(0, 301);
            btnCobros.Margin = new Padding(2, 3, 2, 3);
            btnCobros.Name = "btnCobros";
            btnCobros.Size = new Size(80, 76);
            btnCobros.TabIndex = 10;
            btnCobros.Text = "Cobros";
            btnCobros.TextAlign = ContentAlignment.BottomCenter;
            btnCobros.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCobros.UseVisualStyleBackColor = false;
            // 
            // btnVentas
            // 
            btnVentas.BackColor = Color.FromArgb(82, 101, 143);
            btnVentas.FlatStyle = FlatStyle.Flat;
            btnVentas.ForeColor = Color.White;
            btnVentas.ImageAlign = ContentAlignment.TopCenter;
            btnVentas.ImageKey = "shopping-cart.png";
            btnVentas.ImageList = imageList2;
            btnVentas.Location = new Point(0, 225);
            btnVentas.Margin = new Padding(2, 3, 2, 3);
            btnVentas.Name = "btnVentas";
            btnVentas.Size = new Size(80, 76);
            btnVentas.TabIndex = 9;
            btnVentas.Text = "Ventas";
            btnVentas.TextAlign = ContentAlignment.BottomCenter;
            btnVentas.TextImageRelation = TextImageRelation.ImageAboveText;
            btnVentas.UseVisualStyleBackColor = false;
            // 
            // btnCitas
            // 
            btnCitas.BackColor = Color.FromArgb(82, 101, 143);
            btnCitas.FlatStyle = FlatStyle.Flat;
            btnCitas.ForeColor = Color.White;
            btnCitas.ImageAlign = ContentAlignment.TopCenter;
            btnCitas.ImageKey = "calendar.png";
            btnCitas.ImageList = imageList2;
            btnCitas.Location = new Point(0, 149);
            btnCitas.Margin = new Padding(2, 3, 2, 3);
            btnCitas.Name = "btnCitas";
            btnCitas.Size = new Size(80, 76);
            btnCitas.TabIndex = 8;
            btnCitas.Text = "Citas";
            btnCitas.TextAlign = ContentAlignment.BottomCenter;
            btnCitas.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCitas.UseVisualStyleBackColor = false;
            // 
            // btnStock
            // 
            btnStock.BackColor = Color.FromArgb(82, 101, 143);
            btnStock.FlatStyle = FlatStyle.Flat;
            btnStock.ForeColor = Color.White;
            btnStock.ImageAlign = ContentAlignment.TopCenter;
            btnStock.ImageKey = "book-open.png";
            btnStock.ImageList = imageList2;
            btnStock.Location = new Point(0, 73);
            btnStock.Margin = new Padding(2, 3, 2, 3);
            btnStock.Name = "btnStock";
            btnStock.Size = new Size(80, 76);
            btnStock.TabIndex = 7;
            btnStock.Text = "Stock";
            btnStock.TextAlign = ContentAlignment.BottomCenter;
            btnStock.TextImageRelation = TextImageRelation.ImageAboveText;
            btnStock.UseVisualStyleBackColor = false;
            // 
            // btnPedidos
            // 
            btnPedidos.BackColor = Color.FromArgb(82, 101, 143);
            btnPedidos.FlatStyle = FlatStyle.Flat;
            btnPedidos.ForeColor = Color.White;
            btnPedidos.ImageAlign = ContentAlignment.TopCenter;
            btnPedidos.ImageKey = "package.png";
            btnPedidos.ImageList = imageList2;
            btnPedidos.Location = new Point(0, -3);
            btnPedidos.Margin = new Padding(2, 3, 2, 3);
            btnPedidos.Name = "btnPedidos";
            btnPedidos.Size = new Size(80, 76);
            btnPedidos.TabIndex = 6;
            btnPedidos.Text = "Pedidos";
            btnPedidos.TextAlign = ContentAlignment.BottomCenter;
            btnPedidos.TextImageRelation = TextImageRelation.ImageAboveText;
            btnPedidos.UseVisualStyleBackColor = false;
            // 
            // panel7
            // 
            panel7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel7.BackColor = Color.FromArgb(51, 58, 86);
            panel7.Controls.Add(label8);
            panel7.Controls.Add(panel6);
            panel7.Controls.Add(label3);
            panel7.Controls.Add(label4);
            panel7.Controls.Add(label1);
            panel7.Controls.Add(label7);
            panel7.Controls.Add(pictureBox13);
            panel7.Controls.Add(pictureBox10);
            panel7.ForeColor = Color.White;
            panel7.Location = new Point(0, 0);
            panel7.Margin = new Padding(3, 4, 3, 4);
            panel7.Name = "panel7";
            panel7.Size = new Size(766, 76);
            panel7.TabIndex = 79;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(267, 21);
            label8.Margin = new Padding(1, 0, 1, 0);
            label8.Name = "label8";
            label8.Size = new Size(200, 41);
            label8.TabIndex = 77;
            label8.Text = "Nuevo cliente";
            // 
            // panel6
            // 
            panel6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel6.BackColor = Color.Transparent;
            panel6.Controls.Add(pictureBox8);
            panel6.Controls.Add(label2);
            panel6.Controls.Add(label5);
            panel6.Location = new Point(1190, 3);
            panel6.Margin = new Padding(2, 3, 2, 3);
            panel6.Name = "panel6";
            panel6.Size = new Size(207, 91);
            panel6.TabIndex = 21;
            // 
            // pictureBox8
            // 
            pictureBox8.Image = (Image)resources.GetObject("pictureBox8.Image");
            pictureBox8.Location = new Point(0, 20);
            pictureBox8.Margin = new Padding(2, 3, 2, 3);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(49, 55);
            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox8.TabIndex = 2;
            pictureBox8.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(49, 27);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(158, 23);
            label2.TabIndex = 1;
            label2.Text = "Bienvenido: Alfredo";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(51, 49);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(73, 19);
            label5.TabIndex = 1;
            label5.Text = "Supervisor";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(2959, 15);
            label3.Margin = new Padding(1, 0, 1, 0);
            label3.Name = "label3";
            label3.Size = new Size(0, 41);
            label3.TabIndex = 19;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(3385, 41);
            label4.Margin = new Padding(1, 0, 1, 0);
            label4.Name = "label4";
            label4.Size = new Size(0, 20);
            label4.TabIndex = 17;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(3385, 15);
            label1.Margin = new Padding(1, 0, 1, 0);
            label1.Name = "label1";
            label1.Size = new Size(0, 28);
            label1.TabIndex = 18;
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(122, 20);
            label7.Name = "label7";
            label7.Size = new Size(109, 36);
            label7.TabIndex = 16;
            label7.Text = "SIVAA";
            // 
            // pictureBox13
            // 
            pictureBox13.Image = (Image)resources.GetObject("pictureBox13.Image");
            pictureBox13.Location = new Point(17, 0);
            pictureBox13.Margin = new Padding(1, 3, 1, 3);
            pictureBox13.Name = "pictureBox13";
            pictureBox13.Size = new Size(53, 76);
            pictureBox13.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox13.TabIndex = 2;
            pictureBox13.TabStop = false;
            // 
            // pictureBox10
            // 
            pictureBox10.Image = (Image)resources.GetObject("pictureBox10.Image");
            pictureBox10.Location = new Point(72, 0);
            pictureBox10.Margin = new Padding(1, 3, 1, 3);
            pictureBox10.Name = "pictureBox10";
            pictureBox10.Size = new Size(53, 76);
            pictureBox10.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox10.TabIndex = 2;
            pictureBox10.TabStop = false;
            // 
            // NuevoCliente
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(766, 567);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panel7);
            Margin = new Padding(2, 3, 2, 3);
            Name = "NuevoCliente";
            Text = "NuevoCliente";
            WindowState = FormWindowState.Maximized;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox15).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            panel1.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox13).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Button button3;
        private PictureBox pictureBox3;
        private TextBox txtAgregarCorreo;
        private MaskedTextBox mtxtTelefono;
        private PictureBox pictureBox15;
        private TextBox txtNombreCliente;
        private TextBox txtRfc;
        private PictureBox pictureBox7;
        private PictureBox pictureBox5;
        private Panel panel1;
        private Button btnReportes;
        private Button btnCobros;
        private Button btnVentas;
        private Button btnCitas;
        private Button btnStock;
        private Button btnPedidos;
        private Panel panel7;
        private Label label8;
        private Panel panel6;
        private PictureBox pictureBox8;
        private Label label2;
        private Label label5;
        private Label label3;
        private Label label4;
        private Label label1;
        private Label label7;
        private PictureBox pictureBox13;
        private PictureBox pictureBox10;
        private ImageList imageList2;
        private TextBox txtCiudad;
        private TextBox txtEstado;
        private TextBox txtColonia;
        private TextBox txtNoExterior;
        private TextBox txtApellidoMat;
        private TextBox txtApellidoPat;
    }
}