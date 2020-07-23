using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    new Animation animation;

    float fSpeed = 5f;
    float fRotSpeed = 100f;

    GameObject pathParent;
    int iPath = 0;

    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animation>();
        pathParent = GameObject.Find("Path");
    }

    // Update is called once per frame
    void Update()
    {
        if (!Follow_Path())
        {
            Key_Input();
            Check_Gravity();
        }
    }

    void Key_Input()
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

        transform.Translate(Vector3.forward * -fPos);
        transform.Rotate(Vector3.up * fRotPos);

        if (Input.GetKey(KeyCode.Space))
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 8f, 0));
    }

    void Check_Gravity()
    {
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

    bool Follow_Path()
    {
        foreach (AnimationState state in animation)
            state.speed = 1.5f;

        if (iPath >= pathParent.transform.childCount)
            return false;

        Vector3 vPathPos = pathParent.transform.GetChild(iPath).position;
        Vector3 vPos = transform.position;

        Vector3 vPathTemp = vPathPos - vPos;
        vPathTemp.Normalize();

        float fDist = (vPathPos - vPos).magnitude;
        if (fDist < 1f)
            if (Make_Turn(-vPathTemp))
                return true;

        transform.forward = -vPathTemp; 
        vPos += vPathTemp * Time.deltaTime * 10f;
        vPos.y = Terrain.activeTerrain.SampleHeight(transform.position) + 1f;
        transform.position = vPos;

        return true;
    }

    bool Make_Turn(Vector3 vDir)
    {
        if ((-transform.forward - vDir).magnitude < 1f)
        {
            ++iPath;
            return true;
        }

        transform.Rotate(Vector3.up * Time.deltaTime * -100f);
        return true;
    }
}
