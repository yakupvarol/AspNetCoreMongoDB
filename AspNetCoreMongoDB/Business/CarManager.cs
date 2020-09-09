using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreMongoDB.Data;
using AspNetCoreMongoDB.DTO.Car;
using AspNetCoreMongoDB.Entities;
using AutoMapper;

namespace AspNetCoreMongoDB.Business
{
    public class CarManager : ICarService
    {
        private readonly ICarDAL _carDAL;
        private readonly IMapper _mapper;

        public CarManager(ICarDAL carDAL, IMapper mapper)
        {
            _carDAL = carDAL;
            _mapper = mapper;
        }

        public void MongoTest()
        {
            _carDAL.MongoTest();
        }

        public async Task<bool> AddOneAsync(Cars dt)
        {
            return await _carDAL.AddOneAsync(dt);
        }

        public async Task<bool> AddManyAsync(IList<Cars> dt)
        {
            return await _carDAL.AddManyAsync(dt);
        }

        public async Task<long> AllCountAsync()
        {
            return await _carDAL.AllCountAsync();
        }

        public async Task<IEnumerable<CarBrandRelationshipDTO.Car>> CarBrandRelationship(CarListRequestDTO src)
        {
            return await _carDAL.CarBrandRelationship(src);
        }

        public async Task<bool> DeleteManyAsync(CarListRequestDTO src)
        {
            return await _carDAL.DeleteManyAsync(src);
        }

        public IEnumerable<CarListResponseDTO> ElemMatchFindBy(CarListRequestDTO src)
        {
            return _carDAL.ElemMatchFindBy(src);
        }

        public IList<CarListResponseDTO> EqFindByList(CarListRequestDTO src)
        {
            return _carDAL.EqFindByList(src);
        }

        public async Task<long> FindCountAsync(CarListRequestDTO src)
        {
            return await _carDAL.FindCountAsync(src);
        }

        public async Task<bool> FindOneAndUpdate(Cars dt)
        {
            return await FindOneAndUpdate(dt);
        }

        public CarListResponseDTO GetId(string id)
        {
            return _carDAL.GetId(id);
        }

        public async Task<CarListResponseDTO> GetIdAsync(string id)
        {
            return await _carDAL.GetIdAsync(id);
        }

        public async Task<IEnumerable<CarListResponseDTO>> IEnumerableAsync()
        {
            return await _carDAL.IEnumerableAsync();
        }

        public async Task<IEnumerable<CarListResponseDTO>> IEnumerableFindByAsync(CarListRequestDTO src)
        {
            return await _carDAL.IEnumerableFindByAsync(src);
        }

        public async Task<IList<CarListResponseDTO>> IListGetAllAsync()
        {
            return await _carDAL.IListGetAllAsync();
        }

        public async Task<IEnumerable<CarListResponseDTO>> InExpressions(CarListRequestDTO src)
        {
            return await _carDAL.InExpressions(src);
        }

        public IList<CarListResponseDTO> IQueryableGetAll()
        {
            return _carDAL.IQueryableGetAll().ToList();
        }

        public IList<CarListResponseDTO> LinqFindFluentBy(CarListRequestDTO src)
        {
            return _carDAL.LinqFindFluentBy(src);
        }

        public async Task<IList<CarListResponseDTO>> LinqFindFluentByAsync(CarListRequestDTO src)
        {
            return await _carDAL.LinqFindFluentByAsync(src);
        }

        public IEnumerable<CarListResponseDTO> QueryableAsFindBy(CarListRequestDTO src)
        {
            return _carDAL.QueryableAsFindBy(src);
        }

        public IEnumerable<CarListResponseDTO> TextFindBy(CarListRequestDTO src)
        {
            return _carDAL.TextFindBy(src);
        }

        public async Task<bool> UpdateAddToSetAsync(CarListRequestDTO src, Comment dt)
        {
            return await _carDAL.UpdateAddToSetAsync(src,dt);
        }

        public async Task<bool> UpdateElemMatchAsync(CarListRequestDTO src, string commentname)
        {
            return await _carDAL.UpdateElemMatchAsync(src, commentname);
        }

        public void UpdateFullAsync(CarListRequestDTO src)
        {
            _carDAL.UpdateFullAsync(src);
        }

        public async Task<bool> UpdateManyAddToSetAsync(CarListRequestDTO src, IList<Comment> dt)
        {
            return await _carDAL.UpdateManyAddToSetAsync(src, dt);
        }

        public async Task<bool> UpdateOneAsync(Cars dt)
        {
            return await _carDAL.UpdateOneAsync(dt);
        }

        public async Task<bool> UpdatePullFilterAsync(string name, CarListRequestDTO src)
        {
            return await _carDAL.UpdatePullFilterAsync(name,src);
        }

        public async Task<bool> UpdateReplaceOneAsync(Cars dt)
        {
            return await _carDAL.UpdateReplaceOneAsync(dt);
        }

        public async Task<bool> InsertRelationshipAsync(Cars dt)
        {
            return await _carDAL.InsertRelationshipAsync(dt);
        }

        public async Task<bool> UpdateManyAsync(Cars dt)
        {
            return await _carDAL.UpdateManyAsync(dt);
        }

        public CarListResponseDTO FindId(CarListRequestDTO src)
        {
            return _carDAL.FindId(src);
        }

        public async Task<bool> DeleteOneAsync(CarListRequestDTO src)
        {
            return await _carDAL.DeleteOneAsync(src);
        }

        public async Task<IEnumerable<CarBrandRelationshipDTO.Car>> CarBrandJoin(CarListRequestDTO src)
        {
            return await _carDAL.CarBrandJoin(src);
        }
    }
}
