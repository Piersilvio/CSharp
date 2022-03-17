using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blocco_note
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        public string doc_aperto = ""; //variabile globale per il doc aperto

        //controllo testo modificato
        public string note_init = "";
        private void check_note() 
        {
            if(note.Text != note_init)
            {
                //chiediamo se vuole salvare il file
                DialogResult risposta = MessageBox.Show("File modificato! Desideri salvarlo??", "salvataggio", MessageBoxButtons.YesNo);
                try
                {
                    if(risposta == DialogResult.Yes)
                    {
                        salvataggio();
                        note_init = "";
                    }
                    else if(risposta == DialogResult.No)
                    {
                        note_init = "";
                    }
                }
                catch
                {}
            }
        }

        //funzione di salvataggio del file
        private void salvataggio()
        {
            salva_file.ShowDialog();

            //gestiamo l'eccezione nella finestra di dialogo, qaulora l'utente clicca 'annulla'
            try
            {
                if (apri_file.FileName != null) //se il file esiste
                {
                    System.IO.File.WriteAllText(salva_file.FileName, note.Text); //scriviamo il contenuto del file nel file 
                    doc_aperto = salva_file.FileName;
                }
            }
            catch
            {
                note.Text = ""; //in tal caso, non mostriamo nulla sull'oggetto note
            }
        }

        //procedura di uscita dal prog.
        private void menu_exit_Click(object sender, EventArgs e)
        {
            check_note();
            Application.Exit(); 
        }

        private void menu_nuovo_Click(object sender, EventArgs e)
        {
            check_note();
            note.Text = "";
            doc_aperto = "";
        }

        private void menu_apriFile_Click(object sender, EventArgs e)
        {
            check_note();
            apri_file.ShowDialog();

            //gestiamo l'eccezione nella finestra di dialogo, qaulora l'utente clicca 'annulla'
            try
            {
                if (apri_file.FileName != null) //se il file esiste
                {
                    note.Text = System.IO.File.ReadAllText(apri_file.FileName);
                    note_init = System.IO.File.ReadAllText(apri_file.FileName);
                    doc_aperto = apri_file.FileName;
                }
            }
            catch
            {
                note.Text = ""; //in tal caso, non mostriamo nulla sull'oggetto note
            }
        }

        private void menu_salvaFilenome_Click(object sender, EventArgs e)
        {
            salvataggio();
        }

        private void menu_salvaFile_Click(object sender, EventArgs e)
        {
            if(doc_aperto != "")
            {
                //gestiamo l'eccezione nella finestra di dialogo, qaulora l'utente clicca 'annulla'
                try
                {
                        System.IO.File.WriteAllText(doc_aperto, note.Text); //scriviamo il contenuto del file nel file 
                }
                catch
                {
                    note.Text = ""; //in tal caso, non mostriamo nulla sull'oggetto note
                }
            }
            else
            {
                salvataggio();
            }
            
        }
    }
}
