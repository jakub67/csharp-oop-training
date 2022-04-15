using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorf1 {
    class MyDate {
        private int day;
        private int month;
        private int year;
        public MyDate(int day, int month, int year) {                 //konstruktor          
                this.day = day;
                this.month = month;
                this.year = year;           
        }

        static string[] months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
        static string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        static int[] daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        public static bool isLeapYear(int year) {
            bool x = (((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0)) ? true : false;
            return x;
        }
        public static bool isValidDate(int year, int month, int day) {
            bool z = ((year >= 1) && (year < 9999)) && ((month >= 1) && (month <= 12)) && ((day >= 1) && (day <= daysInMonth[month]));
            return z;
        }
        public static int getDayOfWeek(int year, int month, int day) {
            DateTime dateValue = new DateTime(year, month, day);
            return(int)dateValue.DayOfWeek;
            //Console.WriteLine(dateValue.ToString("dddd"));
        }
        public void setDate(int year, int month, int day) {
            bool b = isValidDate(year, month, day);
            if (b) {
                this.year = year;
                this.month = month;
                this.day = day;
            }
        }
        public void setYear(int year) {
            if ((year >= 1) && (year < 9999)) {
                this.year = year;
            }
        }
        public void setMonth(int month) {
            if ((month >= 1) && (month <= 12)) {
                this.month = month;
            }
        }
        public void setDay(int day) {                 //parametr MyDate date a dalsi a vytvori instanci a potvrdit
            if ((day >= 1) && (day <=30)) {
                this.day = day;
            }
        }
        public string nextDay() {
            DateTime dateValue = new DateTime(year, month, day);
            DateTime x = dateValue.AddDays(1);
            this.day = x.Day;
            this.month = x.Month;
            this.year = x.Year;
            return x.ToString();            
        }
        public string previousDay() {
            DateTime dateValue = new DateTime(year, month, day);
            DateTime x = dateValue.AddDays(-1);
            this.day = x.Day;
            this.month = x.Month;
            this.year = x.Year;
            return x.ToString();
        }
        public int GetYear() { return year; }
        public int GetMonth() { return month; }
        public int GetDay() { return day; }
        public override string ToString() {
            int x=getDayOfWeek(year, month, day);
            return $"{days[x]} Day: {day} Month: {months[month - 1]} Year: {year}";
        }



    }
    class CviceniClass2Date {
            public static void Mainx() {
            MyDate d1 = new MyDate(28,2,2012);
            Console.WriteLine(d1);
            Console.WriteLine(d1.nextDay());
            Console.WriteLine(d1.nextDay());

            //MyDate d4 = new MyDate(32, 11, 2099);

            //Console.WriteLine(d1.previousDay());
        }
    }
    }

