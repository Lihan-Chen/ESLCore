using ESL.Core.Models.BusinessEntities;

namespace ESL.Core.IRepositories
{
    public interface ILogTypeRepository
    {
        // LogType GetItem(int logTypeNo)
        public Task<LogType> GetLogType(int LogTypeNo);

        // LogType GetItem(int logTypeNo)
        public Task<LogType> GetLogType(string LogTypeName);

        // LogList GetList() ~ GetLogList
        public Task<List<LogType>> GetLogTypes();

        public Task<string> GetLogTypeName(int LogTypeNo);
       
        public Task<int> GetLogTypeNo(string LogTypeName);

        // GetLogTypeList() for selectItem (LogTypeNo, LogTypeName)
        public Task<List<string>> GetLogTypeList();
    }
}