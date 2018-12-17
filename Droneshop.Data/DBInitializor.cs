using Droneshop.Core.Entity;
using Droneshop.Core.Helpers;
using System;
using System.Collections.Generic;

namespace Droneshop.Data
{
    public class DBInitializor : IDBInitializor
    {
        private readonly IAuthenticationHelper _authenticationHelper;

        public DBInitializor(IAuthenticationHelper authenticationHelper)
        {
            _authenticationHelper = authenticationHelper;
        }

        public void SeedDB(DroneShopContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            var manufacturer1 = ctx.Manufacturers.Add(new Manufacturer()
            {
                Id = 1,
                Name = "DJI"
            }).Entity;

            var manufacturer2 = ctx.Manufacturers.Add(new Manufacturer()
            {
                Id = 2,
                Name = "GoPro"
            }).Entity;

            var manufacturer3 = ctx.Manufacturers.Add(new Manufacturer()
            {
                Id = 3,
                Name = "Boeing"
            }).Entity;

            var manufacturer4 = ctx.Manufacturers.Add(new Manufacturer()
            {
                Id = 4,
                Name = "AeroViron"
            }).Entity;

            var drone1 = ctx.Drones.Add(new Drone()
            {
                Id = 1,
                Details = "DJI Spark er en mini-drone, der kun vejer 300 gram, men på trods af detteg har et 2-akset stabiliseret HD-kamera, anti-kollisionssensorer samt automatisk computerstyret flyvning, der kan genkende personer og objekter. \n"
                + "DJI Spark har en masse spændende funktionaliteter, hvor du blandt andet kan styre dronen med håndfakter via Gesture mode, flyve over 60 km/t med Sport Mode eller få den ultimative FPV-oplevelse, kan der til DJI Spark tilkøbes DJI Goggles. \n"
                + "DJI Sparken fås med en medfølgende beholder, hvor du nemt kan transportere dronen rundt. DJI Spark er dronen, som du altid kan have med på farten og flyve med uden de store udfordringer - og er perfekt til at holde din flyveegenskaber skarpe samtidig med, at du kan lave nogle imponerende optagelser (4K) og billeder (12MP) ved samme lejlighed.",
                ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/d/j/dji-spark-alpine-white-front-3-4-1_1.jpg",
                Manufacturer = manufacturer1,
                ProductName = "Spark",
                Price = 3299,
                UserManualURL = "https://dl.djicdn.com/downloads/Spark/20171031/Spark%20User%20Manual%20V1.6.pdf"

            }).Entity;

            var drone2 = ctx.Drones.Add(new Drone()
            {
                Id = 2,
                Details = "DJI Mavic 2 er udstyret med 4K-kamera fra selveste Hasselblad"
                + "Den store 1'' CMOS-sensor sørger for høj dynamic range og 100mbit bitrate. En kamerakvalitet der hidtil kun er set på større og ikke-foldbare dronemodeller"
                + "Du kan via mekanisk blænde fra F2,8-F11 styre lysindfaldet og din dybdeskarphed. ISO-værdien strækker sig fra 100-6400, hvilket giver en fordel under ringe lysforhold, der ellers har været en akilleshæl for droner med mindre kameraer."
                + "DJI Mavic 2 tager billeder i 20 MP med mulighed for JPEG og RAW. Samtidig kan den skyde video i 4K med 30fps og et video codec på 10bit.",
                ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/l/a/large_e796da8a-a9c1-4dcb-b67e-dbc3c4acebfe.jpg",
                Manufacturer = manufacturer1,
                ProductName = "Mavic 2 Pro",
                Price = 11499,
                UserManualURL = "https://dl.djicdn.com/downloads/Mavic_2/20180827/Mavic%202%20Pro%20Zoom%20User%20Manual_v1.0.pdf"

            }).Entity;

            var drone3 = ctx.Drones.Add(new Drone()
            {
                Id = 3,
                Details = "Som noget helt unikt har Mavic 2 Zoom et kamera med zoom-funktionaliteter. Kameraet har 2x optisk zoom - og kan zoome fra 24mm-48mm. Det betyder i praksis, at du kan zoome to gange ind i billedet uden at gå på kompromis med kvaliteten. Ved første øjekast kan dette lyde som om, at Mavic 2 Zoom udelukkende er designet til inspektionsopgaver, men det er ikke tilfældet. Zoom-objektivet giver nemlig mulighed for en lang række kreative udfoldelser i videoproduktionen, som kun Mavic 2 Zoom kan udføre: \n"
                + "Den første og mest interessant funktion er Dolly - zoom-funktionen. Denne funktion giver en speciel effekt, hvor dronen flyver frem og samtidig zoomer ud. Det lyder simpelt, men giver en helt speciel effekt. Denne funktion er alene en god grund til til at investere i netop denne model.",
                ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/m/e/medium_be9967d2-8f9f-45d2-a61d-2c416d3d5b10.jpg",
                Manufacturer = manufacturer1,
                ProductName = "Mavic 2 Zoom",
                Price = 9399,
                UserManualURL = "https://dl.djicdn.com/downloads/Mavic_2/20180827/Mavic%202%20Pro%20Zoom%20User%20Manual_v1.0.pdf"

            }).Entity;

            var drone4 = ctx.Drones.Add(new Drone()
            {
                Id = 4,
                Details = "DJI Mavic Air er 40% mindre end Mavic Pro. Mavic Air har en 3-akset gimbal-kamera med 7 retningssensorer for bedre sikkerhed under flyvning. \n"
                + "Mavic Air benytter de ekstra sensorer til at forudse hændelser og undgå kollidering med objekter ved hjælp af DJI's nye flysystem FlightAutonomy 2.0.",
                ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/m/e/medium_a7f3e87a-e907-4eef-8755-4a704155b682.jpg",
                Manufacturer = manufacturer1,
                ProductName = "Mavic Air",
                Price = 5599,
                UserManualURL = "https://dl.djicdn.com/downloads/Mavic%20Air/Mavic%20Air%20User%20Manual%20v1.0.pdf"

            }).Entity;

            var drone5 = ctx.Drones.Add(new Drone()
            {
                Id = 5,
                Details = "DJI Mavic Pro Platinum er 60% mere lydløs i forhold til den oprindelige udgave, DJI Mavic Pro, da den kommer monteret med støjsvage propeller. DJI Mavic Pro Platinium kan flyve 30 minutter i alt pr. batteri - 3 minutter længere end den originale model. \n"
                + "DJI Mavic den bedste drone til at tage med på farten i en rygsæk med en kompakt størrelse, fem indbyggede sensorer og et 4K-kamera i en 3-akset gimbal.",
                ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/m/e/medium_a2df7439-57c3-4c25-a01e-fcb35e0d8fb5.jpg",
                Manufacturer = manufacturer1,
                ProductName = "Mavic Pro Platinum",
                Price = 7499,
                UserManualURL = "https://dl.djicdn.com/downloads/mavic/20171219/Mavic%20Pro%20User%20Manual%20V2.0.pdf"

            }).Entity;

            var drone6 = ctx.Drones.Add(new Drone()
            {
                Id = 6,
                Details = "DJI Mavic 2 Enterprise giver mulighed for at påsætte ekstratilbehør på toppen af dronen.",
                ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/m/a/matrice-200.png",
                Manufacturer = manufacturer1,
                ProductName = "Mavic 2 Enterprise",
                Price = 17299,
                UserManualURL = "https://dl.djicdn.com/downloads/Mavic_2_Enterprise/Mavic_2_Enterprise_User_Manual_EN.pdf"

            }).Entity;

            var drone7 = ctx.Drones.Add(new Drone()
            {
                Id = 7,
                Details = "DJI Phantom 4 Advanced er en opgradering af DJI Phantom 4 med et forbedret kamera med højere bitrate og større sensor (1 tomme, 20MP Exmor R CMOS sensor). Dronen kommer med et forbedret batteri (også kompatibel med den almindelig Phantom 4), der giver længere flyvetid. Selve maskinen er udstyret med ekstra sensorer, således at den nu undgår objekter i 5 retninger.",
                ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/l/a/large_8e4406e9-6b59-4344-8a27-448e36ee0135.jpg",
                Manufacturer = manufacturer2,
                ProductName = "Phantom 4 Advanced",
                Price = 10499,
                UserManualURL = "https://dl.djicdn.com/downloads/Phantom_4_Advanced/20170413/User_Manual/Phantom_4_Adv_Adv_Plus_User_Manual_EN.pdf"

            }).Entity;

            var drone8 = ctx.Drones.Add(new Drone()
            {
                Id = 8,
                Details = "DJI Phantom 4 Advanced er en opgradering af DJI Phantom 4 med et forbedret kamera med højere bitrate og større sensor (1 tomme, 20MP Exmor R CMOS sensor). Dronen kommer med et forbedret batteri (også kompatibel med den almindelig Phantom 4), der giver længere flyvetid. Selve maskinen er udstyret med ekstra sensorer, såledesx at den nu undgår objekter i 5 retninger.",
                ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/m/e/medium_baada688-b74f-4bee-9a2d-9ff2e9782b7d_1.jpg",
                Manufacturer = manufacturer2,
                ProductName = "Phantom 4 Advanced+",
                Price = 12799,
                UserManualURL = "https://dl.djicdn.com/downloads/Phantom_4_Advanced/20170413/User_Manual/Phantom_4_Adv_Adv_Plus_User_Manual_EN.pdf"

            }).Entity;

            var drone9 = ctx.Drones.Add(new Drone()
            {
                Id = 9,
                Details = "DJI Phantom 4 RTK er designet til kravene for opmåling og kortlægning. Dronen er en kompakt løsning med et højopløsningskamera somgiver centimeter-nøjagtige RTK-data.",
                ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/p/4/p4r_light_front_v5_2.png",
                Manufacturer = manufacturer2,
                ProductName = "Phantom 4 RTK",
                Price = 42499,
                UserManualURL = "http://dl.djicdn.com/downloads/phantom_4_rtk/20181015/Phantom_4_RTK_User_Manual_v1.4_EN_.pdf"

            }).Entity;

            var drone10 = ctx.Drones.Add(new Drone()
            {
                Id = 10,
                Details = "DJI Phantom 4 RTK Combo er designet til kravene for opmåling og kortlægning. Dronen er en kompakt løsning med et højopløsningskamera somgiver centimeter-nøjagtige RTK-data.",
                ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/l/a/large_e796da8a-a9c1-4dcb-b67e-dbc3c4acebfe.jpg",
                Manufacturer = manufacturer2,
                ProductName = "Phantom 4 RTK Combo",
                Price = 58199,
                UserManualURL = "https://dl.djicdn.com/downloads/phantom_4/en/Phantom_4_User_Manual_en_v1.0.pdf"

            }).Entity;

            var drone11 = ctx.Drones.Add(new Drone()
            {
                Id = 11,
                Details = "DJI Inspire 2 er en opgradering af DJIs revolutionerende DJI Inspire 1 og tilbyder blandt andet et nyt integreret billedebehandlingssystem som kan optage video i op til 5,2K i CinemaDNG RAW og Apple ProRes . Derudover har den en maks hastighed på 108 km/t (30m/s) og kan accellerere fra 0-80 km/h på kun 4 sekunder, hvilket er unikt for en drone på denne størrelse. Et dobbelt batterisystem giver en flyvetid på helt op til 27 minutter (med DJI Zenmuse X4S ) og den har en indbygget selvvarmende teknologi, som giver mulighed for at flyve i lave temperature.",
                ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/o/p/optimeret-dji-inspire-2.jpg",
                Manufacturer = manufacturer3,
                ProductName = "Inspire 2",
                Price = 25499,
                UserManualURL = "https://dl.djicdn.com/downloads/inspire_2/20170104/INSPIRE+2+User+Manual+.pdf"

            }).Entity;

            var drone12 = ctx.Drones.Add(new Drone()
            {
                Id = 12,
                Details = "DJI Inspire 2 er en opgradering af DJIs revolutionerende DJI Inspire 1 og tilbyder blandt andet et nyt integreret billedebehandlingssystem som kan optage video i op til 5,2K i CinemaDNG RAW og Apple ProRes . Derudover har den en maks hastighed på 108 km/t (30m/s) og kan accellerere fra 0-80 km/h på kun 4 sekunder, hvilket er unikt for en drone på denne størrelse. Et dobbelt batterisystem giver en flyvetid på helt op til 27 minutter (med DJI Zenmuse X4S ) og den har en indbygget selvvarmende teknologi, som giver mulighed for at flyve i lave temperature.",
                ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/m/e/medium_b2ece876-e7ab-440b-bf4e-025025d9e0a7.png",
                Manufacturer = manufacturer3,
                ProductName = "Inspire 2 Professional Combo",
                Price = 52499,
                UserManualURL = "https://dl.djicdn.com/downloads/inspire_2/20170104/INSPIRE+2+User+Manual+.pdf"

            }).Entity;

            var drone13 = ctx.Drones.Add(new Drone()
            {
                Id = 13,
                Details = "DJI Inspire 2 er en opgradering af DJIs revolutionerende DJI Inspire 1 og tilbyder blandt andet et nyt integreret billedebehandlingssystem som kan optage video i op til 5,2K i CinemaDNG RAW og Apple ProRes . Derudover har den en maks hastighed på 108 km/t (30m/s) og kan accellerere fra 0-80 km/h på kun 4 sekunder, hvilket er unikt for en drone på denne størrelse. Et dobbelt batterisystem giver en flyvetid på helt op til 27 minutter (med DJI Zenmuse X4S ) og den har en indbygget selvvarmende teknologi, som giver mulighed for at flyve i lave temperature.",
                ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/m/e/medium_64178d3f-6dce-4c30-9d8d-d49a7cd53f82.png",
                Manufacturer = manufacturer3,
                ProductName = "Inspire 2 Premium Combo",
                Price = 106129,
                UserManualURL = "https://dl.djicdn.com/downloads/inspire_2/20170104/INSPIRE+2+User+Manual+.pdf"

            }).Entity;

            var drone14 = ctx.Drones.Add(new Drone()
            {
                Id = 14,
                Details = "DJI Inspire 1 er en samlet løsning med alt hvad du behøver indenfor luftfotografering. DJI Inspire 1 er en quadcoptor, der leveres flyveklar ved modtagelse.",
                ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/i/n/inspire-1v2.jpg",
                Manufacturer = manufacturer3,
                ProductName = "Inspire 1 V2",
                Price = 17399,
                UserManualURL = "https://dl.djicdn.com/downloads/inspire_1/en/INSPIRE+1+V2.0+User+Manual+(%E5%8F%91%E5%B8%83).pdf"

            }).Entity;

            var drone15 = ctx.Drones.Add(new Drone()
            {
                Id = 15,
                Details = "DJI Matrice 200 er skabt til at løse professionelle opgaver. Matrice 200 er inspireret udfra Inspire 2-platformen, men er mere robust og bygget til at modstå barske vind- og vejrforhold. DJI Matrice 200 har fået en IP43-vurdering for vind- og vejr modstandsdygtighed, der gør den resistent i flyvninger med regn og blæst.",
                ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/m/a/matrice-200.png",
                Manufacturer = manufacturer4,
                ProductName = "Matrice 200",
                Price = 37599,
                UserManualURL = "https://dl.djicdn.com/downloads/M200/20170622/M200_User_Manual_v1.0_en.pdf"

            }).Entity;

            var drone16 = ctx.Drones.Add(new Drone()
            {
                Id = 16,
                Details = "Med DJI Matrice 600 Pro kan du hurtigt flyve på trods af, at det er en avanceret platform. Dette er grundet, at alle moduler er integreret i platformen hvilket betyder, at alt er designet, kodet samt taler sammen i ét system. Alle zenmuse - kameraer og - gimbals understøttes af DJI Matrice 600 Pro deriblandt også DJI Ronin - MX.Løfteevnen på DJI Matrice 600 Pro er 6kg total, hvilket betyder at DJI Ronin - MX samt er RED Epic kan løftes og flyves med dronen.",
                ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/m/6/m600pro.jpg",
                Manufacturer = manufacturer4,
                ProductName = "Matrice 600 Pro",
                Price = 42999,
                UserManualURL = "https://dl.djicdn.com/downloads/m600+pro/20170717/Matrice_600_Pro_User_Manual_v1.0_EN.pdf"

            }).Entity;

            string password = "1234";
            _authenticationHelper.CreatePasswordHash(password, out var passwordHash, out var passwordSalt);
            var admin = ctx.Users.Add(new User()
            {
                Id = 1,
                Username = "AdminAllan",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                IsAdmin = true

            }).Entity;
            
            var user = ctx.Users.Add(new User()
            {
                Id = 2,
                Username = "User2",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                IsAdmin = false

            }).Entity;

            var customer = ctx.Customers.Add(new Customer()
            {
                Id = 1,
                FirstName = "Hans",
                LastName = "Hansen",
                Address = "Kongensgade 11",
                PhoneNumber = 12345678,
                Email = "hans.hansen@gmail.com",
                User = user,
                UserId = user.Id
            }).Entity;

            var package1 = ctx.Packages.Add(new Package()
            {
                Id = 1,
                description = "Timepris 1 person",
                price = "650 kr + moms"
            }).Entity;

            var package2 = ctx.Packages.Add(new Package()
            {
                Id = 2,
                description = "Timepris 2 personer",
                price = "1100 + moms"
            }).Entity;

            var package3 = ctx.Packages.Add(new Package()
            {
                Id = 3,
                description = "Uredigeret i RAW og JPG",
                price = "5 kr pr billede max 30 billeder"
            }).Entity;

            var package4 = ctx.Packages.Add(new Package()
            {
                Id = 4,
                description = "Redigeret i Adobe Light-room i RAW og JPG",
                price = "15 kr pr billede max 20 billeder"
            }).Entity;

            var package5 = ctx.Packages.Add(new Package()
            {
                Id = 5,
                description = "Videooptagelse med 4 K uredigeret",
                price = "1 kr pr minut"
            }).Entity;

            var package6 = ctx.Packages.Add(new Package()
            {
                Id = 6,
                description = "Redigering af video",
                price = "15 kr pr minut video"
            }).Entity;

            var package7 = ctx.Packages.Add(new Package()
            {
                Id = 7,
                description = "Kørsel",
                price = "Statens takst – de første 15 km gratis"
            }).Entity;

            var order1 = ctx.Orders.Add(new Order()
            {
                Id = 1,
                OderDate = DateTime.Now,
                Customer = customer,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine()
                    {
                        DroneId = 1,
                        Qty = 5,
                        BoughtPrice = 500
                    }
                }
            }).Entity;


            var order2 = ctx.Orders.Add(new Order()
            {
                Id = 2,
                OderDate = DateTime.Now,
                Customer = customer,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine()
                    {
                        DroneId = 2,
                        Qty = 5,
                        BoughtPrice = 500
                    }
                }
            }).Entity;

            ctx.SaveChanges();
        }

    }
}