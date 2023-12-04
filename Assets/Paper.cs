/*
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Paper : MonoBehaviour
{
    public TextMeshProUGUI data;
    public TextMeshProUGUI year;
    public TextMeshProUGUI ratio;

    private Dictionary<int, string> dataDict = new Dictionary<int, string>()
{
    { 2018, "231,240,297" },
    { 2019, "210,829,712" },
    { 2020, "191,449,254" },
    { 2021, "180,476,151" },
    { 2022, "176,119,404" },
    { 2023, "171,000,000" },
    { 2024, "165,000,000" }
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
*/

/*
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Paper : MonoBehaviour
{
    public TextMeshProUGUI data;
    public TextMeshProUGUI year;
    public TextMeshProUGUI ratio;

    private Dictionary<int, string> dataDict = new Dictionary<int, string>()
{
    { 2018, "231,240,297" },
    { 2019, "210,829,712" },
    { 2020, "191,449,254" },
    { 2021, "180,476,151" },
    { 2022, "176,119,404" },
    { 2023, "171,000,000" },
    { 2024, "165,000,000" }
};

    private Dictionary<int, string> ratioDict = new Dictionary<int, string>()
    {
        { 2018, "-" },
        { 2019, "8.85%" },
        { 2020, "9.20%" },
        { 2021, "5.74%" },
        { 2022, "2.41%" },
        { 2023, "2.91%" },
        { 2024, "3.51%" }
    };

    private List<int> years = new List<int>()
{
    2018, 2019, 2020, 2021, 2022, 2023, 2024
};

    private Coroutine dataCoroutine;

    void Start()
    {
        dataCoroutine = StartCoroutine(ShowDataSequentially());
    }

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
            float duration = 3f;

            while (elapsedTime < duration)
            {
                float t = elapsedTime / duration;
                int interpolatedNumber = Mathf.RoundToInt(Mathf.Lerp(currentNumber, nextNumber, t));
                string interpolatedData = interpolatedNumber.ToString("N0");
                data.text = interpolatedData + "원";

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            currentIndex = nextIndex;
            year.text = nextYear.ToString();
            data.text = nextData + "원";

            // Add this line to update ratio text
            ratio.text = ratioDict[nextYear];

            yield return new WaitForSeconds(5f);
        }
    }

    private void OnDisable()
    {
        StopCoroutine(dataCoroutine);
    }
}
*/


using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Paper : MonoBehaviour
{
    public TextMeshProUGUI data;
    public TextMeshProUGUI year;
    public TextMeshProUGUI ratio;

    private Dictionary<int, string> dataDict = new Dictionary<int, string>()
{
    { 2018, "231,240,297" },
    { 2019, "210,829,712" },
    { 2020, "191,449,254" },
    { 2021, "180,476,151" },
    { 2022, "176,119,404" },
    { 2023, "171,000,000" },
    { 2024, "165,000,000" }
};

    private Dictionary<int, float> ratioDict = new Dictionary<int, float>()
    {
        { 2018, 0f },
        { 2019, 8.85f },
        { 2020, 9.20f },
        { 2021, 5.74f },
        { 2022, 2.41f },
        { 2023, 2.91f },
        { 2024, 3.51f }
    };

    private List<int> years = new List<int>()
{
    2018, 2019, 2020, 2021, 2022, 2023, 2024
};

    private Coroutine dataCoroutine;

    void Start()
    {
        dataCoroutine = StartCoroutine(ShowDataSequentially());
    }

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
            float duration = 3f;

            float currentRatio = ratioDict[currentYear];
            float nextRatio = ratioDict[nextYear];

            while (elapsedTime < duration)
            {
                float t = elapsedTime / duration;

                int interpolatedNumber = Mathf.RoundToInt(Mathf.Lerp(currentNumber, nextNumber, t));
                string interpolatedData = interpolatedNumber.ToString("N0");
                data.text = interpolatedData + "원";

                if (nextYear == 2018 && interpolatedData != nextData)
                {
                    ratio.text = "-";
                }
                else
                {
                    float interpolatedRatio = Mathf.Lerp(currentRatio, nextRatio, t);
                    ratio.text = interpolatedRatio.ToString("F2") + "%";
                }

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            currentIndex = nextIndex;
            year.text = nextYear.ToString();
            data.text = nextData + "원";

            if (nextYear == 2018)
            {
                ratio.text = "-";
            }
            else
            {
                ratio.text = nextRatio.ToString("F2") + "%";
            }

            yield return new WaitForSeconds(5f);
        }
    }

    private void OnDisable()
    {
        StopCoroutine(dataCoroutine);
    }
}

