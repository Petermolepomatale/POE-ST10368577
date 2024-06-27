using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RecipeWPFApp
{
    public partial class MainWindow : Window
    {
        // Instance of RecipeManager to handle recipe-related operations
        private RecipeManager recipeManager;

        // MainWindow constructor
        public MainWindow()
        {
            InitializeComponent(); // Initialize the components
            recipeManager = new RecipeManager(); // Create a new instance of RecipeManager
            PopulateFoodGroupComboBox(); // Populate the FoodGroup ComboBox
        }

        // Method to populate the FoodGroup ComboBox with available food groups
        private void PopulateFoodGroupComboBox()
        {
            FoodGroupComboBox.ItemsSource = FoodGroup.FoodGroups;
        }

        // Method to refresh the Recipe ListView with the given recipes
        private void RefreshRecipeListView(IEnumerable<Recipe> recipes)
        {
            RecipeListView.ItemsSource = recipes;
            RecipeListView.Items.Refresh();
        }

        // Event handler for "Enter Recipe Details" button click
        private void EnterRecipeDetails_Click(object sender, RoutedEventArgs e)
        {
            var enterRecipeWindow = new EnterRecipeWindow(recipeManager);
            enterRecipeWindow.ShowDialog(); // Open the EnterRecipeWindow as a dialog
            RefreshRecipeListView(recipeManager.GetRecipes()); // Refresh the ListView after entering a new recipe
        }

        // Event handler for "View Recipe" button click
        private void ViewRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeListView.SelectedItem is Recipe selectedRecipe)
            {
                var viewRecipeWindow = new ViewRecipeWindow(selectedRecipe);
                viewRecipeWindow.ShowDialog(); // Open the ViewRecipeWindow as a dialog
            }
            else
            {
                MessageBox.Show("Please select a recipe to view."); // Show message if no recipe is selected
            }
        }

        // Event handler for "Scale Recipe" button click
        private void ScaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeListView.SelectedItem is Recipe selectedRecipe)
            {
                var scaleRecipeWindow = new ScaleRecipeWindow(selectedRecipe);
                scaleRecipeWindow.ShowDialog(); // Open the ScaleRecipeWindow as a dialog
                RefreshRecipeListView(recipeManager.GetRecipes()); // Refresh the ListView after scaling the recipe
            }
            else
            {
                MessageBox.Show("Please select a recipe to scale."); // Show message if no recipe is selected
            }
        }

        // Event handler for "Reset Quantities" button click
        private void ResetQuantities_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeListView.SelectedItem is Recipe selectedRecipe)
            {
                selectedRecipe.QuantitiesReset += SelectedRecipe_QuantitiesReset; // Subscribe to the QuantitiesReset event
                selectedRecipe.ResetQuantities(); // Reset quantities of the selected recipe
                selectedRecipe.QuantitiesReset -= SelectedRecipe_QuantitiesReset; // Unsubscribe to avoid memory leaks
                RefreshRecipeListView(recipeManager.GetRecipes()); // Refresh the ListView after resetting quantities
            }
            else
            {
                MessageBox.Show("Please select a recipe to reset quantities."); // Show message if no recipe is selected
            }
        }

        // Event handler for the QuantitiesReset event
        private void SelectedRecipe_QuantitiesReset(object sender, string message)
        {
            MessageBox.Show(message); // Display the message
        }

        // Event handler for "Clear Recipe" button click
        private void ClearRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeListView.SelectedItem is Recipe selectedRecipe)
            {
                recipeManager.ClearRecipe(selectedRecipe); // Clear the selected recipe
                RefreshRecipeListView(recipeManager.GetRecipes()); // Refresh the ListView after clearing the recipe
            }
            else
            {
                MessageBox.Show("Please select a recipe to clear."); // Show message if no recipe is selected
            }
        }

        // Event handler for "Exit" button click
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); // Shut down the application
        }

        // Event handler for "Filter by Ingredient" button click
        private void FilterByIngredient_Click(object sender, RoutedEventArgs e)
        {
            string ingredient = IngredientFilterTextBox.Text;
            if (!string.IsNullOrWhiteSpace(ingredient))
            {
                var filteredRecipes = recipeManager.FilterByIngredient(ingredient);
                RefreshRecipeListView(filteredRecipes); // Refresh the ListView with filtered recipes
            }
        }

        // Event handler for "Filter by Food Group" button click
        private void FilterByFoodGroup_Click(object sender, RoutedEventArgs e)
        {
            if (FoodGroupComboBox.SelectedItem is string foodGroup)
            {
                var filteredRecipes = recipeManager.FilterByFoodGroup(foodGroup);
                RefreshRecipeListView(filteredRecipes); // Refresh the ListView with filtered recipes
            }
        }

        // Event handler for "Filter by Calories" button click
        private void FilterByCalories_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(MaxCaloriesTextBox.Text, out double maxCalories))
            {
                var filteredRecipes = recipeManager.FilterByCalories(maxCalories);
                RefreshRecipeListView(filteredRecipes); // Refresh the ListView with filtered recipes
            }
        }

        // Event handler for RecipeListView selection change
        private void RecipeListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Placeholder for any additional logic when the selection changes
        }
    }
}
