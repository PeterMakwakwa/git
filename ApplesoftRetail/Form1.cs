using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.IO;

namespace ApplesoftRetail
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer myspeechReader;
        string mypath = @"C:\Users\MPILO\Desktop\ApplesoftLofile";
       

        public Form1()
        {
            InitializeComponent();
            
            myspeechReader = new SpeechSynthesizer();
        }

        #region Creating LogFile
        void LogFile(string Shopadded,DateTime datetime)
        {
            

            if (!File.Exists(mypath))
            {
                File.Create(mypath).Dispose();
                using (TextWriter mytextfile = new StreamWriter(mypath))
                {
                    mytextfile.WriteLine("==============================ApplesoftLofile============================================");
                    mytextfile.WriteLine("Added: " + Shopadded + "Date Added"+ datetime);
                    mytextfile.Close();
                }
            }

            else if (File.Exists(mypath))
            {



                using (TextWriter mytextfile = File.AppendText(mypath))
                {
                    mytextfile.WriteLine("Added: " + Shopadded + "Date Added"+ datetime);
                    mytextfile.Close();
                }
            }
        }

        #endregion




        #region Button Make Happy Sound
        private void button1_Click(object sender, EventArgs e)
        {
            
            //myspeechReader = new SpeechSynthesizer();
            myspeechReader.SpeakAsync("Woohoo!!!!!!!!!");

            LogFile(comboBox1.Text,DateTime.Now); // calling my logfile function

            // MessageBox.Show(comboBox1.SelectedIndex.ToString());

            var customers = new cutomer
            {
                storeID = comboBox1.SelectedIndex + 1,
                Dates = DateTime.Now
            };

            if (comboBox1.SelectedIndex >= 0)
            {
                //apllesEntity.GetAll();
                var context = new ApplesoftEntities();

                if (comboBox1.SelectedIndex == 0)
                {

                    using (var unitofwork = new UnitOfWork(new ApplesoftEntities()))
                    {
                        unitofwork.customer.Add(customers);
                        unitofwork.Complete();

                    }
                }
                else
                {

                    using (var unitofwork = new UnitOfWork(new ApplesoftEntities()))
                    {
                        unitofwork.customer.Add(customers);
                        unitofwork.Complete();

                    }
  
                }
            }
        }
        #endregion





        #region Populating dropdwonlist when the form load
        private void Form1_Load(object sender, EventArgs e)
        {
            using (var unitOfWork = new UnitOfWork(new ApplesoftEntities()))
            {
                var tt = unitOfWork.Store.GetAll();
                unitOfWork.Complete();
                foreach (var b in tt)
                    comboBox1.Items.Add(b.storeName);
            }
        }
        #endregion


      
        private void button1_Click_2(object sender, EventArgs e)
        {

            listBox2.DataSource = File.ReadAllLines(mypath);

        }

        private void btnHeadOffice_Click(object sender, EventArgs e)
        {
            List<string> DilsapyData = new List<string>();
            using (var unitOfWork = new UnitOfWork(new ApplesoftEntities()))
            {
                var sotrecustomers = unitOfWork.customer.GetStoreCustomer();
                var mostSelling = unitOfWork.customer.GetMostSelling();
                foreach (var customer in sotrecustomers)
                {
                    listBox1.Items.Add(customer.storeName);
                }

                foreach (var tt in mostSelling)
                {
                    listBox1.Items.Add(listBox1.Text+ tt.ToString());
                }
                listBox1.Items.Add("Highest Value"+unitOfWork.customer.GetMostSellingName().ToString());
                listBox1.Items.Add("Most Selling Shop is " + unitOfWork.Store.Get(unitOfWork.customer.GetMostSellingName()).storeName);
            }


        }
    }
}
