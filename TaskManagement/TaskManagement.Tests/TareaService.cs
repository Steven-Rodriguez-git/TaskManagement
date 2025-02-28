using System;
using System.Threading.Tasks;
using Moq;
using Xunit;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Application.Services;

namespace TaskManagement.Tests
{
    public class TareaServiceTests
    {
        private readonly Mock<ITareaRepository> _mockRepo;
        private readonly TareaService _service;

        public TareaServiceTests()
        {
            _mockRepo = new Mock<ITareaRepository>();
            _service = new TareaService(_mockRepo.Object);
        }

        [Fact]
        public async Task CrearTareaAsync_ValidTask_CallsAgregarTareaAsync()
        {
            // Arrange
            var tarea = new Tarea
            {
                Titulo = "Tarea de prueba",
                FechaVencimiento = DateTime.Now.AddDays(1),
                Codigo = "ABC123",
                Estado = Estado.Pendiente
            };

            _mockRepo.Setup(repo => repo.CodigoExisteAsync(tarea.Codigo))
                     .ReturnsAsync(false);

            _mockRepo.Setup(repo => repo.AgregarTareaAsync(tarea))
                     .Returns(Task.CompletedTask);

            // Act
            await _service.CrearTareaAsync(tarea);

            // Assert
            _mockRepo.Verify(repo => repo.AgregarTareaAsync(tarea), Times.Once);
        }

        [Fact]
        public async Task CrearTareaAsync_EmptyTitulo_ThrowsException()
        {
            // Arrange
            var tarea = new Tarea
            {
                Titulo = "",
                FechaVencimiento = DateTime.Now.AddDays(1),
                Codigo = "DEF456",
                Estado = Estado.Pendiente
            };

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _service.CrearTareaAsync(tarea));
        }
    }
}
