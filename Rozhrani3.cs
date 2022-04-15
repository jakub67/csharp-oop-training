

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Polymorf3 {
    interface SoundAble {
        string sound2();
        //string getName();                                                 //misto toho property
        public string Name { get; set; }
    }
    abstract class Animal {
        public string name;
        public static int countAnimal;
        public Animal() {
            countAnimal++;
        }
        public Animal(string name) {
            this.name = name;
            countAnimal++;
        }
        public static int GetCount() { return countAnimal; }                   
    }
    class Dog : Animal, SoundAble {
        bool isPedigree;
        public Dog(string name) : base(name) { }

        public string Name { get => name; set => name=value; }

        public string getName() { return name; }           
        public void sound() {Console.WriteLine("Hafa haf");}                    
        public string sound2() {return "HaaaaafHaaaaaaaaaf22";}                   
    }
    class Cat : Animal,SoundAble {
        bool isPedigree;
        public Cat(string name) : base(name) { }

        public string Name { get => name; set => name = value; }

        public string getName() { return name; }
        public void sound() {Console.WriteLine("Mnau mnau");}                  
        public string sound2() {return "Mnauuuuuuuuuu22";}                  
    }

    class Turtle : Animal {
        int speed;
        public Turtle(string name) : base(name) { }
    }

    class Car : SoundAble {
            int speed;
            public string name;

        public string Name { get => name; set => name = value; }

        public Car(string name) { this.name = name; }
        public string sound2() {return "Brmm Brmmmm";}                       
        public string getName() {return name;}                  
    }
    class Rozhrani1 {
        public static void Mainx() {

            SoundAble[] poleZvucnych = new SoundAble[3];
            poleZvucnych[0] = new Dog("Antony");
            poleZvucnych[1] = new Cat("Antonie");
            poleZvucnych[2] = new Car("Ford");
           
            //for(int i = 0; i < poleZvucnych.Length; i++) {
            //    Console.WriteLine(poleZvucnych[i].sound2());
            //    //Console.WriteLine(poleZvucnych[i] is Dog || poleZvucnych[i] is Cat ? ((Dog)poleZvucnych[i]).name : ((Cat)poleZvucnych[i]).name); 
            //    //Console.WriteLine(poleZvucnych[i] is Dog ? ((Dog)poleZvucnych[i]).name : null );
            //    //Console.WriteLine(poleZvucnych[i] is Cat ? ((Cat)poleZvucnych[i]).name : null);
            //    //Animal a = new Animal;                                                         //nelze u abstraktni tridy
            //    //Animal x = (Animal)poleZvucnych[i];
            //    //Console.WriteLine(x.name);
            //    //Console.WriteLine(((Animal)poleZvucnych[i]).name);
            //    Console.WriteLine( (poleZvucnych[i] as Animal)!=null ? ((Animal)poleZvucnych[i]).name: ((Car)poleZvucnych[i]).name);
            //}
            //foreach (SoundAble i in poleZvucnych) {
            //    Console.WriteLine(i.sound2());
            //    Console.WriteLine(i as Animal != null ? ((Animal)i).name : ((Car)i).name);

            //}
            foreach (SoundAble x in poleZvucnych) {
                //Console.WriteLine(x.getName() x.sound2());                                  // s getterem
                Console.WriteLine(x.Name+" "+x.sound2());
            }
            Dog d1 = new Dog("Mour");
            d1.Name = "Azure";
            Console.WriteLine(d1.name);
        }
    }
}


