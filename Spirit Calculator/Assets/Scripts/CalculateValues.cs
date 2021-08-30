using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CalculateValues : MonoBehaviour
{
    // Declare all Text objects to get user input from
    [SerializeField]
    Text weightInput;

    [SerializeField]
    Text tempInput;

    [SerializeField]
    Text abvInput;

    [SerializeField]
    Text densityInput;

    [SerializeField]
    Text reqAbvInput;

    [SerializeField]
    Text bulkLitresInput;

    // Declare public game objects to be used by the script
    [SerializeField]
    GameObject errorMessage;

    [SerializeField]
    GameObject calculateValuesScreen;

    [SerializeField]
    GameObject finalValuesScreen;

    public void RunCalculations()
    {
        // Declare value ints to convert input text's
        float weightFloat;
        float tempFloat;
        float abvFloat;
        float densityFloat;
        float bulkLitresFloat;
        float reqAbvFloat;

        // Convert user input to ints
        float.TryParse(weightInput.text, out weightFloat);
        float.TryParse(tempInput.text, out tempFloat);
        float.TryParse(abvInput.text, out abvFloat);
        float.TryParse(densityInput.text, out densityFloat);
        float.TryParse(bulkLitresInput.text, out bulkLitresFloat);
        float.TryParse(reqAbvInput.text, out reqAbvFloat);

        // Display converted ints in console
        Debug.Log("Weight: " + weightFloat);
        Debug.Log("Temperature: " + tempFloat);
        Debug.Log("Abv %: " + abvFloat);
        Debug.Log("Density: " + densityFloat);
        Debug.Log("Bulk Litres: " + bulkLitresFloat);
        Debug.Log("Required Abv %: " + reqAbvFloat);

        // Check if user entered at least Weight or Density, if not, show error message
        if (weightInput.text == "" && bulkLitresInput.text == "")
        {
            Debug.Log("NO WEIGHT OR BULK LITRES!! Display warning...");
            errorMessage.SetActive(true);
            calculateValuesScreen.SetActive(false);
            return;
        }

        // Convert Abv %'s to decimal
        float decimal_abvFloat = abvFloat / 100;
        float decimal_reqAbvFloat = reqAbvFloat / 100;

        // Check if conversion ran - print values to console
        Debug.Log("Decimal %'s");
        Debug.Log("Decimal Abv %: " + decimal_abvFloat);
        Debug.Log("Decimal Required Abv %: " + decimal_reqAbvFloat);

        // Calculate Bulk Litres (L) - check if user inputs value for this, if not run calculation
        // Bulk Litres = Weight / Density
        if (bulkLitresInput.text == "")
        {
            Debug.Log("NO BULK LITRES! Calculating Bulk Litres...");
            bulkLitresFloat = weightFloat / densityFloat;
            Debug.Log("Calculated Bulk Litres: " + bulkLitresFloat);
        }

        // Calculate Litres of Pure Alcohol = Bulk litres * Decimal Abv %
        Debug.Log("Calculating Litres of Pure Alcohol...");
        float pureAlcoholLitres = bulkLitresFloat * decimal_abvFloat;
        Debug.Log("Litres of Pure Alcohol: " + pureAlcoholLitres);

        // Calculate Water Required = (Litres of pure alcohol / Decimal Required Abv %) - Bulk Litres
        Debug.Log("Calculating Water Required...");
        float waterRequired = (pureAlcoholLitres / decimal_reqAbvFloat) - bulkLitresFloat;
        Debug.Log("Water Required: " + waterRequired);

        // Caclulate Total Bulk Litres = Bulk Litres + Water Required
        Debug.Log("Calculating Total Bulk Litres...");
        float totalBulkLitres = bulkLitresFloat + waterRequired;
        Debug.Log("Total Bulk Litres: " + totalBulkLitres);

        // Display final values screen to player - disable enter values screen
        finalValuesScreen.SetActive(true);
        calculateValuesScreen.SetActive(false);
    }
}
