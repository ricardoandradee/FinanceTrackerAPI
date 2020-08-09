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
                    Country = "Afghanistan",
                    UTC = "+04:30",
                    Description = "(UTC +04:30) Kabul, Kandahār"
                },
                new StateTimeZone()
                {
                    Country = "Aland Islands",
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Mariehamn"
                },
                new StateTimeZone()
                {
                    Country = "Albania",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Tirana, Durrës"
                },
                new StateTimeZone()
                {
                    Country = "Algeria",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Algiers, Boumerdas"
                },
                new StateTimeZone()
                {
                    Country = "American Samoa",
                    UTC = "-11:00",
                    Description = "(UTC -11:00) Pago Pago"
                },
                new StateTimeZone()
                {
                    Country = "Andorra",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Andorra la Vella, les Escaldes"
                },
                new StateTimeZone()
                {
                    Country = "Angola",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Luanda, N’dalatando"
                },
                new StateTimeZone()
                {
                    Country = "Anguilla",
                    UTC = "-04:00",
                    Description = "(UTC -04:00) The Valley"
                },
                new StateTimeZone()
                {
                    Country = "Antarctica",
                    UTC = "+00:00",
                    Description = "(UTC +00:00) Troll"
                },
                new StateTimeZone()
                {
                    Country = "Antarctica",
                    UTC = "+03:00",
                    Description = "(UTC +03:00) Syowa"
                },
                new StateTimeZone()
                {
                    Country = "Antarctica",
                    UTC = "+05:00",
                    Description = "(UTC +05:00) Mawson"
                },
                new StateTimeZone()
                {
                    Country = "Antarctica",
                    UTC = "+06:00",
                    Description = "(UTC +06:00) Vostok"
                },
                new StateTimeZone()
                {
                    Country = "Antarctica",
                    UTC = "+07:00",
                    Description = "(UTC +07:00) Davis"
                },
                new StateTimeZone()
                {
                    Country = "Antarctica",
                    UTC = "+08:00",
                    Description = "(UTC +08:00) Casey"
                },
                new StateTimeZone()
                {
                    Country = "Antarctica",
                    UTC = "+10:00",
                    Description = "(UTC +10:00) DumontDUrville"
                },
                new StateTimeZone()
                {
                    Country = "Antarctica",
                    UTC = "+12:00",
                    Description = "(UTC +12:00) McMurdo"
                },
                new StateTimeZone()
                {
                    Country = "Antarctica",
                    UTC = "-03:00",
                    Description = "(UTC -03:00) Palmer, Rothera"
                },
                new StateTimeZone()
                {
                    Country = "Antigua and Barbuda",
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Saint John’s"
                },
                new StateTimeZone()
                {
                    Country = "Argentina",
                    UTC = "-03:00",
                    Description = "(UTC -03:00) Buenos Aires, Córdoba"
                },
                new StateTimeZone()
                {
                    Country = "Armenia",
                    UTC = "+04:00",
                    Description = "(UTC +04:00) Yerevan, Gyumri"
                },
                new StateTimeZone()
                {
                    Country = "Aruba",
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Oranjestad, Tanki Leendert"
                },
                new StateTimeZone()
                {
                    Country = "Australia",
                    UTC = "+08:00",
                    Description = "(UTC +08:00) Perth, Rockingham"
                },
                new StateTimeZone()
                {
                    Country = "Australia",
                    UTC = "+08:45",
                    Description = "(UTC +08:45) Eucla"
                },
                new StateTimeZone()
                {
                    Country = "Australia",
                    UTC = "+09:30",
                    Description = "(UTC +09:30) Adelaide, Adelaide Hills"
                },
                new StateTimeZone()
                {
                    Country = "Australia",
                    UTC = "+09:30",
                    Description = "(UTC +09:30) Darwin, Alice Springs"
                },
                new StateTimeZone()
                {
                    Country = "Australia",
                    UTC = "+10:00",
                    Description = "(UTC +10:00) Brisbane, Gold Coast"
                },
                new StateTimeZone()
                {
                    Country = "Australia",
                    UTC = "+10:00",
                    Description = "(UTC +10:00) Sydney, Melbourne"
                },
                new StateTimeZone()
                {
                    Country = "Australia",
                    UTC = "+10:30",
                    Description = "(UTC +10:30) Lord Howe"
                },
                new StateTimeZone()
                {
                    Country = "Australia",
                    UTC = "+11:00",
                    Description = "(UTC +11:00) Macquarie"
                },
                new StateTimeZone()
                {
                    Country = "Austria",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Vienna, Graz"
                },
                new StateTimeZone()
                {
                    Country = "Azerbaijan",
                    UTC = "+04:00",
                    Description = "(UTC +04:00) Baku, Ganja"
                },
                new StateTimeZone()
                {
                    Country = "Bahamas",
                    UTC = "-05:00",
                    Description = "(UTC -05:00) Nassau, Lucaya"
                },
                new StateTimeZone()
                {
                    Country = "Bahrain",
                    UTC = "+03:00",
                    Description = "(UTC +03:00) Manama, Al Muharraq"
                },
                new StateTimeZone()
                {
                    Country = "Bangladesh",
                    UTC = "+06:00",
                    Description = "(UTC +06:00) Dhaka, Chittagong"
                },
                new StateTimeZone()
                {
                    Country = "Barbados",
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Bridgetown"
                },
                new StateTimeZone()
                {
                    Country = "Belarus",
                    UTC = "+03:00",
                    Description = "(UTC +03:00) Minsk, Homyel'"
                },
                new StateTimeZone()
                {
                    Country = "Belgium",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Brussels, Antwerpen"
                },
                new StateTimeZone()
                {
                    Country = "Belize",
                    UTC = "-06:00",
                    Description = "(UTC -06:00) Belize City, San Ignacio"
                },
                new StateTimeZone()
                {
                    Country = "Benin",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Cotonou, Abomey-Calavi"
                },
                new StateTimeZone()
                {
                    Country = "Bermuda",
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Hamilton"
                },
                new StateTimeZone()
                {
                    Country = "Bhutan",
                    UTC = "+06:00",
                    Description = "(UTC +06:00) Thimphu, Punākha"
                },
                new StateTimeZone()
                {
                    Country = "Bolivia",
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Santa Cruz de la Sierra, Cochabamba"
                },
                new StateTimeZone()
                {
                    Country = "Bonaire, Saint Eustatius and Saba ",
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Kralendijk"
                },
                new StateTimeZone()
                {
                    Country = "Bosnia and Herzegovina",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Sarajevo, Banja Luka"
                },
                new StateTimeZone()
                {
                    Country = "Botswana",
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Gaborone, Francistown"
                },
                new StateTimeZone()
                {
                    Country = "Brazil",
                    UTC = "-02:00",
                    Description = "(UTC -02:00) Noronha"
                },
                new StateTimeZone()
                {
                    Country = "Brazil",
                    UTC = "-03:00",
                    Description = "(UTC -03:00) São Paulo, Rio de Janeiro"
                },
                new StateTimeZone()
                {
                    Country = "Brazil",
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Manaus, Campo Grande"
                },
                new StateTimeZone()
                {
                    Country = "Brazil",
                    UTC = "-05:00",
                    Description = "(UTC -05:00) Rio Branco, Cruzeiro do Sul"
                },
                new StateTimeZone()
                {
                    Country = "British Indian Ocean Territory",
                    UTC = "+06:00",
                    Description = "(UTC +06:00) Chagos"
                },
                new StateTimeZone()
                {
                    Country = "British Virgin Islands",
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Road Town"
                },
                new StateTimeZone()
                {
                    Country = "Brunei",
                    UTC = "+08:00",
                    Description = "(UTC +08:00) Bandar Seri Begawan, Kuala Belait"
                },
                new StateTimeZone()
                {
                    Country = "Bulgaria",
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Sofia, Plovdiv"
                },
                new StateTimeZone()
                {
                    Country = "Burkina Faso",
                    UTC = "+00:00",
                    Description = "(UTC +00:00) Ouagadougou, Bobo-Dioulasso"
                },
                new StateTimeZone()
                {
                    Country = "Burundi",
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Bujumbura, Muyinga"
                },
                new StateTimeZone()
                {
                    Country = "Cabo Verde",
                    UTC = "-01:00",
                    Description = "(UTC -01:00) Praia, Mindelo"
                },
                new StateTimeZone()
                {
                    Country = "Cambodia",
                    UTC = "+07:00",
                    Description = "(UTC +07:00) Phnom Penh, Takeo"
                },
                new StateTimeZone()
                {
                    Country = "Cameroon",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Douala, Yaoundé"
                },
                new StateTimeZone()
                {
                    Country = "Canada",
                    UTC = "-03:30",
                    Description = "(UTC -03:30) St. John's, Mount Pearl"
                },
                new StateTimeZone()
                {
                    Country = "Canada",
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Halifax, Moncton"
                },
                new StateTimeZone()
                {
                    Country = "Canada",
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Lévis"
                },
                new StateTimeZone()
                {
                    Country = "Canada",
                    UTC = "-05:00",
                    Description = "(UTC -05:00) Atikokan"
                },
                new StateTimeZone()
                {
                    Country = "Canada",
                    UTC = "-05:00",
                    Description = "(UTC -05:00) Toronto, Montréal"
                },
                new StateTimeZone()
                {
                    Country = "Canada",
                    UTC = "-06:00",
                    Description = "(UTC -06:00) Saskatoon, Regina"
                },
                new StateTimeZone()
                {
                    Country = "Canada",
                    UTC = "-06:00",
                    Description = "(UTC -06:00) Winnipeg, Brandon"
                },
                new StateTimeZone()
                {
                    Country = "Canada",
                    UTC = "-07:00",
                    Description = "(UTC -07:00) Calgary, Edmonton"
                },
                new StateTimeZone()
                {
                    Country = "Canada",
                    UTC = "-07:00",
                    Description = "(UTC -07:00) Fort St. John, Creston"
                },
                new StateTimeZone()
                {
                    Country = "Canada",
                    UTC = "-07:00",
                    Description = "(UTC -07:00) Whitehorse, Dawson"
                },
                new StateTimeZone()
                {
                    Country = "Canada",
                    UTC = "-08:00",
                    Description = "(UTC -08:00) Vancouver, Surrey"
                },
                new StateTimeZone()
                {
                    Country = "Cayman Islands",
                    UTC = "-05:00",
                    Description = "(UTC -05:00) George Town"
                },
                new StateTimeZone()
                {
                    Country = "Central African Republic",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Bangui, Bimbo"
                },
                new StateTimeZone()
                {
                    Country = "Chad",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) N'Djamena, Moundou"
                },
                new StateTimeZone()
                {
                    Country = "Chile",
                    UTC = "-03:00",
                    Description = "(UTC -03:00) Punta Arenas, Puerto Natales"
                },
                new StateTimeZone()
                {
                    Country = "Chile",
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Santiago, Puente Alto"
                },
                new StateTimeZone()
                {
                    Country = "Chile",
                    UTC = "-06:00",
                    Description = "(UTC -06:00) Easter"
                },
                new StateTimeZone()
                {
                    Country = "China",
                    UTC = "+06:00",
                    Description = "(UTC +06:00) Zhongshan, Ürümqi"
                },
                new StateTimeZone()
                {
                    Country = "China",
                    UTC = "+08:00",
                    Description = "(UTC +08:00) Shanghai, Beijing"
                },
                new StateTimeZone()
                {
                    Country = "Christmas Island",
                    UTC = "+07:00",
                    Description = "(UTC +07:00) Flying Fish Cove"
                },
                new StateTimeZone()
                {
                    Country = "Cocos Islands",
                    UTC = "+06:30",
                    Description = "(UTC +06:30) West Island"
                },
                new StateTimeZone()
                {
                    Country = "Colombia",
                    UTC = "-05:00",
                    Description = "(UTC -05:00) Bogotá, Cali"
                },
                new StateTimeZone()
                {
                    Country = "Comoros",
                    UTC = "+03:00",
                    Description = "(UTC +03:00) Moroni, Moutsamoudou"
                },
                new StateTimeZone()
                {
                    Country = "Cook Islands",
                    UTC = "-10:00",
                    Description = "(UTC -10:00) Avarua"
                },
                new StateTimeZone()
                {
                    Country = "Costa Rica",
                    UTC = "-06:00",
                    Description = "(UTC -06:00) San José, Limón"
                },
                new StateTimeZone()
                {
                    Country = "Croatia",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Zagreb, Split"
                },
                new StateTimeZone()
                {
                    Country = "Cuba",
                    UTC = "-05:00",
                    Description = "(UTC -05:00) Havana, Santiago de Cuba"
                },
                new StateTimeZone()
                {
                    Country = "Curacao",
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Willemstad"
                },
                new StateTimeZone()
                {
                    Country = "Cyprus",
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Nicosia, Limassol"
                },
                new StateTimeZone()
                {
                    Country = "Czechia",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Prague, Brno"
                },
                new StateTimeZone()
                {
                    Country = "Democratic Republic of the Congo",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Kinshasa, Masina"
                },
                new StateTimeZone()
                {
                    Country = "Democratic Republic of the Congo",
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Lubumbashi, Mbuji-Mayi"
                },
                new StateTimeZone()
                {
                    Country = "Denmark",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Copenhagen, Århus"
                },
                new StateTimeZone()
                {
                    Country = "Djibouti",
                    UTC = "+03:00",
                    Description = "(UTC +03:00) Djibouti, 'Ali Sabieh"
                },
                new StateTimeZone()
                {
                    Country = "Dominica",
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Roseau"
                },
                new StateTimeZone()
                {
                    Country = "Dominican Republic",
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Santo Domingo, Santiago de los Caballeros"
                },
                new StateTimeZone()
                {
                    Country = "Ecuador",
                    UTC = "-05:00",
                    Description = "(UTC -05:00) Guayaquil, Quito"
                },
                new StateTimeZone()
                {
                    Country = "Ecuador",
                    UTC = "-06:00",
                    Description = "(UTC -06:00) Galapagos"
                },
                new StateTimeZone()
                {
                    Country = "Egypt",
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Cairo, Alexandria"
                },
                new StateTimeZone()
                {
                    Country = "El Salvador",
                    UTC = "-06:00",
                    Description = "(UTC -06:00) San Salvador, Soyapango"
                },
                new StateTimeZone()
                {
                    Country = "Equatorial Guinea",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Bata, Malabo"
                },
                new StateTimeZone()
                {
                    Country = "Eritrea",
                    UTC = "+03:00",
                    Description = "(UTC +03:00) Asmara, Keren"
                },
                new StateTimeZone()
                {
                    Country = "Estonia",
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Tallinn, Tartu"
                },
                new StateTimeZone()
                {
                    Country = "Eswatini",
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Manzini, Mbabane"
                },
                new StateTimeZone()
                {
                    Country = "Ethiopia",
                    UTC = "+03:00",
                    Description = "(UTC +03:00) Addis Ababa, Dire Dawa"
                },
                new StateTimeZone()
                {
                    Country = "Falkland Islands",
                    UTC = "-03:00",
                    Description = "(UTC -03:00) Stanley"
                },
                new StateTimeZone()
                {
                    Country = "Faroe Islands",
                    UTC = "+00:00",
                    Description = "(UTC +00:00) Tórshavn"
                },
                new StateTimeZone()
                {
                    Country = "Fiji",
                    UTC = "+12:00",
                    Description = "(UTC +12:00) Suva, Lautoka"
                },
                new StateTimeZone()
                {
                    Country = "Finland",
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Helsinki, Espoo"
                },
                new StateTimeZone()
                {
                    Country = "France",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Paris, Marseille"
                },
                new StateTimeZone()
                {
                    Country = "French Guiana",
                    UTC = "-03:00",
                    Description = "(UTC -03:00) Cayenne, Matoury"
                },
                new StateTimeZone()
                {
                    Country = "French Polynesia",
                    UTC = "-09:00",
                    Description = "(UTC -09:00) Gambier"
                },
                new StateTimeZone()
                {
                    Country = "French Polynesia",
                    UTC = "-09:30",
                    Description = "(UTC -09:30) Marquesas"
                },
                new StateTimeZone()
                {
                    Country = "French Polynesia",
                    UTC = "-10:00",
                    Description = "(UTC -10:00) Faaa, Papeete"
                },
                new StateTimeZone()
                {
                    Country = "French Southern Territories",
                    UTC = "+05:00",
                    Description = "(UTC +05:00) Port-aux-Français"
                },
                new StateTimeZone()
                {
                    Country = "Gabon",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Libreville, Port-Gentil"
                },
                new StateTimeZone()
                {
                    Country = "Gambia",
                    UTC = "+00:00",
                    Description = "(UTC +00:00) Serekunda, Brikama"
                },
                new StateTimeZone()
                {
                    Country = "Georgia",
                    UTC = "+04:00",
                    Description = "(UTC +04:00) Tbilisi, Kutaisi"
                },
                new StateTimeZone()
                {
                    Country = "Germany",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Berlin, Hamburg"
                },
                new StateTimeZone()
                {
                    Country = "Ghana",
                    UTC = "+00:00",
                    Description = "(UTC +00:00) Accra, Kumasi"
                },
                new StateTimeZone()
                {
                    Country = "Gibraltar",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Gibraltar"
                },
                new StateTimeZone()
                {
                    Country = "Greece",
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Athens, Thessaloníki"
                },
                new StateTimeZone()
                {
                    Country = "Greenland",
                    UTC = "+00:00",
                    Description = "(UTC +00:00) Danmarkshavn"
                },
                new StateTimeZone()
                {
                    Country = "Greenland",
                    UTC = "-01:00",
                    Description = "(UTC -01:00) Scoresbysund"
                },
                new StateTimeZone()
                {
                    Country = "Greenland",
                    UTC = "-03:00",
                    Description = "(UTC -03:00) Nuuk"
                },
                new StateTimeZone()
                {
                    Country = "Greenland",
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Thule"
                },
                new StateTimeZone()
                {
                    Country = "Grenada",
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Saint George's"
                },
                new StateTimeZone()
                {
                    Country = "Guadeloupe",
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Les Abymes, Baie-Mahault"
                },
                new StateTimeZone()
                {
                    Country = "Guam",
                    UTC = "+10:00",
                    Description = "(UTC +10:00) Dededo Village, Yigo Village"
                },
                new StateTimeZone()
                {
                    Country = "Guatemala",
                    UTC = "-06:00",
                    Description = "(UTC -06:00) Guatemala City, Mixco"
                },
                new StateTimeZone()
                {
                    Country = "Guernsey",
                    UTC = "+00:00",
                    Description = "(UTC +00:00) Saint Peter Port"
                },
                new StateTimeZone()
                {
                    Country = "Guinea",
                    UTC = "+00:00",
                    Description = "(UTC +00:00) Camayenne, Conakry"
                },
                new StateTimeZone()
                {
                    Country = "Guinea-Bissau",
                    UTC = "+00:00",
                    Description = "(UTC +00:00) Bissau, Bafatá"
                },
                new StateTimeZone()
                {
                    Country = "Guyana",
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Georgetown, Linden"
                },
                new StateTimeZone()
                {
                    Country = "Haiti",
                    UTC = "-05:00",
                    Description = "(UTC -05:00) Port-au-Prince, Carrefour"
                },
                new StateTimeZone()
                {
                    Country = "Honduras",
                    UTC = "-06:00",
                    Description = "(UTC -06:00) Tegucigalpa, San Pedro Sula"
                },
                new StateTimeZone()
                {
                    Country = "Hong Kong",
                    UTC = "+08:00",
                    Description = "(UTC +08:00) Hong Kong, Kowloon"
                },
                new StateTimeZone()
                {
                    Country = "Hungary",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Budapest, Debrecen"
                },
                new StateTimeZone()
                {
                    Country = "Iceland",
                    UTC = "+00:00",
                    Description = "(UTC +00:00) Reykjavík, Kópavogur"
                },
                new StateTimeZone()
                {
                    Country = "India",
                    UTC = "+05:30",
                    Description = "(UTC +05:30) Mumbai, Delhi"
                },
                new StateTimeZone()
                {
                    Country = "Indonesia",
                    UTC = "+07:00",
                    Description = "(UTC +07:00) Jakarta, Surabaya"
                },
                new StateTimeZone()
                {
                    Country = "Indonesia",
                    UTC = "+08:00",
                    Description = "(UTC +08:00) Makassar, Denpasar"
                },
                new StateTimeZone()
                {
                    Country = "Indonesia",
                    UTC = "+09:00",
                    Description = "(UTC +09:00) Ambon, Jayapura"
                },
                new StateTimeZone()
                {
                    Country = "Iran",
                    UTC = "+03:30",
                    Description = "(UTC +03:30) Tehran, Mashhad"
                },
                new StateTimeZone()
                {
                    Country = "Iraq",
                    UTC = "+03:00",
                    Description = "(UTC +03:00) Baghdad, Basrah"
                },
                new StateTimeZone()
                {
                    Country = "Ireland",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Dublin, Cork"
                },
                new StateTimeZone()
                {
                    Country = "Isle of Man",
                    UTC = "+00:00",
                    Description = "(UTC +00:00) Douglas"
                },
                new StateTimeZone()
                {
                    Country = "Israel",
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Jerusalem, Tel Aviv"
                },
                new StateTimeZone()
                {
                    Country = "Italy",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Rome, Milan"
                },
                new StateTimeZone()
                {
                    Country = "Ivory Coast",
                    UTC = "+00:00",
                    Description = "(UTC +00:00) Abidjan, Abobo"
                },
                new StateTimeZone()
                {
                    Country = "Jamaica",
                    UTC = "-05:00",
                    Description = "(UTC -05:00) Kingston, New Kingston"
                },
                new StateTimeZone()
                {
                    Country = "Japan",
                    UTC = "+09:00",
                    Description = "(UTC +09:00) Tokyo, Yokohama"
                },
                new StateTimeZone()
                {
                    Country = "Jersey",
                    UTC = "+00:00",
                    Description = "(UTC +00:00) Saint Helier"
                },
                new StateTimeZone()
                {
                    Country = "Jordan",
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Amman, Zarqa"
                },
                new StateTimeZone()
                {
                    Country = "Kazakhstan",
                    UTC = "+05:00",
                    Description = "(UTC +05:00) Kyzylorda, Aktobe"
                },
                new StateTimeZone()
                {
                    Country = "Kazakhstan",
                    UTC = "+06:00",
                    Description = "(UTC +06:00) Almaty, Karagandy"
                },
                new StateTimeZone()
                {
                    Country = "Kenya",
                    UTC = "+03:00",
                    Description = "(UTC +03:00) Nairobi, Mombasa"
                },
                new StateTimeZone()
                {
                    Country = "Kiribati",
                    UTC = "+12:00",
                    Description = "(UTC +12:00) Tarawa"
                },
                new StateTimeZone()
                {
                    Country = "Kiribati",
                    UTC = "+13:00",
                    Description = "(UTC +13:00) Enderbury"
                },
                new StateTimeZone()
                {
                    Country = "Kiribati",
                    UTC = "+14:00",
                    Description = "(UTC +14:00) Kiritimati"
                },
                new StateTimeZone()
                {
                    Country = "Kuwait",
                    UTC = "+03:00",
                    Description = "(UTC +03:00) Al Aḩmadī, Ḩawallī"
                },
                new StateTimeZone()
                {
                    Country = "Kyrgyzstan",
                    UTC = "+06:00",
                    Description = "(UTC +06:00) Bishkek, Osh"
                },
                new StateTimeZone()
                {
                    Country = "Laos",
                    UTC = "+07:00",
                    Description = "(UTC +07:00) Vientiane, Pakse"
                },
                new StateTimeZone()
                {
                    Country = "Latvia",
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Riga, Daugavpils"
                },
                new StateTimeZone()
                {
                    Country = "Lebanon",
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Beirut, Ra’s Bayrūt"
                },
                new StateTimeZone()
                {
                    Country = "Lesotho",
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Maseru, Mafeteng"
                },
                new StateTimeZone()
                {
                    Country = "Liberia",
                    UTC = "+00:00",
                    Description = "(UTC +00:00) Monrovia, Gbarnga"
                },
                new StateTimeZone()
                {
                    Country = "Libya",
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Tripoli, Benghazi"
                },
                new StateTimeZone()
                {
                    Country = "Liechtenstein",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Vaduz"
                },
                new StateTimeZone()
                {
                    Country = "Lithuania",
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Vilnius, Kaunas"
                },
                new StateTimeZone()
                {
                    Country = "Luxembourg",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Luxembourg, Esch-sur-Alzette"
                },
                new StateTimeZone()
                {
                    Country = "Macao",
                    UTC = "+08:00",
                    Description = "(UTC +08:00) Macau"
                },
                new StateTimeZone()
                {
                    Country = "Madagascar",
                    UTC = "+03:00",
                    Description = "(UTC +03:00) Antananarivo, Toamasina"
                },
                new StateTimeZone()
                {
                    Country = "Malawi",
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Lilongwe, Blantyre"
                },
                new StateTimeZone()
                {
                    Country = "Malaysia",
                    UTC = "+08:00",
                    Description = "(UTC +08:00) Kota Bharu, Kuala Lumpur"
                },
                new StateTimeZone()
                {
                    Country = "Maldives",
                    UTC = "+05:00",
                    Description = "(UTC +05:00) Male"
                },
                new StateTimeZone()
                {
                    Country = "Mali",
                    UTC = "+00:00",
                    Description = "(UTC +00:00) Bamako, Sikasso"
                },
                new StateTimeZone()
                {
                    Country = "Malta",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Birkirkara, Qormi"
                },
                new StateTimeZone()
                {
                    Country = "Marshall Islands",
                    UTC = "+12:00",
                    Description = "(UTC +12:00) Majuro, Kwajalein"
                },
                new StateTimeZone()
                {
                    Country = "Martinique",
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Fort-de-France, Le Lamentin"
                },
                new StateTimeZone()
                {
                    Country = "Mauritania",
                    UTC = "+00:00",
                    Description = "(UTC +00:00) Nouakchott, Nouadhibou"
                },
                new StateTimeZone()
                {
                    Country = "Mauritius",
                    UTC = "+04:00",
                    Description = "(UTC +04:00) Port Louis, Beau Bassin-Rose Hill"
                },
                new StateTimeZone()
                {
                    Country = "Mayotte",
                    UTC = "+03:00",
                    Description = "(UTC +03:00) Mamoudzou, Koungou"
                },
                new StateTimeZone()
                {
                    Country = "Mexico",
                    UTC = "-05:00",
                    Description = "(UTC -05:00) Cancún, Chetumal"
                },
                new StateTimeZone()
                {
                    Country = "Mexico",
                    UTC = "-06:00",
                    Description = "(UTC -06:00) Mexico City, Iztapalapa"
                },
                new StateTimeZone()
                {
                    Country = "Mexico",
                    UTC = "-07:00",
                    Description = "(UTC -07:00) Ciudad Juárez, Chihuahua"
                },
                new StateTimeZone()
                {
                    Country = "Mexico",
                    UTC = "-07:00",
                    Description = "(UTC -07:00) Hermosillo, Ciudad Obregón"
                },
                new StateTimeZone()
                {
                    Country = "Mexico",
                    UTC = "-08:00",
                    Description = "(UTC -08:00) Tijuana, Mexicali"
                },
                new StateTimeZone()
                {
                    Country = "Micronesia",
                    UTC = "+10:00",
                    Description = "(UTC +10:00) Chuuk"
                },
                new StateTimeZone()
                {
                    Country = "Micronesia",
                    UTC = "+11:00",
                    Description = "(UTC +11:00) Kosrae, Palikir - National Government Center"
                },
                new StateTimeZone()
                {
                    Country = "Moldova",
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Chisinau, Tiraspol"
                },
                new StateTimeZone()
                {
                    Country = "Monaco",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Monaco, Monte-Carlo"
                },
                new StateTimeZone()
                {
                    Country = "Mongolia",
                    UTC = "+07:00",
                    Description = "(UTC +07:00) Khovd, Ölgii"
                },
                new StateTimeZone()
                {
                    Country = "Mongolia",
                    UTC = "+08:00",
                    Description = "(UTC +08:00) Ulan Bator, Erdenet"
                },
                new StateTimeZone()
                {
                    Country = "Montenegro",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Podgorica, Nikšić"
                },
                new StateTimeZone()
                {
                    Country = "Montserrat",
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Brades, Plymouth"
                },
                new StateTimeZone()
                {
                    Country = "Morocco",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Casablanca, Rabat"
                },
                new StateTimeZone()
                {
                    Country = "Mozambique",
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Maputo, Matola"
                },
                new StateTimeZone()
                {
                    Country = "Myanmar",
                    UTC = "+06:30",
                    Description = "(UTC +06:30) Yangon, Mandalay"
                },
                new StateTimeZone()
                {
                    Country = "Namibia",
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Windhoek, Rundu"
                },
                new StateTimeZone()
                {
                    Country = "Nauru",
                    UTC = "+12:00",
                    Description = "(UTC +12:00) Yaren"
                },
                new StateTimeZone()
                {
                    Country = "Nepal",
                    UTC = "+05:45",
                    Description = "(UTC +05:45) Kathmandu, Pokhara"
                },
                new StateTimeZone()
                {
                    Country = "Netherlands",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Amsterdam, Rotterdam"
                },
                new StateTimeZone()
                {
                    Country = "New Caledonia",
                    UTC = "+11:00",
                    Description = "(UTC +11:00) Nouméa, Mont-Dore"
                },
                new StateTimeZone()
                {
                    Country = "New Zealand",
                    UTC = "+12:00",
                    Description = "(UTC +12:00) Auckland, Wellington"
                },
                new StateTimeZone()
                {
                    Country = "New Zealand",
                    UTC = "+12:45",
                    Description = "(UTC +12:45) Chatham"
                },
                new StateTimeZone()
                {
                    Country = "Nicaragua",
                    UTC = "-06:00",
                    Description = "(UTC -06:00) Managua, León"
                },
                new StateTimeZone()
                {
                    Country = "Niger",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Niamey, Zinder"
                },
                new StateTimeZone()
                {
                    Country = "Nigeria",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Lagos, Kano"
                },
                new StateTimeZone()
                {
                    Country = "Niue",
                    UTC = "-11:00",
                    Description = "(UTC -11:00) Alofi"
                },
                new StateTimeZone()
                {
                    Country = "Norfolk Island",
                    UTC = "+11:00",
                    Description = "(UTC +11:00) Kingston"
                },
                new StateTimeZone()
                {
                    Country = "North Korea",
                    UTC = "+09:00",
                    Description = "(UTC +09:00) Pyongyang, Hamhŭng"
                },
                new StateTimeZone()
                {
                    Country = "North Macedonia",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Skopje, Bitola"
                },
                new StateTimeZone()
                {
                    Country = "Northern Mariana Islands",
                    UTC = "+10:00",
                    Description = "(UTC +10:00) Saipan"
                },
                new StateTimeZone()
                {
                    Country = "Norway",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Oslo, Bergen"
                },
                new StateTimeZone()
                {
                    Country = "Oman",
                    UTC = "+04:00",
                    Description = "(UTC +04:00) Muscat, Seeb"
                },
                new StateTimeZone()
                {
                    Country = "Pakistan",
                    UTC = "+05:00",
                    Description = "(UTC +05:00) Karachi, Lahore"
                },
                new StateTimeZone()
                {
                    Country = "Palau",
                    UTC = "+09:00",
                    Description = "(UTC +09:00) Ngerulmud"
                },
                new StateTimeZone()
                {
                    Country = "Palestinian Territory",
                    UTC = "+02:00",
                    Description = "(UTC +02:00) East Jerusalem, Gaza"
                },
                new StateTimeZone()
                {
                    Country = "Panama",
                    UTC = "-05:00",
                    Description = "(UTC -05:00) Panamá, San Miguelito"
                },
                new StateTimeZone()
                {
                    Country = "Papua New Guinea",
                    UTC = "+10:00",
                    Description = "(UTC +10:00) Port Moresby, Lae"
                },
                new StateTimeZone()
                {
                    Country = "Papua New Guinea",
                    UTC = "+11:00",
                    Description = "(UTC +11:00) Arawa"
                },
                new StateTimeZone()
                {
                    Country = "Paraguay",
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Asunción, Ciudad del Este"
                },
                new StateTimeZone()
                {
                    Country = "Peru",
                    UTC = "-05:00",
                    Description = "(UTC -05:00) Lima, Arequipa"
                },
                new StateTimeZone()
                {
                    Country = "Philippines",
                    UTC = "+08:00",
                    Description = "(UTC +08:00) Quezon City, Manila"
                },
                new StateTimeZone()
                {
                    Country = "Pitcairn",
                    UTC = "-08:00",
                    Description = "(UTC -08:00) Adamstown"
                },
                new StateTimeZone()
                {
                    Country = "Poland",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Warsaw, Łódź"
                },
                new StateTimeZone()
                {
                    Country = "Portugal",
                    UTC = "+00:00",
                    Description = "(UTC +00:00) Lisbon, Porto"
                },
                new StateTimeZone()
                {
                    Country = "Portugal",
                    UTC = "-01:00",
                    Description = "(UTC -01:00) Ponta Delgada"
                },
                new StateTimeZone()
                {
                    Country = "Puerto Rico",
                    UTC = "-04:00",
                    Description = "(UTC -04:00) San Juan, Bayamón"
                },
                new StateTimeZone()
                {
                    Country = "Qatar",
                    UTC = "+03:00",
                    Description = "(UTC +03:00) Doha, Ar Rayyān"
                },
                new StateTimeZone()
                {
                    Country = "Republic of the Congo",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Brazzaville, Pointe-Noire"
                },
                new StateTimeZone()
                {
                    Country = "Reunion",
                    UTC = "+04:00",
                    Description = "(UTC +04:00) Saint-Denis, Saint-Paul"
                },
                new StateTimeZone()
                {
                    Country = "Romania",
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Bucharest, Sector 3"
                },
                new StateTimeZone()
                {
                    Country = "Russia",
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Kaliningrad, Chernyakhovsk"
                },
                new StateTimeZone()
                {
                    Country = "Russia",
                    UTC = "+03:00",
                    Description = "(UTC +03:00) Moscow, Saint Petersburg"
                },
                new StateTimeZone()
                {
                    Country = "Russia",
                    UTC = "+04:00",
                    Description = "(UTC +04:00) Samara, Volgograd"
                },
                new StateTimeZone()
                {
                    Country = "Russia",
                    UTC = "+05:00",
                    Description = "(UTC +05:00) Yekaterinburg, Chelyabinsk"
                },
                new StateTimeZone()
                {
                    Country = "Russia",
                    UTC = "+06:00",
                    Description = "(UTC +06:00) Omsk, Tara"
                },
                new StateTimeZone()
                {
                    Country = "Russia",
                    UTC = "+07:00",
                    Description = "(UTC +07:00) Novosibirsk, Krasnoyarsk"
                },
                new StateTimeZone()
                {
                    Country = "Russia",
                    UTC = "+08:00",
                    Description = "(UTC +08:00) Irkutsk, Ulan-Ude"
                },
                new StateTimeZone()
                {
                    Country = "Russia",
                    UTC = "+09:00",
                    Description = "(UTC +09:00) Chita, Yakutsk"
                },
                new StateTimeZone()
                {
                    Country = "Russia",
                    UTC = "+10:00",
                    Description = "(UTC +10:00) Vladivostok, Khabarovsk"
                },
                new StateTimeZone()
                {
                    Country = "Russia",
                    UTC = "+11:00",
                    Description = "(UTC +11:00) Yuzhno-Sakhalinsk, Magadan"
                },
                new StateTimeZone()
                {
                    Country = "Russia",
                    UTC = "+12:00",
                    Description = "(UTC +12:00) Petropavlovsk-Kamchatsky, Yelizovo"
                },
                new StateTimeZone()
                {
                    Country = "Rwanda",
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Kigali, Butare"
                },
                new StateTimeZone()
                {
                    Country = "Saint Barthelemy",
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Gustavia"
                },
                new StateTimeZone()
                {
                    Country = "Saint Helena",
                    UTC = "+00:00",
                    Description = "(UTC +00:00) Jamestown"
                },
                new StateTimeZone()
                {
                    Country = "Saint Kitts and Nevis",
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Basseterre"
                },
                new StateTimeZone()
                {
                    Country = "Saint Lucia",
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Castries"
                },
                new StateTimeZone()
                {
                    Country = "Saint Martin",
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Marigot"
                },
                new StateTimeZone()
                {
                    Country = "Saint Pierre and Miquelon",
                    UTC = "-03:00",
                    Description = "(UTC -03:00) Saint-Pierre"
                },
                new StateTimeZone()
                {
                    Country = "Saint Vincent and the Grenadines",
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Kingstown, Kingstown Park"
                },
                new StateTimeZone()
                {
                    Country = "Samoa",
                    UTC = "+13:00",
                    Description = "(UTC +13:00) Apia"
                },
                new StateTimeZone()
                {
                    Country = "San Marino",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) San Marino"
                },
                new StateTimeZone()
                {
                    Country = "Sao Tome and Principe",
                    UTC = "+00:00",
                    Description = "(UTC +00:00) São Tomé"
                },
                new StateTimeZone()
                {
                    Country = "Saudi Arabia",
                    UTC = "+03:00",
                    Description = "(UTC +03:00) Riyadh, Jeddah"
                },
                new StateTimeZone()
                {
                    Country = "Senegal",
                    UTC = "+00:00",
                    Description = "(UTC +00:00) Dakar, Pikine"
                },
                new StateTimeZone()
                {
                    Country = "Serbia",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Belgrade, Niš"
                },
                new StateTimeZone()
                {
                    Country = "Seychelles",
                    UTC = "+04:00",
                    Description = "(UTC +04:00) Victoria"
                },
                new StateTimeZone()
                {
                    Country = "Sierra Leone",
                    UTC = "+00:00",
                    Description = "(UTC +00:00) Freetown, Bo"
                },
                new StateTimeZone()
                {
                    Country = "Singapore",
                    UTC = "+08:00",
                    Description = "(UTC +08:00) Singapore, Woodlands"
                },
                new StateTimeZone()
                {
                    Country = "Sint Maarten",
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Philipsburg"
                },
                new StateTimeZone()
                {
                    Country = "Slovakia",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Bratislava, Košice"
                },
                new StateTimeZone()
                {
                    Country = "Slovenia",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Ljubljana, Maribor"
                },
                new StateTimeZone()
                {
                    Country = "Solomon Islands",
                    UTC = "+11:00",
                    Description = "(UTC +11:00) Honiara"
                },
                new StateTimeZone()
                {
                    Country = "Somalia",
                    UTC = "+03:00",
                    Description = "(UTC +03:00) Mogadishu, Hargeysa"
                },
                new StateTimeZone()
                {
                    Country = "South Africa",
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Cape Town, Durban"
                },
                new StateTimeZone()
                {
                    Country = "South Georgia and the South Sandwich Islands",
                    UTC = "-02:00",
                    Description = "(UTC -02:00) Grytviken"
                },
                new StateTimeZone()
                {
                    Country = "South Korea",
                    UTC = "+09:00",
                    Description = "(UTC +09:00) Seoul, Busan"
                },
                new StateTimeZone()
                {
                    Country = "South Sudan",
                    UTC = "+03:00",
                    Description = "(UTC +03:00) Juba, Winejok"
                },
                new StateTimeZone()
                {
                    Country = "Spain",
                    UTC = "+00:00",
                    Description = "(UTC +00:00) Las Palmas de Gran Canaria, Santa Cruz de Tenerife"
                },
                new StateTimeZone()
                {
                    Country = "Spain",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Madrid, Barcelona"
                },
                new StateTimeZone()
                {
                    Country = "Sri Lanka",
                    UTC = "+05:30",
                    Description = "(UTC +05:30) Colombo, Dehiwala-Mount Lavinia"
                },
                new StateTimeZone()
                {
                    Country = "Sudan",
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Khartoum, Omdurman"
                },
                new StateTimeZone()
                {
                    Country = "Suriname",
                    UTC = "-03:00",
                    Description = "(UTC -03:00) Paramaribo, Lelydorp"
                },
                new StateTimeZone()
                {
                    Country = "Svalbard and Jan Mayen",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Longyearbyen"
                },
                new StateTimeZone()
                {
                    Country = "Sweden",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Stockholm, Göteborg"
                },
                new StateTimeZone()
                {
                    Country = "Switzerland",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Zürich, Genève"
                },
                new StateTimeZone()
                {
                    Country = "Syria",
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Aleppo, Damascus"
                },
                new StateTimeZone()
                {
                    Country = "Taiwan",
                    UTC = "+08:00",
                    Description = "(UTC +08:00) Taipei, Kaohsiung"
                },
                new StateTimeZone()
                {
                    Country = "Tajikistan",
                    UTC = "+05:00",
                    Description = "(UTC +05:00) Dushanbe, Khujand"
                },
                new StateTimeZone()
                {
                    Country = "Tanzania",
                    UTC = "+03:00",
                    Description = "(UTC +03:00) Dar es Salaam, Mwanza"
                },
                new StateTimeZone()
                {
                    Country = "Thailand",
                    UTC = "+07:00",
                    Description = "(UTC +07:00) Bangkok, Samut Prakan"
                },
                new StateTimeZone()
                {
                    Country = "Timor Leste",
                    UTC = "+09:00",
                    Description = "(UTC +09:00) Dili, Maliana"
                },
                new StateTimeZone()
                {
                    Country = "Togo",
                    UTC = "+00:00",
                    Description = "(UTC +00:00) Lomé, Sokodé"
                },
                new StateTimeZone()
                {
                    Country = "Tokelau",
                    UTC = "+13:00",
                    Description = "(UTC +13:00) Fakaofo"
                },
                new StateTimeZone()
                {
                    Country = "Tonga",
                    UTC = "+13:00",
                    Description = "(UTC +13:00) Nuku‘alofa"
                },
                new StateTimeZone()
                {
                    Country = "Trinidad and Tobago",
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Chaguanas, Mon Repos"
                },
                new StateTimeZone()
                {
                    Country = "Tunisia",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Tunis, Sfax"
                },
                new StateTimeZone()
                {
                    Country = "Turkey",
                    UTC = "+03:00",
                    Description = "(UTC +03:00) Istanbul, Ankara"
                },
                new StateTimeZone()
                {
                    Country = "Turkmenistan",
                    UTC = "+05:00",
                    Description = "(UTC +05:00) Ashgabat, Türkmenabat"
                },
                new StateTimeZone()
                {
                    Country = "Turks and Caicos Islands",
                    UTC = "-05:00",
                    Description = "(UTC -05:00) Cockburn Town"
                },
                new StateTimeZone()
                {
                    Country = "Tuvalu",
                    UTC = "+12:00",
                    Description = "(UTC +12:00) Funafuti"
                },
                new StateTimeZone()
                {
                    Country = "U.S. Virgin Islands",
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Saint Croix, Charlotte Amalie"
                },
                new StateTimeZone()
                {
                    Country = "Uganda",
                    UTC = "+03:00",
                    Description = "(UTC +03:00) Kampala, Gulu"
                },
                new StateTimeZone()
                {
                    Country = "Ukraine",
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Kyiv, Kharkiv"
                },
                new StateTimeZone()
                {
                    Country = "United Arab Emirates",
                    UTC = "+04:00",
                    Description = "(UTC +04:00) Dubai, Sharjah"
                },
                new StateTimeZone()
                {
                    Country = "United Kingdom",
                    UTC = "+00:00",
                    Description = "(UTC +00:00) London, Birmingham"
                },
                new StateTimeZone()
                {
                    Country = "United States Minor Outlying Islands",
                    UTC = "+12:00",
                    Description = "(UTC +12:00) Wake"
                },
                new StateTimeZone()
                {
                    Country = "United States Minor Outlying Islands",
                    UTC = "-11:00",
                    Description = "(UTC -11:00) Midway"
                },
                new StateTimeZone()
                {
                    Country = "United States",
                    UTC = "-05:00",
                    Description = "(UTC -05:00) New York City, Brooklyn"
                },
                new StateTimeZone()
                {
                    Country = "United States",
                    UTC = "-06:00",
                    Description = "(UTC -06:00) Chicago, Houston"
                },
                new StateTimeZone()
                {
                    Country = "United States",
                    UTC = "-07:00",
                    Description = "(UTC -07:00) Denver, El Paso"
                },
                new StateTimeZone()
                {
                    Country = "United States",
                    UTC = "-07:00",
                    Description = "(UTC -07:00) Phoenix, Tucson"
                },
                new StateTimeZone()
                {
                    Country = "United States",
                    UTC = "-08:00",
                    Description = "(UTC -08:00) Los Angeles, San Diego"
                },
                new StateTimeZone()
                {
                    Country = "United States",
                    UTC = "-09:00",
                    Description = "(UTC -09:00) Anchorage, Juneau"
                },
                new StateTimeZone()
                {
                    Country = "United States",
                    UTC = "-10:00",
                    Description = "(UTC -10:00) Adak"
                },
                new StateTimeZone()
                {
                    Country = "United States",
                    UTC = "-10:00",
                    Description = "(UTC -10:00) Honolulu, East Honolulu"
                },
                new StateTimeZone()
                {
                    Country = "Uruguay",
                    UTC = "-03:00",
                    Description = "(UTC -03:00) Montevideo, Salto"
                },
                new StateTimeZone()
                {
                    Country = "Uzbekistan",
                    UTC = "+05:00",
                    Description = "(UTC +05:00) Tashkent, Namangan"
                },
                new StateTimeZone()
                {
                    Country = "Vanuatu",
                    UTC = "+11:00",
                    Description = "(UTC +11:00) Port-Vila"
                },
                new StateTimeZone()
                {
                    Country = "Vatican",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Vatican City"
                },
                new StateTimeZone()
                {
                    Country = "Venezuela",
                    UTC = "-04:00",
                    Description = "(UTC -04:00) Caracas, Maracaibo"
                },
                new StateTimeZone()
                {
                    Country = "Vietnam",
                    UTC = "+07:00",
                    Description = "(UTC +07:00) Ho Chi Minh City, Da Nang"
                },
                new StateTimeZone()
                {
                    Country = "Wallis and Futuna",
                    UTC = "+12:00",
                    Description = "(UTC +12:00) Mata-Utu"
                },
                new StateTimeZone()
                {
                    Country = "Western Sahara",
                    UTC = "+01:00",
                    Description = "(UTC +01:00) Laayoune, Dakhla"
                },
                new StateTimeZone()
                {
                    Country = "Yemen",
                    UTC = "+03:00",
                    Description = "(UTC +03:00) Sanaa, Al Ḩudaydah"
                },
                new StateTimeZone()
                {
                    Country = "Zambia",
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Lusaka, Kitwe"
                },
                new StateTimeZone()
                {
                    Country = "Zimbabwe",
                    UTC = "+02:00",
                    Description = "(UTC +02:00) Harare, Bulawayo"
                }
            };

            return timeZones;
        }
    }
}
