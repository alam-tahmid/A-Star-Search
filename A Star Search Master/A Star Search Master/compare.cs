using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Star_Search_Master {
    class compare: IComparer<Node> {
        int IComparer<Node>.Compare(Node x, Node y) {

            if (x.f_scores > y.f_scores) {
                return 1;
            }

            else if (x.f_scores < y.f_scores) {
                return -1;
            }

            else {
                return 0;
            }
        }
    }
}
