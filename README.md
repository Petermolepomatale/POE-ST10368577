Project Title: Recipe Manager Application

1.	How to Compile and Run Software
•	Prerequisites
Development Environment: Visual Studio with.NET Framework (version compatible with WPF apps).
 Steps to Compile and Run: 
Clone the repository.
	Clone or download the Recipe Manager repository from GitHub: Repository Link.
	Open the Solution in Visual Studio.
	Launch Visual Studio and open the RecipeWPFApp.sln solution file. Build the solution.
	Create the solution (Ctrl + Shift + B) and compile the program.
Set the Startup Project:
	If RecipeWPFApp is not already the starter project, set it to that.
	Run the application.
	To launch the program, press F5 or click the Start button.
2.	What Changed from Part 2
	Added ViewRecipeWindow.xaml and ViewRecipeWindow.xaml.cs.

	I added a new window (ViewRecipeWindow) to display recipe data such as ingredients, steps, and a warning about excessive calorie content.
Modified existing functionality:
	ViewRecipeWindow was integrated with existing classes (Recipe, Ingredient, Step, and RecipeManager) to show recipe data and manage user interactions.
	Added ScaleRecipeWindow.xaml and ScaleRecipeWindow.xaml.cs:
	I created a window (ScaleRecipeWindow) to enable for the scaling of component quantities in a recipe using a user-defined scaling factor.

