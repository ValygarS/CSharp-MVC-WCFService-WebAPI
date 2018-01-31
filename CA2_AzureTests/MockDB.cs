using CA2_Azure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2_AzureTests
{
    public class MockDB
    {
        private List<Tea> list;

        public MockDB()
        {
            list = new List<Tea>
            {
               new Tea {Id=1, Type="Green Tea", Name="Biluochun", Qty=5000, Price=5, Year="2017"},
               new Tea {Id=2, Type="Green Tea", Name="Longjing", Qty=10000, Price=7.5, Year="2017"},
               new Tea {Id=3, Type="Black Tea", Name="Jinjumei", Qty=3000, Price=8.5, Year="2016"},
               new Tea {Id=4, Type="White Tea", Name="Bai Mudan", Qty=1000, Price=8, Year="2016"},
               new Tea {Id=5, Type="Puerh", Name="Menghai 8582", Qty=5, Price=35, Year="2016"},
               new Tea {Id=6, Type="Puerh", Name="Menghai 7592", Qty=5, Price=30, Year="2015"},
               new Tea {Id=7, Type="Puerh", Name="Menghai 7742", Qty=3, Price=65.5, Year="2012"},
               new Tea {Id=8, Type="Puerh", Name="Haiwan LaoTongZhi", Qty=10, Price=28.9, Year="2017"},
               new Tea {Id=9, Type="Green Tea", Name="Maofen", Qty=4000, Price=9.5, Year="2017"}
            };
        }

        public Tea getTea(int id)
        {
            return list[id - 1];
        }

        public List<Tea> getAll()
        {
            return list;
        }
    }
}
