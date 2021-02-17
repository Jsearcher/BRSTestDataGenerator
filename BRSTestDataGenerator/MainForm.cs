using BRSTestDataGenerator.ConfigScript;
using BRSTestDataGenerator.DAO;
using Lib.DB;
using Lib.Log;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BRSTestDataGenerator
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 暫存字串
        /// </summary>
        private string tempStr = string.Empty;

        #region =====[Private] App Configuration=====

        /// <summary>
        /// T1BRSDB供此Form Application使用之資料庫連線參數
        /// </summary>
        private static readonly string T1BRSDB_ConnStr = AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.DBServer.T1BRSDB;

        /// <summary>
        /// 此Form Application執行模式
        /// </summary>
        /// <remarks>
        /// <para>0: 表示為測試模式</para>
        /// <para>1: 表示為正式運行模式</para>
        /// </remarks>
        private static readonly string App_Mode = AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.Basic.Mode;

        /// <summary>
        /// 此Form Application執行模式為測試模式時，所使用的測試日期，格式為"yyyy-MM-dd"
        /// </summary>
        private static readonly string TestDate = AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.Basic.TestDate;

        /// <summary>
        /// 下一個新增之航班編號，預設為"XX0001"
        /// </summary>
        private string TargetFlight = AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.Default.FlightNo;

        #endregion

        #region =====[Public] Constructor & Destructor=====

        /// <summary>
        /// 建構子
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            List_Baggage.Controls.Add(Text_BagAmend);
        }

        #endregion

        #region =====[Private] EventHandler=====

        private void MainForm_Load(object sender, EventArgs e)
        {
            InfoLog.Log("BRSTestDataGenerator", "MainForm", "MainForm of [BRS Test Data Generator] initialized.");
            RefreshForm();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 清除回復、重複步驟記錄
            //List<string> undoKeys = AppConfig.AppPropertySetting.Instance().GetCollectionPropertyNames(AppConfig.AppPropSection.UndoCollection);
            //undoKeys.ForEach(key => AppConfig.AppPropertySetting.Instance().RemoveProperty(key, AppConfig.AppPropSection.UndoCollection));
            //AppConfig.AppPropertySetting.Instance().AddProperty(new AppConfig.AppPropElement("Undo_Base_00", "DoNotRemove"), AppConfig.AppPropSection.UndoCollection);
            List<string> undoKeys = AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.Undo;
            undoKeys.RemoveAll(s => !s.StartsWith("Undo_Base"));
            //List<string> redoKeys = AppConfig.AppPropertySetting.Instance().GetCollectionPropertyNames(AppConfig.AppPropSection.RedoCollection);
            //redoKeys.ForEach(key => AppConfig.AppPropertySetting.Instance().RemoveProperty(key, AppConfig.AppPropSection.RedoCollection));
            //AppConfig.AppPropertySetting.Instance().AddProperty(new AppConfig.AppPropElement("Redo_Base_00", "DoNotRemove"), AppConfig.AppPropSection.RedoCollection);
            List<string> redoKeys = AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.Redo;
            redoKeys.RemoveAll(s => !s.StartsWith("Redo_Base"));
            
            InfoLog.Log("BRSTestDataGenerator", "MainForm", "MainForm of [BRS Test Data Generator] Closed.");
        }

        private void ChildForm_AddFlight_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 取出最後回復步驟記錄並確認是否為新增航班動作
            List<string> undoKeys = AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.Undo;
            if (undoKeys.Count > 0)
            {
                if (undoKeys[^1].StartsWith("A_F"))
                {
                    RefreshForm();
                    InfoLog.Log("BRSTestDataGenerator", "MainForm", "ChildForm of [Add a New Flight Data] Closed, refreshing the screen.");
                }
            }
        }

        private void ChildForm_AddBag_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 取出最後回復步驟記錄並確認是否為新增行李動作
            List<string> undoKeys = AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.Undo;
            if (undoKeys.Count > 0)
            {
                if (undoKeys[^1].StartsWith("A_B"))
                {
                    // 重新整理行李顯示畫面...
                    if (List_Flight.SelectedItems.Count > 0)
                    {
                        List<BSM2Day.Row> List_BSM = GetSelectedBSM(List_Flight.SelectedItems[0].SubItems[0].Text);
                        List_Baggage.Items.Clear();
                        if (List_BSM != null)
                        {
                            List_BSM.ForEach(obj => List_Baggage.Items.Add(
                                new ListViewItem(new string[] { obj.BAG_TAG, obj.BSM_DATE, obj.BSM_FLIGHT, obj.BAG_STATE.ToString(), obj.CABIN_CLASS, obj.AUTH_LOAD, obj.AUTH_TRANSPORT })
                                ));
                            List_Flight.SelectedItems[0].SubItems[2].Text = List_BSM.Count.ToString();
                        }
                    }
                    InfoLog.Log("BRSTestDataGenerator", "MainForm", "ChildForm of [Add Test Baggage Data] Closed, refreshing the screen.");
                }
            }
        }

        #region ### [Click] ###
        private void Button_AddFlight_Click(object sender, EventArgs e)
        {
            InfoLog.Log("BRSTestDataGenerator", "MainForm", "Click <Add Flight Data> button to show the childForm of [Add a New Flight Data].");
            ChildForm_AddFlight addFlight = new ChildForm_AddFlight(TargetFlight);
            addFlight.FormClosed += ChildForm_AddFlight_FormClosed;
            addFlight.ShowDialog();
        }

        private void Button_AddBag_Click(object sender, EventArgs e)
        {
            InfoLog.Log("BRSTestDataGenerator", "MainForm", "Click <Add Baggage Data> button to show the childForm of [Add Test Baggage Data].");
            if (List_Flight.SelectedItems.Count > 0)
            {
                string queryDate = App_Mode == "0" ?
                    DateTime.ParseExact(TestDate, "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString("yyyyMMdd") :
                    DateTime.Now.ToString("yyyyMMdd");
                if (List_Flight.SelectedItems[0].SubItems[1].Text == queryDate)
                {
                    ChildForm_AddBag addBag = new ChildForm_AddBag(List_Flight.SelectedItems[0].SubItems[0].Text);
                    addBag.FormClosed += ChildForm_AddBag_FormClosed;
                    addBag.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Please select a flight operated in today.", "Warning", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("You did not select a flight operated in today yet.", "Warning", MessageBoxButtons.OK);
            }
        }

        private void Button_Reload_Click(object sender, EventArgs e)
        {
            InfoLog.Log("BRSTestDataGenerator", "MainForm", "Click <Reloaded Data> button to reload FIDS and BSM data.");
            RefreshForm();
        }

        private void Button_Reset_Click(object sender, EventArgs e)
        {
            InfoLog.Log("BRSTestDataGenerator", "MainForm", "Click <Reset Data> button to initialize BSM data.");
            if (List_Baggage.SelectedItems.Count > 0)
            {
                if (List_Baggage.SelectedItems.Count > 0)
                {
                    // 顯示異動確認之對話方塊作再次確認
                    InfoLog.Log("BRSTestDataGenerator", "MainForm", "Double confirm whether to complete this FIDS deletion or not.");
                    DialogResult doubleConfirm = MessageBox.Show("Are you sure to reset the selected BSM data?", "Confirm", MessageBoxButtons.YesNo);
                    if (doubleConfirm == DialogResult.Yes)
                    {
                        // 異動確認之對話方塊選擇"Yes"
                        InfoLog.Log("BRSTestDataGenerator", "MainForm", "Sure to complete this BSM data reset.");
                        foreach (ListViewItem item in List_Baggage.SelectedItems)
                        {
                            BSM2Day.Row row = GetOneBSM(item.SubItems[0].Text);
                            tempStr = string.Format("BAG_STATE:{0},CABIN_CLASS:{1},BSM_STATE:{2},AUTH_LOAD:{3},AUTH_TRANSPORT:{4}",
                                                    row.BAG_STATE, row.CABIN_CLASS, row.BSM_STATE, row.AUTH_LOAD, row.AUTH_TRANSPORT);
                            row.BAG_STATE = int.Parse(AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.Default.BagState);
                            row.CABIN_CLASS = AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.Default.CabinClass;
                            row.BSM_STATE = int.Parse(AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.Default.BsmState);
                            row.AUTH_LOAD = AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.Default.AuthLoad;
                            row.AUTH_TRANSPORT = AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.Default.AuthTransport;
                            if (ModifyTestBSM(row))
                            {
                                // 回復步驟記錄修改行李動作與行李條碼編號及修改變數、修改前數值...
                                List<string> undoKeys = AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.Undo;
                                int undoNo = undoKeys.Count > 0 ? int.Parse(undoKeys[^1].Split("|")[0].Split("_")[2]) + 1 : 1;
                                //AppJsonConfig.AppPropertySetting.Instance().AddProperty(new AppConfig.AppPropElement("M_B_" + undoNo.ToString().PadLeft(2, '0'), row.BAG_TAG + "#" + tempStr), AppConfig.AppPropSection.UndoCollection);
                                //AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.Undo.Add(string.Format("{0}|{1}", "M_B_" + undoNo.ToString().PadLeft(2, '0'), row.BAG_TAG + "#" + tempStr));
                                // 需新增回復記錄...
                                // 顯示重置後所選取航班之行李資料
                                List<BSM2Day.Row> List_BSM = GetSelectedBSM(List_Flight.SelectedItems[0].SubItems[0].Text);
                                List_Baggage.Items.Clear();
                                if (List_BSM != null)
                                {
                                    List_BSM.ForEach(obj => List_Baggage.Items.Add(
                                        new ListViewItem(new string[] { obj.BAG_TAG, obj.BSM_DATE, obj.BSM_FLIGHT, obj.BAG_STATE.ToString(), obj.CABIN_CLASS, obj.AUTH_LOAD, obj.AUTH_TRANSPORT })
                                        ));
                                    List_Flight.SelectedItems[0].SubItems[2].Text = List_BSM.Count.ToString();
                                }
                            }
                        }
                    }
                    else
                    {
                        // 異動確認之對話方塊選擇"No"
                        // Do Nothig...
                        InfoLog.Log("BRSTestDataGenerator", "MainForm", "Not to do this BSM data reset.");
                    }
                }
            }
        }

        private void Button_Delete_Click(object sender, EventArgs e)
        {
            InfoLog.Log("BRSTestDataGenerator", "MainForm", "Click <Delete Data> button to delete selected FIDS or BSM data.");
            // 所點選航班刪除
            if (List_Flight.SelectedItems.Count > 0 && List_Baggage.SelectedItems.Count == 0)
            {
                // 顯示異動確認之對話方塊作再次確認
                InfoLog.Log("BRSTestDataGenerator", "MainForm", "Double confirm whether to complete this FIDS deletion or not.");
                DialogResult doubleConfirm = MessageBox.Show("Are you sure to clear the selected FIDS data?", "Confirm", MessageBoxButtons.YesNo);
                if (doubleConfirm == DialogResult.Yes)
                {
                    // 異動確認之對話方塊選擇"Yes"
                    InfoLog.Log("BRSTestDataGenerator", "MainForm", "Sure to complete this FIDS deletion.");
                    if (List_Flight.SelectedItems.Count == List_Flight.Items.Count)
                    {
                        InfoLog.Log("BRSTestDataGenerator", "MainForm", "Start to delete all FIDS test data.");
                        if (DeleteAllTestFIDS())
                        {
                            InfoLog.Log("BRSTestDataGenerator", "MainForm", "All FIDS test data have been deleted.");
                            RefreshForm();
                        }
                    }
                    else
                    {
                        InfoLog.Log("BRSTestDataGenerator", "MainForm", "Start to delete selected FIDS test data.");
                        foreach (ListViewItem item in List_Flight.SelectedItems)
                        {
                            if (item.SubItems[0].Text.Last() == '*')
                            {
                                InfoLog.Log("BRSTestDataGenerator", "MainForm", string.Format("The selected FIDS test data: {0} is not existed.", item.SubItems[0].Text));
                                continue;
                            }
                            if (DeleteSelectedFIDS(item.SubItems[0].Text))
                            {
                                // 回復步驟記錄刪除航班動作與航班編號及修改變數、修改前數值...
                                List<string> undoKeys = AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.Undo;
                                int undoNo = undoKeys.Count > 0 ? int.Parse(undoKeys[^1].Split("|")[0].Split("_")[2]) + 1 : 1;
                                // 需新增回復記錄...
                                InfoLog.Log("BRSTestDataGenerator", "MainForm", string.Format("The selected FIDS test data: {0} has been deleted.", item.SubItems[0].Text));
                                RefreshForm();
                            }
                        }
                    }
                }
                else
                {
                    // 異動確認之對話方塊選擇"No"
                    // Do Nothig...
                    InfoLog.Log("BRSTestDataGenerator", "MainForm", "Not to complete this FIDS deletion.");
                }
            }

            // 所點選行李刪除
            if (List_Baggage.SelectedItems.Count > 0)
            {
                // 顯示異動確認之對話方塊作再次確認
                InfoLog.Log("BRSTestDataGenerator", "MainForm", "Double confirm whether to complete this BSM deletion or not.");
                DialogResult doubleConfirm = MessageBox.Show("Are you sure to clear all the BSM data?", "Confirm", MessageBoxButtons.YesNo);
                if (doubleConfirm == DialogResult.Yes)
                {
                    // 異動確認之對話方塊選擇"Yes"
                    InfoLog.Log("BRSTestDataGenerator", "MainForm", "Sure to complete this BSM deletion.");
                    foreach (ListViewItem item in List_Baggage.SelectedItems)
                    {
                        InfoLog.Log("BRSTestDataGenerator", "MainForm", "Start to delete selected BSM test data.");
                        if (DeleteSelectedBSM(item.SubItems[0].Text))
                        {
                            // 回復步驟記錄刪除行李動作與行李條碼編號及修改變數、修改前數值...
                            List<string> undoKeys = AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.Undo;
                            int undoNo = undoKeys.Count > 0 ? int.Parse(undoKeys[^1].Split("|")[0].Split("_")[2]) + 1 : 1;
                            // 需新增回復記錄...
                            InfoLog.Log("BRSTestDataGenerator", "MainForm", string.Format("The selected BSM test data: {0} has been deleted.", item.SubItems[0].Text));
                            RefreshForm();
                        }
                    }
                }
                else
                {
                    // 異動確認之對話方塊選擇"No"
                    // Do Nothig...
                    InfoLog.Log("BRSTestDataGenerator", "MainForm", "Not to complete this BSM deletion.");
                }
            }
        }

        private void List_Flight_SlcChg(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (List_Flight.SelectedItems.Count == 1)
            {
                // 允許使用"新增行李按鈕"、"資料列刪除按鈕"功能
                Button_AddBag.Enabled = true;
                Button_Delete.Enabled = true;

                // 顯示選取航班之屬性資料，並允許使用新增行李按鈕功能
                foreach (ListViewItem item in List_Properties.Items)
                {
                    item.SubItems[1].Text = string.Empty; // Clear all properties first
                }
                FIDS2Day.Row Selected_FIDS = GetSelectedFIDS(List_Flight.SelectedItems[0].SubItems[0].Text);
                if (Selected_FIDS != null)
                {
                    foreach (ListViewItem item in List_Properties.Items)
                    {
                        switch (item.Text)
                        {
                            case "FLIGHT_NO":
                                item.SubItems[1].Text = Selected_FIDS.FLIGHT_NO;
                                break;
                            case "DATE":
                                item.SubItems[1].Text = DateTime.ParseExact(Selected_FIDS.DATE_TIME, "yyyyMMdd", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd");
                                break;
                            case "STD":
                                item.SubItems[1].Text = DateTime.ParseExact(Selected_FIDS.STD, "HHmm", CultureInfo.InvariantCulture).ToString("HH:mm");
                                break;
                            case "ETD":
                                item.SubItems[1].Text = DateTime.ParseExact(Selected_FIDS.ETD, "HHmm", CultureInfo.InvariantCulture).ToString("HH:mm");
                                break;
                            case "DES":
                                item.SubItems[1].Text = Selected_FIDS.DESTINATION;
                                break;
                            default:
                                break;
                        }
                    }
                }

                // 顯示選取航班之行李資料
                List<BSM2Day.Row> List_BSM = GetSelectedBSM(List_Flight.SelectedItems[0].SubItems[0].Text);
                List_Baggage.Items.Clear();
                if (List_BSM != null)
                {
                    List_BSM.ForEach(obj => List_Baggage.Items.Add(
                        new ListViewItem(new string[] { obj.BAG_TAG, obj.BSM_DATE, obj.BSM_FLIGHT, obj.BAG_STATE.ToString(), obj.CABIN_CLASS, obj.AUTH_LOAD, obj.AUTH_TRANSPORT })
                        ));
                    List_Flight.SelectedItems[0].SubItems[2].Text = List_BSM.Count.ToString();
                }
            }
            else if (List_Flight.SelectedItems.Count > 1)
            {
                // 選取多筆航班不顯示屬性與行李資料
                foreach (ListViewItem item in List_Properties.Items)
                {
                    item.SubItems[1].Text = string.Empty;
                }
                List_Baggage.Items.Clear();
            }
            else
            {
                // Do Nothig...
            }
        }

        private void List_Baggage_SlcChg(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (List_Baggage.SelectedItems.Count > 0)
            {
                Button_AddBag.Enabled = false;
                Button_Reset.Enabled = true;
                Button_Delete.Enabled = true;
                if (List_Flight.SelectedItems.Count == 0)
                {
                    foreach (ListViewItem item in List_Flight.Items)
                    {
                        if (item.SubItems[0].Text == List_Baggage.SelectedItems[0].SubItems[2].Text)
                        {
                            item.Selected = true;
                            break;
                        }
                    }
                }
            }
        }

        private void List_Baggage_LostFocus(object sender, EventArgs e)
        {
            List_Baggage.SelectedIndices.Clear();
            Button_Reset.Enabled = false;
        }

        private void List_Baggage_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo hit = List_Baggage.HitTest(e.Location);
            int columnIndex = hit.Item.SubItems.IndexOf(hit.SubItem);
            switch (columnIndex)
            {
                case 0:
                    MessageBox.Show("This parameter can not be amended.", "Warning", MessageBoxButtons.OK);
                    break;
                case 1:
                    MessageBox.Show("This parameter can not be amended.", "Warning", MessageBoxButtons.OK);
                    break;
                case 2:
                    MessageBox.Show("This parameter can not be amended.", "Warning", MessageBoxButtons.OK);
                    break;
                default:
                    Rectangle rowBounds = hit.SubItem.Bounds;
                    Rectangle labelBounds = hit.Item.GetBounds(ItemBoundsPortion.Label);
                    int leftMargin = labelBounds.Left - 1;
                    Text_BagAmend.Bounds = new Rectangle(rowBounds.Left + leftMargin, rowBounds.Top, rowBounds.Width - leftMargin - 1, rowBounds.Height);
                    Text_BagAmend.Text = hit.SubItem.Text;
                    tempStr = columnIndex + ":" + hit.SubItem.Text;
                    Text_BagAmend.SelectAll();
                    Text_BagAmend.Visible = true;
                    Text_BagAmend.Focus();
                    break;
            }
        }

        private void Text_BagAmend_Enter(object sender, KeyPressEventArgs e)
        {
            InfoLog.Log("BRSTestDataGenerator", "MainForm", "Amend a specified column of BSM data.");
            if (e.KeyChar == (char)13)
            {
                if (List_Baggage.SelectedItems.Count > 0)
                {
                    // 顯示異動確認之對話方塊作再次確認
                    InfoLog.Log("BRSTestDataGenerator", "MainForm", "Double confirm whether to complete this FIDS deletion or not.");
                    DialogResult doubleConfirm = MessageBox.Show("Are you sure to amend the selected BSM data?", "Confirm", MessageBoxButtons.YesNo);
                    if (doubleConfirm == DialogResult.Yes)
                    {
                        // 異動確認之對話方塊選擇"Yes"
                        InfoLog.Log("BRSTestDataGenerator", "MainForm", "Sure to complete this BSM amendment.");
                        BSM2Day.Row row = GetOneBSM(List_Baggage.SelectedItems[0].SubItems[0].Text);
                        bool canAmend = false;
                        switch (int.Parse(tempStr.Split(":")[0]))
                        {
                            case 3:
                                if (new Regex(@"^\d*$").IsMatch(Text_BagAmend.Text) && int.TryParse(Text_BagAmend.Text, out int int_BagState_BSM))
                                {
                                    canAmend = true;
                                    row.BAG_STATE = int_BagState_BSM;
                                    tempStr = string.Format("BAG_STATE:{0}", row.BAG_STATE);
                                }
                                break;
                            case 4:
                                if (new Regex(@"[A-Z]").IsMatch(Text_BagAmend.Text))
                                {
                                    canAmend = true;
                                    row.CABIN_CLASS = Text_BagAmend.Text.ToUpper();
                                    tempStr = string.Format("CABIN_CLASS:{0}", row.CABIN_CLASS);
                                }
                                break;
                            case 5:
                                if (new Regex(@"[A-Z]").IsMatch(Text_BagAmend.Text))
                                {
                                    canAmend = true;
                                    row.AUTH_LOAD = Text_BagAmend.Text.ToUpper();
                                    tempStr = string.Format("AUTH_LOAD:{0}", row.AUTH_LOAD);
                                }
                                break;
                            case 6:
                                if (new Regex(@"[A-Z]").IsMatch(Text_BagAmend.Text))
                                {
                                    canAmend = true;
                                    row.AUTH_TRANSPORT = Text_BagAmend.Text.ToUpper();
                                    tempStr = string.Format("AUTH_TRANSPORT:{0}", row.AUTH_TRANSPORT);
                                }
                                break;
                            default:

                                break;
                        }
                        if (canAmend)
                        {
                            if (ModifyTestBSM(row))
                            {
                                // 回復步驟記錄修改行李動作與行李條碼編號及修改變數、修改前數值
                                List<string> undoKeys = AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.Undo;
                                int undoNo = undoKeys.Count > 0 ? int.Parse(undoKeys[^1].Split("|")[0].Split("_")[2]) + 1 : 1;
                                //AppConfig.AppPropertySetting.Instance().AddProperty(new AppConfig.AppPropElement("M_B_" + undoNo.ToString().PadLeft(2, '0'), row.BAG_TAG + "#" + tempStr), AppConfig.AppPropSection.UndoCollection);
                                AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.Undo.Add(string.Format("{0}|{1}", "M_B_" + undoNo.ToString().PadLeft(2, '0'), row.BAG_TAG + "#" + tempStr));

                                // 顯示修改後所選取航班之行李資料，並隱藏修改文字框
                                Text_BagAmend.Visible = false;
                                List<BSM2Day.Row> List_BSM = GetSelectedBSM(List_Flight.SelectedItems[0].SubItems[0].Text);
                                List_Baggage.Items.Clear();
                                if (List_BSM != null)
                                {
                                    List_BSM.ForEach(obj => List_Baggage.Items.Add(
                                        new ListViewItem(new string[] { obj.BAG_TAG, obj.BSM_DATE, obj.BSM_FLIGHT, obj.BAG_STATE.ToString(), obj.CABIN_CLASS, obj.AUTH_LOAD, obj.AUTH_TRANSPORT })
                                        ));
                                    List_Flight.SelectedItems[0].SubItems[2].Text = List_BSM.Count.ToString();
                                }
                            }
                        }
                        else
                        {
                            // 顯示對話方塊說明參數輸入錯誤或不足，因此無法執行測試資料產生
                            InfoLog.Log("BRSTestDataGenerator", "MainForm", "Some inputs is invalid. Amending BSM data is not completed yet.");
                            MessageBox.Show("Some inputs is invalid.", "Warning", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        // 異動確認之對話方塊選擇"No"
                        // Do Nothig...
                        InfoLog.Log("BRSTestDataGenerator", "MainForm", "Not to do this BSM amendment.");
                    }
                }
            }
        }

        private void Text_BagAmend_LoseFocus(object sender, EventArgs e)
        {
            Text_BagAmend.Visible = false;
        }
        #endregion

        #endregion

        #region =====[Private] Function=====

        private void RefreshForm()
        {
            List<FIDS2Day.Row> List_FIDS = GetCurrentFIDS();
            List<BSM2Day.Row> List_BSM = GetCurrentBSM();

            // 不允許使用"新增行李按鈕"、"重置行李按鈕"、"資料列刪除按鈕"功能
            Button_AddBag.Enabled = false;
            Button_Reset.Enabled = false;
            Button_Delete.Enabled = false;

            // Initialize ListView of FIDS
            TargetFlight = AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.Default.FlightNo;
            List_Flight.Items.Clear();
            if (List_FIDS != null)
            {
                List_FIDS.ForEach(obj => List_Flight.Items.Add(
                    new ListViewItem(new string[] { obj.FLIGHT_NO, obj.DATE_TIME, "0" })
                    ));
                foreach (ListViewItem item in List_Flight.Items)
                {
                    item.ForeColor = Color.Red;
                }
                TargetFlight = int.TryParse(List_FIDS.First().FLIGHT_NO[2..], out int currentNo) ?
                        List_FIDS.First().FLIGHT_NO.Substring(0, 2) + (++currentNo).ToString().PadLeft(4, '0') :
                        AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.Default.FlightNo;
            }

            // Initialize ListView of BSM and modify the detail of flights (BAGS and remarks on FLIGHT_NO)
            List_Baggage.Items.Clear();
            if (List_BSM != null)
            {
                List_BSM.ForEach(obj => List_Baggage.Items.Add(
                    new ListViewItem(new string[] { obj.BAG_TAG, obj.BSM_DATE, obj.BSM_FLIGHT, (obj.BAG_STATE == null) ? "-" : obj.BAG_STATE.ToString(), obj.CABIN_CLASS, obj.AUTH_LOAD, obj.AUTH_TRANSPORT })
                    ));

                var List_BSM_g = List_BSM.GroupBy(obj => new { obj.BSM_DATE, obj.BSM_FLIGHT })
                                                        .Select(obj_g => new { obj_g.Key.BSM_DATE, obj_g.Key.BSM_FLIGHT, BAG_COUNT = obj_g.Count() }).ToList();
                foreach (ListViewItem item in List_Flight.Items)
                {
                    var itemToRemove = List_BSM_g.SingleOrDefault(obj => item.SubItems[0].Text.Contains(obj.BSM_FLIGHT) && obj.BSM_DATE == item.SubItems[1].Text);
                    if (itemToRemove != null)
                    {
                        item.SubItems[2].Text = itemToRemove.BAG_COUNT.ToString();
                        item.ForeColor = Color.Black;
                        List_BSM_g.Remove(itemToRemove);
                    }
                }
                List_BSM_g.ForEach(obj => List_Flight.Items.Add(
                    new ListViewItem(new string[] { obj.BSM_FLIGHT + "*", obj.BSM_DATE, obj.BAG_COUNT.ToString() })
                    ));
                if (List_BSM_g.Count > 0)
                {
                    TargetFlight = List_BSM_g.First().BSM_FLIGHT;
                }
            }

            // Initialize ListView of Properties
            List_Properties.Items.Clear();
            string[] propNames = AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.Default.PropNames.Split(",");
            foreach (string name in propNames)
            {
                List_Properties.Items.Add(new ListViewItem(new string[] { name, string.Empty }));
            }
        }

        private FIDS2Day.Row GetSelectedFIDS(string flightNo)
        {
            string queryDate = App_Mode == "0" ?
                DateTime.ParseExact(TestDate, "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString("yyyyMMdd") :
                DateTime.Now.ToString("yyyyMMdd");
            DataBase T1BRSDB = null;
            FIDS2Day.Row ret = null;

            try
            {
                T1BRSDB = DataBase.Instance(T1BRSDB_ConnStr);
                if (T1BRSDB.Conn == new DataBase(null).Conn)
                {
                    ErrorLog.Log("ERROR", "MainForm", "DB connection failed.");
                    return null; // 資料庫連線失敗
                }
                FIDS2Day TB_FIDS2Day = new FIDS2Day(T1BRSDB.Conn);
                if (TB_FIDS2Day.SelectByKey(flightNo, queryDate) > 0)
                {
                    InfoLog.Log("BRSTestDataGenerator", "MainForm", string.Format("Query FIDS data of [{0}] successfully.", flightNo));
                    ret = TB_FIDS2Day.RecordList[0] as FIDS2Day.Row;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Log("MainForm", ex);
            }
            finally
            {
                if (T1BRSDB != null)
                {
                    T1BRSDB.Close();
                }
            }

            return ret;
        }

        private List<FIDS2Day.Row> GetCurrentFIDS()
        {
            string queryDate = App_Mode == "0" ?
                DateTime.ParseExact(TestDate, "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString("yyyyMMdd") :
                DateTime.Now.ToString("yyyyMMdd");
            DataBase T1BRSDB = null;
            List<FIDS2Day.Row> RowList_FIDS = new List<FIDS2Day.Row>();

            try
            {
                T1BRSDB = DataBase.Instance(T1BRSDB_ConnStr);
                if (T1BRSDB.Conn == new DataBase(null).Conn)
                {
                    ErrorLog.Log("ERROR", "MainForm", "DB connection failed.");
                    return null; // 資料庫連線失敗
                }
                FIDS2Day TB_FIDS2Day = new FIDS2Day(T1BRSDB.Conn);
                if (TB_FIDS2Day.SelectXXByDate(queryDate) > 0)
                {
                    InfoLog.Log("BRSTestDataGenerator", "MainForm", "Query FIDS data successfully.");
                    TB_FIDS2Day.RecordList.ForEach(obj => RowList_FIDS.Add(obj as FIDS2Day.Row));
                }
                else
                {
                    InfoLog.Log("BRSTestDataGenerator", "MainForm", "There is non of current FIDS data to query.");
                    RowList_FIDS = null;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Log("MainForm", ex);
                RowList_FIDS = null;
            }
            finally
            {
                if (T1BRSDB != null)
                {
                    T1BRSDB.Close();
                }
            }

            return RowList_FIDS;
        }

        private bool AddNewTestFIDS(FIDS2Day.Row newRow)
        {
            DataBase T1BRSDB = null;
            DBTransaction Transaction_T1BRSDB = new DBTransaction();

            try
            {
                T1BRSDB = DataBase.Instance(T1BRSDB_ConnStr);
                if (T1BRSDB.Conn == new DataBase(null).Conn)
                {
                    ErrorLog.Log("ERROR", "MainForm", "DB connection failed.");
                    return false; // 資料庫連線失敗
                }
                FIDS2Day TB_FIDS2Day = new FIDS2Day(T1BRSDB.Conn);
                if (TB_FIDS2Day.SelectByKey(newRow.FLIGHT_NO, newRow.DATE_TIME) <= 0)
                {
                    Transaction_T1BRSDB.BeginTransaction(TB_FIDS2Day);
                    Transaction_T1BRSDB.SetTransactionResult(TB_FIDS2Day, TB_FIDS2Day.Insert(newRow));
                    if (Transaction_T1BRSDB.EndTransaction()[TB_FIDS2Day.SqlCmd.Connection])
                    {
                        InfoLog.Log("BRSTestDataGenerator", "MainForm", string.Format("Add new test data of flight: {0} successfully", newRow.FLIGHT_NO));
                        return true;
                    }
                    else
                    {
                        ErrorLog.Log("ERROR", "MainForm", string.Format("Failed to add new test data of flight: {0}.", newRow.FLIGHT_NO));
                        return false;
                    }
                }
                else
                {
                    InfoLog.Log("BRSTestDataGenerator", "MainForm", string.Format("The test data of flight: {0} already exists and is not added.", newRow.FLIGHT_NO));
                    return false;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Log("MainForm", ex);
                return false;
            }
            finally
            {
                if (T1BRSDB != null)
                {
                    T1BRSDB.Close();
                }
            }
        }

        private bool DeleteSelectedFIDS(string flightNo)
        {
            string targetDate = App_Mode == "0" ?
                DateTime.ParseExact(TestDate, "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString("yyyyMMdd") :
                DateTime.Now.ToString("yyyyMMdd");
            DataBase T1BRSDB = null;
            DBTransaction Transaction_T1BRSDB = new DBTransaction();

            try
            {
                T1BRSDB = DataBase.Instance(T1BRSDB_ConnStr);
                if (T1BRSDB.Conn == new DataBase(null).Conn)
                {
                    ErrorLog.Log("ERROR", "MainForm", "DB connection failed.");
                    return false; // 資料庫連線失敗
                }
                FIDS2Day TB_FIDS2Day = new FIDS2Day(T1BRSDB.Conn);
                Transaction_T1BRSDB.BeginTransaction(TB_FIDS2Day);
                Transaction_T1BRSDB.SetTransactionResult(TB_FIDS2Day, TB_FIDS2Day.DeleteByKey(flightNo, targetDate));
                if (Transaction_T1BRSDB.EndTransaction()[TB_FIDS2Day.SqlCmd.Connection])
                {
                    InfoLog.Log("BRSTestDataGenerator", "MainForm", string.Format("Delete a test data of flight: {0} successfully.", flightNo));
                    return true;
                }
                else
                {
                    ErrorLog.Log("ERROR", "MainForm", string.Format("Failed to delete a test data of flight: {0}.", flightNo));
                    return false;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Log("MainForm", ex);
                return false;
            }
            finally
            {
                if (T1BRSDB != null)
                {
                    T1BRSDB.Close();
                }
            }
        }

        private bool DeleteAllTestFIDS()
        {
            string targetDate = App_Mode == "0" ?
                DateTime.ParseExact(TestDate, "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString("yyyyMMdd") :
                DateTime.Now.ToString("yyyyMMdd");
            DataBase T1BRSDB = null;
            DBTransaction Transaction_T1BRSDB = new DBTransaction();

            try
            {
                T1BRSDB = DataBase.Instance(T1BRSDB_ConnStr);
                if (T1BRSDB.Conn == new DataBase(null).Conn)
                {
                    ErrorLog.Log("ERROR", "MainForm", "DB connection failed.");
                    return false; // 資料庫連線失敗
                }
                FIDS2Day TB_FIDS2Day = new FIDS2Day(T1BRSDB.Conn);
                Transaction_T1BRSDB.BeginTransaction(TB_FIDS2Day);
                Transaction_T1BRSDB.SetTransactionResult(TB_FIDS2Day, TB_FIDS2Day.DeleteXXByDate(targetDate));
                if (Transaction_T1BRSDB.EndTransaction()[TB_FIDS2Day.SqlCmd.Connection])
                {
                    InfoLog.Log("BRSTestDataGenerator", "MainForm", "Delete all test data of flight successfully.");
                    return true;
                }
                else
                {
                    ErrorLog.Log("ERROR", "MainForm", "Failed to delete all test data of flight.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Log("MainForm", ex);
                return false;
            }
            finally
            {
                if (T1BRSDB != null)
                {
                    T1BRSDB.Close();
                }
            }
        }

        private BSM2Day.Row GetOneBSM(string bagTag)
        {
            string queryDate = App_Mode == "0" ?
                DateTime.ParseExact(TestDate, "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString("yyyyMMdd") :
                DateTime.Now.ToString("yyyyMMdd");
            DataBase T1BRSDB = null;
            BSM2Day.Row ret = null;
            try
            {
                T1BRSDB = DataBase.Instance(T1BRSDB_ConnStr);
                if (T1BRSDB.Conn == new DataBase(null).Conn)
                {
                    ErrorLog.Log("ERROR", "MainForm", "DB connection failed.");
                    return null; // 資料庫連線失敗
                }
                BSM2Day TB_BSM2Day = new BSM2Day(T1BRSDB.Conn);
                if (TB_BSM2Day.SelectByKey(bagTag, queryDate) > 0)
                {
                    InfoLog.Log("BRSTestDataGenerator", "MainForm", "Query BSM data successfully.");
                    ret = TB_BSM2Day.RecordList[0] as BSM2Day.Row;
                }
                else
                {
                    InfoLog.Log("BRSTestDataGenerator", "MainForm", "There is non of current BSM data of selected flight to query.");
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Log("MainForm", ex);
            }
            finally
            {
                if (T1BRSDB != null)
                {
                    T1BRSDB.Close();
                }
            }

            return ret;
        }

        private List<BSM2Day.Row> GetSelectedBSM(string flightNo)
        {
            string queryDate = App_Mode == "0" ?
                DateTime.ParseExact(TestDate, "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString("yyyyMMdd") :
                DateTime.Now.ToString("yyyyMMdd");
            DataBase T1BRSDB = null;
            List<BSM2Day.Row> RowList_BSM = new List<BSM2Day.Row>();

            try
            {
                T1BRSDB = DataBase.Instance(T1BRSDB_ConnStr);
                if (T1BRSDB.Conn == new DataBase(null).Conn)
                {
                    ErrorLog.Log("ERROR", "MainForm", "DB connection failed.");
                    return null; // 資料庫連線失敗
                }
                BSM2Day TB_BSM2Day = new BSM2Day(T1BRSDB.Conn);
                if (TB_BSM2Day.SelectByFlight(flightNo, queryDate) > 0)
                {
                    InfoLog.Log("BRSTestDataGenerator", "MainForm", "Query BSM data successfully.");
                    TB_BSM2Day.RecordList.ForEach(obj => RowList_BSM.Add(obj as BSM2Day.Row));
                }
                else
                {
                    InfoLog.Log("BRSTestDataGenerator", "MainForm", "There is non of current BSM data of selected flight to query.");
                    RowList_BSM = null;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Log("MainForm", ex);
                RowList_BSM = null;
            }
            finally
            {
                if (T1BRSDB != null)
                {
                    T1BRSDB.Close();
                }
            }

            return RowList_BSM;
        }

        private List<BSM2Day.Row> GetCurrentBSM()
        {
            string queryDate = App_Mode == "0" ?
                DateTime.ParseExact(TestDate, "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString("yyyyMMdd") :
                DateTime.Now.ToString("yyyyMMdd");
            DataBase T1BRSDB = null;
            List<BSM2Day.Row> RowList_BSM = new List<BSM2Day.Row>();

            try
            {
                T1BRSDB = DataBase.Instance(T1BRSDB_ConnStr);
                if (T1BRSDB.Conn == new DataBase(null).Conn)
                {
                    ErrorLog.Log("ERROR", "MainForm", "DB connection failed.");
                    return null; // 資料庫連線失敗
                }
                BSM2Day TB_BSM2Day = new BSM2Day(T1BRSDB.Conn);
                if (TB_BSM2Day.SelectXXByDate(queryDate) > 0)
                {
                    InfoLog.Log("BRSTestDataGenerator", "MainForm", "Query BSM data successfully.");
                    TB_BSM2Day.RecordList.ForEach(obj => RowList_BSM.Add(obj as BSM2Day.Row));
                }
                else
                {
                    InfoLog.Log("BRSTestDataGenerator", "MainForm", "There is non of current BSM data to query.");
                    RowList_BSM = null;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Log("MainForm", ex);
                RowList_BSM = null;
            }
            finally
            {
                if (T1BRSDB != null)
                {
                    T1BRSDB.Close();
                }
            }

            return RowList_BSM;
        }

        private bool ModifyTestBSM(BSM2Day.Row row)
        {
            DataBase T1BRSDB = null;
            DBTransaction Transaction_T1BRSDB = new DBTransaction();

            try
            {
                T1BRSDB = DataBase.Instance(T1BRSDB_ConnStr);
                if (T1BRSDB.Conn == new DataBase(null).Conn)
                {
                    ErrorLog.Log("ERROR", "MainForm", "DB connection failed.");
                    return false; // 資料庫連線失敗
                }
                BSM2Day TB_BSM2Day = new BSM2Day(T1BRSDB.Conn);
                Transaction_T1BRSDB.BeginTransaction(TB_BSM2Day);
                Transaction_T1BRSDB.SetTransactionResult(TB_BSM2Day, TB_BSM2Day.Update(row));
                if (Transaction_T1BRSDB.EndTransaction()[TB_BSM2Day.SqlCmd.Connection])
                {
                    InfoLog.Log("BRSTestDataGenerator", "MainForm", string.Format("Amend a test data of BSM (BAG_TAG: {0}, BSM_DATE: {1}) successfully", row.BAG_TAG, row.BSM_DATE));
                    return true;
                }
                else
                {
                    ErrorLog.Log("ERROR", "MainForm", "Failed to amend a test data of BSM");
                    return false;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Log("MainForm", ex);
                return false;
            }
            finally
            {
                if (T1BRSDB != null)
                {
                    T1BRSDB.Close();
                }
            }
        }

        private bool DeleteSelectedBSM(string bagTag)
        {
            string targetDate = App_Mode == "0" ?
                DateTime.ParseExact(TestDate, "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString("yyyyMMdd") :
                DateTime.Now.ToString("yyyyMMdd");
            DataBase T1BRSDB = null;
            DBTransaction Transaction_T1BRSDB = new DBTransaction();

            try
            {
                T1BRSDB = DataBase.Instance(T1BRSDB_ConnStr);
                if (T1BRSDB.Conn == new DataBase(null).Conn)
                {
                    ErrorLog.Log("ERROR", "MainForm", "DB connection failed.");
                    return false; // 資料庫連線失敗
                }
                BSM2Day TB_BSM2Day = new BSM2Day(T1BRSDB.Conn);
                Transaction_T1BRSDB.BeginTransaction(TB_BSM2Day);
                Transaction_T1BRSDB.SetTransactionResult(TB_BSM2Day, TB_BSM2Day.DeleteByKey(bagTag, targetDate));
                if (Transaction_T1BRSDB.EndTransaction()[TB_BSM2Day.SqlCmd.Connection])
                {
                    InfoLog.Log("BRSTestDataGenerator", "MainForm", "Delete all test data of BSM successfully.");
                    return true;
                }
                else
                {
                    ErrorLog.Log("ERROR", "MainForm", string.Format("Failed to delete a test data of BSM (BAG_TAG: {0}, BSM_DATE: {1}).", bagTag, targetDate));
                    return false;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Log("MainForm", ex);
                return false;
            }
            finally
            {
                if (T1BRSDB != null)
                {
                    T1BRSDB.Close();
                }
            }
        }

        private bool DeleteAllTestBSM()
        {
            string targetDate = App_Mode == "0" ?
                DateTime.ParseExact(TestDate, "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString("yyyyMMdd") :
                DateTime.Now.ToString("yyyyMMdd");
            DataBase T1BRSDB = null;
            DBTransaction Transaction_T1BRSDB = new DBTransaction();

            try
            {
                T1BRSDB = DataBase.Instance(T1BRSDB_ConnStr);
                if (T1BRSDB.Conn == new DataBase(null).Conn)
                {
                    ErrorLog.Log("ERROR", "MainForm", "DB connection failed.");
                    return false; // 資料庫連線失敗
                }
                BSM2Day TB_BSM2Day = new BSM2Day(T1BRSDB.Conn);
                Transaction_T1BRSDB.BeginTransaction(TB_BSM2Day);
                Transaction_T1BRSDB.SetTransactionResult(TB_BSM2Day, TB_BSM2Day.DeleteXXByDate(targetDate));
                if (Transaction_T1BRSDB.EndTransaction()[TB_BSM2Day.SqlCmd.Connection])
                {
                    InfoLog.Log("BRSTestDataGenerator", "MainForm", "Delete all test data of BSM successfully.");
                    return true;
                }
                else
                {
                    ErrorLog.Log("ERROR", "MainForm", "Failed to delete all test data of BSM.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Log("MainForm", ex);
                return false;
            }
            finally
            {
                if (T1BRSDB != null)
                {
                    T1BRSDB.Close();
                }
            }
        }

        #endregion
    }
}
