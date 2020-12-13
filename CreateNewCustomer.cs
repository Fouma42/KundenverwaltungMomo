using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MüsteriYönetimi
{
    public partial class f : Form
    {
        private KundenverwaltungEntities context;

        public f()
        {
            InitializeComponent();
            context = new KundenverwaltungEntities();
            
        }


        private void SpeichernButton_Click(object sender, EventArgs e)
        {
            Kundenverwaltung kunde = new Kundenverwaltung();
            
            if (string.IsNullOrWhiteSpace(textNameEingabe.Text) &&
                string.IsNullOrWhiteSpace(textAdresseEingabe.Text)&&
                string.IsNullOrWhiteSpace(textFestnetzEingabe.Text)&&
                string.IsNullOrWhiteSpace(textHandyEingabe.Text)&&
                string.IsNullOrWhiteSpace(textBetragEingabe.Text)&&
                string.IsNullOrWhiteSpace(textBoxBemerkungEingabe.Text)&&
                string.IsNullOrWhiteSpace(textBoxMaterialEingabe.Text))
            {
                MessageBox.Show("Bitte füllen Sie alle Felder aus!");
            }
            else
            {
                kunde.Name = textNameEingabe.Text;
                kunde.Anschrift = textAdresseEingabe.Text;
                kunde.Festnetz = textFestnetzEingabe.Text;
                kunde.Handy = textHandyEingabe.Text;
                kunde.Betrag = textBetragEingabe.Text != null || textBetragEingabe.Text !="" ? Int32.Parse(textBetragEingabe.Text):0;
                kunde.Quittung = comboBox1.Text.Equals("Ja") ? true : false;
                kunde.Bemerkung = textBoxBemerkungEingabe.Text;
                kunde.Material = textBoxMaterialEingabe.Text;

                context.Kundenverwaltung.Add(kunde);
                context.SaveChanges();
                textNameEingabe.Clear();
                textAdresseEingabe.Clear();
                textFestnetzEingabe.Clear();
                textHandyEingabe.Clear();
                textBoxBemerkungEingabe.Clear();
                textBoxMaterialEingabe.Clear();
                textBetragEingabe.Clear();
                MessageBox.Show("Gespeichert");
            }
 
            
        }

      
    }
}
