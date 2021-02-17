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
    public partial class ChildForm_AddBag : Form
    {
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
        /// 此Form Application操作者名稱
        /// </summary>
        private static readonly string User = AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.Basic.User;

        /// <summary>
        /// 所點選之航班編號
        /// </summary>
        private readonly string SelectedFlight = null;

        #endregion

        #region =====[Public] Constructor & Desctructor =====

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="selected">所點選之航班編號</param>
        public ChildForm_AddBag(string selected)
        {
            InitializeComponent();
            Group_AddBag.Text = "BSM_FLIGHT: " + selected;
            SelectedFlight = selected;
        }

        #endregion

        #region =====[Private] EventHandler=====

        private void ChildForm_AddBag_Load(object sender, EventArgs e)
        {
            InfoLog.Log("BRSTestDataGenerator", "ChildForm", "ChildForm_AddBag of [BRS Test Data Generator] initialized.");
            InitializeForm();
        }

        #region ### [Click] ###
        private void Button_Bag_Y_Click(object sender, EventArgs e)
        {
            InfoLog.Log("BRSTestDataGenerator", "ChildForm", "Click <Submit> button to add a BSM data.");
            if (Text_Data_Number.ForeColor != Color.Black ||
                Text_BagState.ForeColor != Color.Black ||
                Text_CabinClass.ForeColor != Color.Black)
            {
                MessageBox.Show("You did not complete all inputs yet.", "Warning", MessageBoxButtons.OK);
                InfoLog.Log("BRSTestDataGenerator", "ChildForm", "Inputs in BSM panel are not completed.");
                return;
            }
            // 顯示異動確認之對話方塊作再次確認
            InfoLog.Log("BRSTestDataGenerator", "ChildForm", "Double confirm whether to complete this BSM amendment or not.");
            DialogResult doubleConfirm = MessageBox.Show("Are you sure to complete this amendment?", "Confirm", MessageBoxButtons.YesNo);
            if (doubleConfirm == DialogResult.Yes)
            {
                // 異動確認之對話方塊選擇"Yes"
                InfoLog.Log("BRSTestDataGenerator", "ChildForm", "Sure to complete this BSM amendment.");
                if (new Regex(@"^[1-9]\d*$").IsMatch(Text_Data_Number.Text) && int.TryParse(Text_Data_Number.Text, out int int_Number_BSM) &&
                    new Regex(@"^\d*$").IsMatch(Text_BagState.Text) && int.TryParse(Text_BagState.Text, out int int_BagState_BSM) &&
                    new Regex(@"^[A-Z]{1}$").IsMatch(Text_CabinClass.Text) &&
                    new Regex(@"^\w{1,20}$").IsMatch(User))
                {
                    InfoLog.Log("BRSTestDataGenerator", "MainForm", string.Format("Start to add {0} new BSM test data for [{1}].", Text_Data_Number.Text, SelectedFlight));
                    if (AddNewTestBSM(int_Number_BSM, Text_CabinClass.Text, int_BagState_BSM, SelectedFlight))
                    {
                        // 回復步驟記錄新增行李動作與行李所屬航班編號及新增數量
                        List<string> undoKeys = AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.Undo;
                        int undoNo = undoKeys.Count > 0 ? int.Parse(undoKeys[^1].Split("|")[0].Split("_")[2]) + 1 : 1;
                        //AppConfig.AppPropertySetting.Instance().AddProperty(new AppConfig.AppPropElement("A_B_" + undoNo.ToString().PadLeft(2, '0'), SelectedFlight + "#" + Text_Data_Number.Text), AppConfig.AppPropSection.UndoCollection);
                        AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.Undo.Add(string.Format("{0}|{1}", "A_B_" + undoNo.ToString().PadLeft(2, '0'), SelectedFlight + "#" + Text_Data_Number.Text));
                        Close();
                    }
                }
                else
                {
                    // 顯示對話方塊說明參數輸入錯誤或不足，因此無法執行測試資料產生
                    InfoLog.Log("BRSTestDataGenerator", "ChildForm", "Some inputs is invalid. Adding BSM data is not completed yet.");
                    MessageBox.Show("Some inputs is invalid.", "Warning", MessageBoxButtons.OK);
                }
            }
            else
            {
                // 異動確認之對話方塊選擇"No"
                // Do Nothig...
                InfoLog.Log("BRSTestDataGenerator", "ChildForm", "Not to complete this BSM amendment.");
            }
        }

        private void Button_Bag_N_Click(object sender, EventArgs e)
        {
            InfoLog.Log("BRSTestDataGenerator", "ChildForm", "Click <Cancel> button to close the BSM diaglog.");
            Close();
        }
        #endregion

        #region ### [TextBox] ###
        private void Text_GotFocus(object sender, EventArgs e)
        {
            TextBox text = (TextBox)sender;
            text.ForeColor = Color.Black;
            text.Text = string.Empty;
        }

        private void Text_Data_Number_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Text_Data_Number.Text))
            {
                Text_Data_Number.ForeColor = Color.Silver;
                Text_Data_Number.Text = AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.Default.DataNum;
            }
            else if (!new Regex(@"^[1-9]\d*$").IsMatch(Text_Data_Number.Text))
            {
                Text_Data_Number.ForeColor = Color.Red;
            }
        }

        private void Text_BagState_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Text_BagState.Text))
            {
                Text_BagState.ForeColor = Color.Silver;
                Text_BagState.Text = AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.Default.BagState;
            }
            else if (!new Regex(@"^\d*$").IsMatch(Text_BagState.Text))
            {
                Text_BagState.ForeColor = Color.Red;
            }
        }

        private void Text_CabinClass_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Text_CabinClass.Text))
            {
                Text_CabinClass.ForeColor = Color.Silver;
                Text_CabinClass.Text = AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.Default.CabinClass;
            }
            else if (!new Regex(@"^[A-Z]{1}$").IsMatch(Text_CabinClass.Text))
            {
                Text_CabinClass.ForeColor = Color.Red;
            }
        }
        #endregion

        #endregion

        #region =====[Private] Function=====

        private void InitializeForm()
        {
            Text_Data_Number.ForeColor = Color.Silver;
            Text_Data_Number.Text = AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.Default.DataNum;
            Text_BagState.ForeColor = Color.Silver;
            Text_BagState.Text = AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.Default.BagState;
            Text_CabinClass.ForeColor = Color.Silver;
            Text_CabinClass.Text = AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.Default.CabinClass;
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
                string currentBagTag = TB_BSM2Day.SelectXXByDate(targetDate) > 0 ? (TB_BSM2Day.RecordList.OrderBy(x => (x as BSM2Day.Row).BAG_TAG).Last() as BSM2Day.Row).BAG_TAG : AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.Default.BagTag;
                string selectedDES = TB_FIDS2Day.SelectByKey(flightNo, targetDate) > 0 ? (TB_FIDS2Day.RecordList.First() as FIDS2Day.Row).DESTINATION : AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.Default.DES;
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
                            PASSENGER = AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.Default.Passenger,
                            SEAT = AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.Default.Seat,
                            AUTH_LOAD = AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.Default.AuthLoad,
                            AUTH_TRANSPORT = AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.Default.AuthTransport,
                            BSM_STATE = int.Parse(AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.Default.BsmState),
                            BAG_FLIGHT = string.Empty,
                            BAG_DATE = string.Empty,
                            CART_ID = string.Empty,
                            BAG_STATE = bagState,
                            UPD_USER = User,
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

        #endregion
    }
}
