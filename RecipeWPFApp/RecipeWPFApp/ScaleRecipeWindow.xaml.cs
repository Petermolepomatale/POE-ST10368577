using System;
using System.Windows;

namespace RecipeWPFApp
{
    public partial class ScaleRecipeWindow : Window
    {
        // Reference to the recipe to be scaled
        private Recipe recipe;

        // Constructor for ScaleRecipeWindow
        public ScaleRecipeWindow(Recipe recipe)
        {
            InitializeComponent(); // Initialize the components
            this.recipe = recipe; // Set the recipe instance
        }

        // Event handler for the Scale button click
        private void Scale_Click(object sender, RoutedEventArgs e)
        {
            // Try to parse the scaling factor from the text box
            if (double.TryParse(ScalingFactorTextBox.Text, out double scalingFactor))
            {
                // Scale each ingredient's quantity by the scaling factor
                foreach (var ingredient in recipe.Ingredients)
                {
                    ingredient.Quantity *= scalingFactor;
                }
                // Show a success message
                MessageBox.Show("Recipe scaled successfully.");
                // Close the window
                this.Close();
            }
            else
            {
                // Show an error message if the scaling factor is invalid
                MessageBox.Show("Invalid scaling factor.");
            }
        }
    }
}
