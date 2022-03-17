using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyPierCSharp
{
    public partial class Game : Form                  
    {
        int velocitàPipe = 8; //13 //25 velocita degli ostacoli
        int gravità = 8; //10 //20 //30 velocita della gravita
        int punteggio = 0;

        public Game()
        {
            InitializeComponent();
        }

        //game principale
        private void gameTimerEvento(object sender, EventArgs e)
        {
            flappy.Top += gravità; //aggiornamento della gravita

            //direzione verso sinistra e aggiornamento della velocita
            pipeBottom.Left -= velocitàPipe; 
            pipeTop.Left -= velocitàPipe;
            

            //assegnazione del punteggio
            score.Text = "passaggi conquistati " + punteggio;

            //generazione di nuovi ostacoli modificando il valore di grandezza (widht)
            if (pipeBottom.Left < -180) {pipeBottom.Left = 250; punteggio++; }
            if (pipeTop.Left < -195) {pipeTop.Left = 350; punteggio++; }

            if (punteggio > 2)
            {
                velocitàPipe = 12;
            }

            if (punteggio > 10)
            {
                velocitàPipe = 16;
                gravità = 14;
            }

            if (punteggio > 20)
            {
                velocitàPipe = 25;
                gravità = 23;
            }

            //evento per la collisione degli ostacoli con l'uccell
            if (flappy.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappy.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappy.Bounds.IntersectsWith(background.Bounds))
            {
                fineGioco();
            }

        }

        //eventi tasto 'space'
        private void tastoGiu(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space){gravità = -5;}
        }

        private void tastoSu(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space){gravità = 5;}
        }

        //evento 'fineGioco()'
        private void fineGioco()
        {
            gameTimer.Stop();
            score.Text += "   Game over";
        }
    }
}
