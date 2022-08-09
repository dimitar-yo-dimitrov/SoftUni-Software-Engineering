using System.Linq;
using AutoMapper;

using CarDealer.DTO.Export;
using CarDealer.DTO.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<ImportSuppliersDto, Supplier>();
            this.CreateMap<ImportPartDto, Part>();
            this.CreateMap<ImportCustomerDto, Customer>();

            this.CreateMap<Customer, ExportCustomerDto>();
            this.CreateMap<Car, ExportCarToyotaDto>();
            this.CreateMap<Supplier, ExportLocalSupplierDto>();
            this.CreateMap<Car, ExportCarDto>();
            this.CreateMap<Sale, ExportSalesWithDiscountDto>()
                .ForMember(d => d.Discount, mo => mo.MapFrom(s => s.Discount.ToString("F2")))
                .ForMember(d => d.Price, mo => mo.MapFrom(s => s.Car.PartCars.Sum(p => p.Part.Price).ToString("F2")));
            this.CreateMap<ExportCarDto, ExportSalesWithDiscountDto>();
        }


    }
}
