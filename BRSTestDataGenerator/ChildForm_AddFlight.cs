using BRSTestDataGenerator.ConfigScript;
using BRSTestDataGenerator.DAO;
using Lib.DB;
using Lib.Log;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BRSTestDataGenerator
{
    public partial class ChildForm_AddFlight : Form
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
        /// 欲新增之目標航班編號，預設為XX0001
        /// </summary>
        private readonly string TargetFlight = AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.Default.FlightNo;

        #endregion

        #region =====[Public] Constructor & Destructor=====

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="target">下一個新增之目標航班編號</param>
        public ChildForm_AddFlight(string target)
        {
            InitializeComponent();
            Group_AddFlight.Text = target;
            TargetFlight = target;
        }

        #endregion

        #region =====[Private] EventHandler=====

        private void ChildForm_AddFlight_Load(object sender, EventArgs e)
        {
            InfoLog.Log("BRSTestDataGenerator", "ChildForm", "ChildForm_AddFlight of [BRS Test Data Generator] initialized.");
            InitializeForm();
        }

        #region ### [Click] ###
        private void Button_Flight_Y_Click(object sender, EventArgs e)
        {
            InfoLog.Log("BRSTestDataGenerator", "ChildForm", "Click <Submit> button to add a FIDS data.");
            if (Text_STD.ForeColor != Color.Black ||
                Text_ETD.ForeColor != Color.Black ||
                Text_DES.ForeColor != Color.Black)
            {
                MessageBox.Show("You did not complete all inputs yet.", "Warning", MessageBoxButtons.OK);
                InfoLog.Log("BRSTestDataGenerator", "ChildForm", "Inputs in FIDS panel are not completed.");
                return;
            }
            // 顯示異動確認之對話方塊作再次確認
            InfoLog.Log("BRSTestDataGenerator", "ChildForm", "Double confirm whether to complete this FIDS amendment or not.");
            DialogResult doubleConfirm = MessageBox.Show("Are you sure to complete this amendment?", "Confirm", MessageBoxButtons.YesNo);
            if (doubleConfirm == DialogResult.Yes)
            {
                // 異動確認之對話方塊選擇"Yes"
                InfoLog.Log("BRSTestDataGenerator", "ChildForm", "Sure to complete this FIDS amendment.");
                if (new Regex(@"^\d{4}$").IsMatch(Text_STD.Text) &&
                    new Regex(@"^\d{4}$").IsMatch(Text_ETD.Text) &&
                    new Regex(@"^[A-Z]{3,4}$").IsMatch(Text_DES.Text) &&
                    new Regex(@"^\w{1,20}$").IsMatch(User))
                {
                    InfoLog.Log("BRSTestDataGenerator", "ChildForm", string.Format("Start to add a new FIDS test data: {0}.", TargetFlight));
                    FIDS2Day.Row newRow = new FIDS2Day.Row()
                    {
                        FLIGHT_NO = TargetFlight,
                        DATE_TIME = App_Mode == "0" ?
                            DateTime.ParseExact(TestDate, "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString("yyyyMMdd") :
                            DateTime.Now.ToString("yyyyMMdd"),
                        TYPE = "D",
                        STD = Text_STD.Text,
                        ETD = Text_ETD.Text,
                        ATD = string.Empty,
                        DESTINATION = Text_DES.Text.ToUpper(),
                        PLANE = string.Empty,
                        STATUS = "On Time",
                        UPD_USER = User,
                        UPD_TIME = DateTime.Now.ToString("yyyyMMddHHmmss"),
                        UPD_TYPE = 0
                    };
                    if (AddNewTestFIDS(newRow))
                    {
                        // 回復步驟記錄新增航班動作與航班編號
                        List<string> undoKeys = AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.Undo;
                        int undoNo = undoKeys.Count > 0 ? int.Parse(undoKeys[^1].Split("|")[0].Split("_")[2]) + 1 : 1;
                        //AppConfig.AppPropertySetting.Instance().AddProperty(new AppConfig.AppPropElement("A_F_" + undoNo.ToString().PadLeft(2, '0'), TargetFlight), AppConfig.AppPropSection.UndoCollection);
                        AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.Undo.Add(string.Format("{0}|{1}", "A_F_" + undoNo.ToString().PadLeft(2, '0'), TargetFlight));
                        Close();
                    }
                }
                else
                {
                    // 顯示對話方塊說明參數輸入錯誤或不足，因此無法執行測試資料產生
                    InfoLog.Log("BRSTestDataGenerator", "ChildForm", "Some inputs is invalid. Adding FIDS data is not completed yet.");
                    MessageBox.Show("Some inputs is invalid.", "Warning", MessageBoxButtons.OK);
                }
            }
            else
            {
                // 異動確認之對話方塊選擇"No"
                // Do Nothig...
                InfoLog.Log("BRSTestDataGenerator", "ChildForm", "Not to Complete this FIDS amendment.");
            }
        }

        private void Button_Flight_N_Click(object sender, EventArgs e)
        {
            InfoLog.Log("BRSTestDataGenerator", "ChildForm", "Click <Cancel> button to close the FIDS diaglog.");
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

        private void Text_STD_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Text_STD.Text))
            {
                Text_STD.ForeColor = Color.Silver;
                Text_STD.Text = AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.Default.STD;
            }
            else if (!new Regex(@"^\d{4}$").IsMatch(Text_STD.Text))
            {
                Text_STD.ForeColor = Color.Red;
            }
        }

        private void Text_ETD_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Text_ETD.Text))
            {
                Text_ETD.ForeColor = Color.Silver;
                Text_ETD.Text = AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.Default.ETD;
            }
            else if (!new Regex(@"^\d{4}$").IsMatch(Text_ETD.Text))
            {
                Text_ETD.ForeColor = Color.Red;
            }
        }

        private void Text_DES_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Text_DES.Text))
            {
                Text_DES.ForeColor = Color.Silver;
                Text_DES.Text = AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.Default.DES;
            }
            else if (!new Regex(@"^[A-Z]{3,4}$").IsMatch(Text_DES.Text))
            {
                Text_DES.ForeColor = Color.Red;
            }
        }
        #endregion

        #endregion

        #region =====[Private] Function=====

        private void InitializeForm()
        {
            Text_STD.ForeColor = Color.Silver;
            Text_STD.Text = AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.Default.STD;
            Text_ETD.ForeColor = Color.Silver;
            Text_ETD.Text = AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.Default.ETD;
            Text_DES.ForeColor = Color.Silver;
            Text_DES.Text = AppJsonConfig.AppPropertySetting.Instance().ConfigRoot.properties.AppPropSetting.Default.DES;
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
                    ErrorLog.Log("ERROR", "ChildForm", "DB connection failed.");
                    return false; // 資料庫連線失敗
                }
                FIDS2Day TB_FIDS2Day = new FIDS2Day(T1BRSDB.Conn);
                if (TB_FIDS2Day.SelectByKey(newRow.FLIGHT_NO, newRow.DATE_TIME) <= 0)
                {
                    Transaction_T1BRSDB.BeginTransaction(TB_FIDS2Day);
                    Transaction_T1BRSDB.SetTransactionResult(TB_FIDS2Day, TB_FIDS2Day.Insert(newRow));
                    if (Transaction_T1BRSDB.EndTransaction()[TB_FIDS2Day.SqlCmd.Connection])
                    {
                        InfoLog.Log("BRSTestDataGenerator", "ChildForm", string.Format("Add new test data of flight: {0} successfully", newRow.FLIGHT_NO));
                        return true;
                    }
                    else
                    {
                        ErrorLog.Log("ERROR", "ChildForm", string.Format("Failed to add new test data of flight: {0}.", newRow.FLIGHT_NO));
                        return false;
                    }
                }
                else
                {
                    InfoLog.Log("BRSTestDataGenerator", "ChildForm", string.Format("The test data of flight: {0} already exists and is not added.", newRow.FLIGHT_NO));
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
