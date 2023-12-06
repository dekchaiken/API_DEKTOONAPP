using Dektoon.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dektoon.Repositories;
using Dektoon.Services;

namespace Dektoon.Services
{
    public class DektoonServices : IDektoonServices
    {
        private readonly IDektoonRepositories repository;

        public DektoonServices(IDektoonRepositories repository)
        {
            this.repository = repository;
        }

        public List<CartoonModel> GetCartoon()
        {
            var result = repository.QueryStoredProcedure<CartoonModel>("SP_selectAllCartoon", null);

            return result.ToList();
        }
        public string AddCartoon(CartoonModel cartoon)
        {
            var spParam = new DynamicParameters();
            spParam.Add("@cartoonName", cartoon.CartoonName);
            spParam.Add("@cartoonSubtitle", cartoon.CartoonSubtitle);
            spParam.Add("@cartoonCover", cartoon.CartoonCover);
            spParam.Add("@cartoonTypeId", cartoon.TypeId);
            var result = repository.ExecuteStoredProcedure<CartoonModel>("SP_createCartoon", spParam);
            if (result != 0)
                return "Add Cartoon success";
            else
                return "Add Cartoon fail";
        }
        public string UpdateCartoon(CartoonModel cartoon)
        {
            var spParam = new DynamicParameters();
            spParam.Add("@cartoonId", cartoon.CartoonId);
            spParam.Add("@cartoonName", cartoon.CartoonName);
            spParam.Add("@cartoonSubtitle", cartoon.CartoonSubtitle);
            spParam.Add("@cartoonCover", cartoon.CartoonCover);
            spParam.Add("@typeId", cartoon.TypeId);
            var result = repository.ExecuteStoredProcedure<CartoonModel>("SP_UpdateCartoonID", spParam);
            if (result != 0)
                return "Update Cartoon success";
            else
                return "Update Cartoon fail";
        }
        public string DeleteCartoon(int cartoonId)
        {
            var spParam = new DynamicParameters();
            spParam.Add("@cartoonId", cartoonId);
            var result = repository.ExecuteStoredProcedure<CartoonModel>("SP_DeleteCartoonID", spParam);
            if (result != 0)
                return "Delete Cartoon success";
            else
                return "Delete Cartoon fail";
        }
    }
}