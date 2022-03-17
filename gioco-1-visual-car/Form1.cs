using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualCar_
{


    public partial class Game : Form
    {
        public Game()
        {
            InitializeComponent();
            fineGioco.Visible = false;
        }

        int velocità = 10;

        //script principale di gioco
        private void gameTimerEvento(object sender, EventArgs e)
        {
            movStrisceCentrali(velocità);
            ostacolo(velocità);
            monete(velocità);
            prendiMonete();

            score.Text = "Punteggio: " + punteggio;

            perso();
        }

        int punteggio = 0;

        void prendiMonete()
        {
            if (macchina.Bounds.IntersectsWith(coin1.Bounds))
            {coin1.Hide(); punteggio++; }

            if (macchina.Bounds.IntersectsWith(coin2.Bounds))
            { coin2.Hide(); punteggio++; }

            if (macchina.Bounds.IntersectsWith(coin3.Bounds))
            { coin3.Hide(); punteggio++; }

        }

        void perso()
        {
            if(macchina.Bounds.IntersectsWith(margineDestro.Bounds) ||
              macchina.Bounds.IntersectsWith(margineSinistro.Bounds) ||
              macchina.Bounds.IntersectsWith(ostacolo1.Bounds) ||
              macchina.Bounds.IntersectsWith(ostacolo2.Bounds) ||
              macchina.Bounds.IntersectsWith(ostacolo3.Bounds) ||
              macchina.Bounds.IntersectsWith(ostacolo4.Bounds) ||
              macchina.Bounds.IntersectsWith(ostacolo5.Bounds))
             
            {
                fineGioco.Visible = true;
                gameTimer.Stop();
                
            }
        }

        Random coordRandom = new Random();
        int x, y;

        void monete(int velocità)
        {
            if (coin1.Top >= 800)
            {
                x = coordRandom.Next(0, 400);
                y = coordRandom.Next(0, 500);
                coin1.Location = new Point(x, y);
            }
            else
            { coin1.Top += velocità; }

            if (coin2.Top >= 800)
            {
                x = coordRandom.Next(0, 400);
                y = coordRandom.Next(0, 500);
                coin2.Location = new Point(x, y);
            }
            else
            { coin2.Top += velocità; }

            if (coin3.Top >= 800)
            {
                x = coordRandom.Next(0, 400);
                y = coordRandom.Next(0, 500);
                coin3.Location = new Point(x, y);
            }
            else
            { coin3.Top += velocità; }
        }

        void ostacolo(int velocità)
        {
            //generazione di coordinate casuali x;y

            if (ostacolo1.Top >= 800)
            {
                x = coordRandom.Next(0, 400);
                y = coordRandom.Next(0, 500);
                ostacolo1.Location = new Point(x, y);
            }
            else
            { ostacolo1.Top += velocità; }

            if (ostacolo2.Top >= 800)
            {
                x = coordRandom.Next(0, 400);
                y = coordRandom.Next(0, 500);
                ostacolo2.Location = new Point(x, y);
            }
            else
            { ostacolo2.Top += velocità; }

            if (ostacolo3.Top >= 800)
            {
                x = coordRandom.Next(0, 400);
                y = coordRandom.Next(0, 500);
                ostacolo3.Location = new Point(x, y);
            }
            else
            { ostacolo3.Top += velocità; }

            if (ostacolo4.Top >= 800)
            {
                x = coordRandom.Next(0, 400);
                y = coordRandom.Next(0, 500);
                ostacolo4.Location = new Point(x, y);
            }
            else
            { ostacolo4.Top += velocità; }

            if (ostacolo5.Top >= 800)
            {
                x = coordRandom.Next(0, 400);
                y = coordRandom.Next(0, 500);
                ostacolo5.Location = new Point(x, y);
            }
            else
            { ostacolo5.Top += velocità; }
        }


        void movStrisceCentrali(int velocità)
        {
            //movimento delle strisce centarli

            if (striscia1.Top >= 800)
            { striscia1.Top = 0;}
            else
            { striscia1.Top += velocità; }

            if (striscia2.Top >= 800)
            { striscia2.Top = 0; }
            else
            { striscia2.Top += velocità; }

            if (striscia3.Top >= 800)
            { striscia3.Top = 0; }
            else
            { striscia3.Top += velocità; }

        }

        int velocitaMacchina = 10;

        private void tastiPremuti(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left) {

                if(macchina.Left > 80)
                {
                    macchina.Left +=  -20;
                }

            }

            if (e.KeyCode == Keys.Right) {

                if (macchina.Right <= 500)
                {
                    macchina.Left += 20;
                }

            }

            if (e.KeyCode == Keys.Up)
            {
                //se vado su, la strda velocizza

                if (velocitaMacchina < 800)
                {
                    velocitaMacchina++;
                    macchina.Top -= 20;
                }

            }

            if (e.KeyCode == Keys.Down)
            {
                //se vado giu, la strada rallenta

                if (velocitaMacchina > 0)
                {
                    velocitaMacchina--;
                    macchina.Top += 20;
                }

            }

        }

        
    }
}
