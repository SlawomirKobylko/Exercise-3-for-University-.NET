using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3
{
    public class Films : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        readonly static Dictionary<string, string[]> linkedProperties = new Dictionary<string, string[]>()
        {
            ["Title"] = new string[] { "Properties" },
            ["Director"] = new string[] { "Properties" },
            ["Studio"] = new string[] { "Properties" },
            ["Media"] = new string[] { "Properties" },
            ["DateofPremiere"] = new string[] { "Premiere" },
            ["Premiere"] = new string[] { "Properties" }
        };
        void OnPropertyChanged([CallerMemberName] string properties = null, HashSet<string> doneProperties = null)
        {
            if (doneProperties == null)
                doneProperties = new HashSet<string>();

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(properties));
            doneProperties.Add(properties);

            if (linkedProperties.ContainsKey(properties))
                foreach (string linkedProperties in linkedProperties[properties])
                    if (!doneProperties.Contains(linkedProperties))
                        OnPropertyChanged(linkedProperties, doneProperties);
        }
        DateTime dateofPremiere;
        string title, director, studio, media;
        public string Title { get => title; set { title = value; OnPropertyChanged(); } }
        public string Director { get => director; set { director = value; OnPropertyChanged(); } }
        public string Studio { get => studio; set { studio = value; OnPropertyChanged(); } }
        public string Media { get => media; set { media = value; OnPropertyChanged(); } }
        public string Title_ => $"{title}";
        public string Director_ =>$"{director}";
        public string Media_ => $"{media}";
        public string Studio_ => $"{studio}";

        public DateTime DateofPremiere
        {
            get => dateofPremiere;
            set
            {
                dateofPremiere = value;
                OnPropertyChanged();
            }
        }
        public string Premiere
        {
            get
            {
                if (dateofPremiere == null)
                    return "BD";
                else
                    return dateofPremiere.ToString("d");
            }
        }
        public string Properties => $"Tytuł: {Title_}, Reżyser: {Director_}, Studio filmowe: {Studio_}, Nośnik: {Media_}, Data premiery: {Premiere}";
        public Films(string name, string lastname, string studio, string media)
        {
            Title = name;
            Director = lastname;
            Studio = studio;
            Media = media;
        }
        public Films() { }
    }
}
