using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    [SerializeField]
    private float fadeSpeed = 4;   //페이드 아웃 되는 속도
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnEnable()
    {
        StartCoroutine("OnFadeEffect");
    }

    private void OnDisable()
    {
        StopCoroutine("OnFadeEffect");
    }

    private IEnumerator OnFadeEffect()
    {
        while(true)
        {
            Color color = meshRenderer.material.color;
            color.a = Mathf.Lerp(1, 0, Mathf.PingPong(Time.time * fadeSpeed, 1));

            meshRenderer.material.color = color;

            yield return null;
        }

        /*
        float f = Mathf.PingPong(float t, float length);
        t값에 따라 0부터 length 사이의 값을 반환한다.
        t값이 계속 증가할 때 lenght까지는 t값을 반환하고,
        t가 length 값보다 커지면 순차적으로 0까지 -, length까지 +를 반복한다.
        */
    }
}
