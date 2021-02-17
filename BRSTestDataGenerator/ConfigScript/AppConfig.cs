using Lib.Log;
using Lib.Misc.Property;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;

namespace BRSTestDataGenerator.ConfigScript
{
    /// <summary>
    /// 一般應用程式中 <c>App.config</c> 組態設定("AppConfigSetting")之處理類別
    /// </summary>
    public class AppConfig : XMLPropertyBase
    {
        #region =====[Public] Class for Reflecting the Property Sections and Its Elements=====

        /// <summary>
        /// 組態設定檔區段之內容定義類別
        /// </summary>
        public class AppPropSection : ConfigurationSection
        {
            #region =====[Public] Collection Name=====
            /// <summary>
            /// DB相關組態設定成員集合名稱
            /// </summary>
            public const string DBCollection = "DBServer";
            /// <summary>
            /// 基本組態設定成員集合名稱
            /// </summary>
            public const string BasicCollection = "Basic";
            /// <summary>
            /// 預設參數值組態設定成員集合名稱
            /// </summary>
            public const string DefaultCollection = "Default";
            /// <summary>
            /// 回復步驟記錄列表組態設定成員集合名稱
            /// </summary>
            public const string UndoCollection = "Undo";
            /// <summary>
            /// 重複步驟記錄列表組態設定成員集合名稱
            /// </summary>
            public const string RedoCollection = "Redo";
            #endregion

            #region =====[Public] Collection Structor=====
            /// <summary>
            /// DB相關組態設定成員集合
            /// </summary>
            [ConfigurationProperty(DBCollection, IsDefaultCollection = false)]
            [ConfigurationCollection(typeof(AppPropElement), AddItemName = "add", ClearItemsName = "clear", RemoveItemName = "remove")]
            public AppPropsCollection DBPropCollection => (AppPropsCollection)this[DBCollection];
            /// <summary>
            /// 基本組態設定成員集合
            /// </summary>
            [ConfigurationProperty(BasicCollection, IsDefaultCollection = false)]
            [ConfigurationCollection(typeof(AppPropElement), AddItemName = "add", ClearItemsName = "clear", RemoveItemName = "remove")]
            public AppPropsCollection BasicPropCollection => (AppPropsCollection)this[BasicCollection];
            /// <summary>
            /// 預設參數值組態設定成員集合
            /// </summary>
            [ConfigurationProperty(DefaultCollection, IsDefaultCollection = false)]
            [ConfigurationCollection(typeof(AppPropElement), AddItemName = "add", ClearItemsName = "clear", RemoveItemName = "remove")]
            public AppPropsCollection DefaultPropCollection => (AppPropsCollection)this[DefaultCollection];
            /// <summary>
            /// 回復步驟記錄列表組態設定成員集合
            /// </summary>
            [ConfigurationProperty(UndoCollection, IsDefaultCollection = false)]
            [ConfigurationCollection(typeof(AppPropElement), AddItemName = "add", ClearItemsName = "clear", RemoveItemName = "remove")]
            public AppPropsCollection UndoPropCollection => (AppPropsCollection)this[UndoCollection];
            /// <summary>
            /// 重複步驟記錄列表組態設定成員集合
            /// </summary>
            [ConfigurationProperty(RedoCollection, IsDefaultCollection = false)]
            [ConfigurationCollection(typeof(AppPropElement), AddItemName = "add", ClearItemsName = "clear", RemoveItemName = "remove")]
            public AppPropsCollection RedoPropCollection => (AppPropsCollection)this[RedoCollection];
            #endregion

            #region =====[Public] Constructor & Destructor=====
            /// <summary>
            /// 建構子
            /// </summary>
            public AppPropSection()
            {
                AppPropElement appProp = new AppPropElement();
                DBPropCollection.Add(appProp);
                BasicPropCollection.Add(appProp);
                DefaultPropCollection.Add(appProp);
                UndoPropCollection.Add(appProp);
                RedoPropCollection.Add(appProp);
            }
            #endregion
        }

        /// <summary>
        /// 組態設定成員內容之定義類別
        /// </summary>
        public class AppPropElement : PropertyElement
        {
            #region =====[Public] Element Structor=====
            // 可添加所需之組態設定成員結構與內容
            #endregion

