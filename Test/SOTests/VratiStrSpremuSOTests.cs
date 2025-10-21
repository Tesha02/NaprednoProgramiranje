using Common.Domain;
using DBBroker;
using Moq;
using Server.Core.SystemOperations;
using System;
using System.Collections.Generic;
using Xunit;

namespace Test.SOTests
{
	public class VratiStrSpremuSOTests
	{
		[Fact]
		public void ExecuteConcreteOperation_Should_Return_StrSprema_When_Found()
		{
			// Arrange
			var input = new StrSprema { Id = 2 };

			var expected = new StrSprema
			{
				Id = 2,
				Naziv = "Master akademske studije",
				Opis = "Završen master nivo obrazovanja"
			};

			var mockBroker = new Mock<IBroker>();
			mockBroker
				.Setup(b => b.GetByCondition(It.IsAny<StrSprema>()))
				.Returns(new List<IEntity> { expected });

			var so = new VratiStrSpremuSO(input, mockBroker.Object);

			// Act
			so.ExecuteConcreteOperation();

			// Assert
			mockBroker.Verify(b => b.GetByCondition(input), Times.Once);
			Assert.NotNull(so.Result);
			Assert.Equal(expected.Naziv, so.Result.Naziv);
			Assert.Equal(expected.Opis, so.Result.Opis);
		}

		[Fact]
		public void ExecuteConcreteOperation_Should_Return_Null_When_Not_Found()
		{
			// Arrange
			var input = new StrSprema { Id = 99, Naziv = "Nepostojeća" };

			var mockBroker = new Mock<IBroker>();
			mockBroker
				.Setup(b => b.GetByCondition(It.IsAny<StrSprema>()))
				.Returns(new List<IEntity>()); // prazna lista

			var so = new VratiStrSpremuSO(input, mockBroker.Object);

			// Act
			so.ExecuteConcreteOperation();

			// Assert
			mockBroker.Verify(b => b.GetByCondition(input), Times.Once);
			Assert.Null(so.Result);
		}

		[Fact]
		public void ExecuteConcreteOperation_Should_Throw_Exception_When_Broker_Fails()
		{
			// Arrange
			var input = new StrSprema { Id = 1 };

			var mockBroker = new Mock<IBroker>();
			mockBroker
				.Setup(b => b.GetByCondition(It.IsAny<StrSprema>()))
				.Throws(new Exception("Greška pri čitanju iz baze."));

			var so = new VratiStrSpremuSO(input, mockBroker.Object);

			// Act & Assert
			var ex = Assert.Throws<Exception>(() => so.ExecuteConcreteOperation());
			Assert.Equal("Greška pri čitanju iz baze.", ex.Message);
		}
	}
}
