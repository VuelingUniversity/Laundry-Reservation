using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using WundaWashMachine.Core.Services;
using WundaWashMachine.ServiceLibrary.Interfaces;
using WundaWashMachine.ServiceLibrary.Services;

namespace WundaWashMachine.ServiceLibrary.Test
{
    [TestClass]
    public class MachineServiceTest
    {
        private Mock<IMachineRepository> _machineRepository;

        private IMachineService _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _machineRepository = new Mock<IMachineRepository>();
            _sut = new MachineService(_machineRepository.Object);
        }

        [TestMethod]
        public void When_Machine_Is_Unlocked_LockMethod_SaveLock_And_Returns_True()
        {
            // Arrange
            _machineRepository.Setup(repo => repo.IsMachineUnlocked(It.IsAny<int>())).Returns(true);
            var dateTime = DateTime.Now;

            // Act
            var response = _sut.Lock(1, "234tyuio45", dateTime, 12345);

            // Assert
            _machineRepository.Verify(repo => repo.IsMachineUnlocked(It.IsAny<int>()));
            _machineRepository.Verify(repo => repo.SaveLock(1, "234tyuio45", dateTime, 12345));
            response.Should().BeTrue();
        }

        [TestMethod]
        public void When_ReservationId_Already_Exists_LockMethod_UpdateLockInfo_And_Returns_True()
        {
            // Arrange
            _machineRepository.Setup(repo => repo.ExistReservationId(It.IsAny<string>())).Returns(true);
            var dateTime = DateTime.Now;

            // Act
            var response = _sut.Lock(1, "23wqwd445", dateTime, 12345);

            // Assert
            _machineRepository.Verify(repo => repo.ExistReservationId(It.IsAny<string>()));
            _machineRepository.Verify(repo => repo.UpdateLockInfo("23wqwd445", dateTime, 12345));
            response.Should().BeTrue();
        }

        [TestMethod]
        public void When_Machine_Is_Already_Lock_And_Not_Exist_ReservationId_LockMethod_Returns_False()
        {
            // Arrange
            _machineRepository.Setup(repo => repo.IsMachineUnlocked(It.IsAny<int>())).Returns(false);
            _machineRepository.Setup(repo => repo.ExistReservationId(It.IsAny<string>())).Returns(false);

            // Act
            var response = _sut.Lock(1, "2344tf5", DateTime.Now, 12345);

            // Assert
            _machineRepository.Verify(repo => repo.IsMachineUnlocked(It.IsAny<int>()));
            _machineRepository.Verify(repo => repo.ExistReservationId(It.IsAny<string>()));
            _machineRepository.Verify(repo => repo.SaveLock(1, "2344tf5", DateTime.Now, 12345), Times.Never);
            response.Should().BeFalse();
        }

        [TestMethod]
        public void When_ReservationId_Exits_UnlockMethod_UnlockMachine_And_Returns_True()
        {
            // Arrange
            _machineRepository.Setup(repo => repo.ExistReservationId(It.IsAny<string>())).Returns(true);

            // Act
            var response = _sut.Unlock("23edfgtesf");

            // Assert
            _machineRepository.Verify(repo => repo.ExistReservationId(It.IsAny<string>()));
            _machineRepository.Verify(repo => repo.SaveUnlock("23edfgtesf"));
            response.Should().BeTrue();
        }

        [TestMethod]
        public void When_ReservationId_Not_Exit_UnlockMethod_Returns_False()
        {
            // Arrange
            _machineRepository.Setup(repo => repo.ExistReservationId(It.IsAny<string>())).Returns(false);

            // Act
            var response = _sut.Unlock("23edfgtesf");

            // Assert
            _machineRepository.Verify(repo => repo.ExistReservationId(It.IsAny<string>()));
            _machineRepository.Verify(repo => repo.SaveUnlock("23edfgtesf"), Times.Never);
            response.Should().BeFalse();
        }
    }
}