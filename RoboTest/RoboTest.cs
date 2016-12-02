using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotController;
using Moq;
using Ninject.MockingKernel.Moq;
using System.ComponentModel.DataAnnotations;
using Ninject;

namespace RoboTest
{
    [TestClass]
    public class RoboTest
    {

        private readonly MoqMockingKernel _kernel;

        public RoboTest()
        {
            _kernel = new MoqMockingKernel();
            _kernel.Bind<IRobotMove<Robot>>().To<Robot>();
            _kernel.Bind<IRobotReact>().To<Robot>();
        }

        
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void gridCordinatesOutOfRange()
        {
           
            var _con = _kernel.Get<Controller>();
            _con.initializeGrid(7);
            Robot bot = _con.startRobot(7, 8, "llrrll");
            _con.moveRobot(bot);
          
            //auto assert handled by expectedException attribute
        }

       

    }
}
