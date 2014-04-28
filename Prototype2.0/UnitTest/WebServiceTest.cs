using Prototype2._0;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

namespace UnitTest
{
    
    
    /// <summary>
    ///这是 WebServiceTest 的测试类，旨在
    ///包含所有 WebServiceTest 单元测试
    ///</summary>
    [TestClass()]
    public class WebServiceTest
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
        ///GetWebContent 的测试
        ///</summary>
        [TestMethod()]
        public void GetWebContentTest()
        {
            WebService target = new WebService(); // TODO: 初始化为适当的值
            string Url = "about:blank"; // TODO: 初始化为适当的值
            Encoding encode = Encoding.GetEncoding("gb2312"); // TODO: 初始化为适当的值
            string expected = null; // TODO: 初始化为适当的值
            string actual;
            actual = target.GetWebContent(Url, encode);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///WebService 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void WebServiceConstructorTest()
        {
            WebService target = new WebService();
            //Assert.Inconclusive("TODO: 实现用来验证目标的代码");
        }

        /// <summary>
        ///GetAccepted 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcceptedTest()
        {
            WebService target = new WebService(); // TODO: 初始化为适当的值
            string name = "changchang"; // TODO: 初始化为适当的值
            ProgressBar progressBar = new ProgressBar(); // TODO: 初始化为适当的值
            List<Problem> expected = new List<Problem>(); // TODO: 初始化为适当的值
            List<Problem> actual;
            Problem problem = new Problem();
            problem.Id = 1003;
            problem.AcTime = Convert.ToDateTime("2012-10-26 00:34:36");
            expected.Add(problem);
            //progressBar.Value += 1;
            actual = target.GetAccepted(name, progressBar);
            Assert.AreEqual(expected[0].AcTime, actual[0].AcTime);
            Assert.AreEqual(expected[0].Id, actual[0].Id);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetUser 的测试
        ///</summary>
        [TestMethod()]
        public void GetUserTest()
        {
            ProgressBar progressBar = new ProgressBar(); // TODO: 初始化为适当的值
            WebService target = new WebService(); // TODO: 初始化为适当的值
            string name = "edisond"; // TODO: 初始化为适当的值
            User expected = new User(); // TODO: 初始化为适当的值
            expected.Name = name;
            User actual;
            String url = "http://acm.hdu.edu.cn/userstatus.php?user=" + name;
            Encoding encode = Encoding.GetEncoding("gb2312");
            String Page = target.GetWebContent(url, encode);
            expected.Accepted = System.Int32.Parse(Page.Substring(7567, 3));
            actual = target.GetUser(name, progressBar);
            Assert.AreEqual(expected.Accepted, actual.Accepted);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetUserNameByRank 的测试
        ///</summary>
        [TestMethod()]
        public void GetUserNameByRankTest()
        {
            WebService target = new WebService(); // TODO: 初始化为适当的值
            int rank = 1333; // TODO: 初始化为适当的值
            string expected = "liucs116"; // TODO: 初始化为适当的值
            string actual;
            actual = target.GetUserNameByRank(rank);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
