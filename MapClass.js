// create a graph class
class Graph {
    // defining vertex array and
    // adjacent list
    constructor(noOfVertices)
    {
        this.noOfVertices = noOfVertices;
        this.AdjList = new Map();
    }

    // functions to be implemented

    addVertex(v)
    {
    // initialize the adjacent list with a
    // null array
    this.AdjList.set(v, []);
  }

  addEdge(v, w)
  {
    // get the list for vertex v and put the
    // vertex w denoting edge betweeen v and w
    this.AdjList.get(v).push(w);
    // Since graph is undirected,
    // add an edge from w to v also
    this.AdjList.get(w).push(v);
  }     // printGraph()

    // bfs(v)
    // dfs(v)
}
