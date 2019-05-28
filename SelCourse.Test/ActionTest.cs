using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SelCourse.Test
{
    [TestClass]
    public class ActionTest
    {
        /// <summary>
        /// 1.定义一个委托
        /// 2.编写一个与委托指定参数一直的函数，数据类型和参数个数都一样
        /// 3.定义一个委托的实例，并且传入一个函数名作为参数，MathD math = new MathD(Add);
        /// 4.执行委托函数，传入参数  int result = math(3,4);
        /// 5.判断返回结果与预期是否相等，Assert.AreEqual(result,7);
        /// 引入 action 和 func 
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public delegate int MathD(int p1, int p2);
        private int Add(int p1, int p2)
        {
            return p1 + p2;
        }
        private void AddTwo(int p1, int p2)
        {
            Console.WriteLine(p1+"--"+p2);
        }
        [TestMethod]
        public void ActionMethod()
        {
            MathD math = new MathD(Add);
            int result = math(3,4);
            Assert.AreEqual(result,7);
        }

        [TestMethod]
        public void ActionMethod2()
        {
            Func<int, int, int> math = Add;
            int result = math(3,4);
            Assert.AreEqual(result, 7);
        }

        [TestMethod]
        public void ActionMethod3()
        {
            Action<int, int> math = AddTwo;
            math(3, 4);
        }

        [TestMethod]
        public void ActionMethod4()
        {
            Action<int, int> math = delegate(int p1,int p2) {
                Console.WriteLine("this is a action test");
            };
            math(3, 4);
        }

        [TestMethod]
        public void ActionMethod5()
        {
            Action<int, int> math = (int p1, int p2) => {
                Console.WriteLine("this is a action test");
            };
            math(3, 4);
        }

        [TestMethod]
        public void ActionMethod6()
        {
            Func<int, int,int> math = (int p1, int p2) => {
                return p1 + p2;
            };
            int result = math(3, 4);
            Assert.AreEqual(7,result);
        }
    }
}
