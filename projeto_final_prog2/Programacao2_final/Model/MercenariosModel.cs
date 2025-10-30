using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Programacao2_final.Model
{
    public class MercenariosModel :UIElement
    {
        public MercenariosModel() {
            iniciar(1);
        }
        public void GravaMerc(Object parameter)
        {
            Mercenarios_Hub hub = main.frame.Content as Mercenarios_Hub;
            int id = MercenariosCorrente.Idmerc;
            mercenarios este = db.mercenarios.Find(id);
            if (este != null)
            {
                este.rank = MercenariosCorrente.rank;
                este.nome = MercenariosCorrente.nome;
                este.pdia = MercenariosCorrente.pdia;
                db.SaveChanges();
                iniciar(id);
            }
        }
        public void apagarMerc(Object parameter)
        {
            try
            {
                int id = MercenariosCorrente.Idmerc;
                mercenarios morto = db.mercenarios.Find(id);
                if (morto != null)
                {
                    db.mercenarios.Remove(morto);
                    db.SaveChanges();
                }

                iniciar(1);
            }
            catch (SqlException erro)
            {

                MessageBox.Show(erro.Message);
            }

        }
        public void inserirMerc(Object parameter)
        {
            int novoid = db.mercenarios.Max(X => X.Idmerc) + 1;
            db.mercenarios.Add(new mercenarios() { Idmerc = novoid });
            db.SaveChanges();
            iniciar(1);
            ViewMerc.MoveCurrentToLast();
        }


        MainWindow main = (MainWindow)App.Current.MainWindow;
        public ObservableCollection<mercenarios> ListaMerc
        {
            get { return (ObservableCollection<mercenarios>)GetValue(ListaMercProperty); }
            set { SetValue(ListaMercProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ListaMerc.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ListaMercProperty =
            DependencyProperty.Register("ListaMerc", typeof(ObservableCollection<mercenarios>), typeof(MercenariosModel), new PropertyMetadata(null));



        public ObservableCollection<nomes> ListaNomes
        {
            get { return (ObservableCollection<nomes>)GetValue(ListaNomesProperty); }
            set { SetValue(ListaNomesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ListaNomes.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ListaNomesProperty =
            DependencyProperty.Register("ListaNomes", typeof(ObservableCollection<nomes>), typeof(MercenariosModel), new PropertyMetadata(null));




        public ICollectionView ViewMerc     
        {
            get { return (ICollectionView)GetValue(ViewMercProperty); }
            set { SetValue(ViewMercProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ViewMerc.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ViewMercProperty =
            DependencyProperty.Register("ViewMerc", typeof(ICollectionView), typeof(MercenariosModel), new PropertyMetadata(null));



        public mercenarios MercenariosCorrente
        {
            get { return (mercenarios)GetValue(MercenariosCorrenteProperty); }
            set { SetValue(MercenariosCorrenteProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MercenariosCorrente.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MercenariosCorrenteProperty =
            DependencyProperty.Register("MercenariosCorrente", typeof(mercenarios), typeof(MercenariosModel), new PropertyMetadata(null));

        public Database1Entities  db = new Database1Entities();
        public void iniciar(int? id)
        {
            ListaMerc = new ObservableCollection<mercenarios>(db.mercenarios.ToList());
            ViewMerc = CollectionViewSource.GetDefaultView(ListaMerc);
            if (id == null) ViewMerc.MoveCurrentToFirst();
            else ViewMerc.MoveCurrentTo(ListaMerc.Where(x => x.Idmerc == (id ?? 1)).FirstOrDefault());
            MercenariosCorrente = ViewMerc.CurrentItem as mercenarios;
            ViewMerc.CurrentChanged += ViewMerc_CurrentChanged;
            ListaNomes = new ObservableCollection<nomes>(db.nomes.ToList());

        }

        private void ViewMerc_CurrentChanged(object sender, EventArgs e)
        {
            MercenariosCorrente = ViewMerc.CurrentItem as mercenarios;
        }

        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        private bool _disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // TODO: dispose managed state (managed objects).
                db.Dispose();
            }

            // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
            // TODO: set large fields to null.

            _disposed = true;
        }
    }
    }
