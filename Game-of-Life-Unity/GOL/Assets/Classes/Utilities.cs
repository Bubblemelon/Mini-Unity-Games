using UnityEngine;
using System.Collections;

public class Utilities : object {

	public static Cell GetNewCell() {

		GameObject prefab = Resources.Load<GameObject>("Cell");
		GameObject go = (GameObject)GameObject.Instantiate(prefab,Vector3.zero,Quaternion.identity);
		go.name = prefab.name;

		Transform grid = GameObject.FindGameObjectWithTag("Grid").transform;
		go.transform.SetParent(grid);

		Cell cell = go.GetComponent<Cell>(); // not the default script - calling specific script that you drag onto

		return cell;
	}

	public static void ChangeCellColor(Cell cell, Color color) {

		MeshRenderer mr = cell.gameObject.GetComponent<MeshRenderer>();
		if (mr) {
			Material materialCopy = (Material)GameObject.Instantiate (mr.sharedMaterial);
			materialCopy.color = color;
			mr.material = materialCopy;
		}
	}
}
