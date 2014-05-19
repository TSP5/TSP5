using Prototype2._0;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest
{
    
    
    /// <summary>
    ///这是 settingsTest 的测试类，旨在
    ///包含所有 settingsTest 单元测试
    ///</summary>
    [TestClass()]
    public class settingsTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        // 
        //编写测试时，还可使用以下特性:
        //
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //使用 TestInitialize 在运行每个测试前先运行代码
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///settings 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void settingsConstructorTest()
        {
            settings target = new settings();
            //Assert.Inconclusive("TODO: 实现用来验证目标的代码");
        }

        /// <summary>
        ///Dispose 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Prototype2.0.exe")]
        public void DisposeTest()
        {
            settings_Accessor target = new settings_Accessor(); // TODO: 初始化为适当的值
            bool disposing = false; // TODO: 初始化为适当的值
            target.Dispose(disposing);
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///InitMenu 的测试
        ///</summary>
        [DeploymentItem("Prototype2.0.exe")]
        public void InitMenuTest()
        {
            settings_Accessor target = new settings_Accessor(); // TODO: 初始化为适当的值
            target.InitMenu();
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///InitPanel 的测试
        ///</summary>
        [DeploymentItem("Prototype2.0.exe")]
        public void InitPanelTest()
        {
            settings_Accessor target = new settings_Accessor(); // TODO: 初始化为适当的值
            target.InitPanel();
            Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///InitializeComponent 的测试
        ///</summary>
        [DeploymentItem("Prototype2.0.exe")]
        public void InitializeComponentTest()
        {
            settings_Accessor target = new settings_Accessor(); // TODO: 初始化为适当的值
            target.InitializeComponent();
            Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///MenuClick 的测试
        ///</summary>
        [DeploymentItem("Prototype2.0.exe")]
        public void MenuClickTest()
        {
            settings_Accessor target = new settings_Accessor(); // TODO: 初始化为适当的值
            int index = 0; // TODO: 初始化为适当的值
            target.MenuClick(index);
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///OpenMenu 的测试
        ///</summary>
        [DeploymentItem("Prototype2.0.exe")]
        public void OpenMenuTest()
        {
            settings_Accessor target = new settings_Accessor(); // TODO: 初始化为适当的值
            int index = 0; // TODO: 初始化为适当的值
            target.OpenMenu(index);
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///RefleshMenu 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Prototype2.0.exe")]
        public void RefleshMenuTest()
        {
            settings_Accessor target = new settings_Accessor(); // TODO: 初始化为适当的值
            target.RefleshMenu();
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///RefleshPanel 的测试
        ///</summary>
        [DeploymentItem("Prototype2.0.exe")]
        public void RefleshPanelTest()
        {
            settings_Accessor target = new settings_Accessor(); // TODO: 初始化为适当的值
            target.RefleshPanel();
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///ShowPanel 的测试
        ///</summary>
        [DeploymentItem("Prototype2.0.exe")]
        public void ShowPanelTest()
        {
            settings_Accessor target = new settings_Accessor(); // TODO: 初始化为适当的值
            int index = 0; // TODO: 初始化为适当的值
            target.ShowPanel(index);
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///button1_Click 的测试
        ///</summary>
        [DeploymentItem("Prototype2.0.exe")]
        public void button1_ClickTest()
        {
            settings_Accessor target = new settings_Accessor(); // TODO: 初始化为适当的值
            object sender = null; // TODO: 初始化为适当的值
            EventArgs e = null; // TODO: 初始化为适当的值
            target.button1_Click(sender, e);
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///button2_Click 的测试
        ///</summary>
        [DeploymentItem("Prototype2.0.exe")]
        public void button2_ClickTest()
        {
            settings_Accessor target = new settings_Accessor(); // TODO: 初始化为适当的值
            object sender = null; // TODO: 初始化为适当的值
            EventArgs e = null; // TODO: 初始化为适当的值
            target.button2_Click(sender, e);
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///button3_Click 的测试
        ///</summary>
        [DeploymentItem("Prototype2.0.exe")]
        public void button3_ClickTest()
        {
            settings_Accessor target = new settings_Accessor(); // TODO: 初始化为适当的值
            object sender = null; // TODO: 初始化为适当的值
            EventArgs e = null; // TODO: 初始化为适当的值
            target.button3_Click(sender, e);
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        

        /// <summary>
        ///settings_Load 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Prototype2.0.exe")]
        public void settings_LoadTest()
        {
            settings_Accessor target = new settings_Accessor(); // TODO: 初始化为适当的值
            object sender = null; // TODO: 初始化为适当的值
            EventArgs e = null; // TODO: 初始化为适当的值
            target.settings_Load(sender, e);
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }
    }
}
