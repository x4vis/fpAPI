using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using api.Access;
using AutoMapper;
using fpAPI.Access;
using fpAPI.Access.DbCtx;
using fpAPI.DTO;
using fpAPI.Helpers;
using fpAPI.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fpAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProviderController : ControllerBase
    {
        private readonly IMapper mapper;

        public ProviderController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        /// <summary>
        ///     Get a providers list
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns>
        ///     A paginated list if pagination.Paginated == true
        /// </returns>
        [HttpGet]
        [Route("list")]
        public async Task<List<IdProvider>>
            GetProviders([FromQuery] Pagination pagination)
        {
            List<Provider> provs;

            if (pagination.Paginated == false)
            {
                provs = await CRUDL.List(EFCtx.Inv.Providers);
            }
            else
            {
                IQueryable<Provider> query = LogicProviders
                    .GetProviderQuery(pagination.Search);

                await HttpContext.InsertPagionationParameters(
                        query.AsQueryable(), pagination.ResourceQty
                    );

                provs = await query.Paginate(pagination).ToListAsync();
            }

            return mapper.Map<List<IdProvider>>(provs);
        }


        /// <summary>
        ///     Get a provider
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        ///     A provider
        /// </returns>
        [HttpGet("{id}", Name = "getProvider")]
        public async Task<ActionResult<IdProvider>> GetProvider(uint id)
        {
            Provider prov = await CRUDL.Read(EFCtx.Inv.Providers, id);

            if (prov == null)
            {
                return NotFound();
            }

            return mapper.Map<IdProvider>(prov);
        }

        /// <summary>
        ///     Creates a new provider
        /// </summary>
        /// <param name="baseProv"></param>
        /// <returns>
        ///     the resource created
        /// </returns>
        [HttpPost]
        public async Task<ActionResult>
            PostProvider([FromBody] BaseProvider baseProv)
        {
            var prov = mapper.Map<Provider>(baseProv);
            ReasonCRUDL r = await CRUDL.Create(EFCtx.Inv.Providers, prov);

            switch (r)
            {
                case ReasonCRUDL.DUPLICATE:
                    return BadRequest();

                case ReasonCRUDL.CREATE:
                    var provCreated = mapper.Map<IdProvider>(prov);
                    return new CreatedAtRouteResult(
                            "getProvider",
                            new { id = provCreated.Id }, provCreated
                        );

                default:
                    return StatusCode(500);
            }
        }
    }
}

