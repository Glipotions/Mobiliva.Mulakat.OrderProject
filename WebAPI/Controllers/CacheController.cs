using Microsoft.AspNetCore.Mvc;
using Mobiliva.Mulakat.Business.Abstract;
using Mobiliva.Mulakat.Core.CrossCuttingConcerns.Caching;
using Mobiliva.Mulakat.Core.Enums;
using Mobiliva.Mulakat.Entities.Concrete;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class CacheController : ControllerBase
	{
		ICacheService _cacheService;

		public CacheController(ICacheService CacheService)
		{
			_cacheService = CacheService;
		}
		[HttpGet("cache/{key}")]
		public async Task<IActionResult> GetCacheValue([FromRoute] string key)
        {
			var value = await _cacheService.GetValueAsync(key);
			return string.IsNullOrEmpty(value) ? (IActionResult)NotFound() : Ok(value);
        }

		[HttpPost("cache")]
		public async Task<IActionResult> SetCacheValue([FromBody] NewCacheEntryRequest request)
		{
			await _cacheService.SetValueAsync(request.Key, request.Value);
			return Ok();
		}
	}
}
