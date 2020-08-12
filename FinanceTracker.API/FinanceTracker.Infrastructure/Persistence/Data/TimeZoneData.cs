using FinanceTracker.Domain.Entities;
using System.Collections.Generic;

namespace FinanceTracker.Infrastructure.Persistence.Data
{
    public static class TimeZoneData
    {
        public static List<StateTimeZone> GetTimeZoneList()
        {
            var timeZones = new List<StateTimeZone>()
            {
                new StateTimeZone()
                {
                    UTC = "+04:30",
                    Description = "(UTC +04:30) Kabul, Kandahār"
                },
                new StateTimeZone()
                {
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Mariehamn"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Tirana, Durrës"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Algiers, Boumerdas"
                },
                new StateTimeZone()
                {
                    UTC = "-11:00",
                    Description = "(UTC -11:00) Pago Pago"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Andorra la Vella, les Escaldes"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Luanda, N’dalatando"
                },
                new StateTimeZone()
                {
                    UTC = "-04:00",
                    Description = "(UTC -04:00) The Valley"
                },
                new StateTimeZone()
                {
                    UTC = "+00:00",
                    Description = "(UTC +00:00) Troll"
                },
                new StateTimeZone()
                {
                    UTC = "+03:00",
                    Description = "(UTC +03:00) Syowa"
                },
                new StateTimeZone()
                {
                    UTC = "+05:00",
                    Description = "(UTC +05:00) Mawson"
                },
                new StateTimeZone()
                {
                    UTC = "+06:00",
                    Description = "(UTC +06:00) Vostok"
                },
                new StateTimeZone()
                {
                    UTC = "+07:00",
                    Description = "(UTC +07:00) Davis"
                },
                new StateTimeZone()
                {
                    UTC = "+08:00",
                    Description = "(UTC +08:00) Casey"
                },
                new StateTimeZone()
                {
                    UTC = "+10:00",
                    Description = "(UTC +10:00) DumontDUrville"
                },
                new StateTimeZone()
                {
                    UTC = "+12:00",
                    Description = "(UTC +12:00) McMurdo"
                },
                new StateTimeZone()
                {
                    UTC = "-03:00",
                    Description = "(UTC -03:00) Palmer, Rothera"
                },
                new StateTimeZone()
                {
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Saint John’s"
                },
                new StateTimeZone()
                {
                    UTC = "-03:00",
                    Description = "(UTC -03:00) Buenos Aires, Córdoba"
                },
                new StateTimeZone()
                {
                    UTC = "+04:00",
                    Description = "(UTC +04:00) Yerevan, Gyumri"
                },
                new StateTimeZone()
                {
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Oranjestad, Tanki Leendert"
                },
                new StateTimeZone()
                {
                    UTC = "+08:00",
                    Description = "(UTC +08:00) Perth, Rockingham"
                },
                new StateTimeZone()
                {
                    UTC = "+08:45",
                    Description = "(UTC +08:45) Eucla"
                },
                new StateTimeZone()
                {
                    UTC = "+09:30",
                    Description = "(UTC +09:30) Adelaide, Adelaide Hills"
                },
                new StateTimeZone()
                {
                    UTC = "+09:30",
                    Description = "(UTC +09:30) Darwin, Alice Springs"
                },
                new StateTimeZone()
                {
                    UTC = "+10:00",
                    Description = "(UTC +10:00) Brisbane, Gold Coast"
                },
                new StateTimeZone()
                {
                    UTC = "+10:00",
                    Description = "(UTC +10:00) Sydney, Melbourne"
                },
                new StateTimeZone()
                {
                    UTC = "+10:30",
                    Description = "(UTC +10:30) Lord Howe"
                },
                new StateTimeZone()
                {
                    UTC = "+11:00",
                    Description = "(UTC +11:00) Macquarie"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Vienna, Graz"
                },
                new StateTimeZone()
                {
                    UTC = "+04:00",
                    Description = "(UTC +04:00) Baku, Ganja"
                },
                new StateTimeZone()
                {
                    UTC = "-05:00",
                    Description = "(UTC -05:00) Nassau, Lucaya"
                },
                new StateTimeZone()
                {
                    UTC = "+03:00",
                    Description = "(UTC +03:00) Manama, Al Muharraq"
                },
                new StateTimeZone()
                {
                    UTC = "+06:00",
                    Description = "(UTC +06:00) Dhaka, Chittagong"
                },
                new StateTimeZone()
                {
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Bridgetown"
                },
                new StateTimeZone()
                {
                    UTC = "+03:00",
                    Description = "(UTC +03:00) Minsk, Homyel'"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Brussels, Antwerpen"
                },
                new StateTimeZone()
                {
                    UTC = "-06:00",
                    Description = "(UTC -06:00) Belize City, San Ignacio"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Cotonou, Abomey-Calavi"
                },
                new StateTimeZone()
                {
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Hamilton"
                },
                new StateTimeZone()
                {
                    UTC = "+06:00",
                    Description = "(UTC +06:00) Thimphu, Punākha"
                },
                new StateTimeZone()
                {
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Santa Cruz de la Sierra, Cochabamba"
                },
                new StateTimeZone()
                {
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Kralendijk"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Sarajevo, Banja Luka"
                },
                new StateTimeZone()
                {
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Gaborone, Francistown"
                },
                new StateTimeZone()
                {
                    UTC = "-02:00",
                    Description = "(UTC -02:00) Noronha"
                },
                new StateTimeZone()
                {
                    UTC = "-03:00",
                    Description = "(UTC -03:00) São Paulo, Rio de Janeiro"
                },
                new StateTimeZone()
                {
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Manaus, Campo Grande"
                },
                new StateTimeZone()
                {
                    UTC = "-05:00",
                    Description = "(UTC -05:00) Rio Branco, Cruzeiro do Sul"
                },
                new StateTimeZone()
                {
                    UTC = "+06:00",
                    Description = "(UTC +06:00) Chagos"
                },
                new StateTimeZone()
                {
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Road Town"
                },
                new StateTimeZone()
                {
                    UTC = "+08:00",
                    Description = "(UTC +08:00) Bandar Seri Begawan, Kuala Belait"
                },
                new StateTimeZone()
                {
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Sofia, Plovdiv"
                },
                new StateTimeZone()
                {
                    UTC = "+00:00",
                    Description = "(UTC +00:00) Ouagadougou, Bobo-Dioulasso"
                },
                new StateTimeZone()
                {
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Bujumbura, Muyinga"
                },
                new StateTimeZone()
                {
                    UTC = "-01:00",
                    Description = "(UTC -01:00) Praia, Mindelo"
                },
                new StateTimeZone()
                {
                    UTC = "+07:00",
                    Description = "(UTC +07:00) Phnom Penh, Takeo"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Douala, Yaoundé"
                },
                new StateTimeZone()
                {
                    UTC = "-03:30",
                    Description = "(UTC -03:30) St. John's, Mount Pearl"
                },
                new StateTimeZone()
                {
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Halifax, Moncton"
                },
                new StateTimeZone()
                {
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Lévis"
                },
                new StateTimeZone()
                {
                    UTC = "-05:00",
                    Description = "(UTC -05:00) Atikokan"
                },
                new StateTimeZone()
                {
                    UTC = "-05:00",
                    Description = "(UTC -05:00) Toronto, Montréal"
                },
                new StateTimeZone()
                {
                    UTC = "-06:00",
                    Description = "(UTC -06:00) Saskatoon, Regina"
                },
                new StateTimeZone()
                {
                    UTC = "-06:00",
                    Description = "(UTC -06:00) Winnipeg, Brandon"
                },
                new StateTimeZone()
                {
                    UTC = "-07:00",
                    Description = "(UTC -07:00) Calgary, Edmonton"
                },
                new StateTimeZone()
                {
                    UTC = "-07:00",
                    Description = "(UTC -07:00) Fort St. John, Creston"
                },
                new StateTimeZone()
                {
                    UTC = "-07:00",
                    Description = "(UTC -07:00) Whitehorse, Dawson"
                },
                new StateTimeZone()
                {
                    UTC = "-08:00",
                    Description = "(UTC -08:00) Vancouver, Surrey"
                },
                new StateTimeZone()
                {
                    UTC = "-05:00",
                    Description = "(UTC -05:00) George Town"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Bangui, Bimbo"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) N'Djamena, Moundou"
                },
                new StateTimeZone()
                {
                    UTC = "-03:00",
                    Description = "(UTC -03:00) Punta Arenas, Puerto Natales"
                },
                new StateTimeZone()
                {
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Santiago, Puente Alto"
                },
                new StateTimeZone()
                {
                    UTC = "-06:00",
                    Description = "(UTC -06:00) Easter"
                },
                new StateTimeZone()
                {
                    UTC = "+06:00",
                    Description = "(UTC +06:00) Zhongshan, Ürümqi"
                },
                new StateTimeZone()
                {
                    UTC = "+08:00",
                    Description = "(UTC +08:00) Shanghai, Beijing"
                },
                new StateTimeZone()
                {
                    UTC = "+07:00",
                    Description = "(UTC +07:00) Flying Fish Cove"
                },
                new StateTimeZone()
                {
                    UTC = "+06:30",
                    Description = "(UTC +06:30) West Island"
                },
                new StateTimeZone()
                {
                    UTC = "-05:00",
                    Description = "(UTC -05:00) Bogotá, Cali"
                },
                new StateTimeZone()
                {
                    UTC = "+03:00",
                    Description = "(UTC +03:00) Moroni, Moutsamoudou"
                },
                new StateTimeZone()
                {
                    UTC = "-10:00",
                    Description = "(UTC -10:00) Avarua"
                },
                new StateTimeZone()
                {
                    UTC = "-06:00",
                    Description = "(UTC -06:00) San José, Limón"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Zagreb, Split"
                },
                new StateTimeZone()
                {
                    UTC = "-05:00",
                    Description = "(UTC -05:00) Havana, Santiago de Cuba"
                },
                new StateTimeZone()
                {
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Willemstad"
                },
                new StateTimeZone()
                {
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Nicosia, Limassol"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Prague, Brno"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Kinshasa, Masina"
                },
                new StateTimeZone()
                {
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Lubumbashi, Mbuji-Mayi"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Copenhagen, Århus"
                },
                new StateTimeZone()
                {
                    UTC = "+03:00",
                    Description = "(UTC +03:00) Djibouti, 'Ali Sabieh"
                },
                new StateTimeZone()
                {
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Roseau"
                },
                new StateTimeZone()
                {
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Santo Domingo, Santiago de los Caballeros"
                },
                new StateTimeZone()
                {
                    UTC = "-05:00",
                    Description = "(UTC -05:00) Guayaquil, Quito"
                },
                new StateTimeZone()
                {
                    UTC = "-06:00",
                    Description = "(UTC -06:00) Galapagos"
                },
                new StateTimeZone()
                {
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Cairo, Alexandria"
                },
                new StateTimeZone()
                {
                    UTC = "-06:00",
                    Description = "(UTC -06:00) San Salvador, Soyapango"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Bata, Malabo"
                },
                new StateTimeZone()
                {
                    UTC = "+03:00",
                    Description = "(UTC +03:00) Asmara, Keren"
                },
                new StateTimeZone()
                {
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Tallinn, Tartu"
                },
                new StateTimeZone()
                {
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Manzini, Mbabane"
                },
                new StateTimeZone()
                {
                    UTC = "+03:00",
                    Description = "(UTC +03:00) Addis Ababa, Dire Dawa"
                },
                new StateTimeZone()
                {
                    UTC = "-03:00",
                    Description = "(UTC -03:00) Stanley"
                },
                new StateTimeZone()
                {
                    UTC = "+00:00",
                    Description = "(UTC +00:00) Tórshavn"
                },
                new StateTimeZone()
                {
                    UTC = "+12:00",
                    Description = "(UTC +12:00) Suva, Lautoka"
                },
                new StateTimeZone()
                {
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Helsinki, Espoo"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Paris, Marseille"
                },
                new StateTimeZone()
                {
                    UTC = "-03:00",
                    Description = "(UTC -03:00) Cayenne, Matoury"
                },
                new StateTimeZone()
                {
                    UTC = "-09:00",
                    Description = "(UTC -09:00) Gambier"
                },
                new StateTimeZone()
                {
                    UTC = "-09:30",
                    Description = "(UTC -09:30) Marquesas"
                },
                new StateTimeZone()
                {
                    UTC = "-10:00",
                    Description = "(UTC -10:00) Faaa, Papeete"
                },
                new StateTimeZone()
                {
                    UTC = "+05:00",
                    Description = "(UTC +05:00) Port-aux-Français"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Libreville, Port-Gentil"
                },
                new StateTimeZone()
                {
                    UTC = "+00:00",
                    Description = "(UTC +00:00) Serekunda, Brikama"
                },
                new StateTimeZone()
                {
                    UTC = "+04:00",
                    Description = "(UTC +04:00) Tbilisi, Kutaisi"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Berlin, Hamburg"
                },
                new StateTimeZone()
                {
                    UTC = "+00:00",
                    Description = "(UTC +00:00) Accra, Kumasi"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Gibraltar"
                },
                new StateTimeZone()
                {
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Athens, Thessaloníki"
                },
                new StateTimeZone()
                {
                    UTC = "+00:00",
                    Description = "(UTC +00:00) Danmarkshavn"
                },
                new StateTimeZone()
                {
                    UTC = "-01:00",
                    Description = "(UTC -01:00) Scoresbysund"
                },
                new StateTimeZone()
                {
                    UTC = "-03:00",
                    Description = "(UTC -03:00) Nuuk"
                },
                new StateTimeZone()
                {
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Thule"
                },
                new StateTimeZone()
                {
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Saint George's"
                },
                new StateTimeZone()
                {
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Les Abymes, Baie-Mahault"
                },
                new StateTimeZone()
                {
                    UTC = "+10:00",
                    Description = "(UTC +10:00) Dededo Village, Yigo Village"
                },
                new StateTimeZone()
                {
                    UTC = "-06:00",
                    Description = "(UTC -06:00) Guatemala City, Mixco"
                },
                new StateTimeZone()
                {
                    UTC = "+00:00",
                    Description = "(UTC +00:00) Saint Peter Port"
                },
                new StateTimeZone()
                {
                    UTC = "+00:00",
                    Description = "(UTC +00:00) Camayenne, Conakry"
                },
                new StateTimeZone()
                {
                    UTC = "+00:00",
                    Description = "(UTC +00:00) Bissau, Bafatá"
                },
                new StateTimeZone()
                {
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Georgetown, Linden"
                },
                new StateTimeZone()
                {
                    UTC = "-05:00",
                    Description = "(UTC -05:00) Port-au-Prince, Carrefour"
                },
                new StateTimeZone()
                {
                    UTC = "-06:00",
                    Description = "(UTC -06:00) Tegucigalpa, San Pedro Sula"
                },
                new StateTimeZone()
                {
                    UTC = "+08:00",
                    Description = "(UTC +08:00) Hong Kong, Kowloon"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Budapest, Debrecen"
                },
                new StateTimeZone()
                {
                    UTC = "+00:00",
                    Description = "(UTC +00:00) Reykjavík, Kópavogur"
                },
                new StateTimeZone()
                {
                    UTC = "+05:30",
                    Description = "(UTC +05:30) Mumbai, Delhi"
                },
                new StateTimeZone()
                {
                    UTC = "+07:00",
                    Description = "(UTC +07:00) Jakarta, Surabaya"
                },
                new StateTimeZone()
                {
                    UTC = "+08:00",
                    Description = "(UTC +08:00) Makassar, Denpasar"
                },
                new StateTimeZone()
                {
                    UTC = "+09:00",
                    Description = "(UTC +09:00) Ambon, Jayapura"
                },
                new StateTimeZone()
                {
                    UTC = "+03:30",
                    Description = "(UTC +03:30) Tehran, Mashhad"
                },
                new StateTimeZone()
                {
                    UTC = "+03:00",
                    Description = "(UTC +03:00) Baghdad, Basrah"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Dublin, Cork"
                },
                new StateTimeZone()
                {
                    UTC = "+00:00",
                    Description = "(UTC +00:00) Douglas"
                },
                new StateTimeZone()
                {
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Jerusalem, Tel Aviv"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Rome, Milan"
                },
                new StateTimeZone()
                {
                    UTC = "+00:00",
                    Description = "(UTC +00:00) Abidjan, Abobo"
                },
                new StateTimeZone()
                {
                    UTC = "-05:00",
                    Description = "(UTC -05:00) Kingston, New Kingston"
                },
                new StateTimeZone()
                {
                    UTC = "+09:00",
                    Description = "(UTC +09:00) Tokyo, Yokohama"
                },
                new StateTimeZone()
                {
                    UTC = "+00:00",
                    Description = "(UTC +00:00) Saint Helier"
                },
                new StateTimeZone()
                {
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Amman, Zarqa"
                },
                new StateTimeZone()
                {
                    UTC = "+05:00",
                    Description = "(UTC +05:00) Kyzylorda, Aktobe"
                },
                new StateTimeZone()
                {
                    UTC = "+06:00",
                    Description = "(UTC +06:00) Almaty, Karagandy"
                },
                new StateTimeZone()
                {
                    UTC = "+03:00",
                    Description = "(UTC +03:00) Nairobi, Mombasa"
                },
                new StateTimeZone()
                {
                    UTC = "+12:00",
                    Description = "(UTC +12:00) Tarawa"
                },
                new StateTimeZone()
                {
                    UTC = "+13:00",
                    Description = "(UTC +13:00) Enderbury"
                },
                new StateTimeZone()
                {
                    UTC = "+14:00",
                    Description = "(UTC +14:00) Kiritimati"
                },
                new StateTimeZone()
                {
                    UTC = "+03:00",
                    Description = "(UTC +03:00) Al Aḩmadī, Ḩawallī"
                },
                new StateTimeZone()
                {
                    UTC = "+06:00",
                    Description = "(UTC +06:00) Bishkek, Osh"
                },
                new StateTimeZone()
                {
                    UTC = "+07:00",
                    Description = "(UTC +07:00) Vientiane, Pakse"
                },
                new StateTimeZone()
                {
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Riga, Daugavpils"
                },
                new StateTimeZone()
                {
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Beirut, Ra’s Bayrūt"
                },
                new StateTimeZone()
                {
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Maseru, Mafeteng"
                },
                new StateTimeZone()
                {
                    UTC = "+00:00",
                    Description = "(UTC +00:00) Monrovia, Gbarnga"
                },
                new StateTimeZone()
                {
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Tripoli, Benghazi"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Vaduz"
                },
                new StateTimeZone()
                {
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Vilnius, Kaunas"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Luxembourg, Esch-sur-Alzette"
                },
                new StateTimeZone()
                {
                    UTC = "+08:00",
                    Description = "(UTC +08:00) Macau"
                },
                new StateTimeZone()
                {
                    UTC = "+03:00",
                    Description = "(UTC +03:00) Antananarivo, Toamasina"
                },
                new StateTimeZone()
                {
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Lilongwe, Blantyre"
                },
                new StateTimeZone()
                {
                    UTC = "+08:00",
                    Description = "(UTC +08:00) Kota Bharu, Kuala Lumpur"
                },
                new StateTimeZone()
                {
                    UTC = "+05:00",
                    Description = "(UTC +05:00) Male"
                },
                new StateTimeZone()
                {
                    UTC = "+00:00",
                    Description = "(UTC +00:00) Bamako, Sikasso"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Birkirkara, Qormi"
                },
                new StateTimeZone()
                {
                    UTC = "+12:00",
                    Description = "(UTC +12:00) Majuro, Kwajalein"
                },
                new StateTimeZone()
                {
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Fort-de-France, Le Lamentin"
                },
                new StateTimeZone()
                {
                    UTC = "+00:00",
                    Description = "(UTC +00:00) Nouakchott, Nouadhibou"
                },
                new StateTimeZone()
                {
                    UTC = "+04:00",
                    Description = "(UTC +04:00) Port Louis, Beau Bassin-Rose Hill"
                },
                new StateTimeZone()
                {
                    UTC = "+03:00",
                    Description = "(UTC +03:00) Mamoudzou, Koungou"
                },
                new StateTimeZone()
                {
                    UTC = "-05:00",
                    Description = "(UTC -05:00) Cancún, Chetumal"
                },
                new StateTimeZone()
                {
                    UTC = "-06:00",
                    Description = "(UTC -06:00) Mexico City, Iztapalapa"
                },
                new StateTimeZone()
                {
                    UTC = "-07:00",
                    Description = "(UTC -07:00) Ciudad Juárez, Chihuahua"
                },
                new StateTimeZone()
                {
                    UTC = "-07:00",
                    Description = "(UTC -07:00) Hermosillo, Ciudad Obregón"
                },
                new StateTimeZone()
                {
                    UTC = "-08:00",
                    Description = "(UTC -08:00) Tijuana, Mexicali"
                },
                new StateTimeZone()
                {
                    UTC = "+10:00",
                    Description = "(UTC +10:00) Chuuk"
                },
                new StateTimeZone()
                {
                    UTC = "+11:00",
                    Description = "(UTC +11:00) Kosrae, Palikir - National Government Center"
                },
                new StateTimeZone()
                {
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Chisinau, Tiraspol"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Monaco, Monte-Carlo"
                },
                new StateTimeZone()
                {
                    UTC = "+07:00",
                    Description = "(UTC +07:00) Khovd, Ölgii"
                },
                new StateTimeZone()
                {
                    UTC = "+08:00",
                    Description = "(UTC +08:00) Ulan Bator, Erdenet"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Podgorica, Nikšić"
                },
                new StateTimeZone()
                {
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Brades, Plymouth"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Casablanca, Rabat"
                },
                new StateTimeZone()
                {
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Maputo, Matola"
                },
                new StateTimeZone()
                {
                    UTC = "+06:30",
                    Description = "(UTC +06:30) Yangon, Mandalay"
                },
                new StateTimeZone()
                {
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Windhoek, Rundu"
                },
                new StateTimeZone()
                {
                    UTC = "+12:00",
                    Description = "(UTC +12:00) Yaren"
                },
                new StateTimeZone()
                {
                    UTC = "+05:45",
                    Description = "(UTC +05:45) Kathmandu, Pokhara"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Amsterdam, Rotterdam"
                },
                new StateTimeZone()
                {
                    UTC = "+11:00",
                    Description = "(UTC +11:00) Nouméa, Mont-Dore"
                },
                new StateTimeZone()
                {
                    UTC = "+12:00",
                    Description = "(UTC +12:00) Auckland, Wellington"
                },
                new StateTimeZone()
                {
                    UTC = "+12:45",
                    Description = "(UTC +12:45) Chatham"
                },
                new StateTimeZone()
                {
                    UTC = "-06:00",
                    Description = "(UTC -06:00) Managua, León"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Niamey, Zinder"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Lagos, Kano"
                },
                new StateTimeZone()
                {
                    UTC = "-11:00",
                    Description = "(UTC -11:00) Alofi"
                },
                new StateTimeZone()
                {
                    UTC = "+11:00",
                    Description = "(UTC +11:00) Kingston"
                },
                new StateTimeZone()
                {
                    UTC = "+09:00",
                    Description = "(UTC +09:00) Pyongyang, Hamhŭng"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Skopje, Bitola"
                },
                new StateTimeZone()
                {
                    UTC = "+10:00",
                    Description = "(UTC +10:00) Saipan"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Oslo, Bergen"
                },
                new StateTimeZone()
                {
                    UTC = "+04:00",
                    Description = "(UTC +04:00) Muscat, Seeb"
                },
                new StateTimeZone()
                {
                    UTC = "+05:00",
                    Description = "(UTC +05:00) Karachi, Lahore"
                },
                new StateTimeZone()
                {
                    UTC = "+09:00",
                    Description = "(UTC +09:00) Ngerulmud"
                },
                new StateTimeZone()
                {
                    UTC = "+02:00",
                    Description = "(UTC +02:00) East Jerusalem, Gaza"
                },
                new StateTimeZone()
                {
                    UTC = "-05:00",
                    Description = "(UTC -05:00) Panamá, San Miguelito"
                },
                new StateTimeZone()
                {
                    UTC = "+10:00",
                    Description = "(UTC +10:00) Port Moresby, Lae"
                },
                new StateTimeZone()
                {
                    UTC = "+11:00",
                    Description = "(UTC +11:00) Arawa"
                },
                new StateTimeZone()
                {
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Asunción, Ciudad del Este"
                },
                new StateTimeZone()
                {
                    UTC = "-05:00",
                    Description = "(UTC -05:00) Lima, Arequipa"
                },
                new StateTimeZone()
                {
                    UTC = "+08:00",
                    Description = "(UTC +08:00) Quezon City, Manila"
                },
                new StateTimeZone()
                {
                    UTC = "-08:00",
                    Description = "(UTC -08:00) Adamstown"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Warsaw, Łódź"
                },
                new StateTimeZone()
                {
                    UTC = "+00:00",
                    Description = "(UTC +00:00) Lisbon, Porto"
                },
                new StateTimeZone()
                {
                    UTC = "-01:00",
                    Description = "(UTC -01:00) Ponta Delgada"
                },
                new StateTimeZone()
                {
                    UTC = "-04:00",
                    Description = "(UTC -04:00) San Juan, Bayamón"
                },
                new StateTimeZone()
                {
                    UTC = "+03:00",
                    Description = "(UTC +03:00) Doha, Ar Rayyān"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Brazzaville, Pointe-Noire"
                },
                new StateTimeZone()
                {
                    UTC = "+04:00",
                    Description = "(UTC +04:00) Saint-Denis, Saint-Paul"
                },
                new StateTimeZone()
                {
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Bucharest, Sector 3"
                },
                new StateTimeZone()
                {
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Kaliningrad, Chernyakhovsk"
                },
                new StateTimeZone()
                {
                    UTC = "+03:00",
                    Description = "(UTC +03:00) Moscow, Saint Petersburg"
                },
                new StateTimeZone()
                {
                    UTC = "+04:00",
                    Description = "(UTC +04:00) Samara, Volgograd"
                },
                new StateTimeZone()
                {
                    UTC = "+05:00",
                    Description = "(UTC +05:00) Yekaterinburg, Chelyabinsk"
                },
                new StateTimeZone()
                {
                    UTC = "+06:00",
                    Description = "(UTC +06:00) Omsk, Tara"
                },
                new StateTimeZone()
                {
                    UTC = "+07:00",
                    Description = "(UTC +07:00) Novosibirsk, Krasnoyarsk"
                },
                new StateTimeZone()
                {
                    UTC = "+08:00",
                    Description = "(UTC +08:00) Irkutsk, Ulan-Ude"
                },
                new StateTimeZone()
                {
                    UTC = "+09:00",
                    Description = "(UTC +09:00) Chita, Yakutsk"
                },
                new StateTimeZone()
                {
                    UTC = "+10:00",
                    Description = "(UTC +10:00) Vladivostok, Khabarovsk"
                },
                new StateTimeZone()
                {
                    UTC = "+11:00",
                    Description = "(UTC +11:00) Yuzhno-Sakhalinsk, Magadan"
                },
                new StateTimeZone()
                {
                    UTC = "+12:00",
                    Description = "(UTC +12:00) Petropavlovsk-Kamchatsky, Yelizovo"
                },
                new StateTimeZone()
                {
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Kigali, Butare"
                },
                new StateTimeZone()
                {
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Gustavia"
                },
                new StateTimeZone()
                {
                    UTC = "+00:00",
                    Description = "(UTC +00:00) Jamestown"
                },
                new StateTimeZone()
                {
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Basseterre"
                },
                new StateTimeZone()
                {
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Castries"
                },
                new StateTimeZone()
                {
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Marigot"
                },
                new StateTimeZone()
                {
                    UTC = "-03:00",
                    Description = "(UTC -03:00) Saint-Pierre"
                },
                new StateTimeZone()
                {
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Kingstown, Kingstown Park"
                },
                new StateTimeZone()
                {
                    UTC = "+13:00",
                    Description = "(UTC +13:00) Apia"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) San Marino"
                },
                new StateTimeZone()
                {
                    UTC = "+00:00",
                    Description = "(UTC +00:00) São Tomé"
                },
                new StateTimeZone()
                {
                    UTC = "+03:00",
                    Description = "(UTC +03:00) Riyadh, Jeddah"
                },
                new StateTimeZone()
                {
                    UTC = "+00:00",
                    Description = "(UTC +00:00) Dakar, Pikine"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Belgrade, Niš"
                },
                new StateTimeZone()
                {
                    UTC = "+04:00",
                    Description = "(UTC +04:00) Victoria"
                },
                new StateTimeZone()
                {
                    UTC = "+00:00",
                    Description = "(UTC +00:00) Freetown, Bo"
                },
                new StateTimeZone()
                {
                    UTC = "+08:00",
                    Description = "(UTC +08:00) Singapore, Woodlands"
                },
                new StateTimeZone()
                {
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Philipsburg"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Bratislava, Košice"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Ljubljana, Maribor"
                },
                new StateTimeZone()
                {
                    UTC = "+11:00",
                    Description = "(UTC +11:00) Honiara"
                },
                new StateTimeZone()
                {
                    UTC = "+03:00",
                    Description = "(UTC +03:00) Mogadishu, Hargeysa"
                },
                new StateTimeZone()
                {
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Cape Town, Durban"
                },
                new StateTimeZone()
                {
                    UTC = "-02:00",
                    Description = "(UTC -02:00) Grytviken"
                },
                new StateTimeZone()
                {
                    UTC = "+09:00",
                    Description = "(UTC +09:00) Seoul, Busan"
                },
                new StateTimeZone()
                {
                    UTC = "+03:00",
                    Description = "(UTC +03:00) Juba, Winejok"
                },
                new StateTimeZone()
                {
                    UTC = "+00:00",
                    Description = "(UTC +00:00) Las Palmas de Gran Canaria, Santa Cruz de Tenerife"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Madrid, Barcelona"
                },
                new StateTimeZone()
                {
                    UTC = "+05:30",
                    Description = "(UTC +05:30) Colombo, Dehiwala-Mount Lavinia"
                },
                new StateTimeZone()
                {
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Khartoum, Omdurman"
                },
                new StateTimeZone()
                {
                    UTC = "-03:00",
                    Description = "(UTC -03:00) Paramaribo, Lelydorp"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Longyearbyen"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Stockholm, Göteborg"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Zürich, Genève"
                },
                new StateTimeZone()
                {
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Aleppo, Damascus"
                },
                new StateTimeZone()
                {
                    UTC = "+08:00",
                    Description = "(UTC +08:00) Taipei, Kaohsiung"
                },
                new StateTimeZone()
                {
                    UTC = "+05:00",
                    Description = "(UTC +05:00) Dushanbe, Khujand"
                },
                new StateTimeZone()
                {
                    UTC = "+03:00",
                    Description = "(UTC +03:00) Dar es Salaam, Mwanza"
                },
                new StateTimeZone()
                {
                    UTC = "+07:00",
                    Description = "(UTC +07:00) Bangkok, Samut Prakan"
                },
                new StateTimeZone()
                {
                    UTC = "+09:00",
                    Description = "(UTC +09:00) Dili, Maliana"
                },
                new StateTimeZone()
                {
                    UTC = "+00:00",
                    Description = "(UTC +00:00) Lomé, Sokodé"
                },
                new StateTimeZone()
                {
                    UTC = "+13:00",
                    Description = "(UTC +13:00) Fakaofo"
                },
                new StateTimeZone()
                {
                    UTC = "+13:00",
                    Description = "(UTC +13:00) Nuku‘alofa"
                },
                new StateTimeZone()
                {
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Chaguanas, Mon Repos"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Tunis, Sfax"
                },
                new StateTimeZone()
                {
                    UTC = "+03:00",
                    Description = "(UTC +03:00) Istanbul, Ankara"
                },
                new StateTimeZone()
                {
                    UTC = "+05:00",
                    Description = "(UTC +05:00) Ashgabat, Türkmenabat"
                },
                new StateTimeZone()
                {
                    UTC = "-05:00",
                    Description = "(UTC -05:00) Cockburn Town"
                },
                new StateTimeZone()
                {
                    UTC = "+12:00",
                    Description = "(UTC +12:00) Funafuti"
                },
                new StateTimeZone()
                {
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Saint Croix, Charlotte Amalie"
                },
                new StateTimeZone()
                {
                    UTC = "+03:00",
                    Description = "(UTC +03:00) Kampala, Gulu"
                },
                new StateTimeZone()
                {
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Kyiv, Kharkiv"
                },
                new StateTimeZone()
                {
                    UTC = "+04:00",
                    Description = "(UTC +04:00) Dubai, Sharjah"
                },
                new StateTimeZone()
                {
                    UTC = "+00:00",
                    Description = "(UTC +00:00) London, Birmingham"
                },
                new StateTimeZone()
                {
                    UTC = "+12:00",
                    Description = "(UTC +12:00) Wake"
                },
                new StateTimeZone()
                {
                    UTC = "-11:00",
                    Description = "(UTC -11:00) Midway"
                },
                new StateTimeZone()
                {
                    UTC = "-05:00",
                    Description = "(UTC -05:00) New York City, Brooklyn"
                },
                new StateTimeZone()
                {
                    UTC = "-06:00",
                    Description = "(UTC -06:00) Chicago, Houston"
                },
                new StateTimeZone()
                {
                    UTC = "-07:00",
                    Description = "(UTC -07:00) Denver, El Paso"
                },
                new StateTimeZone()
                {
                    UTC = "-07:00",
                    Description = "(UTC -07:00) Phoenix, Tucson"
                },
                new StateTimeZone()
                {
                    UTC = "-08:00",
                    Description = "(UTC -08:00) Los Angeles, San Diego"
                },
                new StateTimeZone()
                {
                    UTC = "-09:00",
                    Description = "(UTC -09:00) Anchorage, Juneau"
                },
                new StateTimeZone()
                {
                    UTC = "-10:00",
                    Description = "(UTC -10:00) Adak"
                },
                new StateTimeZone()
                {
                    UTC = "-10:00",
                    Description = "(UTC -10:00) Honolulu, East Honolulu"
                },
                new StateTimeZone()
                {
                    UTC = "-03:00",
                    Description = "(UTC -03:00) Montevideo, Salto"
                },
                new StateTimeZone()
                {
                    UTC = "+05:00",
                    Description = "(UTC +05:00) Tashkent, Namangan"
                },
                new StateTimeZone()
                {
                    UTC = "+11:00",
                    Description = "(UTC +11:00) Port-Vila"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Vatican City"
                },
                new StateTimeZone()
                {
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Caracas, Maracaibo"
                },
                new StateTimeZone()
                {
                    UTC = "+07:00",
                    Description = "(UTC +07:00) Ho Chi Minh City, Da Nang"
                },
                new StateTimeZone()
                {
                    UTC = "+12:00",
                    Description = "(UTC +12:00) Mata-Utu"
                },
                new StateTimeZone()
                {
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Laayoune, Dakhla"
                },
                new StateTimeZone()
                {
                    UTC = "+03:00",
                    Description = "(UTC +03:00) Sanaa, Al Ḩudaydah"
                },
                new StateTimeZone()
                {
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Lusaka, Kitwe"
                },
                new StateTimeZone()
                {
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Harare, Bulawayo"
                }
            };

            return timeZones;
        }
    }
}