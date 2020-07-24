using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    new Animation animation;

    bool bRenderOn = true;
    float fSpeed = 5f;
    float fRotSpeed = 100f;

    GameObject pathParent;
    int iPath = 0;

    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animation>();
        pathParent = GameObject.Find("AIPath");
    }

    // Update is called once per frame
    void Update()
    {
        if (!Follow_Path())
        {
            ////For VR
            Move_CameraForward();
            ////For PC
            //Key_Input();

            Check_Gravity();
        }
    }

    void Move_CameraForward()
    {
        if (bRenderOn)
        {
            bRenderOn = false;
            transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().enabled = bRenderOn;
        }

        transform.position += Camera.main.transform.forward * Time.deltaTime;
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
            transform.SetPositionAndRotation(vPos, Quaternion.identity);
        }
        else
        {
            GetComponent<Rigidbody>().useGravity = false;

            Vector3 vPos = transform.position;
            vPos.y = Terrain.activeTerrain.SampleHeight(transform.position) + 1f;
            transform.SetPositionAndRotation(vPos, Quaternion.identity);
        }
    }

    bool Follow_Path()
    {
        foreach (AnimationState state in animation)
            state.speed = 1.5f;

        //Debug.Log(iPath + " / " + pathParent.transform.childCount);
        if (iPath >= pathParent.transform.childCount - 1)
        {
            //Debug.Log("RETURN FALSE");
            return false;
        }

        Vector3 vPathPos = pathParent.transform.GetChild(iPath).position;
        Vector3 vPos = transform.position;

        float fDist = (vPathPos - vPos).magnitude;
        if (fDist < 1f)
            if (Make_Turn())
                return true;

        Vector3 vPathTemp = vPathPos - vPos;
        vPathTemp.Normalize();
        transform.forward = -vPathTemp;

        vPos += vPathTemp * Time.deltaTime * 10f;
        vPos.y = Terrain.activeTerrain.SampleHeight(transform.position) + 1f;
        transform.position = vPos;

        return true;
    }

    bool Make_Turn()
    {
        if (iPath + 1 >= pathParent.transform.childCount)
            return true;

        Vector3 vPathPos = pathParent.transform.GetChild(iPath + 1).position;
        Vector3 vPos = transform.position;
        Vector3 vPathTemp = vPathPos - vPos;
        vPathTemp.Normalize();

        if (Vector3.Dot(transform.forward, -vPathTemp) > 0.997f)
        {
            ++iPath;
            return true;
        }

        transform.Rotate(Vector3.up * Time.deltaTime * -100f);
        return true;
    }
}
