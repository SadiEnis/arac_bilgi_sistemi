using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace hafta2_odev
{
    internal class Contents // Bütün işlemler sınıflarda olması gerektiği için tanımlandı.
    {
        // Static yapısı nesneler arası kullanılabilir kılar.
        // Projedeki amacı nedir? Aslında olmasa da proje çalışabilir hale getirilebilir.
        // Static kullandım böylece Program sınıfında nesne örneklemeden kullanmayı tercih ettim.
        public static void Menu()
        {
            Console.WriteLine("Araç Bilgi Sistemi");
            Console.WriteLine("Menü");
            Console.WriteLine("Yeni kişi eklemek için: P");
            Console.WriteLine("Yeni araç eklemek için: V");
            Console.WriteLine("Var olan aracınızı(larınızı) görüntülemek için: S");
            Console.WriteLine("Menü için: M");
            Console.WriteLine("Çıkmak için işlemler dışında bir tuşa basın.");
            Console.WriteLine();
        }
        public static void Operation(List<Person> list)
        {
            // Operation metodu menü üzerinde işlem yappabilmemizi ve
            // bu işleme göre yönlendirmeler yapan metot.

            Console.Clear();
            Menu();
            string chs;
            Console.Write("Yapmak istediğiniz işlem: ");
            chs = Console.ReadLine();
            if (chs.ToUpper() == "P")
                CreatePerson(list); // Kullanıcı girdisi olarak P girildiğinde kişi ekler.
            else if (chs.ToUpper() == "V")
                CreateVehicle(list); // V girildiğinde araç ekler.
            else if (chs.ToUpper() == "S")
                ShowVehicles(list); // S girildiğinde araçarı gösterir.
            else if (chs.ToUpper() == "M")
                Operation(list);
            else
                Console.ReadKey();
        }
        private static void CreatePerson(List<Person> listPeople)
        {
            Console.Clear();
            Person personNew = new Person();
            Console.Write("Adı: ");
            personNew.Name = Console.ReadLine();
            Console.Write("Soyadı: ");
            personNew.Surname = Console.ReadLine();
            Console.Write("Doğum yılı: ");
            personNew.Birthyear = Convert.ToInt32(Console.ReadLine());
            Console.Write("TC kimlik numrası: ");
            personNew.TCID = Console.ReadLine();

            Console.WriteLine("Kaydediliyor...");
            listPeople.Add(personNew);
            System.Threading.Thread.Sleep(1500);
            Console.Write("Kaydedildi. Bir tuşa basın.");
            Console.ReadKey();
            Operation(listPeople);
        }
        private static void CreateVehicle(List<Person> listPeople)
        {
            Console.Clear();
            tc:
            Console.Write("Aracın eklenecği kişinin kimlik numarası: ");
            string tc = Console.ReadLine();
            if (tc.Length != 11)
                goto tc;
            int indx = -1;
            for (int i = 0; i < listPeople.Count; i++)
            {
                if (IndexQuary(listPeople[i], tc))
                    indx = i; // Eğer tc uyuşuyorsa biriyle o kişinin araçlarına bakmalıyız.
            }
            if (indx == -1)
            {
                Console.WriteLine("Sistemde bu kişi bulunmamaktadır.");
                goto tc;
            }

            Vehicle vehicleNew = new Vehicle();
            Console.Write("Türü: ");
            vehicleNew.Type = Console.ReadLine();
            Console.Write("Markası: ");
            vehicleNew.Brand = Console.ReadLine();
            Console.Write("Modeli: ");
            vehicleNew.Model = Console.ReadLine();
            Console.Write("Yılı: ");
            vehicleNew.Year = Convert.ToInt32(Console.ReadLine());
            Console.Write("Edinme tarihi: ");
            vehicleNew.Date = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Edinme fiyatı: ");
            vehicleNew.Price = Convert.ToDecimal(Console.ReadLine());
            sasi:
            Console.Write("Aracın 9 haneli şasi numrası: ");
            vehicleNew.ChassisNumber = Console.ReadLine();
            if (vehicleNew.ChassisNumber.Length != 9) // Bu karşılaştırma yapılırken sadece uzunluğuna bakılır.
                                                      // Ne kullanıcı ne de developer araç şasi numarasını görebilir. Maskelidir.
                goto sasi;

            Console.WriteLine("Kaydediliyor...");
            vehicleNew.Owners.Add(listPeople[indx]);   // Aracı kişiye kişiye de aracı eklemek gerek.
            listPeople[indx].Vehicles.Add(vehicleNew); // indx tc'sine göre uygun kişi olduğu için o kişinin araçları ekleme yapabilir.
            System.Threading.Thread.Sleep(1500);
            Console.Write("Kaydedildi. Bir tuşa basın.");
            Console.ReadKey();
            Operation(listPeople); // Her işlemden sonra menğye geri döner.
        }
        private static void ShowVehicles(List<Person> peopleList)
        {
            Console.Clear();
            tc:
            Console.Write("Çıkmak için M / Aracın(ların) sahibinin TC kimlik numrası: ");
            string tc = Console.ReadLine();
            if (tc.ToUpper() == "M")
                Operation(peopleList);
            else
            {
                if (tc.Length != 11)
                    goto tc;
                int indx = -1; // -1 çünkü satır 134
                for (int i = 0; i < peopleList.Count; i++)
                {
                    if (IndexQuary(peopleList[i], tc))
                        indx = i; // Eğer tc uyuyorsa biriyle o kişinin  araçlarına bakmalıyız.
                }
                if (indx == -1) // Eğer indx 0 olursa listede bir şeye karşılık gelebilir anack -1 asla bir karşılığı bulunmaz.
                                // Karşılığı yoksa kişi de yoktur tc yanlış girilmiştir.
                {
                    Console.WriteLine("Sistemde bu kişi bulunmamaktadır.");
                    goto tc; // tc yanlış girildiği için yeniden tc isterim bunun için de goto yönlendiricisini kullanırım.
                }
                Console.WriteLine("Kontrol ediliyor...");
                System.Threading.Thread.Sleep(1500); // Bu thread'lar tamamen estetik amaçlı

                Console.WriteLine("Bulundu.");
                foreach (Vehicle _vehicle in peopleList[indx].Vehicles)
                {
                    Console.WriteLine();
                    Console.WriteLine(String.Format("{0} Bir önceki sahibi: {1} {2}", _vehicle.Type, _vehicle.Owners[_vehicle.Owners.Count - 1].Name, _vehicle.Owners[_vehicle.Owners.Count - 1].Surname));
                    Console.WriteLine(String.Format("{0} şasi numrası: {1}", _vehicle.Type, _vehicle.ChassisNumber));
                    Console.WriteLine(String.Format("{0} Markası: {1}", _vehicle.Type, _vehicle.Brand));
                    Console.WriteLine(String.Format("{0} Modeli: {1}", _vehicle.Type, _vehicle.Model));
                    Console.WriteLine(String.Format("{0} Yılı: {1}", _vehicle.Type, _vehicle.Year));
                    Console.WriteLine(String.Format("{0} Edinme Tarihi: {1}", _vehicle.Type, _vehicle.Date));
                    Console.WriteLine(String.Format("{0} Edinme Fiyatı: {1}", _vehicle.Type, _vehicle.Price));

                    if (_vehicle.BeforeOwner() == null)
                        Console.WriteLine("Kullanıcı aracın sistemde kayıtlı ilk sahibi.");
                    else
                        Console.WriteLine(String.Format("{0} Bir önceki sahibi: {1} {2}", _vehicle.Type, _vehicle.BeforeOwner().Name, _vehicle.BeforeOwner().Surname));
                }
                Console.WriteLine();
                Console.Write("Çıkmak için herhangi bir tuşa basınız.");
                Console.ReadKey();
                Operation(peopleList);
            }
        }
        private static bool IndexQuary(Person _person, string _tc)
        {
            // Bu metot bir Perso ve _tc ister parametre olarak.
            // Kişi tcsi, kullanıcı girdisi olan tc ike uyşuyorsa metot true olarak döner...
            // ...ve true ise anlarız ki bu kullanıcı sistemde kayıtlıdır.
            // Birden fazla kullanmam gerekeceği için kod bloğunu ben de metot haline getirmek istedim.
            if (_person.TCID == _tc)
                return true;
            else
                return false;
        }
    }
}
