using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeWPFApp
{
    public class RecipeManager
    {
        // List to store recipes
        private List<Recipe> recipes;

        // Constructor to initialize the recipes list
        public RecipeManager()
        {
            recipes = new List<Recipe>();
        }

        // Method to add a new recipe
        public void AddRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
        }

        // Method to get all recipes sorted by name
        public List<Recipe> GetRecipes()
        {
            return recipes.OrderBy(r => r.Name).ToList();
        }

        // Method to remove a recipe from the list
        public void ClearRecipe(Recipe recipe)
        {
            recipes.Remove(recipe);
        }

        // Method to filter recipes by ingredient name
        public IEnumerable<Recipe> FilterByIngredient(string ingredient)
        {
            return recipes.Where(r => r.Ingredients.Any(i => i.Name.Contains(ingredient, StringComparison.OrdinalIgnoreCase))).ToList();
        }

        // Method to filter recipes by food group
        public IEnumerable<Recipe> FilterByFoodGroup(string foodGroup)
        {
            return recipes.Where(r => r.Ingredients.Any(i => i.FoodGroup.Equals(foodGroup, StringComparison.OrdinalIgnoreCase))).ToList();
        }

        // Method to filter recipes by maximum calories
        public IEnumerable<Recipe> FilterByCalories(double maxCalories)
        {
            return recipes.Where(r => r.TotalCalories <= maxCalories).ToList();
        }
    }

    public class Recipe
    {
        // Name of the recipe
        public string Name { get; set; }
        // List of ingredients in the recipe
        public List<Ingredient> Ingredients { get; set; }
        // List of steps to prepare the recipe
        public List<Step> Steps { get; set; }
        // Total calories calculated from the sum of ingredient calories
        public double TotalCalories => Ingredients.Sum(i => i.Calories);

        // Define an event for notifying when quantities are reset
        public event EventHandler<string> QuantitiesReset;

        // Constructor to initialize the ingredients and steps lists
        public Recipe()
        {
            Ingredients = new List<Ingredient>();
            Steps = new List<Step>();
        }

        // Method to reset ingredient quantities to their original values
        public void ResetQuantities()
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity = ingredient.OriginalQuantity;
            }

            // Trigger the event after resetting quantities
            OnQuantitiesReset($"Quantities reset to original for recipe: {Name}");
        }

        // Protected method to raise the QuantitiesReset event
        protected virtual void OnQuantitiesReset(string message)
        {
            QuantitiesReset?.Invoke(this, message);
        }
    }

    public class Step
    {
        // Description of the step
        public string Description { get; set; }
        // Indicates if the step is completed
        public bool IsCompleted { get; set; }
    }

    public class Ingredient
    {
        // Name of the ingredient
        public string Name { get; set; }
        // Current quantity of the ingredient
        public double Quantity { get; set; }
        // Original quantity of the ingredient
        public double OriginalQuantity { get; set; }
        // Unit of measurement for the ingredient
        public string Unit { get; set; }
        // Calories for the given quantity of the ingredient
        public double Calories { get; set; }
        // Food group to which the ingredient belongs
        public string FoodGroup { get; set; }
    }

    public static class FoodGroup
    {
        // Static array of food groups
        public static readonly string[] FoodGroups = new string[]
        {
            "Vegetables",
            "Fruits",
            "Grains",
            "Protein",
            "Dairy",
            "Fats and Oils",
            "Sweets"
        };
    }
}
