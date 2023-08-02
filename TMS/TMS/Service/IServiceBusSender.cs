namespace TMS.Service
{
    public interface IServiceBusSender
    {
        public System.Threading.Tasks.Task Send(Data.Model.Task task);
        public Task<List<Data.Model.Task>> Get(Data.Model.Task task);
    }
}
