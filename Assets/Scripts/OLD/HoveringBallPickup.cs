using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Highlighters;

public class HoveringBallPickup : MonoBehaviour
{
    private GameObject newBall;

    void OnTriggerExit(Collider obj)
    {
        if (newBall != null) newBall.SetActive(true);    
    }

    public void SpawnNextBall(GameObject child)
    {
        this.newBall = Instantiate(child);
        newBall.transform.parent = this.transform;
        newBall.transform.position = this.transform.position;
        newBall.transform.localScale = new Vector3(1f, 1f, 1f);
        newBall.SetActive(false);

        var h = newBall.GetComponent<VRTK_BaseHighlighter>();
        if (h) Destroy(h);
    }
}