            #region =====[Public] Constructor & Destructor=====
            /// <summary>
            /// 建構子
            /// </summary>
            public AppPropElement() { }
            /// <summary>
            /// 建構子
            /// </summary>
            /// <param name="key">組態設定標籤</param>
            /// <param name="value">組態設定值</param>
            public AppPropElement(string key, string value) : base(key, value) { }
            #endregion
        }

        /// <summary>
        /// 組態設定成員集合之定義類別
        /// </summary>
        public class AppPropsCollection : PropertiesCollection
        {
            #region =====[Public] Constructor & Destructor=====
            /// <summary>
            /// 建構子
            /// </summary>
            public AppPropsCollection() { }
            #endregion

            #region =====[Public] Method=====
            // 可複寫組態設定成員處理的相關方法(Add, remove, clear...)
            #endregion
        }

        /// <summary>
        /// 系統組態設定(App.config)相關處理類別
        /// </summary>
        public class AppPropertySetting : PropertySetting<AppPropSection>
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
                /// <remarks>預設組態設定檔案"App.config"位置為工作目錄，且系統組態設定檔之區段路徑為"AppConfigSetting"</remarks>
                public static readonly AppPropertySetting INSTANCE = new AppPropertySetting("AppConfigSetting", new Uri(Assembly.GetExecutingAssembly().GetName().CodeBase).LocalPath);
                //public static readonly AppPropertySetting INSTANCE = new AppPropertySetting("AppConfigSetting", "~/");
            }
            #endregion

            #region =====[Public] Constructor & Destructor=====
            /// <summary>
            /// 建構子
            /// </summary>
            /// <param name="pSectionName">系統組態設定檔之區段名稱</param>
            /// <param name="pConfigPath">系統組態設定檔之檔案路徑名稱</param>
            public AppPropertySetting(string pSectionName, string pConfigPath) : base(pSectionName, pConfigPath) { }
            /// <summary>
            /// 建構子
            /// </summary>
            /// <param name="pSectionName">系統組態設定檔之區段名稱</param>
            /// <param name="pConfig">目前的組態設定檔案</param>
            public AppPropertySetting(string pSectionName, Configuration pConfig) : base(pSectionName, pConfig) { }
            #endregion

