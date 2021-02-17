using Lib.Misc.Property;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace BRSTestDataGenerator.ConfigScript
{
    /// <summary>
    ///  一般應用程式中 <c>appsettings.json</c> 組態設定("AppPropSetting")之處理類別
    /// </summary>
    public class AppJsonConfig : JsonPropertyBase
    {
        #region [Public] Class for Reflecting the Property Sections and Its Elements

        #region =====組態設定區段之依賴類別組 (For DI)=====
        /// <summary>
        /// DB相關組態設定參數類別
        /// </summary>
        public class DBServer
        {
            /// <summary>
            /// BRS DB連接參數
            /// </summary>
            [JsonProperty("T1BRSDB", Required = Required.Always)]
            public string T1BRSDB { get; set; }
        }
        /// <summary>
        /// 其他基本組態設定參數類別
        /// </summary>
        public class Basic
        {
            /// <summary>
            /// 程式執行模式
            /// </summary>
            /// <remarks>
            /// <para>0: 表示為測試模式</para>
            /// <para>1: 表示為正式運行模式</para>
            /// </remarks>
            [JsonProperty("Mode", Required = Required.Always)]
            public string Mode { get; set; }
            /// <summary>
            /// 測試模式運行下使用之測試日期，格式為"yyyy-MM-dd"
            /// </summary>
            [JsonProperty("TestDate", Required = Required.Default)]
            public string TestDate { get; set; }
            /// <summary>
            /// 資料修改者、程式使用者名稱
            /// </summary>
            [JsonProperty("User", Required = Required.Always)]
            public string User { get; set; }
        }
        /// <summary>
        /// 預設輸入參數組態設定類別
        /// </summary>
        public class Default
        {
            /// <summary>
            /// 各航班屬性資料之預設名稱參數
            /// </summary>
            [JsonProperty("PropNames", Required = Required.Always)]
            public string PropNames { get; set; }
            /// <summary>
            /// 航班測試資料之預設輸入提示參數(表定起飛時間)
            /// </summary>
            [JsonProperty("STD", Required = Required.Always)]
            public string STD { get; set; }
            /// <summary>
            /// 航班測試資料之預設輸入提示參數(預計起飛時間)
            /// </summary>
            [JsonProperty("ETD", Required = Required.Always)]
            public string ETD { get; set; }
            /// <summary>
            /// 航班測試資料之預設輸入提示參數(目的地)
            /// </summary>
            [JsonProperty("DES", Required = Required.Always)]
            public string DES { get; set; }
            /// <summary>
            /// 行李測試資料之預設輸入提示參數(資料筆數)
            /// </summary>
            [JsonProperty("Data#", Required = Required.Always)]
            public string DataNum { get; set; }
            /// <summary>
            /// 行李測試資料之預設輸入提示參數(行李裝載狀態)
            /// </summary>
            [JsonProperty("BagState", Required = Required.Always)]
            public string BagState { get; set; }
            /// <summary>
            /// 行李測試資料之預設輸入提示參數(艙等)
            /// </summary>
            [JsonProperty("CabinClass", Required = Required.Always)]
            public string CabinClass { get; set; }
            /// <summary>
            /// 行李測試資料之欄位資料預設值(BSM資料異動狀態)
            /// </summary>
            [JsonProperty("BsmState", Required = Required.Always)]
            public string BsmState { get; set; }
            /// <summary>
            /// 航班測試資料之欄位資料預設值(航班編號)
            /// </summary>
            [JsonProperty("FlightNo", Required = Required.Always)]
            public string FlightNo { get; set; }
            /// <summary>
            /// 行李測試資料之欄位資料起始預設值(行李條碼編號)
            /// </summary>
            [JsonProperty("BagTag", Required = Required.Always)]
            public string BagTag { get; set; }
            /// <summary>
            /// 行李測試資料之欄位資料預設值(旅客姓名)
            /// </summary>
            [JsonProperty("Passenger", Required = Required.Always)]
            public string Passenger { get; set; }
            /// <summary>
            /// 行李測試資料之欄位資料預設值(座位號碼)
            /// </summary>
            [JsonProperty("Seat", Required = Required.Always)]
            public string Seat { get; set; }
            /// <summary>
            /// 行李測試資料之欄位資料預設值(允許裝載旗標)
            /// </summary>
            [JsonProperty("AuthLoad", Required = Required.Always)]
            public string AuthLoad { get; set; }
            /// <summary>
            /// 行李測試資料之欄位資料預設值(允許運送旗標)
            /// </summary>
            [JsonProperty("AuthTransport", Required = Required.Always)]
            public string AuthTransport { get; set; }
        }
        /// <summary>
        /// 組態設定參數集合類別
        /// </summary>
        public class AppPropSetting
        {
            /// <summary>
            /// DB相關組態設定參數類別物件
            /// </summary>
            public DBServer DBServer { get; set; }
            /// <summary>
            /// 其他基本組態設定參數類別物件
            /// </summary>
            public Basic Basic { get; set; }
            /// <summary>
            /// 預設參數組態設定參數類別物件
            /// </summary>
            public Default Default { get; set; }
            /// <summary>
            /// 異動回復組態設定參數類別物件
            /// </summary>
            public List<string> Undo { get; set; }
            /// <summary>
            /// 異動復原組態設定參數類別物件
            /// </summary>
            public List<string> Redo { get; set; }
        }
        /// <summary>
        /// 組態設定參數根集合類別
        /// </summary>
        public class AppSetting
        {
            /// <summary>
            /// 組態設定參數集合類別
            /// </summary>
            public AppPropSetting AppPropSetting { get; set; }
        }
        #endregion

        /// <summary>
        /// 依賴類別注入服務之應用類別，取得指定之組態設定檔內容(AppSetting)
        /// </summary>
        /// <remarks>
        /// <para>泛型<c>T</c>之對應之組態設定區段的依賴類別，使用<c>AppPropSetting</c></para>
        /// <para><c>properties</c>參數依 <c>AppPropSetting</c> 依賴類別存取目前組態設定值</para>
        /// </remarks>
        public class AppPropSettingDI : AppSettingsDI<AppPropSetting>
        {
            #region =====[Public] Constructor & Descructor=====
            /// <summary>
            /// 建構子
            /// </summary>
            /// <param name="aprop">組態設定依賴轉換之物件參數</param>
            public AppPropSettingDI(IOptions<AppPropSetting> aprop) : base(aprop) { }
            #endregion

            #region =====[Public] Method=====
            // 可自訂其他組態設定值(properties)運用的方法
            #endregion
        }

        /// <summary>
        /// 依賴類別注入服務之應用類別，取得指定之組態設定檔內容(Root)
        /// </summary>
        public class AppSettingRootDI : AppSettingsDI<AppSetting>
        {
            #region =====[Public] Constructor & Descructor=====
            /// <summary>
            /// 建構子
            /// </summary>
            /// <param name="aprop">組態設定依賴轉換之物件參數</param>
            public AppSettingRootDI(IOptions<AppSetting> aprop) : base(aprop) { }
            #endregion

            #region =====[Public] Method=====
            // 可自訂其他組態設定值(properties)運用的方法
            #endregion
        }

        /// <summary>
        /// 系統組態設定(appsettings.json)相關處理類別
        /// </summary>
        public class AppPropertySetting : PropertySetting<AppSetting, AppSettingRootDI>
        {
            #region =====[Private] Class=====
            /// <summary>
            /// 靜態初始化通用物件實體類別
            /// </summary>
            private static class LazyHolder
            {
                /// <summary>
                /// <c>AppPropertySetting</c> 通用物件實體
                /// </summary>
                /// <remarks>預設組態設定檔案"appsettings.json"位置為工作目錄，且系統組態設定檔之區段路徑為"AppPropSetting"</remarks>
                public static readonly AppPropertySetting INSTANCE = new AppPropertySetting("AppPropSetting", Directory.GetCurrentDirectory() + @"\appsettings.json");
            }
            #endregion

            #region =====[Public] Getter & Setter=====
            /// <summary>
            /// 系統組態設定(Configuration)根物件
            /// </summary>
            public AppSettingRootDI ConfigRoot { get; }
            #endregion

            #region =====[Public] Constructor & Destructor=====
            /// <summary>
            /// 建構子
            /// </summary>
            /// <param name="pSectionPath">系統組態設定檔之區段路徑，無指定則填入<c>null</c>或<c>string.Empty</c></param>
            public AppPropertySetting(string pSectionPath) : base(pSectionPath)
            {
                ConfigRoot = ServiceProvider.GetService<AppSettingRootDI>();
            }
            /// <summary>
            /// 建構子
            /// </summary>
            /// <param name="pSectionPath">系統組態設定檔之區段路徑，無指定則填入<c>null</c>或<c>string.Empty</c></param>
            /// <param name="pConfigPath">系統組態設定檔之檔案路徑名稱</param>
            public AppPropertySetting(string pSectionPath, string pConfigPath) : base(pSectionPath, pConfigPath)
            {
                ConfigRoot = ServiceProvider.GetService<AppSettingRootDI>();
            }
            #endregion

            /// <summary>
            /// 取得系統組態設定(Configuration)物件實體
            /// </summary>
            /// <returns><c>AppPropertySetting</c> 通用物件實體</returns>
            public static AppPropertySetting Instance()
            {
                return LazyHolder.INSTANCE;
            }
        }

        #endregion
    }
}
