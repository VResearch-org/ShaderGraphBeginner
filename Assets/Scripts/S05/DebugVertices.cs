using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class DebugVertices : MonoBehaviour {

	Mesh mesh;
	Vector3[] vertices;
	public CoordSpace coordSpace;
	public enum CoordSpace { world, _object, view };

	void OnDrawGizmos()
	{
		if (vertices == null)
		{
			mesh = GetComponent<MeshFilter>().sharedMesh;
			vertices = mesh.vertices;
		}
		foreach (Vector3 v in vertices)
        {
			string vert = "";
			switch (coordSpace)
			{
				case CoordSpace.world:
					vert = "wv: " + (transform.position + v).ToString();
					break;
				case CoordSpace._object:
					vert = "v: " + v.ToString();
					break;
				case CoordSpace.view:
					Vector3 vievWert = SceneView.GetAllSceneCameras()[0].WorldToViewportPoint(transform.position + v);
					vert = " vv:" + vievWert.ToString();
					break;
			}
			UnityEditor.Handles.Label(transform.position + v, vert);
		}
	}
}
