using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Star_Search_Master {
    class Edge {

        public  double cost;
	    public  Node target;

        public Edge(Node targetNode, double costVal){
		target = targetNode;
		cost = costVal;
    }
  }
}

