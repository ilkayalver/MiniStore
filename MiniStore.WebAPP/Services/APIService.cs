using MiniStore.WebAPP.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniStore.WebAPP.Services
{
    public class APIService
    {
        public APIService()
        {

        }


        public SearchResultModel Search(string query)
        {
            var products = GetProducts(null).Where(x => x.Name.ToLowerInvariant().Contains(query)).ToList();
            var categories = GetCategories(null, null).Where(x => x.Name.ToLowerInvariant().Contains(query)).ToList();

            return new SearchResultModel()
            {
                Categories = categories,
                Products = products
            };
        }

        public List<ProductModel> GetProducts(int? categoryId)
        {
            string url;
            if (categoryId != null)
            {
                url = "https://localhost:44393/Products/GetProducts?categoryId=" + categoryId;
            }
            else
            {
                url = "https://localhost:44393/Products/GetProducts";
            }
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest(Method.GET);
            var response = client.Execute(request);
            List<ProductModel> deseiraliazeObj = JsonConvert.DeserializeObject<List<ProductModel>>(response.Content);
            return deseiraliazeObj;
        }

        public List<CategoryModel> GetCategories(int? categoryId, int? parentCategoryId)
        {
            string url;
            if (categoryId != null && parentCategoryId != null)
            {
                url = "https://localhost:44393/Categories?categoryId=" + categoryId + "&parentCategoryId" + parentCategoryId;
            }
            else
            {
                url = "https://localhost:44393/Categories";
            }
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest(Method.GET);
            var response = client.Execute(request);
            List<CategoryModel> deseiraliazeObj = JsonConvert.DeserializeObject<List<CategoryModel>>(response.Content);
            return deseiraliazeObj;
        }

        public List<ProductModel> GetDefaultProducts()
        {
            RestClient client = new RestClient("https://localhost:44393/Products/GetDefaultProducts");
            RestRequest request = new RestRequest(Method.GET);
            var response = client.Execute(request);
            var deseiraliazeObj = JsonConvert.DeserializeObject<List<ProductModel>>(response.Content);
            return deseiraliazeObj;
        }
    }
}
