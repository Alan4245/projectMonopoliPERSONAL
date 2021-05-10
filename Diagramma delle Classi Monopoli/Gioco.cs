using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Xml.Serialization;
using System.IO;

namespace Diagramma_delle_Classi_Monopoli
{
    public class Gioco
    {
        private Giocatore _giocatore;
        List<Carta> _carteGioco;
        List<Proprieta> _proprieta;
        List<Probabilita> _probabilita;
        List<Imprevisto> _imprevisti;

        public Gioco(Giocatore giocatore)
        {
            _giocatore = giocatore;
            _carteGioco = Deserializzazione();
        }

        Giocatore Ggiocatore
        {
            get
            {
                return _giocatore;
            }
        }

        public List<Carta> Deserializzazione()
        {
            List<Carta> nuovoVideogioco = new List<Carta>();

            if (!File.Exists("carte.xml"))
                throw new FileNotFoundException("File non esistente");

            XmlSerializer serializer = new XmlSerializer(typeof(List<Carta>));

            using (Stream reader = new FileStream("carte.xml", FileMode.Open))
            {
                nuovoVideogioco = (List<Carta>)serializer.Deserialize(reader);
            }

            return nuovoVideogioco;
        }

    }
}