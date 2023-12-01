using System;
using System.Collections.Generic;

namespace hafta2_odev
{
    internal class Vehicle
    {
        #region Fields
        private string type;
        private string brand;
        private string model;
        private int year;
        private DateTime date;
        private decimal price;
        private List<Person> owners = new List<Person>();
        private string chassisNumber;
        #endregion

        #region Contructors(ctor)
        public Vehicle()
        {
            
        }
        public Vehicle(string _type, string _brand, string _model, int _year, DateTime _date, decimal _price, string _chassisNumber)
        {
            type = _type;
            brand = _brand;
            model = _model;
            year = _year;
            date = _date;
            price = _price;
            chassisNumber = _chassisNumber;
        }
        public Vehicle(string _type, string _brand, string _model, int _year, DateTime _date, decimal _price, string _chassisNumber, Person _owner)
        {
            type = _type;
            brand = _brand;
            model = _model;
            year = _year;
            date = _date;
            price = _price;
            chassisNumber = _chassisNumber;
            AddOwner(_owner);
        }
        #endregion

        #region Encapsulations(prop)
        public string Type { get { return type; } set { type = value; } }
        public string Brand { get {  return brand; } set {  brand = value; } }
        public string Model { get { return model; } set { model = value; } }
        public int Year { get { return year; } set { year = value; } }
        public DateTime Date { get { return date; } set { date = value; } }
        public decimal Price { get { return price; } set { price = value; } }
        public string ChassisNumber { get {  return MaskedCN(chassisNumber); } set { chassisNumber = value; } }
        public List<Person> Owners { get { return owners; } set { owners = value; } }
        #endregion

        #region Methots
        private string MaskedCN(string _cn)
        {
            char[] maskedChars = _cn.ToCharArray();
            if (_cn != null && _cn.Length == 9 )
            {
                for ( int i = 0; i < maskedChars.Length; i++ )
                {
                    if (i != 3 && i != 8) // Sadece 3 ve 8.indekslerin maskesiz olmasını istiyorum.
                        maskedChars[i] = '*';
                }
            }
            else
                Console.WriteLine("Hatalı şasi numarası");
            string maskedStr = new string(maskedChars);
            return maskedStr;
        }
        public void AddOwner(Person _owner)
        {
            owners.Add(_owner);
        }
        public Person BeforeOwner()
        {
            if (owners.Count >= 2) // Eğer daha önce birden fazla sahibi olduysa işlem yapcak...
                return owners[owners.Count - 2]; // ...ve bize önceki sahibini return edecek.
            else 
                return null; // null değer döncek kullanıcıya çıktı verirken nullorempty kontrolü yapıp çıktı verceğiz.
        }
        #endregion
    }
}
