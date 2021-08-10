public class TreeA {
    private NodeA root;

    public TreeA(){
        root = null;
    }

    public NodeA AddNode(int value)
    {
        NodeA created = null;
        if(root!=null){
            created = root.AddNode(value);
        }
        else{
            created = new NodeA(value);
            root = created;
        }
        return created;
    }
}