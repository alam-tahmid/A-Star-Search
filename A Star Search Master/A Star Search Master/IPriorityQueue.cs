using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Star_Search_Master {
    interface IPriorityQueue <T> {

        int Push(T item);
        T Pop();
        T Peek();
        void Update(int i);
    }
}
