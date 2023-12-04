using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Purchase1 : MonoBehaviour
{
    public TextMeshProUGUI data;
    public TextMeshProUGUI year;

    private Dictionary<int, string> dataDict = new Dictionary<int, string>()
{
    { 2018, "825,535,563" },
    { 2019, "749,155,486" },
    { 2020, "980,549,938" },
    { 2021, "962,067,878" },
    { 2022, "726,080,844" },
    { 2023, "294,000,000" },
    { 2024, "309,000,000" }
};

    private List<int> years = new List<int>()
{
    2018, 2019, 2020, 2021, 2022, 2023, 2024
};

    private Coroutine dataCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        dataCoroutine = StartCoroutine(ShowDataSequentially());
    }

    // Coroutine to show data sequentially
    IEnumerator ShowDataSequentially()
    {
        int currentIndex = 0;

        while (true)
        {
            int currentYear = years[currentIndex];
            int nextIndex = currentIndex == years.Count - 1 ? 0 : currentIndex + 1;
            int nextYear = years[nextIndex];

            string currentData = dataDict[currentYear];
            string nextData = dataDict[nextYear];
            float elapsedTime = 0f;
            int currentNumber = int.Parse(currentData.Replace(",", ""));
            int nextNumber = int.Parse(nextData.Replace(",", ""));
            float duration = 3f; // Adjust the duration here

            while (elapsedTime < duration)
            {
                float t = elapsedTime / duration;
                int interpolatedNumber = Mathf.RoundToInt(Mathf.Lerp(currentNumber, nextNumber, t));
                string interpolatedData = interpolatedNumber.ToString("N0");
                data.text = interpolatedData + "원"; // "원"을 붙여 표시

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            currentIndex = nextIndex;
            year.text = nextYear.ToString();
            data.text = nextData + "원"; // "원"을 붙여 표시

            yield return new WaitForSeconds(5f); // Adjust the delay time here
        }
    }

    // Stop the coroutine when the scene is stopped
    private void OnDisable()
    {
        StopCoroutine(dataCoroutine);
    }
}
