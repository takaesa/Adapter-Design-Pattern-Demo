using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public class SquareHole {
    private double sideLength;

    public SquareHole(double sideLength) {
        this.sideLength = sideLength;
    }

    public bool canFit(Square square) {
        return this.sideLength >= square.getSideLength();
    }
}

public class Square {
    private double sideLength;

    public Square() {}

    public Square(double sideLength) {
        this.sideLength = sideLength;
    }

    public virtual double getSideLength() {
        return this.sideLength;
    }
}

public class Circle {
    private double radius;

    public Circle(double radius) {
        this.radius = radius;
    }

    public double getRadius() {
        return this.radius;
    }
}

public class CircleToSquareAdapter : Square {
    private Circle circle;
    public CircleToSquareAdapter(Circle circle) {
        this.circle = circle;
    }

    public override double getSideLength() {
        return 2*this.circle.getRadius();
    }
}

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter side length for a square: ");
            double sideLength = Convert.ToDouble( Console.ReadLine());
            
            Console.Write("Enter circle radius: ");
            double circleRadius = Convert.ToDouble( Console.ReadLine());

            Square square = new Square();
            SquareHole squareHole = new SquareHole(sideLength);

            squareHole.canFit(square);

            Circle circle = new Circle(circleRadius);

            /*            bool check = squareHole.canFit(circle);
            */

            CircleToSquareAdapter circleAdapter = new CircleToSquareAdapter(circle);

            bool check = squareHole.canFit(circleAdapter);


            Console.WriteLine($"{check}");
        }
    }
}
