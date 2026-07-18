using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private GridBasedMovement player;

    public bool screenShake = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && screenShake)
        {
            if (player.isMoving)
            {
                StartCoroutine(Shake(0.1f, 0.05f));
            }
        }
    }
    
    IEnumerator Shake(float pDuration, float pMagnitude)
    {
        Vector3 originalPos = transform.localPosition;
        float elapsed = 0.0f;

        while (elapsed < pDuration)
        {
            float x = Random.Range(-1f, 1f)*pMagnitude;
            float y = Random.Range(-1f, 1f)*pMagnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originalPos;
    }
}

