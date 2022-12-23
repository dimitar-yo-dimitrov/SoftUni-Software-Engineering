using System.Linq;

using AutoMapper;

using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<ImportSupplierDto, Supplier>();
            this.CreateMap<ImportPartDto, Part>();
            this.CreateMap<ImportCustomerDto, Customer>();
            this.CreateMap<ImportSaleDto, Sale>();

            this.CreateMap<Car, ExportCarWithDistanceDto>();
            this.CreateMap<Car, ExportCarBMWDto>();
            this.CreateMap<Supplier, ExportSupplierDto>();
            this.CreateMap<Part, ExportPartCarDto>();

            this.CreateMap<Car, ExportCarWithPartDto>()
                .ForMember(d => d.CarParts,
                    mo => mo.MapFrom(
                        s => s.PartCars
                            .Select(pt => pt.Part)
                            .OrderByDescending(p => p.Price)));

            this.CreateMap<Customer, ExportCustomerSaleDto>()
                .ForMember(d => d.BoughtCars,
                    mo => mo.MapFrom(
                        s => s.Sales.Count))
                .ForMember(d => d.SpentMoney,
                    mo => mo.MapFrom(
                        c => c.Sales
                            .Select(s => s.Car)
                            .SelectMany(car => car.PartCars)
                            .Sum(pc => pc.Part.Price)));

            this.CreateMap<Car, ExportCarDto>();

            this.CreateMap<Sale, ExportSaleWithDiscountDto>()
                .ForMember(d => d.SoldCar,
                    mo => mo.MapFrom(s => s.Car))
                .ForMember(d => d.Price,
                    mo => mo.MapFrom(s => s.Car.PartCars
                            .Sum(pc => pc.Part.Price)))
                .ForMember(d => d.PriceWithDiscount,
                    mo => mo.MapFrom(s => s.Car.PartCars
                            .Sum(pc => pc.Part.Price) - s.Car.PartCars
                        .Sum(pc => pc.Part.Price) * (s.Discount / 100)));
        }
    }
}
