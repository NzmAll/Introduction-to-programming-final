using Newtonsoft.Json;
using System.Xml;
using TaskManagement.Database.Models.Common;


namespace TaskManagement.Database.Repositories
{
    public abstract class JsonFileRepository<T> where T : BaseEntity<decimal>
    {
        private readonly string _fileName;
        private readonly List<T> _data;

        public object JsonConvert { get; private set; }

        protected JsonFileRepository(string fileName)
        {
            _fileName = fileName;
            _data = new List<T>();
            LoadDataFromFile(Get_data());
        }

        protected void Add(T entity)
        {
            entity.Id = GenerateNewId();
            _data.Add(entity);
            SaveDataToFile();
        }

        protected void Update(T entity)
        {
            int index = _data.FindIndex(x => x.Id == entity.Id);
            if (index != -1)
            {
                _data[index] = entity;
                SaveDataToFile();
            }
        }

        protected void Delete(decimal id)
        {
            int index = _data.FindIndex(x => x.Id == id);
            if (index != -1)
            {
                _data.RemoveAt(index);
                SaveDataToFile();
            }
        }

        protected List<T> GetAll()
        {
            return _data;
        }

        protected T GetById(decimal id)
        {
            return _data.Find(x => x.Id == id);
        }

        private List<T> Get_data()
        {
            return _data;
        }

        private void LoadDataFromFile(List<T> _data)
        {
            if (File.Exists(_fileName))
            {
                string jsonData = File.ReadAllText(_fileName);
                _data = JsonConvert.DeserializeObject<List<T>>(jsonData);
            }
        }

        private void SaveDataToFile()
        {
            string jsonData = JsonConvert.SerializeObject(_data, System.Xml.Formatting.Indented);
            File.WriteAllText(_fileName, jsonData);
        }

        private decimal GenerateNewId()
        {
            decimal maxId = 0;
            foreach (var entity in _data)
            {
                if (entity.Id > maxId)
                {
                    maxId = entity.Id;
                }
            }
            return maxId + 1;
        }
    }
}
