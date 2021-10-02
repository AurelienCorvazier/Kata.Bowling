using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Bowling.Test
{
    [TestClass]
    public class BowlingTest
    {
        [TestMethod]
        public void Initialisation()
        {
            new BowlingGame();
        }
        
        [TestMethod]
        [ExpectedException(typeof(Exception), "0 <= pins <= 10")]
        public void rolls_entre_0_et_9_A()
        {
            var game = new BowlingGame();
            game.Roll(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "0 <= pins <= 10")]
        public void rolls_entre_0_et_9_B()
        {
            var game = new BowlingGame();
            game.Roll(11);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(9)]
        public void one_frame(int pins)
        {
            var game = new BowlingGame();
            game.Roll(pins);
            Assert.AreEqual(pins, game.Frames.First().Score);
        }

        [TestMethod]
        public void one_spare()
        {
            var game = new BowlingGame();
            game.Spare();
            Assert.AreEqual(10, game.Frames.First().Score);
            Assert.AreEqual(10, game.Score());
        }

        [TestMethod]
        public void one_strike()
        {
            var game = new BowlingGame();
            game.Strike();
            Assert.AreEqual(10, game.Frames.First().Score);
            Assert.AreEqual(10, game.Score());
        }

        [TestMethod]
        public void spare_then_1_then_all_0()
        {
            var game = new BowlingGame();
            game.Spare();
            game.Roll(1);
            Assert.AreEqual(11, game.Frames.ElementAt(0).Score);
            Assert.AreEqual(1, game.Frames.ElementAt(1).Score);
        }

        [TestMethod]
        public void spare_then_8_then_all_1()
        {
            var game = new BowlingGame();
            game.Spare();
            game.Roll(8);
            game.Roll(1);
            Assert.AreEqual(18, game.Frames.ElementAt(0).Score);
            Assert.AreEqual(8, game.Frames.ElementAt(1).Score);
            Assert.AreEqual(1, game.Frames.ElementAt(2).Score);
        }

        [TestMethod]
        public void spare_then_strike()
        {
            var game = new BowlingGame();
            game.Spare();
            game.Strike();
            Assert.AreEqual(20, game.Frames.ElementAt(0).Score);
            Assert.AreEqual(10, game.Frames.ElementAt(1).Score);
        }

        [TestMethod]
        public void strike_then_8()
        {
            var game = new BowlingGame();
            game.Strike();
            game.Roll(8);
            Assert.AreEqual(18, game.Frames.ElementAt(0).Score);
        }

        [TestMethod]
        public void strike_then_8_then_1()
        {
            var game = new BowlingGame();
            game.Strike();
            game.Roll(8);
            game.Roll(1);
            Assert.AreEqual(19, game.Frames.ElementAt(0).Score);
            Assert.AreEqual(8, game.Frames.ElementAt(1).Score);
            Assert.AreEqual(1, game.Frames.ElementAt(2).Score);
        }

        [TestMethod]
        public void strike_strike_then_1()
        {
            var game = new BowlingGame();
            game.Strike();
            game.Strike();
            game.Strike();
            game.Roll(0);
            Assert.AreEqual(30, game.Frames.ElementAt(0).Score);
        }

        [TestMethod]
        public void all_pin_1()
        {
            var game = new BowlingGame();
            foreach (var frame in Enumerable.Range(0, 10))
                game.Roll(1);
            Assert.AreEqual(10, game.Score());
        }

        [TestMethod]
        public void all_strike()
        {
            var game = new BowlingGame();
            foreach(var frame in Enumerable.Range(0,10))
                game.Strike();
            game.Strike();
            Assert.AreEqual(300, game.Score());
        }
    }
} 
