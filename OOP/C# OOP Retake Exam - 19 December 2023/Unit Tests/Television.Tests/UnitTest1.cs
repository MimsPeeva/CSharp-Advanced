namespace Television.Tests
{
    using System;
    using System.Diagnostics;
    using NUnit.Framework;
    public class Tests
    {
        private string brand = "TCL";
        private double price=250;
        private int screenWidth=43;
        private int screenHeigth=35;
        private TelevisionDevice device;
        [SetUp]
        public void Setup()
        {
            device = new TelevisionDevice(brand,price,screenWidth,screenHeigth);
        }

        [Test]
        public void Constructor_HappyPath()
        {
            Assert.IsNotNull(device);
          Assert.AreEqual(device.Brand, brand);
          Assert.AreEqual(device.Price,price);
          Assert.AreEqual( device.ScreenWidth, screenWidth);
          Assert.AreEqual( device.ScreenHeigth, screenHeigth);
            Assert.AreEqual(device.CurrentChannel,0);
            Assert.AreEqual(device.Volume,13);
            Assert.AreEqual(device.IsMuted,false);
        }

        [Test]
        public void SwitchOn_HappyPath()
        {
            string expected = $"Cahnnel 0 - Volume 13 - Sound On";
            string actual = device.SwitchOn();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void ToString_HappyPath()
        {
            Assert.AreEqual(device.ToString(), $"TV Device: {brand}, Screen Resolution: {screenWidth}x{screenHeigth}, Price {price}$");
        }
        [Test]
        public void ChangeChannel_HappyPath()
        {
            int expectedChannel = 5;
          int actual =  device.ChangeChannel(expectedChannel);
            Assert.AreEqual(expectedChannel,actual);
        }
        [Test]
        public void ChangeChannel_ThrowsEx()
        {
            int expectedChannel = -5;
           Exception ex = Assert.Throws<ArgumentException>(()=> device.ChangeChannel(expectedChannel));
           Assert.AreEqual(ex.Message, "Invalid key!");
        }
        [TestCase(7)]
        [TestCase( -7)]
        public void VolumeUP_HappyPath( int units)
        {
            string expected = "Volume: 20";
           string actual = device.VolumeChange("UP", units);
            Assert.AreEqual(expected,actual);
        }
        [Test]
        public void VolumeUP_higherThan100()
        {
            string expected = "Volume: 100";
            string actual = device.VolumeChange("UP", 120);
            Assert.AreEqual(expected, actual);
        }
        [TestCase(7)]
        [TestCase(-7)]
        public void VolumeDown_HappyPath(int units)
        {
            string expected = "Volume: 6";
            string actual = device.VolumeChange("DOWN", units);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void VolumeDown_lowerThan0()
        {
            string expected = "Volume: 0";
            string actual = device.VolumeChange("DOWN", 120);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void MuteDevice_HappyPath()
        {
            device.MuteDevice();
            Assert.AreEqual(device.IsMuted,true);
            device.MuteDevice();
            Assert.AreEqual(device.IsMuted, false);
        }
       
    }
}