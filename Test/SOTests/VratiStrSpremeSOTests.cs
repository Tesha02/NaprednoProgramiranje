using Common.Domain;
using DBBroker;
using Moq;
using Server.Core.SystemOperations;
using System;
using System.Collections.Generic;
using Xunit;

namespace Test.SOTests
{
	public class VratiStrSpremeSOTests
	{
		[Fact]
		public void ExecuteConcreteOperation_Should_Return_All_StrSpreme()
		{
			// Arrange
			var spremaList = new List<IEntity>
			{
				new StrSprema { Id = 1, Naziv = "Osnovna škola", Opis = "Završena osnovna škola" },
				new StrSprema { Id = 2, Naziv = "Srednja škola", Opis = "Završena srednja škola" },
				new StrSprema { Id = 3, Naziv = "Fakultet", Opis = "Završen fakultet" }
			};

			var mockBroker = new Mock<IBroker>();
			mockBroker.Setup(b => b.GetAll(It.IsAny<StrSprema>())).Returns(spremaList);

			var so = new VratiStrSpremeSO(mockBroker.Object);

			// Act
			so.ExecuteConcreteOperation();

			// Assert
			mockBroker.Verify(b => b.GetAll(It.IsAny<StrSprema>()), Times.Once);
			Assert.NotNull(so.Result);
			Assert.Equal(3, so.Result.Count);
			Assert.Equal("Fakultet", so.Result[2].Naziv);
		}

		[Fact]
		public void ExecuteConcreteOperation_Should_Return_EmptyList_When_No_StrSpreme()
		{
			// Arrange
			var mockBroker = new Mock<IBroker>();
			mockBroker.Setup(b => b.GetAll(It.IsAny<StrSprema>())).Returns(new List<IEntity>());

			var so = new VratiStrSpremeSO(mockBroker.Object);

			// Act
			so.ExecuteConcreteOperation();

			// Assert
			mockBroker.Verify(b => b.GetAll(It.IsAny<StrSprema>()), Times.Once);
			Assert.NotNull(so.Result);
			Assert.Empty(so.Result);
		}

		[Fact]
		public void ExecuteConcreteOperation_Should_Throw_Exception_When_Broker_Fails()
		{
			// Arrange
			var mockBroker = new Mock<IBroker>();
			mockBroker
				.Setup(b => b.GetAll(It.IsAny<StrSprema>()))
				.Throws(new Exception("Greška pri čitanju stručnih sprema iz baze."));

			var so = new VratiStrSpremeSO(mockBroker.Object);

			// Act & Assert
			var ex = Assert.Throws<Exception>(() => so.ExecuteConcreteOperation());
			Assert.Equal("Greška pri čitanju stručnih sprema iz baze.", ex.Message);
		}
	}
}
