using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_shake : MonoBehaviour
{

    public static Camera_shake instance;
    Vector3 originalpos;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
            instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        originalpos = transform.localPosition;
    }

    public void startshake(float duration , float strength)
    {

       StartCoroutine(shake(3f , 20f));
    }
    public IEnumerator shake(float duration  , float strength)
    {
        float timer = 0f;
        while (timer < duration)
        {
            Vector3 randompos = originalpos + Random.insideUnitSphere * strength;
            transform.localPosition = randompos;
            timer += Time.deltaTime;    
            yield return null;
        }
        transform.localPosition = originalpos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
