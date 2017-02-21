namespace SuperShoes.Services
{
    using System.Collections.Generic;
    using System;
    using RestSharp;
    using System.Configuration;
    using Api.Models;
    using System.Net.Http.Headers;
    using System.Text;

    public class StoreService : IStoreService
    {
        /// <summary>
        /// Represents the client rest service for the store.
        /// </summary>
        private RestClient client;

        /// <summary>
        /// Constructor of the class.
        /// </summary>
        public StoreService()
        {
            this.client = new RestClient() { BaseUrl = new Uri(ConfigurationManager.AppSettings["WebApiBaseUrl"]) };
        } 

        /// <summary>
        /// Get all the stores in the respository.
        /// </summary>
        /// <returns>List the stores in the respository.</returns>
        public List<Store> GetStores()
        {
            List<Store> stores = new List<Store>();
            RestRequest request = new RestRequest("services/store", Method.GET) { RequestFormat = DataFormat.Json };
            request.AddHeader("Authorization", "Basic " + Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", ConfigurationManager.AppSettings["APIUser"], ConfigurationManager.AppSettings["APIPassword"]))));
            var result = this.client.Execute<StoresResponse>(request);
            if (result.Data == null)
            {
                throw new Exception(result.ErrorMessage);
            }
            if (result.Data.Success)
            {
                stores = result.Data.Stores;
            }
            else
            {
                throw new Exception(result.Data.ErrorMessage);
            }

            return stores;
        }

        /// <summary>
        /// Save a store.
        /// </summary>
        /// <param name="store">Store to save.</param>
        public void SaveStore(Store store)
        {
            RestRequest request = new RestRequest("services/store", Method.POST) { RequestFormat = DataFormat.Json };
            request.AddHeader("Authorization", "Basic " + Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", ConfigurationManager.AppSettings["APIUser"], ConfigurationManager.AppSettings["APIPassword"]))));
            request.AddBody(store);
            var result = this.client.Execute<Response>(request);
            if (result.Data == null)
            {
                throw new Exception(result.ErrorMessage);
            }
            if (!result.Data.Success)
            {
                throw new Exception(result.Data.ErrorMessage);
            }
        }

        /// <summary>
        /// Update a store.
        /// </summary>
        /// <param name="store">Store to update.</param>
        public void UpdateStore(Store store)
        {
            RestRequest request = new RestRequest("services/store", Method.PUT) { RequestFormat = DataFormat.Json };
            request.AddHeader("Authorization", "Basic " + Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", ConfigurationManager.AppSettings["APIUser"], ConfigurationManager.AppSettings["APIPassword"]))));
            request.AddBody(store);
            var result = this.client.Execute<Response>(request);
            if (result.Data == null)
            {
                throw new Exception(result.ErrorMessage);
            }
            if (!result.Data.Success)
            {
                throw new Exception(result.Data.ErrorMessage);
            }
        }

        /// <summary>
        /// Delete a store by id.
        /// </summary>
        /// <param name="storeId">Id of the store.</param>
        public void DeleteStore(int storeId)
        {
            RestRequest request = new RestRequest("services/store" + storeId, Method.DELETE) { RequestFormat = DataFormat.Json };
            request.AddHeader("Authorization", "Basic " + Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", ConfigurationManager.AppSettings["APIUser"], ConfigurationManager.AppSettings["APIPassword"]))));
            var result = this.client.Execute<Response>(request);
            if (result.Data == null)
            {
                throw new Exception(result.ErrorMessage);
            }
            if (!result.Data.Success)
            {
                throw new Exception(result.Data.ErrorMessage);
            }
        }

        /// <summary>
        /// Get a store.
        /// </summary>
        /// <param name="storeId">Id of the store to get.</param>
        public Store GetStore(int storeId)
        {
            Store store = new Store();
            RestRequest request = new RestRequest("services/store" + storeId, Method.GET) { RequestFormat = DataFormat.Json };
            request.AddHeader("Authorization", "Basic " + Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", ConfigurationManager.AppSettings["APIUser"], ConfigurationManager.AppSettings["APIPassword"]))));
            var result = this.client.Execute<StoreResponse>(request);
            if (result.Data == null)
            {
                throw new Exception(result.ErrorMessage);
            }
            if (result.Data.Success)
            {
                store = result.Data.Store;
            }
            else
            {
                throw new Exception(result.Data.ErrorMessage);
            }

            return store;
        }
    }
}
