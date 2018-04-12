using UnityEngine;
using System.Collections;

public class GameBoardGenerator : MonoBehaviour {

	public GameObject block;
	public GameObject wall;

    // will show up on the interface - public vairables on the board
	public int boardWidth = 10;
	public int boardHeight = 10;

	// Use this for initialization
	void Start () {
		GameObject ceiling = Instantiate(wall) as GameObject;
        // or 
        // GameObject ceiling = (GameObject)Instantiate(wall);

        GameObject floor = Instantiate(wall) as GameObject;
		GameObject leftWall = Instantiate(wall) as GameObject;
		GameObject rightWall = Instantiate(wall) as GameObject;

        //Instantiate lets you create any kind of object in Unity
        //GameObject to type cast the created object to GameObject - cast means change the type - "as" GameObject
        //C# is statically typed, and everything must be strongly cast to a specific type



        //Make the 4 walls children of the game board object
        rightWall.transform.parent = this.transform;
		leftWall.transform.parent = this.transform;

        //tags for walls - for objects that are instantiated 
        leftWall.gameObject.tag = "Wall";
        rightWall.gameObject.tag = "Wall";

        ceiling.transform.parent = this.transform;
		floor.transform.parent = this.transform;

        //A child moves around based on how the parent moves.


        //set floor position
        floor.transform.localPosition = new Vector3(boardWidth / 2f, -4f, 0f);
		floor.transform.localScale = new Vector3(boardWidth + 3f, 1f, 1f);
		floor.AddComponent<DeathZone>();

		//set ceiling position
		ceiling.transform.localPosition = new Vector3(boardWidth / 2f, (boardHeight + 2f), 0f);
		ceiling.transform.localScale = new Vector3(boardWidth + 3f, 1f, 1f);

		//set right wall position
		rightWall.transform.localPosition = new Vector3(-2f, (boardHeight / 2f) - 1f, 0f);
		rightWall.transform.localScale = new Vector3(1f, boardHeight + 7f, 1f);

		//set left wall position
		leftWall.transform.localPosition = new Vector3(boardWidth + 2f, (boardHeight / 2f) - 1f, 0f);
		leftWall.transform.localScale = new Vector3(1f, boardHeight + 7f, 1f);

        // The transform of a GameObject is a component it has that determines its position, its scale, and how it's oriented

        for (int i = 1; i <= boardWidth; i++) // column
		{
			for(int j = 1; j <= boardHeight; j++) // row
			{
				//create blocks
				GameObject newBlock = Instantiate(block) as GameObject;
				newBlock.transform.parent = this.transform;
				newBlock.transform.localPosition = new Vector3((float)i, (float)j, 0f);
			}
		}

      //world space - "position"
      //position relative to object parent - "localPosition"

    }



}