            #region =====[Public] Method=====
            /// <summary>
            /// 取得系統組態設定(App.config)物件實體
            /// </summary>
            /// <returns><c>AppPropertySetting</c> 通用物件實體</returns>
            public static AppPropertySetting Instance()
            {
                return LazyHolder.INSTANCE;
            }
            /// <summary>
            /// 新增特定型態之組態設定成員至組態設定集合
            /// </summary>
            /// <param name="element">特定型態之組態設定成員</param>
            /// <param name="pCollectionName">特定組態設定成員集合之名稱</param>
            public override void AddProperty(object element, string pCollectionName)
            {
                try
                {
                    // Get the application configuration file.
                    GetConfigurationFile();
                    // Read and display the custom section.
                    GetPropSection();

                    // Add the element to the collection in the custom section.
                    if (PropSection != null)
                    {
                        // Use the ConfigurationCollectionElement Add method to add the new element to the collection.
                        switch (pCollectionName)
                        {
                            case AppPropSection.DBCollection:
                                PropSection.DBPropCollection.Add((AppPropElement)element);
                                break;
                            case AppPropSection.BasicCollection:
                                PropSection.BasicPropCollection.Add((AppPropElement)element);
                                break;
                            case AppPropSection.DefaultCollection:
                                PropSection.DefaultPropCollection.Add((AppPropElement)element);
                                break;
                            case AppPropSection.UndoCollection:
                                PropSection.UndoPropCollection.Add((AppPropElement)element);
                                break;
                            case AppPropSection.RedoCollection:
                                PropSection.RedoPropCollection.Add((AppPropElement)element);
                                break;
                            default:
                                Console.WriteLine("The requested ConfigurationCollection name {0} is not found", pCollectionName);
                                return;
                        }

                        // Save the application configuration file.
                        PropSection.SectionInformation.ForceSave = true;
                        Config.Save(ConfigurationSaveMode.Modified);

                        InfoLog.Log("AppConfig", "AddProperty", string.Format("Added collection element to the custom section in the configuration file: {0}", Config.FilePath));
                    }
                    else
                    {
                        InfoLog.Log("AppConfig", "AddProperty", "You must create the custom section first.");
                    }
                }
                catch (ConfigurationErrorsException ex)
                {
                    ErrorLog.Log("AddProperty", ex);
                    throw ex;
                }
            }
            /// <summary>
            /// 確認組態設定檔區段之內容是否包含標籤名稱(key)
            /// </summary>
            /// <param name="key">標籤名稱(key)</param>
            /// <returns>標籤名稱(key)確認包含狀態</returns>
            public override bool ContainsKey(string key)
            {
                try
                {
                    // Get the application configuration file.
                    GetConfigurationFile();
                    // Read and display the custom section.
                    GetPropSection();

                    if (PropSection != null)
                    {
                        return PropSection.DBPropCollection.ContainsKey(key) || PropSection.BasicPropCollection.ContainsKey(key) || PropSection.DefaultPropCollection.ContainsKey(key);
                    }

                    return false;
                }
                catch (ConfigurationErrorsException ex)
                {
                    ErrorLog.Log("ContainsKey", ex);
                    throw ex;
                }
            }
            /// <summary>
            /// 取得組態設定檔區段之內容中所有標籤名稱(key)
            /// </summary>
            /// <returns>組態設定標籤清單</returns>
            public override List<string> GetAllPropertyNames()
            {
                List<string> propNameList = new List<string>();

                try
                {
                    // Get the application configuration file.
                    GetConfigurationFile();
                    // Read and display the custom section.
                    GetPropSection();

                    if (PropSection != null)
                    {
                        propNameList.AddRange(PropSection.DBPropCollection.GetAllPropertyNames());
                        propNameList.AddRange(PropSection.BasicPropCollection.GetAllPropertyNames());
                        propNameList.AddRange(PropSection.DefaultPropCollection.GetAllPropertyNames());
                    }

                    return propNameList;
                }
                catch (ConfigurationErrorsException ex)
                {
                    ErrorLog.Log("GetAllPropertyNames", ex);
                    throw ex;
                }
            }
            /// <summary>
            /// 依組態設定成員集合(Collection)取得組態設定檔區段之所有標籤名稱(key)
            /// </summary>
            /// <param name="pCollectionName">特定組態設定成員集合之名稱</param>
            /// <returns>對應組態設定成員集合的組態設定標籤清單</returns>
            public List<string> GetCollectionPropertyNames(string pCollectionName)
            {
                List<string> propNameList = new List<string>();

                try
                {
                    // Get the application configuration file.
                    GetConfigurationFile();
                    // Read and display the custom section.
                    GetPropSection();

                    if (PropSection != null)
                    {
                        switch (pCollectionName)
                        {
                            case AppPropSection.DBCollection:
                                propNameList = PropSection.DBPropCollection.GetAllPropertyNames();
                                break;
                            case AppPropSection.BasicCollection:
                                propNameList = PropSection.BasicPropCollection.GetAllPropertyNames();
                                break;
                            case AppPropSection.DefaultCollection:
                                propNameList = PropSection.DefaultPropCollection.GetAllPropertyNames();
                                break;
                            case AppPropSection.UndoCollection:
                                propNameList = PropSection.UndoPropCollection.GetAllPropertyNames();
                                break;
                            case AppPropSection.RedoCollection:
                                propNameList = PropSection.RedoPropCollection.GetAllPropertyNames();
                                break;
                            default:
                                Console.WriteLine("The requested ConfigurationCollection name {0} is not found", pCollectionName);
                                break;
                        }
                    }

                    return propNameList;
                }
                catch (ConfigurationErrorsException ex)
                {
                    ErrorLog.Log("GetCollectionProperty", ex);
                    throw ex;
                }
            }
            /// <summary>
            /// 依標籤名稱(key)取得組態設定檔區段內容之設定值
            /// </summary>
            /// <param name="key">標籤名稱(key)</param>
            /// <returns>對應標籤名稱(key)的組態設定值</returns>
            public override string GetProperty(string key)
            {
                string ret = null;

                try
                {
                    // Get the application configuration file.
                    GetConfigurationFile();
                    // Read and display the custom section.
                    GetPropSection();

                    if (PropSection != null)
                    {
                        if (PropSection.DBPropCollection[key] != null)
                        {
                            ret = PropSection.DBPropCollection[key].Value;
                        }
                        else if (PropSection.BasicPropCollection[key] != null)
                        {
                            ret = PropSection.BasicPropCollection[key].Value;
                        }
                        else if (PropSection.DefaultPropCollection[key] != null)
                        {
                            ret = PropSection.DefaultPropCollection[key].Value;
                        }
                    }

                    return ret;
                }
                catch (ConfigurationErrorsException ex)
                {
                    ErrorLog.Log("GetProperty", ex);
                    throw ex;
                }
            }
            /// <summary>
            /// 將標籤名稱(key)的組態設定檔區段內容之設定值變更
            /// </summary>
            /// <param name="key">標籤名稱(key)</param>
            /// <param name="value">欲變更組態設定檔區段內容之設定值</param>
            public override void SetProperty(string key, string value)
            {
                try
                {
                    // Get the application configuration file.
                    GetConfigurationFile();
                    // Read and display the custom section.
                    GetPropSection();

                    if (PropSection != null)
                    {
                        if (PropSection.DBPropCollection[key] != null)
                        {
                            PropSection.DBPropCollection[key].Value = value;
                        }
                        else if (PropSection.BasicPropCollection[key] != null)
                        {
                            PropSection.BasicPropCollection[key].Value = value;
                        }
                        else if (PropSection.DefaultPropCollection[key] != null)
                        {
                            PropSection.DefaultPropCollection[key].Value = value;
                        }
                    }

                    // Save the application configuration file.
                    PropSection.SectionInformation.ForceSave = true;
                    Config.Save(ConfigurationSaveMode.Modified);

                    InfoLog.Log("AppConfig", "SetProperty", string.Format("Saved the value for the collection element from the custom section in the configuration file: {0}", Config.FilePath));
                }
                catch (ConfigurationErrorsException ex)
                {
                    ErrorLog.Log("SetProperty", ex);
                    throw ex;
                }
            }
            /// <summary>
            /// 建立並取得指定組態設定檔區段之內容定義物件
            /// </summary>
            /// <param name="pSectionName">指定的系統組態設定檔之區段名稱</param>
            /// <returns>指定組態設定檔區段之內容定義物件</returns>
            public override AppPropSection GetPropSection(string pSectionName)
            {
                PropSection = (AppPropSection)Config.Sections[SectionName];
                return PropSection;
            }
            /// <summary>
            /// 自組態設定集合移除所有組態設定成員
            /// </summary>
            public override void RemoveAllProperties()
            {
                try
                {
                    // Get the application configuration file.
                    GetConfigurationFile();
                    // Read and display the custom section.
                    GetPropSection();

                    // Remove the collection of elements from the section.
                    if (PropSection != null)
                    {
                        PropSection.DBPropCollection.Clear();
                        PropSection.BasicPropCollection.Clear();
                        PropSection.DefaultPropCollection.Clear();
                        PropSection.UndoPropCollection.Clear();
                        PropSection.RedoPropCollection.Clear();

                        // Save the application configuration file.
                        PropSection.SectionInformation.ForceSave = true;
                        Config.Save(ConfigurationSaveMode.Modified);

                        InfoLog.Log("AppConfig", "RemoveAllProperties", string.Format("Removed collection element from the custom section in the configuration file: {0}", Config.FilePath));
                    }
                    else
                    {
                        InfoLog.Log("AppConfig", "RemoveAllProperties", "You must create the custom section first.");
                    }
                }
                catch (ConfigurationErrorsException ex)
                {
                    ErrorLog.Log("RemoveAllProperties", ex);
                    throw ex;
                }
            }
            /// <summary>
            /// 自組態設定集合依標籤名稱(key)移除特定型態組態設定成員
            /// </summary>
            /// <param name="key">標籤名稱(key)</param>
            /// <param name="pCollectionName">特定組態設定成員集合之名稱</param>
            public override void RemoveProperty(string key, string pCollectionName)
            {
                try
                {
                    // Get the application configuration file.
                    GetConfigurationFile();
                    // Read and display the custom section.
                    GetPropSection();

                    // Remove the element from the custom section.
                    if (PropSection != null)
                    {
                        // Use one of the ConfigurationCollectionElement Remove overloaded methods to remove the element from the collection based on the element's key
                        switch (pCollectionName)
                        {
                            case AppPropSection.DBCollection:
                                PropSection.DBPropCollection.Remove(PropSection.DBPropCollection[key]);
                                break;
                            case AppPropSection.BasicCollection:
                                PropSection.BasicPropCollection.Remove(PropSection.BasicPropCollection[key]);
                                break;
                            case AppPropSection.DefaultCollection:
                                PropSection.DefaultPropCollection.Remove(PropSection.DefaultPropCollection[key]);
                                break;
                            case AppPropSection.UndoCollection:
                                PropSection.UndoPropCollection.Remove(PropSection.UndoPropCollection[key]);
                                break;
                            case AppPropSection.RedoCollection:
                                PropSection.RedoPropCollection.Remove(PropSection.RedoPropCollection[key]);
                                break;
                            default:
                                InfoLog.Log(string.Empty, "AppConfig", string.Format("The requested ConfigurationCollection name {0} is not found", pCollectionName));
                                return;
                        }

                        // Save the application configuration file.
                        PropSection.SectionInformation.ForceSave = true;
                        Config.Save(ConfigurationSaveMode.Modified);

                        InfoLog.Log("AppConfig", "RemoveProperty", string.Format("Removed collection element from the custom section in the configuration file: {0}", Config.FilePath));
                    }
                    else
                    {
                        InfoLog.Log("AppConfig", "RemoveProperty", "You must create the custom section first.");
                    }
                }
                catch (ConfigurationErrorsException ex)
                {
                    ErrorLog.Log("RemoveProperty", ex);
                    throw ex;
                }
            }
            #endregion

