using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Transform ball;
    public Transform genji1;
    public Transform genji2;
    public Transform genji3;
    public Transform genji4;
    private Transform[] players = new Transform[4];
    private Transform targetGenji;
    public Rigidbody rb;
    private float time = 0;
    public GameObject camera;
    // Start is called before the first frame
    void Start()
    {
        players[0] = genji1;
        players[1] = genji2;
        players[2] = genji3;
        players[3] = genji4;
        int player = Random.Range(0, 4);
        targetGenji = players[player];
    }

    // Update is called once per frame
    void Update()
    {
        float total = Mathf.Sqrt(Mathf.Pow(((targetGenji.position.x - ball.position.x) * Time.deltaTime), 2) + Mathf.Pow(((targetGenji.position.y - ball.position.y) * Time.deltaTime), 2) + Mathf.Pow(((targetGenji.position.z - ball.position.z) * Time.deltaTime), 2));
        Vector3 direction = new Vector3((((targetGenji.position.x - ball.position.x) * Time.deltaTime) / total), (((targetGenji.position.y - ball.position.y) * Time.deltaTime) / total), (((targetGenji.position.z - ball.position.z) * Time.deltaTime) / total));
        rb.velocity = new Vector3(30*direction.x, 30*direction.y, 30*direction.z);
        if ((ball.position.x * ball.position.x > 38 * 38) & time<0)
        {
            rb.velocity = Vector3.zero;
            NextTarget();
            time = 1f;
        }
        if ((ball.position.z * ball.position.z > 38 * 38) & time<0)
        {
            rb.velocity = Vector3.zero;
            NextTarget();
            time = 1f;
        }
        if (time > -0.1)
        {
            time -= (1 * Time.deltaTime);
        }
    }

    public void NextTarget()
    {
        float[] cs = new float[4];
        int min = 0;
        cs[1] = 100000;
        cs[2] = 100000;
        cs[3] = 100000;
        cs[0] = 100000;
        for (int i = 0; i<=3; i++)
        {
            if (players[i] == targetGenji)
            {
                continue;
            }
            Vector3 direction = players[i].position + camera.transform.position;
            Vector3 a = camera.transform.forward;
            float ab = Vector3.Dot(a, direction);
            float c = ab / (a.magnitude * direction.magnitude);
            cs[i] = Mathf.Acos(c);
            //Debug.Log(Mathf.Acos(c));
            
        }
        for(int i = 0; i<cs.Length; i++) 
        {
            if (cs[i] < cs[min])
            {
                Debug.Log(cs.Length);
                min = i;
                
            }
        }
        Debug.Log(min);
        targetGenji = players[min];
    }
}   
