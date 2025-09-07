using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Context;
using WebAPI.Dtos.FeatureDtos;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly APIContext context;
        
        public FeaturesController(IMapper mapper, APIContext context)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = context.Features.ToList();
            return Ok(mapper.Map<List<ResultFeatureDto>>(values));
        }

        [HttpGet("GetFeature")]
        public IActionResult FeatureGet(int id)
        {
            var values = context.Features.Find(id);
            return Ok(mapper.Map<GetByIdFeatureDto>(values));
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var value = mapper.Map<Feature>(createFeatureDto);
            context.Features.Add(value);
            context.SaveChanges();
            return Ok("Feature added successfully.");
        }

        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var value = context.Features.Find(id);
            context.Features.Remove(value);
            context.SaveChanges();
            return Ok("Feature deleted successfully.");
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdteFeatureDto updteFeatureDto)
        {
            var value = mapper.Map<Feature>(updteFeatureDto);
            context.Features.Update(value);
            context.SaveChanges();
            return Ok("Feature updated successfully.");
        }
    }
}
