using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Repository
{
    public class JsonRepository<TData, TId> : IRepository<TData, TId> where TData : IValueItem<TId>
    {
        internal IJsonConverter JsonConverter = new JsonConverterShim();
        internal IFile File = new FileShim();

        private readonly string _fileName;
        private List<TData> _data;

        public JsonRepository(string fileName)
        {
            _fileName = fileName;
        }

        public JsonRepository<TData, TId> WithDataLoaded()
        {
            LoadData();
            return this;
        }

        public void LoadData()
        {
            _data = JsonConvert.DeserializeObject<List<TData>>(File.ReadAllText(_fileName));
        }

        private void SaveData()
        {
            File.WriteAllText(_fileName, JsonConvert.SerializeObject(_data));
        }

        public IEnumerable<TData> GetAll()
        {
            return _data;
        }

        public TData Get(TId id)
        {
            return _data.First(item => item.Id.Equals(id));
        }

        public void Add(TData item)
        {
            _data.Add(item);
            SaveData();
        }

        public void Remove(TData item)
        {
            _data.Remove(item);
            SaveData();
        }

        public void Remove(TId id)
        {
            Remove(_data.First(item => item.Id.Equals(id)));
        }

        public void Update(TData item)
        {
            _data.Remove(_data.Find(dataItem => dataItem.Id.Equals(item.Id)));
            _data.Add(item);
            SaveData();
        }
    }
}
