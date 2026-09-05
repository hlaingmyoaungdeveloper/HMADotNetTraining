using DependencyInjectionDemo.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LifetimeController : ControllerBase
    {
        private readonly ITransientOperation _transientOperation1;
        private readonly ITransientOperation _transientOperation2;
        
        private readonly IScopedOperation _scopedOperation1;
        private readonly IScopedOperation _scopedOperation2;
        
        private readonly ISingletonOperation _singletonOperation1;
        private readonly ISingletonOperation _singletonOperation2;

        public LifetimeController(
            ITransientOperation transientOperation1,
            ITransientOperation transientOperation2,
            IScopedOperation scopedOperation1,
            IScopedOperation scopedOperation2,
            ISingletonOperation singletonOperation1,
            ISingletonOperation singletonOperation2)
        {
            _transientOperation1 = transientOperation1;
            _transientOperation2 = transientOperation2;
            
            _scopedOperation1 = scopedOperation1;
            _scopedOperation2 = scopedOperation2;
            
            _singletonOperation1 = singletonOperation1;
            _singletonOperation2 = singletonOperation2;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                Transient = new 
                {
                    Instance1 = _transientOperation1.OperationId,
                    Instance2 = _transientOperation2.OperationId
                },
                Scoped = new 
                {
                    Instance1 = _scopedOperation1.OperationId,
                    Instance2 = _scopedOperation2.OperationId
                },
                Singleton = new 
                {
                    Instance1 = _singletonOperation1.OperationId,
                    Instance2 = _singletonOperation2.OperationId
                }
            });
        }
    }
}
