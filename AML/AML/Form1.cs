﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AML
{
    public partial class Form1 : Form

    {
        private List<String> newList;      //New webpage
        private List<String> oldList;      //Old Webpage
        private DateTime pageChange ;
        private readonly string url = "https://www.treasury.gov/ofac/downloads/sdnlist.txt";
        private HttpWebRequest myHttpWebRequest;

        private WebClient client;

        public Form1()
        {
            InitializeComponent();
            newList = new List<String>();
            oldList = new List<String>();
          }


        private void button1_Click(object sender, EventArgs e)      //Start button
        {
            using (client = new WebClient())
            {
                                
                client.DownloadStringCompleted += (s, ev) =>        //Download complete
                {
                    oldList = ev.Result.Split('\r').ToList();       //spit webpage up into paragraphs using the carriage return
                    Console.WriteLine("Start Timer");
                    timer1.Tick += Timer1_Tick;                     //Start timer, every 10 seconds re-download webpage
                    timer1.Interval = 10 * 1000;
                    timer1.Start();
                    client.Dispose();

                    // Creates an HttpWebRequest for the specified URL. 
                    myHttpWebRequest = (HttpWebRequest) WebRequest.Create(new Uri(url));
                    HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
                    pageChange = myHttpWebResponse.LastModified;
                    labelStartTime.Text = "Baseline: " + pageChange.ToString();
                    myHttpWebResponse.Close();
                };
                
                   client.DownloadStringAsync(new Uri(url));                               //Download webpage as one string
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
             // Creates an HttpWebRequest for the specified URL. 
            myHttpWebRequest = (HttpWebRequest)WebRequest.Create(new Uri(url));
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
            Console.WriteLine("check");

            labelLastChecked.Text = "Last modified: " + myHttpWebResponse.LastModified.ToString();
            if (DateTime.Compare(myHttpWebResponse.LastModified, pageChange) > 0)       //check to see if website has been updtaed
            {
                Console.WriteLine("\nThe requested URI was last modified on:{0}", myHttpWebResponse.LastModified);
             

                using (client = new WebClient())
                {

                    client.DownloadStringCompleted += (s, ev) =>
                    {
                        newList.AddRange(ev.Result.Split('\r').ToList());       //Dowload the webpage again to check for any changes
                        Console.WriteLine("Get new webpage");

                        for (int i = 0; i < newList.Count; i++)
                        {
                            if (!oldList.Contains(newList[i]))                  //loop through the new webpage to check for any changes or additons in the new webpage
                            {
                                Changes.Items.Add("Updated: " + newList[i] + '\r');     //display in the dialogue box any changes
                            }
                        }

                        for (int j = 0; j < oldList.Count; j++)
                        {
                            if (!newList.Contains(oldList[j]))                  //loop through the old webapage to check if any items have been deleted
                            {
                                Changes.Items.Add("Deleted: " + oldList[j] + '\r');
                            }
                        }

                        oldList.Clear();                //set the new list/webapge to become the old list/webage to check next time, used instead off oldList=newList                             
                        oldList.AddRange(newList);
                        newList.Clear();
                        client.Dispose();
                    };

                
                    client.DownloadStringAsync(new Uri(url));
                }

                pageChange = myHttpWebResponse.LastModified;
            }

            myHttpWebResponse.Close();
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Method for checking program using text files on Hard drive
    /*
     *public partial class Form1 : Form

    {
        List<String> newList = new List<String>();
        List<String> oldList = new List<String>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = System.IO.File.ReadAllText(@"C:\Users\Study\Documents\listing1.txt");

            newList = url.Split(',').ToList();

            timer1.Tick += Timer1_Tick;
            timer1.Interval = 5 * 1000;
            timer1.Start();

            
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            string url = System.IO.File.ReadAllText(@"C:\Users\Study\Documents\listing2.txt");

            oldList = newList;
            newList = url.Split(',').ToList();

            for (int i = 0; i < newList.Count; i++)
            {
                if (!oldList.Contains(newList[i]))
                {
                    Changes.Items.Add("Updated: " + newList[i] + '\r');
                }
            }

            for (int j = 0; j < oldList.Count; j++)
            {
                if (!newList.Contains(oldList[j]))
                {
                    Changes.Items.Add("Deleted: " + oldList[j] + '\r');
                }
            }

            oldList = newList;
        }
    }
    */
}
