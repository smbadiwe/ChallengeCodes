using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preps
{
    public partial class CTCI
    {
        public class GraphPoint
        {
            const double eps = 0.0000001;
            public double X { get; set; }
            public double Y { get; set; }
            public override bool Equals(object obj)
            {
                var other = obj as GraphPoint;

                return other != null && (Math.Abs(X - other.X) < eps);
            }
        }

        public class Line
        {
            public const double eps = 0.0000001;
            public static double FloorToNearsetEps(double d)
            {
                int r = (int)(d / eps);
                return r * eps;
            }

            public bool IsInfiniteSlope { get; private set; }
            public double Slope { get; set; }
            public double YIntercept { get; set; }
            public Line(GraphPoint p1, GraphPoint p2)
            {
                if (p1.Equals(p2))
                {
                    IsInfiniteSlope = true;
                }
                else
                {
                    Slope = (p2.Y - p1.Y) / (p2.X - p1.X);
                    YIntercept = p1.Y - Slope * p1.X;
                }
            }

            public override bool Equals(object obj)
            {
                var other = obj as Line;

                return other != null
                        && (Math.Abs(this.Slope - other.Slope) < eps)
                        && (Math.Abs(this.YIntercept - other.YIntercept) < eps)
                        && this.IsInfiniteSlope == other.IsInfiniteSlope;
            }

            public Line FindBestLine(GraphPoint[] points)
            {
                Line bestLine = null;
                int bestCount = 0;
                var linesBySlope = new Dictionary<double, List<Line>>();
                for (int i = 0; i < points.Length; i++)
                {
                    for (int j = 1 + i; j < points.Length; j++)
                    {
                        var oneLine = new Line(points[i], points[j]);
                        addToSet(linesBySlope, oneLine);
                        int count = countEquivalentLines(linesBySlope, oneLine);
                        if (count > bestCount)
                        {
                            bestCount = count;
                            bestLine = oneLine;
                        }
                    }
                }
                return bestLine;
            }

            private int countEquivalentLines(Dictionary<double, List<Line>> linesBySlope, Line oneLine)
            {
                var key = Line.FloorToNearsetEps(oneLine.Slope);
                int count = 0;

                if (linesBySlope.ContainsKey(key))
                {
                    count += countEquivalentLines(linesBySlope[key], oneLine);
                }
                if (linesBySlope.ContainsKey(key + eps))
                {
                    count += countEquivalentLines(linesBySlope[key + eps], oneLine);
                }
                if (linesBySlope.ContainsKey(key - eps))
                {
                    count += countEquivalentLines(linesBySlope[key - eps], oneLine);
                }

                return count;
            }

            private int countEquivalentLines(List<Line> lines, Line oneLine)
            {
                int count = 0;
                if (lines != null)
                {
                    foreach (var line in lines)
                    {
                        if (line.Equals(oneLine)) count++;
                    }
                }
                return count;
            }

            private void addToSet(Dictionary<double, List<Line>> linesBySlope, Line oneLine)
            {
                var key = Line.FloorToNearsetEps(oneLine.Slope);
                List<Line> parallelLines;
                if (linesBySlope.TryGetValue(key, out parallelLines))
                {
                    parallelLines.Add(oneLine);
                }
                else
                {
                    parallelLines = new List<Line> { oneLine };
                    linesBySlope.Add(key, parallelLines);
                }
            }

        }
    }
}
