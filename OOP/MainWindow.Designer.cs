namespace OOTPaSD
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.btnLine = new System.Windows.Forms.Button();
            this.btnBrLine = new System.Windows.Forms.Button();
            this.btnRect = new System.Windows.Forms.Button();
            this.btnPolygon = new System.Windows.Forms.Button();
            this.btnEllipse = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.penWidthNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.btnPenColor = new System.Windows.Forms.Button();
            this.btnBrushColor = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.drawPanel = new OOTPaSD.DoubleBufferedPanel();
            ((System.ComponentModel.ISupportInitialize)(this.penWidthNumUpDown)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLine
            // 
            this.btnLine.ImageKey = "diagonal-line.png";
            this.btnLine.ImageList = this.imgList;
            this.btnLine.Location = new System.Drawing.Point(3, 3);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(25, 25);
            this.btnLine.TabIndex = 1;
            this.btnLine.UseVisualStyleBackColor = true;
            this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // btnBrLine
            // 
            this.btnBrLine.ImageKey = "polygonal-chain.png";
            this.btnBrLine.ImageList = this.imgList;
            this.btnBrLine.Location = new System.Drawing.Point(34, 3);
            this.btnBrLine.Name = "btnBrLine";
            this.btnBrLine.Size = new System.Drawing.Size(25, 25);
            this.btnBrLine.TabIndex = 2;
            this.btnBrLine.UseVisualStyleBackColor = true;
            this.btnBrLine.Click += new System.EventHandler(this.btnBrLine_Click);
            // 
            // btnRect
            // 
            this.btnRect.ImageKey = "rectangle (1).png";
            this.btnRect.ImageList = this.imgList;
            this.btnRect.Location = new System.Drawing.Point(65, 3);
            this.btnRect.Name = "btnRect";
            this.btnRect.Size = new System.Drawing.Size(25, 25);
            this.btnRect.TabIndex = 3;
            this.btnRect.UseVisualStyleBackColor = true;
            this.btnRect.Click += new System.EventHandler(this.btnRect_Click);
            // 
            // btnPolygon
            // 
            this.btnPolygon.ImageKey = "pentagon.png";
            this.btnPolygon.ImageList = this.imgList;
            this.btnPolygon.Location = new System.Drawing.Point(96, 3);
            this.btnPolygon.Name = "btnPolygon";
            this.btnPolygon.Size = new System.Drawing.Size(25, 25);
            this.btnPolygon.TabIndex = 4;
            this.btnPolygon.UseVisualStyleBackColor = true;
            this.btnPolygon.Click += new System.EventHandler(this.btnPolygon_Click);
            // 
            // btnEllipse
            // 
            this.btnEllipse.ImageKey = "ellipse.png";
            this.btnEllipse.ImageList = this.imgList;
            this.btnEllipse.Location = new System.Drawing.Point(127, 3);
            this.btnEllipse.Name = "btnEllipse";
            this.btnEllipse.Size = new System.Drawing.Size(25, 25);
            this.btnEllipse.TabIndex = 5;
            this.btnEllipse.UseVisualStyleBackColor = true;
            this.btnEllipse.Click += new System.EventHandler(this.btnEllipse_Click);
            // 
            // penWidthNumUpDown
            // 
            this.penWidthNumUpDown.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.penWidthNumUpDown.Location = new System.Drawing.Point(287, 24);
            this.penWidthNumUpDown.Name = "penWidthNumUpDown";
            this.penWidthNumUpDown.Size = new System.Drawing.Size(53, 20);
            this.penWidthNumUpDown.TabIndex = 6;
            this.penWidthNumUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.penWidthNumUpDown.ValueChanged += new System.EventHandler(this.penWidthNumUpDown_ValueChanged);
            // 
            // btnPenColor
            // 
            this.btnPenColor.BackColor = System.Drawing.Color.Black;
            this.btnPenColor.Location = new System.Drawing.Point(484, 12);
            this.btnPenColor.Name = "btnPenColor";
            this.btnPenColor.Size = new System.Drawing.Size(40, 40);
            this.btnPenColor.TabIndex = 7;
            this.btnPenColor.UseVisualStyleBackColor = false;
            this.btnPenColor.Click += new System.EventHandler(this.btnPenColor_Click);
            // 
            // btnBrushColor
            // 
            this.btnBrushColor.BackColor = System.Drawing.Color.Black;
            this.btnBrushColor.Location = new System.Drawing.Point(484, 58);
            this.btnBrushColor.Name = "btnBrushColor";
            this.btnBrushColor.Size = new System.Drawing.Size(40, 40);
            this.btnBrushColor.TabIndex = 8;
            this.btnBrushColor.UseVisualStyleBackColor = false;
            this.btnBrushColor.Click += new System.EventHandler(this.btnBrushColor_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.flowLayoutPanel1.Controls.Add(this.btnLine);
            this.flowLayoutPanel1.Controls.Add(this.btnBrLine);
            this.flowLayoutPanel1.Controls.Add(this.btnRect);
            this.flowLayoutPanel1.Controls.Add(this.btnPolygon);
            this.flowLayoutPanel1.Controls.Add(this.btnEllipse);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(56, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "rectangle (1).png");
            this.imgList.Images.SetKeyName(1, "pentagon.png");
            this.imgList.Images.SetKeyName(2, "ellipse.png");
            this.imgList.Images.SetKeyName(3, "polygonal-chain.png");
            this.imgList.Images.SetKeyName(4, "diagonal-line.png");
            // 
            // drawPanel
            // 
            this.drawPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.drawPanel.Location = new System.Drawing.Point(12, 122);
            this.drawPanel.Name = "drawPanel";
            this.drawPanel.Size = new System.Drawing.Size(1240, 547);
            this.drawPanel.TabIndex = 0;
            this.drawPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.drawPanel_Paint);
            this.drawPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawPanel_MouseDown);
            this.drawPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawPanel_MouseMove);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnBrushColor);
            this.Controls.Add(this.btnPenColor);
            this.Controls.Add(this.penWidthNumUpDown);
            this.Controls.Add(this.drawPanel);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            ((System.ComponentModel.ISupportInitialize)(this.penWidthNumUpDown)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OOTPaSD.DoubleBufferedPanel drawPanel;
        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.Button btnBrLine;
        private System.Windows.Forms.Button btnRect;
        private System.Windows.Forms.Button btnPolygon;
        private System.Windows.Forms.Button btnEllipse;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.NumericUpDown penWidthNumUpDown;
        private System.Windows.Forms.Button btnPenColor;
        private System.Windows.Forms.Button btnBrushColor;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ImageList imgList;
    }
}