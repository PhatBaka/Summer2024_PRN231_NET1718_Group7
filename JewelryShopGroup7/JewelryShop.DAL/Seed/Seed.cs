using JewelryShop.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JewelryShop.DAL.Seed
{
    public class Seed
    {
        public static async Task SeedAcc(AppDbContext _context)
        {
            if (await _context.Accounts.AnyAsync()) return;
            var orderdes = new List<OrderDetail>
    {
        new OrderDetail
        {
            UnitPrice = 50,
            TotalPrice = 150,
            DiscountPrice = 15,
            FinalPrice = 135,
            DiscountValue = 10,
            Quantity = 3,
            Guarantees = new List<Guarantee>()
        },
        new OrderDetail
        {
            UnitPrice = 100,
            TotalPrice = 200,
            DiscountPrice = 20,
            FinalPrice = 180,
            DiscountValue = 10,
            Quantity = 2
        } 
            };
            var accData = await File.ReadAllTextAsync("../JewelryShop.DAL/Seed/AccountSeed.json");
            var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var accs = JsonSerializer.Deserialize<List<Account>>(accData, jsonOptions);

            foreach (var acc in accs)
            {
                await _context.Accounts.AddAsync(acc);
                var orders = acc.Orders;
                await _context.SaveChangesAsync();
                foreach (var or in orders)
                {
                    or.OrderDetails = orderdes;
                    _context.Orders.Update(or);
                    await _context.SaveChangesAsync();
                }
            }
        }
        public static async Task SeedJew(AppDbContext _context)
        {
            if (await _context.Jewelries.AnyAsync()) return;

            var accData = await File.ReadAllTextAsync("../JewelryShop.DAL/Seed/JewelrySeed.json");
            var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var accs = JsonSerializer.Deserialize<List<Jewelry>>(accData, jsonOptions);

            var image = new Image();
            image.ImageData = Convert.FromBase64String("VGhpcyBpcyBhIHRlc3QgZmlsZSAy");
            var saveimg = await _context.Images.AddAsync(image);
            await _context.SaveChangesAsync(); // save the image first

            foreach (var acc in accs)
            {
                //acc.ImageId = saveimg.Entity.ImageId;
                await _context.Jewelries.AddAsync(acc);
            }
            await _context.SaveChangesAsync(); // save all jewelry items
        }
    }
}
