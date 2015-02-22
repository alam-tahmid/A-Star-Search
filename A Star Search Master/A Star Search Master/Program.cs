using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Star_Search_Master {
    class Program {
        static void Main(string[] args) {
    
            Node[] node = new Node[5];
            node[0] = new Node("s", 1);
            node[1] = new Node("a", 3);
            node[2] = new Node("b", 3);
            node[3] = new Node("c", 0);
            node[4] = new Node("d", 0);
            
            Console.WriteLine("Places: ");
            
            foreach (Node count in node) {
                
                Console.WriteLine(count.ToString());
            }
            
            Console.Write("From: ");
            string from = Console.ReadLine();
            Console.Write("To: ");
            string to = Console.ReadLine();
            
            int countFrom = 0;

            foreach (Node n in node) {
                
                if (from.Equals(n.ToString())) {

                    break;
                }else{
                    
                    countFrom++;
                }
            }

    
            int toCount = 0;

   
            foreach (Node n in node) {

       
                if (to.Equals(n.ToString())) {

                    break;
                }else{

                    toCount++;      
                }
            }

    
            node[0].adjacencies = new Edge[]{

                new Edge(node[1],3),//s-->a
                new Edge(node[2],2),//s--> b
            };

            node[1].adjacencies = new Edge[]{

			
                new Edge(node[0],3),//a-->s
                new Edge(node[2],3),//a-->b
                new Edge(node[3],1),//a-->c
                new Edge(node[4],3)//a-->d
            };

   
            node[2].adjacencies = new Edge[]{

                new Edge(node[0],2),//b-->s
                new Edge(node[1],3),//a-->b
                new Edge(node[3],5),//b-->c
                new Edge(node[4],3)//b-->d
            };

    
            node[3].adjacencies = new Edge[]{

                new Edge(node[1],1),//c-->a
                new Edge(node[2],5),//c-->b
                new Edge(node[4],2)//c-->d
            };

    
            node[4].adjacencies = new Edge[]{

                new Edge(node[1],5),//d-->a
                new Edge(node[2],3),//d-->b
                new Edge(node[3],2)//d-->c
            };
    
            AstarSearch(node[countFrom], node[toCount]);
            List <Node> path = printPath(node[toCount]);

            Console.WriteLine("Path: [" + String.Join(", ", path) + "]");
            Console.ReadLine();
        }
    public static List<Node> printPath(Node target) {
    
        List<Node> path = new List<Node>();

        for (Node node = target; node != null; node = node.parent) {
                path.Add(node);
            }

            path.Reverse();
            return path;
    }

    public static void AstarSearch(Node source, Node goal) {

        HashSet<Node> explored = new HashSet<Node>();
        compare com = new compare();
        PriorityQueue<Node> queue = new PriorityQueue<Node>(20, com);

        source.g_scores = 0;
        queue.Push(source);

        bool found = false;

        while ((queue.Count != 0) && (!found)) {

            Node current = queue.Pop();

            explored.Add(current);

            if (current.value.Equals(goal.value)) {
                found = true;
            }
           
            foreach (Edge e in current.adjacencies) {

                Node child = e.target;
                double cost = e.cost;
                double temp_g_scores = current.g_scores + cost;
                double temp_f_scores = temp_g_scores + child.h_scores;

                if ((explored.Contains(child)) &&(temp_f_scores >= child.f_scores)) {

                    //do nothing
                }

                else if ((!queue.contains(child)) ||(temp_f_scores < child.f_scores)) {

                    child.parent = current;
                    child.g_scores = temp_g_scores;
                    child.f_scores = temp_f_scores;

                    if (queue.contains(child)) {

                        queue.RemoveLocation(child);
                    }
                    queue.Push(child);
                }
            }
        }
    }
  }
}
