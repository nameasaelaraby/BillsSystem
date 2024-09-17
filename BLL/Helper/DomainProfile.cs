using AutoMapper;
using DAL.Entity;
using DAL.ViewModels;
using System;

namespace BLL.Helper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            // Mapping for Item
            CreateMap<Item, ItemVM>()
                .ReverseMap();

            // Mapping for Company
            CreateMap<Company, CompanyVM>()
                .ReverseMap();

            // Mapping for Client
            CreateMap<Client, ClientVM>()
                .ReverseMap();

            // Mapping for Unit
            CreateMap<Unit, UnitVM>()
                .ReverseMap();

            // Mapping for Specie
            CreateMap<Specie, SpecieVM>()
                .ReverseMap();


            // Mapping for Bill
            CreateMap<Bill, BillVM>()
                .ReverseMap();

            // Mapping for SelesReport
            CreateMap<SelesReport, SelesReportVM>()
                .ReverseMap();

        }
    }
}
