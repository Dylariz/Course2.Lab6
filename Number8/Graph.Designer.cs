namespace Number8
{
    partial class Graph
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
            this.pinButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pinButton
            // 
            this.pinButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pinButton.Location = new System.Drawing.Point(12, 804);
            this.pinButton.Name = "pinButton";
            this.pinButton.Size = new System.Drawing.Size(412, 67);
            this.pinButton.TabIndex = 0;
            this.pinButton.Text = "Закрепить многоугольник";
            this.pinButton.UseVisualStyleBackColor = true;
            this.pinButton.Click += new System.EventHandler(this.pinButton_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusLabel.Location = new System.Drawing.Point(448, 810);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(679, 64);
            this.statusLabel.TabIndex = 1;
            this.statusLabel.Text = "Статус: Ожидание построения";
            // 
            // Graph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 883);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.pinButton);
            this.Name = "Graph";
            this.Text = "Graph";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Graph_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Graph_MouseDown);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button pinButton;
        private System.Windows.Forms.Label statusLabel;

        #endregion
    }
}