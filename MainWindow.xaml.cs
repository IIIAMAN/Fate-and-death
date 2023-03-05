using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;

namespace PraKTICHESKAYATWOOOOO
{
    public partial class MainWindow : Window
    {
        public M_type zametka = new M_type();
        public List<M_type> List_m_klass = new List<M_type>();
        public string selected;
        public Dictionary<string, List<M_type>> kaka = new Dictionary<string, List<M_type>>();


        public MainWindow()
        {
            InitializeComponent();
            datepicker.SelectedDate = DateTime.Now;
        }

        public void obnovlenie_spiska()
        {
            try
            {
                if (spisok.Items.Count > 0) 
                {
                    spisok.Items.Clear();
                }
                
                nazvaniezametka.Text = null;
                opisaniezametka.Text = null;

                Dictionary<string, List<M_type>> deserialize = Class2.MyDeserialize<Dictionary<string, List<M_type>>>();
                var jojo = deserialize;
                foreach (var item in jojo)
                {
                    if (item.Key == datepicker.Text)
                    {
                        foreach (var item1 in item.Value)
                        {
                            spisok.Items.Add(item1.names);
                        }
                    }
                }
            }
            catch (Exception)
            {
                obnovlenie_spiska();
            }
        }

        private void datepicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                spisok.Items.Clear();
                nazvaniezametka.Text = null;
                opisaniezametka.Text = null;

                Dictionary<string, List<M_type>> deserialize = Class2.MyDeserialize<Dictionary<string, List<M_type>>>();
                var jojo = deserialize;

                foreach (var item in jojo)
                {
                    if (item.Key == datepicker.Text)
                    {
                        foreach (var item1 in item.Value)
                        {
                            spisok.Items.Add(item1.names);
                        }
                    }
                }
            }
            catch (Exception)
            {
                datepicker_SelectedDateChanged(sender, e);
            }
        }

        void nachalo()
        {
            Dictionary<string, List<M_type>> deserialize = Class2.MyDeserialize<Dictionary<string, List<M_type>>>();
            var jojo = deserialize;

            zametka.names = nazvaniezametka.Text;
            zametka.opisanies = opisaniezametka.Text;
            zametka.dates = datepicker.Text;

            foreach (var item in jojo)
            {
                if (item.Key == datepicker.Text)
                {
                    jojo[item.Key].Add(List_m_klass.LastOrDefault());
                    spisok.Items.Add(nazvaniezametka.Text);
                    Class2.MySerialize(jojo);
                    List_m_klass.Clear();
                }
            }
        }
        void eshenashalo()
        {
            List_m_klass.Clear();

            Dictionary<string, List<M_type>> deserialize = Class2.MyDeserialize<Dictionary<string, List<M_type>>>();
            var jojo = deserialize;

            zametka.names = nazvaniezametka.Text;
            zametka.opisanies = opisaniezametka.Text;
            zametka.dates = datepicker.Text;

            List_m_klass.Add(zametka);

            jojo.Add(datepicker.Text, List_m_klass);

            spisok.Items.Add(nazvaniezametka.Text);

            Class2.MySerialize(jojo);
            nazvaniezametka.Text = null;
            opisaniezametka.Text = null;
        }
        private void Delete_click(object sender, RoutedEventArgs e)
        {
            try
            {
                Dictionary<string, List<M_type>> deserialize = Class2.MyDeserialize<Dictionary<string, List<M_type>>>();
                var jojo = deserialize;

                foreach (var item in jojo)
                {
                    if (item.Key == datepicker.Text)
                    {
                        jojo[item.Key].Remove(item.Value[spisok.SelectedIndex]);
                        Class2.MySerialize(jojo);
                        obnovlenie_spiska();
                    }
                }
            }
            catch (Exception)
            {

            }
            
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Dictionary<string, List<M_type>> deserialize = Class2.MyDeserialize<Dictionary<string, List<M_type>>>();
                var jojo = deserialize;

                List_m_klass.Add(zametka);

                if (jojo.Count == 0)
                {
                    eshenashalo();
                }
                else
                {
                    foreach (var item in jojo)
                    {
                        if (item.Key == datepicker.SelectedDate.Value.ToShortDateString())
                        {
                            nachalo();
                            break;
                        }
                    }
                    foreach (var item in jojo)
                    {
                        if (item.Key != datepicker.SelectedDate.Value.ToShortDateString())
                        {
                            eshenashalo();
                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void Rename_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Dictionary<string, List<M_type>> deserialize = Class2.MyDeserialize<Dictionary<string, List<M_type>>>();
                var jojo = deserialize;

                foreach (var item in jojo)
                {
                    if (item.Key == datepicker.Text)
                    {
                        foreach (var item1 in item.Value)
                        {
                            if (item1.names == spisok.SelectedItem.ToString())
                            {
                                item1.names = nazvaniezametka.Text;
                                item1.opisanies = opisaniezametka.Text;
                                Class2.MySerialize(jojo);
                                obnovlenie_spiska();
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                Rename_Click(sender, e);
            }
        }

        private void opisaniezametka_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void nazvaniezametka_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void spisok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                nazvaniezametka.Text = spisok.SelectedItem.ToString();
                Dictionary<string, List<M_type>> deserialize = Class2.MyDeserialize<Dictionary<string, List<M_type>>>();
                var jojo = deserialize;

                foreach (var item in jojo)
                {
                    if (item.Key == datepicker.Text)
                    {
                        foreach (var item1 in item.Value)
                        {
                            if (nazvaniezametka.Text == item1.names)
                            {
                                opisaniezametka.Text = item1.opisanies;
                                selected = null; break;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}