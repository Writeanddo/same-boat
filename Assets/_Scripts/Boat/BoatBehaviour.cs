using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatBehaviour : MonoBehaviour
{
    [SerializeField]
    float _speed = 5f;

    Boat _boat;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    internal void SetUp(Boat boat)
    {
        _boat = boat;
    }

    private void OnMouseDown()
    {
        GameManager.instance.BoatInteraction(_boat);
    }

    internal Transform GetSeat(int pos)
    {
        //Needs work
        return transform;
    }

    internal void GoTo(Island newIsland, bool instant)
    {
        Vector3 destination = newIsland.Behaviour.GetPortPosition();
        if (instant)
        {
            transform.position = destination;
        }
        else
        {
            float duration = Vector2.Distance(transform.position, destination) / _speed;
            StartCoroutine(MovementCoroutine(destination, duration));
        }
    }

    IEnumerator MovementCoroutine(Vector3 destination, float duration)
    {
        Vector2 pos = transform.position;


        float t = 0;
        while (t < 1)
        {
            transform.position = Vector2.Lerp(pos, destination, t);
            t += Time.deltaTime / duration;
            yield return null;
        }


        yield return null;
    }
}
