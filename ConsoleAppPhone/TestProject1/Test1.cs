using ClassLibrary;

namespace TestProject1
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void Test_Konstruktor_dane_poprawne_działanie_ok()
        {
            //AA

            //arrange
            var wlasciciel = "Molenda";
            var numerTelefonu = "123456789";
            //act
            var phone = new Phone(wlasciciel, numerTelefonu);

            //Assert
            Assert.AreEqual(wlasciciel, phone.Owner);
            Assert.AreEqual(numerTelefonu, phone.PhoneNumber);
        }



    }
    [TestClass]
    public sealed class Test2
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_Konstruktor_Dane_Niepoprawne_Wlasciciel_Null()
        {
            var wlascicel = "";
            var numerTelefonu = "";

            var phone = new Phone(wlascicel, numerTelefonu);

        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_Konstruktor_Dane_Niepoprawne_Numer_Niepoprawna_Liczba_Cyfr()
        {
            var wlasciciel = "Kuba";
            var numerTelefonu = "12345678"; // Niepoprawna liczba cyfr

            var phone = new Phone(wlasciciel, numerTelefonu);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_Konstruktor_Dane_Niepoprawne_Numer_Niepoprawne_Znaki()
        {
            var wlasciciel = "Kuba";
            var numerTelefonu = "12345678a"; // Niepoprawne znaki

            var phone = new Phone(wlasciciel, numerTelefonu);
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_PhoneBook_Capacity()
        {
            var wlasciciel = "Kuba";
            var numerTelefonu = "123456789";
            var phone = new Phone(wlasciciel, numerTelefonu);

            for (int i = 0; i < phone.PhoneBookCapacity; i++)
            {
                phone.AddContact($"Contact{i}", $"12345678{i % 10}");
            }

         
            phone.AddContact("ExtraContact", "123456789");
        }

        [TestMethod]
        public void Test_Call()
        { 
            var wlasciciel = "Kuba";
            var numerTelefonu = "123456789";
            var phone = new Phone(wlasciciel, numerTelefonu);

            phone.AddContact("Kuba", "123456789");  
            var result = phone.Call("Kuba");

            Assert.AreEqual("Calling 123456789 (Kuba) ...", result);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]

        public void Test_Call_Kontakt_Nie_Istnieje()
        {
            var phone = new Phone("Kuba", "123456789");
            phone.Call("Kuba");
        }



    }
}

