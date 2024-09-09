namespace DSA;
class Dependency
{
    public List<Dependency> dependencies;
    // consider that you're creating a package manager for a language that allows users to download dependencies for their code.
    // Each dependency can have 0, 1, or multiple dependencies
    // a dependency is said to be *resolvable* if at least one of the following conditions are met:
    // - has no dependencies
    // - all of its dependencies are resolvable

    // fill in this function which takes in a dependency. if the dependency is resolvable, return true. if not, return false.
}
class LandonExpediaInterviewQuestion
{
    public bool IsResolvable(Dependency root)
    {
        return dfs(root, new HashSet<Dependency>());
    }

    private bool dfs(Dependency root, HashSet<Dependency> set)
    {
        if (!set.Add(root))
        {
            return false;
        }
        if (root.dependencies == null || root.dependencies.Count == 0)
        {
            return true;
        }

        for (int i = 0; i < root.dependencies.Count; i++)
        {
            if (!dfs(root.dependencies[i], set))
            {
                return false;
            }
            set.Remove(root.dependencies[i]);
        }

        return true;
    }
}