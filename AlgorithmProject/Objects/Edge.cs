using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmProject.Objects
{
    class Edge
    {
        private double _EdgeLength;
        private Node _Node;

        public double EdgeLength
        {
            get { return _EdgeLength; }
            set { _EdgeLength = value; }
        }

        public Node Node
        {
            get { return _Node; }
            set { _Node = value; }
        }

        public Edge(Node Node, double EdgeLength)
        {
            this.Node = Node;
            this.EdgeLength = EdgeLength;
        }
    }
}
