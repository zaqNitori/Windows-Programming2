
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
            this._buttonDrawRectangle = new System.Windows.Forms.Button();
            this._buttonDrawEllipse = new System.Windows.Forms.Button();
            this._buttonClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _buttonDrawRectangle
            // 
            this._buttonDrawRectangle.Location = new System.Drawing.Point(92, 49);
            this._buttonDrawRectangle.Name = "_buttonDrawRectangle";
            this._buttonDrawRectangle.Size = new System.Drawing.Size(140, 70);
            this._buttonDrawRectangle.TabIndex = 0;
            this._buttonDrawRectangle.Text = "Rectangle";
            this._buttonDrawRectangle.UseVisualStyleBackColor = true;
            // 
            // _buttonDrawEllipse
            // 
            this._buttonDrawEllipse.Location = new System.Drawing.Point(240, 49);
            this._buttonDrawEllipse.Name = "_buttonDrawEllipse";
            this._buttonDrawEllipse.Size = new System.Drawing.Size(140, 70);
            this._buttonDrawEllipse.TabIndex = 0;
            this._buttonDrawEllipse.Text = "Ellipse";
            this._buttonDrawEllipse.UseVisualStyleBackColor = true;
            // 
            // _buttonClear
            // 
            this._buttonClear.Location = new System.Drawing.Point(386, 49);
            this._buttonClear.Name = "_buttonClear";
            this._buttonClear.Size = new System.Drawing.Size(140, 70);
            this._buttonClear.TabIndex = 0;
            this._buttonClear.Text = "Clear";
            this._buttonClear.UseVisualStyleBackColor = true;
            // 
            // DrawingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._buttonClear);
            this.Controls.Add(this._buttonDrawEllipse);
            this.Controls.Add(this._buttonDrawRectangle);
            this.Name = "DrawingForm";
            this.Text = "DrawingForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _buttonDrawRectangle;
        private System.Windows.Forms.Button _buttonDrawEllipse;
        private System.Windows.Forms.Button _buttonClear;
    }
}