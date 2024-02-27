using System.Collections.ObjectModel;

namespace FirstMauiApp
{
    
    public partial class MainPage : ContentPage
    { public class Product
        {
            public string Name { get; set; }
            public double Price { get; set; }

            public Product( ) { }
        }
        int count = 0;

        public ObservableCollection<string> Items = new ObservableCollection<string>();
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();
        public MainPage()
        {
            InitializeComponent();
            TestListView.ItemsSource = Items;
            ProductListView.ItemsSource = Products;
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count+=10;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
        private void HelloButton_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Hello", HelloEditor.Text, "OK");
        }

        private void AddItem_Clicked(object sender, EventArgs e)
        {
            Items.Add(ListEditor.Text);
        }

        private void RemoveItem_Clicked(object sender, EventArgs e)
        {
            if (TestListView.SelectedItem != null)
            {
                Items.Remove(TestListView.SelectedItem.ToString());
            }
            else
            {
                DisplayAlert("Hello", "all items are removed", "OK");
            }
            
        }

        private void AddProduct_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ProductListEditor.Text) && double.TryParse(PriceEditor.Text,out double price))
            {
                var newproduct = new Product { Name = ProductListEditor.Text, Price = price};
                Products.Add(newproduct);
            }
            else
            {
                DisplayAlert("Invalid input", "Please enter a valid prduct name and price.", "OK");
            }
            
        }
        private void RemoveProduct_Clicked(object sender, EventArgs e)
        {
            if (ProductListView.SelectedItem != null)
            {
               
                Products.Remove((Product)ProductListView.SelectedItem);
            }
            else
            {
                DisplayAlert("Hello", "all items are removed", "OK");
            }

        }



    }

}
