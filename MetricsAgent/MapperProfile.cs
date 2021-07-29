using AutoMapper;
using MetricsAgent.Metrics;
using MetricsAgent.Responses;

namespace MetricsAgent
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
            {
            CreateMap<CpuMetric, CpuMetricDto>();
            CreateMap<DotNetMetric, DotNetMetricDto>();
            CreateMap<NetMetric, NetMetricDto>();
            CreateMap<RamMetric, RamMetricDto>();
            CreateMap<HddMetric, HddMetricResponse>();
            }
    }
}
