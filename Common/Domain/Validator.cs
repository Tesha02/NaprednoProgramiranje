using System;

/// <summary>
/// Klasa koja sadrži jednostavne provere za unos podataka.
/// Koristi se da se proveri da li su stringovi popunjeni i brojevi veći od nule.
/// </summary>
public static class Validator
{
	/// <summary>
	/// Proverava da li je string prazan ili null i baca grešku ako jeste.
	/// </summary>
	/// <param name="value">Vrednost stringa.</param>
	/// <param name="fieldName">Naziv polja koje se proverava.</param>
	public static void ValidateStrings(string value, string fieldName)
	{
		if (string.IsNullOrEmpty(value))
			throw new ArgumentException($"{fieldName} mora da ima vrednost");
	}

	/// <summary>
	/// Proverava da li je broj manji od nule i baca grešku ako jeste.
	/// </summary>
	/// <param name="value">Numerička vrednost.</param>
	/// <param name="fieldName">Naziv polja koje se proverava.</param>
	public static void ValidateNumbers(double value, string fieldName)
	{
		if (value < 0)
			throw new ArgumentException($"{fieldName} mora biti veći od 0");
	}
}
