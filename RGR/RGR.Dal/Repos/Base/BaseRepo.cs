//using Npgsql;

//namespace RGR.Dal.Repos.Base
//{
//    public abstract class BaseRepo<T> : IRepo<T> where T : new()
//    {
//        private readonly bool _disposedConnection;
//        public NpgsqlConnection Connection { get; private set; }
//        protected BaseRepo(NpgsqlConnection connection) 
//        {
//            _disposedConnection = false;
//            Connection = connection;
//        }
//        protected BaseRepo(string connectionString) : this(new NpgsqlConnection(connectionString))
//        {
//            _disposedConnection = true;
//        }
//        public void Dispose() 
//        {
//            Dispose(true);
//            GC.SuppressFinalize(this);
//        }
//        private bool _isDisposed;
//        protected virtual void Dispose(bool disposing)
//        {
//            if (_isDisposed)
//                return;

//            if (disposing) 
//                if (_disposedConnection)
//                    Connection.Dispose();

//            _isDisposed = true;
//        }
//        ~BaseRepo()
//        {
//            Dispose(false);
//        }
//        public virtual T? Find(int? id)
//        {
//            Connection.Open();

//            NpgsqlCommand cmd = Connection.CreateCommand();
//            cmd.CommandType = System.Data.CommandType.Text;
//            cmd.CommandText = @"SELECT * ";
//        }
//    }
//}
