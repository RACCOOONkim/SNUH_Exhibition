/*
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Purchase : MonoBehaviour
{
    public TextMeshProUGUI data;
    public TextMeshProUGUI year;

    private Dictionary<int, string> dataDict = new Dictionary<int, string>()
{
    { 2018, "-" },
    { 2019, "-" },
    { 2020, "-" },
    { 2021, "1,567,998,300" },
    { 2022, "2,843,715,717" },
    { 2023, "1,734,000,000" },
    { 2024, "1,821,000,000" }
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
            year.text = currentYear.ToString(); // 년도를 먼저 설정

            int nextIndex = currentIndex == years.Count - 1 ? 0 : currentIndex + 1;
            int nextYear = years[nextIndex];

            string currentData = dataDict[currentYear];
            string nextData = dataDict[nextYear];
            float elapsedTime = 0f;

            long currentNumber = currentData == "-" ? 0 : long.Parse(currentData.Replace(",", ""));
            long nextNumber = nextData == "-" ? 0 : long.Parse(nextData.Replace(",", ""));

            float duration = 5f; // Adjust the duration here

            while (elapsedTime < duration)
            {
                float t = elapsedTime / duration;
                long interpolatedNumber = (long)Mathf.Lerp(currentNumber, nextNumber, t);
                string interpolatedData = interpolatedNumber.ToString("N0");

                // "-" 문자열일 경우 "원"을 붙이지 않음
                data.text = currentData == "-" ? "-" : interpolatedData + "원";
                year.text = currentYear.ToString(); // 년도를 업데이트

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // "-" 문자열일 경우 "원"을 붙이지 않음
            data.text = nextData == "-" ? "-" : nextData + "원";

            currentIndex = nextIndex;

            if (currentIndex == 0)
            {
                yield return new WaitForSeconds(5f); // Adjust the delay time here before restart
            }
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

public class Purchase : MonoBehaviour
{
    public TextMeshProUGUI data;
    public TextMeshProUGUI year;

    private Dictionary<int, string> dataDict = new Dictionary<int, string>()
{
    { 2018, "-" },
    { 2019, "-" },
    { 2020, "-" },
    { 2021, "1,567,998,300" },
    { 2022, "2,843,715,717" },
    { 2023, "1,734,000,000" },
    { 2024, "1,821,000,000" }
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

            double currentNumber = currentData != "-" ? double.Parse(currentData.Replace(",", "")) : 0;
            double nextNumber = nextData != "-" ? double.Parse(nextData.Replace(",", "")) : 0;
            float duration = 3f; // Adjust the duration here

            while (elapsedTime < duration)
            {
                float t = elapsedTime / duration;
                double interpolatedNumber = Mathf.Lerp((float)currentNumber, (float)nextNumber, t);
                string interpolatedData = string.Format("{0:N0}", interpolatedNumber);
                data.text = currentData != "-" ? interpolatedData + "원" : interpolatedData;

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            currentIndex = nextIndex;
            year.text = nextYear.ToString();
            data.text = nextData != "-" ? nextData + "원" : nextData;

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


using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Purchase : MonoBehaviour
{
    public TextMeshProUGUI data;
    public TextMeshProUGUI year;

    private Dictionary<int, string> dataDict = new Dictionary<int, string>()
{
    { 2018, "-" },
    { 2019, "-" },
    { 2020, "-" },
    { 2021, "1,567,998,300" },
    { 2022, "2,843,715,717" },
    { 2023, "1,734,000,000" },
    { 2024, "1,821,000,000" }
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

            double currentNumber = currentData != "-" ? double.Parse(currentData.Replace(",", "")) : 0;
            double nextNumber = nextData != "-" ? double.Parse(nextData.Replace(",", "")) : 0;
            float duration = 3f; // Adjust the duration here

            while (elapsedTime < duration)
            {
                float t = elapsedTime / duration;
                double interpolatedNumber = Mathf.Lerp((float)currentNumber, (float)nextNumber, t);
                string interpolatedData = string.Format("{0:N0}", interpolatedNumber);
                data.text = currentData != "-" ? interpolatedData + "원" : currentData;

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            currentIndex = nextIndex;
            year.text = nextYear.ToString();
            data.text = nextData != "-" ? nextData + "원" : nextData;

            yield return new WaitForSeconds(5f); // Adjust the delay time here
        }
    }

    // Stop the coroutine when the scene is stopped
    private void OnDisable()
    {
        StopCoroutine(dataCoroutine);
    }
}
