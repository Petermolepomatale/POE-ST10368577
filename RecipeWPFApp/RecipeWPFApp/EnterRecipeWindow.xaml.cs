using System;
using System.Windows;

namespace RecipeWPFApp
{
    public partial class EnterRecipeWindow : Window
    {
        // Instance of RecipeManager to handle recipe-related operations
        private RecipeManager recipeManager;
        // Current recipe being entered
        private Recipe currentRecipe;

        // Constructor for EnterRecipeWindow
        public EnterRecipeWindow(RecipeManager recipeManager)
        {
            InitializeComponent(); // Initialize the components
            this.recipeManager = recipeManager; // Set the RecipeManager instance
            currentRecipe = new Recipe(); // Create a new Recipe instance
            FoodGroupComboBox.ItemsSource = FoodGroup.FoodGroups; // Populate the FoodGroup ComboBox
        }

        // Event handler for "Add Ingredient" button click
        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Retrieve input values from text boxes and combo box
                string name = IngredientNameTextBox.Text;
                double quantity = double.Parse(QuantityTextBox.Text);
                string unit = UnitTextBox.Text;
                double calories = double.Parse(CaloriesTextBox.Text);
                string foodGroup = FoodGroupComboBox.SelectedItem.ToString();

                // Create a new Ingredient object
                Ingredient ingredient = new Ingredient
                {
                    Name = name,
                    Quantity = quantity,
                    OriginalQuantity = quantity, // Set the OriginalQuantity
                    Unit = unit,
                    Calories = calories,
                    FoodGroup = foodGroup
                };

                // Add the ingredient to the current recipe
                currentRecipe.Ingredients.Add(ingredient);
                // Add a description of the ingredient to the IngredientsListView
                IngredientsListView.Items.Add($"{quantity} {unit} of {name} ({calories} calories, {foodGroup})");
                // Clear input fields
                ClearIngredientInputs();
            }
            catch (Exception ex)
            {
                // Show an error message if an exception occurs
                MessageBox.Show($"Error adding ingredient: {ex.Message}");
            }
        }

        // Event handler for "Add Step" button click
        private void AddStep_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve the step description from the text box
            string stepDescription = StepTextBox.Text;
            // Create a new Step object
            Step step = new Step
            {
                Description = stepDescription,
                IsCompleted = false // Initially, the step is not completed
            };
            // Add the step to the current recipe
            currentRecipe.Steps.Add(step);
            // Add the step description to the StepsListView
            StepsListView.Items.Add(stepDescription);
            // Clear the StepTextBox
            StepTextBox.Clear();
        }

        // Event handler for "Save Recipe" button click
        private void SaveRecipe_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Set the recipe name from the text box
                currentRecipe.Name = RecipeNameTextBox.Text;
                // Add the recipe to the RecipeManager
                recipeManager.AddRecipe(currentRecipe);
                // Show a success message
                MessageBox.Show("Recipe saved successfully.");
                // Close the window
                this.Close();
            }
            catch (Exception ex)
            {
                // Show an error message if an exception occurs
                MessageBox.Show($"Error saving recipe: {ex.Message}");
            }
        }

        // Method to clear ingredient input fields
        private void ClearIngredientInputs()
        {
            IngredientNameTextBox.Clear();
            QuantityTextBox.Clear();
            UnitTextBox.Clear();
            CaloriesTextBox.Clear();
            FoodGroupComboBox.SelectedIndex = -1; // Reset the selected index
        }
    }
}
