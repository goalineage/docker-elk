using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using EasyNetQ;
using EasyNetQ.Topology;

namespace StringLibraryTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var connectionstring = $"host=localhost:5672;virtualHost=/;username=guest;Password=guest";
            var Queue = "mq_Queues"; // 對應的Query

            var data = new MyMqObject { 
                DT = DateTime.Now,
                Id = 15623,
                Name = "MyTest"
            };

            using (IBus bus = RabbitHutch.CreateBus(connectionstring))
            {
                bus.SendReceive.Send(Queue, data);
            }

        }
    }


    public class MyMqObject 
    {
        public DateTime DT { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
