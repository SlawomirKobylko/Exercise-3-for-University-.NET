using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Exercise_3
{
    class Model
    {
        public ObservableCollection<Films> Films { get; set; } = new ObservableCollection<Films>();
        public Model()
        {
            Films.Add(new Films("Top Gun", "Tony Scott", "Paramount Pictures", "DVD") { DateofPremiere = DateTime.Parse("01.10.1986")});
            Films.Add(new Films("Spiderman", "Jon Watts", "Marvel", "CD") { DateofPremiere = DateTime.Parse("10.10.2013")});
            Films.Add(new Films("Titanic", "James Cameron", "Paramount Pictures", "Cassette") { DateofPremiere = DateTime.Parse("20.12.1997")});
            Films.Add(new Films("Batman", "Bill Finger", "Marvel", "DVD") { DateofPremiere = DateTime.Parse("14.02.2016")});
            Films.Add(new Films("The Green Mile", "Frank Darabond", "Warner Bros Pictures", "DVD") { DateofPremiere = DateTime.Parse("01.01.1999") });
        }

        public Films AddnewPerson()
        {
            Films newPerson = new Films();
            Films.Add(newPerson);
            return newPerson;
        }
        public void Serialize_()
        {
            XmlSerializer s = new XmlSerializer(typeof(ObservableCollection<Films>));
            TextWriter w = new StreamWriter("output.xml");
            s.Serialize(w, Films);
            w.Close();
        }
    }
}
