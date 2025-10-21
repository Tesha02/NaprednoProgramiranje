using Common.Domain;
using DBBroker;
using Moq;
using Server.Core.SystemOperations;
using System;
using System.Collections.Generic;
using Xunit;

namespace Test.SOTests
{
	public class VratiMestaSOTests
	{
		[Fact]
		public void ExecuteConcreteOperation_Should_Return_All_Mesta()
		{
			// Arrange
			var mesta = new List<IEntity>
			{
				new Mesto { PostanskiBroj = "11000", Naziv = "Beograd" },
				new Mesto { PostanskiBroj = "21000", Naziv = "Novi Sad" }
			};

			var mockBroker = new Mock<IBroker>();
			mockBroker
				.Setup(b => b.GetAll(It.IsAny<Mesto>()))
				.Returns(mesta);

			var so = new VratiMestaSO(mockBroker.Object);

			// Act
			so.ExecuteConcreteOperation();

			// Assert
			mockBroker.Verify(b => b.GetAll(It.IsAny<Mesto>()), Times.Once);
			Assert.NotNull(so.Result);
			Assert.Equal(2, so.Result.Count);
			Assert.Equal("Beograd", so.Result[0].Naziv);
			Assert.Equal("Novi Sad", so.Result[1].Naziv);
		}

		[Fact]
		public void ExecuteConcreteOperation_Should_Return_EmptyList_When_No_Mesta()
		{
			// Arrange
			var mockBroker = new Mock<IBroker>();
			mockBroker
				.Setup(b => b.GetAll(It.IsAny<Mesto>()))
				.Returns(new List<IEntity>());

			var so = new VratiMestaSO(mockBroker.Object);

			// Act
			so.ExecuteConcreteOperation();

			// Assert
			mockBroker.Verify(b => b.GetAll(It.IsAny<Mesto>()), Times.Once);
			Assert.NotNull(so.Result);
			Assert.Empty(so.Result);
		}

		[Fact]
		public void ExecuteConcreteOperation_Should_Throw_Exception_When_Broker_Fails()
		{
			// Arrange
			var mockBroker = new Mock<IBroker>();
			mockBroker
				.Setup(b => b.GetAll(It.IsAny<Mesto>()))
				.Throws(new Exception("Greška pri čitanju mesta iz baze."));

			var so = new VratiMestaSO(mockBroker.Object);

			// Act & Assert
			var ex = Assert.Throws<Exception>(() => so.ExecuteConcreteOperation());
			Assert.Equal("Greška pri čitanju mesta iz baze.", ex.Message);
		}
	}
}
