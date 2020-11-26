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
        #region =====[Private] App Configuration=====
        /// <summary>
        /// T1BRSDB供此Form Application使用之資料庫連線參數
        /// </summary>
        private static readonly string T1BRSDB_ConnStr = AppConfig.AppPropertySetting.Instance().GetProperty("T1BRSDB");
        /// <summary>
        /// 此Form Application執行模式
        /// </summary>
        /// <remarks>
        /// <para>0: 表示為測試模式</para>
        /// <para>1: 表示為正式運行模式</para>
        /// </remarks>
        private static readonly string App_Mode = AppConfig.AppPropertySetting.Instance().GetProperty("MODE");
        /// <summary>
        /// 此Form Application執行模式為測試模式時，所使用的測試日期，格式為"yyyy-MM-dd"
        /// </summary>
        private static readonly string TestDate = AppConfig.AppPropertySetting.Instance().GetProperty("TestDate");
        #endregion

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InfoLog.Log("BRSTestDataGenerator", "MainForm", "MainForm of [BRS Test Data Generator] initialized.");
            RefreshForm();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            InfoLog.Log("BRSTestDataGenerator", "MainForm", "MainForm of [BRS Test Data Generator] Closed.");
        }

        private void Button_Confirm_FIDS_Click(object sender, EventArgs e)
        {
            if (text_STD_FIDS.ForeColor != Color.Black ||
                text_ETD_FIDS.ForeColor != Color.Black ||
                text_DES_FIDS.ForeColor != Color.Black)
            {
                MessageBox.Show("You did not complete all inputs yet.", "Warning", MessageBoxButtons.OK);
                InfoLog.Log("BRSTestDataGenerator", "MainForm", "Inputs in FIDS panel are not completed.");
                return;
            }
            // 顯示異動確認之對話方塊作再次確認
            InfoLog.Log("BRSTestDataGenerator", "MainForm", "Double confirm whether to do this FIDS amendment or not.");
            DialogResult doubleConfirm = MessageBox.Show("Are you sure to do this amendment?", "Confirm", MessageBoxButtons.YesNo);
            if (doubleConfirm == DialogResult.Yes)
            {
                // 異動確認之對話方塊選擇"Yes"
                InfoLog.Log("BRSTestDataGenerator", "MainForm", "Sure to do this FIDS amendment.");
                if (new Regex(@"^\d{4}$").IsMatch(text_STD_FIDS.Text) &&
                    new Regex(@"^\d{4}$").IsMatch(text_ETD_FIDS.Text) &&
                    new Regex(@"^[A-Z]{3,4}$").IsMatch(text_DES_FIDS.Text) &&
                    new Regex(@"^\w{1,20}$").IsMatch(text_USER.Text))
                {
                    InfoLog.Log("BRSTestDataGenerator", "MainForm", string.Format("Start to add a new FIDS test data: {0}.", labelFlight.Text));
                    FIDS2Day.Row newRow = new FIDS2Day.Row()
                    {
                        FLIGHT_NO = labelFlight.Text,
                        DATE_TIME = App_Mode == "0" ?
                        DateTime.ParseExact(TestDate, "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString("yyyyMMdd") :
                        DateTime.Now.ToString("yyyyMMdd"),
                        TYPE = "D",
                        STD = text_STD_FIDS.Text,
                        ETD = text_ETD_FIDS.Text,
                        ATD = string.Empty,
                        DESTINATION = text_DES_FIDS.Text.ToUpper(),
                        PLANE = string.Empty,
                        STATUS = "On Time",
                        UPD_USER = text_USER.Text,
                        UPD_TIME = DateTime.Now.ToString("yyyyMMddHHmmss"),
                        UPD_TYPE = 0
                    };
                    if (AddNewTestFIDS(newRow))
                    {
                        RefreshForm();
                    }
                }
                else
                {
                    // 顯示對話方塊說明參數輸入錯誤或不足，因此無法執行測試資料產生
                    MessageBox.Show("Some inputs is invalid.", "Warning", MessageBoxButtons.OK);
                    InfoLog.Log("BRSTestDataGenerator", "MainForm", "Some inputs in FIDS panel are invalid.");
                }
            }
            else
            {
                // 異動確認之對話方塊選擇"No"
                // Do Nothig...
                InfoLog.Log("BRSTestDataGenerator", "MainForm", "Not to do this FIDS amendment.");
            }
        }

        private void Button_Clear_FIDS_Click(object sender, EventArgs e)
        {
            // 顯示異動確認之對話方塊作再次確認
            InfoLog.Log("BRSTestDataGenerator", "MainForm", "Double confirm whether to do this FIDS deletion or not.");
            DialogResult doubleConfirm = MessageBox.Show("Are you sure to clear all the FIDS data?", "Confirm", MessageBoxButtons.YesNo);
            if (doubleConfirm == DialogResult.Yes)
            {
                // 異動確認之對話方塊選擇"Yes"
                InfoLog.Log("BRSTestDataGenerator", "MainForm", "Sure to do this FIDS deletion.");
                if (dataGridFLT.Rows.Count > 0)
                {
                    InfoLog.Log("BRSTestDataGenerator", "MainForm", "Start to delete all FIDS test data.");
                    if (DeleteTestFIDS())
                    {
                        RefreshForm();
                    }
                }
                else
                {
                    // 顯示對話方塊說明沒有任何航班測試資料，因此無法執行清除動作
                    MessageBox.Show("There is no FIDS data.", "Warning", MessageBoxButtons.OK);
                    InfoLog.Log("BRSTestDataGenerator", "MainForm", "No FIDS data found that could be deleted.");
                }
            }
            else
            {
                // 異動確認之對話方塊選擇"No"
                // Do Nothig...
                InfoLog.Log("BRSTestDataGenerator", "MainForm", "Not to do this FIDS deletion.");
            }
        }

        private void Button_CONFIRM_BSM_Click(object sender, EventArgs e)
        {
            if (text_Number_BSM.ForeColor != Color.Black ||
                text_BagState_BSM.ForeColor != Color.Black)
            {
                MessageBox.Show("You did not complete all inputs yet.", "Warning", MessageBoxButtons.OK);
                InfoLog.Log("BRSTestDataGenerator", "MainForm", "Inputs in BSM panel are not completed.");
                return;
            }
            // 顯示異動確認之對話方塊作再次確認
            InfoLog.Log("BRSTestDataGenerator", "MainForm", "Double confirm whether to do this BSM amendment or not.");
            DialogResult doubleConfirm = MessageBox.Show("Are you sure to do this amendment?", "Confirm", MessageBoxButtons.YesNo);
            if (doubleConfirm == DialogResult.Yes)
            {
                // 異動確認之對話方塊選擇"Yes"
                InfoLog.Log("BRSTestDataGenerator", "MainForm", "Sure to do this BSM amendment.");
                if (new Regex(@"^[1-9]\d*$").IsMatch(text_Number_BSM.Text) && int.TryParse(text_Number_BSM.Text, out int int_Number_BSM) &&
                    new Regex(@"^\d*$").IsMatch(text_BagState_BSM.Text) && int.TryParse(text_BagState_BSM.Text, out int int_BagState_BSM) &&
                    new Regex(@"[A-Z]").IsMatch(text_CabinClass_BSM.Text) &&
                    new Regex(@"^\w{1,20}$").IsMatch(text_USER.Text))
                {
                    InfoLog.Log("BRSTestDataGenerator", "MainForm", string.Format("Start to add {0} new BSM test data.", text_Number_BSM.Text));
                    if (AddNewTestBSM(int_Number_BSM, text_CabinClass_BSM.Text, int_BagState_BSM, dataGridFLT.Rows[dataGridFLT.SelectedCells[0].RowIndex].Cells["FLIGHT_NO_C"].Value.ToString()))
                    {
                        RefreshForm();
                    }
                }
                else
                {
                    // 顯示對話方塊說明參數輸入錯誤或不足，因此無法執行測試資料產生
                    MessageBox.Show("Some inputs is invalid.", "Warning", MessageBoxButtons.OK);
                    InfoLog.Log("BRSTestDataGenerator", "MainForm", "Some inputs in BSM panel are invalid.");
                }
            }
            else
            {
                // 異動確認之對話方塊選擇"No"
                // Do Nothig...
                InfoLog.Log("BRSTestDataGenerator", "MainForm", "Not to do this BSM amendment.");
            }
        }

        private void Button_CLEAR_BSM_Click(object sender, EventArgs e)
        {
            // 顯示異動確認之對話方塊作再次確認
            InfoLog.Log("BRSTestDataGenerator", "MainForm", "Double confirm whether to do this BSM deletion or not.");
            DialogResult doubleConfirm = MessageBox.Show("Are you sure to clear all the BSM data?", "Confirm", MessageBoxButtons.YesNo);
            if (doubleConfirm == DialogResult.Yes)
            {
                // 異動確認之對話方塊選擇"Yes"
                InfoLog.Log("BRSTestDataGenerator", "MainForm", "Sure to do this BSM deletion.");
                if (dataGridBSM.Rows.Count > 0)
                {
                    InfoLog.Log("BRSTestDataGenerator", "MainForm", "Start to delete all BSM test data.");
                    if (DeleteTestBSM())
                    {
                        RefreshForm();
                    }
                }
                else
                {
                    // 顯示對話方塊說明沒有任何行李測試資料，因此無法執行清除動作
                    MessageBox.Show("There is no BSM data.", "Warning", MessageBoxButtons.OK);
                    InfoLog.Log("BRSTestDataGenerator", "MainForm", "No BSM data found that could be deleted.");
                }
            }
            else
            {
                // 異動確認之對話方塊選擇"No"
                // Do Nothig...
                InfoLog.Log("BRSTestDataGenerator", "MainForm", "Not to do this BSM deletion.");
            }
        }

        #region =====[TextBox] EventHandler=====
        private void Text_STD_FIDS_GotFocus(object sender, EventArgs e)
        {
            text_STD_FIDS.ForeColor = Color.Black;
            text_STD_FIDS.Text = string.Empty;
        }

        private void Text_STD_FIDS_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(text_STD_FIDS.Text))
            {
                text_STD_FIDS.ForeColor = Color.Silver;
                text_STD_FIDS.Text = "1520";
            }
            else if (!new Regex(@"^\d{4}$").IsMatch(text_STD_FIDS.Text))
            {
                text_STD_FIDS.ForeColor = Color.Red;
            }
        }

        private void Text_ETD_FIDS_GotFocus(object sender, EventArgs e)
        {
            text_ETD_FIDS.ForeColor = Color.Black;
            text_ETD_FIDS.Text = string.Empty;
        }

        private void Text_ETD_FIDS_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(text_ETD_FIDS.Text))
            {
                text_ETD_FIDS.ForeColor = Color.Silver;
                text_ETD_FIDS.Text = "1520";
            }
            else if (!new Regex(@"^\d{4}$").IsMatch(text_ETD_FIDS.Text))
            {
                text_ETD_FIDS.ForeColor = Color.Red;
            }
        }

        private void Text_DES_FIDS_GotFocus(object sender, EventArgs e)
        {
            text_DES_FIDS.ForeColor = Color.Black;
            text_DES_FIDS.Text = string.Empty;
        }

        private void Text_DES_FIDS_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(text_DES_FIDS.Text))
            {
                text_DES_FIDS.ForeColor = Color.Silver;
                text_DES_FIDS.Text = "KIX";
            }
            else if (!new Regex(@"^[A-Z]{3,4}$").IsMatch(text_DES_FIDS.Text))
            {
                text_DES_FIDS.ForeColor = Color.Red;
            }
            else
            {
                text_DES_FIDS.Text = text_DES_FIDS.Text.ToUpper();
            }
        }

        private void Text_Number_BSM_GotFocus(object sender, EventArgs e)
        {
            text_Number_BSM.ForeColor = Color.Black;
            text_Number_BSM.Text = string.Empty;
        }

        private void Text_Number_BSM_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(text_Number_BSM.Text))
            {
                text_Number_BSM.ForeColor = Color.Silver;
                text_Number_BSM.Text = "1";
            }
            else if (!new Regex(@"^[1-9]\d*$").IsMatch(text_Number_BSM.Text) && !int.TryParse(text_Number_BSM.Text, out _))
            {
                text_Number_BSM.ForeColor = Color.Red;
            }
        }

        private void Text_BagState_BSM_GotFocus(object sender, EventArgs e)
        {
            text_BagState_BSM.ForeColor = Color.Black;
            text_BagState_BSM.Text = string.Empty;
        }

        private void Text_BagState_BSM_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(text_BagState_BSM.Text))
            {
                text_BagState_BSM.ForeColor = Color.Silver;
                text_BagState_BSM.Text = "0";
            }
            else if (!new Regex(@"^\d*$").IsMatch(text_BagState_BSM.Text) && !int.TryParse(text_BagState_BSM.Text, out _))
            {
                text_BagState_BSM.ForeColor = Color.Red;
            }
        }

        private void Text_CabinClass_BSM_GotFocus(object sender, EventArgs e)
        {
            text_CabinClass_BSM.ForeColor = Color.Black;
            text_CabinClass_BSM.Text = string.Empty;
        }

        private void Text_CabinClass_BSM_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(text_CabinClass_BSM.Text))
            {
                text_CabinClass_BSM.ForeColor = Color.Silver;
                text_CabinClass_BSM.Text = "Y";
            }
            else if (!new Regex(@"[A-Z]").IsMatch(text_CabinClass_BSM.Text))
            {
                text_CabinClass_BSM.ForeColor = Color.Red;
            }
            else
            {
                text_CabinClass_BSM.Text = text_CabinClass_BSM.Text.ToUpper();
            }
        }
        #endregion

        #region =====[Private] Function=====

        private void RefreshForm()
        {
            // Refresh FIDS Panel
            dataGridFLT.Rows.Clear();
            List<FIDS2Day.Row> List_FIDS = GetCurrentFIDS();
            if (List_FIDS != null)
            {
                List_FIDS.ForEach(obj => dataGridFLT.Rows.Add(
                    new string[] { obj.FLIGHT_NO, obj.DATE_TIME, obj.STD, obj.ETD, obj.DESTINATION }
                    ));
                labelFlight.Text = int.TryParse(List_FIDS.First().FLIGHT_NO.Substring(2), out int currentNo) ?
                    List_FIDS.First().FLIGHT_NO.Substring(0, 2) + (++currentNo).ToString().PadLeft(4, '0') :
                    "XX0001";
            }
            else
            {
                labelFlight.Text = "XX0001";
            }
            text_STD_FIDS.ForeColor = Color.Silver;
            text_STD_FIDS.Text = "1520";
            text_ETD_FIDS.ForeColor = Color.Silver;
            text_ETD_FIDS.Text = "1520";
            text_DES_FIDS.ForeColor = Color.Silver;
            text_DES_FIDS.Text = "KIX";

            // Refresh BSM Panel
            dataGridBSM.Rows.Clear();
            List<BSM2Day.Row> List_BSM = GetCurrentBSM();
            if (List_BSM != null)
            {
                List_BSM.ForEach(obj => dataGridBSM.Rows.Add(
                    new string[] { obj.BAG_TAG, obj.BSM_DATE, obj.BSM_FLIGHT, obj.BAG_STATE.ToString(), obj.CABIN_CLASS }
                    ));
            }
            text_Number_BSM.ForeColor = Color.Silver;
            text_Number_BSM.Text = "1";
            text_BagState_BSM.ForeColor = Color.Silver;
            text_BagState_BSM.Text = "0";
            text_CabinClass_BSM.ForeColor = Color.Silver;
            text_CabinClass_BSM.Text = "Y";
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

        private bool DeleteTestFIDS()
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

        private bool AddNewTestBSM(int dataNumber, string cabinClass, int bagState, string flightNo)
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
                BSM2Day TB_BSM2Day = new BSM2Day(T1BRSDB.Conn);
                string currentBagTag = TB_BSM2Day.SelectXXByDate(targetDate) > 0 ? (TB_BSM2Day.RecordList.First() as BSM2Day.Row).BAG_TAG : "7890000000";
                string selectedDES = TB_FIDS2Day.SelectByKey(flightNo, targetDate) > 0 ? (TB_FIDS2Day.RecordList[0] as FIDS2Day.Row).DESTINATION : "KIX";
                // 以目前已產生的FIDS航班測試資料隨機選擇航班，作為BSM行李測試資料之所屬航班(同一新增批次行李的所屬航班相同)
                Transaction_T1BRSDB.BeginTransaction(TB_BSM2Day);
                for (int i = 0; i < dataNumber; i++)
                {
                    if (int.TryParse(currentBagTag.Substring(4, 6), out int currentNo))
                    {
                        currentBagTag = currentBagTag.Substring(0, 4) + (++currentNo).ToString().PadLeft(6, '0');
                        BSM2Day.Row newRow = new BSM2Day.Row()
                        {
                            BAG_TAG = currentBagTag,
                            BSM_FLIGHT = flightNo,
                            BSM_DATE = targetDate,
                            DESTINATION = selectedDES,
                            CABIN_CLASS = cabinClass.ToUpper(),
                            PASSENGER = "WANG/MING",
                            SEAT = "45D",
                            AUTH_LOAD = "Y",
                            AUTH_TRANSPORT = "Y",
                            BSM_STATE = 1,
                            BAG_FLIGHT = string.Empty,
                            BAG_DATE = string.Empty,
                            CART_ID = string.Empty,
                            BAG_STATE = bagState,
                            UPD_USER = text_USER.Text,
                            UPD_TIME = DateTime.Now.ToString("yyyyMMddHHmmss"),
                            BSM_SOURCE = string.Empty,
                            OP_Attribute = 0,
                            NEXT_FLIGHT = string.Empty,
                            FINAL_DEST = string.Empty,
                            PREV_FLIGHT = string.Empty,
                            SECURITY_NO = 0,
                            TRAVELLER_ID = string.Empty,
                            TIER_ID = string.Empty
                        };
                        Transaction_T1BRSDB.SetTransactionResult(TB_BSM2Day, TB_BSM2Day.Insert(newRow));
                    }
                    else
                    {
                        ErrorLog.Log("ERROR", "MainForm", "TryParsing the newest BAG_TAG is failed.");
                        return false;
                    }
                }
                if (Transaction_T1BRSDB.EndTransaction()[TB_BSM2Day.SqlCmd.Connection])
                {
                    InfoLog.Log("BRSTestDataGenerator", "MainForm", string.Format("Add {0} new test data of BSM (BSM_FLIGHT: {1}, BAG_STATE: {2}) successfully", dataNumber, flightNo, bagState));
                    return true;
                }
                else
                {
                    ErrorLog.Log("ERROR", "MainForm", "Failed to add new test data of BSM");
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

        public bool DeleteTestBSM()
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
