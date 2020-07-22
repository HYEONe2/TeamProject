using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animation animation;
    float fSpeed = 5f;
    float fRotSpeed = 100f;


    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        float fPos = Input.GetAxis("Vertical");
        float fRotPos = Input.GetAxis("Horizontal");

        fPos = fPos * fSpeed * Time.deltaTime;
        fRotPos = fRotPos * fRotSpeed * Time.deltaTime;

        if (fPos == 0)
        {
            foreach (AnimationState state in animation)
                state.speed = 0.6f;
        }
        else
        {
            foreach (AnimationState state in animation)
                state.speed = 1.5f;
        }

        transform.Translate(Vector3.forward* -fPos);
        transform.Rotate(Vector3.up * fRotPos);

        if (Input.GetKey(KeyCode.Space))
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 5f, 0));

        if (Terrain.activeTerrain.SampleHeight(transform.position) + 1f < transform.position.y)
        {
            GetComponent<Rigidbody>().useGravity = true;

            Vector3 vPos = transform.position;
            vPos.y += Time.deltaTime;
            transform.position = vPos;
        }
        else
        {
            GetComponent<Rigidbody>().useGravity = false;

            Vector3 vPos = transform.position;
            vPos.y = Terrain.activeTerrain.SampleHeight(transform.position) + 1f;
            transform.position = vPos;
        }
    }
}
