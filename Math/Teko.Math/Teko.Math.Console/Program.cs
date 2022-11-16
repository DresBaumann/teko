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

Vector v6 = new Vector(5);
v6.SetAll(1, 1, 1, 1, 1);
Console.WriteLine(v6.Abs());


Console.ReadKey();
Console.Clear();


Vector v7 = new Vector(3);
Vector v8 = new Vector(3);
Vector v9 = new Vector(3);
v7.SetAll(new[] { 6.0, 8, 23 });
v8.SetAll(new[] { 678.0, 84, 24 });
v9 = v7.Cross(v8);
Console.WriteLine(v9.Dot(v7));
Console.WriteLine(v9.Dot(v8));


Vector a = new Vector(3);
a.SetAll(new[] { 1.0, 2, 1 });
Vector b = new Vector(3);
b.SetAll(new[] { 2, 4.0, 1 });

Console.WriteLine(a.Cross(b));
Console.ReadKey();