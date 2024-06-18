using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class Tests_Pathfinding {

    [Test]
    public void Test_A() {
        Function function = new Function();

        // Mock 假数据
        Vector2Int start = new Vector2Int(-1, -1);
        Vector2Int end = new Vector2Int(1, 1);

        List<Vector2Int> hinders = new List<Vector2Int>();
        hinders.Add(new Vector2Int(0, 0));
        hinders.Add(new Vector2Int(-1, 0));
        hinders.Add(new Vector2Int(1, 0));

        int pathCount = function.Astar(start, end, hinders, 10000, out int res, out RectCell cell);
        Assert.AreEqual(pathCount, 7);
        Assert.AreEqual(res, 1);

        List<Vector2Int> path = new List<Vector2Int>();
        path.Add(new Vector2Int(1, 1));
        path.Add(new Vector2Int(2, 1));
        path.Add(new Vector2Int(2, 0));
        path.Add(new Vector2Int(2, -1));
        path.Add(new Vector2Int(1, -1));
        path.Add(new Vector2Int(0, -1));
        path.Add(new Vector2Int(-1, -1));

        int index = 0;
        while(cell != null) {
            Assert.AreEqual(cell.position, path[index]);
            cell = cell.parent;
            index++;
        }

    }

}
