namespace Pantallas_SIVAA
{
    partial class Inicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            pictureBox13 = new PictureBox();
            label7 = new Label();
            lblNombre = new Label();
            panel7 = new Panel();
            label1 = new Label();
            lblTipoEmpleado = new Label();
            panel1 = new Panel();
            btnReportes = new Button();
            imageList2 = new ImageList(components);
            btnCobros = new Button();
            btnVentas = new Button();
            btnCitas = new Button();
            btnStock = new Button();
            btnPedidos = new Button();
            btnVersiones = new Button();
            imageList1 = new ImageList(components);
            btnEmpleados = new Button();
            btnCotizacion = new Button();
            btnVehículos = new Button();
            btnClientes = new Button();
            btnProveedor = new Button();
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox13).BeginInit();
            panel7.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox13
            // 
            pictureBox13.Image = (Image)resources.GetObject("pictureBox13.Image");
            pictureBox13.Location = new Point(21, 12);
            pictureBox13.Margin = new Padding(1, 3, 1, 3);
            pictureBox13.Name = "pictureBox13";
            pictureBox13.Size = new Size(66, 67);
            pictureBox13.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox13.TabIndex = 2;
            pictureBox13.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(161, 25);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(115, 45);
            label7.TabIndex = 16;
            label7.Text = "SIVAA";
            // 
            // lblNombre
            // 
            lblNombre.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblNombre.Location = new Point(806, 15);
            lblNombre.Margin = new Padding(1, 0, 1, 0);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(255, 32);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Bienvenido: Fulanito";
            lblNombre.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel7
            // 
            panel7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel7.BackColor = Color.FromArgb(51, 58, 86);
            panel7.Controls.Add(label1);
            panel7.Controls.Add(lblTipoEmpleado);
            panel7.Controls.Add(lblNombre);
            panel7.Controls.Add(label7);
            panel7.Controls.Add(pictureBox13);
            panel7.ForeColor = Color.White;
            panel7.Location = new Point(0, -3);
            panel7.Margin = new Padding(4, 5, 4, 5);
            panel7.Name = "panel7";
            panel7.Size = new Size(1109, 95);
            panel7.TabIndex = 36;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(529, 22);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(106, 48);
            label1.TabIndex = 17;
            label1.Text = "Inicio";
            // 
            // lblTipoEmpleado
            // 
            lblTipoEmpleado.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTipoEmpleado.AutoSize = true;
            lblTipoEmpleado.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblTipoEmpleado.Location = new Point(889, 57);
            lblTipoEmpleado.Margin = new Padding(1, 0, 1, 0);
            lblTipoEmpleado.Name = "lblTipoEmpleado";
            lblTipoEmpleado.Size = new Size(96, 25);
            lblTipoEmpleado.TabIndex = 1;
            lblTipoEmpleado.Text = "Supervisor";
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
            panel1.Location = new Point(0, 93);
            panel1.Margin = new Padding(1, 3, 1, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(94, 607);
            panel1.TabIndex = 35;
            // 
            // btnReportes
            // 
            btnReportes.BackColor = Color.FromArgb(82, 101, 143);
            btnReportes.FlatStyle = FlatStyle.Flat;
            btnReportes.ForeColor = Color.White;
            btnReportes.ImageAlign = ContentAlignment.TopCenter;
            btnReportes.ImageKey = "bar-chart.png";
            btnReportes.ImageList = imageList2;
            btnReportes.Location = new Point(0, 480);
            btnReportes.Margin = new Padding(1, 3, 1, 3);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(101, 95);
            btnReportes.TabIndex = 10;
            btnReportes.Text = "Reportes";
            btnReportes.TextImageRelation = TextImageRelation.ImageAboveText;
            btnReportes.UseVisualStyleBackColor = false;
            btnReportes.Click += btnReportes_Click;
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
            btnCobros.Location = new Point(0, 383);
            btnCobros.Margin = new Padding(1, 3, 1, 3);
            btnCobros.Name = "btnCobros";
            btnCobros.Size = new Size(101, 95);
            btnCobros.TabIndex = 9;
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
            btnVentas.Location = new Point(0, 287);
            btnVentas.Margin = new Padding(1, 3, 1, 3);
            btnVentas.Name = "btnVentas";
            btnVentas.Size = new Size(101, 95);
            btnVentas.TabIndex = 8;
            btnVentas.Text = "Ventas";
            btnVentas.TextImageRelation = TextImageRelation.ImageAboveText;
            btnVentas.UseVisualStyleBackColor = false;
            btnVentas.Click += btnVentas_Click;
            // 
            // btnCitas
            // 
            btnCitas.BackColor = Color.FromArgb(82, 101, 143);
            btnCitas.FlatStyle = FlatStyle.Flat;
            btnCitas.ForeColor = Color.White;
            btnCitas.ImageAlign = ContentAlignment.TopCenter;
            btnCitas.ImageKey = "calendar.png";
            btnCitas.ImageList = imageList2;
            btnCitas.Location = new Point(0, 193);
            btnCitas.Margin = new Padding(1, 3, 1, 3);
            btnCitas.Name = "btnCitas";
            btnCitas.Size = new Size(101, 95);
            btnCitas.TabIndex = 7;
            btnCitas.Text = "Citas";
            btnCitas.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCitas.UseVisualStyleBackColor = false;
            btnCitas.Click += btnCitas_Click;
            // 
            // btnStock
            // 
            btnStock.BackColor = Color.FromArgb(82, 101, 143);
            btnStock.FlatStyle = FlatStyle.Flat;
            btnStock.ForeColor = Color.White;
            btnStock.ImageAlign = ContentAlignment.TopCenter;
            btnStock.ImageKey = "book-open.png";
            btnStock.ImageList = imageList2;
            btnStock.Location = new Point(-20, 95);
            btnStock.Margin = new Padding(1, 3, 1, 3);
            btnStock.Name = "btnStock";
            btnStock.Size = new Size(141, 107);
            btnStock.TabIndex = 6;
            btnStock.Text = "Inventario";
            btnStock.TextImageRelation = TextImageRelation.ImageAboveText;
            btnStock.UseVisualStyleBackColor = false;
            btnStock.Click += btnStock_Click;
            // 
            // btnPedidos
            // 
            btnPedidos.BackColor = Color.FromArgb(82, 101, 143);
            btnPedidos.FlatStyle = FlatStyle.Flat;
            btnPedidos.ForeColor = Color.White;
            btnPedidos.ImageAlign = ContentAlignment.TopCenter;
            btnPedidos.ImageKey = "package.png";
            btnPedidos.ImageList = imageList2;
            btnPedidos.Location = new Point(0, 3);
            btnPedidos.Margin = new Padding(1, 3, 1, 3);
            btnPedidos.Name = "btnPedidos";
            btnPedidos.Size = new Size(101, 95);
            btnPedidos.TabIndex = 5;
            btnPedidos.Text = "Pedidos";
            btnPedidos.TextImageRelation = TextImageRelation.ImageAboveText;
            btnPedidos.UseVisualStyleBackColor = false;
            btnPedidos.Click += btnPedidos_Click;
            // 
            // btnVersiones
            // 
            btnVersiones.BackColor = Color.FromArgb(232, 232, 232);
            btnVersiones.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnVersiones.ImageAlign = ContentAlignment.TopCenter;
            btnVersiones.ImageKey = "Tipos.png";
            btnVersiones.ImageList = imageList1;
            btnVersiones.Location = new Point(351, 37);
            btnVersiones.Margin = new Padding(4, 3, 4, 3);
            btnVersiones.Name = "btnVersiones";
            btnVersiones.Size = new Size(246, 158);
            btnVersiones.TabIndex = 52;
            btnVersiones.Text = "Versiones";
            btnVersiones.TextAlign = ContentAlignment.BottomCenter;
            btnVersiones.UseVisualStyleBackColor = false;
            btnVersiones.Click += btnVersiones_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "Auto.png");
            imageList1.Images.SetKeyName(1, "Cli.png");
            imageList1.Images.SetKeyName(2, "EMP.png");
            imageList1.Images.SetKeyName(3, "Prov.png");
            imageList1.Images.SetKeyName(4, "Tipos.png");
            imageList1.Images.SetKeyName(5, "Cot.png");
            // 
            // btnEmpleados
            // 
            btnEmpleados.BackColor = Color.FromArgb(232, 232, 232);
            btnEmpleados.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnEmpleados.ImageAlign = ContentAlignment.TopCenter;
            btnEmpleados.ImageKey = "EMP.png";
            btnEmpleados.ImageList = imageList1;
            btnEmpleados.Location = new Point(684, 33);
            btnEmpleados.Margin = new Padding(4, 3, 4, 3);
            btnEmpleados.Name = "btnEmpleados";
            btnEmpleados.Size = new Size(246, 158);
            btnEmpleados.TabIndex = 52;
            btnEmpleados.Text = "Empleados";
            btnEmpleados.TextAlign = ContentAlignment.BottomCenter;
            btnEmpleados.UseVisualStyleBackColor = false;
            btnEmpleados.Click += btnEmpleados_Click;
            // 
            // btnCotizacion
            // 
            btnCotizacion.BackColor = Color.FromArgb(232, 232, 232);
            btnCotizacion.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnCotizacion.ImageAlign = ContentAlignment.TopCenter;
            btnCotizacion.ImageKey = "Cot.png";
            btnCotizacion.ImageList = imageList1;
            btnCotizacion.Location = new Point(684, 227);
            btnCotizacion.Margin = new Padding(4, 3, 4, 3);
            btnCotizacion.Name = "btnCotizacion";
            btnCotizacion.Size = new Size(246, 158);
            btnCotizacion.TabIndex = 52;
            btnCotizacion.Text = "Cotizacion";
            btnCotizacion.TextAlign = ContentAlignment.BottomCenter;
            btnCotizacion.UseVisualStyleBackColor = false;
            btnCotizacion.Click += btnCotizacion_Click;
            // 
            // btnVehículos
            // 
            btnVehículos.BackColor = Color.FromArgb(232, 232, 232);
            btnVehículos.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnVehículos.ImageAlign = ContentAlignment.TopCenter;
            btnVehículos.ImageKey = "Auto.png";
            btnVehículos.ImageList = imageList1;
            btnVehículos.Location = new Point(20, 37);
            btnVehículos.Margin = new Padding(4, 3, 4, 3);
            btnVehículos.Name = "btnVehículos";
            btnVehículos.Size = new Size(246, 158);
            btnVehículos.TabIndex = 52;
            btnVehículos.Text = "Vehiculos";
            btnVehículos.TextAlign = ContentAlignment.BottomCenter;
            btnVehículos.UseVisualStyleBackColor = false;
            btnVehículos.Click += btnVehículos_Click;
            // 
            // btnClientes
            // 
            btnClientes.BackColor = Color.FromArgb(232, 232, 232);
            btnClientes.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnClientes.ImageAlign = ContentAlignment.TopCenter;
            btnClientes.ImageKey = "Cli.png";
            btnClientes.ImageList = imageList1;
            btnClientes.Location = new Point(351, 227);
            btnClientes.Margin = new Padding(4, 3, 4, 3);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(246, 158);
            btnClientes.TabIndex = 52;
            btnClientes.Text = "Clientes";
            btnClientes.TextAlign = ContentAlignment.BottomCenter;
            btnClientes.UseVisualStyleBackColor = false;
            btnClientes.Click += btnClientes_Click;
            // 
            // btnProveedor
            // 
            btnProveedor.BackColor = Color.FromArgb(232, 232, 232);
            btnProveedor.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnProveedor.ImageAlign = ContentAlignment.TopCenter;
            btnProveedor.ImageKey = "Prov.png";
            btnProveedor.ImageList = imageList1;
            btnProveedor.Location = new Point(20, 227);
            btnProveedor.Margin = new Padding(4, 3, 4, 3);
            btnProveedor.Name = "btnProveedor";
            btnProveedor.Size = new Size(246, 158);
            btnProveedor.TabIndex = 52;
            btnProveedor.Text = "Proveedor";
            btnProveedor.TextAlign = ContentAlignment.BottomCenter;
            btnProveedor.UseVisualStyleBackColor = false;
            btnProveedor.Click += btnProveedor_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.None;
            panel2.AutoSize = true;
            panel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel2.Controls.Add(btnVehículos);
            panel2.Controls.Add(btnCotizacion);
            panel2.Controls.Add(btnClientes);
            panel2.Controls.Add(btnEmpleados);
            panel2.Controls.Add(btnProveedor);
            panel2.Controls.Add(btnVersiones);
            panel2.Location = new Point(129, 170);
            panel2.Margin = new Padding(1, 3, 1, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(934, 388);
            panel2.TabIndex = 53;
            // 
            // Inicio
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1121, 703);
            Controls.Add(panel2);
            Controls.Add(panel7);
            Controls.Add(panel1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Inicio";
            Text = "Inicio";
            WindowState = FormWindowState.Maximized;
            Load += Inicio_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox13).EndInit();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox13;
        private Label label7;
        private Label lblNombre;
        private Panel panel7;
        private Panel panel1;
        private Button btnVersiones;
        private Button btnEmpleados;
        private Button btnCotizacion;
        private Button btnVehículos;
        private Button btnClientes;
        private Button btnProveedor;
        private ImageList imageList1;
        private Button btnPedidos;
        private ImageList imageList2;
        private Button btnReportes;
        private Button btnCobros;
        private Button btnVentas;
        private Button btnCitas;
        private Button btnStock;
        private Panel panel2;
        private Label lblTipoEmpleado;
        private Label label1;
    }
}