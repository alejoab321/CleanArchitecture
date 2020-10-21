using ApplicationTeatro.ObraApp;
using ApplicationTeatro.PersonApp;
using ApplicationTeatro.TeatroApp;
using Domain.Entities;
using Domain.Entities.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppTeatro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IPersonaApp _personaApp;
        private readonly ITeatroApp _teatroApp;
        private readonly IObraApp _obraApp;
        public MainWindow(IPersonaApp personaApp,ITeatroApp teatroApp,IObraApp obraApp)
        {
            _personaApp = personaApp;
            _teatroApp = teatroApp;
            _obraApp = obraApp;
            InitializeComponent();
        }
        protected async override void OnInitialized(EventArgs e)
        {
            var personaList =  await _personaApp.GetEspectadors();
            var teatroList = await _teatroApp.GetAllTeatro();
            DG.ItemsSource = personaList;
            DGTeatro.ItemsSource = teatroList;
            base.OnInitialized(e);
        }

        private void DG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var personIteM = (Espectador)DG.CurrentItem;
            var pr = personIteM.IdPersona;
        }

        private void DGTeatro_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var teatroItem = (Teatro)DGTeatro.CurrentItem;
            var result =  _obraApp.GetObrasByIdTeatro(teatroItem.IdTeatro).Result;
        }
    }
}
