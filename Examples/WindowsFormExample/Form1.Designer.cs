namespace WindowsFormExample
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if ( disposing && (components != null) )
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.ThrowDivideByZeroButton = new System.Windows.Forms.Button();
            this.ThrowNullExceptionButton = new System.Windows.Forms.Button();
            this.ThrowGenericExceptionButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ThrowDivideByZeroButton
            // 
            this.ThrowDivideByZeroButton.Location = new System.Drawing.Point(12, 12);
            this.ThrowDivideByZeroButton.Name = "ThrowDivideByZeroButton";
            this.ThrowDivideByZeroButton.Size = new System.Drawing.Size(215, 105);
            this.ThrowDivideByZeroButton.TabIndex = 0;
            this.ThrowDivideByZeroButton.Text = "Click here to raise DivideByZeroException";
            this.ThrowDivideByZeroButton.UseVisualStyleBackColor = true;
            this.ThrowDivideByZeroButton.Click += new System.EventHandler(this.ThrowDivideByZeroButton_Click);
            // 
            // ThrowNullExceptionButton
            // 
            this.ThrowNullExceptionButton.Location = new System.Drawing.Point(233, 12);
            this.ThrowNullExceptionButton.Name = "ThrowNullExceptionButton";
            this.ThrowNullExceptionButton.Size = new System.Drawing.Size(216, 105);
            this.ThrowNullExceptionButton.TabIndex = 1;
            this.ThrowNullExceptionButton.Text = "Click to Raise a NullException";
            this.ThrowNullExceptionButton.UseVisualStyleBackColor = true;
            this.ThrowNullExceptionButton.Click += new System.EventHandler(this.ThrowNullExceptionButton_Click);
            // 
            // ThrowGenericExceptionButton
            // 
            this.ThrowGenericExceptionButton.Location = new System.Drawing.Point(455, 12);
            this.ThrowGenericExceptionButton.Name = "ThrowGenericExceptionButton";
            this.ThrowGenericExceptionButton.Size = new System.Drawing.Size(214, 105);
            this.ThrowGenericExceptionButton.TabIndex = 2;
            this.ThrowGenericExceptionButton.Text = "Click to Raise a generic Exception";
            this.ThrowGenericExceptionButton.UseVisualStyleBackColor = true;
            this.ThrowGenericExceptionButton.Click += new System.EventHandler(this.ThrowGenericExceptionButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 129);
            this.Controls.Add(this.ThrowGenericExceptionButton);
            this.Controls.Add(this.ThrowNullExceptionButton);
            this.Controls.Add(this.ThrowDivideByZeroButton);
            this.Name = "Form1";
            this.Text = "Exception Helper Tests";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ThrowDivideByZeroButton;
        private System.Windows.Forms.Button ThrowNullExceptionButton;
        private System.Windows.Forms.Button ThrowGenericExceptionButton;
    }
}

