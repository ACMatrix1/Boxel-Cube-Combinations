using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using JetBrains.Annotations;
using System.Security.Principal;
using Microsoft.Cci;

public class CubeGenTest : MonoBehaviour
{
    public int[] TestingArrayBit;
    public int CombinationIndex;



    public Mesh mesh;
    public MeshFilter Filter;
    public List<Vector3> Verts;
    public List<int> Tris;
    public List<Color> Colors;
    public int[] ActiveVerts;

    public bool GenFromTable;
    void Start()
    {
        Verts = new List<Vector3>();
        mesh = new Mesh();
        Tris = new List<int>();
        TestingArrayBit = new int[6];

        GenerateCube(ActiveVerts,ref Verts,ref Tris,ref Colors,Color.blue);

        Filter.mesh.vertices = Verts.ToArray();
        Filter.mesh.triangles = Tris.ToArray();
        Filter.mesh.colors = Colors.ToArray();
    }

    void Update()
    {
        Tris.Clear();
        Verts.Clear();
        Colors.Clear();

        if(!GenFromTable)
        {
            for (int i = 0; i < 6; i++)
            {
                // Extract each bit using bitwise AND operation
                ActiveVerts[i] = (CombinationIndex >> i) & 1;
            }

            GenerateCube(ActiveVerts,ref Verts,ref Tris,ref Colors,Color.grey);

            Filter.mesh.vertices = Verts.ToArray();
            Filter.mesh.triangles = Tris.ToArray();
            Filter.mesh.colors = Colors.ToArray();

        }else
        {
            CombinationIndex = 0;

            GenerateFromTabels(ActiveVerts,ref Verts,ref Tris, ref Colors, Color.white);

            Filter.mesh.vertices = Verts.ToArray();
            Filter.mesh.triangles = Tris.ToArray();
            Filter.mesh.colors = Colors.ToArray();
        }



    }
    void GenerateCube(int[] ActiveVerts, ref List<Vector3> Verts, ref List<int> Tris, ref List<Color> Colors, Color VertexColor)
    {
        float size = 1;

        int[] TrianglesFaces = new int[]
        {
            0,1,2,2,3,0
        };

        Color[] VertColors = 
        {
            VertexColor,
            VertexColor,
            VertexColor,
            VertexColor,
        };

        if(ActiveVerts[0] == 1)
        {
            int[] Faces = new int[6];
            Array.Copy(TrianglesFaces,Faces,TrianglesFaces.Length);
            for (int i = 0; i < Faces.Length; i++)
            {
                Faces[i] += Verts.Count;
            }
            Tris.AddRange(Faces);
            Verts.Add(new Vector3(-size, -size, size));
            Verts.Add(new Vector3(size, -size, size));
            Verts.Add(new Vector3(size, size, size));
            Verts.Add(new Vector3(-size, size, size));
            Colors.AddRange(VertColors);
        }
        if(ActiveVerts[1] == 1)
        {
            int[] Faces = new int[6];
            Array.Copy(TrianglesFaces,Faces,TrianglesFaces.Length);
            for (int i = 0; i < Faces.Length; i++)
            {
                Faces[i] += Verts.Count;
            }
            Tris.AddRange(Faces);
            Verts.Add(new Vector3(size, -size, -size));
            Verts.Add(new Vector3(-size, -size, -size));
            Verts.Add(new Vector3(-size, size, -size));
            Verts.Add(new Vector3(size, size, -size));
            Colors.AddRange(VertColors);
        }
        if(ActiveVerts[2] == 1)
        {
            int[] Faces = new int[6];
            Array.Copy(TrianglesFaces,Faces,TrianglesFaces.Length);
            for (int i = 0; i < Faces.Length; i++)
            {

                Faces[i] += Verts.Count;
            }
            Tris.AddRange(Faces);
            Verts.Add(new Vector3(-size, -size, size));
            Verts.Add(new Vector3(-size, size, size));
            Verts.Add(new Vector3(-size, size, -size));
            Verts.Add(new Vector3(-size, -size, -size));
            Colors.AddRange(VertColors);
        }
        if(ActiveVerts[3] == 1)
        {
            int[] Faces = new int[6];
            Array.Copy(TrianglesFaces,Faces,TrianglesFaces.Length);
            for (int i = 0; i < Faces.Length; i++)
            {

                Faces[i] += Verts.Count;
            }
            Tris.AddRange(Faces);
            Verts.Add(new Vector3(size, size, size));
            Verts.Add(new Vector3(size, -size, size));
            Verts.Add(new Vector3(size, -size, -size));
            Verts.Add(new Vector3(size, size, -size));
            Colors.AddRange(VertColors);
        }
        if(ActiveVerts[4] == 1)
        {
            int[] Faces = new int[6];
            Array.Copy(TrianglesFaces,Faces,TrianglesFaces.Length);
            for (int i = 0; i < Faces.Length; i++)
            {

                Faces[i] += Verts.Count;
            }
            Tris.AddRange(Faces);
            Verts.Add(new Vector3(-size, size, size));
            Verts.Add(new Vector3(size, size, size));
            Verts.Add(new Vector3(size, size, -size));
            Verts.Add(new Vector3(-size, size, -size));
            Colors.AddRange(VertColors);
        }
        if(ActiveVerts[5] == 1)
        {
            int[] Faces = new int[6];
            Array.Copy(TrianglesFaces,Faces,TrianglesFaces.Length);
            for (int i = 0; i < Faces.Length; i++)
            {
                Faces[i] += Verts.Count;
            }
            Tris.AddRange(Faces);
            Verts.Add(new Vector3(size, -size, size));
            Verts.Add(new Vector3(-size, -size, size));
            Verts.Add(new Vector3(-size, -size, -size));
            Verts.Add(new Vector3(size, -size, -size));
            Colors.AddRange(VertColors);
        }

    }

