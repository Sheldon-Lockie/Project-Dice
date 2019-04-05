using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuInstantiation : MonoBehaviour
{
    private double ScreenWidth;
    private double OldScreenWidth;
    private double ScreenHeight;
    private double OldScreenHeight;
    private float Width_Scale = .5f;    //Scales width of gameobjects to screen width
    private float Height_Scale = 1.0f;  //Scales height of gameobjects to screen height
    private float Depth = 10.0f;                   // Depth of the "Play Area"
    private Vector3 CenterScreenPosition; // loacation of center of camera
    private Vector3 FloorPosition;
    private Vector3 CeilingPosition;
    private Vector3 Left_WallPosition;
    private Vector3 Right_WallPosition;
    private Vector3 BackgroundPostion;
    private GameObject Floor;
    private GameObject Ceiling;
    private GameObject Left_Wall;
    private GameObject Right_Wall;
    private GameObject Background;
    
    // Start is called before the first frame update
    void Start()
    {
        /*
         * SCREEN SETUP AND BOUNDS
         *
        */
        CenterScreenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane + 5));
        FloorPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height/9, Camera.main.nearClipPlane + 7));
        CeilingPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height * .9f, Camera.main.nearClipPlane +7));
        Left_WallPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width *.1f, Screen.height / 2 , Camera.main.nearClipPlane + 7));
        Right_WallPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * .9f, Screen.height / 2, Camera.main.nearClipPlane + 7));



        ScreenWidth = Camera.main.orthographicSize * 2.0 * Screen.width / Screen.height;
        OldScreenWidth = ScreenWidth;
    

        ScreenHeight = Camera.main.orthographicSize * 2.0 * Screen.height / Screen.width;
        OldScreenHeight = ScreenHeight;


        Debug.Log("Screen Width is :" + ScreenHeight);
        Debug.Log("Screen Width is :" +ScreenWidth);

        /*
         * INSTANTIATING PLAYFIELD 
         * 
        */
        Floor = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Floor.name = "Floor";
        Floor.AddComponent<Rigidbody>();
        Floor.GetComponent<Rigidbody>().useGravity = false;
        Floor.GetComponent<Rigidbody>().isKinematic = true;
        Floor.transform.position = FloorPosition;
        Floor.transform.localScale = new Vector3((float)ScreenWidth * Width_Scale, 1, Depth);


        Ceiling = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Ceiling.name = "Ceiling";
        Ceiling.AddComponent<Rigidbody>();
        Ceiling.GetComponent<Rigidbody>().useGravity = false;
        Ceiling.GetComponent<Rigidbody>().isKinematic = true;
        Ceiling.transform.position = CeilingPosition;
        Ceiling.transform.localScale = new Vector3((float)ScreenWidth * Width_Scale, 1, Depth);

        Left_Wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Left_Wall.name = "Left Wall";
        Left_Wall.AddComponent<Rigidbody>();
        Left_Wall.GetComponent<Rigidbody>().useGravity = false;
        Left_Wall.GetComponent<Rigidbody>().isKinematic = true;
        Left_Wall.transform.position = Left_WallPosition;
        Left_Wall.transform.Rotate(0, 0, 90, Space.World);
        Left_Wall.transform.localScale = new Vector3((float)ScreenWidth * Width_Scale, 1, Depth);



    }

    // Update is called once per frame
    void Update()
    {
        ScreenHeight = Camera.main.orthographicSize * 2.0 * Screen.height / Screen.width;
        ScreenWidth = Camera.main.orthographicSize * 2.0 * Screen.width / Screen.height;
        if (OldScreenHeight != ScreenHeight)
        {
            Debug.Log("Screen Height is :" + ScreenHeight);
            OldScreenHeight= ScreenHeight;
        }
        if (OldScreenWidth != ScreenWidth)
        {
            Debug.Log("Screen Width is :" + ScreenWidth);
            OldScreenWidth = ScreenWidth;

            Floor.transform.position = FloorPosition;
            Floor.transform.localScale = new Vector3((float)ScreenWidth * Width_Scale, 1, Depth);
            
            Ceiling.transform.position = CeilingPosition;
            Ceiling.transform.localScale = new Vector3((float)ScreenWidth * Width_Scale, 1, Depth);

            Left_WallPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width *.1f, Screen.height / 2 , Camera.main.nearClipPlane + 7));
            Left_Wall.transform.position = Left_WallPosition;
            Left_Wall.transform.localScale = new Vector3((float)ScreenWidth * Width_Scale, 1, Depth);

        }
        
    }
}
