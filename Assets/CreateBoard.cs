using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using System;

public class CreateBoard : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public GameObject housePrefab;
    public GameObject treePrefab;
    public Text score;
    GameObject[] tiles;
    long dirtBB = 0;
    long treeBB = 0;
    long playerBB = 0;

    void Start()
    {
        tiles = new GameObject[64];
        for (int row = 0; row < 8; row++)
        {
            for (int column = 0; column < 8; column++)
            {
                int randomTile = Random.Range(0, tilePrefabs.Length);
                Vector3 position = new Vector3(column, 0, row);
                GameObject tile = Instantiate(tilePrefabs[randomTile], position, Quaternion.identity);

                tile.name = tile.tag + "_" + row + "_" + column;
                tiles[row * 8 + column] = tile;

                if (tile.tag == "Dirt")
                {
                    dirtBB = SetCellState(dirtBB, row, column);
                    //PrintBB("Dirt", dirtBB);
                }
            }
        }

        Debug.Log("Dirt cells =" + CellCount(dirtBB));

        InvokeRepeating("PlantTree", 1, 1);
    }

    void PlantTree()
    {
        int rr = Random.Range(0, 8);
        int rc = Random.Range(0, 8);
        if(GetCellState(dirtBB & ~playerBB, rr, rc))
        {
            GameObject tree = Instantiate(treePrefab);
            tree.transform.parent = tiles[rr * 8 + rc].transform;
            tree.transform.localPosition = Vector3.zero;
            treeBB = SetCellState(treeBB, rr, rc);
        }
    }

    void PrintBB(string name, long BB)
    {
        Debug.Log(name + ": " + Convert.ToString(BB, 2).PadLeft(64, '0'));
    }

    long SetCellState(long bitboard, int row, int column)
    {
        long newBit = 1L << (row * 8 + column);
        return (bitboard |= newBit);
    }

    bool GetCellState(long bitboard, int row, int col)
    {
        long mask = 1L << (row * 8 + col);
        return ((bitboard & mask) != 0);
    }

    int CellCount(long bitboard)
    {
        int count = 0;
        long bb = bitboard;
        while (bb != 0)
        {
            bb &= bb - 1;
            count++;
        }

        return count;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                int r = (int)hit.transform.position.z;
                int c = (int)hit.transform.position.x;

                if (GetCellState(dirtBB & ~treeBB, r, c))
                {
                    GameObject house = Instantiate(housePrefab);
                    house.transform.parent = hit.collider.transform;
                    house.transform.localPosition = Vector3.zero;
                    playerBB = SetCellState(playerBB, r, c);
                }
            }
        }
    }
}
