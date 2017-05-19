using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RetroMarket.Tests
{
    public class TaxesCanada
    {
        public enum Abbre
        {
            AB,
            BC,
            MB,
            NB,
            NL,
            NT,
            NS,
            NU,
            PE,
            ON,
            QC,
            SK,
            YT,
            Autre
        }
        public Abbre Destination { get; private set; }

        public float GST { get; private set; }

        public float PST { get; private set; }

        public TaxesCanada(Abbre exe)
        {
            switch (exe)
            {
                case Abbre.AB:
                    Destination = Abbre.AB;
                    GST = 0.05f;
                    PST = 0.00f;
                    break;
                case Abbre.BC:
                    Destination = Abbre.BC;
                    GST = 0.05f;
                    PST = 0.07f;
                    break;
                case Abbre.MB:
                    Destination = Abbre.MB;
                    GST = 0.05f;
                    PST = 0.08f;
                    break;
                case Abbre.NB:
                    Destination = Abbre.NB;
                    GST = 0.15f;
                    PST = 0.00f;
                    break;
                case Abbre.NL:
                    Destination = Abbre.NL;
                    GST = 0.15f;
                    PST = 0.00f;
                    break;
                case Abbre.NT:
                    Destination = Abbre.NT;
                    GST = 0.05f;
                    PST = 0.00f;
                    break;
                case Abbre.NS:
                    Destination = Abbre.NS;
                    GST = 0.15f;
                    PST = 0.00f;
                    break;
                case Abbre.NU:
                    Destination = Abbre.NU;
                    GST = 0.05f;
                    PST = 0.00f;
                    break;
                case Abbre.PE:
                    Destination = Abbre.PE;
                    GST = 0.15f;
                    PST = 0.00f;
                    break;
                case Abbre.ON:
                    Destination = Abbre.ON;
                    GST = 0.13f;
                    PST = 0.00f;
                    break;
                case Abbre.QC:
                    Destination = Abbre.QC;
                    GST = 0.05f;
                    PST = 0.10f;
                    break;
                case Abbre.SK:
                    Destination = Abbre.SK;
                    GST = 0.05f;
                    PST = 0.06f;
                    break;
                case Abbre.YT:
                    Destination = Abbre.YT;
                    GST = 0.05f;
                    PST = 0.00f;
                    break;
                case Abbre.Autre:
                    Destination = Abbre.Autre;
                    GST = 0.00f;
                    PST = 0.00f;
                    break;
                default:
                    break;
            }
        }
    }
}