            #region =====[Protected] Function=====
            /// <summary>
            /// 建立並儲存 <c>AppPropElement</c> 組態設定檔案所需之區段
            /// </summary>
            protected override void CreateCustomSection()
            {
                try
                {
                    // Get the current configuration file.
                    GetConfigurationFile();
                    // Add the custom section to the application configuration file.
                    GetPropSection();

                    if (PropSection == null)
                    {
                        // The configuration file does not contain the custom section yet. Create it.
                        PropSection = new AppPropSection();
                        Config.Sections.Add(SectionName, PropSection);
                    }
                    else
                    {
                        // The configuration file contains the custom section but its element collection is empty. Initialize the collection
                        if (PropSection.DBPropCollection.Count == 0)
                        {
                            PropSection.DBPropCollection.Add(new AppPropElement());
                        }
                        if (PropSection.BasicPropCollection.Count == 0)
                        {
                            PropSection.BasicPropCollection.Add(new AppPropElement());
                        }
                        if (PropSection.DefaultPropCollection.Count == 0)
                        {
                            PropSection.DefaultPropCollection.Add(new AppPropElement());
                        }
                        if (PropSection.UndoPropCollection.Count == 0)
                        {
                            PropSection.UndoPropCollection.Add(new AppPropElement());
                        }
                        if (PropSection.RedoPropCollection.Count == 0)
                        {
                            PropSection.RedoPropCollection.Add(new AppPropElement());
                        }
                    }

                    // Save the application configuration file.
                    PropSection.SectionInformation.ForceSave = true;
                    bool sb = Config.HasFile;
                    Config.Save(ConfigurationSaveMode.Modified);

                    InfoLog.Log("AppConfig", "CreateCustomSection", string.Format("Created custom section in the application configuration file: {0}", Config.FilePath));
                }
                catch (ConfigurationErrorsException ex)
                {
                    ErrorLog.Log("CreateCustomSection", ex);
                    throw ex;
                }
            }
            #endregion
        }

        #endregion
    }
}