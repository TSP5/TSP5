using Prototype2._0;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;

namespace UnitTest
{
    
    
    /// <summary>
    ///这是 mainTest 的测试类，旨在
    ///包含所有 mainTest 单元测试
    ///</summary>
    [TestClass()]
    public class mainTest
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
        ///main 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void mainConstructorTest()
        {
            main target = new main();
            //Assert.Inconclusive("TODO: 实现用来验证目标的代码");
        }

        /// <summary>
        ///Dispose 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Prototype2.0.exe")]
        public void DisposeTest()
        {
            main_Accessor target = new main_Accessor(); // TODO: 初始化为适当的值
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
            main_Accessor target = new main_Accessor(); // TODO: 初始化为适当的值
            target.InitMenu();
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///InitPanel 的测试
        ///</summary>
        [DeploymentItem("Prototype2.0.exe")]
        public void InitPanelTest()
        {
            main_Accessor target = new main_Accessor(); // TODO: 初始化为适当的值
            target.InitPanel();
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///InitializeComponent 的测试
        ///</summary>
        [DeploymentItem("Prototype2.0.exe")]
        public void InitializeComponentTest()
        {
            main_Accessor target = new main_Accessor(); // TODO: 初始化为适当的值
            target.InitializeComponent();
            Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///MenuClick 的测试
        ///</summary>
        [DeploymentItem("Prototype2.0.exe")]
        public void MenuClickTest()
        {
            main_Accessor target = new main_Accessor(); // TODO: 初始化为适当的值
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
            main_Accessor target = new main_Accessor(); // TODO: 初始化为适当的值
            int index = 0; // TODO: 初始化为适当的值
            target.OpenMenu(index);
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///RefleshFendoushiPanel 的测试
        ///</summary>
        [DeploymentItem("Prototype2.0.exe")]
        public void RefleshFendoushiPanelTest()
        {
            main_Accessor target = new main_Accessor(); // TODO: 初始化为适当的值
            target.RefleshFendoushiPanel();
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///RefleshMenu 的测试
        ///</summary>
        [DeploymentItem("Prototype2.0.exe")]
        public void RefleshMenuTest()
        {
            main_Accessor target = new main_Accessor(); // TODO: 初始化为适当的值
            target.RefleshMenu();
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///RefleshPanel 的测试
        ///</summary>
        [DeploymentItem("Prototype2.0.exe")]
        public void RefleshPanelTest()
        {
            main_Accessor target = new main_Accessor(); // TODO: 初始化为适当的值
            target.RefleshPanel();
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///RefleshWodexinxiPanel 的测试
        ///</summary>
        [DeploymentItem("Prototype2.0.exe")]
        public void RefleshWodexinxiPanelTest()
        {
            main_Accessor target = new main_Accessor(); // TODO: 初始化为适当的值
            target.RefleshWodexinxiPanel();
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///RefleshZuotifenleiPanel 的测试
        ///</summary>
        [DeploymentItem("Prototype2.0.exe")]
        public void RefleshZuotifenleiPanelTest()
        {
            main_Accessor target = new main_Accessor(); // TODO: 初始化为适当的值
            target.RefleshZuotifenleiPanel();
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///ReleaseCapture 的测试
        ///</summary>
        public void ReleaseCaptureTest()
        {
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = main.ReleaseCapture();
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///SendMessage 的测试
        ///</summary>
        [TestMethod()]
        public void SendMessageTest()
        {
            IntPtr hwnd = new IntPtr(); // TODO: 初始化为适当的值
            int wMsg = 0; // TODO: 初始化为适当的值
            int wParam = 0; // TODO: 初始化为适当的值
            int lParam = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = main.SendMessage(hwnd, wMsg, wParam, lParam);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///ShowPanel 的测试
        ///</summary>
        [DeploymentItem("Prototype2.0.exe")]
        public void ShowPanelTest()
        {
            main_Accessor target = new main_Accessor(); // TODO: 初始化为适当的值
            int index = 0; // TODO: 初始化为适当的值
            target.ShowPanel(index);
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///button1_Click 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Prototype2.0.exe")]
        public void button1_ClickTest()
        {
            main_Accessor target = new main_Accessor(); // TODO: 初始化为适当的值
            object sender = null; // TODO: 初始化为适当的值
            EventArgs e = null; // TODO: 初始化为适当的值
            target.button1_Click(sender, e);
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///button1_Click_1 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Prototype2.0.exe")]
        public void button1_Click_1Test()
        {
            main_Accessor target = new main_Accessor(); // TODO: 初始化为适当的值
            object sender = null; // TODO: 初始化为适当的值
            EventArgs e = null; // TODO: 初始化为适当的值
            target.button1_Click_1(sender, e);
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///button2_Click 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Prototype2.0.exe")]
        public void button2_ClickTest()
        {
            main_Accessor target = new main_Accessor(); // TODO: 初始化为适当的值
            object sender = null; // TODO: 初始化为适当的值
            EventArgs e = null; // TODO: 初始化为适当的值
            target.button2_Click(sender, e);
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///button2_Click_1 的测试
        ///</summary>
        [DeploymentItem("Prototype2.0.exe")]
        public void button2_Click_1Test()
        {
            main_Accessor target = new main_Accessor(); // TODO: 初始化为适当的值
            object sender = null; // TODO: 初始化为适当的值
            EventArgs e = null; // TODO: 初始化为适当的值
            target.button2_Click_1(sender, e);
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///button3_Click 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Prototype2.0.exe")]
        public void button3_ClickTest()
        {
            main_Accessor target = new main_Accessor(); // TODO: 初始化为适当的值
            object sender = null; // TODO: 初始化为适当的值
            EventArgs e = null; // TODO: 初始化为适当的值
            target.button3_Click(sender, e);
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///button5_Click 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Prototype2.0.exe")]
        public void button5_ClickTest()
        {
            main_Accessor target = new main_Accessor(); // TODO: 初始化为适当的值
            object sender = null; // TODO: 初始化为适当的值
            EventArgs e = null; // TODO: 初始化为适当的值
            target.button5_Click(sender, e);
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///button_exit_Click 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Prototype2.0.exe")]
        public void button_exit_ClickTest()
        {
            main_Accessor target = new main_Accessor(); // TODO: 初始化为适当的值
            object sender = null; // TODO: 初始化为适当的值
            EventArgs e = null; // TODO: 初始化为适当的值
            target.button_exit_Click(sender, e);
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///button_fendoushi_Click 的测试
        ///</summary>
        [DeploymentItem("Prototype2.0.exe")]
        public void button_fendoushi_ClickTest()
        {
            main_Accessor target = new main_Accessor(); // TODO: 初始化为适当的值
            object sender = null; // TODO: 初始化为适当的值
            EventArgs e = null; // TODO: 初始化为适当的值
            target.button_fendoushi_Click(sender, e);
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///button_jiantixitong_Click 的测试
        ///</summary>
        [DeploymentItem("Prototype2.0.exe")]
        public void button_jiantixitong_ClickTest()
        {
            main_Accessor target = new main_Accessor(); // TODO: 初始化为适当的值
            object sender = null; // TODO: 初始化为适当的值
            EventArgs e = null; // TODO: 初始化为适当的值
            target.button_jiantixitong_Click(sender, e);
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///button_jiudehuiyi_Click 的测试
        ///</summary>
        [DeploymentItem("Prototype2.0.exe")]
        public void button_jiudehuiyi_ClickTest()
        {
            main_Accessor target = new main_Accessor(); // TODO: 初始化为适当的值
            object sender = null; // TODO: 初始化为适当的值
            EventArgs e = null; // TODO: 初始化为适当的值
            target.button_jiudehuiyi_Click(sender, e);
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///button_niurenduibi_Click 的测试
        ///</summary>
        [DeploymentItem("Prototype2.0.exe")]
        public void button_niurenduibi_ClickTest()
        {
            main_Accessor target = new main_Accessor(); // TODO: 初始化为适当的值
            object sender = null; // TODO: 初始化为适当的值
            EventArgs e = null; // TODO: 初始化为适当的值
            target.button_niurenduibi_Click(sender, e);
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///button_settings_Click 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Prototype2.0.exe")]
        public void button_settings_ClickTest()
        {
            main_Accessor target = new main_Accessor(); // TODO: 初始化为适当的值
            object sender = null; // TODO: 初始化为适当的值
            EventArgs e = null; // TODO: 初始化为适当的值
            target.button_settings_Click(sender, e);
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///button_wodeliangdian_Click 的测试
        ///</summary>
        [DeploymentItem("Prototype2.0.exe")]
        public void button_wodeliangdian_ClickTest()
        {
            main_Accessor target = new main_Accessor(); // TODO: 初始化为适当的值
            object sender = null; // TODO: 初始化为适当的值
            EventArgs e = null; // TODO: 初始化为适当的值
            target.button_wodeliangdian_Click(sender, e);
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///button_wodexinxi_Click 的测试
        ///</summary>
        [DeploymentItem("Prototype2.0.exe")]
        public void button_wodexinxi_ClickTest()
        {
            main_Accessor target = new main_Accessor(); // TODO: 初始化为适当的值
            object sender = null; // TODO: 初始化为适当的值
            EventArgs e = null; // TODO: 初始化为适当的值
            target.button_wodexinxi_Click(sender, e);
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///button_xuexiniuren_Click 的测试
        ///</summary>
        [DeploymentItem("Prototype2.0.exe")]
        public void button_xuexiniuren_ClickTest()
        {
            main_Accessor target = new main_Accessor(); // TODO: 初始化为适当的值
            object sender = null; // TODO: 初始化为适当的值
            EventArgs e = null; // TODO: 初始化为适当的值
            target.button_xuexiniuren_Click(sender, e);
           // Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///button_zhexiantuduibi_Click 的测试
        ///</summary>
        [DeploymentItem("Prototype2.0.exe")]
        public void button_zhexiantuduibi_ClickTest()
        {
            main_Accessor target = new main_Accessor(); // TODO: 初始化为适当的值
            object sender = null; // TODO: 初始化为适当的值
            EventArgs e = null; // TODO: 初始化为适当的值
            target.button_zhexiantuduibi_Click(sender, e);
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///button_zuotifenlei_Click 的测试
        ///</summary>
        [DeploymentItem("Prototype2.0.exe")]
        public void button_zuotifenlei_ClickTest()
        {
            main_Accessor target = new main_Accessor(); // TODO: 初始化为适当的值
            object sender = null; // TODO: 初始化为适当的值
            EventArgs e = null; // TODO: 初始化为适当的值
            target.button_zuotifenlei_Click(sender, e);
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///getCowMan 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Prototype2.0.exe")]
        public void getCowManTest()
        {
            main_Accessor target = new main_Accessor(); // TODO: 初始化为适当的值
            target.getCowMan();
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///getRecommand 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Prototype2.0.exe")]
        public void getRecommandTest()
        {
            main_Accessor target = new main_Accessor(); // TODO: 初始化为适当的值
            target.getRecommand();
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///getUser 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Prototype2.0.exe")]
        public void getUserTest()
        {
            main_Accessor target = new main_Accessor(); // TODO: 初始化为适当的值
            target.getUser();
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///main_Load 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Prototype2.0.exe")]
        public void main_LoadTest()
        {
            main_Accessor target = new main_Accessor(); // TODO: 初始化为适当的值
            object sender = null; // TODO: 初始化为适当的值
            EventArgs e = null; // TODO: 初始化为适当的值
            target.main_Load(sender, e);
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///main_MouseDown 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Prototype2.0.exe")]
        public void main_MouseDownTest()
        {
            main_Accessor target = new main_Accessor(); // TODO: 初始化为适当的值
            object sender = null; // TODO: 初始化为适当的值
            MouseEventArgs e = null; // TODO: 初始化为适当的值
            target.main_MouseDown(sender, e);
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///radioButton1_Click 的测试
        ///</summary>
        [DeploymentItem("Prototype2.0.exe")]
        public void radioButton1_ClickTest()
        {
            main_Accessor target = new main_Accessor(); // TODO: 初始化为适当的值
            object sender = null; // TODO: 初始化为适当的值
            EventArgs e = null; // TODO: 初始化为适当的值
            target.radioButton1_Click(sender, e);
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///radioButton2_MouseClick 的测试
        ///</summary>
        [DeploymentItem("Prototype2.0.exe")]
        public void radioButton2_MouseClickTest()
        {
            main_Accessor target = new main_Accessor(); // TODO: 初始化为适当的值
            object sender = null; // TODO: 初始化为适当的值
            MouseEventArgs e = null; // TODO: 初始化为适当的值
            target.radioButton2_MouseClick(sender, e);
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///radioButton4_Click 的测试
        ///</summary>
        [DeploymentItem("Prototype2.0.exe")]
        public void radioButton4_ClickTest()
        {
            main_Accessor target = new main_Accessor(); // TODO: 初始化为适当的值
            object sender = null; // TODO: 初始化为适当的值
            EventArgs e = null; // TODO: 初始化为适当的值
            target.radioButton4_Click(sender, e);
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///radioButton6_Click 的测试
        ///</summary>
        [DeploymentItem("Prototype2.0.exe")]
        public void radioButton6_ClickTest()
        {
            main_Accessor target = new main_Accessor(); // TODO: 初始化为适当的值
            object sender = null; // TODO: 初始化为适当的值
            EventArgs e = null; // TODO: 初始化为适当的值
            target.radioButton6_Click(sender, e);
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///textBox1_Click 的测试
        ///</summary>
        [DeploymentItem("Prototype2.0.exe")]
        public void textBox1_ClickTest()
        {
            main_Accessor target = new main_Accessor(); // TODO: 初始化为适当的值
            object sender = null; // TODO: 初始化为适当的值
            EventArgs e = null; // TODO: 初始化为适当的值
            target.textBox1_Click(sender, e);
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///textBox2_Click 的测试
        ///</summary>
        [DeploymentItem("Prototype2.0.exe")]
        public void textBox2_ClickTest()
        {
            main_Accessor target = new main_Accessor(); // TODO: 初始化为适当的值
            object sender = null; // TODO: 初始化为适当的值
            EventArgs e = null; // TODO: 初始化为适当的值
            target.textBox2_Click(sender, e);
           // Assert.Inconclusive("无法验证不返回值的方法。");
        }
    }
}
