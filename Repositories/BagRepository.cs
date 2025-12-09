using ex01.Data;
using ex01.Dto;
using ex01.Models;
using System;
using AutoMapper;

namespace ex01.Repositories
{
    public class BagRepository : IBagRepository
    {
        private readonly StoreDbContext context;
        public BagRepository(StoreDbContext context1)
        {
            context = context1;
        }

        //GetBags
        public List<BagDto> GetBags()
        {
            return context.bags
            .Select(a => new BagDto()
            {
                Id = a.Id,
                UserName = a.User.Name,
                Product = a.Product
            }).ToList();
        }


        //CreateBag
        public bool CreateBag(CreateBagDto createBagDto)
        {
            try
            {
                context.bags.Add(new Bag()
                {
                    UserId = createBagDto.UserId,
                    ProductId = createBagDto.ProductId
                });
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }



    }
}
