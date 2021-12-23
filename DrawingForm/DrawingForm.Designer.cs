
namespace DrawingForm
{
    partial class DrawingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DrawingForm));
            this._buttonDrawRectangle = new System.Windows.Forms.Button();
            this._buttonDrawEllipse = new System.Windows.Forms.Button();
            this._buttonClear = new System.Windows.Forms.Button();
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._buttonUndo = new System.Windows.Forms.ToolStripButton();
            this._buttonRedo = new System.Windows.Forms.ToolStripButton();
            this._buttonChoose = new System.Windows.Forms.Button();
            this._selectedLabel = new System.Windows.Forms.Label();
            this._toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _buttonDrawRectangle
            // 
            this._buttonDrawRectangle.Location = new System.Drawing.Point(92, 49);
            this._buttonDrawRectangle.Name = "_buttonDrawRectangle";
            this._buttonDrawRectangle.Size = new System.Drawing.Size(100, 50);
            this._buttonDrawRectangle.TabIndex = 0;
            this._buttonDrawRectangle.Text = "Rectangle";
            this._buttonDrawRectangle.UseVisualStyleBackColor = true;
            // 
            // _buttonDrawEllipse
            // 
            this._buttonDrawEllipse.Location = new System.Drawing.Point(240, 49);
            this._buttonDrawEllipse.Name = "_buttonDrawEllipse";
            this._buttonDrawEllipse.Size = new System.Drawing.Size(100, 50);
            this._buttonDrawEllipse.TabIndex = 0;
            this._buttonDrawEllipse.Text = "Ellipse";
            this._buttonDrawEllipse.UseVisualStyleBackColor = true;
            // 
            // _buttonClear
            // 
            this._buttonClear.Location = new System.Drawing.Point(386, 49);
            this._buttonClear.Name = "_buttonClear";
            this._buttonClear.Size = new System.Drawing.Size(100, 50);
            this._buttonClear.TabIndex = 0;
            this._buttonClear.Text = "Clear";
            this._buttonClear.UseVisualStyleBackColor = true;
            // 
            // _toolStrip
            // 
            this._toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._buttonUndo,
            this._buttonRedo});
            this._toolStrip.Location = new System.Drawing.Point(0, 0);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(800, 27);
            this._toolStrip.TabIndex = 1;
            this._toolStrip.Text = "toolStrip1";
            // 
            // _buttonUndo
            // 
            this._buttonUndo.BackColor = System.Drawing.SystemColors.Control;
            this._buttonUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._buttonUndo.ForeColor = System.Drawing.SystemColors.ControlText;
            this._buttonUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._buttonUndo.Name = "_buttonUndo";
            this._buttonUndo.Size = new System.Drawing.Size(49, 24);
            this._buttonUndo.Text = "Undo";
            // 
            // _buttonRedo
            // 
            this._buttonRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._buttonRedo.Image = ((System.Drawing.Image)(resources.GetObject("_buttonRedo.Image")));
            this._buttonRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._buttonRedo.Name = "_buttonRedo";
            this._buttonRedo.Size = new System.Drawing.Size(48, 24);
            this._buttonRedo.Text = "Redo";
            // 
            // _buttonChoose
            // 
            this._buttonChoose.Location = new System.Drawing.Point(527, 49);
            this._buttonChoose.Name = "_buttonChoose";
            this._buttonChoose.Size = new System.Drawing.Size(100, 50);
            this._buttonChoose.TabIndex = 2;
            this._buttonChoose.Text = "Choose";
            this._buttonChoose.UseVisualStyleBackColor = true;
            // 
            // _selectedLabel
            // 
            this._selectedLabel.AutoSize = true;
            this._selectedLabel.BackColor = System.Drawing.SystemColors.Control;
            this._selectedLabel.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._selectedLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this._selectedLabel.Location = new System.Drawing.Point(593, 421);
            this._selectedLabel.Name = "_selectedLabel";
            this._selectedLabel.Size = new System.Drawing.Size(34, 20);
            this._selectedLabel.TabIndex = 3;
            this._selectedLabel.Text = "test";
            this._selectedLabel.Visible = false;
            // 
            // DrawingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._selectedLabel);
            this.Controls.Add(this._buttonChoose);
            this.Controls.Add(this._toolStrip);
            this.Controls.Add(this._buttonClear);
            this.Controls.Add(this._buttonDrawEllipse);
            this.Controls.Add(this._buttonDrawRectangle);
            this.Name = "DrawingForm";
            this.Text = "DrawingForm";
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _buttonDrawRectangle;
        private System.Windows.Forms.Button _buttonDrawEllipse;
        private System.Windows.Forms.Button _buttonClear;
        private System.Windows.Forms.ToolStrip _toolStrip;
        private System.Windows.Forms.ToolStripButton _buttonUndo;
        private System.Windows.Forms.ToolStripButton _buttonRedo;
        private System.Windows.Forms.Button _buttonChoose;
        private System.Windows.Forms.Label _selectedLabel;
    }
}