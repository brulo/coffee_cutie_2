using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
/* using System; */

public class RecipeBookGui : MonoBehaviour {
	public Text leftPageText;
	public Text rightPageText;
	RecipeBook recipeBook = new RecipeBook();
	private int leftPageIndex = 0;

	void Start() {
			leftPageText.text = recipeBook.AllRecipes[leftPageIndex].RecipeBookText;
			rightPageText.text = recipeBook.AllRecipes[leftPageIndex+1].RecipeBookText;
			TurnPage(1);
			TurnPage(-1);
	}

	// Use positive/negative number to flip that many pages left/right.
	public void TurnPage(int numPageTurns) {
		int numPagesToTurn = numPageTurns * 2;
		int newPageIndex = leftPageIndex + numPagesToTurn;

		if((newPageIndex >= 0) & (newPageIndex < recipeBook.AllRecipes.Length)) {
			leftPageIndex = newPageIndex;
			leftPageText.text = recipeBook.AllRecipes[leftPageIndex].RecipeBookText;

			int rightPageIndex = leftPageIndex + 1;
			if(rightPageIndex < recipeBook.AllRecipes.Length) {
				rightPageText.text = recipeBook.AllRecipes[rightPageIndex].RecipeBookText;
			}
			else {
				rightPageText.text = "";
			}
		}
	}
}
