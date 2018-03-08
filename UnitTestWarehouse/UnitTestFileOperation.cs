using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Warehouse_lly;

namespace UnitTestWarehouse
{
    [TestClass]
    public class UnitTestFileOperation
    {
        public UnitTestFileOperation()
        {
           
        }

        [TestMethod]
        public void TestFileOperation()
        {
            List<string> lineList = new List<string>();
            List<string> lineList1 = new List<string>();
            FileOperation f = new FileOperation();
            lineList = f.ReadFile("Items.txt");
            Assert.IsNotNull(lineList,"OPen file is OK");
            lineList1 = f.ReadFile("item.txt");
            Assert.IsNull(lineList1, "No file found");
          
        }
    }
}
