namespace LazzyCoffeeShop.Application.Common
{
    public abstract class BaseService : IDisposable
    {
        private readonly Lazy<IMapper> _mapper;
        protected IMapper MapperObject => _mapper.Value;

        public BaseService(Lazy<IMapper> mapper)
        {
            _mapper = mapper;
        }

        #region Dispose Pattern
        private bool _disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {

            }
            _disposed = true;
        }

        ~BaseService()
        {
            Dispose(false);
        }
        #endregion Dispose Pattern
    }
}
