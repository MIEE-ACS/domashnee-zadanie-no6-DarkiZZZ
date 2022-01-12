using System;
using System.Collections.Generic;

// Sokolov UTS-21 Variant 1(21)

namespace HomeWork6
{
    class Program
    {
        static void Main(string[] args)
        {
            var cubes = new List<Cube>() { };
            cubes.Add(new Cube(5.0));
            cubes.Add(new Cube(3.0));
            cubes.Add(new Cube(8.0));
            cubes.Add(new Cube(9.5));
            foreach (Cube c in cubes)
            {
                Console.WriteLine(c.ToString());
                c.GetSurfaceArea();
                c.GetVolume();
            }
            var spheres = new List<Sphere>() { };
            spheres.Add(new Sphere(2.0));
            spheres.Add(new Sphere(3.0));
            spheres.Add(new Sphere(4.0));
            spheres.Add(new Sphere(5.0));
            foreach (Sphere s in spheres)
            {
                Console.WriteLine(s.ToString());
                s.GetSurfaceArea();
                s.GetVolume();
            }
            var cones = new List<Cone>() { };
            cones.Add(new Cone(13.0, 5.0, 12.0));
            cones.Add(new Cone(10.0, 6.0, 8.0));
            cones.Add(new Cone(5.0, 4.0, 3.0));
            cones.Add(new Cone(25.0, 24.0, 7.0));
            foreach (Cone cn in cones)
            {
                Console.WriteLine(cn.ToString());
                cn.GetSurfaceArea();
                cn.GetVolume();
            }
        }

        //========================================================================
        // Общий класс Тело:
        public abstract class Body
        {
            private double squareResult;
            private double volumeResult;
            public virtual double GetSurfaceArea()
            {
                return squareResult;
            }

            public virtual double GetVolume()
            {
                return volumeResult;
            }
        }

        //========================================================================
        // Класс Куб:
        public class Cube : Body
        {
            private double length;
            private double squareResult;
            private double volumeResult;
            public Cube(double aLength)
            {
                if (aLength <= 0)
                {
                    Console.WriteLine("This cube doesnt exist!");
                }
                else
                {
                    length = aLength;
                }
            }

            public override double GetSurfaceArea()
            {
                squareResult = 6 * Math.Pow(length, 2);
                Console.WriteLine("Surface area of this cube: " + string.Format("{0:F1}", squareResult));
                return squareResult;
            }

            public override double GetVolume()
            {
                volumeResult = Math.Pow(length, 3);
                Console.WriteLine("Volume of this cube: " + string.Format("{0:F1}", volumeResult) + "\n");
                return volumeResult;
            }

            public override bool Equals(Object obj)
            {
                if ((obj == null) || !this.GetType().Equals(obj.GetType()))
                {
                    return false;
                }
                else
                {
                    Cube p = (Cube)obj;
                    return (length == p.length);
                }
            }

            public override string ToString()
            {
                return "Cube " + " - radius: " + length;
            }
        }

        //========================================================================
        // Класс Сфера:
        public class Sphere : Body
        {
            private double radius;
            private double squareResult;
            private double volumeResult;
            public Sphere(double aRadius)
            {
                if (aRadius <= 0)
                {
                    Console.WriteLine("This sphere doesnt exist!");
                }
                else
                {
                    radius = aRadius;
                }
            }

            public override double GetSurfaceArea()
            {
                squareResult = 4 * Math.PI * Math.Pow(radius, 2);
                Console.WriteLine("Surface area of this sphere: " + string.Format("{0:F1}", squareResult));
                return squareResult;
            }

            public override double GetVolume()
            {
                volumeResult = 4 * (Math.PI * Math.Pow(radius, 3)) / 4;
                Console.WriteLine("Volume of this sphere: " + string.Format("{0:F1}", volumeResult) + "\n");
                return volumeResult;
            }

            public override bool Equals(Object obj)
            {
                if ((obj == null) || !this.GetType().Equals(obj.GetType()))
                {
                    return false;
                }
                else
                {
                    Sphere p = (Sphere)obj;
                    return (radius == p.radius);
                }
            }

            public override string ToString()
            {
                return "Sphere " + " - radius: " + radius;
            }
        }

        //========================================================================
        // Класс Конус:
        public class Cone : Body
        {
            private double length;
            private double radius;
            private double height;
            private double squareResult;
            private double volumeResult;
            public Cone(double aLength, double aRadius, double aHeight)
            {
                if (aLength != Math.Sqrt(Math.Pow(aRadius, 2) + Math.Pow(aHeight, 2)) || aLength <= 0 || aRadius <= 0 || aHeight <= 0)
                {
                    Console.WriteLine("This cone doesnt exist!");
                }
                else
                {
                    length = aLength;
                    radius = aRadius;
                    height = aHeight;
                }
            }

            public override double GetSurfaceArea()
            {
                squareResult = Math.PI * radius * length + Math.PI * Math.Pow(radius, 2);
                Console.WriteLine("Surface area of this cone: " + string.Format("{0:F1}", squareResult));
                return squareResult;
            }

            public override double GetVolume()
            {
                volumeResult = (Math.PI * Math.Pow(radius, 2) * height) / 3;
                Console.WriteLine("Volume of this cone: " + string.Format("{0:F1}", volumeResult) + "\n");
                return volumeResult;
            }

            public override bool Equals(Object obj)
            {
                if ((obj == null) || !this.GetType().Equals(obj.GetType()))
                {
                    return false;
                }
                else
                {
                    Cone p = (Cone)obj;
                    return (length == p.length) && (radius == p.radius) && (height == p.height);
                }
            }

            public override string ToString()
            {
                return "Cone " + " - length: " + length +
                    ", radius: " + radius + ", height: " + height;
            }
        }

    }
}
