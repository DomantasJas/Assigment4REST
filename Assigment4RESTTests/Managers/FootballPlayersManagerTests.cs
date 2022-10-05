using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assigment4REST.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;
using Assigment4REST.Models;

namespace Assigment4REST.Managers.Tests
{
    [TestClass()]
    public class FootballPlayersManagerTests
    {
        internal FootballPlayer existingPlayer = new FootballPlayer() { Id = 2, Name = "Patrick Mahomes", Age = 29, ShirtNumber = 15 };
        internal FootballPlayersManager _pManager = new FootballPlayersManager();

        [TestMethod()]
        public void GetByIDTest()
        {
            FootballPlayer? wantedPlayer = _pManager.GetByID(2);
            Assert.AreEqual(existingPlayer.Name, wantedPlayer.Name);

        }
        [TestMethod()]
        public void AddTest()
        {
            FootballPlayer player = new FootballPlayer() { Id = 7, Name = "Terminator", Age = 24, ShirtNumber = 55 };
            List<FootballPlayer> list = _pManager.GetAll();
            _pManager.Add(player);
            Assert.AreEqual(7, list.Count);
        }
    }
}