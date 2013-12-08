﻿using System;
using System.Collections.Generic;
using System.Linq;
using GeoAPI.Geometries;

namespace terrain
{
    internal class MapFeatures
    {
        private readonly PolygonMap map;
        private readonly Random rand;

        public MapFeatures(PolygonMap map, int seed)
        {
            this.map = map;
            rand = new Random(seed);
        }

        private static MapEdge SelectDownhill(MapNode node)
        {
            var dist = node.DistanceToCoast;
            var ret = node.Edges.First();
            foreach (var e in node.Edges)
                if (e.To.DistanceToCoast < dist)
                    ret = e;
            return ret;
        }

        public IEnumerable<MapNode[]> GenerateRivers()
        {
            var c = 0;
            var eligibleRivers = map.Polygons
                .SelectMany(_ => _.Nodes)
                .Where(_ => _.DistanceToCoast > 0.25 && _.DistanceToCoast < 0.8)
                .ToArray();
            var ret = new List<MapNode[]>();
            do
            {
                var node = eligibleRivers[rand.Next(0, eligibleRivers.Length)];
                var edges = new Stack<MapEdge>();
                var visited = new HashSet<MapNode>();
                edges.Push(SelectDownhill(node));

                var nodes = new List<MapNode>();
                nodes.Add(node);
                while (edges.Count > 0)
                {
                    var ed = edges.Pop();
                    nodes.Add(ed.To);

                    var edge = SelectDownhill(ed.To);
                    if (!edge.To.IsOcean && !visited.Contains(edge.To))
                    {
                        visited.Add(edge.To);
                        edges.Push(edge);
                    }
                }
                ret.Add(nodes.ToArray());
                c++;
            } while (c < 10);
            return ret;
        }

        public IEnumerable<Coordinate[]> GenerateRoads()
        {
            var heights = map.Polygons
                .Select(_ => _.DistanceToCoast.Value)
                .Distinct()
                .OrderBy(_ => _).ToArray();
            double[] roadHeights =
            {
                heights[heights.Length*1/10],
                heights[heights.Length*3/10],
                heights[heights.Length*5/10],
                1
            };
            var centerContour = new Dictionary<MapPolygon, int>();
            var queue = new Queue<MapPolygon>();
            foreach (var i in map.Polygons)
                if (i.IsOcean)
                    queue.Enqueue(i);
            do
            {
                var n = queue.Dequeue();
                foreach (var i in n.Neighbour)
                {
                    int newLevel;
                    if (!centerContour.TryGetValue(n, out newLevel))
                        newLevel = 0;

                    while (i.DistanceToCoast > roadHeights[newLevel])
                        newLevel++;

                    int iLevel;
                    if (!centerContour.TryGetValue(i, out iLevel))
                        iLevel = int.MaxValue;

                    if (newLevel < iLevel)
                    {
                        centerContour[i] = newLevel;
                        queue.Enqueue(i);
                    }
                }
            } while (queue.Count > 0);

            var cornerContour = new Dictionary<MapNode, int>();
            foreach (var i in map.Polygons)
                foreach (var j in i.Nodes)
                {
                    int curr;
                    if (!cornerContour.TryGetValue(j, out curr)) curr = int.MaxValue;
                    int poly;
                    if (!centerContour.TryGetValue(i, out poly)) poly = int.MaxValue;
                    cornerContour[j] = Math.Min(curr, poly);
                }

            var points = new List<Coordinate>[roadHeights.Length - 1];
            for (var i = 0; i < points.Length; i++) points[i] = new List<Coordinate>();
            foreach (var i in map.Polygons.SelectMany(_ => _.Nodes).SelectMany(_ => _.Edges).Distinct())
            {
                if (cornerContour[i.From] < cornerContour[i.To])
                {
                    points[cornerContour[i.From]].Add(new Coordinate(
                        (i.From.X + i.To.X)/2,
                        (i.From.Y + i.To.Y)/2));
                }
            }
            foreach (var i in points)
            {
                var pts = new List<Coordinate>();
                var paths = new List<Coordinate[]>();
                for (var j = 0; j < i.Count; j++)
                {
                    var minDist = double.MaxValue;
                    for (var k = j + 1; k < i.Count; k++)
                    {
                        var dx = i[j].X - i[k].X;
                        var dy = i[j].Y - i[k].Y;
                        var d = dx*dx + dy*dy;
                        if (d < minDist)
                        {
                            minDist = d;
                            var tmp = i[j + 1];
                            i[j + 1] = i[k];
                            i[k] = tmp;
                        }
                    }
                    if (minDist > 0.1 && minDist != double.MaxValue)
                    {
                        if (pts.Count > 0)
                            pts.Add(pts[0]);
                        paths.Add(pts.ToArray());
                        pts.Clear();
                    }
                    else pts.Add(i[j]);
                }
                if (pts.Count > 0)
                    pts.Add(pts[0]);
                paths.Add(pts.ToArray());
                pts.Clear();

                foreach (var j in paths)
                {
                    if (j.Length < 4) continue;
                    yield return j;
                }
            }
        }
    }
}