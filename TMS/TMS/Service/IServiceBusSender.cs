namespace TMS.Service
{
    public interface IServiceBusSender
    {
        public System.Threading.Tasks.Task Send(Model.Task task);
        public Task<List<Model.Task>> Get(Model.Task task);
    }
}
