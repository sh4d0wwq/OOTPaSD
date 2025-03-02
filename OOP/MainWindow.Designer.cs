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
            this.drawPanel = new System.Windows.Forms.Panel();
            this.btnLine = new System.Windows.Forms.Button();
            this.btnBrLine = new System.Windows.Forms.Button();
            this.btnRect = new System.Windows.Forms.Button();
            this.btnPolygon = new System.Windows.Forms.Button();
            this.btnEllipse = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.penWidthNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.btnPenColor = new System.Windows.Forms.Button();
            this.btnBrushColor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.penWidthNumUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // drawPanel
            // 
            this.drawPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.drawPanel.Location = new System.Drawing.Point(12, 58);
            this.drawPanel.Name = "drawPanel";
            this.drawPanel.Size = new System.Drawing.Size(1240, 611);
            this.drawPanel.TabIndex = 0;
            this.drawPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawPanel_MouseDown);
            this.drawPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawPanel_MouseUp);
            // 
            // btnLine
            // 
            this.btnLine.Location = new System.Drawing.Point(12, 12);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(40, 40);
            this.btnLine.TabIndex = 1;
            this.btnLine.Text = "button1";
            this.btnLine.UseVisualStyleBackColor = true;
            this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // btnBrLine
            // 
            this.btnBrLine.Location = new System.Drawing.Point(58, 12);
            this.btnBrLine.Name = "btnBrLine";
            this.btnBrLine.Size = new System.Drawing.Size(40, 40);
            this.btnBrLine.TabIndex = 2;
            this.btnBrLine.Text = "button2";
            this.btnBrLine.UseVisualStyleBackColor = true;
            this.btnBrLine.Click += new System.EventHandler(this.btnBrLine_Click);
            // 
            // btnRect
            // 
            this.btnRect.Location = new System.Drawing.Point(104, 12);
            this.btnRect.Name = "btnRect";
            this.btnRect.Size = new System.Drawing.Size(40, 40);
            this.btnRect.TabIndex = 3;
            this.btnRect.Text = "button3";
            this.btnRect.UseVisualStyleBackColor = true;
            this.btnRect.Click += new System.EventHandler(this.btnRect_Click);
            // 
            // btnPolygon
            // 
            this.btnPolygon.Location = new System.Drawing.Point(150, 12);
            this.btnPolygon.Name = "btnPolygon";
            this.btnPolygon.Size = new System.Drawing.Size(40, 40);
            this.btnPolygon.TabIndex = 4;
            this.btnPolygon.Text = "button4";
            this.btnPolygon.UseVisualStyleBackColor = true;
            this.btnPolygon.Click += new System.EventHandler(this.btnPolygon_Click);
            // 
            // btnEllipse
            // 
            this.btnEllipse.Location = new System.Drawing.Point(196, 12);
            this.btnEllipse.Name = "btnEllipse";
            this.btnEllipse.Size = new System.Drawing.Size(40, 40);
            this.btnEllipse.TabIndex = 5;
            this.btnEllipse.Text = "button5";
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
            this.btnPenColor.Location = new System.Drawing.Point(399, 12);
            this.btnPenColor.Name = "btnPenColor";
            this.btnPenColor.Size = new System.Drawing.Size(40, 40);
            this.btnPenColor.TabIndex = 7;
            this.btnPenColor.Text = "button1";
            this.btnPenColor.UseVisualStyleBackColor = true;
            this.btnPenColor.Click += new System.EventHandler(this.btnPenColor_Click);
            // 
            // btnBrushColor
            // 
            this.btnBrushColor.Location = new System.Drawing.Point(445, 12);
            this.btnBrushColor.Name = "btnBrushColor";
            this.btnBrushColor.Size = new System.Drawing.Size(40, 40);
            this.btnBrushColor.TabIndex = 8;
            this.btnBrushColor.Text = "button2";
            this.btnBrushColor.UseVisualStyleBackColor = true;
            this.btnBrushColor.Click += new System.EventHandler(this.btnBrushColor_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.btnBrushColor);
            this.Controls.Add(this.btnPenColor);
            this.Controls.Add(this.penWidthNumUpDown);
            this.Controls.Add(this.btnEllipse);
            this.Controls.Add(this.btnPolygon);
            this.Controls.Add(this.btnRect);
            this.Controls.Add(this.btnBrLine);
            this.Controls.Add(this.btnLine);
            this.Controls.Add(this.drawPanel);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            ((System.ComponentModel.ISupportInitialize)(this.penWidthNumUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel drawPanel;
        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.Button btnBrLine;
        private System.Windows.Forms.Button btnRect;
        private System.Windows.Forms.Button btnPolygon;
        private System.Windows.Forms.Button btnEllipse;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.NumericUpDown penWidthNumUpDown;
        private System.Windows.Forms.Button btnPenColor;
        private System.Windows.Forms.Button btnBrushColor;
    }
}