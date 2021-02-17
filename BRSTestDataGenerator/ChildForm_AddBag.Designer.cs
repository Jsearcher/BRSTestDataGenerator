
namespace BRSTestDataGenerator
{
    partial class ChildForm_AddBag
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
            this.Group_AddBag = new System.Windows.Forms.GroupBox();
            this.Button_Bag_N = new System.Windows.Forms.Button();
            this.Button_Bag_Y = new System.Windows.Forms.Button();
            this.Text_CabinClass = new System.Windows.Forms.TextBox();
            this.Text_BagState = new System.Windows.Forms.TextBox();
            this.Label_CabinClass = new System.Windows.Forms.Label();
            this.Label_BagState = new System.Windows.Forms.Label();
            this.Text_Data_Number = new System.Windows.Forms.TextBox();
            this.Label_Data_Number = new System.Windows.Forms.Label();
            this.Group_AddBag.SuspendLayout();
            this.SuspendLayout();
            // 
            // Group_AddBag
            // 
            this.Group_AddBag.Controls.Add(this.Button_Bag_N);
            this.Group_AddBag.Controls.Add(this.Button_Bag_Y);
            this.Group_AddBag.Controls.Add(this.Text_CabinClass);
            this.Group_AddBag.Controls.Add(this.Text_BagState);
            this.Group_AddBag.Controls.Add(this.Label_CabinClass);
            this.Group_AddBag.Controls.Add(this.Label_BagState);
            this.Group_AddBag.Controls.Add(this.Text_Data_Number);
            this.Group_AddBag.Controls.Add(this.Label_Data_Number);
            this.Group_AddBag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Group_AddBag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Group_AddBag.Location = new System.Drawing.Point(13, 13);
            this.Group_AddBag.Name = "Group_AddBag";
            this.Group_AddBag.Size = new System.Drawing.Size(256, 128);
            this.Group_AddBag.TabIndex = 0;
            this.Group_AddBag.TabStop = false;
            this.Group_AddBag.Tag = "";
            this.Group_AddBag.Text = "BSM_FLIGHT: XX0001";
            // 
            // Button_Bag_N
            // 
            this.Button_Bag_N.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Button_Bag_N.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Button_Bag_N.Location = new System.Drawing.Point(160, 60);
            this.Button_Bag_N.Name = "Button_Bag_N";
            this.Button_Bag_N.Size = new System.Drawing.Size(75, 23);
            this.Button_Bag_N.TabIndex = 7;
            this.Button_Bag_N.Text = "Cancel";
            this.Button_Bag_N.UseVisualStyleBackColor = true;
            this.Button_Bag_N.Click += new System.EventHandler(this.Button_Bag_N_Click);
            // 
            // Button_Bag_Y
            // 
            this.Button_Bag_Y.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Button_Bag_Y.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Button_Bag_Y.Location = new System.Drawing.Point(160, 27);
            this.Button_Bag_Y.Name = "Button_Bag_Y";
            this.Button_Bag_Y.Size = new System.Drawing.Size(75, 23);
            this.Button_Bag_Y.TabIndex = 6;
            this.Button_Bag_Y.Text = "Submit";
            this.Button_Bag_Y.UseVisualStyleBackColor = true;
            this.Button_Bag_Y.Click += new System.EventHandler(this.Button_Bag_Y_Click);
            // 
            // Text_CabinClass
            // 
            this.Text_CabinClass.ForeColor = System.Drawing.Color.Silver;
            this.Text_CabinClass.Location = new System.Drawing.Point(83, 87);
            this.Text_CabinClass.Name = "Text_CabinClass";
            this.Text_CabinClass.Size = new System.Drawing.Size(50, 26);
            this.Text_CabinClass.TabIndex = 5;
            this.Text_CabinClass.Text = "Y";
            this.Text_CabinClass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Text_CabinClass.Enter += new System.EventHandler(this.Text_GotFocus);
            this.Text_CabinClass.Leave += new System.EventHandler(this.Text_CabinClass_LostFocus);
            // 
            // Text_BagState
            // 
            this.Text_BagState.ForeColor = System.Drawing.Color.Silver;
            this.Text_BagState.Location = new System.Drawing.Point(83, 57);
            this.Text_BagState.Name = "Text_BagState";
            this.Text_BagState.Size = new System.Drawing.Size(50, 26);
            this.Text_BagState.TabIndex = 4;
            this.Text_BagState.Text = "0";
            this.Text_BagState.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Text_BagState.Enter += new System.EventHandler(this.Text_GotFocus);
            this.Text_BagState.Leave += new System.EventHandler(this.Text_BagState_LostFocus);
            // 
            // Label_CabinClass
            // 
            this.Label_CabinClass.AutoSize = true;
            this.Label_CabinClass.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label_CabinClass.Location = new System.Drawing.Point(20, 90);
            this.Label_CabinClass.Name = "Label_CabinClass";
            this.Label_CabinClass.Size = new System.Drawing.Size(62, 20);
            this.Label_CabinClass.TabIndex = 3;
            this.Label_CabinClass.Text = "CLASS";
            // 
            // Label_BagState
            // 
            this.Label_BagState.AutoSize = true;
            this.Label_BagState.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label_BagState.Location = new System.Drawing.Point(20, 60);
            this.Label_BagState.Name = "Label_BagState";
            this.Label_BagState.Size = new System.Drawing.Size(60, 20);
            this.Label_BagState.TabIndex = 2;
            this.Label_BagState.Text = "STATE";
            this.Label_BagState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Text_Data_Number
            // 
            this.Text_Data_Number.ForeColor = System.Drawing.Color.Silver;
            this.Text_Data_Number.Location = new System.Drawing.Point(83, 27);
            this.Text_Data_Number.Name = "Text_Data_Number";
            this.Text_Data_Number.Size = new System.Drawing.Size(50, 26);
            this.Text_Data_Number.TabIndex = 1;
            this.Text_Data_Number.Text = "1";
            this.Text_Data_Number.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Text_Data_Number.Enter += new System.EventHandler(this.Text_GotFocus);
            this.Text_Data_Number.Leave += new System.EventHandler(this.Text_Data_Number_LostFocus);
            // 
            // Label_Data_Number
            // 
            this.Label_Data_Number.AutoSize = true;
            this.Label_Data_Number.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label_Data_Number.Location = new System.Drawing.Point(20, 30);
            this.Label_Data_Number.Name = "Label_Data_Number";
            this.Label_Data_Number.Size = new System.Drawing.Size(57, 20);
            this.Label_Data_Number.TabIndex = 0;
            this.Label_Data_Number.Text = "Data #";
            this.Label_Data_Number.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ChildForm_AddBag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 157);
            this.Controls.Add(this.Group_AddBag);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "ChildForm_AddBag";
            this.Text = "Add Test Baggage Data";
            this.Load += new System.EventHandler(this.ChildForm_AddBag_Load);
            this.Group_AddBag.ResumeLayout(false);
            this.Group_AddBag.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Group_AddBag;
        private System.Windows.Forms.Label Label_Data_Number;
        private System.Windows.Forms.TextBox Text_Data_Number;
        private System.Windows.Forms.Label Label_BagState;
        private System.Windows.Forms.Label Label_CabinClass;
        private System.Windows.Forms.TextBox Text_BagState;
        private System.Windows.Forms.TextBox Text_CabinClass;
        private System.Windows.Forms.Button Button_Bag_Y;
        private System.Windows.Forms.Button Button_Bag_N;
    }
}