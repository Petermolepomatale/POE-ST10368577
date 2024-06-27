using System.Collections.ObjectModel;
using System.Windows;

namespace RecipeWPFApp
{
    public partial class ViewRecipeWindow : Window
    {
        public ObservableCollection<Step> Steps { get; set; }

        public ViewRecipeWindow(Recipe selectedRecipe)
        {
            InitializeComponent();
            LoadRecipe(selectedRecipe);
        }

        private void LoadRecipe(Recipe recipe)
        {
            RecipeNameTextBlock.Text = recipe.Name;
            IngredientsListView.ItemsSource = recipe.Ingredients;
            Steps = new ObservableCollection<Step>(recipe.Steps);
            StepsListView.ItemsSource = Steps;

            if (recipe.TotalCalories > 300)
            {
                WarningTextBlock.Visibility = Visibility.Visible;
            }
            else
            {
                WarningTextBlock.Visibility = Visibility.Collapsed;
            }
        }

        private void Done_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void IngredientsListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Placeholder for additional logic
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            // Placeholder for CheckBox checked event logic
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            // Placeholder for CheckBox unchecked event logic
        }
    }
}
