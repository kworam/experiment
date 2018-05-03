using System.Collections.Generic;
using System.Linq;

namespace Experiment
{
	public class GraphTopologicalSort
	{
		public static IEnumerable<GraphTopologicalSortNode> Sort(Graph g)
		{
			// while there are nodes in inDegreeZero
			//  dequeue node 'n', append it to the topSort list
			//  for each node 'v' adjacent to 'n'
			//    delete the edge n->v from the graph 
			//    if 'v' now has inDegree of zero, append it to the inDegreeZero list

			// if there are edges left in clone graph, throw exception (graph not DAG)

			List<GraphVertex> topSort = new List<GraphVertex>();

			Graph clone = g.Clone() as Graph;

			Queue<GraphVertex> inDegreeZeroVertices = new Queue<GraphVertex>(
				clone.GetAllVertices().Where(v => clone.GetInDegreeForVertex(v.UniqueKey) == 0));
			while (inDegreeZeroVertices.Count > 0)
			{
				GraphVertex current = inDegreeZeroVertices.Dequeue();
				topSort.Add(current);

				List<GraphEdge> edgesCopy = current.GetIncidentEdges().Select(e => e).ToList();

				foreach (GraphEdge edge in edgesCopy)
				{
					clone.RemoveEdge(edge.SourceVertexUniqueKey, edge.TargetVertexUniqueKey);

					if (clone.GetInDegreeForVertex(edge.TargetVertexUniqueKey) == 0)
					{
						inDegreeZeroVertices.Enqueue(g.GetVertexByUniqueKey(edge.TargetVertexUniqueKey));
					}
				}
			}

			if (clone.NumEdges > 0)
			{
				throw new CyclicGraphException(string.Format("You cannot topologically sort a cyclic graph."));
			}

			return topSort.Select(v => new GraphTopologicalSortNode()
			{
				Vertex = v,
				Level = 0
			});
		}
	}
}
