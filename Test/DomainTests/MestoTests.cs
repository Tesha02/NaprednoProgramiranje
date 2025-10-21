using Xunit;
using Common.Domain;

namespace Test.DomainTests
{
    /// <summary>
    /// Testovi za domensku klasu Mesto.
    /// </summary>
    public class MestoTests
    {
        [Theory]
        [InlineData("11000", "Beograd")]
        [InlineData("21000", "Novi Sad")]
        [InlineData("18000", "Niš")]
        public void ToString_TrebaDaVratiNazivMesta(string postanskiBroj, string naziv)
        {
            // Arrange
            var mesto = new Mesto { PostanskiBroj = postanskiBroj, Naziv = naziv };

            // Act
            string rezultat = mesto.ToString();

            // Assert
            Assert.Equal(naziv, rezultat);
        }

        [Theory]
        [InlineData("11000", "Beograd", "'11000', 'Beograd'")]
        [InlineData("31000", "Uzice", "'31000', 'Uzice'")]
        public void Values_TrebaDaVratiIspravanSQLString(string postanskiBroj, string naziv, string ocekivano)
        {
            var mesto = new Mesto { PostanskiBroj = postanskiBroj, Naziv = naziv };
            Assert.Equal(ocekivano, mesto.Values);
        }

        [Theory]
        [InlineData("11000")]
        [InlineData("21000")]
        public void WhereCondition_TrebaDaVratiIspravanPostanskiBroj(string postanskiBroj)
        {
            var mesto = new Mesto { PostanskiBroj = postanskiBroj };
            Assert.Equal($"PostanskiBroj = '{postanskiBroj}'", mesto.WhereCondition);
        }

        [Fact]
        public void TableName_TrebaDaBudeMesto()
        {
            var mesto = new Mesto();
            Assert.Equal("Mesto", mesto.TableName);
        }

        [Fact]
        public void TableAlias_TrebaDaBudeM()
        {
            var mesto = new Mesto();
            Assert.Equal("m", mesto.TableAlias);
        }

        [Fact]
        public void OutputId_TrebaDaBudePostanskiBroj()
        {
            var mesto = new Mesto();
            Assert.Equal("PostanskiBroj", mesto.outputId);
        }

        [Fact]
        public void UpdateValues_TrebaDaBudePrazanString()
        {
            var mesto = new Mesto();
            Assert.Equal(string.Empty, mesto.UpdateValues);
        }

        [Fact]
        public void GetCondition_TrebaDaBudePrazanString()
        {
            var mesto = new Mesto();
            Assert.Equal(string.Empty, mesto.GetCondition);
        }
    }
}
