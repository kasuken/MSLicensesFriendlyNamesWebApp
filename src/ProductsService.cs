public class ProductsService
{
    const string url = "https://raw.githubusercontent.com/MicrosoftDocs/azure-docs/master/articles/active-directory/enterprise-users/licensing-service-plan-reference.md";

    public async Task<List<Product>> GetProducts()
    {
        var products = new List<Product>();

        var client = new HttpClient();
        var response = await client.GetAsync(url);
        var content = await response.Content.ReadAsStringAsync();

        var lines = content.Split('\n').Where(l => l.StartsWith("|")).ToList();
        lines.RemoveAt(0);
        lines.RemoveAt(0);

        foreach (var line in lines)
        {
            var product = new Product();
            product.servicePlansIncluded = new List<ServicePlansIncluded>();
            product.servicePlansIncludedFriendlyNames = new List<ServicePlansIncludedFriendlyNames>();

            var productString = line.Trim().Split('|');

            if (productString.Length < 6) continue;

            product.ProductName = productString[1].Trim();
            product.StringID = productString[2].Trim();
            product.ID = productString[3].Trim();

            if (productString[4].IndexOf("<br/>") > -1)
            {
                var servicePlans = productString[4].Trim().Split("<br/>");

                foreach (var servicePlan in servicePlans)
                {
                    if (string.IsNullOrEmpty(servicePlan)) continue;

                    try
                    {
                        var servicePlansIncluded = new ServicePlansIncluded();
                        servicePlansIncluded.Name = servicePlan.Split("(")[0];
                        servicePlansIncluded.ID = servicePlan.Split("(")[1].Replace("(", "").Replace(")", "");

                        product.servicePlansIncluded.Add(servicePlansIncluded);
                    }
                    catch (System.Exception ex)
                    {
                    }
                }
            }
            else
            {
                var servicePlansIncluded = new ServicePlansIncluded();
                servicePlansIncluded.Name = productString[4].Trim().Split(" ")[0];
                servicePlansIncluded.ID = productString[4].Trim().Split(" ")[1].Replace("(", "").Replace(")", "");

                product.servicePlansIncluded.Add(servicePlansIncluded);
            }

            if (productString[5].IndexOf("<br/>") > -1)
            {
                var servicePlans = productString[5].Trim().Split("<br/>");

                foreach (var servicePlan in servicePlans)
                {
                    if (string.IsNullOrEmpty(servicePlan)) continue;

                    try
                    {
                        var servicePlansIncluded = new ServicePlansIncludedFriendlyNames();
                        servicePlansIncluded.Name = servicePlan.Split("(")[0];
                        servicePlansIncluded.ID = servicePlan.Split("(")[1].Replace("(", "").Replace(")", "");

                        product.servicePlansIncludedFriendlyNames.Add(servicePlansIncluded);
                    }
                    catch (System.Exception ex)
                    {
                    }
                }
            }
            else
            {
                var servicePlansIncluded = new ServicePlansIncludedFriendlyNames();
                servicePlansIncluded.Name = productString[4].Trim().Split("(")[0];
                servicePlansIncluded.ID = productString[4].Trim().Split("(")[1].Replace("(", "").Replace(")", "");

                product.servicePlansIncludedFriendlyNames.Add(servicePlansIncluded);
            }

            products.Add(product);

        }

        return products;
    }
}