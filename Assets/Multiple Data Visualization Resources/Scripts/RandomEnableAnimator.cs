
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomEnableAnimator : MonoBehaviour
{
    Animator am;

    // Start is called before the first frame update
    void Start()
    {
        am = GetComponent<Animator>();
        if (am)
        {
            am.enabled = false;
            float f = Random.Range(1, 3.5f);
            StartCoroutine("Show", f);
        }
    }

    // Update is called once per frame
    IEnumerator Show(float f )
    {
        yield return new WaitForSeconds(f);
        am.enabled = true;

    }
}


/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnableAnimator : MonoBehaviour
{
    Animator am;
    float activeTime = 1.0f; // 애니메이터가 활성화될 시간을 정의합니다. 여기서는 1초로 설정했습니다.

    void Start()
    {
        am = GetComponent<Animator>();
        if (am)
        {
            am.enabled = false;
            float f = Random.Range(1, 3.5f);
            StartCoroutine("Show", f);
        }
    }

    IEnumerator Show(float f)
    {
        yield return new WaitForSeconds(f);
        am.enabled = true;
        // 애니메이터를 활성화한 후 activeTime 동안 대기합니다.
        yield return new WaitForSeconds(activeTime);
        // 대기 시간이 끝나면 애니메이터를 다시 비활성화합니다.
        am.enabled = false;
        // 이후에도 계속 애니메이터를 활성화하고 비활성화하려면, Show 코루틴을 다시 시작합니다.
        StartCoroutine("Show", f);
    }
}
*/