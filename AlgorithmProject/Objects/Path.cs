using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmProject.Objects
{
    class Path : List<Queue<int>>
    {
        private List<Queue<int>> _NodePath;

        public List<Queue<int>> NodePath
        {
            get { return this._NodePath; }
            set { this._NodePath = value; }

        }

        public Path()
        {

        }
    }
}
