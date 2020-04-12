using Xamarin.Forms;
using TestApp2.Services;
using TestApp2.Views;
using TestApp2.Services.Persistance.Impl;

namespace TestApp2
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            //var productItemStore = new SQLiteProductItemDataStore(DependencyService.Get<ISQLLiteDb>());
            //DependencyService.Register<>();
            DependencyService.Register<SQLiteProductItemDataStore>();
            DependencyService.Register<MockDataStoreShoppingList>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
