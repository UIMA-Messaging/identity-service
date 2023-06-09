using IdentityService.Contracts;
using IdentityService.Services.Keys;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.Controllers;

[ApiController]
[Route("keys")]
public class KeyController : ControllerBase
{
    private readonly KeyService service;

    public KeyController(KeyService service)
    {
        this.service = service ?? throw new ArgumentNullException(nameof(service));
    }
    
    [HttpPost("register/exchanges")]
    public async Task RegisterKeyBundles([FromBody] ExchangeKeys keys)
    {
        await service.RegisterExchangeKeys(keys);
    }
    
    [HttpPost("bundle/{from}/{to}")]
    public async Task<KeyBundle> FetchKeyBundle(string from, string to)
    {
        return await service.GetKeyBundle(from, to);
    }
}