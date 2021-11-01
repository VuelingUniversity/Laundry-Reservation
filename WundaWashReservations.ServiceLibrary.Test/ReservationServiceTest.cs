using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using WundaWashReservations.Core.Enums;
using WundaWashReservations.Core.Services;
using WundaWashReservations.Email.ServiceLibrary.Interfaces;
using WundaWashReservations.ServiceLibrary.Interfaces;
using WundaWashReservations.ServiceLibrary.Services;

namespace WundaWashReservations.ServiceLibrary.Test
{
    [TestClass]
    public class ReservationServiceTest
    {
        private Mock<IReservationRepository> _reservationRepository;
        private Mock<IMachineApiRepository> _machineRepository;
        private Mock<IEmailService> _emailService;

        private IReservationService _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _emailService = new Mock<IEmailService>();
            _reservationRepository = new Mock<IReservationRepository>();
            _machineRepository = new Mock<IMachineApiRepository>();
            _sut = new ReservationService(_emailService.Object, _reservationRepository.Object, _machineRepository.Object);
        }

        // Faltan test de create y claim reservation

        [TestMethod]
        public void CancelReservation_Send_CancelledEmail()
        {
            // Arrange
            _reservationRepository.Setup(repo => repo.GetEmail("123abc")).Returns("hola@gmail.com");

            // Act
            _sut.CancelReservation("123abc");
            // Assert
            _reservationRepository.Verify(repo => repo.GetEmail("123abc"));
            _emailService.Verify(service => service.SendCancelReservationEmail("hola@gmail.com", "123abc"));
        }

        [Ignore]
        [TestMethod]
        public void CancelReservation_UpdateReservationStatus_And_UnlockMachine_Returning_True()
        {
            // Arrange
            _reservationRepository.Setup(repo => repo.GetEmail("123abc")).Returns("hola@gmail.com");
            _reservationRepository.Setup(repo => repo.GetMachineId("123abc")).Returns(1);

            // Act
            var response = _sut.CancelReservation("123abc");

            // Assert
            _reservationRepository.Verify(repo => repo.UpdateReservationStatus("123abc", StatusEnum.Cancelled));
            _reservationRepository.Verify(repo => repo.GetMachineId("123abc"));
            _machineRepository.Verify(repo => repo.UnlockMachine("123abc", 1));
            response.Should().BeTrue();
        }

        [Ignore]
        [TestMethod]
        public void CancelReservation_Returns_False_When_Something_Is_Wrong()
        {
            // Arrange
            _reservationRepository.Setup(repo => repo.GetEmail("123abc")).Returns("hola@gmail.com");

            // Act
            _sut.CancelReservation("123abc");
        }

        [TestMethod]
        public void RevertCreateReservation_Calls_UnlockMachine_If_RepositorySaveInDBResponse_Is_False()
        {
            // Act
            _sut.RevertCreateReservation(false, true, "123abc", 1);

            // Assert
            _machineRepository.Verify(repo => repo.UnlockMachine("123abc", 1));
        }

        [TestMethod]
        public void RevertCreateReservation_Calls_DeleteReservation_If_MachineLockReponse_Is_False()
        {
            // Act
            _sut.RevertCreateReservation(true, false, "123abc", 1);

            // Assert
            _reservationRepository.Verify(repo => repo.DeleteReservation("123abc"));
        }

        [TestMethod]
        public void RevertCreateReservation_Does_Not_Call_Any_Method_If_RepositorySaveInDBResponse_And__MachineLockReponse_Are_True()
        {
            // Act
            _sut.RevertCreateReservation(true, true, "123abc", 1);

            // Assert
            _machineRepository.Verify(repo => repo.UnlockMachine("123abc", 1), Times.Never);
            _reservationRepository.Verify(repo => repo.DeleteReservation("123abc"), Times.Never);
        }

        [TestMethod]
        public void DeleteReservation_Calls_ReservationRepository()
        {
            // Act
            _sut.DeleteReservation("srr123");
            // Assert
            _reservationRepository.Verify(repo => repo.DeleteReservation("srr123"));
        }

        [TestMethod]
        public void GenerateReservationId_Returns_Random_String()
        {
            // Act
            var reservationId = _sut.GenerateReservationId();
            var otherReservationId = _sut.GenerateReservationId();
            // Assert
            reservationId.Should().BeOfType<string>();
            reservationId.Should().NotBeSameAs(otherReservationId);
        }

        [TestMethod]
        public void ChooseWashMachine_Returns_Random_Machine_Between_1_to_25()
        {
            // Act
            var washMachine = _sut.ChooseWashMachine();
            var otherWashMachine = _sut.ChooseWashMachine();

            // Assert
            washMachine.Should().BeInRange(1, 25);
            otherWashMachine.Should().BeInRange(1, 25);
        }

        [TestMethod]
        public void GeneratePin_Returns_Random_Pin_with_5_Digits()
        {
            // Act
            var pin = _sut.GeneratePin();

            // Assert
            pin.Should().BeInRange(10000, 99999);
        }
    }
}