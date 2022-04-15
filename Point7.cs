using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point7 {
    interface Iobvodove {
        double perimetr();
    }
    class Person : Iobvodove{
        double r;
        public Person(double r) {
            this.r = r;
        }
        public double perimetr() {
            return(Math.PI * r * 2);
        }
    }
    class Cylinder {
        Circle bottom;
        double height;

        public Cylinder(Circle bottom, double height) {
            this.bottom = bottom;
            this.height = height;
        }
        public double surface() {
            return bottom.perimetr() * height;
        }
        public double volume() {
            return bottom.perimetr() * height*2;
        }
        public override string ToString() {
            return $"Souradnice {bottom.GetCenter()} vyska {height}"; 
        }
    }
    class Point {
        private double x;
        private double y;
        public Point(double x, double y) {
            this.X = x;
            this.Y = y;
        }

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }

        public override string ToString() {
            return @$"Hodnota x a y: {X.ToString("F2")} ; {Y.ToString("F2")}";         //@ aby to vypisovalo i klicove znaky normalne
            //return @$"Hodnota x a y: {Math.Round(x,2)} ; {Math.Round(y,2)}";
        }
    }
    abstract class Shape : Iobvodove{
        private Point center;                                         //predtim byl public

        public Shape() { }

        public Point GetCenter() { return center; }
        public void SetCenter(Point center) { this.center = center; }
        public Shape(double x, double y) {              //:this(new Point(x, y)) {
            this.center = new Point(x, y);
        }
        public Shape(Point center) {            //:this(center.X,center.Y) {
            this.center = center;
        }
        public virtual void writeInfo() {
            Console.Write($"Souradnice: {center.X} : {center.Y} ");
        }
        public abstract double perimetr();
        public abstract void area();
    }
    class Circle : Shape, Iobvodove {
        public double r;
        public Circle(double r) : this(new Point(0, 0), r) {
            if (r < 0) throw new ArgumentOutOfRangeException("Polomer musi byt kladne cislo");
        }
        public Circle(Point center, double r) : base(center) {
            this.r = r;
        }

        public Circle(double x, double y, double r) : base(x, y) {
            if (r < 0) throw new ArgumentOutOfRangeException("Polomer musi byt kladne cislo");
            this.r = r;
        }
        public override double perimetr() {
            return(Math.PI * r * 2);
        }
        public override void area() {
            Console.WriteLine((Math.PI * r * r).ToString("F2"));
        }
        public override string ToString() {
            return $"Polomer je {r} souradnice: {GetCenter()}";
        }
        public override void writeInfo() {
            base.writeInfo();
            Console.WriteLine($"Typ {this.GetType().Name} Polomer {r}");
            perimetr();
        }
    }
    class Rectangle : Shape,Iobvodove {
        public double b;
        public double a;


        public Rectangle(double a, double b) : this(0, 0, a) {
            this.b = b;
        }
        public Rectangle(double a) : this(0, 0, a) {
            this.b = a;
        }
        public Rectangle(double x, double y, double a) : base(x, y) {
            this.a = a;
            this.b = a;
        }
        public Rectangle(Point center, double a, double b) {
            SetCenter(center);
            this.a = a;
            this.b = b;
        }
        public Rectangle(double x, double y, double a, double b) : base(x, y) {
            this.a = a;
            this.b = b;
        }
        public override double perimetr() {
            return(2 * (a + b));
        }
        public override void area() {
            Console.WriteLine(a * b);
        }
        public override string ToString() {
            return $"Strana a: {a} strana b: {b} souradnice: {GetCenter()}";
        }
        public override void writeInfo() {
            base.writeInfo();
            string s = a == b ? "Ctverec" : "Obdelnik";
            Console.WriteLine($" Typ {this.GetType().Name} Strany {a} : {b} je {s}");
            perimetr();
        }
    }


    class Point7 {
        public static void Mainx() {
            
            Circle c1 = new Circle(4);
            Rectangle r1 = new Rectangle(3);
            Circle c2 = new Circle(4, 5, 6);
            Rectangle r2 = new Rectangle(3, 4, 5, 6);
            Rectangle r3 = new Rectangle(4, 5);
            Rectangle r4 = new Rectangle(4, 5, 3);
            Person p1 = new Person(5);
            Person p2 = new Person(7);

            double sum = 0;
            List<Iobvodove> listTvar = new List<Iobvodove>() { c1, c2, r1, r2, p1, p2 };
            foreach (var i in listTvar) {
                Console.WriteLine(i.perimetr());
                sum += i.perimetr();
            }
            Console.WriteLine($"Suma je: {sum}");

            Cylinder y1 = new Cylinder(c1, 10);
            Console.WriteLine(y1);
            Console.WriteLine(y1.surface());
            Console.WriteLine(y1.volume());




                        
        }
    }
}