    void GenerateFromTabels(int[] ActiveVerts, ref List<Vector3> Verts, ref List<int> Tris, ref List<Color> VertColors ,Color VertColor)
    {
        for (int i = ActiveVerts.Length - 1; i >= 0; i--)
        {
            // Left shift the current value of number and OR it with the current bit
            CombinationIndex = (CombinationIndex << 1) | ActiveVerts[i];
        }

        for (int i = 0; i < Vertexes[CombinationIndex].Length; i++)
        {
            Verts.Add(CubeVectors[Vertexes[CombinationIndex][i]]);
            VertColors.Add(VertColor);
        }

        Tris.AddRange(Triangles[CombinationIndex]);
    }

    void OnDrawGizmos()
    {
        foreach (Vector3 i in Filter.mesh.vertices)
        {
            Gizmos.DrawSphere(i,.1f);
        }
    }

    Vector3[] CubeVectors = 
    {
        new Vector3(-1, -1, 1),//0
        new Vector3(1, -1, 1),//1

        new Vector3(1, 1, 1),//2
        new Vector3(-1, 1, 1),//3

        // Back face
        new Vector3(1, -1, -1),//4
        new Vector3(-1, -1, -1),//5

        new Vector3(-1, 1, -1),//6
        new Vector3(1, 1, -1),//7
    };

