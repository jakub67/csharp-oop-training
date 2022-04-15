using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Soubory4 {
    class Soubory4 {
        public static void Mainx() {
            //string cesta = "C:\\Users\\Jakub\\Desktop\\DOCASNE\\dnyhodinybyty.dat";    //POZOR KONCOVKA .DAT!!!!!

            //FileStream fs = new FileStream(cesta, FileMode.CreateNew);    // CreateNew vytvori novy soubor, predtim neexistuje
            //FileInfo fi = new FileInfo(cesta);
            //if (!fi.Exists) { Console.WriteLine("Soubor neexistuje"); }
            //if (!fi.Directory.Exists) { Console.WriteLine("Cesta neexistuje"); }

            //byte[] poleProZapis = { 3, 12, 4, 19 };
            //foreach (var i in poleProZapis) {
            //    fs.WriteByte(i);                              //musi WriteByte ne Write
            //}
            ////fs.Write(poleProZapis, 0, poleProZapis.Length - 1);      //druha moznost
            //fs.Seek(0, SeekOrigin.Begin);
            //int cislo = 0,x=0;
            //do {
            //    cislo = fs.ReadByte();
            //    if (cislo != -1 && x % 2 == 0) { Console.WriteLine(cislo*24); }  //JINAK NUTNOST PRETYPOVAT NA BYTE!!! TREBA DO POLE
            //    if (cislo != -1 && x % 2 != 0) { Console.WriteLine(cislo); }
            //    x++;
            //} while (cislo!=-1);
            

            string cesta2= "C:\\Users\\Jakub\\Desktop\\DOCASNE\\dnyhodinyINTbin2.dat";
            FileInfo fi2 = new FileInfo(cesta2);
            if (fi2.Exists) {
                FileStream fs2 = new FileStream(cesta2, FileMode.Create);     //Create pouze novy obsah, soubor uz existuje
                BinaryReader br = new BinaryReader(fs2);
                BinaryWriter bw = new BinaryWriter(fs2);

                int[] poleInt = { 3, 12, 4, 19 };
                //bw.Write(poleInt, 0, poleInt.Length - 1);                // U BW TOTO ASI NELZE
                foreach (var i in poleInt) {
                    bw.Write(i);
                }
                fs2.Seek(0, SeekOrigin.Begin);
                int cislo2 = 0, y = 0;
                do {
                    cislo2 = br.ReadInt32();
                    if(y%2==0) { Console.WriteLine(cislo2 * 24); }
                    if(y%2!=0) { Console.WriteLine(cislo2); }
                    y++;
                } while (y<poleInt.Length);
            }
            else { Console.WriteLine("Soubor neexistuje, prvne vytvorte!"); }





            //int[] hodiny = new int[10];
            //int i = 0, sum = 0;
            //string s = "";
            //try {
            //    StreamReader sr = new StreamReader(cesta);
            //    StreamWriter vystup = new StreamWriter("C:\\Users\\Jakub\\Desktop\\DOCASNE\\novehodiny.txt", false);
            //    while (!sr.EndOfStream) {
            //        if (i % 2 == 0) { hodiny[i] = int.Parse(sr.ReadLine()) * 24; }
            //        else { hodiny[i] = (int.Parse(sr.ReadLine())); }
            //        vystup.WriteLine(hodiny[i]);
            //        sum += hodiny[i];
            //        i++;                                       //POZOR NA HODINY[I++] A NASLEDNY ZAPIS PISE POUZE NULY!!!!
            //    }
            //    vystup.WriteLine($"Celkovy pocet hodin: {sum}");
            //    s = sr.ReadToEnd();
            //    vystup.Close();
            //    Console.WriteLine(s);
            //    Console.WriteLine(sum);
            //}
            //catch (FormatException e) { Console.WriteLine(e.Message); }
            //catch (FileNotFoundException e) { Console.WriteLine(e.Message); }
            //catch (EndOfStreamException e) { Console.WriteLine(e.Message); }
            //catch (ArgumentException e) { Console.WriteLine(e.Message); }
            //catch (Exception e) { Console.WriteLine(e.Message); }




        }
    }
}

