using AspNetCoreMongoDB.DTO.Car;
using AspNetCoreMongoDB.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMongoDB.Data
{
    public interface ICarDAL 
    {
        void MongoTest();
        CarListResponseDTO FindId(CarListRequestDTO src);
        Task<IEnumerable<CarListResponseDTO>> IEnumerableFindByAsync(CarListRequestDTO src);
        IQueryable<CarListResponseDTO> IQueryableGetAll();
        Task<IList<CarListResponseDTO>> IListGetAllAsync();
        Task<IEnumerable<CarListResponseDTO>> IEnumerableAsync();
        CarListResponseDTO GetId(string id);
        Task<CarListResponseDTO> GetIdAsync(string id);
        Task<long> AllCountAsync();
        Task<long> FindCountAsync(CarListRequestDTO src);
        IList<CarListResponseDTO> EqFindByList(CarListRequestDTO src);
        IList<CarListResponseDTO> LinqFindFluentBy(CarListRequestDTO src);
        Task<IList<CarListResponseDTO>> LinqFindFluentByAsync(CarListRequestDTO src);
        Task<IEnumerable<CarListResponseDTO>> InExpressions(CarListRequestDTO src);
        Task<IEnumerable<CarBrandRelationshipDTO.Car>> CarBrandRelationship(CarListRequestDTO src);
        IEnumerable<CarListResponseDTO> ElemMatchFindBy(CarListRequestDTO src);
        IEnumerable<CarListResponseDTO> TextFindBy(CarListRequestDTO src);
        IEnumerable<CarListResponseDTO> QueryableAsFindBy(CarListRequestDTO src);
        Task<bool> AddOneAsync(Cars dt);
        Task<bool> AddManyAsync(IList<Cars> dt);
        Task<bool> DeleteOneAsync(CarListRequestDTO src);
        Task<bool> DeleteManyAsync(CarListRequestDTO src);
        Task<bool> UpdateReplaceOneAsync(Cars dt);
        Task<bool> FindOneAndUpdate(Cars dt);
        Task<bool> UpdateOneAsync(Cars dt);
        Task<bool> UpdatePullFilterAsync(string name, CarListRequestDTO src);
        Task<bool> UpdateAddToSetAsync(CarListRequestDTO src, Comment dt);
        Task<bool> UpdateManyAddToSetAsync(CarListRequestDTO src, IList<Comment> dt);
        Task<bool> UpdateElemMatchAsync(CarListRequestDTO src, string commentname);
        void UpdateFullAsync(CarListRequestDTO src);
        Task<bool> InsertRelationshipAsync(Cars dt);
        Task<bool> UpdateManyAsync(Cars dt);
        Task<IEnumerable<CarBrandRelationshipDTO.Car>> CarBrandJoin(CarListRequestDTO src);


    }
}