    int[][] Vertexes = 
    {
        new int[] {},//index 0
        new int[] {2,3,1,0},//Index 1
        new int[] {6,7,5,4},//Index 2
        new int[] {2,3,1,0,6,7,5,4},//Index 3
        new int[] {3,6,0,5},//Index 4
        new int[] {2,3,1,0,6,5},//Index 5
        new int[] {3,6,0,5,7,4},//Index 6
        new int[] {3,6,0,5,7,4,2,1},//Index 7
        new int[] {7,2,4,1},//Index 8
        new int[] {7,2,4,1,3,0},//Index 9
        new int[] {6,7,5,4,2,1},//Index 10
        new int[] {6,7,5,4,2,1,3,0},//Index 11
        new int[] {7,2,4,1,3,6,0,5},//Index 12
        new int[] {7,2,4,1,3,0,6,5},//Index 13
        new int[] {3,6,0,5,7,4,2,1},//Index 14
        new int[] {3,6,0,5,7,4,2,1},//Index 15
        new int[] {6,3,7,2},//Index 16
        new int[] {1,2,0,3,7,6},//Index 17
        new int[] {2,7,3,6,4,5},//Index 18
        new int[] {1,2,0,3,7,6,4,5},//Index 19
        new int[] {0,3,5,6,2,7},//Index 20
        new int[] {2,3,1,0,6,5,7},//Index 21
        new int[] {3,6,0,5,7,4,2},//Index 22
        new int[] {2,3,1,0,6,5,7,4},//Index 23
        new int[] {4,7,1,2,6,3},//Index 24
        new int[] {7,2,4,1,3,0,6},//Index 25
        new int[] {6,7,5,4,2,1,3},//Index 26
        new int[] {6,7,5,4,2,1,3,0},//Index 27
        new int[] {4,7,1,2,6,3,5,0},//Index 28
        new int[] {7,2,4,1,3,0,6,5},//Index 29
        new int[] {3,6,0,5,7,4,2,1},//Index 30
        new int[] {7,2,4,1,3,0,6,5},//Index 31
        new int[] {4,1,5,0},//Index 32
        new int[] {4,1,5,0,2,3},//Index 33
        new int[] {0,5,1,4,6,7},//Index 34
        new int[] {3,0,2,1,5,4,6,7},//Index 35
        new int[] {1,0,4,5,3,6},//Index 36
        new int[] {5,0,6,3,1,2,4},//Index 37
        new int[] {4,5,7,6,0,3,1},//Index 38
        new int[] {4,5,7,6,0,3,1,2},//Index 39
        new int[] {5,4,0,1,7,2},//Index 40
        new int[] {0,1,3,2,4,7,5},//Index 41
        new int[] {1,4,2,7,5,6,0},//Index 42
        new int[] {0,1,3,2,4,7,5,6},//Index 43
        new int[] {6,5,3,0,4,1,7,2},//Index 44
        new int[] {5,0,6,3,1,2,4,7},//Index 45
        new int[] {1,4,2,7,5,6,0,3},//Index 46
        new int[] {1,4,2,7,5,6,0,3},//Index 47
        new int[] {0,5,1,4,2,7,3,6},//Index 48
        new int[] {4,1,5,0,2,3,7,6},//Index 49
        new int[] {0,5,1,4,6,7,3,2},//Index 50
        new int[] {5,6,4,7,3,2,0,1},//Index 51
        new int[] {1,0,4,5,3,6,2,7},//Index 52
        new int[] {2,3,1,0,6,5,7,4},//Index 53
        new int[] {3,6,0,5,7,4,2,1},//Index 54
        new int[] {5,6,4,7,3,2,0,1},//Index 55
        new int[] {5,4,0,1,7,2,6,3},//Index 56
        new int[] {7,2,4,1,3,0,6,5},//Index 57
        new int[] {6,7,5,4,2,1,3,0},//Index 58
        new int[] {7,4,6,5,1,0,2,3},//Index 59
        new int[] {6,5,3,0,4,1,7,2},//Index 60
        new int[] {2,1,7,4,0,5,3,6},//Index 61
        new int[] {6,5,3,0,4,1,7,2},//Index 62
        new int[] {2,3,1,0,6,5,7,4}//Index 63 FINAL INDEX
    };

