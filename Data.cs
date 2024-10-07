using kyrovaya.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Class1
{
    internal class Data
    {
        public static Отгрузки? Отгрузки;
        public static Приемка? Приемка;
        public static Производители? Производители;
        public static Склад? Склад;
        public static Комплектующие? Комплектующие;
        public static ТипыКомплектующего? ТипыКомплектующего;
        public static bool Login = false;
        public static string UserSurname;
        public static string UserPatronymic;
        public static string Right;
    }
}
