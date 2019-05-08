using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tangram.GraphicsElements;

namespace UnitTests
{
    [TestClass]
    public class ColorTests
    {
        [TestMethod]
        public void ColorTest()
        {
            System.Drawing.Color color = System.Drawing.Color.FromArgb(255, 207, 56, 12);
            System.Drawing.Color newColor = ColorTools.ColorFromAhsb(255, color.GetHue(), color.GetSaturation(), color.GetBrightness());
            Assert.IsTrue(color.R == newColor.R && color.B == newColor.B && color.G == newColor.G && color.A == newColor.A);
        }
    }
}
