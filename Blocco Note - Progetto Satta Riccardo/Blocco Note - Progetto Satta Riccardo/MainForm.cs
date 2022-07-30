using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Blocco_Note___Progetto_Satta_Riccardo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {   InitializeComponent();   }
        //IDE:
        private void MainForm_Load(object sender, EventArgs e)
        {
            if(Environment.GetCommandLineArgs().Count() > 1)
            {
                string[] argomenti = Environment.GetCommandLineArgs();
                caricaBarraTitolo(argomenti[1]);
                mainTextBox.Text = System.IO.File.ReadAllText(argomenti[1]);
                TestoIniziale = System.IO.File.ReadAllText(argomenti[1]);
                DocumentoAperto = argomenti[1];
            }
            else
            {
                string[] argomenti = Environment.GetCommandLineArgs();
                caricaBarraTitolo("Nuovo documento");
            }
            if (Properties.Settings.Default.capoautomatico == true) //visualizzare spunta a capo automatica
            {
                mainTextBox.WordWrap = true;
                aCapoAutomaticoToolStripMenuItem.Checked = true;
            }
            else
            {
                mainTextBox.WordWrap = false;
                aCapoAutomaticoToolStripMenuItem.Checked = false;
            }
            if (Properties.Settings.Default.nome_font != "") //caricare font e colore
            {
                FontFamily famigliaFont = new FontFamily(Properties.Settings.Default.nome_font);
                Font carattereScelto = new Font(famigliaFont, Properties.Settings.Default.dimensione, FontStyle.Regular, GraphicsUnit.Pixel);
                mainTextBox.Font = carattereScelto;
                mainTextBox.ForeColor = Properties.Settings.Default.colore_font;
            }
            if(Properties.Settings.Default.barraDiStatoVisibile == true) //caricare la barra di stato
            {   mainStatusStrip.Visible = true;   }
            else
            {   mainStatusStrip.Visible = false;   }
            if(Properties.Settings.Default.barraCercaVisible == true) //caricare la barra di ricerca
            {   toolDiRicerca.Visible = true;   }
            else
            {   toolDiRicerca.Visible = false;  }
            if (Properties.Settings.Default.barraVaiAVisible == true) //caricare la barra vai A
            { toolVaiA.Visible = true; }
            else
            { toolVaiA.Visible = false; }
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e) //casella di testo
        {   mainToolStripCaratteri0.Text = "Caratteri: " + mainTextBox.Text.Count();   }
        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { } //barra di stato
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { } //barra del menù
        private void mainToolStripFileNuovo_Click(object sender, EventArgs e) //svuotare la casella di testo
        {
            ControlloTesto();
            mainTextBox.Text = "";
            DocumentoAperto = "";
            caricaBarraTitolo("Nuovo Documento");
        }
        private void mainToolStripApri_Click(object sender, EventArgs e)
        {
            ControlloTesto();
            AprireFile();   
        }
        private void mainToolStripSalva_Click(object sender, EventArgs e)
        {
            if(DocumentoAperto != "")
            {
                try
                {
                    System.IO.File.WriteAllText(DocumentoAperto, mainTextBox.Text);
                    TestoIniziale = mainTextBox.Text;
                }
                catch { }
            }
            else
            {   SalvaDocumento();   }
        }
        private void mainToolStripSalvaConNome_Click(object sender, EventArgs e) //salvare un file di testo sul pc
        {   SalvaDocumento();   }
        private void mainToolStripFileEsci_Click(object sender, EventArgs e) //uscire dall'applicazione
        {
            ControlloTesto();
            Application.Exit();
        }
        private void caricaBarraTitolo(string TitoloDocumento) // caricare la barra del titolo
        {   this.Text = "Il Blocco Note di Riccardo Satta - " + TitoloDocumento;   }
        private void mainToolStripFileImpostaPagina_Click(object sender, EventArgs e)
        {
            DocumentoDaStampare.DocumentName = DocumentoAperto; //scegliere il documento da stampare
            SchermataImpostazioniStampa.ShowDialog(); //aprire la schermata di impostazioni di stampa
        }
        private void mainToolStripFileStampa_Click(object sender, EventArgs e)
        {
            DocumentoDaStampare.DocumentName = DocumentoAperto; //scegliere il documento da stampare
            if (SchermataStampa.ShowDialog() == DialogResult.OK) //aprire schermata stampa documento
            {   DocumentoDaStampare.Print();   }
        }
        private void DocumentoDaStampare_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string testoDaStampare = mainTextBox.Text;
            int caratterePagina = 0;
            int righePagina = 0;
            FontFamily famigliaFont = new FontFamily("Arial");
            Font fontDiStampa = new Font(famigliaFont, 16, FontStyle.Regular, GraphicsUnit.Pixel);
            e.Graphics.MeasureString(testoDaStampare, fontDiStampa, e.MarginBounds.Size, StringFormat.GenericTypographic, out caratterePagina, out righePagina);
            e.Graphics.DrawString(testoDaStampare, fontDiStampa, Brushes.Black, e.MarginBounds, StringFormat.GenericTypographic);
            testoDaStampare = testoDaStampare.Substring(caratterePagina);
            e.HasMorePages = testoDaStampare.Length > 0;
        }
        private void mainToolStripModificaAnnulla_Click(object sender, EventArgs e) //annullare l'ultima azione eseguita
        {   mainTextBox.Undo();  }
        private void mainToolStripModificaTaglia_Click(object sender, EventArgs e) //tagliare del testo
        {   mainTextBox.Cut();   }
        private void mainToolStripModificaCopia_Click(object sender, EventArgs e) //Copiare del testo
        {   mainTextBox.Copy();  }
        private void mainToolStripModificaIncolla_Click(object sender, EventArgs e) //Incolla del testo
        {   mainTextBox.Paste(); }
        private void mainToolStripModificaElimina_Click(object sender, EventArgs e) //eliminare del testo
        {   mainTextBox.SelectedText = "";   }
        private void cercaConGoogleToolStripMenuItem_Click(object sender, EventArgs e) //ricerca testo con Google
        {
            string testoDaCercare = mainTextBox.SelectedText;
            if(testoDaCercare.Contains(" "))
            {   testoDaCercare.Replace(" ", "+");   }
            System.Diagnostics.Process.Start("http://www.google.it/search?source=hp&q=" + testoDaCercare);
        }
        private void cercaConBingToolStripMenuItem_Click(object sender, EventArgs e) //ricerca testo con Bing
        {
            string testoDaCercare = mainTextBox.SelectedText;
            if (testoDaCercare.Contains(" "))
            {   testoDaCercare.Replace(" ", "+");   }
            System.Diagnostics.Process.Start("http://www.bing.com/search?q=" + testoDaCercare);
        }
        private void mainToolStripModificaSelezionaTutto_Click(object sender, EventArgs e)
        {   mainTextBox.SelectAll();   }
        private void oraToolStripMenuItem_Click(object sender, EventArgs e) //aggiungere ora in formato testuale
        {
            int posizioneIniziale = mainTextBox.SelectionStart;
            DateTime dataCorrente = DateTime.Now;
            mainTextBox.Text = mainTextBox.Text.Insert(posizioneIniziale, dataCorrente.Hour + " : " + dataCorrente.Minute + " : " + dataCorrente.Second);
        }
        private void dataToolStripMenuItem_Click(object sender, EventArgs e) //aggiungere data in formato testuale
        {
            int posizioneIniziale = mainTextBox.SelectionStart;
            mainTextBox.Text = mainTextBox.Text.Insert(posizioneIniziale, DateTime.Now.Day + " / " + DateTime.Now.Month + " / " + DateTime.Now.Year);
        }
        private void oraEDataToolStripMenuItem_Click(object sender, EventArgs e) //aggiungere ora e data in formato testuale
        {
            int posizioneIniziale = mainTextBox.SelectionStart;
            string varOraData = DateTime.Now.Hour + " : " + DateTime.Now.Minute + " : " + DateTime.Now.Second  + " - " + DateTime.Now.Day + " / " + DateTime.Now.Month + " / " + DateTime.Now.Year;
            mainTextBox.Text = mainTextBox.Text.Insert(posizioneIniziale, varOraData);
        }
        private void mainToolStripModificaTrova_Click(object sender, EventArgs e) //rendere visibile la barra di ricerca
        {
            if(toolDiRicerca.Visible == false)
            {
                toolDiRicerca.Visible = true;
                mainToolStripModificaTrova.Checked = true;
                Properties.Settings.Default.barraCercaVisible = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                toolDiRicerca.Visible = false;
                mainToolStripModificaTrova.Checked = false;
                Properties.Settings.Default.barraCercaVisible = false;
                Properties.Settings.Default.Save();
            }
        }
        private void btn_cerca_Click(object sender, EventArgs e) //cercare del testo attraverso la barra di ricerca
        {
            if(txt_cerca.Text.Length == 0)
            {   MessageBox.Show("Non è presente alcun testo da cercare");   }
            else
            {
                if(mainTextBox.Text.Length > 0)
                {   ricercaContinua();   }
            }
        }
        private void btn_sostituisci_Click(object sender, EventArgs e) //sostituire del testo attraverso la barra di ricerca
        {
            if (txt_cerca.Text.Length == 0)
            {   MessageBox.Show("Non è presente alcun testo da cercare");   }
            else if (txt_sostituisci.Text.Length == 0)
            {   MessageBox.Show("Non è presente alcun testo da sostituire");   }
            else
            {   sostituisciTutto();   }    
        }
        private void mainToolStripModificaTrovaSuccessiva_Click(object sender, EventArgs e) //trovare più volte una parole all'interno del testo
        {   ricercaContinua();   }
        private void mainToolStripModificaVaiA_Click(object sender, EventArgs e) //rendere visibile la tool 'Vai a'
        {
            if(toolVaiA.Visible == false)
            {
                toolVaiA.Visible = true;
                mainToolStripModificaVaiA.Checked = true;
                Properties.Settings.Default.barraVaiAVisible = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                toolVaiA.Visible = false;
                mainToolStripModificaVaiA.Checked = false;
                Properties.Settings.Default.barraVaiAVisible = false ;
                Properties.Settings.Default.Save();
            }
        }
        private void btn_vaiA_Click(object sender, EventArgs e) //cercare il numero di una riga nel testo
        {
            int valoreFinale;
            var controlloTesto = int.TryParse(txt_vaiA.Text, out valoreFinale);
            if(controlloTesto == true)
            {
                if(valoreFinale > mainTextBox.Lines.Count())
                {   valoreFinale = mainTextBox.Lines.Count();   }
                else
                {
                    if(valoreFinale == 0)
                    {   valoreFinale = 1;   }
                }
                int indice = mainTextBox.GetFirstCharIndexFromLine(valoreFinale - 1);
                mainTextBox.Select(indice, 0);
                mainTextBox.ScrollToCaret();
            }
            else
            {   MessageBox.Show("Inserire un valore numerico");   }
        }
        private void aCapoAutomaticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(mainTextBox.WordWrap == true)
            {
                mainTextBox.WordWrap = false;
                Properties.Settings.Default.capoautomatico = false;
                Properties.Settings.Default.Save();
                aCapoAutomaticoToolStripMenuItem.Checked = false;
            }
            else
            {
                mainTextBox.WordWrap = true;
                Properties.Settings.Default.capoautomatico = true;
                Properties.Settings.Default.Save();
                aCapoAutomaticoToolStripMenuItem.Checked = true;
            }
        }
        private void mainToolStripFormatoCarattere_Click(object sender, EventArgs e)
        {
            if(sceltaCarattere.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.nome_font = sceltaCarattere.Font.Name;
                Properties.Settings.Default.dimensione = sceltaCarattere.Font.Size;
                Properties.Settings.Default.colore_font = sceltaCarattere.Color;
                Properties.Settings.Default.Save();
                FontFamily famigliaFont = new FontFamily(sceltaCarattere.Font.Name);
                Font carattereScelto = new Font(famigliaFont, sceltaCarattere.Font.Size, FontStyle.Regular, GraphicsUnit.Pixel);
                mainTextBox.Font = carattereScelto;
                mainTextBox.ForeColor = sceltaCarattere.Color;
            }
        }
        private void aumentaZoomToolStripMenuItem_Click(object sender, EventArgs e) //aumentare lo zoom della casella di testo
        {
            if (mainTextBox.ZoomFactor < 2.0f)
            {
                mainTextBox.ZoomFactor = mainTextBox.ZoomFactor + 0.2f;
                double valoreDaArrotondare = mainTextBox.ZoomFactor * 100;
                int percentualeZoom = (int)Math.Round(valoreDaArrotondare);
                mainToolStrip100.Text = "Zoom: " + percentualeZoom + " %";
            }
        }
        private void diminuisciZoomToolStripMenuItem_Click(object sender, EventArgs e) //diminuire lo zoom della casella di testo
        {
            if (mainTextBox.ZoomFactor > 0.6f)
            {   
                mainTextBox.ZoomFactor = mainTextBox.ZoomFactor - 0.2f;
                double valoreDaArrotondare = mainTextBox.ZoomFactor * 100;
                int percentualeZoom = (int)Math.Round(valoreDaArrotondare);
                mainToolStrip100.Text = "Zoom: " + percentualeZoom + " %";
            }
        }
        private void mainToolStripVisualizzaBarraDiStato_Click(object sender, EventArgs e)
        {
            if(mainStatusStrip.Visible == false)
            {
                mainStatusStrip.Visible = true;
                mainToolStripVisualizzaBarraDiStato.Checked = true;
                Properties.Settings.Default.barraDiStatoVisibile = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                mainStatusStrip.Visible = false;
                mainToolStripVisualizzaBarraDiStato.Checked = false;
                Properties.Settings.Default.barraDiStatoVisibile = false;
                Properties.Settings.Default.Save();
            }
        }
        private void mainToolStripInfoGuida_Click(object sender, EventArgs e) //inserire la guida al Blocco Note
        {   System.Diagnostics.Process.Start("https://www.riccardosatta.com/");   }
        private void mainToolStripInfoInformazioniSuRiccardoSatta_Click(object sender, EventArgs e) //collegare il form di informazioni all'apposita label
        {
            Info InforForm = new Info();
            InforForm.ShowDialog();
        }
        private void mainToolStripInPrimoPianoOn_Click(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.primoPiano == true)
            {
                Properties.Settings.Default.primoPiano = false;
                Properties.Settings.Default.Save();
                mainToolStripInPrimoPianoOFF.Text = "In primo piano: OFF";
                TopMost = false;
            }
            else
            {
                Properties.Settings.Default.primoPiano = true;
                Properties.Settings.Default.Save();
                mainToolStripInPrimoPianoOFF.Text = "In primo piano: ON";
                TopMost = true;
            }
        }
        private void contestualeCopia_Click(object sender, EventArgs e)
        {   mainToolStripModificaCopia_Click(sender, new System.EventArgs());   }
        private void contestualeIncolla_Click(object sender, EventArgs e)
        {   mainToolStripModificaIncolla_Click(sender, new EventArgs());   }
        private void contestualeElimina_Click(object sender, EventArgs e)
        {   mainToolStripModificaElimina_Click(sender, new EventArgs());   }
        private void contestualeSelezionaTutto_Click(object sender, EventArgs e)
        {   mainToolStripModificaSelezionaTutto_Click(sender, new EventArgs());   }
        //METODI E STRINGHE:
        public string TestoIniziale = "";
        public string DocumentoAperto = "";
        private int posizioneInizialeSostituisci = 0;
        private int posizioneInizialeRicerca = 0;
        private void ControlloTesto() 
        {
            if(mainTextBox.Text != TestoIniziale) 
            {
                DialogResult rispostaUtente = MessageBox.Show("Documento modificato. Desideri procedere al salvataggio?", "Documento modificato con successo", MessageBoxButtons.YesNo);
                try
                {
                    if(rispostaUtente == DialogResult.Yes)
                    {
                        SalvaDocumento();
                        TestoIniziale = "";
                    }
                    if(rispostaUtente == DialogResult.No)
                    {   TestoIniziale = "";   }
                }
                catch { }
            }
        }
        private void AprireFile() //aprire un file di testo da pc
        {
            try
            {
                ApriFile.ShowDialog(); //..seleziono dal pc il file da aprire..
                if (ApriFile.FileName != null) //..se il file di testo non è vuoto..
                {
                    mainTextBox.Text = System.IO.File.ReadAllText(ApriFile.FileName); //..ne leggo il contenuto e lo copio nella casella di testo
                    TestoIniziale = System.IO.File.ReadAllText(ApriFile.FileName);
                    DocumentoAperto = ApriFile.FileName;
                    caricaBarraTitolo(ApriFile.FileName);
                }
            }
            catch { }
        }
        private void SalvaDocumento() // salvare il file di testo su pc
        { 
            SalvaFile.ShowDialog(); //..creo il salvataggio di un file di testo..
            try
            {
                if (SalvaFile.FileName != "") //..ammesso che non sia vuoto..
                {
                    System.IO.File.WriteAllText(SalvaFile.FileName, mainTextBox.Text); //..lo associo alla casella di testo
                    DocumentoAperto = SalvaFile.FileName;
                    TestoIniziale = mainTextBox.Text;
                }
            }
            catch { }
        }
        private void ricercaContinua()
        {
            try
            {
                string paroleDaCercare = txt_cerca.Text;
                mainTextBox.Focus();
                posizioneInizialeRicerca = mainTextBox.Find(paroleDaCercare, posizioneInizialeRicerca, RichTextBoxFinds.None);
                mainTextBox.Select(posizioneInizialeRicerca, paroleDaCercare.Length);
                posizioneInizialeRicerca = posizioneInizialeRicerca + paroleDaCercare.Length + 1;
            }
            catch
            {
                MessageBox.Show("Non è stato possibile trovare la parola cercata");
                posizioneInizialeRicerca = 0;
            }
        }
        private void sostituisciTutto()
        {
            try
            {
                if (mainTextBox.Find(txt_cerca.Text) >= 0)
                {
                    string parolaDaSostituire = txt_cerca.Text;
                    posizioneInizialeSostituisci = mainTextBox.Find(parolaDaSostituire, posizioneInizialeSostituisci, RichTextBoxFinds.None);
                    string testoPrimaParte = mainTextBox.Text.Substring(0, mainTextBox.SelectionStart);
                    string testoSostituto = txt_sostituisci.Text;
                    string testoUltimaParte = mainTextBox.Text.Substring(mainTextBox.SelectionStart + mainTextBox.SelectionLength);
                    mainTextBox.Text = testoPrimaParte + testoSostituto + testoUltimaParte;
                    posizioneInizialeSostituisci = posizioneInizialeSostituisci + txt_sostituisci.TextLength;
                }
            }
            catch
            {
                MessageBox.Show("Testo da sostituire non trovato!");
                posizioneInizialeSostituisci = 0;
            }
        }
    }
}