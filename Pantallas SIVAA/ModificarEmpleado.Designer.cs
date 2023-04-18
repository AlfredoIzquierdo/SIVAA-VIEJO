namespace Pantallas_SIVAA
{
    partial class ModificarEmpleado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModificarEmpleado));
            pictureBox3 = new PictureBox();
            txtTelefono = new MaskedTextBox();
            pictureBox15 = new PictureBox();
            cbpuesto = new ComboBox();
            label4 = new Label();
            label1 = new Label();
            pictureBox13 = new PictureBox();
            pictureBox10 = new PictureBox();
            btnPedidos = new Button();
            imageList2 = new ImageList(components);
            btnCobros = new Button();
            btnVentas = new Button();
            btnStock = new Button();
            pictureBox4 = new PictureBox();
            pictureBox7 = new PictureBox();
            pictureBox6 = new PictureBox();
            pictureBox5 = new PictureBox();
            txtCorreo = new TextBox();
            txtContraseña = new TextBox();
            txtNombre = new TextBox();
            button3 = new Button();
            panel7 = new Panel();
            label8 = new Label();
            panel6 = new Panel();
            pictureBox8 = new PictureBox();
            label2 = new Label();
            label5 = new Label();
            label3 = new Label();
            label7 = new Label();
            btnReportes = new Button();
            btnCitas = new Button();
            panel1 = new Panel();
            txtRFC = new TextBox();
            panel2 = new Panel();
            txtApellidoM = new TextBox();
            txtApellidoP = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox15).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox13).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.FromArgb(232, 232, 232);
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(55, 147);
            pictureBox3.Margin = new Padding(2);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(30, 30);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 94;
            pictureBox3.TabStop = false;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(92, 195);
            txtTelefono.Mask = "000-000-0000";
            txtTelefono.Name = "txtTelefono";
            txtTelefono.PromptChar = '-';
            txtTelefono.Size = new Size(165, 22);
            txtTelefono.TabIndex = 93;
            // 
            // pictureBox15
            // 
            pictureBox15.BackColor = Color.FromArgb(232, 232, 232);
            pictureBox15.Image = (Image)resources.GetObject("pictureBox15.Image");
            pictureBox15.Location = new Point(54, 192);
            pictureBox15.Margin = new Padding(2);
            pictureBox15.Name = "pictureBox15";
            pictureBox15.Size = new Size(30, 30);
            pictureBox15.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox15.TabIndex = 92;
            pictureBox15.TabStop = false;
            // 
            // cbpuesto
            // 
            cbpuesto.AutoCompleteCustomSource.AddRange(new string[] { "Supervisor", "Vendedor", "Cajero", "Atencion a clientes" });
            cbpuesto.FormattingEnabled = true;
            cbpuesto.Items.AddRange(new object[] { "Supervisor", "Atencion", "Cajero" });
            cbpuesto.Location = new Point(92, 327);
            cbpuesto.Margin = new Padding(3, 2, 3, 2);
            cbpuesto.Name = "cbpuesto";
            cbpuesto.Size = new Size(167, 24);
            cbpuesto.TabIndex = 91;
            cbpuesto.Text = "Puesto";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(2742, 31);
            label4.Margin = new Padding(1, 0, 1, 0);
            label4.Name = "label4";
            label4.Size = new Size(0, 15);
            label4.TabIndex = 17;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(2742, 11);
            label1.Margin = new Padding(1, 0, 1, 0);
            label1.Name = "label1";
            label1.Size = new Size(0, 21);
            label1.TabIndex = 18;
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // pictureBox13
            // 
            pictureBox13.Image = (Image)resources.GetObject("pictureBox13.Image");
            pictureBox13.Location = new Point(15, 0);
            pictureBox13.Margin = new Padding(1, 2, 1, 2);
            pictureBox13.Name = "pictureBox13";
            pictureBox13.Size = new Size(46, 57);
            pictureBox13.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox13.TabIndex = 2;
            pictureBox13.TabStop = false;
            pictureBox13.Click += pictureBox13_Click;
            // 
            // pictureBox10
            // 
            pictureBox10.Image = (Image)resources.GetObject("pictureBox10.Image");
            pictureBox10.Location = new Point(63, 0);
            pictureBox10.Margin = new Padding(1, 2, 1, 2);
            pictureBox10.Name = "pictureBox10";
            pictureBox10.Size = new Size(46, 57);
            pictureBox10.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox10.TabIndex = 2;
            pictureBox10.TabStop = false;
            // 
            // btnPedidos
            // 
            btnPedidos.BackColor = Color.FromArgb(82, 101, 143);
            btnPedidos.FlatStyle = FlatStyle.Flat;
            btnPedidos.ForeColor = Color.White;
            btnPedidos.ImageAlign = ContentAlignment.TopCenter;
            btnPedidos.ImageKey = "package.png";
            btnPedidos.ImageList = imageList2;
            btnPedidos.Location = new Point(0, -2);
            btnPedidos.Margin = new Padding(2);
            btnPedidos.Name = "btnPedidos";
            btnPedidos.Size = new Size(71, 57);
            btnPedidos.TabIndex = 6;
            btnPedidos.Text = "Pedidos";
            btnPedidos.TextAlign = ContentAlignment.BottomCenter;
            btnPedidos.TextImageRelation = TextImageRelation.ImageAboveText;
            btnPedidos.UseVisualStyleBackColor = false;
            btnPedidos.Click += btnPedidos_Click;
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
            // 
            // btnCobros
            // 
            btnCobros.BackColor = Color.FromArgb(82, 101, 143);
            btnCobros.FlatStyle = FlatStyle.Flat;
            btnCobros.ForeColor = Color.White;
            btnCobros.ImageAlign = ContentAlignment.TopCenter;
            btnCobros.ImageKey = "dollar-sign.png";
            btnCobros.ImageList = imageList2;
            btnCobros.Location = new Point(0, 226);
            btnCobros.Margin = new Padding(2);
            btnCobros.Name = "btnCobros";
            btnCobros.Size = new Size(71, 57);
            btnCobros.TabIndex = 10;
            btnCobros.Text = "Cobros";
            btnCobros.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCobros.UseVisualStyleBackColor = false;
            btnCobros.Click += btnCobros_Click;
            // 
            // btnVentas
            // 
            btnVentas.BackColor = Color.FromArgb(82, 101, 143);
            btnVentas.FlatStyle = FlatStyle.Flat;
            btnVentas.ForeColor = Color.White;
            btnVentas.ImageAlign = ContentAlignment.TopCenter;
            btnVentas.ImageKey = "shopping-cart.png";
            btnVentas.ImageList = imageList2;
            btnVentas.Location = new Point(0, 169);
            btnVentas.Margin = new Padding(2);
            btnVentas.Name = "btnVentas";
            btnVentas.Size = new Size(71, 57);
            btnVentas.TabIndex = 9;
            btnVentas.Text = "Ventas";
            btnVentas.TextImageRelation = TextImageRelation.ImageAboveText;
            btnVentas.UseVisualStyleBackColor = false;
            btnVentas.Click += btnVentas_Click;
            // 
            // btnStock
            // 
            btnStock.BackColor = Color.FromArgb(82, 101, 143);
            btnStock.FlatStyle = FlatStyle.Flat;
            btnStock.ForeColor = Color.White;
            btnStock.ImageAlign = ContentAlignment.TopCenter;
            btnStock.ImageKey = "book-open.png";
            btnStock.ImageList = imageList2;
            btnStock.Location = new Point(0, 55);
            btnStock.Margin = new Padding(2);
            btnStock.Name = "btnStock";
            btnStock.Size = new Size(71, 57);
            btnStock.TabIndex = 7;
            btnStock.Text = "Stock";
            btnStock.TextImageRelation = TextImageRelation.ImageAboveText;
            btnStock.UseVisualStyleBackColor = false;
            btnStock.Click += btnStock_Click;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.FromArgb(232, 232, 232);
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(54, 325);
            pictureBox4.Margin = new Padding(2);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(30, 30);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 85;
            pictureBox4.TabStop = false;
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = Color.FromArgb(232, 232, 232);
            pictureBox7.Image = (Image)resources.GetObject("pictureBox7.Image");
            pictureBox7.Location = new Point(54, 283);
            pictureBox7.Margin = new Padding(2);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(30, 30);
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.TabIndex = 86;
            pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            pictureBox6.BackColor = Color.FromArgb(232, 232, 232);
            pictureBox6.Image = Properties.Resources.Can;
            pictureBox6.Location = new Point(54, 239);
            pictureBox6.Margin = new Padding(2);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(30, 30);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 87;
            pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.FromArgb(232, 232, 232);
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(55, 44);
            pictureBox5.Margin = new Padding(2);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(30, 30);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 89;
            pictureBox5.TabStop = false;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(94, 150);
            txtCorreo.Margin = new Padding(2);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.PlaceholderText = "Agregar correo";
            txtCorreo.Size = new Size(362, 22);
            txtCorreo.TabIndex = 81;
            // 
            // txtContraseña
            // 
            txtContraseña.Location = new Point(92, 243);
            txtContraseña.Margin = new Padding(2);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.PlaceholderText = "*************";
            txtContraseña.Size = new Size(167, 22);
            txtContraseña.TabIndex = 83;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(93, 48);
            txtNombre.Margin = new Padding(2);
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "Nombre";
            txtNombre.Size = new Size(363, 22);
            txtNombre.TabIndex = 82;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(51, 58, 86);
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Century", 10F, FontStyle.Regular, GraphicsUnit.Point);
            button3.ForeColor = Color.White;
            button3.Location = new Point(301, 211);
            button3.Margin = new Padding(2);
            button3.Name = "button3";
            button3.Size = new Size(154, 25);
            button3.TabIndex = 80;
            button3.Text = "Actualizar";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
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
            panel7.Name = "panel7";
            panel7.Size = new Size(682, 57);
            panel7.TabIndex = 78;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(190, 19);
            label8.Margin = new Padding(1, 0, 1, 0);
            label8.Name = "label8";
            label8.Size = new Size(229, 32);
            label8.TabIndex = 95;
            label8.Text = "Modificar empleado";
            // 
            // panel6
            // 
            panel6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel6.BackColor = Color.Transparent;
            panel6.Controls.Add(pictureBox8);
            panel6.Controls.Add(label2);
            panel6.Controls.Add(label5);
            panel6.Location = new Point(480, -1);
            panel6.Margin = new Padding(2);
            panel6.Name = "panel6";
            panel6.Size = new Size(179, 68);
            panel6.TabIndex = 20;
            // 
            // pictureBox8
            // 
            pictureBox8.Image = (Image)resources.GetObject("pictureBox8.Image");
            pictureBox8.Location = new Point(0, 15);
            pictureBox8.Margin = new Padding(2);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(43, 41);
            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox8.TabIndex = 2;
            pictureBox8.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(43, 20);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(127, 19);
            label2.TabIndex = 1;
            label2.Text = "Bienvenido: Alfredo";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(45, 37);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(61, 13);
            label5.TabIndex = 1;
            label5.Text = "Supervisor";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(2370, 11);
            label3.Margin = new Padding(1, 0, 1, 0);
            label3.Name = "label3";
            label3.Size = new Size(0, 32);
            label3.TabIndex = 19;
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(107, 15);
            label7.Name = "label7";
            label7.Size = new Size(80, 27);
            label7.TabIndex = 16;
            label7.Text = "SIVAA";
            // 
            // btnReportes
            // 
            btnReportes.BackColor = Color.FromArgb(82, 101, 143);
            btnReportes.FlatStyle = FlatStyle.Flat;
            btnReportes.ForeColor = Color.White;
            btnReportes.ImageAlign = ContentAlignment.TopCenter;
            btnReportes.ImageKey = "bar-chart.png";
            btnReportes.ImageList = imageList2;
            btnReportes.Location = new Point(0, 283);
            btnReportes.Margin = new Padding(2);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(71, 57);
            btnReportes.TabIndex = 11;
            btnReportes.Text = "Reportes";
            btnReportes.TextImageRelation = TextImageRelation.ImageAboveText;
            btnReportes.UseVisualStyleBackColor = false;
            btnReportes.Click += btnReportes_Click;
            // 
            // btnCitas
            // 
            btnCitas.BackColor = Color.FromArgb(82, 101, 143);
            btnCitas.FlatStyle = FlatStyle.Flat;
            btnCitas.ForeColor = Color.White;
            btnCitas.ImageAlign = ContentAlignment.TopCenter;
            btnCitas.ImageKey = "calendar.png";
            btnCitas.ImageList = imageList2;
            btnCitas.Location = new Point(0, 112);
            btnCitas.Margin = new Padding(2);
            btnCitas.Name = "btnCitas";
            btnCitas.Size = new Size(71, 57);
            btnCitas.TabIndex = 8;
            btnCitas.Text = "Citas";
            btnCitas.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCitas.UseVisualStyleBackColor = false;
            btnCitas.Click += btnCitas_Click;
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
            panel1.Location = new Point(0, 62);
            panel1.Margin = new Padding(1, 2, 1, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(73, 438);
            panel1.TabIndex = 77;
            // 
            // txtRFC
            // 
            txtRFC.Location = new Point(94, 289);
            txtRFC.Margin = new Padding(2);
            txtRFC.Name = "txtRFC";
            txtRFC.PlaceholderText = "RFC";
            txtRFC.Size = new Size(167, 22);
            txtRFC.TabIndex = 83;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.None;
            panel2.Controls.Add(txtApellidoM);
            panel2.Controls.Add(txtApellidoP);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(pictureBox3);
            panel2.Controls.Add(txtContraseña);
            panel2.Controls.Add(txtTelefono);
            panel2.Controls.Add(pictureBox15);
            panel2.Controls.Add(cbpuesto);
            panel2.Controls.Add(txtNombre);
            panel2.Controls.Add(txtRFC);
            panel2.Controls.Add(pictureBox4);
            panel2.Controls.Add(txtCorreo);
            panel2.Controls.Add(pictureBox7);
            panel2.Controls.Add(pictureBox5);
            panel2.Controls.Add(pictureBox6);
            panel2.Font = new Font("Century", 9F, FontStyle.Regular, GraphicsUnit.Point);
            panel2.Location = new Point(77, 62);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(593, 427);
            panel2.TabIndex = 95;
            // 
            // txtApellidoM
            // 
            txtApellidoM.Location = new Point(92, 111);
            txtApellidoM.Margin = new Padding(2);
            txtApellidoM.Name = "txtApellidoM";
            txtApellidoM.PlaceholderText = "Apellido Materno";
            txtApellidoM.Size = new Size(363, 22);
            txtApellidoM.TabIndex = 96;
            // 
            // txtApellidoP
            // 
            txtApellidoP.Location = new Point(93, 79);
            txtApellidoP.Margin = new Padding(2);
            txtApellidoP.Name = "txtApellidoP";
            txtApellidoP.PlaceholderText = "Apellido Paterno";
            txtApellidoP.Size = new Size(363, 22);
            txtApellidoP.TabIndex = 95;
            // 
            // ModificarEmpleado
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(682, 500);
            Controls.Add(panel2);
            Controls.Add(panel7);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ModificarEmpleado";
            Text = "ModificarEmpleado";
            WindowState = FormWindowState.Maximized;
            Load += ModificarEmpleado_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox15).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox13).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox3;
        private MaskedTextBox txtTelefono;
        private PictureBox pictureBox15;
        private ComboBox cbpuesto;
        private Label label4;
        private Label label1;
        private PictureBox pictureBox13;
        private PictureBox pictureBox10;
        private Button btnPedidos;
        private ImageList imageList2;
        private Button btnCobros;
        private Button btnVentas;
        private Button btnStock;
        private PictureBox pictureBox4;
        private PictureBox pictureBox7;
        private PictureBox pictureBox6;
        private PictureBox pictureBox5;
        private TextBox txtCorreo;
        private TextBox txtContraseña;
        private TextBox txtNombre;
        private Button button3;
        private Panel panel7;
        private Label label3;
        private Label label7;
        private Button btnReportes;
        private Button btnCitas;
        private Panel panel1;
        private TextBox txtRFC;
        private Panel panel2;
        private Panel panel6;
        private PictureBox pictureBox8;
        private Label label2;
        private Label label5;
        private Label label8;
        private TextBox txtApellidoM;
        private TextBox txtApellidoP;
    }
}