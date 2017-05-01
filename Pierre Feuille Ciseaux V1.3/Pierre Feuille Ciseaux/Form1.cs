using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Pierre_Feuille_Ciseaux
{
    public partial class Form1 : Form
    {

        int nbTour = 1; // nombre de tour écoulé
        int nbDefaite = 0; // nombre de défaite du joueur
        int nbVictoire = 0; // nombre de victoire du joueur

        int nbEtoileJoueur = 4;
        int nbEtoileOrdi = 4;

        int ciseauxJoue = 0; // le nombre de ciseaux joué
        int feuilleJoue = 0; // le nombre de feuille joué
        int pierreJoue = 0; // le nombre de pierre joué

        int ciseauxJoueOrdi = 0; // le nombre de ciseaux joué
        int feuilleJoueOrdi = 0; // le nombre de feuille joué
        int pierreJoueOrdi = 0; // le nombre de pierre joué

        string vainqueur = "";

        int begin = 1;
        int end = 30;

        string currentCarteCheckJoueur = ""; // la carte que le joueur à jouer
        string currentCarteCheckOrdi = ""; // la carte que l'ordi à jouer

        bool tourSuivant = true; // indique si le joueur peut jouer une autre carte (si le tour est bien finit) 
                                 // vrai quand le tour est terminé faux tan qu'il ne l'est pas
        Random leHasard = new Random();
        public Form1()
        {
            InitializeComponent();
            label10.Visible = false;
            label1.Visible = false; // Set
            label7.Visible = false; // Check
            label8.Visible = false; // Open
            label6.Visible = false; // Affiche le dialogue de l'ordinateur
            button1.Visible = false; // Bouton validant le choix de la carte par le joueur
            button2.Visible = false; // Bouton pour commencer un nouveau tour
            pictureBox33.Visible = false; // Bouton pour retourner les cartes
            pictureBox33.Visible = false;

            if(nbTour==1)
            {
                label9.Visible = true;
                label9.Text = "Cliquer sur une carte pour la jouez !";
            }

            DessinneEtoileOrdi(nbEtoileOrdi);
            DessinneEtoileJoueur(nbEtoileJoueur);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (nbTour == 1)
            {
                label9.Visible = true;
                label9.Font = new Font("Arial Black",10) ;
                label9.Text = "Maintenant cliquez sur la carte de l'adversaire pour la retourner";
            }
            tourSuivant = false;
            button1.Visible = false;
            button2.Visible = false;
            pictureBox33.Visible = true;
            label1.Visible = false;
            // Au click, l'ordinateur va jouer
            if (currentCarteCheckJoueur != "")
            {
                label7.Visible = true;
                label6.Visible = true;
                label6.Text = "Adversaire : La chance me sourit !";


                // recherche de la carte à jouer par l'ordi
                int choixOrdi = leHasard.Next(begin, end);
                string carteJouerParOrdi = "";
                if (choixOrdi > 0 && choixOrdi <= 10)
                {
                    carteJouerParOrdi = "feuille";
                }
                if (choixOrdi >= 11 && choixOrdi <= 20)
                {
                    carteJouerParOrdi = "pierre";
                }
                if (choixOrdi >= 21 && choixOrdi <= 30)
                {
                    carteJouerParOrdi = "ciseaux";
                }
                switch (carteJouerParOrdi)
                {
                    case "feuille":
                        if (feuilleJoueOrdi < 4)
                        {
                            pictureBox15.Location = new Point(318, 45);
                            feuilleJoueOrdi += 1;
                            currentCarteCheckOrdi = "feuille";
                            begin = begin + 2; // l'ordinateur joueras de maniére équilibré puisqu'il à de moins en moins de chance de tomber sur feuille
                        }
                        else // s'il n'à plus de feuille
                        {
                            if (pierreJoueOrdi < 4)
                            {
                                pictureBox18.Location = new Point(318, 45);
                                pierreJoueOrdi += 1;
                                currentCarteCheckOrdi = "pierre";
                            }
                            else // s'il n'à plus de pierre
                            {
                                if (ciseauxJoueOrdi < 4)
                                {
                                    pictureBox19.Location = new Point(318, 45);
                                    ciseauxJoueOrdi += 1;
                                    currentCarteCheckOrdi = "ciseaux";
                                    end = end - 2; // l'ordinateur joueras de maniére équilibré puisqu'il à de moins en moins de chance de tomber sur ciseaux
                                }
                                else // Si l'ordi n'à plus de cartes
                                {
                                    label6.Visible = true;
                                    label6.Text = "Ordniateur : Aïe ! Je n'ai plus de cartes !";// ne devrait jamais arriver (les joeurs jouent leurs carte en même temps)
                                }
                            }
                        }
                        break;
                    case "pierre":
                        if (pierreJoueOrdi < 4)
                        {
                            pictureBox18.Location = new Point(318, 45);
                            pierreJoueOrdi += 1;
                            currentCarteCheckOrdi = "pierre";
                        }
                        else // s'il n'à plus de pierre
                        {
                            if (feuilleJoueOrdi < 4)
                            {
                                pictureBox15.Location = new Point(318, 45);
                                feuilleJoueOrdi += 1;
                                begin = begin + 2; // l'ordinateur joueras de maniére équilibré puisqu'il à de moins en moins de chance de tomber sur feuille
                                currentCarteCheckOrdi = "feuille";
                            }
                            else // s'il n'à plus de feuille
                            {
                                if (ciseauxJoueOrdi < 4)
                                {
                                    pictureBox19.Location = new Point(318, 45);
                                    ciseauxJoueOrdi += 1;
                                    currentCarteCheckOrdi = "ciseaux";
                                    end = end - 2; // l'ordinateur joueras de maniére équilibré puisqu'il à de moins en moins de chance de tomber sur ciseaux
                                }
                                else // Si l'ordi n'à plus de cartes
                                {
                                    label6.Visible = true;
                                    label6.Text = "Ordniateur : Aïe ! Je n'ai plus de cartes !";// ne devrait jamais arriver (les joeurs jouent leurs carte en même temps)
                                }
                            }
                        }
                        break;
                    case "ciseaux":
                        if (ciseauxJoue < 4)
                        {
                            pictureBox19.Location = new Point(318, 45);
                            ciseauxJoueOrdi += 1;
                            currentCarteCheckOrdi = "ciseaux";
                            end = end - 2; // l'ordinateur joueras de maniére équilibré puisqu'il à de moins en moins de chance de tomber sur ciseaux
                        }
                        else // s'il n'à plus de ciseaux
                        {
                            if (pierreJoueOrdi < 4)
                            {
                                pictureBox18.Location = new Point(318, 45);
                                pierreJoueOrdi += 1;
                                currentCarteCheckOrdi = "pierre";
                            }
                            else // s'il n'à plus de pierre
                            {
                                if (feuilleJoueOrdi < 4)
                                {
                                    pictureBox15.Location = new Point(318, 45);
                                    feuilleJoueOrdi += 1;
                                    begin = begin + 2; // l'ordinateur joueras de maniére équilibré puisqu'il à de moins en moins de chance de tomber sur feuille
                                    currentCarteCheckOrdi = "feuille";
                                }
                                else // Si l'ordi n'à plus de cartes
                                {
                                    label6.Visible = true;
                                    label6.Text = "Ordniateur : Aïe ! Je n'ai plus de cartes !";// ne devrait jamais arriver (les joeurs jouent leurs carte en même temps)
                                }
                            }
                        }
                        break;
                }
                pictureBox33.Visible = true;

            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (tourSuivant && vainqueur == "")
            {
                label1.Visible = true;
                // Le joueur à choisit un ciseaux

                // On replace les pierres
                pictureBox5.Location = new Point(446, 299);
                pictureBox6.Location = new Point(446, 323);
                pictureBox7.Location = new Point(446, 355);
                pictureBox8.Location = new Point(446, 394);
                // On replace les feuilles
                pictureBox9.Location = new Point(261, 299);
                pictureBox10.Location = new Point(261, 323);
                pictureBox11.Location = new Point(261, 355);
                pictureBox12.Location = new Point(261, 394);
                switch (ciseauxJoue)
                {
                    case 0:
                        pictureBox1.Location = new Point(550, 42);
                        currentCarteCheckJoueur = "ciseaux";
                        break;
                    case 1:
                        pictureBox2.Location = new Point(550, 42);
                        currentCarteCheckJoueur = "ciseaux";
                        break;
                    case 2:
                        pictureBox3.Location = new Point(550, 42);
                        currentCarteCheckJoueur = "ciseaux";
                        break;
                    case 3:
                        pictureBox4.Location = new Point(550, 42);
                        currentCarteCheckJoueur = "ciseaux";
                        break;
                }
                button1.Visible = true;
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (tourSuivant && vainqueur == "")
            {
                label1.Visible = true;
                // Le joueur à choisit une pierre

                // On replace les feuilles
                pictureBox9.Location = new Point(261, 299);
                pictureBox10.Location = new Point(261, 323);
                pictureBox11.Location = new Point(261, 355);
                pictureBox12.Location = new Point(261, 394);
                // On replace les ciseaux
                pictureBox1.Location = new Point(649, 299);
                pictureBox2.Location = new Point(649, 323);
                pictureBox3.Location = new Point(649, 355);
                pictureBox4.Location = new Point(649, 394);
                switch (pierreJoue)
                {
                    case 0:
                        pictureBox5.Location = new Point(550, 42);
                        currentCarteCheckJoueur = "pierre";
                        break;
                    case 1:
                        pictureBox6.Location = new Point(550, 42);
                        currentCarteCheckJoueur = "pierre";
                        break;
                    case 2:
                        pictureBox7.Location = new Point(550, 42);
                        currentCarteCheckJoueur = "pierre";
                        break;
                    case 3:
                        pictureBox8.Location = new Point(550, 42);
                        currentCarteCheckJoueur = "pierre";
                        break;
                }
                button1.Visible = true;
            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            if (tourSuivant && vainqueur == "")
            {
                label1.Visible = true;

                // Le joueur à choisit une feuille

                // On replace les pierres
                pictureBox5.Location = new Point(446, 299);
                pictureBox6.Location = new Point(446, 323);
                pictureBox7.Location = new Point(446, 355);
                pictureBox8.Location = new Point(446, 394);
                // On replace les ciseaux
                pictureBox1.Location = new Point(649, 299);
                pictureBox2.Location = new Point(649, 323);
                pictureBox3.Location = new Point(649, 355);
                pictureBox4.Location = new Point(649, 394);
                switch (feuilleJoue)
                {
                    case 0:
                        pictureBox9.Location = new Point(550, 42);
                        currentCarteCheckJoueur = "feuille";
                        break;
                    case 1:
                        pictureBox10.Location = new Point(550, 42);
                        currentCarteCheckJoueur = "feuille";
                        break;
                    case 2:
                        pictureBox11.Location = new Point(550, 42);
                        currentCarteCheckJoueur = "feuille";
                        break;
                    case 3:
                        pictureBox12.Location = new Point(550, 42);
                        currentCarteCheckJoueur = "feuille";
                        break;
                }
                button1.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label9.Visible = false;
            label9.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Bold);
            label8.Visible = false;
            // Bouton préparant le prochain tour et nettoyant le plateau
            if (currentCarteCheckJoueur == "ciseaux")
            {
                switch (ciseauxJoue)
                {
                    case 0:
                        pictureBox1.Visible = false;
                        break;
                    case 1:
                        pictureBox2.Visible = false;
                        break;
                    case 2:
                        pictureBox3.Visible = false;
                        break;
                    case 3:
                        pictureBox4.Visible = false;
                        break;
                }
                ciseauxJoue += 1;
            }
            if (currentCarteCheckJoueur == "pierre")
            {
                switch (pierreJoue)
                {
                    case 0:
                        pictureBox5.Visible = false;
                        break;
                    case 1:
                        pictureBox6.Visible = false;
                        break;
                    case 2:
                        pictureBox7.Visible = false;
                        break;
                    case 3:
                        pictureBox8.Visible = false;
                        break;
                }
                pierreJoue += 1;
            }
            if (currentCarteCheckJoueur == "feuille")
            {
                switch (feuilleJoue)
                {
                    case 0:
                        pictureBox9.Visible = false;
                        break;
                    case 1:
                        pictureBox10.Visible = false;
                        break;
                    case 2:
                        pictureBox11.Visible = false;
                        break;
                    case 3:
                        pictureBox12.Visible = false;
                        break;
                }
                feuilleJoue += 1;
            }
            currentCarteCheckJoueur = "";
            switch (currentCarteCheckOrdi)
            {
                case "pierre":
                    pictureBox18.Location = new Point(940, 675);
                    currentCarteCheckOrdi = "";
                    break;
                case "feuille":
                    pictureBox15.Location = new Point(940, 675);
                    currentCarteCheckOrdi = "";
                    break;
                case "ciseaux":
                    pictureBox19.Location = new Point(940, 675);
                    currentCarteCheckOrdi = "";
                    break;
            }
            nbTour += 1;
            label3.Text = "Tour N°" + nbTour;
            button2.Visible = false;
            tourSuivant = true;
            label6.Text = "";
        }

        


        // Retourne Joueur si le joueur gagne la baaille
        // Retourne DRAW en cas d'égalité
        // Retourne Ordi si l'ordinateur l'emporte
        public string GagnantBataille(string carteOrdi, string carteJoueur)
        {
            if (carteJoueur == "feuille")
            {
                switch (carteOrdi)
                {
                    case "feuille":
                        return "DRAW";
                    case "pierre":
                        return "Joueur";
                    case "ciseaux":
                        return "Ordi";
                }
            }
            if (carteJoueur == "pierre")
            {
                switch (carteOrdi)
                {
                    case "pierre":
                        return "DRAW";
                    case "ciseaux":
                        return "Joueur";
                    case "feuille":
                        return "Ordi";
                }
            }
            if (carteJoueur == "ciseaux")
            {
                switch (carteOrdi)
                {
                    case "ciseaux":
                        return "DRAW";
                    case "feuille":
                        return "Joueur";
                    case "pierre":
                        return "Ordi";
                }
            }
            return "Erreur";
        }

        public void DessinneEtoileOrdi(int nbEtoiles)
        {
            pictureBox24.Visible = false;
            pictureBox25.Visible = false;
            pictureBox23.Visible = false;
            pictureBox22.Visible = false;
            pictureBox34.Visible = false;
            pictureBox35.Visible = false;
            pictureBox36.Visible = false;
            pictureBox37.Visible = false;
            switch (nbEtoiles)
            {
                case 1:
                    pictureBox24.Visible = true;
                    break;
                case 2:
                    pictureBox24.Visible = true;
                    pictureBox25.Visible = true;
                    break;
                case 3:
                    pictureBox24.Visible = true;
                    pictureBox25.Visible = true;
                    pictureBox23.Visible = true;
                    break;
                case 4:
                    pictureBox24.Visible = true;
                    pictureBox25.Visible = true;
                    pictureBox23.Visible = true;
                    pictureBox22.Visible = true;
                    break;
                case 5:
                    pictureBox24.Visible = true;
                    pictureBox25.Visible = true;
                    pictureBox23.Visible = true;
                    pictureBox22.Visible = true;
                    pictureBox34.Visible = true;
                    break;
                case 6:
                    pictureBox24.Visible = true;
                    pictureBox25.Visible = true;
                    pictureBox23.Visible = true;
                    pictureBox22.Visible = true;
                    pictureBox34.Visible = true;
                    pictureBox35.Visible = true;
                    break;
                case 7:
                    pictureBox24.Visible = true;
                    pictureBox25.Visible = true;
                    pictureBox23.Visible = true;
                    pictureBox22.Visible = true;
                    pictureBox34.Visible = true;
                    pictureBox35.Visible = true;
                    pictureBox36.Visible = true;
                    break;
                case 8:
                    pictureBox24.Visible = true;
                    pictureBox25.Visible = true;
                    pictureBox23.Visible = true;
                    pictureBox22.Visible = true;
                    pictureBox34.Visible = true;
                    pictureBox35.Visible = true;
                    pictureBox36.Visible = true;
                    pictureBox37.Visible = true;
                    break;
            }
        }

        public void DessinneEtoileJoueur(int nbEtoiles)
        {
            pictureBox17.Visible = false;
            pictureBox13.Visible = false;
            pictureBox14.Visible = false;
            pictureBox21.Visible = false;
            pictureBox40.Visible = false;
            pictureBox41.Visible = false;
            pictureBox39.Visible = false;
            pictureBox38.Visible = false;
            switch (nbEtoiles)
            {
                case 1:
                    pictureBox17.Visible = true;
                    break;
                case 2:
                    pictureBox17.Visible = true;
                    pictureBox13.Visible = true;
                    break;
                case 3:
                    pictureBox17.Visible = true;
                    pictureBox13.Visible = true;
                    pictureBox14.Visible = true;
                    break;
                case 4:
                    pictureBox17.Visible = true;
                    pictureBox13.Visible = true;
                    pictureBox14.Visible = true;
                    pictureBox21.Visible = true;
                    break;
                case 5:
                    pictureBox17.Visible = true;
                    pictureBox13.Visible = true;
                    pictureBox14.Visible = true;
                    pictureBox21.Visible = true;
                    pictureBox40.Visible = true;
                    break;
                case 6:
                    pictureBox17.Visible = true;
                    pictureBox13.Visible = true;
                    pictureBox14.Visible = true;
                    pictureBox21.Visible = true;
                    pictureBox40.Visible = true;
                    pictureBox41.Visible = true;
                    break;
                case 7:
                    pictureBox17.Visible = true;
                    pictureBox13.Visible = true;
                    pictureBox14.Visible = true;
                    pictureBox21.Visible = true;
                    pictureBox40.Visible = true;
                    pictureBox41.Visible = true;
                    pictureBox39.Visible = true;
                    break;
                case 8:
                    pictureBox17.Visible = true;
                    pictureBox13.Visible = true;
                    pictureBox14.Visible = true;
                    pictureBox21.Visible = true;
                    pictureBox40.Visible = true;
                    pictureBox41.Visible = true;
                    pictureBox39.Visible = true;
                    pictureBox38.Visible = true;
                    break;
            }
        }
        public string GagnerPerdre(int EtoileOrdi, int EtoileJoueur)
        {
            if (EtoileJoueur == 0)
            {
                return ("Ordi");// le joueur à perdu
            }
            if (EtoileOrdi == 0)
            {
                return ("Joueur");// L'ordi à perdu
            }
            return ("Personne");
        }

        private void pictureBox33_Click(object sender, EventArgs e)
        {
            // Retourner la carte

            label7.Visible = false;
            label8.Visible = true;
            pictureBox33.Visible = false;
            button2.Visible = true;
            pictureBox33.Visible = false;

            switch (GagnantBataille(currentCarteCheckOrdi, currentCarteCheckJoueur))
            {
                case "DRAW":
                    label6.Text = "Ordinateur : C'est une égalité !";
                    break;

                case "Ordi":
                    label6.Text = "Ordinateur : J'ai gagné cette partie !";

                    nbDefaite += 1;
                    nbEtoileJoueur -= 1;
                    nbEtoileOrdi += 1;

                    DessinneEtoileOrdi(nbEtoileOrdi);// On dessine les étoiles de l'ordi représentant son score, sa vie !
                    DessinneEtoileJoueur(nbEtoileJoueur);// On dessine les étoiles du joueur représentant son score, sa vie !

                    label4.Text = "Défaite : " + nbDefaite;

                    break;

                case "Joueur":
                    label6.Text = "Ordinateur : Vous avez gagné !";
                    nbVictoire += 1;
                    nbEtoileOrdi -= 1;
                    nbEtoileJoueur += 1;

                    DessinneEtoileOrdi(nbEtoileOrdi);// On dessine les étoiles de l'ordi représentant son score, sa vie !
                    DessinneEtoileJoueur(nbEtoileJoueur);// On dessine les étoiles du joueur représentant son score, sa vie !

                    label5.Text = "Victoire : " + nbVictoire;
                    break;
            }
            if (nbTour < 11)
            {
                label2.Text = (12 - nbTour) + " Cartes";
            }
            else
            {
                label2.Text = (12 - nbTour) + " Carte";
            }
            string chercheVainqueur = GagnerPerdre(nbEtoileOrdi, nbEtoileJoueur);// On cherche si on à un vainqueur
            if (nbTour == 12)
            {
                if (nbEtoileJoueur > nbEtoileOrdi)// Joueur à gagné
                {
                    label9.Visible = true;
                    label10.Visible = true;
                    label9.Text = "Vous avez gagné !";
                    button3.Visible = true;
                    vainqueur = "Joueur";
                }
                if (nbEtoileJoueur < nbEtoileOrdi)// Ordi à gagné
                {
                    label9.Visible = true;
                    label10.Visible = true;
                    label9.Text = "L'ordi l'emporte !";
                    button3.Visible = true;
                    vainqueur = "Ordi";
                }
                if (nbEtoileJoueur == nbEtoileOrdi)// Égalité
                {
                    label9.Visible = true;
                    label10.Visible = true;
                    label9.Text = "Égalité";
                    button3.Visible = true;
                    vainqueur = "Égalité";
                }
            }
			if(chercheVainqueur == "Ordi")
			{
				label9.Visible = true;
                label10.Visible = true;
                label9.Text = "L'ordi à gagné";
                button3.Visible = true;
				vainqueur = "Ordi";
			}
			if (chercheVainqueur == "Joueur")
			{
                label9.Visible = true;
                label10.Visible = true;
				label9.Text = "L'ordi est battu !";
                button3.Visible = true;
				vainqueur = "Joueur";
			}
			
        }

        private void button3_Click(object sender, EventArgs e)
        {
            nbTour = 1; // nombre de tour écoulé
            nbDefaite = 0; // nombre de défaite du joueur
            label4.Text = "Défaite : " + nbDefaite;
            nbVictoire = 0; // nombre de victoire du joueur
            label5.Text = "Victoire : " + nbVictoire;
            nbEtoileJoueur = 4;
            nbEtoileOrdi = 4;

            ciseauxJoue = 0; // le nombre de ciseaux joué
            feuilleJoue = 0; // le nombre de feuille joué
            pierreJoue = 0; // le nombre de pierre joué

            ciseauxJoueOrdi = 0; // le nombre de ciseaux joué
            feuilleJoueOrdi = 0; // le nombre de feuille joué
            pierreJoueOrdi = 0; // le nombre de pierre joué

            vainqueur = "";

            begin = 1;
            end = 30;

            button3.Visible = false;

            label9.Visible = false;
            label10.Visible = false;
            label1.Visible = false; // Set
            label7.Visible = false; // Check
            label8.Visible = false; // Open
            label6.Visible = false; // Affiche le dialogue de l'ordinateur
            button1.Visible = false; // Bouton validant le choix de la carte par le joueur
            button2.Visible = false; // Bouton pour commencer un nouveau tour
            pictureBox33.Visible = false; // Bouton pour retourner les cartes
            pictureBox33.Visible = false;

            DessinneEtoileOrdi(nbEtoileOrdi);
            DessinneEtoileJoueur(nbEtoileJoueur);


            // On réaffiche toutes les cartes

            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
            pictureBox4.Visible = true;
            pictureBox5.Visible = true;
            pictureBox6.Visible = true;
            pictureBox7.Visible = true;
            pictureBox8.Visible = true;
            pictureBox9.Visible = true;
            pictureBox10.Visible = true;
            pictureBox11.Visible = true;
            pictureBox12.Visible = true;

            // On replace les pierres
            pictureBox5.Location = new Point(446, 299);
            pictureBox6.Location = new Point(446, 323);
            pictureBox7.Location = new Point(446, 355);
            pictureBox8.Location = new Point(446, 394);
            // On replace les ciseaux
            pictureBox1.Location = new Point(649, 299);
            pictureBox2.Location = new Point(649, 323);
            pictureBox3.Location = new Point(649, 355);
            pictureBox4.Location = new Point(649, 394);
            // On replace les feuilles
            pictureBox9.Location = new Point(261, 299);
            pictureBox10.Location = new Point(261, 323);
            pictureBox11.Location = new Point(261, 355);
            pictureBox12.Location = new Point(261, 394);

            pictureBox18.Location = new Point(940, 675);
            pictureBox15.Location = new Point(940, 675);
            pictureBox19.Location = new Point(940, 675);

            currentCarteCheckJoueur = "";
            currentCarteCheckOrdi = "";
            label2.Text = "12 cartes" ;
            label3.Text = "Tour N° 0";

            tourSuivant = true;
        }
    }
}
