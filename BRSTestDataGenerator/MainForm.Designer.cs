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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "FLIGHT_NO"}, -1, System.Drawing.Color.Empty, System.Drawing.SystemColors.Window, null);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("DATE");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("STD");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("ETD");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("DES");
            this.Panel_Control = new System.Windows.Forms.Panel();
            this.List_Flight = new System.Windows.Forms.ListView();
            this.ListHead_FlightNo = new System.Windows.Forms.ColumnHeader();
            this.ListHead_Date = new System.Windows.Forms.ColumnHeader();
            this.ListHead_Bags = new System.Windows.Forms.ColumnHeader();
            this.Main_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.Button_AddFlight = new System.Windows.Forms.ToolStripButton();
            this.Button_AddBag = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Button_Undo = new System.Windows.Forms.ToolStripButton();
            this.Button_Redo = new System.Windows.Forms.ToolStripButton();
            this.Button_Reload = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Button_Reset = new System.Windows.Forms.ToolStripButton();
            this.Button_Delete = new System.Windows.Forms.ToolStripButton();
            this.Group_Control = new System.Windows.Forms.GroupBox();
            this.Group_Property = new System.Windows.Forms.GroupBox();
            this.List_Properties = new System.Windows.Forms.ListView();
            this.ListHead_Name_Prop = new System.Windows.Forms.ColumnHeader();
            this.ListHead_Value_Prop = new System.Windows.Forms.ColumnHeader();
            this.Label_FlightProp = new System.Windows.Forms.Label();
            this.List_Baggage = new System.Windows.Forms.ListView();
            this.ListHead_BagTag = new System.Windows.Forms.ColumnHeader();
            this.ListHead_BsmDate = new System.Windows.Forms.ColumnHeader();
            this.ListHead_BsmFlight = new System.Windows.Forms.ColumnHeader();
            this.ListHead_BagState = new System.Windows.Forms.ColumnHeader();
            this.ListHead_CabinClass = new System.Windows.Forms.ColumnHeader();
            this.ListHead_AuthLoad = new System.Windows.Forms.ColumnHeader();
            this.ListHead_AuthTransport = new System.Windows.Forms.ColumnHeader();
            this.Panel_ShowList = new System.Windows.Forms.Panel();
            this.Text_BagAmend = new System.Windows.Forms.TextBox();
            this.Panel_Control.SuspendLayout();
            this.Main_ToolStrip.SuspendLayout();
            this.Group_Control.SuspendLayout();
            this.Group_Property.SuspendLayout();
            this.Panel_ShowList.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel_Control
            // 
            this.Panel_Control.Controls.Add(this.List_Flight);
            this.Panel_Control.Controls.Add(this.Main_ToolStrip);
            this.Panel_Control.Location = new System.Drawing.Point(0, 22);
            this.Panel_Control.Name = "Panel_Control";
            this.Panel_Control.Size = new System.Drawing.Size(244, 317);
            this.Panel_Control.TabIndex = 11;
            // 
            // List_Flight
            // 
            this.List_Flight.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ListHead_FlightNo,
            this.ListHead_Date,
            this.ListHead_Bags});
            this.List_Flight.FullRowSelect = true;
            this.List_Flight.GridLines = true;
            this.List_Flight.HideSelection = false;
            this.List_Flight.Location = new System.Drawing.Point(7, 35);
            this.List_Flight.Name = "List_Flight";
            this.List_Flight.Size = new System.Drawing.Size(222, 276);
            this.List_Flight.TabIndex = 1;
            this.List_Flight.UseCompatibleStateImageBehavior = false;
            this.List_Flight.View = System.Windows.Forms.View.Details;
            this.List_Flight.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.List_Flight_SlcChg);
            // 
            // ListHead_FlightNo
            // 
            this.ListHead_FlightNo.Text = "FLIGHT_NO";
            this.ListHead_FlightNo.Width = 80;
            // 
            // ListHead_Date
            // 
            this.ListHead_Date.Text = "DATE";
            this.ListHead_Date.Width = 70;
            // 
            // ListHead_Bags
            // 
            this.ListHead_Bags.Text = "BAGS";
            this.ListHead_Bags.Width = 50;
            // 
            // Main_ToolStrip
            // 
            this.Main_ToolStrip.AutoSize = false;
            this.Main_ToolStrip.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.Main_ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Button_AddFlight,
            this.Button_AddBag,
            this.toolStripSeparator1,
            this.Button_Undo,
            this.Button_Redo,
            this.Button_Reload,
            this.toolStripSeparator2,
            this.Button_Reset,
            this.Button_Delete});
            this.Main_ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.Main_ToolStrip.Name = "Main_ToolStrip";
            this.Main_ToolStrip.Size = new System.Drawing.Size(244, 32);
            this.Main_ToolStrip.TabIndex = 0;
            this.Main_ToolStrip.Text = "toolStrip1";
            // 
            // Button_AddFlight
            // 
            this.Button_AddFlight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_AddFlight.Image = ((System.Drawing.Image)(resources.GetObject("Button_AddFlight.Image")));
            this.Button_AddFlight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button_AddFlight.Name = "Button_AddFlight";
            this.Button_AddFlight.Size = new System.Drawing.Size(29, 29);
            this.Button_AddFlight.Text = "Add Flight Data";
            this.Button_AddFlight.Click += new System.EventHandler(this.Button_AddFlight_Click);
            // 
            // Button_AddBag
            // 
            this.Button_AddBag.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_AddBag.Enabled = false;
            this.Button_AddBag.Image = ((System.Drawing.Image)(resources.GetObject("Button_AddBag.Image")));
            this.Button_AddBag.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button_AddBag.Name = "Button_AddBag";
            this.Button_AddBag.Size = new System.Drawing.Size(29, 29);
            this.Button_AddBag.Text = "Add Baggage Data";
            this.Button_AddBag.Click += new System.EventHandler(this.Button_AddBag_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // Button_Undo
            // 
            this.Button_Undo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_Undo.Enabled = false;
            this.Button_Undo.Image = ((System.Drawing.Image)(resources.GetObject("Button_Undo.Image")));
            this.Button_Undo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button_Undo.Name = "Button_Undo";
            this.Button_Undo.Size = new System.Drawing.Size(29, 29);
            this.Button_Undo.Text = "Undo";
            // 
            // Button_Redo
            // 
            this.Button_Redo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_Redo.Enabled = false;
            this.Button_Redo.Image = ((System.Drawing.Image)(resources.GetObject("Button_Redo.Image")));
            this.Button_Redo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button_Redo.Name = "Button_Redo";
            this.Button_Redo.Size = new System.Drawing.Size(29, 29);
            this.Button_Redo.Text = "Redo";
            // 
            // Button_Reload
            // 
            this.Button_Reload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_Reload.Image = ((System.Drawing.Image)(resources.GetObject("Button_Reload.Image")));
            this.Button_Reload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button_Reload.Name = "Button_Reload";
            this.Button_Reload.Size = new System.Drawing.Size(29, 29);
            this.Button_Reload.Text = "Reload Data";
            this.Button_Reload.Click += new System.EventHandler(this.Button_Reload_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 32);
            // 
            // Button_Reset
            // 
            this.Button_Reset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_Reset.Enabled = false;
            this.Button_Reset.Image = ((System.Drawing.Image)(resources.GetObject("Button_Reset.Image")));
            this.Button_Reset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button_Reset.Name = "Button_Reset";
            this.Button_Reset.Size = new System.Drawing.Size(29, 29);
            this.Button_Reset.Text = "Reset Selected Data";
            this.Button_Reset.Click += new System.EventHandler(this.Button_Reset_Click);
            // 
            // Button_Delete
            // 
            this.Button_Delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_Delete.Enabled = false;
            this.Button_Delete.Image = ((System.Drawing.Image)(resources.GetObject("Button_Delete.Image")));
            this.Button_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button_Delete.Name = "Button_Delete";
            this.Button_Delete.Size = new System.Drawing.Size(29, 29);
            this.Button_Delete.Text = "Delete Selected Data";
            this.Button_Delete.Click += new System.EventHandler(this.Button_Delete_Click);
            // 
            // Group_Control
            // 
            this.Group_Control.Controls.Add(this.Panel_Control);
            this.Group_Control.Location = new System.Drawing.Point(12, 12);
            this.Group_Control.Name = "Group_Control";
            this.Group_Control.Size = new System.Drawing.Size(244, 339);
            this.Group_Control.TabIndex = 12;
            this.Group_Control.TabStop = false;
            this.Group_Control.Text = "Control Panel";
            // 
            // Group_Property
            // 
            this.Group_Property.Controls.Add(this.List_Properties);
            this.Group_Property.Controls.Add(this.Label_FlightProp);
            this.Group_Property.Location = new System.Drawing.Point(12, 358);
            this.Group_Property.Name = "Group_Property";
            this.Group_Property.Size = new System.Drawing.Size(244, 201);
            this.Group_Property.TabIndex = 13;
            this.Group_Property.TabStop = false;
            this.Group_Property.Text = "Properties";
            // 
            // List_Properties
            // 
            this.List_Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.List_Properties.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ListHead_Name_Prop,
            this.ListHead_Value_Prop});
            this.List_Properties.Enabled = false;
            this.List_Properties.FullRowSelect = true;
            this.List_Properties.HideSelection = false;
            this.List_Properties.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5});
            this.List_Properties.Location = new System.Drawing.Point(7, 38);
            this.List_Properties.Name = "List_Properties";
            this.List_Properties.Size = new System.Drawing.Size(222, 157);
            this.List_Properties.TabIndex = 1;
            this.List_Properties.UseCompatibleStateImageBehavior = false;
            this.List_Properties.View = System.Windows.Forms.View.Details;
            // 
            // ListHead_Name_Prop
            // 
            this.ListHead_Name_Prop.Text = "Name";
            this.ListHead_Name_Prop.Width = 100;
            // 
            // ListHead_Value_Prop
            // 
            this.ListHead_Value_Prop.Text = "Value";
            this.ListHead_Value_Prop.Width = 100;
            // 
            // Label_FlightProp
            // 
            this.Label_FlightProp.AutoSize = true;
            this.Label_FlightProp.BackColor = System.Drawing.SystemColors.Control;
            this.Label_FlightProp.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Label_FlightProp.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.Label_FlightProp.Location = new System.Drawing.Point(6, 18);
            this.Label_FlightProp.Name = "Label_FlightProp";
            this.Label_FlightProp.Size = new System.Drawing.Size(223, 16);
            this.Label_FlightProp.TabIndex = 0;
            this.Label_FlightProp.Text = "Detailed properties of a selected flight";
            // 
            // List_Baggage
            // 
            this.List_Baggage.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.List_Baggage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ListHead_BagTag,
            this.ListHead_BsmDate,
            this.ListHead_BsmFlight,
            this.ListHead_BagState,
            this.ListHead_CabinClass,
            this.ListHead_AuthLoad,
            this.ListHead_AuthTransport});
            this.List_Baggage.FullRowSelect = true;
            this.List_Baggage.GridLines = true;
            this.List_Baggage.HideSelection = false;
            this.List_Baggage.Location = new System.Drawing.Point(0, 0);
            this.List_Baggage.Name = "List_Baggage";
            this.List_Baggage.Size = new System.Drawing.Size(688, 537);
            this.List_Baggage.TabIndex = 14;
            this.List_Baggage.UseCompatibleStateImageBehavior = false;
            this.List_Baggage.View = System.Windows.Forms.View.Details;
            this.List_Baggage.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.List_Baggage_SlcChg);
            this.List_Baggage.Leave += new System.EventHandler(this.List_Baggage_LostFocus);
            this.List_Baggage.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.List_Baggage_MouseDoubleClick);
            // 
            // ListHead_BagTag
            // 
            this.ListHead_BagTag.Text = "BAG_TAG";
            this.ListHead_BagTag.Width = 100;
            // 
            // ListHead_BsmDate
            // 
            this.ListHead_BsmDate.Text = "DATE";
            this.ListHead_BsmDate.Width = 80;
            // 
            // ListHead_BsmFlight
            // 
            this.ListHead_BsmFlight.Text = "FLIGHT_NO";
            this.ListHead_BsmFlight.Width = 100;
            // 
            // ListHead_BagState
            // 
            this.ListHead_BagState.Text = "BAG_STATE";
            this.ListHead_BagState.Width = 80;
            // 
            // ListHead_CabinClass
            // 
            this.ListHead_CabinClass.Text = "CABIN_CLASS";
            this.ListHead_CabinClass.Width = 90;
            // 
            // ListHead_AuthLoad
            // 
            this.ListHead_AuthLoad.Text = "AUTH_LOAD";
            this.ListHead_AuthLoad.Width = 90;
            // 
            // ListHead_AuthTransport
            // 
            this.ListHead_AuthTransport.Text = "AUTH_TRANSPORT";
            this.ListHead_AuthTransport.Width = 130;
            // 
            // Panel_ShowList
            // 
            this.Panel_ShowList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Panel_ShowList.Controls.Add(this.Text_BagAmend);
            this.Panel_ShowList.Controls.Add(this.List_Baggage);
            this.Panel_ShowList.Location = new System.Drawing.Point(259, 20);
            this.Panel_ShowList.Name = "Panel_ShowList";
            this.Panel_ShowList.Size = new System.Drawing.Size(690, 539);
            this.Panel_ShowList.TabIndex = 15;
            // 
            // Text_BagAmend
            // 
            this.Text_BagAmend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Text_BagAmend.Location = new System.Drawing.Point(204, 37);
            this.Text_BagAmend.Name = "Text_BagAmend";
            this.Text_BagAmend.Size = new System.Drawing.Size(100, 23);
            this.Text_BagAmend.TabIndex = 15;
            this.Text_BagAmend.Visible = false;
            this.Text_BagAmend.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Text_BagAmend_Enter);
            this.Text_BagAmend.Leave += new System.EventHandler(this.Text_BagAmend_LoseFocus);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 571);
            this.Controls.Add(this.Panel_ShowList);
            this.Controls.Add(this.Group_Property);
            this.Controls.Add(this.Group_Control);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "BRS Test Data Generator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Panel_Control.ResumeLayout(false);
            this.Main_ToolStrip.ResumeLayout(false);
            this.Main_ToolStrip.PerformLayout();
            this.Group_Control.ResumeLayout(false);
            this.Group_Property.ResumeLayout(false);
            this.Group_Property.PerformLayout();
            this.Panel_ShowList.ResumeLayout(false);
            this.Panel_ShowList.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Panel_Control;
        private System.Windows.Forms.ToolStrip Main_ToolStrip;
        private System.Windows.Forms.ToolStripButton Button_AddFlight;
        private System.Windows.Forms.ToolStripButton Button_AddBag;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton Button_Undo;
        private System.Windows.Forms.ToolStripButton Button_Redo;
        private System.Windows.Forms.ToolStripButton Button_Reload;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton Button_Reset;
        private System.Windows.Forms.ToolStripButton Button_Delete;
        private System.Windows.Forms.GroupBox Group_Control;
        private System.Windows.Forms.GroupBox Group_Property;
        private System.Windows.Forms.Label Label_FlightProp;
        private System.Windows.Forms.ListView List_Flight;
        private System.Windows.Forms.ColumnHeader ListHead_FlightNo;
        private System.Windows.Forms.ColumnHeader ListHead_Date;
        private System.Windows.Forms.ColumnHeader ListHead_Bags;
        private System.Windows.Forms.ListView List_Properties;
        private System.Windows.Forms.ColumnHeader ListHead_Name_Prop;
        private System.Windows.Forms.ColumnHeader ListHead_Value_Prop;
        private System.Windows.Forms.ListView List_Baggage;
        private System.Windows.Forms.ColumnHeader ListHead_BagTag;
        private System.Windows.Forms.ColumnHeader ListHead_BsmDate;
        private System.Windows.Forms.ColumnHeader ListHead_BsmFlight;
        private System.Windows.Forms.ColumnHeader ListHead_BagState;
        private System.Windows.Forms.ColumnHeader ListHead_CabinClass;
        private System.Windows.Forms.Panel Panel_ShowList;
        private System.Windows.Forms.ColumnHeader ListHead_AuthLoad;
        private System.Windows.Forms.ColumnHeader ListHead_AuthTransport;
        private System.Windows.Forms.TextBox Text_BagAmend;
    }
}