    int[][] Triangles = 
    {
        new int[] {},//Index 0
        new int[] {3,2,0,0,1,3},//Index 1
        new int[] {3,2,0,0,1,3},//Index 2
        new int[] {3,2,0,0,1,3,7,6,4,4,5,7},//Index 3 //Opposite sides
        new int[] {3,2,0,0,1,3},//Index 4
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5},//Index 5
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5},//Index 6 // 2 sides attached at a corner
        new int[] {2,7,6,6,0,2,3,2,0,0,1,3,5,3,1,1,4,5},//Index 7
        new int[] {3,2,0,0,1,3},//Index 8
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5},//Index 9
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5},//Index 10
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5,7,5,4,4,6,7},//Index 11
        new int[] {3,2,0,0,1,3,7,6,4,4,5,7},//Index 12
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5,7,5,4,4,6,7},//Index 13
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5,7,5,4,4,6,7},//Index 14
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5,7,5,4,4,6,7,2,7,6,6,0,2},//Index 15
        new int[] {3,2,0,0,1,3},//Index 16
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5},//Index 17
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5},//Index 18
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5,7,5,4,4,6,7},//Index 19
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5},//Index 20
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5,4,1,0,0,6,4},//Index 21
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5,4,1,0,0,6,4},//Index 22
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5,7,5,4,4,6,7,4,1,0,0,6,4},//Index 23
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5},//Index 24
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5,4,1,0,0,6,4},//Index 25
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5,4,1,0,0,6,4},//Index 26
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5,7,5,4,4,6,7,4,1,0,0,6,4},//Index 27
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5,7,5,4,4,6,7},//Index 28
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5,7,5,4,4,6,7,4,1,0,0,6,4},//Index 29
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5,7,5,4,4,6,7,4,1,0,0,6,4},//Index 30
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5,7,5,4,4,6,7,2,7,6,6,0,2,6,4,1,1,0,6},//31
        new int[] {3,2,0,0,1,3},//Index 32
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5},//Index 33
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5},//Index 34
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5,7,5,4,4,6,7},//Index 35
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5},//Index 36
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5,4,1,0,0,6,4},//Index 37
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5,4,1,0,0,6,4},//Index 38
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5,7,5,4,4,6,7,4,1,0,0,6,4},//Index 39
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5},//Index 40
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5,4,1,0,0,6,4},//Index 41
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5,4,1,0,0,6,4},//Index 42
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5,7,5,4,4,6,7,4,1,0,0,6,4},//Index 43
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5,7,5,4,4,6,7},//Index 44
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5,7,5,4,4,6,7,4,1,0,0,6,4},//Index 45
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5,7,5,4,4,6,7,4,1,0,0,6,4},//Index 46
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5,7,5,4,4,6,7,2,7,6,6,0,2,6,4,1,1,0,6},//47
        new int[] {3,2,0,0,1,3,7,6,4,4,5,7},//Index 48
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5,7,5,4,4,6,7},//Index 49
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5,7,5,4,4,6,7},//Index 50
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5,7,5,4,4,6,7,2,7,6,6,0,2},//Index 51
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5,7,5,4,4,6,7},//Index 52
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5,1,0,6,6,4,1,5,7,2,2,3,5},//Index 53
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5,1,0,6,6,4,1,5,7,2,2,3,5},//Index 54
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5,7,5,4,4,6,7,2,7,6,6,0,2,6,4,1,1,0,6},//55
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5,7,5,4,4,6,7},//Index 56
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5,1,0,6,6,4,1,5,7,2,2,3,5},//Index 57
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5,1,0,6,6,4,1,5,7,2,2,3,5},//Index 58
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5,7,5,4,4,6,7,2,7,6,6,0,2,6,4,1,1,0,6},//59
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5,7,5,4,4,6,7,2,7,6,6,0,2},//Index 60
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5,7,5,4,4,6,7,2,7,6,6,0,2,6,4,1,1,0,6},//61
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5,7,5,4,4,6,7,2,7,6,6,0,2,6,4,1,1,0,6},//62
        new int[] {3,2,0,0,1,3,5,3,1,1,4,5,7,5,4,4,6,7,2,7,6,6,0,2,1,0,6,6,4,1 , 5,7,2,2,3,5}//Index 63 FINAL INDEX
    };
}
