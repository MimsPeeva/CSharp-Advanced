using System.Collections.Generic;

namespace SmartDevice.Tests
{
    using NUnit.Framework;
    using System;
    using System.Text;

    public class Tests
    {
        private int memoryCapacity = 1000;
        private List<string> Applications;
        private Device device;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_HappyPath()
        {
            device = new Device(memoryCapacity);
            Assert.AreEqual(device.MemoryCapacity,memoryCapacity);
            Assert.AreEqual(device.AvailableMemory, memoryCapacity);
            Assert.AreEqual(device.Photos,0);
            Assert.AreEqual(device.Applications.Count,0);
        }
        [Test]
        public void TakePhoto_HappyPath()
        {
            device = new Device(memoryCapacity);
            int photoSize = 100;
            bool photoTaken = device.TakePhoto(photoSize);
           Assert.IsTrue(photoTaken);
            Assert.AreEqual(memoryCapacity - photoSize, device.AvailableMemory);
            Assert.AreEqual(device.Photos,1);

        }
        [Test]
        public void TakePhoto_ReturnFalse()
        {
            device = new Device(memoryCapacity);
            int photoSize = 1500;
            bool photoTaken = device.TakePhoto(photoSize);
            Assert.IsFalse(photoTaken);
            Assert.AreEqual(device.AvailableMemory, memoryCapacity);
            Assert.AreEqual(device.Photos, 0);

        }

        [Test]
        public void InstallApp_HappyPath()
        {
            device = new Device(memoryCapacity);

             string appName = "PPP";
             int appSize = 200;
            string result = device.InstallApp(appName, appSize);
             Assert.AreEqual($"{appName} is installed successfully. Run application?",result);
            Assert.AreEqual(memoryCapacity - appSize, device.AvailableMemory);
            Assert.AreEqual(1, device.Applications.Count);
            Assert.IsTrue(device.Applications.Contains(appName));
        }
        [Test]
        public void InstallApp_ThrowEx()
        {
            device = new Device(memoryCapacity);

            string appName = "SSS";
            int appSize = 2000;
            Assert.AreEqual(memoryCapacity, device.AvailableMemory);
            Assert.AreEqual(0, device.Applications.Count);
            Assert.Throws<InvalidOperationException>(() => device.InstallApp(appName, appSize));
        }

        [Test]
        public void FormatDevice_HappyPath()
        {
            device = new Device(memoryCapacity);
            device.TakePhoto(200);
            device.InstallApp("FirstApp", 340);
            device.FormatDevice();
            Assert.AreEqual(0, device.Photos);
            Assert.AreEqual(device.Applications.Count, 0);
            Assert.AreEqual(device.AvailableMemory, memoryCapacity);
        }
      

        [Test]
        public void GetDeviceStatus_HappyPath()
        {
            device = new Device(memoryCapacity);
            int photoSize = 100;
            device.TakePhoto(photoSize);
            device.InstallApp("FirstApp", 200);
            device.InstallApp("SecondApp", 300);
            string status = device.GetDeviceStatus();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Memory Capacity: {memoryCapacity} MB, Available Memory: {memoryCapacity - photoSize - 200 - 300} MB");
            sb.AppendLine($"Photos Count: {1}");
            sb.AppendLine($"Applications Installed: {string.Join(", ", "FirstApp", "SecondApp")}");
            string result = sb.ToString().Trim();
            Assert.AreEqual(status, result);
        }
        
    }
}