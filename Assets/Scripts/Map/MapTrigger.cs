using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTrigger : MonoBehaviour
{
    public enum mapDirection // your custom enumeration
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
    };

    public mapDirection direction;
    private Camera mainCamera;

    private Vector3 fromPosition;
    private Vector3 toPosition;

    private Vector3 fromPositionChar;
    private Vector3 toPositionChar;
    private bool move = false;

    private float time;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            time += Time.deltaTime;
            float t = time / 1.0f;
            mainCamera.transform.position = Vector3.Lerp(fromPosition, toPosition, t);
            GameManager.instance.Character.transform.position = Vector3.Lerp(fromPositionChar, toPositionChar, t);
            if (t >= 1f)
            {
                move = false;
                GameManager.instance.Character.GetComponent<Collider2D>().enabled = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!move && other.GetComponent<CharacterAction>()!=null) 
        {
            Debug.Log("Trigger");
            float halfHeight = mainCamera.orthographicSize;
            float halfWidth = mainCamera.aspect * halfHeight;

            Vector3 campos = mainCamera.transform.position;
            fromPosition = campos;
            fromPositionChar = GameManager.instance.Character.transform.position;

            string debug = "Trigger " + other.name + "To go ";
            switch (direction)
            {
                case mapDirection.LEFT:
                    toPosition = campos + new Vector3(-2 * halfWidth, 0f, 0f);
                    toPositionChar = fromPositionChar + new Vector3(-halfWidth, 0f, 0f);
                    debug += "Left";
                    break;
                case mapDirection.RIGHT:
                    toPosition = campos + new Vector3(2 * halfWidth, 0f, 0f);
                    toPositionChar = fromPositionChar + new Vector3(halfWidth, 0f, 0f);
                    debug += "Right";
                    break;
                case mapDirection.UP:
                    toPosition = campos + new Vector3(0f, 2 * halfHeight, 0f);
                    toPositionChar = fromPositionChar + new Vector3(0f, halfHeight*1.2f, 0f);
                    debug += "Up";
                    break;
                case mapDirection.DOWN:
                    toPosition = campos + new Vector3(0f, -2 * halfHeight, 0f);
                    toPositionChar = fromPositionChar + new Vector3(0f, -halfHeight*1.2f, 0f);
                    debug += "Down";
                    break;
                default:
                    break;
            }
            Debug.Log(debug);

            move = true;
            GameManager.instance.Character.GetComponent<Collider2D>().enabled = false;
            time = 0f;
        }
    }
}
