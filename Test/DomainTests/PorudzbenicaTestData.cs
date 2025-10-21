using System;
using System.Collections;
using System.Collections.Generic;
using Common.Domain;

namespace Test.DomainTests
{
	public class PorudzbenicaTestData : IEnumerable<object[]>
	{
		public IEnumerator<object[]> GetEnumerator()
		{
			yield return new object[]
			{
				new Porudzbenica
				{
					Id = 1,
					DatumOd = new DateOnly(2025, 1, 1),
					DatumDo = new DateOnly(2025, 1, 5),
					UkupnaVr = 2500.50f,
					Radnik = new Radnik { Id = 10 },
					Kupac = new Kupac { Id = 20 }
				},
				"'2025-01-01', '2025-01-05', '2500.5', '10', '20'"
			};

			yield return new object[]
			{
				new Porudzbenica
				{
					Id = 2,
					DatumOd = new DateOnly(2025, 2, 10),
					DatumDo = new DateOnly(2025, 2, 12),
					UkupnaVr = 999.99f,
					Radnik = new Radnik { Id = 3 },
					Kupac = new Kupac { Id = 7 }
				},
				"'2025-02-10', '2025-02-12', '999.99', '3', '7'"
			};
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
