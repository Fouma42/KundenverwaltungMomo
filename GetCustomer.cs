using System;
using System.Collections;
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
   
    public partial class GetCustomer : Form
    {        
        private KundenverwaltungEntities context;       
        public GetCustomer()
        {
            InitializeComponent();
            context = new KundenverwaltungEntities();
            var names = context.Kundenverwaltung.OrderBy(n=>n.Name).Select(n => n.Name).ToList();
            foreach(var n in names)
            {        
                NameComboBox.Items.Add(n);
            }
    
          

        }

        private void SuchenButton_Click(object sender, EventArgs e)
        {
            string actualItem = NameComboBox.Text.ToString();
            Kundenverwaltung kunde = new Kundenverwaltung();
            kunde = context.Kundenverwaltung.Where(k=>k.Name.Equals(actualItem)).FirstOrDefault();
            if (kunde != null)
            {
                NameTextBox.Text = kunde.Name;
                AdressTextBox.Text = kunde.Anschrift;
                BetragTextBox.Text = kunde.Betrag.ToString();
                BemerkungTextBox.Text = kunde.Bemerkung == null?"keine Bemerkungen":kunde.Bemerkung;
                MaterialTextBox.Text = kunde.Material == null ? "keine Materialien" : kunde.Material;
                TelefonTextBox.Text =(kunde.Festnetz != null ? "[ " + kunde.Festnetz + " ] " : "") + (kunde.Handy != null ? "[ " + kunde.Handy + " ] " : "");
                QuittungTextBox.Text = kunde.Quittung.Equals(false) || kunde.Quittung == null ? "NEIN" : "JA";

            }
            else
            {

            MessageBox.Show("Bitte wählen sie einen Kunden aus!");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            f newCustomer = new f();           
            newCustomer.Show();
           
          
            
        }
    }
}
