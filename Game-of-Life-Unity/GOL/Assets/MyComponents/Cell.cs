using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour {


    private bool isAlive;

    public bool isAliveNext;

    // Use this for initializatio
    void Start()
    {


    }


    // Update is called once per fram
    void Update()
    {
        float scaleFactor = isAlive ? 1 : 0.5f;
        // if true then 1 otherwise 0.5f

        transform.localScale = Vector3.one * scaleFactor;

        Color color = isAlive ? Color.green : Color.gray;
        // if isAlive is true then green otherwise gray
        // note: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator 

        Utilities.ChangeCellColor(this, color); 


    }

    public bool IsAlive() // a getter method so to access the private bool isAlive variable
    {
        return isAlive;

    }


    public void UpdateIsAlive()
    {
        isAlive = isAliveNext;

    }

}
	
	

