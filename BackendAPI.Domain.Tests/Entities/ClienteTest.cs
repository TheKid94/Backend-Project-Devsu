using BackendAPI.Domain.Entities;

namespace BackendAPI.Domain.Tests.Entities
{
    public class ClienteTests
    {
        [Fact]
        public void CambiarEstado_ClienteActivoCambiandoAInactivo_DeberiaCambiarEstado()
        {
            // Arrange
            var cliente = new Cliente { Estado = true };

            // Act
            var resultado = cliente.CambiarEstado(false);

            // Assert
            Assert.False(cliente.Estado);
        }

        [Fact]
        public void CambiarEstado_ClienteYaInactivo_NoDeberiaCambiarEstado()
        {
            // Arrange
            var cliente = new Cliente { Estado = false };

            // Act
            var ex = Assert.Throws<InvalidOperationException>(() => cliente.CambiarEstado(false));

            // Assert
            Assert.Equal("El estado ya es inactivo.", ex.Message);
        }
    }
}
