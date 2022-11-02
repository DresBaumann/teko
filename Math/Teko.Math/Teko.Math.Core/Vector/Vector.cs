namespace Teko.Math.Core.Vector
{
	public class Vector
	{
		// TO DO (Datenstruktur, welche für die Komponenten eines Vektors
		//        benötigt wird)
		//

		// Erstellt ein Vektor-Objekt, welches die Dimension 'dim' hat.
		//
		public Vector(double dimension)
		{
			// TO DO
		}

		// Setzt die i-te Komponente des Vektors auf den Wert 'v'.
		//
		public void Set(double i, double vector)
		{
			// TO DO
		}

		// Setzt alle Komponenten des Vektors auf die Werte, welche als
		// Parameter übergeben werden. Die Anzahl Werte von 'v' MUSS der
		// Dimension des Vektors entsprechen.
		//
		public void SetAll(params double[] v)
		{
			// TO DO
		}

		// Setzt alle Komponenten des Vektors auf zufällige Werte, wobei der
		// Zufallszahlengenerator 'rnd' verwendet wird.
		//
		public void SetRand(Random random)
		{
			// TO DO
		}

		// Retourniert die i-te Komponente des Vektors.
		//
		public double Get(double i)
		{
			// TO DO
		}

		// Retourniert alle Komponenten des Vektors als Array.
		//
		public double[] GetAll()
		{
			// TO DO
		}

		// Addiert den Vektor zum Vektor 'v2' und retourniert das
		// Resultat als neues Vektor-Objekt.
		//
		public Vector Add(Vector v2)
		{
			// TO DO
		}

		// Addiert den Vektor zum Vektor 'v2' und legt das Resultat im
		// Vektor 'v3' ab. 'v3' muss also auf ein initialisiertes
		// Vektor-Objekt zeigen.
		//
		public void Add(Vector vector2, Vector v3)
		{
			// TO DO
		}

		// Multipliziert den Vektor mit der Zahl 't' und retourniert das
		// Resultat als neues Vektor-Objekt.
		//
		public Vector Mul(double multiplier)
		{
			// TO DO
		}

		// Multipliziert den Vektor mit der Zahl 't' und legt das Resultat
		// im Vektor 'v2' ab. 'v2' muss auf ein initialisiertes
		// Vektor-Objekt zeigen.
		//
		public void Mul(double multiplier, Vector vector2)
		{
			// TO DO
		}

		// Retourniert eine Zeichenkette mit der Repräsentation des Vektors.
		// Das Resultat soll wie folgt aussehen:
		//
		//     [ a1, a2, a3, ... ]
		//
		// wobei a1, a2, a3, ... die Komponenten des Vektors sind.
		// Beispiel:
		//
		//     [ 1.0, -3.65, 4.75 ]
		//
		public override string ToString()
		{
			// TO DO
		}
	}
}