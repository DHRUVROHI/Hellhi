
using UnityEngine;

public class Face_Player : MonoBehaviour
{

    public Transform player;
    public float rotatespeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null) return;

        Vector3 direction  = player.position - transform.position;
        if (direction == Vector3.zero) return;

        Quaternion targetRotation = Quaternion.LookRotation(direction);
      //  Debug.Log(targetRotation);
        transform.rotation = Quaternion.Slerp(transform.rotation , targetRotation, rotatespeed * Time.deltaTime);
    }
}
