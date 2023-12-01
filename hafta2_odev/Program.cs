using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hafta2_odev
{
    internal class Program : Contents // Bu yapıya Inheritance denir.
                                      // Başka bir sınıfı bir sınıfa dahil etmek gibi olduğunu söyleyebilirim kısaca.
                                      // Kullanmak ile kullanmamak arasındaki fark şudur: Kullanmasaydım Contents.Menu(); şeklinde kullanmam gerekirdi.
                                      //                                                  Şimdi ise Menu(); yzabilirim. Contents kalıtıldığı için Menu() metodunu tanıdı [ benimsedi gibi oluyor :) ]
    {
        static void Main(string[] args)
        {
            /*
             * Contents.Menu(); Kalıtılmadan önce kullanım.
             * Menu(); // Kalıtıldıktan sonra kullanım.
             * c.Menu(); gibi bir kullanım da söz konusu olamaz.
             * Contents üzerinden bit nesne üretsek de Menu static bir metottur. Tıpkı WriteLine() gibi
             */

            List<Person> personList = new List<Person>(); // Veri tabanı gibi bütün verilerimizin tutulduğu generic list.

            #region Sistemin eski sahibi gösterebildiğine dair örnek
            Vehicle vehicle = new Vehicle();
            vehicle.Type = "oto";
            vehicle.Brand = "ornekMarka";
            vehicle.Model = "ornekModel";
            vehicle.ChassisNumber = "qwert1234";
            vehicle.Date = DateTime.Now;
            vehicle.Price = 1234567;
            vehicle.Year = 2023;

            Person person1 = new Person();
            person1.TCID = "12312312312";
            person1.Name = "isim1";
            person1.Surname = "soyisim1";
            person1.Birthyear = 1999;

            Person person2 = new Person();
            person2.TCID = "23423423423";
            person2.Name = "isim2";
            person2.Surname = "soyisim2";
            person2.Birthyear = 2000;
            person2.Vehicles.Add(vehicle);

            personList.Add(person1);
            personList.Add(person2);

            vehicle.Owners.Add(person1);
            vehicle.Owners.Add(person2);
            #endregion

            Operation(personList);
            // Operation metodu tüümüyle araç bilgi sistemini oluşturuyor.
        }
    }
}
