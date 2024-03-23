
using RestAspNet8VStudio.Model;
using RestAspNet8VStudio.VObject.Converter.Implementations;
using RestAspNet8VStudio.VObject;
using RestAspNetStudio.Data.Generic;

namespace RestAspNet8VStudio.Logic.Implementations
{
    public class PriceLogicImplementation : IPriceLogic
    {
        private readonly IGenericData<Price> _data;
        private readonly PriceConverter _converter;

        public PriceLogicImplementation(IGenericData<Price> data)
        {
            _data = data;
            _converter = new PriceConverter();
        }

        public PriceVO Create(PriceVO price)
        {
            var PriceEntity = _converter.Convert(price);
            PriceEntity = _data.Create(PriceEntity);
            return _converter.Convert(PriceEntity);
        }

        public void Delete(long id)
        {
            _data.Delete(id);
        }

        public List<PriceVO> FindAll()
        {
            return _converter.Convert(_data.FindAll());
        }
        public PriceVO FindById(long id)
        {
            return _converter.Convert(_data.FindById(id));
        }
        public PriceVO Update(PriceVO price)
        {
            var PriceEntity = _converter.Convert(price);
            PriceEntity = _data.Update(PriceEntity);
            return _converter.Convert(PriceEntity);
        }
    }
}
