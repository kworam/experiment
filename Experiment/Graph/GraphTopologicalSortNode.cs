namespace Experiment
{
	public class GraphTopologicalSortNode
	{
		public GraphVertex Vertex { get; set;  }

        public int Level { get; set;  }

		public override string ToString()
		{
			return Vertex.ToString();
		}
	}
}
