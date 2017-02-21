namespace SuperShoes.Api.Controllers
{
    using Domain;
    using Filters;
    using Models;
    using Repositories.Exceptions;
    using SuperShoes.Services;
    using System;
    using System.Web.Http;

    [IdentityBasicAuthentication]
    public class StoreController : ApiController
    {
        /// <summary>
        /// Represents a service for the store.
        /// </summary>
        IStoreService storeService;

        /// <summary>
        /// Constructor of the controller.
        /// </summary>
        /// <param name="storeService">Service of the store.</param>
        public StoreController(IStoreService storeService)
        {
            this.storeService = storeService;
        }

        // GET: services/store
        public StoresResponse Get()
        {
            StoresResponse response = new StoresResponse() { Success = true };
            try
            {
                var stores = storeService.GetStores();
                response.Stores = stores;
                response.TotalElements = stores.Count;
            }
            catch (Exception exc)
            {
                response.Success = false;
                response.ErrorCode = ((int)ErrorResponse.ServerError).ToString();
                response.ErrorMessage = exc.Message;
            }

            return response;
        }

        // GET: services/store/5
        public StoreResponse Get(int id)
        {
            StoreResponse response = new StoreResponse() { Success = true };
            try
            {
                var store = storeService.GetStore(id);
                response.Store = store;
            }
            catch (RecordNotFoudException exc)
            {
                response.Success = false;
                response.ErrorCode = ((int)ErrorResponse.RecordNotFound).ToString();
                response.ErrorMessage = exc.Message;
            }
            catch (Exception exc)
            {
                response.Success = false;
                response.ErrorCode = ((int)ErrorResponse.ServerError).ToString();
                response.ErrorMessage = exc.Message;
            }

            return response;
        }

        // POST: services/store
        public Response Post(Store store)
        {
            Response response = new Response() { Success = true };
            try
            {
                storeService.SaveStore(store);
            }
            catch (Exception exc)
            {
                response.Success = false;
                response.ErrorCode = ((int)ErrorResponse.ServerError).ToString();
                response.ErrorMessage = exc.Message;
            }

            return response;
        }

        // PUT: services/store
        public Response Put(Store store)
        {
            Response response = new Response() { Success = true };
            try
            {
                storeService.UpdateStore(store);
            }
            catch (RecordNotFoudException exc)
            {
                response.Success = false;
                response.ErrorCode = ((int)ErrorResponse.RecordNotFound).ToString();
                response.ErrorMessage = exc.Message;
            }
            catch (Exception exc)
            {
                response.Success = false;
                response.ErrorCode = ((int)ErrorResponse.ServerError).ToString();
                response.ErrorMessage = exc.Message;
            }

            return response;
        }

        // DELETE: services/store/5
        public Response Delete(int id)
        {
            Response response = new Response() { Success = true };
            try
            {
                storeService.DeleteStore(id);
            }
            catch (RecordNotFoudException exc)
            {
                response.Success = false;
                response.ErrorCode = ((int)ErrorResponse.RecordNotFound).ToString();
                response.ErrorMessage = exc.Message;
            }
            catch (Exception exc)
            {
                response.Success = false;
                response.ErrorCode = ((int)ErrorResponse.ServerError).ToString();
                response.ErrorMessage = exc.Message;
            }

            return response;
        }
    }
}
