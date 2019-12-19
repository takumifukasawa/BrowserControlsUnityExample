using UnityEngine;
using WebSocketSharp;

public class ClientSample : MonoBehaviour
{
    [SerializeField]
    private Vector2 movableRange = new Vector2(5, 5);
    
    private WebSocket ws;
    private Vector3 position;
    
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        ws = new WebSocket("ws://localhost:8080");
        ws.OnOpen += (sender, e) =>
        {
            Debug.Log("open");
        };
        ws.OnMessage += (sender, e) =>
        {
            var data = e.Data;
            string[] coords = data.Split(',');
            position = new Vector3(
                float.Parse(coords[0]),
                float.Parse(coords[1]) * -1,
                0
            );
            position.x *= movableRange.x;
            position.y *= movableRange.y;
        };
        ws.OnError += (sender, e) =>
        {
            Debug.Log("error: " + e.Message);
        };
        ws.OnClose += (sender, e) =>
        {
            Debug.Log("close");
        };
        ws.Connect();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = position;
    }

    void OnDestroy()
    {
        ws.Close();
        ws = null;
    }
}
