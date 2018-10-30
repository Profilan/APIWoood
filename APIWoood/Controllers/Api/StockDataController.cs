
using APIWoood.Logic.Repositories;
using APIWoood.Logic.Services;
using System.Web.Http;

namespace APIWoood.Controllers.Api
{
    public class StockDataController : WooodApiController
    {
        private readonly UserRepository userRepository;
        private readonly StockDataRepository stockDataRepository;
        private SystemLogger logger;

        public StockDataController()
        {
            stockDataRepository = new StockDataRepository();
            logger = new SystemLogger();
        }

        [Route("api/stock-data/list")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult GetStockDataList(string apikey, int page = 1, int limit = 25)
        {
            try
            {
                var items = stockDataRepository.GetStockDataList();

                

                return Ok();
            }
            catch
            {

                throw;
            }
        }
    }
}
