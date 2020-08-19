using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Test1
{
    public partial class Form1 : Form
    {
        //Name: Cameron Nepe
        //IDNo: 1262199

        //constants for the maximum QR code number
        const int MAX_CODE = 24;

        List<DoorEntry> doorEntriesList = new List<DoorEntry>();
        
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialise a clear this list to an empty then creates a new list
        /// </summary>
        public void UpdateListBoxCodes()
        {
            listBoxCodes.Items.Clear();
            // loop through list and display data on the listbox
            foreach (DoorEntry d in doorEntriesList)
            {
                listBoxCodes.Items.Add(d);
            }
        }

        /// <summary>
        /// Exit the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Open file menu item opens a dialogue window that lets user select an input file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // get the file reader
            StreamReader reader;
            // variable to read the line
            string line = "";
            // array to handle the splitting of values from csv file
            string[] csvArray;

            string studentID = "";
            int doorCode = 0;
            string status = "";

            // open the file
            openFileDialog1.Filter = "CSV Files|*.csv|ALL Files|*.*";
            // check that user clicks on the OK button
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // read the file
                reader = File.OpenText(openFileDialog1.FileName);
                while (!reader.EndOfStream)
                {
                    try
                    {
                        // read a line from the file
                        line = reader.ReadLine();
                        // split the line using an array
                        csvArray = line.Split(',');
                        // check if the array has the correct number of elements in that line
                        if (csvArray.Length == 3)
                        {
                            // extract values out
                            studentID = csvArray[0];
                            doorCode = int.Parse(csvArray[1]);
                            status = csvArray[2];

                            // create an object and add to the door entries list
                            DoorEntry d = new DoorEntry(studentID, doorCode, status);
                            doorEntriesList.Add(d);
                        }
                        else
                        {
                            Console.WriteLine("Error: " + line);
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Error: " + line);
                    }
                }
                reader.Close();
                //MessageBox.Show(doorEntries.Count.ToString());
                UpdateListBoxCodes();
            }
        }

        private void totalEntriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // calculate the total number of 'in' and the total number of 'out'
            //int totalIN = 0;
            //int totalOUT = 0;

            //foreach (DoorEntry d in doorEntriesList)
            //{
            //    if (d.Status == )
            //}
            
        }
    }
}
