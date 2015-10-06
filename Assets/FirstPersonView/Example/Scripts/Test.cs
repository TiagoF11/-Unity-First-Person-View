using UnityEngine;
using System.Collections;
using FirstPersonView;

public class Test : MonoBehaviour
{

	// Use this for initialization
	void Start () {
        GetComponent<IFPV_Object>().SetAsFirstPersonObject();
	}
}
