using Teko.Math.Core.Vector;

Vector v1 = new Vector(3);
Vector v2 = new Vector(3);
Vector v3 = new Vector(3);
Vector v4 = new Vector(3);
v1.SetAll(1, 3, 10);
v2.SetAll(5, 3, 1);
v3 = v1.Add(v2);
Console.WriteLine(v3.ToString());
v4 = v3.Mul(-1);
Console.WriteLine(v4.ToString());

Console.ReadKey();