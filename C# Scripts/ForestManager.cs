using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestManager : MonoBehaviour
{
    public LaunchingTree[] treeOptions;
    public static ForestManager instance;
    LaunchingTree selectedTree;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        GenerateStartingForest();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateStartingForest()
    {
        //randomly generate trees with repeated calls to RandomlyPlaceTree
    }

    void RandomlyPlaceTree()
    {
        //randomly pick tree from treeOptions;
        //randomly place that tree
    }

    public void SelectTree(LaunchingTree tree)
    {
        selectedTree = tree;
        LaunchTree();
    }

    void LaunchTree()
    {
        
        selectedTree.Launch();
        selectedTree = null;
    }
}
