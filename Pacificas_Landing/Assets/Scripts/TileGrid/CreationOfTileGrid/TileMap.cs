﻿using UnityEngine;
using System.Collections;
/*	Pulls a size x and a size z that is then used
	to construct a series of vertices and triangles
	

*/
	[RequireComponent(typeof(MeshFilter))]
	[RequireComponent(typeof(MeshRenderer))]
	[RequireComponent(typeof(MeshCollider))]
public class TileMap : MonoBehaviour {

	public int size_z;
	public int size_x;
	float tileSize = 1.0f;
	
	
	// Use this for initialization
	void Start () {
		BuildMesh();
	}

	// Buildmesh is called at the start
	void BuildMesh()
	{
			int numb_tiles = size_x*size_z;
			int numb_tris = numb_tiles*2;
			
			int vsize_x = size_x+ 1;
			int vsize_z = size_z + 1;
			
			int numb_verts = vsize_x * vsize_z;
			
			Vector3[] vertices = new Vector3[numb_verts];
			Vector3[] normal = new Vector3[numb_verts];
			Vector2[] uv = new Vector2[numb_verts];
			
			int[] triangles = new int[numb_tris*3];
			int x, z;
			for(z = 0; z < vsize_z; z++)
			{
				for (x = 0; x <  vsize_x; x++)
				{
					vertices[z * vsize_x + x] = new Vector3(x*tileSize,0,z*tileSize);
					normal[z* vsize_x + x] = new Vector3(x*tileSize,1,z*tileSize);
					float uv_x = (float)x/vsize_x;
					float uv_z = (float)z/vsize_z;
					uv[z* vsize_x + x]  = new Vector2(uv_x,uv_z);
				} 

			}	
				Mesh mesh = new Mesh();
				mesh.vertices = vertices;
				mesh.triangles = triangles;
				mesh.normals = normal;
				mesh.uv = uv;
				
				MeshFilter mesh_Filter = this.GetComponent<MeshFilter>();
				MeshRenderer mesh_Renderer = this.GetComponent<MeshRenderer>();
				MeshCollider mesh_Collider = this.GetComponent<MeshCollider>();
				
				mesh_Filter.mesh = mesh;
	
	}

}
