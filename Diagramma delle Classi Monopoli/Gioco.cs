﻿using System;
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

        public List<Carta> Carte
        {
            get
            {
                return _carteGioco;
            }
            private set
            {
                _carteGioco = value;
            }
        }

        public List<Proprieta> Proprieta
        {
            get
            {
                return _proprieta;
            }
            private set
            {
                _proprieta = value;
            }
        }

        public List<Probabilita> Probabilita
        {
            get
            {
                return _probabilita;
            }
            private set
            {
                _probabilita = value;
            }
        }

        public List<Imprevisto> Imprevisti
        {
            get
            {
                return _imprevisti;
            }
            private set
            {
                _imprevisti = value;
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

        public List<Proprieta> DiscretizzaProprieta(List<Carta> carte)
        {
            List<Proprieta> listaCarteProprieta = new List<Proprieta>();
            foreach(Carta carta in carte)
            {
                if(carta is Proprieta)
                {
                    listaCarteProprieta.Add(carta as Proprieta);
                }
            }
            return listaCarteProprieta;
        }

        public List<Probabilita> DiscretizzaProbabilita(List<Carta> carte)
        {
            List<Probabilita> listaCarteProbabilita = new List<Probabilita>();
            foreach (Carta carta in carte)
            {
                if (carta is Probabilita)
                {
                    listaCarteProbabilita.Add(carta as Probabilita);
                }
            }
            return listaCarteProbabilita;
        }

        public List<Imprevisto> DiscretizzaImprevisto(List<Carta> carte)
        {
            List<Imprevisto> listaCarteImprevisto = new List<Imprevisto>();
            foreach (Carta carta in carte)
            {
                if (carta is Imprevisto)
                {
                    listaCarteImprevisto.Add(carta as Imprevisto);
                }
            }
            return listaCarteImprevisto;
        }

    }
}