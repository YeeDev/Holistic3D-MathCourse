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
    public Text score;
    long dirtBB;

    private void Start()
    {
        for (int r = 0; r < 8; r++)
        {
            for (int c = 0; c < 8; c++)
            {
                int randomTile = Random.Range(0, tilePrefabs.Length);
                Vector3 position = new Vector3(c, 0, r);

                GameObject tile = Instantiate(tilePrefabs[randomTile], position, Quaternion.identity);

                tile.name = $"{tile.tag}_{r}_{c}";

                if (tile.tag == "Dirt")
                {
                    dirtBB = SetCellState(dirtBB, r, c);
                    //PrintBB("Dirt", dirtBB);
                }
            }
        }

        Debug.Log($"Dirt cells = {CellCount(dirtBB)}");
    }

    void PrintBB(string name, long bB)
    {
        Debug.Log($"{name}: {Convert.ToString(bB, 2).PadLeft(64, '0')}");
    }

    long SetCellState(long bitboard, int row, int col)
    {
        long newBit = 1L << (row * 8 + col);
        return (bitboard |= newBit);
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
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log(CellCount(15L));
        }
    }
}
