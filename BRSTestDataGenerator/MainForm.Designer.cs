namespace BRSTestDataGenerator
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupFIDS = new System.Windows.Forms.GroupBox();
            this.panelFIDS = new System.Windows.Forms.Panel();
            this.dataGridFLT = new System.Windows.Forms.DataGridView();
            this.FLIGHT_NO_C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATE_C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STD_C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ETD_C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DES_C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_Clear_FIDS = new System.Windows.Forms.Button();
            this.button_Confirm_FIDS = new System.Windows.Forms.Button();
            this.text_DES_FIDS = new System.Windows.Forms.TextBox();
            this.labelDES = new System.Windows.Forms.Label();
            this.labelETD = new System.Windows.Forms.Label();
            this.text_ETD_FIDS = new System.Windows.Forms.TextBox();
            this.labelSTD = new System.Windows.Forms.Label();
            this.text_STD_FIDS = new System.Windows.Forms.TextBox();
            this.labelFlight = new System.Windows.Forms.Label();
            this.groupBSM = new System.Windows.Forms.GroupBox();
            this.panelBSM = new System.Windows.Forms.Panel();
            this.text_CabinClass_BSM = new System.Windows.Forms.TextBox();
            this.labelCabinClass = new System.Windows.Forms.Label();
            this.dataGridBSM = new System.Windows.Forms.DataGridView();
            this.BAG_TAG_B = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BSM_DATE_B = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FLIGHT_NO_B = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BAG_STATE_B = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CABIN_CLASS_B = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_CONFIRM_BSM = new System.Windows.Forms.Button();
            this.button_CLEAR_BSM = new System.Windows.Forms.Button();
            this.text_Number_BSM = new System.Windows.Forms.TextBox();
            this.labelDataNumber = new System.Windows.Forms.Label();
            this.text_BagState_BSM = new System.Windows.Forms.TextBox();
            this.labelBagState = new System.Windows.Forms.Label();
            this.text_USER = new System.Windows.Forms.TextBox();
            this.groupFIDS.SuspendLayout();
            this.panelFIDS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFLT)).BeginInit();
            this.groupBSM.SuspendLayout();
            this.panelBSM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBSM)).BeginInit();
            this.SuspendLayout();
            // 
            // groupFIDS
            // 
            this.groupFIDS.Controls.Add(this.panelFIDS);
            this.groupFIDS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupFIDS.Location = new System.Drawing.Point(12, 32);
            this.groupFIDS.Name = "groupFIDS";
            this.groupFIDS.Size = new System.Drawing.Size(700, 200);
            this.groupFIDS.TabIndex = 0;
            this.groupFIDS.TabStop = false;
            this.groupFIDS.Text = "FIDS_2DAY";
            // 
            // panelFIDS
            // 
            this.panelFIDS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelFIDS.Controls.Add(this.dataGridFLT);
            this.panelFIDS.Controls.Add(this.button_Clear_FIDS);
            this.panelFIDS.Controls.Add(this.button_Confirm_FIDS);
            this.panelFIDS.Controls.Add(this.text_DES_FIDS);
            this.panelFIDS.Controls.Add(this.labelDES);
            this.panelFIDS.Controls.Add(this.labelETD);
            this.panelFIDS.Controls.Add(this.text_ETD_FIDS);
            this.panelFIDS.Controls.Add(this.labelSTD);
            this.panelFIDS.Controls.Add(this.text_STD_FIDS);
            this.panelFIDS.Controls.Add(this.labelFlight);
            this.panelFIDS.Location = new System.Drawing.Point(5, 25);
            this.panelFIDS.Name = "panelFIDS";
            this.panelFIDS.Size = new System.Drawing.Size(689, 170);
            this.panelFIDS.TabIndex = 0;
            // 
            // dataGridFLT
            // 
            this.dataGridFLT.AllowUserToAddRows = false;
            this.dataGridFLT.AllowUserToDeleteRows = false;
            this.dataGridFLT.AllowUserToResizeRows = false;
            this.dataGridFLT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridFLT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FLIGHT_NO_C,
            this.DATE_C,
            this.STD_C,
            this.ETD_C,
            this.DES_C});
            this.dataGridFLT.Location = new System.Drawing.Point(15, 15);
            this.dataGridFLT.MultiSelect = false;
            this.dataGridFLT.Name = "dataGridFLT";
            this.dataGridFLT.ReadOnly = true;
            this.dataGridFLT.RowHeadersVisible = false;
            this.dataGridFLT.Size = new System.Drawing.Size(405, 140);
            this.dataGridFLT.TabIndex = 0;
            // 
            // FLIGHT_NO_C
            // 
            this.FLIGHT_NO_C.HeaderText = "FLIGHT_NO";
            this.FLIGHT_NO_C.Name = "FLIGHT_NO_C";
            this.FLIGHT_NO_C.ReadOnly = true;
            this.FLIGHT_NO_C.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FLIGHT_NO_C.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.FLIGHT_NO_C.Width = 108;
            // 
            // DATE_C
            // 
            this.DATE_C.HeaderText = "DATE";
            this.DATE_C.Name = "DATE_C";
            this.DATE_C.ReadOnly = true;
            this.DATE_C.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DATE_C.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.DATE_C.Width = 86;
            // 
            // STD_C
            // 
            this.STD_C.HeaderText = "STD";
            this.STD_C.Name = "STD_C";
            this.STD_C.ReadOnly = true;
            this.STD_C.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.STD_C.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.STD_C.Width = 73;
            // 
            // ETD_C
            // 
            this.ETD_C.HeaderText = "ETD";
            this.ETD_C.Name = "ETD_C";
            this.ETD_C.ReadOnly = true;
            this.ETD_C.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ETD_C.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ETD_C.Width = 73;
            // 
            // DES_C
            // 
            this.DES_C.HeaderText = "DES";
            this.DES_C.Name = "DES_C";
            this.DES_C.ReadOnly = true;
            this.DES_C.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DES_C.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.DES_C.Width = 70;
            // 
            // button_Clear_FIDS
            // 
            this.button_Clear_FIDS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button_Clear_FIDS.ForeColor = System.Drawing.Color.Maroon;
            this.button_Clear_FIDS.Location = new System.Drawing.Point(579, 89);
            this.button_Clear_FIDS.Name = "button_Clear_FIDS";
            this.button_Clear_FIDS.Size = new System.Drawing.Size(100, 30);
            this.button_Clear_FIDS.TabIndex = 5;
            this.button_Clear_FIDS.Text = "CLEAR";
            this.button_Clear_FIDS.UseVisualStyleBackColor = true;
            this.button_Clear_FIDS.Click += new System.EventHandler(this.Button_Clear_FIDS_Click);
            // 
            // button_Confirm_FIDS
            // 
            this.button_Confirm_FIDS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button_Confirm_FIDS.ForeColor = System.Drawing.Color.Green;
            this.button_Confirm_FIDS.Location = new System.Drawing.Point(579, 47);
            this.button_Confirm_FIDS.Name = "button_Confirm_FIDS";
            this.button_Confirm_FIDS.Size = new System.Drawing.Size(100, 30);
            this.button_Confirm_FIDS.TabIndex = 4;
            this.button_Confirm_FIDS.Text = "CONFIRM";
            this.button_Confirm_FIDS.UseVisualStyleBackColor = true;
            this.button_Confirm_FIDS.Click += new System.EventHandler(this.Button_Confirm_FIDS_Click);
            // 
            // text_DES_FIDS
            // 
            this.text_DES_FIDS.ForeColor = System.Drawing.Color.Silver;
            this.text_DES_FIDS.Location = new System.Drawing.Point(474, 132);
            this.text_DES_FIDS.Name = "text_DES_FIDS";
            this.text_DES_FIDS.Size = new System.Drawing.Size(80, 26);
            this.text_DES_FIDS.TabIndex = 3;
            this.text_DES_FIDS.Text = "KIX";
            this.text_DES_FIDS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.text_DES_FIDS.GotFocus += new System.EventHandler(this.Text_DES_FIDS_GotFocus);
            this.text_DES_FIDS.LostFocus += new System.EventHandler(this.Text_DES_FIDS_LostFocus);
            // 
            // labelDES
            // 
            this.labelDES.AutoSize = true;
            this.labelDES.Location = new System.Drawing.Point(426, 135);
            this.labelDES.Name = "labelDES";
            this.labelDES.Size = new System.Drawing.Size(43, 20);
            this.labelDES.TabIndex = 5;
            this.labelDES.Text = "DES";
            this.labelDES.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelETD
            // 
            this.labelETD.AutoSize = true;
            this.labelETD.Location = new System.Drawing.Point(426, 92);
            this.labelETD.Name = "labelETD";
            this.labelETD.Size = new System.Drawing.Size(41, 20);
            this.labelETD.TabIndex = 4;
            this.labelETD.Text = "ETD";
            this.labelETD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // text_ETD_FIDS
            // 
            this.text_ETD_FIDS.ForeColor = System.Drawing.Color.Silver;
            this.text_ETD_FIDS.Location = new System.Drawing.Point(474, 89);
            this.text_ETD_FIDS.Name = "text_ETD_FIDS";
            this.text_ETD_FIDS.Size = new System.Drawing.Size(80, 26);
            this.text_ETD_FIDS.TabIndex = 2;
            this.text_ETD_FIDS.Text = "1520";
            this.text_ETD_FIDS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.text_ETD_FIDS.GotFocus += new System.EventHandler(this.Text_ETD_FIDS_GotFocus);
            this.text_ETD_FIDS.LostFocus += new System.EventHandler(this.Text_ETD_FIDS_LostFocus);
            // 
            // labelSTD
            // 
            this.labelSTD.AutoSize = true;
            this.labelSTD.Location = new System.Drawing.Point(426, 50);
            this.labelSTD.Name = "labelSTD";
            this.labelSTD.Size = new System.Drawing.Size(41, 20);
            this.labelSTD.TabIndex = 2;
            this.labelSTD.Text = "STD";
            this.labelSTD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // text_STD_FIDS
            // 
            this.text_STD_FIDS.ForeColor = System.Drawing.Color.Silver;
            this.text_STD_FIDS.Location = new System.Drawing.Point(474, 47);
            this.text_STD_FIDS.Name = "text_STD_FIDS";
            this.text_STD_FIDS.Size = new System.Drawing.Size(80, 26);
            this.text_STD_FIDS.TabIndex = 1;
            this.text_STD_FIDS.Text = "1520";
            this.text_STD_FIDS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.text_STD_FIDS.GotFocus += new System.EventHandler(this.Text_STD_FIDS_GotFocus);
            this.text_STD_FIDS.LostFocus += new System.EventHandler(this.Text_STD_FIDS_LostFocus);
            // 
            // labelFlight
            // 
            this.labelFlight.AutoSize = true;
            this.labelFlight.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelFlight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.labelFlight.Location = new System.Drawing.Point(426, 15);
            this.labelFlight.Name = "labelFlight";
            this.labelFlight.Size = new System.Drawing.Size(84, 24);
            this.labelFlight.TabIndex = 0;
            this.labelFlight.Text = "XX0000";
            this.labelFlight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBSM
            // 
            this.groupBSM.Controls.Add(this.panelBSM);
            this.groupBSM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBSM.Location = new System.Drawing.Point(12, 238);
            this.groupBSM.Name = "groupBSM";
            this.groupBSM.Size = new System.Drawing.Size(700, 200);
            this.groupBSM.TabIndex = 1;
            this.groupBSM.TabStop = false;
            this.groupBSM.Text = "BSM_2DAY";
            // 
            // panelBSM
            // 
            this.panelBSM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelBSM.Controls.Add(this.text_CabinClass_BSM);
            this.panelBSM.Controls.Add(this.labelCabinClass);
            this.panelBSM.Controls.Add(this.dataGridBSM);
            this.panelBSM.Controls.Add(this.button_CONFIRM_BSM);
            this.panelBSM.Controls.Add(this.button_CLEAR_BSM);
            this.panelBSM.Controls.Add(this.text_Number_BSM);
            this.panelBSM.Controls.Add(this.labelDataNumber);
            this.panelBSM.Controls.Add(this.text_BagState_BSM);
            this.panelBSM.Controls.Add(this.labelBagState);
            this.panelBSM.Location = new System.Drawing.Point(5, 25);
            this.panelBSM.Name = "panelBSM";
            this.panelBSM.Size = new System.Drawing.Size(689, 170);
            this.panelBSM.TabIndex = 0;
            // 
            // text_CabinClass_BSM
            // 
            this.text_CabinClass_BSM.ForeColor = System.Drawing.Color.Silver;
            this.text_CabinClass_BSM.Location = new System.Drawing.Point(492, 132);
            this.text_CabinClass_BSM.Name = "text_CabinClass_BSM";
            this.text_CabinClass_BSM.Size = new System.Drawing.Size(50, 26);
            this.text_CabinClass_BSM.TabIndex = 8;
            this.text_CabinClass_BSM.Text = "Y";
            this.text_CabinClass_BSM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.text_CabinClass_BSM.GotFocus += new System.EventHandler(this.Text_CabinClass_BSM_GotFocus);
            this.text_CabinClass_BSM.LostFocus += new System.EventHandler(this.Text_CabinClass_BSM_LostFocus);
            // 
            // labelCabinClass
            // 
            this.labelCabinClass.AutoSize = true;
            this.labelCabinClass.Location = new System.Drawing.Point(426, 135);
            this.labelCabinClass.Name = "labelCabinClass";
            this.labelCabinClass.Size = new System.Drawing.Size(62, 20);
            this.labelCabinClass.TabIndex = 11;
            this.labelCabinClass.Text = "CLASS";
            // 
            // dataGridBSM
            // 
            this.dataGridBSM.AllowUserToAddRows = false;
            this.dataGridBSM.AllowUserToDeleteRows = false;
            this.dataGridBSM.AllowUserToResizeRows = false;
            this.dataGridBSM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridBSM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BAG_TAG_B,
            this.BSM_DATE_B,
            this.FLIGHT_NO_B,
            this.BAG_STATE_B,
            this.CABIN_CLASS_B});
            this.dataGridBSM.Location = new System.Drawing.Point(15, 15);
            this.dataGridBSM.MultiSelect = false;
            this.dataGridBSM.Name = "dataGridBSM";
            this.dataGridBSM.ReadOnly = true;
            this.dataGridBSM.RowHeadersVisible = false;
            this.dataGridBSM.Size = new System.Drawing.Size(405, 140);
            this.dataGridBSM.TabIndex = 0;
            this.dataGridBSM.Text = "dataGridView2";
            // 
            // BAG_TAG_B
            // 
            this.BAG_TAG_B.HeaderText = "BAG_TAG";
            this.BAG_TAG_B.Name = "BAG_TAG_B";
            this.BAG_TAG_B.ReadOnly = true;
            this.BAG_TAG_B.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BAG_TAG_B.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.BAG_TAG_B.Width = 108;
            // 
            // BSM_DATE_B
            // 
            this.BSM_DATE_B.HeaderText = "DATE";
            this.BSM_DATE_B.Name = "BSM_DATE_B";
            this.BSM_DATE_B.ReadOnly = true;
            this.BSM_DATE_B.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BSM_DATE_B.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.BSM_DATE_B.Width = 86;
            // 
            // FLIGHT_NO_B
            // 
            this.FLIGHT_NO_B.HeaderText = "FLIGHT_NO";
            this.FLIGHT_NO_B.Name = "FLIGHT_NO_B";
            this.FLIGHT_NO_B.ReadOnly = true;
            this.FLIGHT_NO_B.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FLIGHT_NO_B.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.FLIGHT_NO_B.Width = 108;
            // 
            // BAG_STATE_B
            // 
            this.BAG_STATE_B.HeaderText = "BAG_STATE";
            this.BAG_STATE_B.Name = "BAG_STATE_B";
            this.BAG_STATE_B.ReadOnly = true;
            this.BAG_STATE_B.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BAG_STATE_B.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.BAG_STATE_B.Width = 112;
            // 
            // CABIN_CLASS_B
            // 
            this.CABIN_CLASS_B.HeaderText = "CABIN_CLASS";
            this.CABIN_CLASS_B.Name = "CABIN_CLASS_B";
            this.CABIN_CLASS_B.ReadOnly = true;
            this.CABIN_CLASS_B.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CABIN_CLASS_B.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.CABIN_CLASS_B.Width = 128;
            // 
            // button_CONFIRM_BSM
            // 
            this.button_CONFIRM_BSM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button_CONFIRM_BSM.ForeColor = System.Drawing.Color.Green;
            this.button_CONFIRM_BSM.Location = new System.Drawing.Point(579, 47);
            this.button_CONFIRM_BSM.Name = "button_CONFIRM_BSM";
            this.button_CONFIRM_BSM.Size = new System.Drawing.Size(100, 30);
            this.button_CONFIRM_BSM.TabIndex = 9;
            this.button_CONFIRM_BSM.Text = "CONFIRM";
            this.button_CONFIRM_BSM.UseVisualStyleBackColor = true;
            this.button_CONFIRM_BSM.Click += new System.EventHandler(this.Button_CONFIRM_BSM_Click);
            // 
            // button_CLEAR_BSM
            // 
            this.button_CLEAR_BSM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button_CLEAR_BSM.ForeColor = System.Drawing.Color.Maroon;
            this.button_CLEAR_BSM.Location = new System.Drawing.Point(579, 89);
            this.button_CLEAR_BSM.Name = "button_CLEAR_BSM";
            this.button_CLEAR_BSM.Size = new System.Drawing.Size(100, 30);
            this.button_CLEAR_BSM.TabIndex = 10;
            this.button_CLEAR_BSM.Text = "CLEAR";
            this.button_CLEAR_BSM.UseVisualStyleBackColor = true;
            this.button_CLEAR_BSM.Click += new System.EventHandler(this.Button_CLEAR_BSM_Click);
            // 
            // text_Number_BSM
            // 
            this.text_Number_BSM.ForeColor = System.Drawing.Color.Silver;
            this.text_Number_BSM.Location = new System.Drawing.Point(492, 47);
            this.text_Number_BSM.Name = "text_Number_BSM";
            this.text_Number_BSM.Size = new System.Drawing.Size(50, 26);
            this.text_Number_BSM.TabIndex = 6;
            this.text_Number_BSM.Text = "1";
            this.text_Number_BSM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.text_Number_BSM.GotFocus += new System.EventHandler(this.Text_Number_BSM_GotFocus);
            this.text_Number_BSM.LostFocus += new System.EventHandler(this.Text_Number_BSM_LostFocus);
            // 
            // labelDataNumber
            // 
            this.labelDataNumber.AutoSize = true;
            this.labelDataNumber.Location = new System.Drawing.Point(425, 47);
            this.labelDataNumber.Name = "labelDataNumber";
            this.labelDataNumber.Size = new System.Drawing.Size(57, 20);
            this.labelDataNumber.TabIndex = 0;
            this.labelDataNumber.Text = "Data #";
            this.labelDataNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // text_BagState_BSM
            // 
            this.text_BagState_BSM.ForeColor = System.Drawing.Color.Silver;
            this.text_BagState_BSM.Location = new System.Drawing.Point(492, 89);
            this.text_BagState_BSM.Name = "text_BagState_BSM";
            this.text_BagState_BSM.Size = new System.Drawing.Size(50, 26);
            this.text_BagState_BSM.TabIndex = 7;
            this.text_BagState_BSM.Text = "0";
            this.text_BagState_BSM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.text_BagState_BSM.GotFocus += new System.EventHandler(this.Text_BagState_BSM_GotFocus);
            this.text_BagState_BSM.LostFocus += new System.EventHandler(this.Text_BagState_BSM_LostFocus);
            // 
            // labelBagState
            // 
            this.labelBagState.AutoSize = true;
            this.labelBagState.Location = new System.Drawing.Point(426, 92);
            this.labelBagState.Name = "labelBagState";
            this.labelBagState.Size = new System.Drawing.Size(60, 20);
            this.labelBagState.TabIndex = 10;
            this.labelBagState.Text = "STATE";
            // 
            // text_USER
            // 
            this.text_USER.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.text_USER.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.text_USER.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.text_USER.ForeColor = System.Drawing.Color.Red;
            this.text_USER.Location = new System.Drawing.Point(632, 12);
            this.text_USER.Name = "text_USER";
            this.text_USER.Size = new System.Drawing.Size(80, 26);
            this.text_USER.TabIndex = 10;
            this.text_USER.Text = "asitest";
            this.text_USER.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 450);
            this.Controls.Add(this.text_USER);
            this.Controls.Add(this.groupBSM);
            this.Controls.Add(this.groupFIDS);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "BRS Test Data Generator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupFIDS.ResumeLayout(false);
            this.panelFIDS.ResumeLayout(false);
            this.panelFIDS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFLT)).EndInit();
            this.groupBSM.ResumeLayout(false);
            this.panelBSM.ResumeLayout(false);
            this.panelBSM.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBSM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupFIDS;
        private System.Windows.Forms.Panel panelFIDS;
        private System.Windows.Forms.GroupBox groupBSM;
        private System.Windows.Forms.Panel panelBSM;
        private System.Windows.Forms.Button button_Clear_FIDS;
        private System.Windows.Forms.Button button_Confirm_FIDS;
        private System.Windows.Forms.TextBox text_DES_FIDS;
        private System.Windows.Forms.Label labelDES;
        private System.Windows.Forms.Label labelETD;
        private System.Windows.Forms.TextBox text_ETD_FIDS;
        private System.Windows.Forms.Label labelSTD;
        private System.Windows.Forms.TextBox text_STD_FIDS;
        private System.Windows.Forms.Label labelFlight;
        private System.Windows.Forms.Button button_CONFIRM_BSM;
        private System.Windows.Forms.Button button_CLEAR_BSM;
        private System.Windows.Forms.TextBox text_Number_BSM;
        private System.Windows.Forms.Label labelDataNumber;
        private System.Windows.Forms.DataGridView dataGridFLT;
        private System.Windows.Forms.DataGridView dataGridBSM;
        private System.Windows.Forms.TextBox text_USER;
        private System.Windows.Forms.TextBox text_BagState_BSM;
        private System.Windows.Forms.Label labelBagState;
        private System.Windows.Forms.DataGridViewTextBoxColumn FLIGHT_NO_C;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATE_C;
        private System.Windows.Forms.DataGridViewTextBoxColumn STD_C;
        private System.Windows.Forms.DataGridViewTextBoxColumn ETD_C;
        private System.Windows.Forms.DataGridViewTextBoxColumn DES_C;
        private System.Windows.Forms.DataGridViewTextBoxColumn BAG_TAG_B;
        private System.Windows.Forms.DataGridViewTextBoxColumn BSM_DATE_B;
        private System.Windows.Forms.DataGridViewTextBoxColumn FLIGHT_NO_B;
        private System.Windows.Forms.DataGridViewTextBoxColumn BAG_STATE_B;
        private System.Windows.Forms.DataGridViewTextBoxColumn CABIN_CLASS_B;
        private System.Windows.Forms.TextBox text_CabinClass_BSM;
        private System.Windows.Forms.Label labelCabinClass;
    }
}

