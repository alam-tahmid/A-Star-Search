using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Star_Search_Master {
    class Node {

        public string value;
        public double g_scores;
        public double h_scores;
        public double f_scores = 0;
        public Edge[] adjacencies;
        public Node parent;

        public Node(string val, double hVal) {
            value = val;
            h_scores = hVal;
        }

        public override string ToString() {
            return this.value;
        }
    }
}
