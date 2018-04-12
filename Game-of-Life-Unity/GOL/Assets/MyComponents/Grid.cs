using UnityEngine;
using System.Collections;


public class Grid : MonoBehaviour{

        private int numCols = 8;
        private int numRows = 5;

        // the leght of each cell side - cubes (side length of 1)
        private float cellSideLength = 1;

        //space between cubes
        private float margin = 0.5f;
        //without f above, 0.5 will be a double

        //multidimensional array
        private Cell[,] cells; 

    // grid logic variables
        private float evolutionPeriod = 0.5f;
        private float evolutionTimer = 0.5f;

    //3 dimension layer
    private int numLays = 5;

    //UI Button Variables

    private bool isPlaying;

    //Slider Variables

    private float evolutionPeriodMax = 1.5f;
    private float evolutionPeriodMin = 0.25f;

    //Score variables

    private int generationCount;



    // Use this for initializatio
    void Start()
        {

        // set the cells array to size of the grid
        cells = new Cell[numCols, numRows];

        for (int col = 0; col < numCols; ++col)
            {
                for (int row = 0; row < numRows; ++row)
                {
                    Cell cell = Utilities.GetNewCell();  //the prefab cell object 

                    float x = (col + 0.5f - numCols * 0.5f) * (cellSideLength + margin);
                    float y = (row + 0.5f - numRows * 0.5f) * (cellSideLength + margin);
                    cell.transform.localPosition = new Vector2(x, y);
                    
                    //to populate the cells array with the prefab cell object
                    cells[col, row] = cell;
                    
            }
            }
        }



    // Update is called once per fram
    void Update()
    {

        evolutionTimer = evolutionTimer - Time.deltaTime;
        // subtract from time passed between frame per frame
        // or
        // evolutionTimer -= evolutionPeriod

        /*
         * makes evolutionTimer = 0.5f again whenever it becomes negative
         */

        if (evolutionTimer < 0)
        {
            evolutionTimer = evolutionPeriod;
            Debug.Log("TICKSSS !");
            Evolve();
        }

        //to test if it works without logic
        
            cells[2,3].isAliveNext = true;
            cells[2,4].isAliveNext = true;
            cells[5,3].isAliveNext = true;
            cells[5,4].isAliveNext = true;
            cells[1,1].isAliveNext = true;
            cells[6,1].isAliveNext = true;
            cells[2,0].isAliveNext = true;
            cells[3,0].isAliveNext = true;
            cells[4,0].isAliveNext = true;
            cells[5,0].isAliveNext = true;
        



    }


    private void Evolve()
    {
        // for each cell object in the cells array
        foreach (Cell cell in cells)
        {
            cell.UpdateIsAlive();
        }

        if (isPlaying)
        {
            

            for (int col = 0; col < cells.GetLength(0); ++col)
            {
                for (int row = 0; row < cells.GetLength(1); ++row)
                {

                    int numAliveNeighbors = GetNumAliveNeighbors(col, row);

                    Cell cell = cells[col, row];

                    if (cell.IsAlive())
                    {

                        if (numAliveNeighbors < 2 || numAliveNeighbors > 3)
                        {
                            cell.isAliveNext = false;
                        }
                        else
                        {
                            cell.isAliveNext = true;
                        }

                    }
                    else if (!cell.IsAlive() && numAliveNeighbors == 3)
                    {
                        cell.isAliveNext = true;
                    }

                }



               
            }


        


        }

        ++generationCount; // update generation for each time cell is generated

    }

    private int GetNumAliveNeighbors(int colCenter, int rowCenter)
    {

        int numAliveNeighbors = 0;

        for (int dCol = -1; dCol <= 1; ++dCol)
        {
            for (int dRow = -1; dRow <= 1; ++dRow)
            {

                if (dCol == 0 && dRow == 0) { continue; }

                int col = colCenter + dCol;
                int row = rowCenter + dRow;

                if (col < 0 || col >= cells.GetLength(0) ||
                row < 0 || row >= cells.GetLength(1)) { continue; }

                if (cells[col, row].IsAlive())
                {
                    ++numAliveNeighbors;
                }
            }
        }

        return numAliveNeighbors;
    }



    public void PlayOrPause()
    {
        ResetEvolutionTimer();

        isPlaying = !isPlaying;

        Debug.Log("PLAY Button Pressed!");
    }



    public void Clear()
    {
        ResetEvolutionTimer();

        foreach (Cell cell in cells)
        {
            cell.isAliveNext = false;
        }

        Debug.Log("CLEAR Button Pressed! !");

        generationCount = 0; // reset the genration count
    }




    public void Randomize()
    {
        ResetEvolutionTimer();

        foreach (Cell cell in cells)
        {
            cell.isAliveNext = Random.value < 0.5f;
        }

        Debug.Log("Randomize Button Pressed !");

        generationCount = 0; //reset the genration count
    }



    public int GetPopulationCount()
    {
        int populationCount = 0;
        foreach (Cell cell in cells)
        {
            if (cell.IsAlive())
            {
                ++populationCount;
            }
        }

        return populationCount;
    }



    public int GetGenerationCount()
    {
        return generationCount;
    }
	        
	

    public void SetEvolutionPeriod(float sliderValue)
    {
        evolutionPeriod = Mathf.Lerp(evolutionPeriodMin, evolutionPeriodMax, 1.0f - sliderValue);
    }

    private void ResetEvolutionTimer()
    {
        evolutionTimer = 0;
    }

}
