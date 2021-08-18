
public class Product
{
    public string StringID { get; set; }
    public string ID { get; set; }
    public string ProductName { get; set; }
    public List<ServicePlansIncluded> servicePlansIncluded { get; set; }
    public List<ServicePlansIncludedFriendlyNames> servicePlansIncludedFriendlyNames { get; set; }
}

public class ServicePlansIncluded
{
    public string ID { get; set; }
    public string Name { get; set; }
}

public class ServicePlansIncludedFriendlyNames
{
    public string ID { get; set; }
    public string Name { get; set; }
}