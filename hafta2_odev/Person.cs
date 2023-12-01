using System;
using System.Collections.Generic;

namespace hafta2_odev
{
    internal class Person
    {
        #region Fields
        // Sınıf içinde her türden değişkenler olarak tanımlanabilir.
        // Nesnenin saklanması gereken verileri taşırlar.
        string name;
        string surname;
        int birthyear;
        string TCid;
        List<Vehicle> vehicles = new List<Vehicle>();

        // Hepsi default olarka private olarak tutulur.
        #endregion

        #region Constructor(ctor)
        // Bu yapıya Contructor denir. Nesne örmeklerken(new) farkı artarnif seçenekler sunar.
        // Bu noktada görevi Person p = new Person(parameters); şeklinde de örnekleyebilelim...
        // ...ki bizi program içinde ya da metotlarda ekstra çaba gerektirmeden kşiyi ve Fieldlarını oluştursun.
        public Person()
        {
            
        }
        public Person(string _name, string _surname, int _birthyear, string _TCid)
        {
            this.name = _name;
            this.surname = _surname;
            this.birthyear = _birthyear;
            this.TCid = _TCid;
        }
        public Person(string _name, string _surname, int _birthyear, string _TCid, Vehicle _vehicle)
        {
            this.name = _name;
            this.surname = _surname;
            this.birthyear = _birthyear;
            this.TCid = _TCid;
        }
        #endregion

        #region Encapsulation(prop)
        // Bu yapıya Encapsulations denir. Bir nesnenin verierini saklamaya veya sınırlandırmaya yarar.
        // Bu noktada benim işime yarayan kısmı şu: her kişinin gizli özellikleri var ancak bunları kullanırken sıkıntı yaşarız.
        // Kullanmak istediğimizde de arka planı programlayan kişinin çizdiği sınırlar dışına çıkamayız. Bu güvenlik sağlar.
        // get veri sunar, set veri alır. Böylece nesnenin field'ları gizli ancak görülebilir ve değiştirilmez oluyor.
        public string Name { get { return name; } set {  name = value; } } // ya da { get =>  name; }
        public string Surname { get {  return surname; } set {  surname = value; } }
        public int Birthyear { get {  return birthyear; } set {  birthyear = value; } }
        public string TCID {  get { return TCid; } set {  TCid = value; } }
        public List<Vehicle> Vehicles { get {  return vehicles; } set { vehicles = value; } }
        #endregion

        #region Methots
        public void AddVehicle(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
        }
        #endregion
    }
}
