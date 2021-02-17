
namespace BRSTestDataGenerator
{
    partial class ChildForm_AddFlight
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
            this.Group_AddFlight = new System.Windows.Forms.GroupBox();
            this.Button_Flight_N = new System.Windows.Forms.Button();
            this.Button_Flight_Y = new System.Windows.Forms.Button();
            this.Text_DES = new System.Windows.Forms.TextBox();
            this.Label_DES = new System.Windows.Forms.Label();
            this.Text_ETD = new System.Windows.Forms.TextBox();
            this.Label_ETD = new System.Windows.Forms.Label();
            this.Text_STD = new System.Windows.Forms.TextBox();
            this.Label_STD = new System.Windows.Forms.Label();
            this.Group_AddFlight.SuspendLayout();
            this.SuspendLayout();
            // 
            // Group_AddFlight
            // 
            this.Group_AddFlight.Controls.Add(this.Button_Flight_N);
            this.Group_AddFlight.Controls.Add(this.Button_Flight_Y);
            this.Group_AddFlight.Controls.Add(this.Text_DES);
            this.Group_AddFlight.Controls.Add(this.Label_DES);
            this.Group_AddFlight.Controls.Add(this.Text_ETD);
            this.Group_AddFlight.Controls.Add(this.Label_ETD);
            this.Group_AddFlight.Controls.Add(this.Text_STD);
            this.Group_AddFlight.Controls.Add(this.Label_STD);
            this.Group_AddFlight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Group_AddFlight.Location = new System.Drawing.Point(13, 12);
            this.Group_AddFlight.Name = "Group_AddFlight";
            this.Group_AddFlight.Size = new System.Drawing.Size(256, 128);
            this.Group_AddFlight.TabIndex = 0;
            this.Group_AddFlight.TabStop = false;
            this.Group_AddFlight.Text = "XX0001";
            // 
            // Button_Flight_N
            // 
            this.Button_Flight_N.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Button_Flight_N.Location = new System.Drawing.Point(160, 57);
            this.Button_Flight_N.Name = "Button_Flight_N";
            this.Button_Flight_N.Size = new System.Drawing.Size(75, 22);
            this.Button_Flight_N.TabIndex = 7;
            this.Button_Flight_N.Text = "Cancel";
            this.Button_Flight_N.UseVisualStyleBackColor = true;
            this.Button_Flight_N.Click += new System.EventHandler(this.Button_Flight_N_Click);
            // 
            // Button_Flight_Y
            // 
            this.Button_Flight_Y.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Button_Flight_Y.Location = new System.Drawing.Point(160, 27);
            this.Button_Flight_Y.Name = "Button_Flight_Y";
            this.Button_Flight_Y.Size = new System.Drawing.Size(75, 22);
            this.Button_Flight_Y.TabIndex = 6;
            this.Button_Flight_Y.Text = "Submit";
            this.Button_Flight_Y.UseVisualStyleBackColor = true;
            this.Button_Flight_Y.Click += new System.EventHandler(this.Button_Flight_Y_Click);
            // 
            // Text_DES
            // 
            this.Text_DES.ForeColor = System.Drawing.Color.Silver;
            this.Text_DES.Location = new System.Drawing.Point(65, 87);
            this.Text_DES.Name = "Text_DES";
            this.Text_DES.Size = new System.Drawing.Size(80, 26);
            this.Text_DES.TabIndex = 5;
            this.Text_DES.Text = "KIX";
            this.Text_DES.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Text_DES.Enter += new System.EventHandler(this.Text_GotFocus);
            this.Text_DES.Leave += new System.EventHandler(this.Text_DES_LostFocus);
            // 
            // Label_DES
            // 
            this.Label_DES.AutoSize = true;
            this.Label_DES.Location = new System.Drawing.Point(20, 90);
            this.Label_DES.Name = "Label_DES";
            this.Label_DES.Size = new System.Drawing.Size(43, 20);
            this.Label_DES.TabIndex = 4;
            this.Label_DES.Text = "DES";
            this.Label_DES.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Text_ETD
            // 
            this.Text_ETD.ForeColor = System.Drawing.Color.Silver;
            this.Text_ETD.Location = new System.Drawing.Point(65, 57);
            this.Text_ETD.Name = "Text_ETD";
            this.Text_ETD.Size = new System.Drawing.Size(80, 26);
            this.Text_ETD.TabIndex = 3;
            this.Text_ETD.Text = "1115";
            this.Text_ETD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Text_ETD.Enter += new System.EventHandler(this.Text_GotFocus);
            this.Text_ETD.Leave += new System.EventHandler(this.Text_ETD_LostFocus);
            // 
            // Label_ETD
            // 
            this.Label_ETD.AutoSize = true;
            this.Label_ETD.Location = new System.Drawing.Point(20, 60);
            this.Label_ETD.Name = "Label_ETD";
            this.Label_ETD.Size = new System.Drawing.Size(41, 20);
            this.Label_ETD.TabIndex = 2;
            this.Label_ETD.Text = "ETD";
            this.Label_ETD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Text_STD
            // 
            this.Text_STD.ForeColor = System.Drawing.Color.Silver;
            this.Text_STD.Location = new System.Drawing.Point(65, 27);
            this.Text_STD.Name = "Text_STD";
            this.Text_STD.Size = new System.Drawing.Size(80, 26);
            this.Text_STD.TabIndex = 1;
            this.Text_STD.Text = "1115";
            this.Text_STD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Text_STD.Enter += new System.EventHandler(this.Text_GotFocus);
            this.Text_STD.Leave += new System.EventHandler(this.Text_STD_LostFocus);
            // 
            // Label_STD
            // 
            this.Label_STD.AutoSize = true;
            this.Label_STD.Location = new System.Drawing.Point(20, 30);
            this.Label_STD.Name = "Label_STD";
            this.Label_STD.Size = new System.Drawing.Size(41, 20);
            this.Label_STD.TabIndex = 0;
            this.Label_STD.Text = "STD";
            this.Label_STD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ChildForm_AddFlight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 157);
            this.Controls.Add(this.Group_AddFlight);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "ChildForm_AddFlight";
            this.Text = "Add a New Flight Data";
            this.Load += new System.EventHandler(this.ChildForm_AddFlight_Load);
            this.Group_AddFlight.ResumeLayout(false);
            this.Group_AddFlight.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Group_AddFlight;
        private System.Windows.Forms.Label Label_STD;
        private System.Windows.Forms.TextBox Text_STD;
        private System.Windows.Forms.TextBox Text_ETD;
        private System.Windows.Forms.Label Label_ETD;
        private System.Windows.Forms.TextBox Text_DES;
        private System.Windows.Forms.Label Label_DES;
        private System.Windows.Forms.Button Button_Flight_N;
        private System.Windows.Forms.Button Button_Flight_Y;
    }
}