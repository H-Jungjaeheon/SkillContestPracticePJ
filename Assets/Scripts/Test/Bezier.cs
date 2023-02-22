using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bezier : MonoBehaviour
{
    [Range(0f, 1f)]
    [SerializeField]
    float value;

    [SerializeField]
    GameObject[] targetObjs;

    [SerializeField]
    GameObject lastTargetObj;

    [SerializeField]
    GameObject moveObj;

    // Update is called once per frame
    void Update()
    {
        moveObj.transform.position = BezierTest(targetObjs[0].transform.position, targetObjs[1].transform.position, targetObjs[2].transform.position, lastTargetObj.transform.position, value);//BezierTest(targetPoses[0].transform.position.x, a,b,c, value);
    }

    Vector3 BezierTest(Vector3 first, Vector3 second, Vector3 third, Vector3 fourth, float t)
    {
        var ab = Vector3.Lerp(first, second, t);
        var bc = Vector3.Lerp(second, third, t);
        var cd = Vector3.Lerp(third, fourth, t);

        var abbc = Vector3.Lerp(ab, bc, t);
        var bccd = Vector3.Lerp(bc, cd, t);

        var abcd = Vector3.Lerp(abbc, bccd, t);

        return abcd;
    }
}
